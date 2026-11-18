
USE TPI_Grupo45_Veterinaria;
GO

-- VW_VacunacionesVencidas: mascotas que el plan de vacunacion esta atrasado, con el dato de contacto del dueño para poder avisarle. Usa la funcion FN_EdadMascota.

CREATE VIEW dbo.VW_VacunacionesVencidas AS
SELECT
    m.IdMascota,
    m.Nombre                                 AS Mascota,
    e.Nombre                                 AS Especie,
    dbo.FN_EdadMascota(m.FechaNacimiento)    AS EdadAnios,
    d.Apellido + ', ' + d.Nombre             AS Duenio,
    d.Telefono,
    d.Email,
    vac.Nombre                               AS Vacuna,
    vac.DuracionMeses,
    v.FechaAplicacion                        AS UltimaAplicacion,
    v.FechaProximaAplicacion,
    -- Cuantos dias pasaron desde que correspondia aplicarla: ordena la urgencia
    -- de los llamados a los dueños
    DATEDIFF(DAY, v.FechaProximaAplicacion, CAST(GETDATE() AS DATE)) AS DiasDeAtraso,
    vet.Apellido + ', ' + vet.Nombre         AS AplicadaPor
FROM Vacunaciones v
INNER JOIN Mascotas     m   ON m.IdMascota       = v.IdMascota
INNER JOIN Especies     e   ON e.IdEspecie       = m.IdEspecie
INNER JOIN Duenios      d   ON d.IdDuenio        = m.IdDuenio
INNER JOIN Vacunas      vac ON vac.IdVacuna      = v.IdVacuna
INNER JOIN Veterinarios vet ON vet.IdVeterinario = v.IdVeterinario
-- Si existe una aplicacion POSTERIOR de la misma vacuna a la misma mascota,
-- esta ya fue renovada y no corresponde mostrarla como vencida.
LEFT JOIN Vacunaciones post
       ON post.IdMascota       = v.IdMascota
      AND post.IdVacuna        = v.IdVacuna
      AND post.FechaAplicacion > v.FechaAplicacion
WHERE post.IdVacunacion IS NULL
  AND v.FechaProximaAplicacion IS NOT NULL
  AND v.FechaProximaAplicacion < CAST(GETDATE() AS DATE);
GO

-- VW_HistorialClinico: una fila por consulta con la mascota, el dueñoo, el veterinario y el resumen de medicamentos aplicados. Usa las funciones FN_EdadMascota y FN_TotalConsulta.

CREATE VIEW dbo.VW_HistorialClinico AS
SELECT
    c.IdConsulta,
    c.IdMascota,
    m.Nombre                                 AS Mascota,
    e.Nombre                                 AS Especie,
    dbo.FN_EdadMascota(m.FechaNacimiento)    AS EdadAnios,
    d.Apellido + ', ' + d.Nombre             AS Duenio,
    vet.Apellido + ', ' + vet.Nombre         AS Veterinario,
    vet.Matricula,
    CAST(c.Fecha AS DATE)                    AS Fecha,
    c.Motivo,
    c.Diagnostico,
    c.Observaciones,
    -- Cuantos medicamentos distintos y cuantas unidades en total lleva la consulta.
    COUNT(dc.IdDetalle)                      AS CantidadMedicamentos,
    ISNULL(SUM(dc.Cantidad), 0)              AS UnidadesAplicadas,
    dbo.FN_TotalConsulta(c.IdConsulta)       AS TotalConsulta
FROM Consultas c
INNER JOIN Mascotas        m   ON m.IdMascota       = c.IdMascota
INNER JOIN Especies        e   ON e.IdEspecie       = m.IdEspecie
INNER JOIN Duenios         d   ON d.IdDuenio        = m.IdDuenio
INNER JOIN Veterinarios    vet ON vet.IdVeterinario = c.IdVeterinario
-- LEFT JOIN y no INNER: una consulta sin medicamentos recetados tambien forma
-- parte del historial, y tiene que aparecer con cantidad y total en cero.
LEFT  JOIN DetalleConsulta dc  ON dc.IdConsulta     = c.IdConsulta
GROUP BY
    c.IdConsulta,
    c.IdMascota,
    m.Nombre,
    e.Nombre,
    m.FechaNacimiento,
    d.Apellido,
    d.Nombre,
    vet.Apellido,
    vet.Nombre,
    vet.Matricula,
    c.Fecha,
    c.Motivo,
    c.Diagnostico,
    c.Observaciones;
GO

-- VW_MedicamentosMasUtilizados: ranking de medicamentos por unidades aplicadas, para saber que reponer. Solo muestra los que se usaron 2 o mas veces .

CREATE VIEW dbo.VW_MedicamentosMasUtilizados AS
SELECT
    m.IdMedicamento,
    m.Nombre                                            AS Medicamento,
    m.Stock                                             AS StockActual,
    m.Precio,
    SUM(dc.Cantidad)                                    AS UnidadesAplicadas,
    COUNT(DISTINCT dc.IdConsulta)                       AS ConsultasEnQueSeUso,
    COUNT(DISTINCT c.IdMascota)                         AS MascotasDistintas,
    -- Lo facturado por ese medicamento sumando todas las consultas.
    CAST(SUM(dc.Cantidad) * m.Precio AS DECIMAL(12,2))  AS ImporteTotal,
    CAST(AVG(dc.Cantidad * 1.0) AS DECIMAL(6,2))        AS PromedioPorConsulta,
    MAX(CAST(c.Fecha AS DATE))                          AS UltimaAplicacion
FROM Medicamentos m
INNER JOIN DetalleConsulta dc ON dc.IdMedicamento = m.IdMedicamento
INNER JOIN Consultas       c  ON c.IdConsulta     = dc.IdConsulta
GROUP BY
    m.IdMedicamento,
    m.Nombre,
    m.Stock,
    m.Precio
-- Deja afuera los de uso aislado: el ranking sirve para decidir que reponer,
-- y un medicamento aplicado una sola vez no justifica una compra.
HAVING SUM(dc.Cantidad) >= 2;
GO
