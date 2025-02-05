import { CommonModule } from '@angular/common';
import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { IUser } from '../../shared/model/user.model';
import { UserService } from '../../shared';

@Component({
    selector: 'app-users-info',
    imports: [CommonModule],
    templateUrl: './users-info.component.html',
    styleUrl: './users-info.component.scss'
})
export class UsersInfoComponent implements OnInit {
  protected users: WritableSignal<IUser[] | undefined> = signal(undefined);

  constructor(protected userService: UserService){
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  private loadUsers(): void {
    this.userService.getUsersInfo().subscribe({
      next: (response)=> {
        this.users.set(response.data);
      },
    });
  }
}
