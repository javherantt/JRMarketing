
create table Usuario
(
	ID int identity(1,1) not null,
	NombreUsuario varchar(25) not null,
	Contrasenia varchar(25) not null,
	Nombre varchar(50) not null,
	Apellidos varchar(50) not null,
	Direccion varchar(60) not null,
	Colonia varchar(30) not null,
	Estado varchar(25) not null,
	Ciudad varchar(30) not null,
	CoidgoPostal varchar(5) not null,
	Correo varchar(50) not null,
	FechaNacimiento date not null,
	CreatedAt datetime null,
	UpdatedAt datetime null
);

alter table Usuario add constraint PK_IDUSUARIO primary key(ID);
alter table Usuario add Tipo varchar(10) null

create table Cliente
(
	ID int not null,
	TipoContrato varchar(10) null,
	FinContrato datetime null
);

alter table Cliente add constraint PK_IDCLIENTE primary key(ID);
alter table Cliente add constraint FK_IDCLIENTE foreign key(ID) references Usuario(ID);

create table TelefonoUsuario
(
	ID int not null,
	NumeroUsuario varchar(14) not null,
	CreatedAt datetime null,
	UpdatedAt datetime null
);

alter table TelefonoUsuario add constraint PK_TELEFONOUSUARIO primary key(ID);
alter table TelefonoUsuario add constraint FK_TELEFONOUSUARIO foreign key(ID) references Usuario(ID);

create table Restaurante
(
	ID int identity(1,1) not null,
	NombreRestaurante varchar(70) not null,
	DireccionR varchar(50) not null,
	ColoniaR varchar(30) not null,
	EstadoR varchar(25) not null,
	CiudadR varchar(30) not null,
	CoidgoPostalR varchar(5) not null,
	DescripcionR varchar(500) not null,
	Horario varchar(200) not null,
	FotografiaR varchar(500) null,
	Id_usuarioR int not null,
	CreatedAt datetime null,
	UpdatedAt datetime null
);

alter table Restaurante add constraint PK_IDRESTAURANTE primary key(ID);
alter table Restaurante add constraint FK_IDUSUARIOR foreign key(Id_usuarioR) references Usuario(ID);

create table TelefonoRestaurante
(
	ID int not null,
	NumeroRestaurante varchar(14) not null,
	CreatedAt datetime null,
	UpdatedAt datetime null
);

alter table TelefonoRestaurante add constraint PK_IDTELEFONORESTAU primary key(ID);
alter table TelefonoRestaurante add constraint FK_IDTELEFONORESTAU foreign key(ID) references Restaurante(ID);

create table Publicacion
(
	ID int identity(1,1) not null,
	DescripcionP varchar(600) not null,
	Id_restaurantePubli int not null,
	Foto varchar(450) null,
	CreatedAt datetime null,
	UpdatedAt datetime null
);

alter table Publicacion add constraint PK_IDPUBLICACION primary key(ID);
alter table Publicacion add constraint FK_IDRESTAURANTEPUBLIC foreign key(Id_restaurantePubli) references Restaurante(ID);

/*
create table Foto
(
	ID int identity(1,1) not null,
	FileName varchar(200) not null,
	Url varchar(200) not null,
	FechaSubida Datetime not null,
	Id_publicacionFoto int not null,
	CreatedAt datetime null,
	UpdatedAt datetime null
);


alter table Foto add constraint PK_IDFOTO primary key(ID);
alter table Foto add constraint FK_IDPUBLICACIONFOTO foreign key(Id_publicacionFoto) references Publicacion(ID);

*/

create table Etiqueta
(
	ID int identity(1,1) not null,
	NombreEtiqueta varchar(50) not null,
	CreatedAt datetime null,
	UpdatedAt datetime null
)

alter table Etiqueta add constraint PK_IDETIQUETA primary key(ID);

create table RestauranteEtiqueta
(
	ID_RestauranteEtiq int not null,
	ID_EtiquetaRestau int not null
);

alter table RestauranteEtiqueta add constraint PK_RESTAURANTEETIQUETA primary key clustered(ID_RestauranteEtiq, ID_EtiquetaRestau);
alter table RestauranteEtiqueta add constraint FK_RESTAURANTEETIQUETA foreign key(ID_RestauranteEtiq) references Restaurante(ID);
alter table RestauranteEtiqueta add constraint FK_ETIQUETARESTAU foreign key(ID_EtiquetaRestau) references Etiqueta(ID);
