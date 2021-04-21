select * from tablero
select * from Usuario
select Nomact from Actividad where idTablero=2

select * from Usuario_Actividad_Valor

--Filas de Integrantes
select U.Usuario from Usuario_tablero AS UT
inner join Usuario AS U ON U.idUsuario=UT.idUsuario
inner join Tablero AS T ON T.idTablero=UT.idTablero
WHERE U.TipoUs='PROFESOR' and T.idTablero=2 ORDER BY U.idUsuario ASC

--Obtiene las puntuaciones de forma idUsuario ascendente
select puntuacion from Usuario_tablero AS UT
INNER JOIN Usuario AS U ON U.idUsuario=UT.idUsuario
where UT.idTablero=1 and U.TipoUs='ALUMNO' order by UT.idUsuario ASC


select * from Usuario_tablero AS UT
INNER JOIN Tablero AS T ON T.idTablero=UT.idTablero
INNER JOIN Actividad AS A ON A.idTablero=T.idTablero





--
select * from usuario
select * from Usuario_tablero
select *from Actividad
select*from Insignia
select * from Usuario_Actividad_Valor
insert into Usuario_Actividad_Valor values (2,4,3,1)


select U.Usuario, I.valor from Usuario_Actividad_Valor AS UAV
INNER JOIN Actividad AS A ON A.idActividad=UAV.idActividad
INNER JOIN Insignia AS I ON I.idInsignia=UAV.idInsignia
INNER JOIN Usuario AS U ON U.idUsuario=UAV.idUsuario
where A.Nomact='Programa con FOR' and UAV.idTablero=1 order by UAV.idUsuario ASC


--
select U.Usuario, UT.puntuacion from Usuario_tablero AS UT inner join Usuario AS U ON U.idUsuario=UT.idUsuario WHERE U.TipoUs='ALUMNO' and UT.idTablero=1 ORDER BY U.idUsuario ASC

select * from Actividad
select * from Insignia
INSERT INTO Insignia (insigniaurl,valor,idTablero) values ('https://i.etsystatic.com/8408931/r/il/bad1d7/609933222/il_794xN.609933222_11qd.jpg',15,2)
select * from Tablero
select * from Usuario_tablero
select * from Usuario_Actividad_Valor
UPDATE Usuario_tablero SET puntuacion=0 WHERE idUsuario=4


Select U.Nombre, U.App, U.Apm, t.titulo,T.Nomclase,T.codigotablero from Usuario_tablero AS UT
INNER JOIN Usuario AS U ON U.idUsuario=UT.idUsuario
INNER JOIN Tablero AS T ON T.idTablero=UT.idTablero
where U.TipoUs='PROFESOR' and T.idTablero=1


insert into Usuario_tablero values (1,2,0)

select * from Usuario_tablero where idTablero=1 and idUsuario=1
select T.idTablero from Usuario_tablero  AS UT INNER JOIN Tablero as T ON T.idTablero=UT.idTablero WHERE T.codigotablero='99oogtemartu140'

--------

SELECT * FROM TABLERO

select * from tablero
select * from Equipo_tablero
SELECT * FROM Usuario_tablero
Select T.idtablero from Equipo_tablero AS ET INNER JOIN Tablero AS T ON T.idTablero=ET.idTablero WHERE T.codigotablero='CNN1'

select * from Usuario_tablero
select * from Equipo
UPDATE Tablero SET codigotablero='CNN1' WHERE idTablero=3
select T.idTablero from Usuario_tablero  AS UT INNER JOIN Tablero as T ON T.idTablero=UT.idTablero WHERE T.codigotablero='H1N1'
select * from Equipo_tablero


Select T.idtablero from Equipo_tablero AS ET INNER JOIN Tablero AS T ON T.idTablero=ET.idTablero WHERE T.codigotablero='H1N1'

select * from equipo
select * from Equipo_tablero where idTablero=2 and idEquipo=1

select * from Equipo_tablero where idTablero=3

select * from Usuario_tablero AS UT INNER JOIN Usuario AS U ON U.idUsuario=UT.idUsuario WHERE U.TipoUs='ALUMNO' AND UT.idTablero=1


Select e.Nomequipo from Equipo_tablero AS ET INNER JOIN Tablero AS T ON T.idTablero=ET.idTablero INNER JOIN Equipo AS E ON E.idEquipo=ET.idEquipo WHERE T.idTablero=2 ORDER BY E.idEquipo

