import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {UsersModule} from './users/users.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserListComponent } from './user-list/user-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CustomStyleDirective } from './custom-style.directive';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';


import {UserMModule} from './user-m/user-m.module';
import { UserlistlazyComponent } from './userlistlazy/userlistlazy.component';
import { AdminlazyComponent } from './adminlazy/adminlazy.component';
import { LoggingInterceptor } from './Interceptor/logging.interceptor';
import { LoadingInterceptor } from './Interceptor/loading.interceptor';
// import {AdminMModule} from './admin-m/admin-m.module';

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    PageNotFoundComponent,
    CustomStyleDirective,
    UserlistlazyComponent,
    AdminlazyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsersModule,
    NgbModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatSliderModule,
    HttpClientModule,
    UserMModule,
    // AdminMModule
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS, useClass: LoggingInterceptor, multi:true,
    },
    {
      provide:HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi:true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
