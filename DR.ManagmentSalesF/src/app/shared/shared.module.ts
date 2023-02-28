import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AngularMaterialModule } from "./modules/angular-material.module";
import { NgxSpinnerModule } from "ngx-spinner";
import { LoadingComponent } from "./components/loading/loading.component";
import { DecisionModalComponent } from "./components/modales/decision-modal/decision-modal.component";
import { MessageModalV2Component } from "./components/modales/message-modal-v2/message-modal-v2.component";

const componentes  = [LoadingComponent ,
                      DecisionModalComponent, 
                      MessageModalV2Component];



const pipes = [];



const directives= [];


@NgModule({

  declarations: [

    componentes,
    pipes,
    directives
  ],

  imports: [
    
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    AngularMaterialModule,
    RouterModule,
    NgxSpinnerModule
    
    ],

  exports : [

    componentes,
    pipes,
    directives,
    AngularMaterialModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    NgxSpinnerModule

  ],

  providers: [

  ],
 
})
export class SharedModule { 


}
