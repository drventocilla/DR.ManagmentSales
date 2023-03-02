import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class TituloCabeceraService {

    // private _tituloActual: string = "";
    private tituloSubject$ = new BehaviorSubject<string>("");
    public tituloChanged$ = this.tituloSubject$.asObservable();


    public obtenerTituloActual(): string {
        return this.tituloSubject$.getValue();
    }
    public setearTituloActual(titulo: string) {
        this.tituloSubject$.next(titulo);
    }

}