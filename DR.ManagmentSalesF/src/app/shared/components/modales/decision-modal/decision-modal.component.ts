import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormResult } from '../../../models/form-result';

@Component({
  selector: 'app-decision-modal',
  templateUrl: './decision-modal.component.html',
  styleUrls: ['./decision-modal.component.css']
})
export class DecisionModalComponent implements OnInit {
  
 
  public decision: FormResult = new FormResult();
  public decisionBinary: boolean = false;

  constructor(public dialogRef: MatDialogRef<DecisionModalComponent>,
  @Inject(MAT_DIALOG_DATA) public data: any,) { }

  ngOnInit() {
   // console.log(this.data);
   this.asignacionDeData();
  }

  //#region Asignación de data
  public asignacionDeData(){
    this.decisionBinary = this.data.decisionBinaria;
  }
  //#endregion Asignación de data
  public aceptar(): void{
    this.decision.status = true;
    this.dialogRef.close(this.decision);
  }
  public cancelar(): void{
    this.decision.status = false;
    this.dialogRef.close(this.decision);
  }

  //#region Close mmodal
  public closeModal(){
    this.dialogRef.close(this.decision);
  }
  //#endregion Close modal
}
