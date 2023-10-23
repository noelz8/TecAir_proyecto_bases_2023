-- Tabla Cliente
CREATE TABLE Cliente (
    ClienteID INTEGER PRIMARY KEY,
    Nombre TEXT NOT NULL,
    Apellido1 TEXT NOT NULL,
    Apellido2 TEXT,
    Telefono TEXT,
    Correo TEXT NOT NULL,
    Contraseña TEXT NOT NULL
);

-- Tabla Estudiante
CREATE TABLE Estudiante (
    Carnet TEXT PRIMARY KEY,
    ClienteID INTEGER NOT NULL,
    CantidaddeViajes INTEGER NOT NULL,
    Millas INTEGER,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

-- Tabla Universidad
CREATE TABLE Universidad (
    Nombre TEXT PRIMARY KEY,
    CarnetEstudiante TEXT NOT NULL,
    FOREIGN KEY (CarnetEstudiante) REFERENCES Estudiante(Carnet)
);

-- Tabla Reservacion
CREATE TABLE Reservacion (
    ReservacionID INTEGER PRIMARY KEY,
    ClienteID INTEGER NOT NULL,
    CantidadMaletas INTEGER NOT NULL,
    Año INTEGER NOT NULL,
    Mes INTEGER NOT NULL,
    Dia INTEGER NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID)
);

-- Tabla Maleta
CREATE TABLE Maleta (
    Numero INTEGER PRIMARY KEY,
    ReservacionID INTEGER NOT NULL,
    ClienteID INTEGER NOT NULL,
    Color TEXT,
    Peso REAL NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID),
    FOREIGN KEY (ReservacionID) REFERENCES Reservacion(ReservacionID)
);

-- Tabla Viaje
CREATE TABLE Viaje (
    ViajeID INTEGER PRIMARY KEY,
    Horario TEXT NOT NULL,
    Precio REAL NOT NULL,
    Estado TEXT NOT NULL,
    Fecha TEXT NOT NULL
);

-- Tabla ReservacionesPorViaje
CREATE TABLE ReservacionesPorViaje (
    ViajeID INTEGER NOT NULL,
    ReservacionID INTEGER NOT NULL,
    NumerodeAsiento INTEGER,
    PRIMARY KEY (ViajeID, ReservacionID),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (ReservacionID) REFERENCES Reservacion(ReservacionID)
);

-- Tabla Promocion
CREATE TABLE Promocion (
    PromocionID INTEGER PRIMARY KEY,
    Origen TEXT NOT NULL,
    Destino TEXT NOT NULL
);

-- Tabla PromocionesPorViaje
CREATE TABLE PromocionesPorViaje (
    ViajeID INTEGER NOT NULL,
    PromocionID INTEGER NOT NULL,
    Periodo TEXT NOT NULL,
    PRIMARY KEY (ViajeID, PromocionID),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (PromocionID) REFERENCES Promocion(PromocionID)
);

-- Tabla Avion
CREATE TABLE Avion (
    AvionID INTEGER PRIMARY KEY,
    Imagen TEXT,
    Capacidad INTEGER,
    Aerolinea TEXT,
    Modelo TEXT
);

-- Tabla Asiento del Avion
CREATE TABLE Asiento (
    AsientoID INTEGER PRIMARY KEY,
    AvionID INTEGER NOT NULL,
    PosicionAsiento TEXT,
    Estado TEXT,
    FOREIGN KEY (AvionID) REFERENCES Avion(AvionID)
);

-- Tabla Aeropuerto
CREATE TABLE Aeropuerto (
    CodigoAeropuerto TEXT PRIMARY KEY,
    Ciudad TEXT NOT NULL,
    Pais TEXT NOT NULL
);

-- Tabla Origen
CREATE TABLE Origen (
    CodigoAeropuerto TEXT PRIMARY KEY,
    Ciudad TEXT NOT NULL,
    PuertaIngreso TEXT,
    Pais TEXT NOT NULL,
    FOREIGN KEY (CodigoAeropuerto) REFERENCES Aeropuerto(CodigoAeropuerto)
);

-- Tabla Destino
CREATE TABLE Destino (
    CodigoAeropuerto TEXT PRIMARY KEY,
    Ciudad TEXT NOT NULL,
    PuertaIngreso TEXT,
    Pais TEXT NOT NULL,
    FOREIGN KEY (CodigoAeropuerto) REFERENCES Aeropuerto(CodigoAeropuerto)
);

-- Tabla Vuelo
CREATE TABLE Vuelo (
    VueloID INTEGER PRIMARY KEY,
    CodigoAeropuertoOrigen TEXT NOT NULL,
    CodigoAeropuertoDestino TEXT NOT NULL,
    Origen TEXT NOT NULL,
    Destino TEXT NOT NULL,
    ViajeID INTEGER NOT NULL,
    AvionID INTEGER NOT NULL,
    FOREIGN KEY (CodigoAeropuertoOrigen) REFERENCES Origen(CodigoAeropuerto),
    FOREIGN KEY (CodigoAeropuertoDestino) REFERENCES Destino(CodigoAeropuerto),
    FOREIGN KEY (ViajeID) REFERENCES Viaje(ViajeID),
    FOREIGN KEY (AvionID) REFERENCES Avion(AvionID)
);

-- Tabla Escala
CREATE TABLE Escala (
    CodigoAeropuertoEscala TEXT PRIMARY KEY,
    VueloID INTEGER NOT NULL,
    VueloOrigen TEXT NOT NULL,
    Ciudad TEXT NOT NULL,
    Pais TEXT NOT NULL,
    FOREIGN KEY (VueloID) REFERENCES Vuelo(VueloID)
);
