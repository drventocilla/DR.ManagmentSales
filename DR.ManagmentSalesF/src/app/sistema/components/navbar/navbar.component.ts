import { Component } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  titulo$: Observable<string> = new Observable<string>();
  _perfilActual: any;

  cerrarSesion(){
    
  }
}
