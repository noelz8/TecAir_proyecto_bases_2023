import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegistroClienteComponent } from './registro-cliente/registro-cliente.component';
import { RegistroVueloComponent } from './registro-vuelo/registro-vuelo.component';
import { RegistroViajeComponent } from './registro-viaje/registro-viaje.component';
import { ManejoViajesComponent } from './manejo-viajes/manejo-viajes.component';
import { CheckInPasajeroComponent } from './check-in-pasajero/check-in-pasajero.component';
import { AsignacionMaletaComponent } from './asignacion-maleta/asignacion-maleta.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegistroClienteComponent,
    RegistroVueloComponent,
    RegistroViajeComponent,
    ManejoViajesComponent,
    CheckInPasajeroComponent,
    AsignacionMaletaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
