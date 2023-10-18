import 'package:flutter/material.dart';
import 'package:tecair/page/reserva.dart'; // Asegúrate de importar la pantalla de reserva

class Promotion {
  final String title;
  final String description;
  final String origen;
  final String destino;
  final String numeroVuelo;
  final String horario;
  final String imageUrl;

  Promotion({
    required this.title,
    required this.description,
    required this.origen,
    required this.destino,
    required this.numeroVuelo,
    required this.horario,
    required this.imageUrl,
  });
}

class PromoScreen extends StatelessWidget {
  final List<Promotion> _promotions = [
    // Lista de promociones

    // Agrega más promociones según tus necesidades
    Promotion(
      title: 'Vacaciones en Colombia',
      description: 'Descuento de un 25% en vuelos hacia Medellin, Colombia',
      origen: 'Origen3',
      destino: 'Destino3',
      numeroVuelo: 'Vuelo789',
      horario: '6:00 AM',
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
            title: Text(promotion.title),
            subtitle: Text(promotion.description),
            onTap: () {
              showDialog(
                context: context,
                builder: (BuildContext context) {
                  return AlertDialog(
                    title: Text('Confirmar Reserva'),
                    content: Text('¿Quieres reservar esta promoción?'),
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
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => ReservaScreen(
                                origen: promotion.origen,
                                destino: promotion.destino,
                                numeroVuelo: promotion.numeroVuelo,
                                horario: promotion.horario,
                              ),
                            ),
                          );
                        },
                      ),
                    ],
                  );
                },
              );
            },
          );
        },
      ),
    );
  }
}