Select * from Equipo_Actividad_Valor
UPDATE Equipo_Actividad_Valor SET idEquipo=1 WHERE idEquipo=2
INSERT INTO Equipo_Actividad_Valor VALUES (2,1,4,2)
select * from Actividad

--
select E.Nomequipo, I.valor from Equipo_Actividad_Valor AS EAV 
INNER JOIN Actividad AS A ON A.idActividad = EAV.idActividad 
INNER JOIN Insignia AS I ON I.idInsignia = EAV.idInsignia 
INNER JOIN Equipo AS E ON E.idEquipo=EAV.idEquipo 
where A.Nomact ='Lectura Breve del principito' and EAV.idTablero = 2 ORDER by EAV.idEquipo ASC

--
UPDATE Equipo_tablero SET puntuacion=15 WHERE puntuacion=0

select E.nomequipo, ET.puntuacion from Equipo_tablero AS ET inner join Equipo AS E ON E.idEquipo=ET.idEquipo WHERE ET.idTablero=2 ORDER BY E.idEquipo ASC




---------
SELECT idUsuario from Usuario where Usuario='siarco';
select idequipo from Equipo where Nomequipo='Los teletubbies'
delete from Usuario where idUsuario=13
select * from Usuario

delete from Usuario_equipo where idEquipo=23
delete from equipo where idEquipo=23


Select * from Usuario_equipo
select * from equipo

delete from Actividad where idTablero=6
delete from Usuario_tablero where idTablero=6
delete from Tablero where idTablero=6

select * from tablero
select * from Usuario_tablero
select * from Actividad

select * from Equipo_tablero where idTablero=2
select nomact AS Actividad from Actividad where idTablero=2
select valor from Insignia where idTablero=2

select * from Usuario_Actividad_Valor

select * from Insignia
select idInsignia from Insignia where valor=5 and idTablero=1
select idUsuario, idActividad from Usuario_Actividad_Valor where idUsuario=(select idUsuario from Usuario where Usuario='Siarco') and idActividad=(select idActividad from Actividad where Nomact='Programa con WHILE')

select * from Usuario_Actividad_Valor
update Usuario_Actividad_Valor set idInsignia=@ins where idUsuario=@us and idActividad=@act and idTablero=@tab
Insert into Usuario_Actividad_Valor (idUsuario,idActividad,idInsignia,idTablero) values (@us,act,ins,tab)

select idactividad from Actividad where Nomact='Programa con FOR' and idTablero=1

select * from Usuario_tablero
update Usuario_tablero set puntuacion=(select sum(I.valor) from Usuario_Actividad_Valor as UAV inner join Insignia as I on I.idInsignia=UAV.idInsignia where UAV.idUsuario=2 and UAV.idTablero=1) where idUsuario=2 and idTablero=1
select sum(I.valor) from Usuario_Actividad_Valor as UAV inner join Insignia as I on I.idInsignia=UAV.idInsignia where UAV.idUsuario=2 and UAV.idTablero=1
------------------
-
--------
---------------
------
---
-
select idUsuario, idActividad from Usuario_Actividad_Valor where idUsuario=(select idUsuario from Usuario where Usuario='Siarco') and idActividad=(select idActividad from Actividad where Nomact='Programa con FOR')

select * from Equipo_Actividad_Valor
select * from Actividad
select * from equipo
select idEquipo, idActividad from Equipo_Actividad_Valor where idEquipo=(select idEquipo from Equipo where Nomequipo='uno') and idActividad=(select idActividad from Actividad where Nomact='Lectura Breve del principito')

Select idEquipo from Equipo where Nomequipo='" + eq + "'

update Equipo_Actividad_Valor set idInsignia=@ins where idEquipo=@eq and idActividad=@act and idTablero=@tab

Insert into Equipo_Actividad_Valor (idEquipo,idActividad,idInsignia,idTablero) values (@eq,@act,@ins,@tab)
select * from Equipo_tablero
update Equipo_tablero set puntuacion=(select sum(I.valor) from Equipo_Actividad_Valor as EAV inner join Insignia as I on I.idInsignia=EAV.idInsignia where EAV.idEquipo=@eq and EAV.idTablero=@tab) where idEquipo=@eq and idTablero=@tab