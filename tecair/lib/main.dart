import 'package:flutter/material.dart';
import 'package:tecair/page/confirmar_pago.dart';
import 'package:tecair/page/list_vuelos.dart';
import 'package:tecair/page/menu.dart';
import 'package:tecair/page/reserva.dart';
import 'page/login.dart';
import 'page/buscar_vuelo.dart';
import 'page/promos.dart';

void main() => runApp(MaterialApp(
      title: 'TECAir',
      initialRoute: '/',
      routes: {
        '/': (context) => LoginScreen(), // Ruta de inicio
        //'/': (context) => PromoScreen(), // Ruta de inicio
        '/menu': (context) => MenuScreen(),
        '/promos': (context) => PromoScreen(),
        '/buscar': (context) => buscarScreen(),
        '/list': (context) => ListaScreen(
              origen: '',
              destino: '',
            ),
        '/reserva': (context) => ReservaScreen(
              origen: '',
              destino: '',
              numeroVuelo: '',
              horario: '',
            ),
        '/confirmacion': (context) => ConfirmacionScreen(
              origen: '',
              destino: '',
            )
      },
    ));
