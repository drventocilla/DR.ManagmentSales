import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Producto } from '../../models/producto.model';
import { FormResult } from '../../../shared/models/form-result';
import { SharedModalService } from 'src/app/shared/services/shared-modal.service';
import { SpinnerService } from 'src/app/shared/services/spinner.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductoService } from '../../services/producto.service';
import { generarCodigo } from '../../../core/helpers/other.helpers';
import { SucessResponse } from 'src/app/shared/models/succes-response.model';
import { ProblemDetails } from 'src/app/shared/models/problem-details.model';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  estadoDeFormulario = new FormResult();
  formulario: FormGroup;
  codigoActual : string;

    constructor(private sharedModalService: SharedModalService,
    private spinner: SpinnerService,
    public dialogRef: MatDialogRef<ProductoComponent>,
    private productoService: ProductoService,
    @Inject(MAT_DIALOG_DATA) public data: any) {

    this.controlesDelFormulario();

  }
  ngAfterViewInit(): void {

    if (this.data.codigo) {
      this.find(this.data.codigo);

    }
  }



  ngOnInit(): void {

    this.dialogRef.keydownEvents().subscribe(event => {
      if (event.key === "Escape") {
        this.close();
      }
    });

    this.dialogRef.backdropClick().subscribe(event => {
      this.close();
    });

  }

  save() {
    this.formulario.markAllAsTouched();
    if (this.formulario.valid) {
      this.execute_save();
    }
    else {
      this.sharedModalService.mostrarMessageModal( {description :"Formulario inválido. revise los campos marcados en rojo"}, false);
    }

  }

  execute_save() {

    let producto = this.pasarFormularioAEntidad();
    this.spinner.showBallAtom("producto");
    this.productoService.save(producto)
      .subscribe((respuesta: SucessResponse) => {

        this.estadoDeFormulario.status = true;
        this.spinner.hide("producto");
        this.sharedModalService.mostrarMessageModal({description : respuesta.title , detail : respuesta.detail}, true);
        this.close();
      }
        , (error: ProblemDetails) => {
          this.spinner.hide("producto");
          try {
            this.sharedModalService.mostrarMessageModal({description: error.title , detail :error.detail }, false);
          } catch (e) {
            this.sharedModalService.mostrarMessageModal( {description :'Error al conectar con el servidor, intente recargar la página'}, false);
          }
        });
  }

  pasarFormularioAEntidad(): Producto {

    let entidad = new Producto();

    entidad.id = this.codigoActual? this.codigoActual: generarCodigo();
    entidad.nombre = this.nombre.value;
    entidad.precio = this.precio.value;

    return entidad;

  }

  pasarEntidadAFormulario(entidad: Producto) {

    this.codigoActual = entidad.id;
    this.nombre.setValue(entidad.nombre);
    this.precio.setValue(entidad.precio);

  }

  controlesDelFormulario() {

    this.formulario = new FormGroup({

      nombre: new FormControl("", [Validators.required , Validators.maxLength(50)]),
      precio: new FormControl("", [Validators.required , Validators.max(10000) , Validators.min(0.1) ]),
    });
  }

  find(codigo: string) {

    this.spinner.showBallAtom("producto");
    this.productoService.find(codigo)
      .subscribe((respuesta: SucessResponse) => {
        this.spinner.hide("producto");
        this.pasarEntidadAFormulario(respuesta.data);
      }
        , (error: ProblemDetails) => {
          this.spinner.hide("producto");
          try {
            this.sharedModalService.mostrarMessageModal({description: error.title , detail :error.detail }, false);
          } catch (e) {
            this.sharedModalService.mostrarMessageModal( {description :'Error al realizar la operación, intente recargar la página'}, false);
          }

        });
  }

  get nombre() {
    return this.formulario.get("nombre");
  }

  get precio() {
    return this.formulario.get("precio");
  }

  closeWindow(close: boolean) {

    if (close) {
      this.close();
    }
  }
  close() {
    this.dialogRef.close(this.estadoDeFormulario);
  }

}
