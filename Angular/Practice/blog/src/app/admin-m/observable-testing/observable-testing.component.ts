import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-observable-testing',
  templateUrl: './observable-testing.component.html',
  styleUrls: ['./observable-testing.component.css']
})
export class ObservableTestingComponent implements OnInit {
  orderStatus : any;
  data!: Observable<any>;
  data2!: Observable<any>;
  constructor() { 
  }

  ngOnInit(): void {
   this.data = new Observable(observer => {
      setTimeout(() => {
        observer.next("In Progress");
      }, 2000)
      //logic
      setTimeout(() => {
        observer.next("In Processing");
      }, 4000)


      setTimeout(() => {
        observer.next("In Completed");
      }, 6000)


      setTimeout(() => {
        observer.error()
      }, 6000)


      setTimeout(() => {
        observer.complete()
      }, 6000)

      setTimeout(() => {
        observer.next("after complete not execute");
      }, 8000)


    });

    this.data.subscribe(val => {
      this.orderStatus = val;
    });

    this.data.subscribe(val2 => {
      //this.orderStatus = val2;
      console.log('second subscription')
    })
  }

}
