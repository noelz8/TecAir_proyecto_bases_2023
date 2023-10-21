import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegistroClienteComponent } from './registro-cliente/registro-cliente.component';
import { RegistroVueloComponent } from './registro-vuelo/registro-vuelo.component';
import { RegistroViajeComponent } from './registro-viaje/registro-viaje.component';
import { CheckInPasajeroComponent } from './check-in-pasajero/check-in-pasajero.component';

const routes: Routes = [
  { path: '', component: LoginComponent},
  {path: 'home', component: HomeComponent},
  {path: 'registro-cliente', component: RegistroClienteComponent},
  {path: 'registro-vuelo', component: RegistroVueloComponent},
  {path: 'registro-viaje', component: RegistroViajeComponent},
  {path: 'check-in', component: CheckInPasajeroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
