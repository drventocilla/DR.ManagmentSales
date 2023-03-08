import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { ResponseType } from 'src/app/shared/models/response-type.mode';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Environment } from 'src/environments/enviroment-model';
import { ProblemDetails } from '../../shared/models/problem-details.model';


@Injectable({
  providedIn: 'root'
})
export class BaseRepositoryService {

  constructor(
    private http: HttpClient,
    private environment: Environment,
  ) {
  }

  public getData(route: string, parametros?: HttpParams, response: ResponseType = ResponseType.Json) {

    let HTTPOptions: Object = {

      params: parametros,
      responseType: response
    }

    return this.http.get(
      this.createCompleteRoute(route, this.environment.urlAddress),
      HTTPOptions

    ).pipe( catchError(this.handleError));
  }


  public getDataByPost(route: string, body?: any, parametros?: HttpParams, response: ResponseType = ResponseType.Json) {

    let HTTPOptions: Object = {

      params: parametros,
      responseType: response
    }

    return this.http.post(
      this.createCompleteRoute(route, this.environment.urlAddress),
      body,
      HTTPOptions

    ).pipe( catchError(this.handleError));
  }

  public create(route: string, body?: any, parametros?: HttpParams, response: ResponseType = ResponseType.Json) {

    let HTTPOptions: Object = {

      params: parametros,
      responseType: response,
      headers: new HttpHeaders(this.generateHeaders())
    }
    return this.http.post(
      this.createCompleteRoute(route,this.environment.urlAddress),
      body,
      HTTPOptions
    ).pipe( catchError(this.handleError));
  }

  public update(route: string, body: any, parametros?: HttpParams, response: ResponseType = ResponseType.Json) {

    let HTTPOptions: Object = {

      params: parametros,
      responseType: response,
      headers: new HttpHeaders(this.generateHeaders())
    }

    return this.http.put(
      this.createCompleteRoute(route,this.environment.urlAddress),
      body,
      HTTPOptions
    ).pipe( catchError(this.handleError));
  }

  public delete(route: string, parametros?: HttpParams, response: ResponseType = ResponseType.Json) {

    let HTTPOptions: Object = {

      params: parametros,
      responseType: response,
    }

    return this.http.delete(
      this.createCompleteRoute(route,this.environment.urlAddress),
      HTTPOptions
    ).pipe( catchError(this.handleError));
  }



  private createCompleteRoute(route: string, envAddress: string) {
    // console.log("createCompleteRoute: ", `${envAddress}/${route}`);
    return `${envAddress}/${route}`;
  }


  private generateHeaders() {
    const headerConfig = {
      'Content-Type': 'application/json',
    }
    return headerConfig;
  }

  private handleError(error: HttpErrorResponse) {

    let  response : ProblemDetails= new ProblemDetails();

    try {

          if (error.status === 0) {

            response.status = 500;
            response.title  = "Revise su conexión a internet.";
            response.detail = "Error al conectar al servidor.";

            return throwError(response);

          } else {

            return throwError(error.error);

          }

    } catch (e) {

      return throwError(error);

    }


  }


 }
