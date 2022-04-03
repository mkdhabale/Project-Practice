import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserFormArrayComponent } from './user-form-array.component';

describe('UserFormArrayComponent', () => {
  let component: UserFormArrayComponent;
  let fixture: ComponentFixture<UserFormArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserFormArrayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserFormArrayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
