--UNIVERSIDAD TECNICA NACIONAL
--Autor: John Paul Alfaro Carballo
--PROFESORA: KARLINNA VANESSA CHAVES GONZALES
--Anno: 2020 5CT PROGRAMACION 3
--Script AppJustEat  

-------------------------------------------------------------------------------------------------------
-----------------------------I N S E R T S _ T A B L A S _ T I P O S ----------------------------------
-------------------------------------------------------------------------------------------------------

--INSERT TABLA CATEGORIA TARJETA 
INSERT INTO CategoriaTarjeta VALUES ('VISA');
INSERT INTO CategoriaTarjeta VALUES ('MASTER CARD');
SELECT * FROM CategoriaTarjeta

--INSERT TABLA CATEGORIA USUARIO
INSERT INTO CategoriaUsuario VALUES('USUARIO_CLIENTE','false');
INSERT INTO CategoriaUsuario VALUES('USUARIO_EMPRESA','true');
INSERT INTO CategoriaUsuario VALUES('USUARIO_REPARTIDOR','true');
INSERT INTO CategoriaUsuario VALUES('USUARIO_ADMINISTRADOR','false');
SELECT * FROM CategoriaUsuario

--INSERT TABLA CATEGORIA ARTICULO
INSERT INTO CategoriaArticulo VALUES('PRODUCTO');
INSERT INTO CategoriaArticulo VALUES('CUPON');
SELECT * FROM CategoriaArticulo

--INSERT TABLA CATEGORIA VEHICULO
INSERT INTO CategoriaTransporte VALUES('AUTOMOVIL');
INSERT INTO CategoriaTransporte VALUES('MOTOCICLETA');
INSERT INTO CategoriaTransporte VALUES('BICICLETA');
SELECT * FROM CategoriaTransporte


-------------------------------------------------------------------------------------------------------
-----------------------------I N S E R T S _ T A B L A S _ P A D R E S---------------------------------
-------------------------------------------------------------------------------------------------------

--INSERT TARJETA
INSERT INTO Tarjeta VALUES ('4063761078819482','411','2024/10/21 09:09:12',1);
INSERT INTO Tarjeta VALUES ('4698238357510812','562','2022/04/21 09:09:12',1);
INSERT INTO Tarjeta VALUES ('4192431648260005','327','2023/03/21 09:09:12',1);
INSERT INTO Tarjeta VALUES ('4186618775819276','824','2025/04/21 09:09:12',1);
INSERT INTO Tarjeta VALUES ('5444649984234648','433','2021/06/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5181334088411957','322','2026/08/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5397403061179707','821','2028/09/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5542910767059656','322','2022/02/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5569642482971836','652','2023/01/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5142080095522553','119','2023/01/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5121114777287550','433','2023/05/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5443582898719241','322','2025/03/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5325065299416578','821','2026/03/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5442932731567953','322','2028/04/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5244357968487495','652','2021/08/21 09:09:12',2);
INSERT INTO Tarjeta VALUES ('5200012950342818','119','2021/09/21 09:09:12',2);

INSERT INTO Tarjeta VALUES ('5200012950342818','119','2021/09/21 09:09:12',2);

SELECT * FROM Tarjeta

--INSERT VEHICULO
INSERT INTO Transporte VALUES('Toyota','Corolla','Verde',567895,'true',1);
INSERT INTO Transporte VALUES('Toyota','Rav4','Negro',678932,'true',1);
INSERT INTO Transporte VALUES('Toyota','Prado','Blanco',908756,'true',1);
INSERT INTO Transporte VALUES('Honda','125F','Roja',567895,'true',2);
INSERT INTO Transporte VALUES('Suzuki','Gixxer','Azul',678932,'true',2);
INSERT INTO Transporte VALUES('Yamaha','MT-10','Negro Carbon',987632,'true',2);
INSERT INTO Transporte VALUES('Trek','Excaliber','Blaca con rojo',null,null,3);
INSERT INTO Transporte VALUES('Scott','Spark','Anaranjada',null,null,3);
INSERT INTO Transporte VALUES('Cannondale','Trail 7','Verde chillon',null,null,3);
SELECT * FROM Transporte

--INSERT USUARIO
INSERT INTO Usuario VALUES(000000000,'ADMINISTRADOR',NULL,'(506)00000000','9.936441','-84.107862','Estadio Nacional,SJ,CR','admin','admin',1,4,NULL,NULL,'ACTIVO');

INSERT INTO Usuario VALUES(101170789,'Joan','Sebastian','(506)60870945','9.863942','-83.913325','Basilica de los Angeles,CR,CR','joan@gmail.com','1234',2,3,1,0.0,'ACTIVO');
INSERT INTO Usuario VALUES(109870243,'Vicente','Fernandez','(506)60265321','9.998087','-84.117512','Heredia Centro,CR','vicente@gmail.com','1234',3,3,2,0.0,'ACTIVO');
INSERT INTO Usuario VALUES(109870564,'Ana','Barbara','(506)89039076','10.011502','-84.275462','Zoo Ave,AL,CR','ana@gmail.com','1234',4,3,3,0.0,'ACTIVO');

INSERT INTO Usuario VALUES(208970658,'Taco Bell',NULL,'(506)60550987','10.016193','-84.212994','Alajuela Centro,CR','tacobell@gmail.com','1234',5,2,NULL,0.0,'ACTIVO');
INSERT INTO Usuario VALUES(203410907,'Kentucky Fried Chicken',NULL,'(506)89730978','10.016252','-84.212867','Alajuela Centro,CR','kfc@gmail.com','1234',6,2,NULL,0.0,'ACTIVO');
INSERT INTO Usuario VALUES(204670857,'Mcdonalds',NULL,'(506)70982321','10.012390','-84.210357','Alajuela Centro,CR','mac@gmail.com','1234',7,2,NULL,0.0,'ACTIVO');

INSERT INTO Usuario VALUES(308670917,'Ariana','Grande','(506)70189032','10.005075','-84.218803','Alajuela Centro,CR','ariana@gmail.com','1234',8,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(302690411,'Christian','Nodal','(506)73456742','9.873989','-83.919086','Cartago Centro,CR,CR','cris@gmail.com','1234',9,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(302110899,'Carin','Leon','(506)71230867','10.009731','-84.224318','Alajuela Centro,CR','carin@gmail.com','1234',10,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(409780542,'Justin','Quiles','(506)74590442','9.998076','-84.191673','Rio Segundo,CR','justin@gmail.com','1234',11,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(403210899,'Harry','Styles','(506)70156324','10.021310','-84.125470','Barba Heredia,CR','harry@gmail.com','1234',12,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(402660768,'Dua','Lipa','(506)80482893','9.998234','-84.093190','San Pablo Heredia,CR','dua@gmail.com','1234',13,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(506750322,'Lenin','Ramirez','(506)83626900','10.018633','-84.187000','Desamparados, AL,CR','lenin@gmail.com','1234',14,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(504000110,'Daddy','Yankee','(506)82017962','10.039540','-84.162967','Santa Barbara Heredia,CR','daddy@gmail.com','1234',15,1,NULL,NULL,'ACTIVO');
INSERT INTO Usuario VALUES(509110321,'Cristiano','Ronaldo','(506)60744100','10.033016','-84.289547','Tacares,AL,CR','cristiano@gmail.com','1234',16,1,NULL,NULL,'ACTIVO');
SELECT * FROM Usuario; 