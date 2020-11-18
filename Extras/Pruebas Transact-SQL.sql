
--Usuarios
insert into Usuario(NombreUsuario,Contrasenia,Nombre,Apellidos,Direccion,Colonia,Estado,Ciudad,CoidgoPostal,Correo,FechaNacimiento,CreatedAt,UpdatedAt)
values ('Javierantonio092','12345678','Javier Antonio','Hernández Tun','C. 47 entre 12 y 14','Leandro Valle','Yucatán','Mérida','97143','javierantonio092@gmail.com','2000-12-06','2020-11-17','2020-11-17')

insert into Usuario(NombreUsuario,Contrasenia,Nombre,Apellidos,Direccion,Colonia,Estado,Ciudad,CoidgoPostal,Correo,FechaNacimiento,CreatedAt,UpdatedAt) values ('Roussesmar2001',
'12345678','Rosario','Escalante Martin','C. 47 entre 12 y 14','Santa Rosa','Yucatán','Mérida','97133','lupie103@gmail.com','2000-12-12','2020-11-17','2020-11-17')


insert into Etiqueta(NombreEtiqueta, CreatedAt, UpdatedAt) values('Tacos', '2020-11-17', '2020-11-17')
insert into Etiqueta(NombreEtiqueta, CreatedAt, UpdatedAt) values('Hamburguesas','2020-11-17','2020-11-17')

select * from Etiqueta
select * from Usuario