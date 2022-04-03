import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder, FormArray } from '@angular/forms';

import { UserDataServiceService } from '../../Services/user-data-service.service';

@Component({
  selector: 'app-user-http',
  templateUrl: './user-http.component.html',
  styleUrls: ['./user-http.component.css']
})
export class UserHttpComponent implements OnInit {

  userForm!: FormGroup;

  contactList: any;

  constructor(private us: UserDataServiceService, private formBuilder: FormBuilder) {
    this.userForm = formBuilder.group({
      fName: [''],
      lName: [''],
    });


  }

  ngOnInit(): void {
    this.GetData();
  }

  GetData() {
    this.us.getData().subscribe(data => {
      console.log(data);
      this.contactList = data;
    })
  }
  createData() {
    const jBody = {
      firstName: this.userForm.get("fName")?.value,
      lastName: this.userForm.get("lName")?.value
    };
    this.us.createData(jBody).subscribe(data => {
      console.log(data);
      //this.contactList = data;
    })


   
  }

  updateData(id) {
    const jBody = {
      firstName: this.userForm.get("fName")?.value,
      lastName: this.userForm.get("lName")?.value
    };
    this.us.updateData(id, jBody).subscribe(data => {
      console.log(data);
      //this.contactList = data;
    })
  }

  deleteData(id) {
    this.us.deleteData(id).subscribe(data => {
      console.log(data);
      //this.contactList = data;
    })
  }

  


}
