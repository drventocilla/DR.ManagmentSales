import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TituloCabeceraService } from 'src/app/core/services/titulo.service';
import { APIResponse } from 'src/app/shared/models/api-reponse.model';
import { FormResult } from 'src/app/shared/models/form-result';
import { SharedModalService } from 'src/app/shared/services/shared-modal.service';
import { SpinnerService } from 'src/app/shared/services/spinner.service';
import { AsesorService } from '../../services/asesor.service';
import { Asesor } from '../../models/asesor.model';
import { AsesorComponent } from '../asesor/asesor.component';

@Component({
  selector: 'app-lista-asesor',
  templateUrl: './lista-asesor.component.html',
  styleUrls: ['./lista-asesor.component.css']
})
export class ListaAsesorComponent implements OnInit {

  listaDeAsesores: Asesor[];
  constructor(
    private asesorService: AsesorService,
    private sharedModalService: SharedModalService,
    private spinner: SpinnerService,
    private dialog: MatDialog,
    private tituloCabeceraService: TituloCabeceraService,
  ) {
    this.tituloCabeceraService.setearTituloActual("Asesores");


  }
  ngAfterViewInit(): void {

    this.getAll();
  }

  ngOnInit(): void {


  }
  openDetail(codigo?: string) {

    this.dialog.open(AsesorComponent, {

      disableClose: false,
      data: {
        codigo: codigo
      },
      panelClass: 'no-padding-dialog',
      maxWidth: '500px',
      minWidth: '350px',
      maxHeight: '95vh',
      height: 'auto',

    }).afterClosed().subscribe((formularioResultado: FormResult) => {

      if (formularioResultado.status) {
        this.getAll();

      }

    });

  }

  colorCelda(value: any, dato: any) {
    //// console.log("rowelement:", value.data);
    if (value.data == undefined) {
    }
    else {
    }
  }

  getAll() {

    this.spinner.showBallAtom("lista-asesores");

    this.asesorService.getAll()
      .subscribe((response: APIResponse) => {

        this.listaDeAsesores = response.data;
        
        this.spinner.hide("lista-asesores");
      }
        , (error: APIResponse) => {
          this.spinner.hide("lista-asesores");
          try {
            this.sharedModalService.mostrarMessageModal(error.message, false);
          } catch (e) {
            this.sharedModalService.mostrarMessageModal( {description :'Error al conectar con el servidor, intente recargar la página'}, false);
          }

        });
  }



  deleteItem(codigo: string) {

    this.spinner.showBallAtom("lista-asesores");
    this.asesorService.delete(codigo).subscribe((respuesta: any) => {
    
    this.spinner.hide("lista-asesores");
      this.getAll();
    },
      (error: any) => {
        this.spinner.hide("lista-asesores");
        try {
          this.sharedModalService.mostrarMessageModal(error.error.value.mensaje.mensajeGenerado, false);
        } catch (e) {
          this.sharedModalService.mostrarMessageModal( {description :'Error al conectar con el servidor, intente recargar la página'}, false);
        }

      });

  }

}
