import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginClienteComponent } from './login-cliente/login-cliente.component';
import { ReservaVuelosComponent } from './reserva-vuelos/reserva-vuelos.component';
import { BusquedaVuelosComponent } from './busqueda-vuelos/busqueda-vuelos.component';
import { PromocionesComponent } from './promociones/promociones.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CrearUsuarioComponent } from './crear-usuario/crear-usuario.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginClienteComponent,
    ReservaVuelosComponent,
    BusquedaVuelosComponent,
    PromocionesComponent,
    CrearUsuarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
