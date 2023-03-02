import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { NavbarComponent } from './components/navbar/navbar.component';
import { AsesorComponent } from './components/asesor/asesor.component';
import { ProductoComponent } from './components/producto/producto.component';
import { ListaProductoComponent } from './components/lista-producto/lista-producto.component';
import { ListaAsesorComponent } from './components/lista-asesor/lista-asesor.component';
import { ReporteVentaComponent } from './components/reporte-venta/reporte-venta.component';
import { VentaComponent } from './components/venta/venta.component';
import { PanelPrincipalComponent } from './components/panel-principal/panel-principal.component';
import { SistemaRoutingModule } from "./sistema-routing.module";


const componentes  = [  ];
const pipes  = [];
const directives = [];


@NgModule({

  declarations: [
    componentes,
    pipes,
    directives,
    NavbarComponent,
    AsesorComponent,
    ProductoComponent,
    ListaProductoComponent,
    ListaAsesorComponent,
    ReporteVentaComponent,
    VentaComponent,
    PanelPrincipalComponent,
    
  ],

  imports: [
    
    SharedModule,
    SistemaRoutingModule
  ],

  exports : [
    

  ],

  providers: [

  ],
 
})
export class SistemaModule { 


}
