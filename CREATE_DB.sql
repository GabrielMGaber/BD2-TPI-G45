-- TPI Base de Datos II --
-- Grupo 45 / Sistema de Gestion Veterinaria --

CREATE DATABASE TPI_Grupo45_Veterinaria 
COLLATE Modern_Spanish_CI_AI;
GO

USE TPI_Grupo45_Veterinaria;
GO

CREATE TABLE Especies (
    IdEspecie INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Duenios (
    IdDuenio INT IDENTITY(1,1) PRIMARY KEY,
    DNI VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Telefono VARCHAR(30),
    Email VARCHAR(100),
    Direccion VARCHAR(150),
    CHECK (Email IS NULL OR
           (Email LIKE '%_@_%._%' AND Email NOT LIKE '% %'))
);
GO

CREATE TABLE Veterinarios (
    IdVeterinario INT IDENTITY(1,1) PRIMARY KEY,
    DNI VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Matricula VARCHAR(30) NOT NULL UNIQUE,
    Telefono VARCHAR(30),
    Email VARCHAR(100),
    CHECK (Email IS NULL OR
           (Email LIKE '%_@_%._%' AND Email NOT LIKE '% %'))
);
GO

CREATE TABLE Mascotas (
    IdMascota INT IDENTITY(1,1) PRIMARY KEY,
    IdDuenio INT NOT NULL,
    IdEspecie INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    FechaNacimiento DATE,
    Sexo CHAR(1),
    FOREIGN KEY (IdDuenio) REFERENCES Duenios(IdDuenio),
    FOREIGN KEY (IdEspecie) REFERENCES Especies(IdEspecie),
    CHECK (Sexo IS NULL OR Sexo IN ('M', 'H'))
);
GO

CREATE TABLE Medicamentos (
    IdMedicamento INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(250),
    Stock INT NOT NULL DEFAULT 0 CHECK (Stock >= 0),
    Precio DECIMAL(10,2) NOT NULL CHECK (Precio > 0)
);
GO

CREATE TABLE Vacunas (
    IdVacuna INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(250),
    DuracionMeses SMALLINT NOT NULL CHECK (DuracionMeses > 0)
);
GO

CREATE TABLE Consultas (
    IdConsulta INT IDENTITY(1,1) PRIMARY KEY,
    IdMascota INT NOT NULL,
    IdVeterinario INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Motivo VARCHAR(250) NOT NULL,
    Diagnostico VARCHAR(500),
    Observaciones VARCHAR(1000),
    FOREIGN KEY (IdMascota) REFERENCES Mascotas(IdMascota),
    FOREIGN KEY (IdVeterinario) REFERENCES Veterinarios(IdVeterinario)
);
GO

CREATE TABLE DetalleConsulta (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdConsulta INT NOT NULL,
    IdMedicamento INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    Indicaciones VARCHAR(500),
    UNIQUE (IdConsulta, IdMedicamento),
    FOREIGN KEY (IdConsulta) REFERENCES Consultas(IdConsulta),
    FOREIGN KEY (IdMedicamento) REFERENCES Medicamentos(IdMedicamento)
);
GO

CREATE TABLE Vacunaciones (
    IdVacunacion INT IDENTITY(1,1) PRIMARY KEY,
    IdMascota INT NOT NULL,
    IdVacuna INT NOT NULL,
    IdVeterinario INT NOT NULL,
    FechaAplicacion DATE NOT NULL,
    FechaProximaAplicacion DATE,
    Observaciones VARCHAR(500),
    FOREIGN KEY (IdMascota) REFERENCES Mascotas(IdMascota),
    FOREIGN KEY (IdVacuna) REFERENCES Vacunas(IdVacuna),
    FOREIGN KEY (IdVeterinario) REFERENCES Veterinarios(IdVeterinario),
    CHECK (FechaProximaAplicacion IS NULL OR
           FechaProximaAplicacion >= FechaAplicacion)
);
GO