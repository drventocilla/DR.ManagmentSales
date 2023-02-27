import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { CryptoService } from './crypto.service';
import { LocalStorageService } from './local-storage.service';

import { SubSink } from 'subsink';
import { LoginModel } from '../models/login.model';
import { RepositoryService } from './repository.service';
import { UserFront } from '../models/user-front.model';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  subs: SubSink = new SubSink;

  private readonly KEYUSUARIO: string = "USER";
  private readonly KEYTOKEN: string = 'TOKEN';

  private _usuarioActual: UserFront = new UserFront();
  private usuarioSubject$ = new BehaviorSubject<UserFront>(this._usuarioActual);
  public usuarioChanged$ = this.usuarioSubject$.asObservable();

  private estaLogeado$ = new BehaviorSubject<boolean>(false);
  public estaLogeadoChanged$ = this.estaLogeado$.asObservable();
  
  

  constructor(
    private repository: RepositoryService,
    private localStorageService: LocalStorageService,
    private router: Router,
    private cryptoService: CryptoService
  ) {
    console.log('aqui');
    this.obtenerUsuarioDeLS();
  }


  //#region parsear usuario desde localstorage en la primera carga del login
  public obtenerUsuarioDeLS() {
    // console.log("ENTRO A obtenerUsuarioDeLS()");
    if (this.localStorageService.validarExistencia(this.KEYUSUARIO)) {
      if (this.localStorageService.get(this.KEYUSUARIO) != null) {
        // console.log("existe la key");
        this.parsearUsuarioDeLS();
      }
      else {
        // console.log("existe pero no parsea");
        this.asignarUsuarioPorDefecto();
        this.parsearUsuarioDeLS();
      }
    }
    else {
      // console.log("no existe la key");
      this.asignarUsuarioPorDefecto();
      this.parsearUsuarioDeLS();
    }
  }
  private asignarUsuarioPorDefecto() {
    this.localStorageService.set(this.KEYUSUARIO, new UserFront());
  }
  private parsearUsuarioDeLS() {
    console.log("entro parsearUsuarioDeLS()");
    this._usuarioActual = this.localStorageService.get(this.KEYUSUARIO);
    console.log("parsearUsuarioDeLS:  _usuarioActual ", this._usuarioActual);

    let tokenAux = this._usuarioActual.token;
    console.log("parsearUsuarioDeLS:  tokenAux ", tokenAux);
    this.localStorageService.set(this.KEYTOKEN, tokenAux);
     console.log("token en parsearusuaroidels: ", this.localStorageService.get(this.KEYTOKEN));

    this.usuarioSubject$.next(this._usuarioActual);

    //TODO: MUY IMPORTANTE: Evaluar como se usara la expiracion del token y a donde llevara este (no deberia de llevar al login para evitar problemas de bucle infirnito con el cliente guard)
    //?...continuacion: se deberia crear una pagina adicional???
    if (tokenAux == null || tokenAux == "") {
      this.estaLogeado$.next(false);
    
    }
    else {

        this.estaLogeado$.next(true);
    }
  }
  //#endregion

  //#region 

  public logout() {
    this.localStorageService.clear();
    this.obtenerUsuarioDeLS();
    location.reload();
  }

 
  public setearUsuarioActualALS(){
    let usuarioASetear: UserFront = this.usuarioSubject$.getValue();
    this.localStorageService.set(this.KEYUSUARIO, usuarioASetear);
  }
  //#region 


  get usuarioFrontActual() {
    return { ...this.usuarioSubject$.getValue() };
  }
  /**Usuario actual logeado, este usuario no tiene asignadas las contraseñas por seguridad */
  get usuarioActual() {
    return { ...this.usuarioSubject$.getValue() };
  }
  get clienteActual() {
    return { ...this.usuarioSubject$.getValue() };
  }

  public setearUsuarioFrontGlobal(usuarioFront: UserFront) {
    this.usuarioSubject$.next(usuarioFront);
    this.estaLogeado$.next(true);
    this.setearUsuarioActualALS();
  }

  public setearUsuarioGlobal(usuario: UserFront) {
    // this.usuarioSubject$.getValue().usuario = { ...usuario };
    this.usuarioSubject$.next({ ...usuario });
    this.setearUsuarioActualALS();
  }
 
 
  public setearTokenGlobal(token: string) {
    // this.usuarioSubject$.getValue().token = token;
    this.usuarioSubject$.next({ ...this.usuarioSubject$.getValue(), token: token });
    this.setearUsuarioActualALS();
    this.localStorageService.set(this.KEYTOKEN, token);
  }
   
  
  
  //#endregion 


  
  public obtenerKeyToken() {
    return this.KEYTOKEN;
  }


  public obtenerKeyUsuario() {
    return this.KEYUSUARIO;
  }


  private construirRuta(ruta: string): string {
    return `api/session/${ruta}`;
  }

  public iniciarSesion(loginModel: LoginModel) {
    loginModel = { ...loginModel, password: this.cryptoService.encriptarParaBack(loginModel.password) };
  
    return this.repository.create(this.construirRuta('iniciarsesion'), loginModel);
  }
}
