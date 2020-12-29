CREATE DATABASE BD_FINAL_MACURI;

USE BD_FINAL_MACURI;


create table Profesor
(
id int identity(1,1) primary key not null,
nombre varchar(100),
dni varchar(8),
fechaNac date,
telefono int,
correo varchar(100)
)

create table Estudiante
(
id int identity(1,1) primary key not null,
nombre varchar(100),
dni varchar(8),
fechaNac date,
telefono int,
correo varchar(100),
nivel varchar(5),
grado varchar (2)
)

create table Curso 
(
id int identity(1,1) primary key not null,
Nombre varchar(100)
)

create table Evaluacion 
(
id int identity(1,1) primary key not null,
descripcion varchar(100)
)

create table Registro
(
id int identity(1,1) primary key not null,
idProfesor int 
foreign key (idProfesor) references profesor(id),
idCurso int
foreign key (idCurso) references curso(id),
fechaInicio date,
fechaTermino date
)

create table Notas
(
id int identity(1,1) primary key not null,
idEstudiante int 
foreign key (idEstudiante) references estudiante(id),
idEvaluacion int
foreign key (idEvaluacion) references evaluacion(id),
nota varchar(2)
)


SELECT * from Information_Schema.Tables

insert into profesor (nombre, dni, FechaNac, Telefono,Correo) values ('joe castillo','09512345','1979-03-15','959595959','joe@correo.com');
insert into profesor (nombre, dni, FechaNac, Telefono,Correo) values ('jose haya','09564321','1985-05-25','998877661','haya@correo.com');
insert into profesor (nombre, dni, FechaNac, Telefono,Correo) values ('carlos ampuero','09512345','1975-04-05','941234789','ampuero@correo.com');

select * from profesor

use master;

drop database BD_FINAL_MACURI;

