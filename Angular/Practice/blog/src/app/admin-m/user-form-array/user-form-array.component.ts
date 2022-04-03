import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'app-user-form-array',
  templateUrl: './user-form-array.component.html',
  styleUrls: ['./user-form-array.component.css']
})
export class UserFormArrayComponent implements OnInit {
  userForm!: FormGroup;
  // itemArr = FormArray;


  // //bind selector
  get email() { return this.userForm.get('email') }
  get password() { return this.userForm.get('password') }

  constructor(private formBuilder: FormBuilder) {
    this.userForm = formBuilder.group({
      email: ['', [Validators.required, Validators.email, Validators.minLength(5)]],
      password: [''],
      itemsA: this.formBuilder.array([
        this.formBuilder.group({
          itemId: ['1'],
          itemName: ['namww'],
          itemDesc: ['1'],
          itemDone: ['', Validators.requiredTrue],
        }),
        this.formBuilder.group({
          itemId: ['12'],
          itemName: ['na2222mww'],
          itemDesc: ['12'],
          itemDone: ['', Validators.requiredTrue],
        }),
        this.formBuilder.group({
          itemId: ['13'],
          itemName: ['vbvbvbv'],
          itemDesc: ['13'],
          itemDone: [''],
        })
      ])
    });
  }

  ngOnInit(): void {

  }

  collectData() {
    console.warn(this.userForm.value)
    /*this.clearForm();*/
  }
  clearForm() {
    this.userForm.reset();
  }
  get item(){
    return this.userForm.get('itemsA') as FormArray;
  }

  addNewItem(){
    const itemLength = this.item.length; 
    const newItem = this.formBuilder.group({
      itemId: [itemLength + 1],
      itemName: ['new added'],
      itemDesc: ['1addedww'],
      itemDone: [''],
    });

    this.item.push(newItem);
  }

  removeItem(itemId){
    this.item.removeAt(itemId);
  }
}
