import { Component } from '@angular/core';
import { LoginOrRegisterComponent, UserService } from '../../shared';
import { IUserLogin } from '../../shared/model/user.model';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { CardModule } from 'primeng/card';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    imports: [LoginOrRegisterComponent,
        CardModule,
        RouterLink,
        ToastModule,
        ButtonModule],
  standalone: true,
})
export class LoginComponent {

  constructor(private userService: UserService, private messageService: MessageService, private router: Router){}

  protected onLogin(user: IUserLogin){
    if(user){
      this.userService.login(user).subscribe({
        next:(response) => {
          if(response){
            this.messageService.add({ severity: 'success', summary: 'Success', detail: 'You are successfuly logged in', life: 3000 });
          } else {
            this.messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Api returns OK, but user is null.', life: 3000 });
          }
          console.log('hm?');
          this.router.navigate(['']);
        },
        error: (error: HttpErrorResponse)=> {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: `${error.error.errors[0]}`, life: 4000 });
        }
      })
    }
  }
}
