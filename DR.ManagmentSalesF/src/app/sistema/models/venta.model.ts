import { Asesor } from './asesor.model';
export class Venta {

    id: string;
    tipoDeDocumento: string;
    serie: string;
    numero: number;
    asesorId: string;
    asesor: Asesor;
    estadoActual: number;
    total: number;
    fechaCreacion: Date;

    constructor() {

        this.id = "";
        this.tipoDeDocumento = "";
        this.serie = "";
        this.numero = 0;
        this.asesorId = "";
        this.asesor = new Asesor();
        this.estadoActual= 0;
        this.total =0;
        this.fechaCreacion = new Date();
            
    }
    
}