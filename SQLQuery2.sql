create database AccesoriosMoviles;
go;

use AccesoriosMoviles;

create table Rol(
Id int not null identity (1,1),
Nombre varchar(30) not null,
primary key (Id)
);
go

Create table Usuario(
Id int not null identity (1,1),
IdRol int not null,
Nombre varchar(30) not null,
Apellido varchar(30) not null,
Login varchar(25) not null,
Password char(32) not null,
Estatus tinyint not null,
FechaRegistro datetime not null,
primary key(Id),
foreign key (IdRol) references Rol(Id)
);
go


create table categoria(
Id int not null identity (1,1),
Nombre varchar(30) not null,
primary key (id)
);
go

Create table Producto(
Id int not null identity (1,1),
IdCategoria int not null,
Nombre varchar(30) not null,
Precio money not null,
Imagen varchar(200) not null,
Descripcion varchar(200) not null,
primary key(Id),
foreign key (IdCategoria) references Categoria(Id)
);
go

