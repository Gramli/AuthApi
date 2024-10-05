import { Component } from '@angular/core';
import { UserService } from '../../shared';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { IRegisterUser } from '../../shared/model/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  providers: [MessageService]
})
export class RegisterComponent {

  constructor(private userService: UserService, private messageService: MessageService, private router: Router){}

  protected onRegister(user: IRegisterUser){
    if(user){
      this.userService.register(user).subscribe({
        next:(response) => {
          if(response.data){
          this.messageService.add({ severity: 'success', summary: `Successfully registered.`, detail: 'Message Content', key: 'br', life: 3000 });
          } else {
            this.messageService.add({ severity: 'warn', summary: `Api returns OK, but user is not registered.`, detail: 'Message Content', key: 'br', life: 3000 });
          }
          this.router.navigate(['login']);
        },
        error: (error)=> {
          this.messageService.add({ severity: 'danger', summary: `Login Error: ${error}`, detail: 'Message Content', key: 'br', life: 4000 });
        }
      })
    }
  }
}
