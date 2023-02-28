
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { ExpiracionTokenInterceptor } from './interceptors/expiracion-token.interceptor';
import { TokenInterceptor } from './interceptors/token.interceptor';

@NgModule({

  declarations: [

  ],
  imports: [
 
  ],
  exports :[
       
  ],

  providers : [
    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
  },

  {
      provide: HTTP_INTERCEPTORS,
      useClass: ExpiracionTokenInterceptor,
      multi: true,
  },

  ]
    
})
export class CoreModule {

  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only'
      );
    }

  }
}