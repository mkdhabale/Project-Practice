import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObservableTestingComponent } from './observable-testing.component';

describe('ObservableTestingComponent', () => {
  let component: ObservableTestingComponent;
  let fixture: ComponentFixture<ObservableTestingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObservableTestingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObservableTestingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
