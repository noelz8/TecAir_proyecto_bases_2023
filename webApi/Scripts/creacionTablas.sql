CREATE TABLE Cliente (
    ClienteID INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido1 VARCHAR(50) NOT NULL,
    Apellido2 VARCHAR(50)NOT NULL,
    Telefono VARCHAR(15)NOT NULL,
    Correo VARCHAR(255) NOT NULL,
	PRIMARY KEY(ClienteID),
	UNIQUE(Correo)
);

CREATE TABLE Estudiante(
	Carnet INT,
    ClienteID INT,
	PRIMARY KEY(Carnet),
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

CREATE TABLE Universidad (
    Nombre VARCHAR(255) NOT NULL,
    Carnet INT,
	PRIMARY KEY(Nombre),
	FOREIGN KEY (Carnet) REFERENCES Estudiante(Carnet)
);


CREATE TABLE Reservacion (
    ReservacionID INT NOT NULL,
    CantidadMaletas INT,
    Año INT,
    Mes INT,
    Dia INT,
    ClienteID INT,
    PRIMARY KEY(ReservacionID),
	FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);


CREATE TABLE Promocion (
    PromocionID INT NOT NULL,
    Origen VARCHAR(255) NOT NULL,
    Destino VARCHAR(255) NOT NULL,
	PRIMARY KEY(PromocionID)
);

CREATE TABLE Avion (
    AvionID INT NOT NULL,
    CodigoAeropuertoDestino CHAR(3),
    CodigoAeropuertoOrigen CHAR(3),
    Imagen VARCHAR(255),
    Capacidad INT,
    Aerolinea VARCHAR(255),
    Modelo VARCHAR(255),
	PRIMARY KEY(AvionID),
    FOREIGN KEY (CodigoAeropuertoDestino) REFERENCES Destino(CodigoAeropuertoDestino),
    FOREIGN KEY (CodigoAeropuertoOrigen) REFERENCES Origen(CodigoAeropuertoOrigen)
);


CREATE TABLE Viaje (
    ViajeID INT NOT NULL,
    Fecha DATE,
    Horario TIME,
    Precio DECIMAL(10, 2),
	NumeroAsiento INT,
    ReservacionID INT,
    AvionID INT,
	PRIMARY KEY(ViajeID),
    FOREIGN KEY (ReservacionID) REFERENCES Reservacion(ReservacionID),
    FOREIGN KEY (AvionID) REFERENCES Avion(AvionID)
);

CREATE TABLE PromocionesPorViaje (
    ViajeID INT,
    PromocionID INT,
    PRIMARY KEY (ViajeID, PromocionID),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (PromocionID) REFERENCES Promocion(PromocionID)
);

CREATE TABLE Destino (
    CodigoAeropuertoDestino CHAR(3) NOT NULL,
    Ciudad VARCHAR(255) NOT NULL,
    Pais VARCHAR(255) NOT NULL,
    PuertaIngreso VARCHAR(10),
    HoraLlegada TIME,
	PRIMARY KEY(CodigoAeropuertoDestino)
);


CREATE TABLE Origen (
    CodigoAeropuertoOrigen CHAR(3),
    Ciudad VARCHAR(255) NOT NULL,
    Pais VARCHAR(255) NOT NULL,
    PuertaIngreso VARCHAR(10),
    HoraSalida TIME,
	PRIMARY KEY(CodigoAeropuertoOrigen)
);








































