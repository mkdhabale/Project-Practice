import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserMRoutingModule } from './user-m-routing.module';
import { UserComponent } from './user/user.component';
import { ListComponent } from './list/list.component';


@NgModule({
  declarations: [UserComponent, ListComponent],
  imports: [
    CommonModule,
    UserMRoutingModule
  ]
})
export class UserMModule { }
