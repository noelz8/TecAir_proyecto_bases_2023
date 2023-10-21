import 'package:flutter/material.dart';
import 'package:tecair/page/reserva.dart';

class ListaScreen extends StatelessWidget {
  final String origen;
  final String destino;

  ListaScreen({
    required this.origen,
    required this.destino,
  });
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Horarios de Vuelos'),
      ),
      body: ListView(
        children: <Widget>[
          _buildListTile(context, 'Vuelo 1 - Horario 1'),
          _buildListTile(context, 'Vuelo 2 - Horario 2'),
          // Agrega más ListTile según tus necesidades
        ],
      ),
    );
  }

  Widget _buildListTile(BuildContext context, String title) {
    return ListTile(
      title: Text(title),
      onTap: () {
        // Mostrar un AlertDialog cuando se toque un ListTile
        showDialog(
          context: context,
          builder: (BuildContext context) {
            return AlertDialog(
              title: Text('Confirmar Reserva'),
              content: Text('¿Quieres reservar este vuelo?'),
              actions: <Widget>[
                TextButton(
                  child: Text('Cancelar'),
                  onPressed: () {
                    Navigator.of(context).pop(); // Cerrar el AlertDialog
                  },
                ),
                TextButton(
                  child: Text('Reservar'),
                  onPressed: () {
                    Navigator.of(context).pop(); // Cerrar el AlertDialog
                    // Navegar a la pantalla de reserva
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => ReservaScreen(
                                origen: origen,
                                destino: destino,
                                numeroVuelo: '',
                                horario: '',
                              )),
                    );
                  },
                ),
              ],
            );
          },
        );
      },
    );
  }
}
