import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { InteceptorsModule } from './core/interceptors/interceptors.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    CoreModule,
    InteceptorsModule
  ],
  providers: [{
    provide: LOCALE_ID,
    useValue: 'es-PE'
  },
  {
    provide: MAT_DATE_LOCALE,
    useValue: 'es-PE'
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
2