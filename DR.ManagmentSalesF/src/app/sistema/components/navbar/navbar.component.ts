import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SubSink } from 'subsink';
import { AuthService } from '../../../core/services/auth.service';
import { UserFront } from '../../../core/models/user-front.model';
import { TituloCabeceraService } from 'src/app/core/services/titulo.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit   {
  
  titulo$: Observable<string> = new Observable<string>();
  sub : SubSink = new SubSink();
  usuarioActuAl: UserFront;

  constructor( private authService: AuthService ,
               private cdRef: ChangeDetectorRef,
               private tituloCabeceraService: TituloCabeceraService ) {

    



    
  }
  
  ngAfterViewChecked(): void {
    this.titulo$ = this.tituloCabeceraService.tituloChanged$;
    this.cdRef.detectChanges();
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

   this.authService.logout();
  }



}
