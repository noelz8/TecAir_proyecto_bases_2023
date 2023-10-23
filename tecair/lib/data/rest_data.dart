import 'dart:convert';

import 'package:tecair/models/cliente.dart';
import 'package:tecair/utils/network_util.dart';

class RestData {
  final NetworkUtil _netUtil = NetworkUtil();

  static final BASE_URL = "";
  static final LOGIN_URL = BASE_URL + "/";

  Future<Cliente?> login(String correo, String contrasena) async {
    // Crea un mapa de datos con los parámetros de inicio de sesión
    final Map<String, dynamic> loginParams = {
      'correo': correo,
      'contrasena': contrasena,
    };

    // Realiza la solicitud POST a la API
    final response = await _netUtil.post(LOGIN_URL, loginParams);

    // Si la solicitud fue exitosa, deserializa la respuesta JSON en un objeto Cliente
    if (response.statusCode == 200) {
      final cliente = Cliente.fromMap(jsonDecode(response.body));
      return cliente;
    } else {
      // Si la solicitud no fue exitosa, lanza una excepción
      throw Exception('Error de inicio de sesión');
    }
  }
}
