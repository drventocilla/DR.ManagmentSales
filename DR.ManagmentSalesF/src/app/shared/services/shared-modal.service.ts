import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { DecisionModalComponent } from "src/app/shared/components/modales/decision-modal/decision-modal.component";
import { MessageModalV2Component } from "../components/modales/message-modal-v2/message-modal-v2.component";

import { Message } from "../models/message.model";


@Injectable({
  providedIn: 'root'
})
export class SharedModalService {
  

  constructor(
    private dialog: MatDialog
  ) {

  }

  mostrarMessageModal(message: Message, operacionExitosa: boolean,  titulo?: string  ) {
    return this.dialog.open(MessageModalV2Component, {
      disableClose: false,
      panelClass: 'message-dialog',
      data: {
        mensaje: message,
        estado: operacionExitosa,
        titulo: titulo,
      }
    })
  }

  mostrarDecisioneModal(message: string, decisionBinary?: boolean) {

    return this.dialog.open(DecisionModalComponent, {
      disableClose: true,
      panelClass: 'message-dialog',
      maxHeight: '10%',
      data: {
        mensaje: `${message}`,
        decisionBinaria: decisionBinary
      }
    })
  }
}