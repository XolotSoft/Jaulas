CREATE DATABASE jaulas;
GO
USE jaulas;
GO
CREATE TABLE metacatalogo(
id int IDENTITY NOT NULL PRIMARY KEY,
nombre varchar(255),
descripcion varchar(255),);
GO
CREATE TABLE catalogo(
id int IDENTITY NOT NULL PRIMARY KEY,
nombre varchar(255),
descripcion varchar(255),
metacatalogo_id int,
CONSTRAINT catalogo_metacatalogo
FOREIGN KEY (metacatalogo_id)
REFERENCES metacatalogo(id)
ON DELETE CASCADE);
GO
CREATE TABLE usuarios(
id int IDENTITY NOT NULL PRIMARY KEY,
nombre varchar(255),
username varchar(255),
password varchar(255),
rol_id int,
CONSTRAINT usuarios_rol
FOREIGN KEY (rol_id)
REFERENCES catalogo(id)
ON DELETE CASCADE);
GO
CREATE TABLE empleados(
id int IDENTITY NOT NULL PRIMARY KEY,
nombre varchar(255),
paterno varchar(255),
materno varchar(255),
ingreso date,
area_id int,
CONSTRAINT empleado_area
FOREIGN KEY (area_id)
REFERENCES catalogo(id)
ON DELETE CASCADE);
GO
CREATE TABLE productos(
id int IDENTITY NOT NULL PRIMARY KEY,
serie varchar(255),
codigo varchar(255),
modelo varchar(255),
descripcion varchar(255));
GO
CREATE TABLE materias(
id int IDENTITY NOT NULL PRIMARY KEY,
nombre varchar(255),
modelo varchar(255),
unidad varchar(255),
descripcion varchar(255));
GO
CREATE TABLE compras(
id int IDENTITY NOT NULL PRIMARY KEY,
materia_id int,
cantidad int,
costo decimal(9,2),
total decimal(9,2),
fecha date,
CONSTRAINT compras_materia
FOREIGN KEY (materia_id)
REFERENCES materias(id)
ON DELETE CASCADE);
GO
CREATE TABLE stock_productos(
id int IDENTITY NOT NULL PRIMARY KEY,
producto_id int,
cantidad int,
CONSTRAINT stock_producto
FOREIGN KEY (producto_id)
REFERENCES productos(id)
ON DELETE CASCADE);
GO
CREATE TABLE stock_materias(
id int IDENTITY NOT NULL PRIMARY KEY,
materia_id int,
cantidad int,
CONSTRAINT stock_materia
FOREIGN KEY (materia_id)
REFERENCES materias(id)
ON DELETE CASCADE);
GO
CREATE TRIGGER compras_stock
ON compras
AFTER INSERT
AS
BEGIN
DECLARE @id int, @cantidad int
SET @id = (SELECT materia_id FROM inserted)
SET @cantidad = (SELECT cantidad FROM inserted)
UPDATE stock_materias SET stock_materias.cantidad = stock_materias.cantidad +  @cantidad
WHERE stock_materias.materia_id = @id;
END
GO
CREATE TRIGGER materias_stock
ON materias
AFTER INSERT
AS
BEGIN
DECLARE @id int
SET @id = (SELECT id FROM inserted)
INSERT INTO stock_materias(materia_id,cantidad)
VALUES( @id, 0)
END
GO
CREATE TRIGGER productos_stock
ON productos
AFTER INSERT
AS
BEGIN
DECLARE @id int
SET @id = (SELECT id FROM inserted)
INSERT INTO stock_productos(producto_id,cantidad)
VALUES( @id, 0)
END