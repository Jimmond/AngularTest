create database clientesDB

use clientesDB

create table TBL_CLIENTE(
ClienteId int identity(1,1),
Nombre varchar(60),
Apellido varchar(60),
Direccion varchar(220),
)

insert into TBL_CLIENTE values 
('Jimmy','Ortiz','Av monumental #9, residencial nuevas terrazas, apt BE 101')

select * from TBL_CLIENTE  