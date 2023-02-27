import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AngularMaterialModule } from "./modules/angular-material.module";
import { NgxSpinnerModule } from "ngx-spinner";

const componentes  : any[]= [];



const pipes : any[]= [];



const directives: any[]= [];


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
