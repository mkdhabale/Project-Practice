import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators} from '@angular/forms';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
userForm= new FormGroup({
  email: new FormControl('',[Validators.required, Validators.email,Validators.minLength(5)]),
  password: new FormControl('')
})

//bind selector
get email(){return this.userForm.get('email')}
get password(){return this.userForm.get('password')}

  constructor() { }

  ngOnInit(): void {

    //bind values
    /*this.userForm.setValue({
      email: 'mkd@dfbma.com',
      password:'ddfdfdf'
    })*/
    this.userForm.patchValue({
      email: 'mkd@dfbma.com',
      // password:'ddfdfdf'
    })

    //bind value change
    /*this.userForm.valueChanges.subscribe(data=>{
      console.log(data);
    })*/
   /* this.userForm.get('email')?.valueChanges.subscribe(data=>{
      console.log(data);
    })*/


    //get status change on Form
    this.userForm.statusChanges.subscribe(data=>{
      console.log(data);
    })
    //get status change on control
    /*this.userForm.get('email')?.statusChanges.subscribe(data=>{
      console.log(data);
    })*/
  }

  collectData(){
    console.warn(this.userForm.value)
    /*this.clearForm();*/
  }
  clearForm(){
    this.userForm.reset();
  }
  


}
