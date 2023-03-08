import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TituloCabeceraService } from 'src/app/core/services/titulo.service';
import { SharedModalService } from 'src/app/shared/services/shared-modal.service';
import { SpinnerService } from 'src/app/shared/services/spinner.service';
import { Producto } from '../../models/producto.model';
import { ProductoComponent } from '../producto/producto.component';
import { FormResult } from '../../../shared/models/form-result';
import { ProductoService } from '../../services/producto.service';
import { ProblemDetails } from 'src/app/shared/models/problem-details.model';
import { SucessResponse } from 'src/app/shared/models/succes-response.model';

@Component({
  selector: 'app-lista-producto',
  templateUrl: './lista-producto.component.html',
  styleUrls: ['./lista-producto.component.css']
})
export class ListaProductoComponent implements OnInit {

  listaDeProductos: Producto[];
  constructor(
    private productoService: ProductoService,
    private sharedModalService: SharedModalService,
    private spinner: SpinnerService,
    private dialog: MatDialog,
    private tituloCabeceraService: TituloCabeceraService,
  ) {
    this.tituloCabeceraService.setearTituloActual("Productos");


  }
  ngAfterViewInit(): void {

    this.getAll();
  }

  ngOnInit(): void {


  }
  openDetail(codigo?: string) {

    this.dialog.open(ProductoComponent, {

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

    this.spinner.showBallAtom("lista-productos");

    this.productoService.getAll()
      .subscribe((response: SucessResponse) => {

        this.listaDeProductos = response.data;

        this.spinner.hide("lista-productos");
      }
        , (error: ProblemDetails) => {
          this.spinner.hide("lista-productos");
          try {
            this.sharedModalService.mostrarMessageModal({description: error.title , detail :error.detail }, false);
          } catch (e) {
            this.sharedModalService.mostrarMessageModal({description :'Error al realizar la operación, intente recargar la página'}, false);
          }

        });
  }



  deleteItem(codigo: string) {

    this.spinner.showBallAtom("lista-productos");
    this.productoService.delete(codigo).subscribe((respuesta: any) => {


      this.spinner.hide("lista-productos");
      this.getAll();
    },
      (error: any) => {
        this.spinner.hide("lista-productos");
        try {
          this.sharedModalService.mostrarMessageModal(error.error.value.mensaje.mensajeGenerado, false);
        } catch (e) {
          this.sharedModalService.mostrarMessageModal( {description :'Error al conectar con el servidor, intente recargar la página'}, false);
        }

      });

  }

}
