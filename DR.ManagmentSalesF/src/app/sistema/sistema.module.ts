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
import { AngularDevExtremeModule } from "../shared/modules/devextreme-angular.module";
import { ProductoService } from './services/producto.service';
import { AsesorService } from './services/asesor.service';
import { VentaService } from "./services/venta.service";


const componentes  =  [ NavbarComponent,
                        AsesorComponent,
                        ProductoComponent,
                        ListaProductoComponent,
                        ListaAsesorComponent,
                        ReporteVentaComponent,
                        VentaComponent,
                        PanelPrincipalComponent];
const pipes  = [];
const directives = [];


@NgModule({

  declarations: [
    componentes,
    pipes,
    directives,
    
    
  ],

  imports: [
    
    SharedModule,
    AngularDevExtremeModule,
    SistemaRoutingModule
  ],

  exports : [
    

  ],

  providers: [
    ProductoService,
    AsesorService,
    VentaService
  ],
 
})
export class SistemaModule { 


}
