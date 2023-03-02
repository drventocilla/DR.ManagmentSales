import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Message } from 'src/app/shared/models/message.model';


@Component({
  selector: 'app-message-modal-v2',
  templateUrl: './message-modal-v2.component.html',
  styleUrls: ['./message-modal-v2.component.css']
})
export class MessageModalV2Component implements OnInit {


  _mensajePieDialogo : string ; 
  _titulo: string = "";
  _mensaje:Message = new Message();

  constructor(
    public dialogRef: MatDialogRef<MessageModalV2Component>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.asignarData();
  }

  ngOnInit() {
  }

  asignarData() {

    if (this.data.titulo == undefined || this.data.titulo == null) {

      if (this.data.estado == true) {
        this._titulo = "CORRECTO";

      } else {

        this._titulo = "ERROR";

      }
    } else {
      this._titulo = this.data.titulo;
    }
    this._mensaje = this.data.mensaje
   
  }

  public aceptar(): void {
    this.dialogRef.close(this.data.estado);
  }

  //#region Close modal
  public closeDialog() {
    this.dialogRef.close();
  }
  //#endregion Close modal

}
