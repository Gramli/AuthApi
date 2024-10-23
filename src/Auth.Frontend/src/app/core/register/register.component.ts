import { Component } from '@angular/core';
import { LoginOrRegisterComponent, UserService } from '../../shared';
import { Router } from '@angular/router';
import { IRegisterUser, SubmitedUser } from '../../shared/model/user.model';
import { CardModule } from 'primeng/card';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  standalone: true,
  imports: [
    LoginOrRegisterComponent,
    CardModule,
    RouterLink,
    RouterOutlet,
    ToastModule,
    ButtonModule,
  ],
})
export class RegisterComponent {
  constructor(
    private userService: UserService,
    private messageService: MessageService,
    private router: Router
  ) {}

  protected onRegister(user: SubmitedUser) {
    if (user) {
      const regUser = user as IRegisterUser;
      if (regUser) {
        this.userService.register(regUser).subscribe({
          next: (response) => {
            if (response.data) {
              this.messageService.add({
                severity: 'success',
                summary: 'Success',
                detail: 'Successfully registered.',
                life: 3000,
              });
            } else {
              this.messageService.add({
                severity: 'warn',
                detail: `Api returns OK, but user is not registered.`,
                summary: 'Warning',
                life: 3000,
              });
            }
            this.router.navigate(['login']);
          },
          error: (error) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: `${error.error.errors[0]}`,
              life: 4000,
            });
          },
        });
      }
    }
  }
}
