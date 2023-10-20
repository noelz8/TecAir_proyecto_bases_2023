import 'package:flutter/material.dart';

class ConfirmacionScreen extends StatelessWidget {
  final String origen;
  final String destino;

  ConfirmacionScreen({
    required this.origen,
    required this.destino,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Confirmación de Reserva'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            // Mostrar la información de la reserva (número de vuelo, origen, destino, fecha y precio)
            Text(
                'Número de Vuelo: N/A'), // Puedes generar un número de vuelo dinámicamente
            Text(
                'Origen: $origen'), // Mostrar el valor del aeropuerto de origen
            Text(
                'Destino: $destino'), // Mostrar el valor del aeropuerto de destino
            Text('Fecha: N/A'), // Puedes generar la fecha dinámicamente
            Text('Precio: N/A'), // Puedes calcular el precio dinámicamente

            // Botón para ver la mini factura en un AlertDialog
            ElevatedButton(
              onPressed: () {
                _mostrarMiniFactura(context);
              },
              child: Text('Ver Mini Factura'),
            ),

            // Botón para aceptar la reserva
            ElevatedButton(
              onPressed: () {
                Navigator.of(context).popUntil((route) => route.isFirst);
              },
              child: Text('Aceptar'),
            ),
          ],
        ),
      ),
    );
  }

  void _mostrarMiniFactura(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Mini Factura'),
          content: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text(
                  'Número de Vuelo: N/A'), // Puedes generar un número de vuelo dinámicamente
              Text(
                  'Origen: $origen'), // Mostrar el valor del aeropuerto de origen
              Text(
                  'Destino: $destino'), // Mostrar el valor del aeropuerto de destino
              Text('Fecha: N/A'), // Puedes generar la fecha dinámicamente
              Text('Precio: N/A'), // Puedes calcular el precio dinámicamente
            ],
          ),
          actions: <Widget>[
            TextButton(
              child: Text('Aceptar'),
              onPressed: () {
                Navigator.of(context).pop(); // Cerrar el AlertDialog
              },
            ),
          ],
        );
      },
    );
  }
}
