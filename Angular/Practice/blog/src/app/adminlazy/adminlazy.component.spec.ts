import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminlazyComponent } from './adminlazy.component';

describe('AdminlazyComponent', () => {
  let component: AdminlazyComponent;
  let fixture: ComponentFixture<AdminlazyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminlazyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminlazyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
