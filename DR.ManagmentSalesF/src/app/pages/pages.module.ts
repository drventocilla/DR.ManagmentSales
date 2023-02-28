import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { LoginComponent } from './components/login/login.component';
import { UnderConstructionComponent } from './components/under-construction/under-construction.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { InternalServerComponent } from './components/internal-server/internal-server.component';
import { PagesRoutingModule } from "./pages-routing.module";

const componentes  = [ LoginComponent,
                       UnderConstructionComponent,
                       NotFoundComponent,
                       InternalServerComponent ];
const pipes  = [];
const directives = [];


@NgModule({

  declarations: [
    componentes,
    pipes,
    directives    
  ],

  imports: [
    
    SharedModule,
    PagesRoutingModule
    
  ],

  exports : [
    

  ],

  providers: [

  ],
 
})
export class PagesModule { 


}
