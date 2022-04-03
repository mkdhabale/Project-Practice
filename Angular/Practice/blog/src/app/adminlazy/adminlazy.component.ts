import { Component, OnInit } from '@angular/core';
console.log('adminlazy load TS')
@Component({
  selector: 'app-adminlazy',
  templateUrl: './adminlazy.component.html',
  styleUrls: ['./adminlazy.component.css']
})
export class AdminlazyComponent implements OnInit {

  constructor() { console.log('adminlazy load')}

  ngOnInit(): void {
  }

}
