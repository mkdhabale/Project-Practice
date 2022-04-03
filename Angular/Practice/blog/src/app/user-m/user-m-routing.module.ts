import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ListComponent} from './list/list.component'
import {UserComponent} from './user/user.component'
const routes: Routes = [
  {
    path: 'user1', children: [
      { path: 'list', component: ListComponent },
      { path: 'user', component: UserComponent }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserMRoutingModule { }
