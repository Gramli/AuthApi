import { Component } from '@angular/core';
import { UserService } from '../../shared';
import { IUserLogin } from '../../shared/model/user.model';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [MessageService]
})
export class LoginComponent {

  constructor(private userService: UserService, private messageService: MessageService, private router: Router){}

  protected onLogin(user: IUserLogin){
    if(user){
      this.userService.login(user).subscribe({
        next:(response) => {
          if(response){
          this.messageService.add({ severity: 'success', summary: `User ${response.name} successfuly logged in.`, detail: 'Message Content', key: 'br', life: 3000 });
          } else {
            this.messageService.add({ severity: 'warn', summary: `Api returns OK, but user is null.`, detail: 'Message Content', key: 'br', life: 3000 });
          }
          this.router.navigate(['']);
        },
        error: (error)=> {
          this.messageService.add({ severity: 'danger', summary: `Login Error: ${error}`, detail: 'Message Content', key: 'br', life: 4000 });
        }
      })
    }
  }
}
