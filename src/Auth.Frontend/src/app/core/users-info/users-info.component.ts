
import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { IUser } from '../../shared/model/user.model';
import { AdminUserService, UserAuthService } from '../../shared';

@Component({
    selector: 'app-users-info',
    imports: [],
    templateUrl: './users-info.component.html',
    styleUrl: './users-info.component.scss'
})
export class UsersInfoComponent implements OnInit {
  protected users: WritableSignal<IUser[] | undefined> = signal(undefined);

  constructor(protected adminUserService: AdminUserService){
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  private loadUsers(): void {
    this.adminUserService.getUsers().subscribe({
      next: (response)=> {
        this.users.set(response.data);
      },
    });
  }
}
