-- Tabla del Cliente
CREATE TABLE Cliente (
    ClienteID int,
    Nombre VARCHAR(50) NOT NULL,
    Apellido1 VARCHAR(50) NOT NULL,
    Apellido2 VARCHAR(50),
    Telefono VARCHAR(15),
    Correo VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
	PRIMARY KEY(ClienteID),
	UNIQUE(Correo)
);

-- Tabla de Estudiante 
CREATE TABLE Estudiante (
    Carnet VARCHAR(20),
    ClienteID INT,
    CantidaddeViajes INT NOT NULL,
    Millas INT GENERATED ALWAYS AS (CantidaddeViajes * 100) STORED,
	PRIMARY KEY(Carnet),
	FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

-- Tabla Universidad
CREATE TABLE Universidad (
    Nombre VARCHAR(100),
    CarnetEstudiante VARCHAR(20),
	PRIMARY KEY(Nombre),
	FOREIGN KEY (CarnetEstudiante) REFERENCES Estudiante(Carnet)
);

-- Tabla Reservacion
CREATE TABLE Reservacion (
    ReservacionID INT,
    ClienteID INT,
    CantidadMaletas INT NOT NULL,
    Año INT NOT NULL,
    Mes INT NOT NULL,
    Dia INT NOT NULL,
	PRIMARY KEY(ReservacionID),
	FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);


-- Tabla Maleta
CREATE TABLE Maleta (
    Numero INT,
    ReservacionID INT,
    ClienteID INT,
    Color VARCHAR(50),
    Peso DECIMAL(5, 2) NOT NULL,
	PRIMARY KEY(Numero),
	FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID),
	FOREIGN KEY (ReservacionID) REFERENCES Reservacion(ReservacionID)
);


-- Tabla Viaje
CREATE TABLE Viaje (
    ViajeID INT,
    Horario TIMESTAMP NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    Fecha DATE NOT NULL,
	PRIMARY KEY(ViajeID)
);

-- Tabla ReservacionesPorViaje
CREATE TABLE ReservacionesPorViaje (
    ViajeID INT,
    ReservacionID INT,
    NumerodeAsiento INT,
    PRIMARY KEY (ViajeID, ReservacionID),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (ReservacionID) REFERENCES Reservacion(ReservacionID)
);

-- Tabla Promociones
CREATE TABLE Promocion (
    PromocionID INT,
    Origen VARCHAR(100) NOT NULL,
    Destino VARCHAR(100) NOT NULL,
	PRIMARY KEY(PromocionID)
);

-- Tabla PromocionesPorViaje
CREATE TABLE PromocionesPorViaje (
    ViajeID INT,
    PromocionID INT,
    Periodo DATE NOT NULL,
    PRIMARY KEY (ViajeID, PromocionID),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (PromocionID) REFERENCES Promocion(PromocionID)
);

-- Tabla Avion
CREATE TABLE Avion (
    AvionID INT,
    Imagen TEXT,
    Capacidad INT,
    Aerolinea VARCHAR(100),
    Modelo VARCHAR(100),
	PRIMARY KEY(AvionID)
);
-- Tabla Asiento del Avion
CREATE TABLE Asiento (
    AsientoID INT,
    AvionID INT,
    PosicionAsiento VARCHAR(10),
    Estado VARCHAR(20),
	PRIMARY KEY(AsientoID),
	FOREIGN KEY (AvionID) REFERENCES Avion(AvionID)
);

-- Tabla Aeropuerto
CREATE TABLE Aeropuerto (
    CodigoAeropuerto VARCHAR(10),
    Ciudad VARCHAR(100),
    Pais VARCHAR(100),
	PRIMARY KEY(CodigoAeropuerto)
);
-- Tabla Origen
CREATE TABLE Origen (
    CodigoAeropuerto VARCHAR(10),
    Ciudad VARCHAR(100),
    PuertaIngreso VARCHAR(10),
    Pais VARCHAR(100),
    PRIMARY KEY (CodigoAeropuerto),
    FOREIGN KEY (CodigoAeropuerto) REFERENCES Aeropuerto(CodigoAeropuerto)
);

-- Tabla Destino
CREATE TABLE Destino (
    CodigoAeropuerto VARCHAR(10),
    Ciudad VARCHAR(100),
    PuertaIngreso VARCHAR(10),
    Pais VARCHAR(100),
    PRIMARY KEY (CodigoAeropuerto),
    FOREIGN KEY (CodigoAeropuerto) REFERENCES Aeropuerto(CodigoAeropuerto)
);

-- Tabla Vuelo
CREATE TABLE Vuelo (
    VueloID INT,
    CodigoAeropuertoOrigen VARCHAR(10),
    CodigoAeropuertoDestino VARCHAR(10),
    Origen VARCHAR(100),
    Destino VARCHAR(100),
    ViajeID INT,
    AvionID INT,
	PRIMARY KEY(VueloID),
    FOREIGN KEY (CodigoAeropuertoOrigen) REFERENCES Origen(CodigoAeropuerto),
    FOREIGN KEY (CodigoAeropuertoDestino) REFERENCES Destino(CodigoAeropuerto),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (AvionID) REFERENCES Avion(AvionID)
);

-- Tabla Escala

CREATE TABLE Escala (
    CodigoAeropuertoEscala VARCHAR(10),
    VueloID INT,
    VueloOrigen VARCHAR(100),
    Ciudad VARCHAR(100),
    Pais VARCHAR(100),
	PRIMARY KEY(CodigoAeropuertoEscala),
	FOREIGN KEY (VueloID) REFERENCES Vuelo(VueloID)
);














