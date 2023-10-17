import 'package:flutter/material.dart';
import 'list_vuelos.dart'; // Importa la nueva pantalla de lista de vuelos
import 'reserva.dart'; // Importa la pantalla de reserva

class buscarScreen extends StatefulWidget {
  @override
  SearchScreenState createState() => SearchScreenState();
}

class SearchScreenState extends State<buscarScreen> {
  final TextEditingController _origenController = TextEditingController();
  final TextEditingController _destinoController = TextEditingController();

  String _origen = '';
  String _destino = '';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Búsqueda de Vuelos'),
      ),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            TextField(
              controller: _origenController,
              decoration: InputDecoration(labelText: 'Aeropuerto de Origen'),
            ),
            SizedBox(height: 20),
            TextField(
              controller: _destinoController,
              decoration: InputDecoration(labelText: 'Aeropuerto de Destino'),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                setState(() {
                  _origen = _origenController.text;
                  _destino = _destinoController.text;
                });

                // Al hacer clic en el botón, navega a la pantalla de lista de vuelos
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) =>
                        ListaScreen(origen: _origen, destino: _destino),
                  ),
                );
              },
              child: Text('Buscar Vuelos'),
            ),
          ],
        ),
      ),
    );
  }
}
