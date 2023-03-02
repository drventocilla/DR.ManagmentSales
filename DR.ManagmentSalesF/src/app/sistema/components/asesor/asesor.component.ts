import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { generarCodigo } from 'src/app/core/helpers/other.helpers';
import { APIResponse } from 'src/app/shared/models/api-reponse.model';
import { FormResult } from 'src/app/shared/models/form-result';
import { SharedModalService } from 'src/app/shared/services/shared-modal.service';
import { SpinnerService } from 'src/app/shared/services/spinner.service';
import { Asesor } from '../../models/asesor.model';
import { AsesorService } from '../../services/asesor.service';


@Component({
  selector: 'app-asesor',
  templateUrl: './asesor.component.html',
  styleUrls: ['./asesor.component.css']
})
export class AsesorComponent implements OnInit {

  estadoDeFormulario = new FormResult();
  formulario: FormGroup;
  codigoActual : string;

    constructor(private sharedModalService: SharedModalService,
    private spinner: SpinnerService,
    public dialogRef: MatDialogRef<AsesorComponent>,
    private asesorService: AsesorService,
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

    let asesor = this.pasarFormularioAEntidad();
    this.spinner.showBallAtom("asesor");
    this.asesorService.save(asesor)
      .subscribe((respuesta: APIResponse) => {
        
        this.estadoDeFormulario.status = true;
        this.spinner.hide("asesor");
        this.sharedModalService.mostrarMessageModal(respuesta.message, true);
        this.close();
      }
        , (error: APIResponse) => {
          this.spinner.hide("asesor");
          try {
            this.sharedModalService.mostrarMessageModal(error.message, false);
          } catch (e) {
            this.sharedModalService.mostrarMessageModal( {description :'Error al conectar con el servidor, intente recargar la página'}, false);
          }
        });
  }

  pasarFormularioAEntidad(): Asesor {

    let entidad = new Asesor();
    
    entidad.id = this.codigoActual? this.codigoActual: generarCodigo();
    entidad.nombres = this.nombres.value;
    entidad.celular = this.celular.value;
    entidad.email = this.email.value;
    
    return entidad;

  }

  pasarEntidadAFormulario(entidad: Asesor) {

    this.codigoActual = entidad.id;
    this.nombres.setValue(entidad.nombres);
    this.celular.setValue(entidad.celular);
    this.email.setValue(entidad.email);

  }


  
  controlesDelFormulario() {

    this.formulario = new FormGroup({

      nombres: new FormControl("", [Validators.required , Validators.maxLength(50)]),
      celular: new FormControl("", [Validators.required , Validators.maxLength(20)]),
      email: new FormControl("", [Validators.required , Validators.pattern(/[^ @]*@[^ @]*/)]),
    });
  }

  find(codigo: string) {

    this.spinner.showBallAtom("asesor");
    this.asesorService.find(codigo)
      .subscribe((respuesta: APIResponse) => {
        this.spinner.hide("asesor");
        this.pasarEntidadAFormulario(respuesta.data);
      }
        , (error: APIResponse) => {
          this.spinner.hide("asesor");
          try {
            this.sharedModalService.mostrarMessageModal(error.message, false);
          } catch (e) {
            this.sharedModalService.mostrarMessageModal( {description :'Error al conectar con el servidor, intente recargar la página'}, false);
          }

        });
  }

  get nombres() {
    return this.formulario.get("nombres");
  }
 
  get celular() {
    return this.formulario.get("celular");
  }

  get email() {
    return this.formulario.get("email");
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
