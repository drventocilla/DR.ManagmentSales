import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/core/models/login.model';
import { UserFront } from 'src/app/core/models/user-front.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { APIResponse } from 'src/app/shared/models/api-reponse.model';
import { SharedModalService } from 'src/app/shared/services/shared-modal.service';
import { SpinnerService } from 'src/app/shared/services/spinner.service';
import { SubSink } from 'subsink';
import { Message } from '../../../shared/models/message.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  public loginForm: FormGroup;
  public ocultar = true;
  subs = new SubSink();
  cargando: boolean = false;
  errorMessage: string;

  constructor(
    public dialog: MatDialog,
    private authService: AuthService,
    private spinner: SpinnerService,
    private sharedModalService: SharedModalService,
    private router: Router,
    
   ) {
    
  
  }

  ngOnInit() {

    this.loginForm = new FormGroup({
      login: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      password: new FormControl('', [Validators.required]),
    })

    this.crearSuscripciones();

  };

  crearSuscripciones(){



  }


  signIn(loginForm) {

    if (this.loginForm.valid) {
      
      let login: LoginModel = {
        login: loginForm.login,
        password: loginForm.password
      }
      this.execute_signIn(login);
    }
    else {

      let mensaje = new Message();
      mensaje.description = "Formulario inválido, verifique los campos e intente nuevamente";
      this.sharedModalService.mostrarMessageModal(mensaje, false);
      this.loginForm.markAllAsTouched();
    }
  }
  execute_signIn(login: LoginModel) {

    this.spinner.showTimer("login");
    this.authService.signIn(login) 
      .subscribe((resultado: APIResponse) => {

        this.spinner.hide("login");
        let usuarioObtenido : UserFront = resultado.data;

        this.authService.setUserSubject(usuarioObtenido);
        this.authService.setToken(usuarioObtenido.token);
        this.router.navigate(['/sistema']);
      
      }, (error: any) => {

        this.spinner.hide("login");
        console.log('error.mensaje', error);
        try {
          this.sharedModalService.mostrarMessageModal(error.message , false);
        } catch (e) {
          this.sharedModalService.mostrarMessageModal( { description:"Error al realizar la operación",  action : "Comuníquese con soporte técnico." }  , false);
        }
      });;
  }


  get login() {
    return this.loginForm.get('login');
  };

  get password() {
    return this.loginForm.get('password');
  }


  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
