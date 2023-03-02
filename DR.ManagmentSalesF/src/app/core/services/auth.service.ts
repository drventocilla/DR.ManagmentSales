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
    private cryptoService: CryptoService
  ) {
        this.getUserLS();
  }


  
  public getUserLS() {
    // console.log("ENTRO A obtenerUsuarioDeLS()");
    if (this.localStorageService.validarExistencia(this.KEYUSUARIO)) {
      if (this.localStorageService.get(this.KEYUSUARIO) != null) {
        // console.log("existe la key");
        this.parseUser();
      }
      else {
        // console.log("existe pero no parsea");
        this.setDefaultUser();
        this.parseUser();
      }
    }
    else {
      // console.log("no existe la key");
      this.setDefaultUser();
      this.parseUser();
    }
  }
  private setDefaultUser() {
    this.localStorageService.set(this.KEYUSUARIO, new UserFront());
  }
  private parseUser() {
    
    this._usuarioActual = this.localStorageService.get(this.KEYUSUARIO);
    
    let tokenAux = this._usuarioActual.token;
    
    this.localStorageService.set(this.KEYTOKEN, tokenAux);
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

  public setUserInLS(){
    let usuarioASetear: UserFront = this.usuarioSubject$.getValue();
    this.localStorageService.set(this.KEYUSUARIO, usuarioASetear);
  }
 
  public setUserSubject(usuarioFront: UserFront) {
    this.usuarioSubject$.next(usuarioFront);
    this.estaLogeado$.next(true);
    this.setUserInLS();
  }

  public setUser(usuario: UserFront) {
    // this.usuarioSubject$.getValue().usuario = { ...usuario };
    this.usuarioSubject$.next({ ...usuario });
    this.setUserInLS();
  }
 
 
  public setToken(token: string) {
    // this.usuarioSubject$.getValue().token = token;
    this.usuarioSubject$.next({ ...this.usuarioSubject$.getValue(), token: token });
    this.setUserInLS();
    this.localStorageService.set(this.KEYTOKEN, token);
  }
   
  //#region 

  
  public obtenerKeyToken() {
    return this.KEYTOKEN;
  }


  public obtenerKeyUsuario() {
    return this.KEYUSUARIO;
  }


  private construirRuta(ruta: string): string {
    return `api/session/${ruta}`;
  }

  public signIn(loginModel: LoginModel) {
    loginModel = { ...loginModel, password: this.cryptoService.encriptarParaBack(loginModel.password) };
  
    return this.repository.create(this.construirRuta('signIn'), loginModel);
  }

  public logout() {
    this.localStorageService.clear();
    this.getUserLS();
    location.reload();
  }

}
