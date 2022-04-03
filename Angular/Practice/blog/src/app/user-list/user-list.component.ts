import { Component, OnInit, Output,EventEmitter } from '@angular/core';
console.log('User list')
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
@Output()parentCF:EventEmitter<any> = new EventEmitter()
  constructor() { }

  ngOnInit(): void {
    this.parentCF.emit("Hello")
  }

}
