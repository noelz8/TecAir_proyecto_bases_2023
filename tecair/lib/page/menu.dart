import 'package:flutter/material.dart';
import 'package:tecair/page/promos.dart'; // Importa el archivo de promociones
import 'buscar_vuelo.dart'; // Importa el archivo de búsqueda de vuelos

class MenuScreen extends StatelessWidget {
  void _navigateToPromoScreen(BuildContext context) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => PromoScreen()),
    );
  }

  void _navigateToBuscarScreen(BuildContext context) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => buscarScreen()),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Menú'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                _navigateToPromoScreen(context);
              },
              child: Text('Promociones'),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                _navigateToBuscarScreen(context);
              },
              child: Text('Búsqueda de Vuelos'),
            ),
          ],
        ),
      ),
    );
  }
}
