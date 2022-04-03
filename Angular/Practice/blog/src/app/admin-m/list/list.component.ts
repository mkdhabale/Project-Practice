import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  componentName ="list";
listData = {
  email:"mukul@gmail.com",
  password:"dfdfdfd",
  address:"dfddf",
  mobile1:"32313212"
}
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(data){
    console.log(data)
  }
sum(a, b){
  return a+b;
}

}
