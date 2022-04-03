import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminMRoutingModule } from './admin-m-routing.module';
import { UserComponent } from './user/user.component';
import { ListComponent } from './list/list.component';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { UserFormArrayComponent } from './user-form-array/user-form-array.component';
import { ObservableTestingComponent } from './observable-testing/observable-testing.component';
import { UserHttpComponent } from './user-http/user-http.component'

console.warn('admin m');

@NgModule({
  declarations: [UserComponent, ListComponent, UserFormArrayComponent, ObservableTestingComponent, UserHttpComponent],
  imports: [
    CommonModule,
    AdminMRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
})
export class AdminMModule { }
