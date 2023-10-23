import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'ClientWebApp';
  handleSearchLlegada(value: string) {
    console.log(value)
  };
  handleSearchSalida(value: string) {
    console.log(value)
  }

  constructor(
    private _http: HttpClient
  ) { }


  ngOnInit(){
    this._http.get('https://jsonplaceholder.typicode.com/users').subscribe()
      //(users: any[]) => this.listaAeropuertos = users)
  }

  listaAeropuertos = []

}
