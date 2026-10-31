USE TPI_Grupo45_Veterinaria;
GO

-- Especies
INSERT INTO Especies (Nombre)
VALUES
('Canina'),
('Felina'),
('Conejo');

-- Duenios
INSERT INTO Duenios (DNI, Nombre, Apellido, Telefono, Email, Direccion)
VALUES
('FICT-D-001', 'Lucia', 'Fernandez', '11-0000-1001', 'lucia.fernandez@example.com', 'Av. Los Aromos 1240, San Martin'),
('FICT-D-002', 'Martin', 'Gomez', '11-0000-1002', 'martin.gomez@example.com', 'Pasaje del Parque 385, Villa Ballester'),
('FICT-D-003', 'Carolina', 'Benitez', '11-0000-1003', 'carolina.benitez@example.com', 'Calle Las Heras 760, San Andres'),
('FICT-D-004', 'Diego', 'Acosta', '11-0000-1004', 'diego.acosta@example.com', 'Los Ceibos 219, Chilavert');

-- Veterinarios
INSERT INTO Veterinarios (DNI, Nombre, Apellido, Matricula, Telefono, Email)
VALUES
('FICT-V-001', 'Sofia', 'Mendez', 'MP-FICT-001', '11-0000-2001', 'sofia.mendez@example.com'),
('FICT-V-002', 'Mariano', 'Quiroga', 'MP-FICT-002', '11-0000-2002', 'mariano.quiroga@example.com'),
('FICT-V-003', 'Paula', 'Sosa', 'MP-FICT-003', '11-0000-2003', 'paula.sosa@example.com');

-- Mascotas: IdDuenio 1..4 e IdEspecie 1=Canina, 2=Felina, 3=Conejo
INSERT INTO Mascotas (IdDuenio, IdEspecie, Nombre, FechaNacimiento, Sexo)
VALUES
(1, 1, 'Nala', '2020-04-18', 'H'),
(1, 2, 'Simba', '2021-09-02', 'M'),
(2, 1, 'Rocco', '2018-12-11', 'M'),
(3, 2, 'Mora', '2022-02-27', 'H'),
(4, 3, 'Tito', '2023-06-05', 'M'),
(2, 1, 'Lola', '2019-07-23', 'H');

-- Medicamentos: el stock inicial permite probar los triggers de descuento y reposicion
INSERT INTO Medicamentos (Nombre, Descripcion, Stock, Precio)
VALUES
('Antiparasitario oral', 'Comprimidos antiparasitarios para uso veterinario', 40, 12500.00),
('Antibiotico veterinario', 'Presentacion oral de uso veterinario', 30, 18400.00),
('Analgesico veterinario', 'Comprimidos de uso veterinario', 25, 9800.00),
('Antiinflamatorio veterinario', 'Suspension oral de uso veterinario', 18, 14200.00),
('Solucion otica veterinaria', 'Solucion para higiene y tratamiento otico', 12, 7600.00),
('Suplemento vitaminico', 'Suplemento de uso veterinario', 20, 8900.00);

-- Vacunas
INSERT INTO Vacunas (Nombre, Descripcion, DuracionMeses)
VALUES
('Antirrabica', 'Vacuna antirrabica para perros y gatos', 12),
('Triple felina', 'Vacuna preventiva para felinos', 12),
('Quintuple canina', 'Vacuna preventiva para caninos', 12),
('Leptospirosis', 'Vacuna preventiva para caninos', 12);

-- Consultas: IdMascota 1 a 6 e IdVeterinario 1 a 3 segun el orden anterior
INSERT INTO Consultas (IdMascota, IdVeterinario, Fecha, Motivo, Diagnostico, Observaciones)
VALUES
(1, 1, '2026-10-12T09:30:00', 'Control general', 'Buen estado general', 'Control anual y actualizacion del plan sanitario.'),
(3, 2, '2026-10-13T11:00:00', 'Irritacion en la piel', 'Dermatitis leve', 'Se indica seguimiento y control evolutivo.'),
(4, 3, '2026-10-14T16:15:00', 'Control preventivo', 'Sin hallazgos relevantes', 'Se revisa estado general y calendario sanitario.'),
(2, 3, '2026-10-15T10:00:00', 'Molestia en un oido', 'Otitis externa leve', 'Se recomienda control posterior.'),
(6, 1, '2026-10-16T14:00:00', 'Dolor al caminar', 'Evaluacion traumatologica inicial', 'Requiere seguimiento profesional.'),
(5, 2, '2026-10-17T09:00:00', 'Revision periodica', 'Estado general estable', 'Control preventivo de rutina.');

-- DetalleConsulta: IdConsulta 1 a 6 e IdMedicamento 1 a 6 segun el orden anterior
-- El trigger AFTER INSERT descuenta estas cantidades del inventario inicial.
INSERT INTO DetalleConsulta (IdConsulta, IdMedicamento, Cantidad, Indicaciones)
VALUES
(1, 1, 1, 'Administrar segun indicacion profesional.'),
(2, 2, 2, 'Completar el esquema indicado por el profesional.'),
(2, 6, 1, 'Administrar segun indicacion profesional.'),
(3, 1, 1, 'Administrar segun indicacion profesional.'),
(4, 5, 1, 'Aplicar segun indicacion profesional.'),
(5, 3, 2, 'Administrar segun indicacion profesional.'),
(6, 4, 1, 'Administrar segun indicacion profesional.');

-- Vacunaciones: IdVacuna 1=Antirrabica, 2=Triple felina, 3=Quintuple, 4=Leptospirosis
INSERT INTO Vacunaciones (IdMascota, IdVacuna, IdVeterinario, FechaAplicacion, FechaProximaAplicacion, Observaciones)
VALUES
(1, 1, 1, '2026-10-12', '2027-10-12', 'Aplicacion registrada en la consulta de control.'),
(3, 3, 2, '2026-10-13', '2027-10-13', 'Refuerzo anual registrado.'),
(4, 2, 3, '2026-10-14', '2027-10-14', 'Refuerzo anual registrado.'),
(2, 2, 3, '2026-10-15', '2027-10-15', 'Refuerzo anual registrado.'),
(6, 4, 1, '2026-10-16', '2027-10-16', 'Refuerzo anual registrado.');

-- Verificacion del inventario final luego de insertar los detalles
SELECT IdMedicamento, Nombre, Stock, Precio
FROM Medicamentos
ORDER BY Nombre;
GO
