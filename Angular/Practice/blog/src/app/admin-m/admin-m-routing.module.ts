import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminGGuard } from '../Guard/admin-g.guard';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { ListComponent } from './list/list.component'
import { ObservableTestingComponent } from './observable-testing/observable-testing.component';
import { UserFormArrayComponent } from './user-form-array/user-form-array.component';
import { UserHttpComponent } from './user-http/user-http.component';
import { UserComponent } from './user/user.component'
const routes: Routes = [
  
    // path: 'admin-m', children: [
    //   { path: 'list', component: ListComponent },
    //   { path: 'user', component: UserComponent }
    // ]
    { path: 'list', component: ListComponent, canActivate:[AdminGGuard] },
    { path: 'user', component: UserComponent , canActivate:[AdminGGuard]},
    { path: 'userform', component: UserFormArrayComponent , canActivate:[AdminGGuard]},
    { path: 'observableTesting', component: ObservableTestingComponent},
    { path: 'httpuser', component: UserHttpComponent},
    // { path: '**', component: ObservableTestingComponent},
    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminMRoutingModule { }
