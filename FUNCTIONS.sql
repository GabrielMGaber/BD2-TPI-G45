-- TPI Base de Datos II / Grupo 45 / Sistema de Gestion Veterinaria
-- Funciones de usuario

USE TPI_Grupo45_Veterinaria;
GO

-- FN_EdadMascota: devuelve la edad de la mascota en anios cumplidos. Devuelve NULL si no se conoce la fecha de nacimiento o si es invalida.

CREATE FUNCTION dbo.FN_EdadMascota (@FechaNacimiento DATE)
RETURNS INT
AS
BEGIN
    DECLARE @hoy DATE = CAST(GETDATE() AS DATE);

    -- Sin fecha, o con una fecha futura, no hay edad que calcular: NULL es
    -- "no se sabe". Devolver 0 diria "recien nacida", que es otra cosa.
    IF @FechaNacimiento IS NULL OR @FechaNacimiento > @hoy
        RETURN NULL;

    DECLARE @anios INT = DATEDIFF(YEAR, @FechaNacimiento, @hoy);

    IF (MONTH(@FechaNacimiento) > MONTH(@hoy))
       OR (MONTH(@FechaNacimiento) = MONTH(@hoy) AND DAY(@FechaNacimiento) > DAY(@hoy))
        SET @anios = @anios - 1;

    RETURN @anios;
END;
GO

-- FN_TotalConsulta: devuelve el importe total de los medicamentos aplicados en la consulta recibida como parametro.

CREATE FUNCTION dbo.FN_TotalConsulta (@IdConsulta INT)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @total DECIMAL(10,2);

    SELECT @total = SUM(dc.Cantidad * m.Precio)
    FROM DetalleConsulta dc
    INNER JOIN Medicamentos m ON m.IdMedicamento = dc.IdMedicamento
    WHERE dc.IdConsulta = @IdConsulta;

    RETURN ISNULL(@total, 0);
END;
GO
