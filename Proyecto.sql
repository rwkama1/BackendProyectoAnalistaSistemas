--	use master
--go

--if exists(Select * FROM SysDataBases WHERE name='Proyecto')
--BEGIN
--	DROP DATABASE Proyecto
--END
--go


--CREATE DATABASE Proyecto
--ON(
--	NAME=Proyecto,
--	FILENAME='D:\Proyecto.mdf'
--)
--go

--USE Proyecto
--go
-----TABLAS
CREATE TABLE Producto(
	IdProducto int NOT NULL IDENTITY(1,1) Primary key,
	NomProd varchar(200) NOT NULL,
	DescProd varchar(1000) NOT NULL,
	StockProd bigint not null,
	UbicProd varchar(100) NOT NULL,
	PrecioProd money NOT NULL,
	CatProd varchar(40) not null,
	BajaProd bit not null default 0
		
) 
go
CREATE TABLE Cliente(
	IdCliente int NOT NULL IDENTITY(1,1) Primary key,
	CedulaCli int NOT NULL unique,
	NomCli varchar(50) NOT NULL,
	DirCli varchar(50) NOT NULL,
	telCli varchar(50) not null,
	PassCli varchar(50) not null
) 
go
CREATE TABLE Proveedor(
	IdProveedor int NOT NULL IDENTITY(1,1) Primary key,
	RutProv varchar(50) NOT NULL unique,
	NomProve varchar(50) NOT NULL,
	DirProve varchar(100) NOT NULL,
	telProve varchar(50) not null,
	BajaProv bit not null default 0
) 
go

CREATE TABLE Usuario(
	Idusu int NOT NULL IDENTITY(1,1) Primary key,
	CedulaUsu bigint NOT NULL unique,
	NombreUsu varchar(20) NOT NULL,
	ClaveUsu varchar(20) not null,
	Sueldo money NOT NULL,
	FechaIngreso Date NOT NULL default getdate(),
	BajaUsu bit not null default 0
) 
go

