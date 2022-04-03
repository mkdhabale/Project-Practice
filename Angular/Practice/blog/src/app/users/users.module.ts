import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { FormComponent } from './form/form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [LoginComponent,FormComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    LoginComponent,
    FormComponent
  ]
})
export class UsersModule {
  
 }
