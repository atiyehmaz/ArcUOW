import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterDepositComponent } from './register-deposit.component';

describe('RegisterDepositComponent', () => {
  let component: RegisterDepositComponent;
  let fixture: ComponentFixture<RegisterDepositComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterDepositComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterDepositComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