CREATE TABLE Cadete(
IdCadete int NOT NULL IDENTITY(1,1) primary key,
cedulaCadete bigint unique NOT NULL  foreign key references Usuario(CedulaUsu),
BajaCad bit not null default 0
	
) 
go
CREATE TABLE Stocker(

	IdStocker int NOT NULL IDENTITY(1,1) primary key ,
    cedulaStocker bigint NOT NULL  foreign key references Usuario(CedulaUsu)
) 
go
CREATE TABLE Administrador(
		IdAdministrador int NOT NULL IDENTITY(1,1) primary key ,
        cedulaAdministrador bigint NOT NULL  foreign key references Usuario(CedulaUsu)
) 
go
CREATE TABLE Vendedor(
		IdVendedor int NOT NULL IDENTITY(1,1) primary key ,
    cedulaVendedor bigint unique NOT NULL foreign key references Usuario(CedulaUsu),
	BajaV bit not null default 0
) 
go
CREATE TABLE Cajero(
			IdCajero int NOT NULL IDENTITY(1,1) primary key ,
    cedulaCajero bigint NOT NULL foreign key references Usuario(CedulaUsu),
	
) 
go
CREATE TABLE Tecnico(
	IdTecnico int NOT NULL IDENTITY(1,1) primary key ,
    cedulaTecnico bigint NOT NULL unique foreign key references Usuario(CedulaUsu),
	BajaTec bit not null default 0
)
go
CREATE TABLE Mensaje(
	IdMensaje int NOT NULL IDENTITY(1,1) Primary key,
	ComentarioMens varchar(1000) NOT NULL,
	Clicom int  not NULL  foreign key references Cliente(CedulaCli),
	Vendresp bigint NULL  foreign key references Vendedor(cedulaVendedor),
	RespuestaMens varchar(1000) not NULL,
	Fechaenvio Datetime not null default getdate(),
	Fecharespuesta Datetime  null default getdate()
) 
go
CREATE TABLE FacturaCompra(
	IdFC int NOT NULL IDENTITY(1,1) unique,
    NumeroFC varchar(60) NOT NULL ,
	ProvFC varchar(50)  not NULL foreign key references Proveedor(RutProv),
	FechaFC DateTime  not NULL ,
	ImpuestosFC money null ,
	SubtotalFC money null,
	TotalFC money null,
	Primary Key(NumeroFC,ProvFC)
) 
go
CREATE TABLE LineaFacturaCompra(
	IdLFC int NOT NULL IDENTITY(1,1),
	ProductoLFC int  not NULL  foreign key references Producto(IdProducto),
	IdFacturaCompra int not null foreign key references FacturaCompra(IdFC),
	CantidadLFC int not null,
	ImporteLFC money not null,
	primary key(IdLFC,ProductoLFC,IdFacturaCompra)

) 
go
CREATE TABLE PagoTarjeta(
	IDPT int NOT NULL IDENTITY(1,1),
    NumeroT bigint  not null unique,
	ClienteT int  not null foreign key references Cliente(CedulaCli),
	CantidadCuT int not null,
	TotalT money not null,
	primary key(IDPT,NumeroT,ClienteT)
) 
go
CREATE TABLE Cuota(
	IDCu int NOT NULL IDENTITY(1,1) primary key,
    ImporteCu money  not null ,
	NumeroTCU bigint  not null foreign key references PagoTarjeta(NumeroT),
	
) 
go
CREATE TABLE Venta(
	IdV int NOT NULL IDENTITY(1,1) primary key,
	FechaV DateTime  not NULL ,
	VencimientoV DateTime  not NULL ,
	MetodoPagoV varchar(50)  not NULL ,
	ClienteV int null foreign key references Cliente(CedulaCli),
	TarjetaV bigint  null foreign key references PagoTarjeta(NumeroT),
	ImpuestosV money not null ,
	SubtotalV money not null,
	TotalV money not null,
	FormaEntregaV varchar(50) not null,
	EstadoV varchar(50) not null

) 
go
CREATE TABLE LineaVenta(
	IdLV int NOT NULL IDENTITY(1,1),
	ProductoLV int  not NULL  foreign key references Producto(IdProducto),
	IdV int not null foreign key references Venta(IdV),
	CantidadLV int not null,
	ImporteLV money not null,
	primary key(IdLV,ProductoLV,IdV)

) 
go
CREATE TABLE Compra(
	IdC int NOT NULL IDENTITY(1,1) primary key,
	FechaC DateTime  not NULL ,
	MetodoPagoC varchar(50)  not NULL ,
	ClienteC int null foreign key references Cliente(CedulaCli),
	ImpuestosC money not null ,
	SubtotalC money not null,
	TotalC money not null,
	FormaEntregaC varchar(50) not null,
	EstadoC varchar(50) not null

) 
go
CREATE TABLE LineaCompra(
    IdLC int NOT NULL IDENTITY(1,1),
	ProductoLC int  not NULL  foreign key references Producto(IdProducto),
	IdC int not null foreign key references Compra(IdC),
	CantidadLC int not null,
	ImporteLC money not null,
	
	primary key(IdLC,ProductoLC,IdC)

) 
go
CREATE TABLE OrdenTaller(
    IdOT int NOT NULL IDENTITY(1,1),
	ProductoOT int  not NULL  foreign key references Producto(IdProducto),
	FechaOT datetime not null,
	ClienteOT int not null foreign key references Cliente(CedulaCli),
	DeclaracionCOT varchar(1000) not null,
	EstadoOT varchar(100) not null,
	PrecioOT money not null,
	ComentarioOT varchar(100) not null,

	TecnicoOT bigint NOT NULL  foreign key references Tecnico(cedulaTecnico),
	primary key(IdOT,ProductoOT,ClienteOT,TecnicoOT)

) 
go
CREATE TABLE OrdenEnvio(
    IdOE int NOT NULL IDENTITY(1,1) unique,
	VentaOE  int not null foreign key references Venta(IdV),
	ClienteOE  int not null foreign key references Cliente(CedulaCli),
	CadeteOE  bigint not null foreign key references Cadete(cedulaCadete),
	UbicacionOE varchar(1000) not null,
	LocalidadOE varchar(100)not null,
	FechaOE datetime not null,
	EstadoOE varchar(100) not null,
	primary key(IdOE,VentaOE)
) 
go
CREATE TABLE ProductosOE(
    IdProdOE int NOT NULL IDENTITY(1,1),
	POE int  not NULL  foreign key references Producto(IdProducto),
	IdOrdenE int not null foreign key references OrdenEnvio(IdOE),
	primary key(IdProdOE,IdOrdenE,POE)
) 
go
insert  Proveedor(RutProv,NomProve,DirProve,telProve) values('12345678985','Proveedor1','Fructoso Rivera 125','0111111')
insert  Proveedor(RutProv,NomProve,DirProve,telProve) values('98567412305','Proveedor2','Wall Street 145','0222222')
insert  Proveedor(RutProv,NomProve,DirProve,telProve) values('85674123654','Proveedor3','Calle Libertad 254','0333333')

