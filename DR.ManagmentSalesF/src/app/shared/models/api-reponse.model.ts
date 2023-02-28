import { Mensaje } from "./mensaje.model";

export class APIResponse {

    codigo :number;
    status : boolean;
    valorObjeto : any;
    mensaje : Mensaje[];
    
     constructor() {
        
        this.status = false;
        this.valorObjeto = null;
        this.mensaje = [];
        this.codigo = 0;
     }



}