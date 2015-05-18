INSERT INTO metacatalogo(nombre,descripcion)VALUES
('rol','Roles de usuarios del sistema'),
('area','Areas de la empresa');
GO
INSERT INTO catalogo(nombre,descripcion,metacatalogo_id)VALUES
('Administrador','Administrador general del sistema',1),
('Estandar','Usuario estandar del sistema',1),
('Almacen','Area de almacen de la empresa',2),
('Producción','Area de producción',2),
('Recursos Humanos','Area de recursos humanos',2),
('Ventas','Area de ventas',2);
GO
INSERT INTO usuarios(nombre,username,password,rol_id)VALUES
('Administrador del sistema','admin','e1a965abd6a8ca67b5cb780c83b533c9eb49b967',1),
('Usuario estandar','user','b4d894113178942de203ff5f783edc9e593818be',2);
GO
INSERT INTO empleados(nombre,paterno,materno,ingreso,area_id)VALUES
('Victor','Guzman','Hernandez','2015-05-01',5),
('Guillermo','Carapia','Gayosso','2015-05-01',4),
('Alejandro','Trigueros','Luna','2015-05-01',4),
('Daniel','Hernandez','Meneses','2015-05-01',4),
('Miguel','Trujillo','Perez','2015-05-01',4),
('Antonio','Araiza','Huitron','2015-05-01',3),
('Marco','Becerril','Perez','2015-05-01',3),
('Hugo','Martinez','Juarez','2015-05-01',6),
('Gabriel','Espinoza','Rodriguez','2015-05-01',6);
GO
INSERT INTO productos(serie,codigo,modelo,descripcion)VALUES
('1004201','COPALFA','ALFA','1.20 m X 60 cm'),
('1004202','COPSTAN','STANDAR','90 cm X 60 cm'),
('1004203','COPPETIT','PETIT','75 cm X 60 cm');
GO
INSERT INTO materias(nombre,modelo,unidad,descripcion)VALUES
('Alambre','Calibre 7','mt','Alambre de Calibre 7'),
('Alambre','Calibre 11','mt','Alambre de Calibre 11'),
('Alambre','Calibre 12','mt','Alambre de Calibre 12'),
('Pulido',' de Primera','kg','1kg X 3m'),
('Pintura','Para horneado','kg','630gr X corral'),
('Fosfatizante','LT','lt','Se diluye en 19 lts. de agua para 10 corrales'),
('Antioxidante','Para horneado','lt','1/4 lt X corral'),
('Desengrasante','Para horneado','lt','1/4 lt X corral'),
('Gas','tanque 20 kgs','tanque','1/4 de tanque 30 a 50 paneles'),
('Grapas de lámina','Calibre 26','pza','36 para cada corral'),
('Hojas','4 pies X 8 pies','pza','26 para cada corral'),
('Polistrech','rollo 13 pulgadas','rollo','envolver producto terminado'),
('Papel Kraft','Rollo 1.5 m X 1 m','rollo','para las esquinas'),
('Bandola metálica','No. 2','pza','van dentro del corral');
GO
INSERT INTO compras(materia_id,cantidad,costo,total,fecha)VALUES
(1,100,5.00,500.00,'2015-05-13'),
(2,100,7.00,700.00,'2015-05-13'),
(3,100,8.00,800.00,'2015-05-13'),
(4,30,17.75,532.50,'2015-05-13'),
(5,45,80.00,3600.00,'2015-05-13'),
(6,20,43.00,860.00,'2015-05-13'),
(7,20,11.50,230.00,'2015-05-13'),
(8,20,10.00,200.00,'2015-05-13'),
(9,30,57.00,1710.00,'2015-05-13'),
(10,500,0.50,250.00,'2015-05-13'),
(11,10,285.00,2850.00,'2015-05-13'),
(12,15,37.00,555.00,'2015-05-13'),
(13,25,8.00,200.00,'2015-05-13'),
(14,50,1.98,99.00,'2015-05-13');