go
insert  Cliente(CedulaCli,NomCli,DirCli,telCli,PassCli) values(12345600,'Juansito','Direccion1','08888888','cli1')
insert  Cliente(CedulaCli,NomCli,DirCli,telCli,PassCli) values(65432100,'Fulanito','Direccion2','07777777','cli2')
go


insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Teclado Kolke','Teclado ultra resistente, no es blando como un teclado simple de membrana, pero tampoco duro como los mecánicos.',1000,'Local',345,'Perifericos')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Impresora Brother','Viene equipada con las funciones que usted necesita para obtener resultados excepcionales. Imprima y ahorre dinero con las botellas de tinta de ultra alto rendimiento (6.500 páginas en negro y 5.000 páginas a color aprox.).',20,'Local',8000,'Impresoras')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Tablet Lenovo','Tablet Lenovo 10,1 Hd Android 6.0 1gb Quadcore',100,'Local',4728.75,'Tablet')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Mouse Inalambrico','Mouse inalambrico ultra fino con nano receptor.',0,'Local',136,'Perifericos')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Adaptador Corriente Universal','-Cargador universal de viaje adaptador enchufe, blanco.
-Incluye una bolsa de viaje para un fácil almacenamiento
-LED indicador de carga
-Color: blanco',50,'Local',80,'Perifericos')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Notebook Hp 15,6 Hd 4gb','Notebook Hp 15,6 HD 4gb 500GB Intel dual core windows 10 amv
',12,'Local',12370.41,'Notebook')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Auriculares Gamer','-Sonido: estéreo
-Respuesta de frecuencia: 20 Hz - 20 KHz
-Tamaño del altavoz: 40 mm
-Sensibilidad del altavoz: 105 dB ± 3 dB
-Impedancia del altavoz: 32
-Tipo de micrófono: omnidireccional
',500,'Local',550,'Multimedia')
insert  Producto (NomProd,DescProd,StockProd,UbicProd,PrecioProd,CatProd) values('Xiaomi Note 7','Xiaomi Note 7 64gb/4gb 48mp Cam + Funda + Auric Inala',10,'Local',9230.52,'Celulares')
go
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(11111111,'Usuario1','Usuuno',20000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(22222222,'Usuario2','Usudos',20000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(33333333,'Usuario3','Usutres',21111)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(44444444,'Usuario4','Usucuatro',21111)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(55555555,'Usuario5','Usucinco',18000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(66666666,'Usuario6','Ususeis',18000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(77777777,'Usuario7','Ususiete',15000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(88888888,'Usuario8','Usuocho',15000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(99999999,'Usuario9','Usunueve',16000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(10101010,'Usuario10','Usudiez',16000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(20202020,'Usuario11','Usuonce',17000)
insert  Usuario (CedulaUsu,NombreUsu,ClaveUsu,Sueldo) values(30303030,'Usuario12','Usudoce',17000)
go
insert  Cadete (cedulaCadete) values(11111111)
insert  Cadete (cedulaCadete) values(22222222)
go
insert  Stocker (cedulaStocker) values(33333333)
insert  Stocker (cedulaStocker) values(44444444)
go
insert  Administrador (cedulaAdministrador) values(55555555)
insert  Administrador (cedulaAdministrador) values(66666666)
go
insert  Vendedor (cedulaVendedor) values(77777777)
insert  Vendedor (cedulaVendedor) values(88888888)
go
insert  Cajero (cedulaCajero) values(99999999)
insert  Cajero (cedulaCajero) values(10101010)
go
insert  Tecnico (cedulaTecnico) values(20202020)
insert  Tecnico (cedulaTecnico) values(30303030)
go
insert  Mensaje(ComentarioMens,Clicom,Vendresp,RespuestaMens,Fechaenvio,Fecharespuesta) values('Comentario1',12345600,null,'Sin Respuesta','20190630',null)
go
insert  FacturaCompra(NumeroFC,ProvFC,FechaFC,ImpuestosFC,SubtotalFC,TotalFC) values('00111','12345678985','20190630',20,1000,1220)
go
insert  LineaFacturaCompra(ProductoLFC,IdFacturaCompra,CantidadLFC,ImporteLFC) values(1,1,1,1000)
go
insert  Venta(FechaV,VencimientoV,MetodoPagoV,ClienteV,TarjetaV,ImpuestosV,SubtotalV,TotalV,FormaEntregaV,EstadoV) values( CAST('2019-05-18 22:13:43.010' AS DATETIME),CAST('2019-06-18 22:13:43.010' AS DATETIME),'Efectivo',65432100,null,220,1000,1220,'Envio','Cobrada')
go
insert  LineaVenta(ProductoLV,IdV,CantidadLV,ImporteLV) values(1,1,1,1000)
go
insert  Compra(FechaC,MetodoPagoC,ClienteC,ImpuestosC,SubtotalC,TotalC,FormaEntregaC,EstadoC) values(CAST('2019-05-18 22:13:43.010' AS DATETIME),'Efectivo',12345600,220,1000,1220,'Envio','Pendiente')
go
insert  LineaCompra(ProductoLC,IdC,CantidadLC,ImporteLC) values(1,1,1,1000)
go
insert  OrdenTaller(ProductoOT,ClienteOT,DeclaracionCOT,EstadoOT,FechaOT,PrecioOT,ComentarioOT,TecnicoOT) values(2,12345600,'Hubo una falla','En Revision',GETDATE(),100,'Sin comentario',20202020)
go
insert  OrdenEnvio(VentaOE,ClienteOE,CadeteOE,UbicacionOE,LocalidadOE,EstadoOE,FechaOE) values(1,12345600,11111111,'Venezuela 154','Santa Lucia','Pendiente',GETDATE())
go
insert  ProductosOE(POE,IdOrdenE) values(1,1)
go

--drop table Administrador
--drop table Cajero
--drop table Stocker
--drop table LineaFacturaCompra
--drop table LineaCompra
--drop table LineaVenta
--drop table ProductosOE
--drop table OrdenEnvio
--drop table OrdenTaller
--drop table Cuota
--drop table Mensaje
--drop table Venta
--drop table Cadete
--drop table Compra
--drop table PagoTarjeta
--drop table FacturaCompra
--drop table Cliente
--drop table Proveedor
--drop table Tecnico
--drop table Vendedor
--drop table Producto
--drop table Usuario