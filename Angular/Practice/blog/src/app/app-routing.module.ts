import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './users/login/login.component';
import {FormComponent} from './users/form/form.component';
import {UserListComponent} from './user-list/user-list.component';
import {UserComponent} from './user-m/user/user.component';
import {ListComponent} from './admin-m/list/list.component';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
const routes: Routes = [
{
 path: 'log',
 component:UserListComponent
},
{
  path: 'uselist',
  component:UserListComponent
 },
 {
  path: 'form',
  component:FormComponent
 },
 {
  path: 'admin',
  loadChildren:()=>import('./admin-m/admin-m.module')
  .then(mod=>mod.AdminMModule)
 },
 /*{
  path: '**',
  component:PageNotFoundComponent
 },*/



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
