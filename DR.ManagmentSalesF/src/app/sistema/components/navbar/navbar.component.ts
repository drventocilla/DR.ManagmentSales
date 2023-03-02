import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SubSink } from 'subsink';
import { AuthService } from '../../../core/services/auth.service';
import { UserFront } from '../../../core/models/user-front.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit   {
  
  titulo$: Observable<string> = new Observable<string>();
  sub : SubSink = new SubSink();
  usuarioActuAl: UserFront;

  constructor( private authService: AuthService ) {

    



    
  }
  ngOnInit(): void {
    
    
    this.createSub();

  }

  createSub() {

    this.authService.usuarioChanged$.subscribe( (usuario : UserFront) => {
  
        this.usuarioActuAl = usuario;
    });

  }

  

  logOut(){

   
  }



}
