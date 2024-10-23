import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { IUserInfo } from '../../shared/model/user.model';
import { UserService } from '../../shared';

@Component({
  selector: 'app-user-info',
  standalone: true,
  imports: [],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.scss'
})
export class UserInfoComponent implements OnInit {
  protected userInfo: WritableSignal<IUserInfo | undefined> = signal(undefined);

  constructor(protected userService: UserService){
  }

  ngOnInit(): void {
    this.loadUser();
  }

  private loadUser(): void {
    this.userService.getUserInfo().subscribe({
      next: (response)=> {
        this.userInfo.set(response.data);
        console.log(this.userInfo);
      },
    });
  }
}
