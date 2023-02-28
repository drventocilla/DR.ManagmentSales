import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { DecisionModalComponent } from "src/app/shared/components/modales/decision-modal/decision-modal.component";
import { MessageModalV2Component } from "../components/modales/message-modal-v2/message-modal-v2.component";

import { Mensaje } from "../models/mensaje.model";


@Injectable({
  providedIn: 'root'
})
export class SharedModalService {
  

  constructor(
    private dialog: MatDialog
  ) {

  }

  mostrarMessageModalV2(mensajeAMostrar: Mensaje, operacionExitosa: boolean, mensajePieDialogo?: string,  titulo?: string  ) {
    return this.dialog.open(MessageModalV2Component, {
      disableClose: false,
      panelClass: 'ccont-message-dialog',
      data: {
        mensaje: mensajeAMostrar,
        estado: operacionExitosa,
        titulo: titulo,
      }
    })
  }

  mostrarDecisioneModal(mensajeAMostrar: string, decisionBinaria?: boolean) {

    return this.dialog.open(DecisionModalComponent, {
      disableClose: true,
      panelClass: 'ccont-message-dialog',
      maxHeight: '10%',
      data: {
        mensaje: `${mensajeAMostrar}`,
        decisionBinaria: decisionBinaria
      }
    })
  }
}