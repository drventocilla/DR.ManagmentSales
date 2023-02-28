import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PanelPrincipalComponent } from './components/panel-principal/panel-principal.component';
import { AsesorComponent } from './components/asesor/asesor.component';
import { ProductoComponent } from './components/producto/producto.component';
import { ReporteVentaComponent } from './components/reporte-venta/reporte-venta.component';

const routes: Routes = [

   {

    path : '' , 
    component  : NavbarComponent,
    children : [

          {
            path: '' ,
            redirectTo: 'panel',
            pathMatch: 'full',

          }, 
          {
            path: 'panel' ,
            component: PanelPrincipalComponent,
          },
          {
            path: 'asesor' ,
            component: AsesorComponent,
          },
          {
            path: 'producto' ,
            component: ProductoComponent,
          },
          {
            path: 'reporte-venta' ,
            component: ReporteVentaComponent,
          }
      ]

   }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SistemaRoutingModule {




 }
