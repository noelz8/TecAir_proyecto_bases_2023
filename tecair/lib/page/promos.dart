import 'package:flutter/material.dart';

class Promotion {
  final String title;
  final String description;
  final String imageUrl;

  Promotion({
    required this.title,
    required this.description,
    required this.imageUrl,
  });
}

class PromoScreen extends StatelessWidget {
  final List<Promotion> _promotions = [
    // Lista de promociones
    Promotion(
      title: '¡Oferta Especial!',
      description: 'Descuento del 20% en vuelos internacionales.',
      imageUrl: '',
    ),
    Promotion(
      title: 'Viaja con Estilo',
      description: 'Clase ejecutiva a precio de clase económica.',
      imageUrl: '',
    ),
    // Agrega más promociones según tus necesidades
    Promotion(
      title: 'Vacaciones en Colombia',
      description: 'Descuento de un 25% en vuelos hacia Medellin, Colonbia',
      imageUrl: '',
    ),

    Promotion(
      title: 'Viaja a Mexico',
      description: 'Visita Cancùn ahora con un 30% de descuento',
      imageUrl: '',
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Promociones'),
      ),
      body: ListView.builder(
        itemCount: _promotions.length,
        itemBuilder: (context, index) {
          Promotion promotion = _promotions[index];
          return ListTile(
            contentPadding: EdgeInsets.all(16.0),
            title: Text(promotion.title,
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
            subtitle: Text(promotion.description),
            leading: Image.network(
              promotion.imageUrl,
              width: 100,
              height: 100,
              fit: BoxFit.cover,
            ),
            onTap: () {
              // Implementa la lógica para mostrar detalles de la promoción si el usuario hace clic en ella
              // Puedes abrir una nueva pantalla con más detalles o mostrar un cuadro de diálogo, por ejemplo
            },
          );
        },
      ),
    );
  }
}
