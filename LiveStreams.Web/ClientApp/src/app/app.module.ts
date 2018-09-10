import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

// Material
import {MaterialModule} from './core/material/material.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {AppRoutingModule} from './app.routes';
import {HttpClientService} from './core/index';

import {AppComponent} from './app.component';
import {CoreModule} from './core/core.module';
import {PageNotFoundComponent} from './pageNotFound.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {LoggerService} from './core/logger/logger.service';
import {ConsoleLoggerService} from './core/logger/consoleLogger.service';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    NavMenuComponent
    //
    //
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    CoreModule,
    HttpClientModule,
    FormsModule,

    // Material
    MaterialModule,
    BrowserAnimationsModule,

    // Routing
    AppRoutingModule
  ],
  providers: [
    HttpClientService,
    {provide: LoggerService, useClass: ConsoleLoggerService}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
