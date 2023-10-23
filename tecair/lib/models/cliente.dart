class Cliente {
  int? clienteId = 0;
  String? nombre = "";
  String? apellido1 = "";
  String? apellido2 = "";
  String? telefono = "";
  String correo;
  String contrasena;

  Cliente({
    this.clienteId,
    this.nombre,
    this.apellido1,
    this.apellido2,
    this.telefono,
    required this.correo,
    required this.contrasena,
  });

  factory Cliente.fromMap(Map<String, dynamic> map) {
    return Cliente(
      clienteId: map['clienteId'] as int,
      nombre: map['nombre'] as String,
      apellido1: map['apellido1'] as String,
      apellido2: map['apellido2'] as String,
      telefono: map['telefono'] as String,
      correo: map['correo'] as String,
      contrasena: map['contraseña'] as String,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'clienteId': clienteId,
      'nombre': nombre,
      'apellido1': apellido1,
      'apellido2': apellido2,
      'telefono': telefono,
      'correo': correo,
      'contraseña': contrasena,
    };
  }
}
