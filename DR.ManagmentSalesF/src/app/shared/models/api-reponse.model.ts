import { Message } from "./message.model";

export class APIResponse {

    codigo :number;
    status : boolean;
    data : any;
    message : Message;
    code : string;
    errors : string[];

     constructor() {
        
        this.status = false;
        this.data = null;
        this.message = new Message();
        this.errors = [];
        this.codigo = 0;
     }



}