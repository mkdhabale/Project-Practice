import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  
  constructor() {

   }

  ngOnInit(): void {
  }
  

 
  getName(a1:string) {
    alert(a1)
  }

  myEvent(evt:any){
    console.warn(evt)
  }

}
