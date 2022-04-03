import { Component, OnInit } from '@angular/core';
console.log('user list lazy load TS')
@Component({
  selector: 'app-userlistlazy',
  templateUrl: './userlistlazy.component.html',
  styleUrls: ['./userlistlazy.component.css']
})
export class UserlistlazyComponent implements OnInit {

  constructor() {console.log('user list lazy load') }

  ngOnInit(): void {
  }

}
