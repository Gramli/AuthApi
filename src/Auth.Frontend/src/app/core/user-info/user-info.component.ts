import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { IUserInfo } from '../../shared/model/user.model';
import { UserAuthService } from '../../shared';

@Component({
    selector: 'app-user-info',
    imports: [],
    templateUrl: './user-info.component.html',
    styleUrl: './user-info.component.scss'
})
export class UserInfoComponent implements OnInit {
  protected userInfo: WritableSignal<IUserInfo | undefined> = signal(undefined);

  constructor(protected userAuthService: UserAuthService){
  }

  ngOnInit(): void {
    this.loadUser();
  }

  private loadUser(): void {
    this.userAuthService.getUserInfo().subscribe({
      next: (response)=> {
        this.userInfo.set(response.data);
      },
    });
  }
}
