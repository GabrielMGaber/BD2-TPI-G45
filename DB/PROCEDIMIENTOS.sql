
-- Procedimientos almacenados

USE TPI_Grupo45_Veterinaria;
GO

-- SP_RegistrarConsulta: da de alta una consulta medica. Valida con RAISERROR dentro de un TRY/CATCH 

CREATE PROCEDURE dbo.SP_RegistrarConsulta
    @IdMascota      INT,
    @IdVeterinario  INT,
    @Fecha          DATETIME,
    @Motivo         VARCHAR(250),
    @Diagnostico    VARCHAR(500)  = NULL,
    @Observaciones  VARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @FechaNacimiento DATE;

        -- Validaciones de negocio. 
        IF NOT EXISTS (SELECT 1 FROM Mascotas WHERE IdMascota = @IdMascota)
            RAISERROR('La mascota indicada no existe.', 16, 1);

        IF NOT EXISTS (SELECT 1 FROM Veterinarios WHERE IdVeterinario = @IdVeterinario)
            RAISERROR('El veterinario indicado no existe.', 16, 1);

        IF @Motivo IS NULL OR TRIM(@Motivo) = ''
            RAISERROR('El motivo de la consulta es obligatorio.', 16, 1);

        IF @Fecha IS NULL
            RAISERROR('La fecha de la consulta es obligatoria.', 16, 1);

        IF CAST(@Fecha AS DATE) > CAST(GETDATE() AS DATE)
            RAISERROR('La fecha de la consulta no puede ser futura.', 16, 1);

        SELECT @FechaNacimiento = FechaNacimiento
        FROM Mascotas
        WHERE IdMascota = @IdMascota;

        -- FechaNacimiento acepta NULL: solo se compara si hay dato cargado.
        IF @FechaNacimiento IS NOT NULL AND CAST(@Fecha AS DATE) < @FechaNacimiento
            RAISERROR('La fecha de la consulta es anterior al nacimiento de la mascota.', 16, 1);

        -- Evita el duplicado por doble clic.
        IF EXISTS (
            SELECT 1
            FROM Consultas
            WHERE IdMascota     = @IdMascota
              AND IdVeterinario = @IdVeterinario
              AND CAST(Fecha AS DATE) = CAST(@Fecha AS DATE)
        )
            RAISERROR('Ya existe una consulta de esa mascota con ese veterinario en esa fecha.', 16, 1);

        -- Diagnostico y Observaciones pueden quedar vacios: en una consulta de
        -- control no siempre hay diagnostico que cargar.
        INSERT INTO Consultas
            (IdMascota, IdVeterinario, Fecha, Motivo, Diagnostico, Observaciones)
        VALUES
            (@IdMascota, @IdVeterinario, @Fecha, TRIM(@Motivo), @Diagnostico, @Observaciones);

        -- SCOPE_IDENTITY() y no @@IDENTITY: este ultimo podria devolver el Id
        -- generado por un trigger que se disparo en el medio.
        DECLARE @NuevoID INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        SELECT @NuevoID AS IdConsultaCreada;
    END TRY
    BEGIN CATCH
        -- Cualquier error (nuestras validaciones o una constraint de la tabla)
        
        PRINT ERROR_MESSAGE();
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

-- SP_HistorialMascota: reporte parametrizado. Devuelve las consultas, las vacunaciones y un resumen de una mascota en el rango de fechas pedido. Solo lee.

CREATE PROCEDURE dbo.SP_HistorialMascota
    @IdMascota   INT,
    @FechaDesde  DATE = NULL,
    @FechaHasta  DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Sin TRY/CATCH, RAISERROR muestra el error 
    -- el RETURN es el que evita que el reporte siga adelante.
    IF NOT EXISTS (SELECT 1 FROM Mascotas WHERE IdMascota = @IdMascota)
    BEGIN
        RAISERROR('La mascota indicada no existe.', 16, 1);
        RETURN;
    END

    -- Sin fechas => rango amplio 
    SET @FechaDesde = ISNULL(@FechaDesde, '19000101');
    SET @FechaHasta = ISNULL(@FechaHasta, '99991231');

    IF @FechaDesde > @FechaHasta
    BEGIN
        RAISERROR('El rango de fechas es invalido (desde es mayor que hasta).', 16, 1);
        RETURN;
    END

    -- 1) Consultas del periodo. Se lee de la vista, que ya devuelve Fecha como
    -- DATE: filtrar contra Consultas.Fecha (DATETIME) dejaria afuera lo cargado
    -- despues de la medianoche del dia "hasta".
    SELECT
        h.IdConsulta,
        h.Mascota,
        h.Especie,
        h.EdadAnios,
        h.Duenio,
        h.Veterinario,
        h.Fecha,
        h.Motivo,
        h.Diagnostico,
        h.Observaciones,
        h.CantidadMedicamentos,
        h.UnidadesAplicadas,
        h.TotalConsulta
    FROM VW_HistorialClinico h
    WHERE h.IdMascota = @IdMascota
      AND h.Fecha BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY h.Fecha DESC;

    -- 2) Vacunaciones del periodo.
    SELECT
        v.IdVacunacion,
        vac.Nombre                        AS Vacuna,
        vac.DuracionMeses,
        v.FechaAplicacion,
        v.FechaProximaAplicacion,
        vet.Apellido + ', ' + vet.Nombre  AS Veterinario,
        v.Observaciones,
        -- Estado de cada vacuna al dia de hoy, para que el veterinario vea en la
        -- misma ficha si hay algo pendiente 
        CASE
            WHEN v.FechaProximaAplicacion IS NULL THEN 'SIN PROXIMA FECHA'
            WHEN v.FechaProximaAplicacion < CAST(GETDATE() AS DATE) THEN 'VENCIDA'
            ELSE 'AL DIA'
        END                               AS Situacion
    FROM Vacunaciones v
    INNER JOIN Vacunas      vac ON vac.IdVacuna      = v.IdVacuna
    INNER JOIN Veterinarios vet ON vet.IdVeterinario = v.IdVeterinario
    WHERE v.IdMascota = @IdMascota
      AND v.FechaAplicacion BETWEEN @FechaDesde AND @FechaHasta
    ORDER BY v.FechaAplicacion DESC;

    -- 3) Resumen del periodo: es lo que se le informa al duenio cuando pide un
    -- detalle de lo gastado en la atencion de su mascota.
    SELECT
        (SELECT COUNT(*)
         FROM VW_HistorialClinico h
         WHERE h.IdMascota = @IdMascota
           AND h.Fecha BETWEEN @FechaDesde AND @FechaHasta)           AS CantidadConsultas,
        (SELECT ISNULL(SUM(h.TotalConsulta), 0)
         FROM VW_HistorialClinico h
         WHERE h.IdMascota = @IdMascota
           AND h.Fecha BETWEEN @FechaDesde AND @FechaHasta)           AS ImporteTotal,
        (SELECT COUNT(*)
         FROM Vacunaciones v
         WHERE v.IdMascota = @IdMascota
           AND v.FechaAplicacion BETWEEN @FechaDesde AND @FechaHasta) AS VacunasAplicadas,
        (SELECT MIN(h.Fecha)
         FROM VW_HistorialClinico h
         WHERE h.IdMascota = @IdMascota
           AND h.Fecha BETWEEN @FechaDesde AND @FechaHasta)           AS PrimeraConsulta,
        (SELECT MAX(h.Fecha)
         FROM VW_HistorialClinico h
         WHERE h.IdMascota = @IdMascota
           AND h.Fecha BETWEEN @FechaDesde AND @FechaHasta)           AS UltimaConsulta;
END;
GO
