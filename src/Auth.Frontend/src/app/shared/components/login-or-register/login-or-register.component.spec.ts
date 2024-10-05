import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginOrRegisterComponent } from './login-or-register.component';

describe('LoginOrRegisterComponent', () => {
  let component: LoginOrRegisterComponent;
  let fixture: ComponentFixture<LoginOrRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginOrRegisterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginOrRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
