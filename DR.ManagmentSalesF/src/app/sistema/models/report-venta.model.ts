import { AsesorSummary } from "./asesor-summary.model";
import { Venta } from "./venta.model";

export class ReportVenta {


    detalle : Venta[]
    grupos : AsesorSummary[];

    constructor() {
  
        this.detalle =[];
        this.grupos=[];
    }



}