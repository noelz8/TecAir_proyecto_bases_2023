import 'package:flutter/material.dart';
import 'package:tecair/page/confirmar_pago.dart';
import 'package:tecair/page/list_vuelos.dart';

class ReservaScreen extends StatelessWidget {
  final String origen;
  final String destino;
  final String numeroVuelo;
  final String horario;

  ReservaScreen({
    required this.origen,
    required this.destino,
    required this.numeroVuelo,
    required this.horario,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Reserva de Vuelo'),
      ),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Column(
          children: <Widget>[
            // Formulario para los detalles de la tarjeta de crédito (puedes personalizar según tus necesidades)
            TextFormField(
              decoration: InputDecoration(labelText: 'Número de Tarjeta'),
            ),
            TextFormField(
              decoration: InputDecoration(labelText: 'Fecha de Vencimiento'),
            ),
            // Agrega más campos del formulario según tus necesidades

            // Botones para confirmar o cancelar la reserva
            ElevatedButton(
              onPressed: () {
                // Lógica para confirmar la reserva
                // Puedes implementar la lógica de pago aquí

                // Después de completar la reserva, puedes navegar a la pantalla de confirmación
                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(
                      builder: (context) => ConfirmacionScreen(
                            origen: origen,
                            destino: destino,
                          )),
                );
              },
              child: Text('Confirmar Reserva'),
            ),
            ElevatedButton(
              onPressed: () {
                Navigator.of(context).pop(); // Cerrar la pantalla de reserva
              },
              child: Text('Cancelar'),
            ),
          ],
        ),
      ),
    );
  }
}
