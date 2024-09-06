CREATE DATABASE BG_692024;
GO

USE BG_692024;
GO

-- Crear tabla de Clientes
CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    CorreoElectronico NVARCHAR(100) UNIQUE NOT NULL,
	usuario NVARCHAR(100) NOT NULL,
	Contraseña NVARCHAR(100) NOT NULL
);
GO

-- Crear tabla de Préstamos
CREATE TABLE Prestamos (
    IdPrestamo INT IDENTITY(1,1) PRIMARY KEY,
    Monto DECIMAL(18,2) NOT NULL,
    Plazo INT NOT NULL, -- en meses
    TasaInteres DECIMAL(5,2) NOT NULL, -- en porcentaje
    Estado NVARCHAR(50) NOT NULL, -- Por ejemplo: 'Pendiente', 'Aprobado', 'Rechazado'
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente)
);
GO

-- Crear tabla de Pagos
CREATE TABLE Pagos (
    IdPago INT IDENTITY(1,1) PRIMARY KEY,
    IdPrestamo INT FOREIGN KEY REFERENCES Prestamos(IdPrestamo),
    FechaPago DATE NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Capital DECIMAL(18,2) NOT NULL,
    Interes DECIMAL(18,2) NOT NULL,
    Comisiones DECIMAL(18,2) NULL
);
GO


-- Insertar registros en la tabla de Clientes
INSERT INTO Clientes (Nombre, CorreoElectronico,usuario, Contraseña)
VALUES 
('Juan Pérez', 'juan.perez@example.com', 'Juan', '12345'),
('María Gómez', 'maria.gomez@example.com','Maria', '12345'),
('Carlos López', 'carlos.lopez@example.com','Carlos', '12345'),
('Ana Rodríguez', 'ana.rodriguez@example.com','Ana', '12345'),
('Luis Fernández', 'luis.fernandez@example.com','Luis', '12345');
GO

-- Insertar registros en la tabla de Préstamos
-- Asegúrate de que los IdCliente coincidan con los registros en la tabla Clientes
INSERT INTO Prestamos (Monto, Plazo, TasaInteres, Estado, IdCliente)
VALUES 
(5000.00, 24, 5.00, 'Aprobado', 1),
(10000.00, 36, 4.50, 'Pendiente', 2),
(15000.00, 12, 6.00, 'Aprobado', 3),
(20000.00, 60, 5.25, 'Rechazado', 4),
(8000.00, 24, 5.75, 'Aprobado', 5);
GO

-- Insertar registros en la tabla de Pagos
-- Asegúrate de que los IdPrestamo coincidan con los registros en la tabla Prestamos
INSERT INTO Pagos (IdPrestamo, FechaPago, Monto, Capital, Interes, Comisiones)
VALUES 
(6, '2024-01-15', 250.00, 200.00, 50.00, 0.00),
(6, '2024-02-15', 250.00, 205.00, 45.00, 0.00),
(2, '2024-03-15', 300.00, 250.00, 50.00, 0.00),
(3, '2024-04-15', 500.00, 480.00, 20.00, 0.00),
(4, '2024-05-15', 400.00, 390.00, 10.00, 0.00);
GO
