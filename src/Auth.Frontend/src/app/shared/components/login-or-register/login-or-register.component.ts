import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, signal, WritableSignal } from '@angular/core';
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
    imports: [CommonModule, FormsModule, ReactiveFormsModule, InputTextModule, ButtonModule, PasswordModule],
    templateUrl: './login-or-register.component.html',
    styleUrl: './login-or-register.component.scss',
    standalone: true,
})
export class LoginOrRegisterComponent implements OnInit {
  @Input() showEmail = false;
  @Input() submitText = 'Submit';
  @Output() submitEvent: EventEmitter<SubmitedUser> =
    new EventEmitter<SubmitedUser>();

  protected userForm: WritableSignal<FormGroup> = signal(new FormGroup({}));

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.userForm.set(this.formBuilder.group({
      userName: new FormControl('', [ Validators.required, Validators.pattern('[a-zA-Z]{3,}')]),
      password: new FormControl('', [ Validators.required]),
    }));

    if (this.showEmail) {
      this.userForm().addControl('email', new FormControl('', [Validators.required, Validators.pattern('.+@.+\..{2,}')]));
    }
  }

  protected onSubmitClick(): void {
    const password = this.userForm().get('password')!.value;
    const userName = this.userForm().get('userName')!.value;

    if (this.showEmail) {
      this.submitEvent.emit({
        password,
        userName,
        email: this.userForm().get('email')!.value,
      });
    } else {
      this.submitEvent.emit({
        password,
        userName,
      });
    }
  }
}
