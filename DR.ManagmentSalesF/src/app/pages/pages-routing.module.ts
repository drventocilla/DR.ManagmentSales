import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagesGuard } from '../core/guards/pages.guard';
import { InternalServerComponent } from './components/internal-server/internal-server.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { UnderConstructionComponent } from './components/under-construction/under-construction.component';

const routes: Routes = [ 

  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },

{
  path: 'login',
  component: LoginComponent
},
{ 
  path: 'under-construction',
  component: UnderConstructionComponent
},
{ 
  path: '404',
  component: NotFoundComponent
},
{ 
  path: '500',
  component: InternalServerComponent
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
