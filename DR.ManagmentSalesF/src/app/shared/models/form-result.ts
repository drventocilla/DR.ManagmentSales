import { Message } from "./message.model"

export class FormResult {

   status: boolean;
   mensaje: Message;

   constructor() {
      this.status = false;
      this.mensaje = new Message();
   }

}