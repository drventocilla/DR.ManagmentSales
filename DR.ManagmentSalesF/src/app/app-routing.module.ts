import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioGuard } from './core/guards/usuario.guard';

const routes: Routes = [

  {
    path: '',
    loadChildren: () => import('./pages/pages.module').then(m => m.PagesModule)
  },
  {

    path: 'sistema',
    canActivate : [UsuarioGuard],
    loadChildren: () => import('./sistema/sistema.module').then(m => m.SistemaModule)
    
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: '404'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
