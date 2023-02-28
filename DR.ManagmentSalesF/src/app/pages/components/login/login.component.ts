import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginModel } from 'src/app/core/models/login.model';
import { UserFront } from 'src/app/core/models/user-front.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { LocalStorageService } from 'src/app/core/services/local-storage.service';
import { APIResponse } from 'src/app/shared/models/api-reponse.model';
import { SharedModalService } from 'src/app/shared/services/shared-modal.service';
import { SpinnerService } from 'src/app/shared/services/spinner.service';
import { SubSink } from 'subsink';
import { Mensaje } from '../../../shared/models/mensaje.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  public loginForm: FormGroup;
  public ocultar = true;
  subs = new SubSink();

  _usuario: UserFront;
  _logeado: boolean;

  cargando: boolean = false;
  errorMessage: string;

  constructor(public dialog: MatDialog,
    private router: Router,
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private spinner: SpinnerService,
    private sharedModalService: SharedModalService,
    private route: ActivatedRoute ,
   ) {
    
  
  }

  ngOnInit() {

    this.loginForm = new FormGroup({
      correo: new FormControl('', [Validators.required, Validators.pattern(/[^ @]*@[^ @]*/)]),
      password: new FormControl('', [Validators.required]),
    })

    this.crearSuscripciones();

  };

  crearSuscripciones(){

    this.subs.add(this.authService.usuarioChanged$.subscribe((userFrontEmitido) => {
     
      this._usuario = userFrontEmitido;
    }));
    this.subs.add(this.authService.estaLogeadoChanged$.subscribe((logeado) => {
     
      this._logeado = logeado;
    }));

  }


  iniciarSesion(loginForm) {
    if (this.loginForm.valid) {
      
      let login: LoginModel = {
        correo: loginForm.correo,
        password: loginForm.password
      }
      this.ejecutarIniciarSesion(login);
    }
    else {

      let mensaje = new Mensaje();
      mensaje.mensajeGenerado = "Formulario inválido, verifique los campos e intente nuevamente";
      this.sharedModalService.mostrarMessageModalV2(mensaje, false);
      this.loginForm.markAllAsTouched();
    }
  }
  ejecutarIniciarSesion(login: LoginModel) {

    this.spinner.showSquareFullScreen("login");
    this.authService.iniciarSesion(login) 
      .subscribe((resultado: APIResponse) => {
        console.log('resultado',resultado);
        this.spinner.hide("login");
        let usuarioObtenido = resultado.valorObjeto;

        if (usuarioObtenido.haCambiadoContrasenha) {

          this.authService.setearUsuarioFrontGlobal(usuarioObtenido);
          this.authService.setearTokenGlobal(usuarioObtenido.token);
       
        } else {
          this.router.navigate(['/login/new-password']);
        }

      }, (error: any) => {

        this.spinner.hide("login");
        console.log('error.mensaje', error);
        try {
          this.sharedModalService.mostrarMessageModalV2(error.mensaje , false);
        } catch (e) {
          this.sharedModalService.mostrarMessageModalV2( { mensajeGenerado :"Error al realizar la operación", detalleDelMensaje : e, accionARealizar : "Comuníquese con soporte técnico." }  , false);
        }
      });;
  }


  get correo() {
    return this.loginForm.get('correo');
  };

  get password() {
    return this.loginForm.get('password');
  }
  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
