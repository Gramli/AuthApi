import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { SubmitedUser } from '../../model/user.model';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';

@Component({
  selector: 'app-login-or-register',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, InputTextModule, ButtonModule, PasswordModule],
  templateUrl: './login-or-register.component.html',
  styleUrl: './login-or-register.component.scss',
})
export class LoginOrRegisterComponent implements OnInit {
  @Input() showEmail = false;
  @Input() submitText = 'Submit';
  @Output() submitEvent: EventEmitter<SubmitedUser> =
    new EventEmitter<SubmitedUser>();

  protected userForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });

    if (this.showEmail) {
      this.userForm.addControl('email', new FormControl('',[Validators.required, Validators.pattern('/^[^\s@]+@[^\s@]+\.[^\s@]+$/')]));
    }
  }

  protected onSubmitClick(): void {
    const password = this.userForm.get('password')!.value;
    const username = this.userForm.get('userName')!.value;

    if (this.showEmail) {
      this.submitEvent.emit({
        password,
        name: username,
        email: this.userForm.get('email')!.value,
      });
    } else {
      this.submitEvent.emit({
        password,
        name: username,
      });
    }
  }
}
