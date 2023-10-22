import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginClienteComponent } from './login-cliente/login-cliente.component';

const routes: Routes = [
  { path: '', component: LoginClienteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
