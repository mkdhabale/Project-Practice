import { Component, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { UserDataServiceService } from './Services/user-data-service.service';
interface Alert {
  type: string;
  message: string;
}
const ALERTS: Alert[] = [{
  type: 'success',
  message: 'This is an success alert',
}, {
  type: 'info',
  message: 'This is an info alert',
}, {
  type: 'warning',
  message: 'This is a warning alert',
}, {
  type: 'danger',
  message: 'This is a danger alert',
}, {
  type: 'primary',
  message: 'This is a primary alert',
}, {
  type: 'secondary',
  message: 'This is a secondary alert',
}, {
  type: 'light',
  message: 'This is a light alert',
}, {
  type: 'dark',
  message: 'This is a dark alert',
}
];
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  data: String = "mukuld D";
  title ="mkd1";
  data1 = [];
  constructor(private us: UserDataServiceService,
    private viewContainer: ViewContainerRef,
    private cfr: ComponentFactoryResolver) {
    this.us.getData().subscribe(data => {
      console.log(data);
    })
  }



  parentCF(data) {
    alert(data);
  }

  async loadAdmin() {
    this.viewContainer.clear();
    const { AdminlazyComponent } = await import('./adminlazy/adminlazy.component')
    this.viewContainer.createComponent(
      this.cfr.resolveComponentFactory(AdminlazyComponent)
    )
  }

  async loadList() {
    this.viewContainer.clear();
    const { UserlistlazyComponent } = await import('./userlistlazy/userlistlazy.component')
    this.viewContainer.createComponent(
      this.cfr.resolveComponentFactory(UserlistlazyComponent)
    )
  }
}
