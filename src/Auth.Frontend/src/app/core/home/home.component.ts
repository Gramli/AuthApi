import {
  Component,
  OnInit,
  signal,
  ViewChild,
  WritableSignal,
  ChangeDetectionStrategy
} from '@angular/core';
import { MenuItem } from '@openng/optimus-ui/api';
import { AvatarModule } from '@openng/optimus-ui/avatar';
import { AvatarGroupModule } from '@openng/optimus-ui/avatargroup';
import { ButtonModule } from '@openng/optimus-ui/button';
import { CardModule } from '@openng/optimus-ui/card';
import { ImageModule } from '@openng/optimus-ui/image';
import { Menu, MenuModule } from '@openng/optimus-ui/menu';
import { HomeComponentState } from './model';

import { Router } from '@angular/router';
import { ServiceInfoComponent } from '../service-info/service-info.component';
import { UserInfoComponent } from '../user-info/user-info.component';
import { UsersInfoComponent } from '../users-info/users-info.component';
import { ChangeRoleComponent } from '../change-role/change-role.component';
import { IUser } from '../../shared/model/user.model';
import { UserAuthService } from '../../shared';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss',
    changeDetection: ChangeDetectionStrategy.Eager,
    imports: [
    AvatarModule,
    AvatarGroupModule,
    CardModule,
    ButtonModule,
    ImageModule,
    MenuModule,
    ServiceInfoComponent,
    UserInfoComponent,
    UsersInfoComponent,
    ChangeRoleComponent
]
})
export class HomeComponent implements OnInit {
  readonly HomeComponentState = HomeComponentState;

  @ViewChild('menu', { static: false }) protected menu: Menu | undefined;
  protected items: WritableSignal<MenuItem[] | undefined> = signal(undefined);
  protected state: WritableSignal<HomeComponentState> = signal(
    HomeComponentState.userInfo
  );

  constructor(private userAuthService: UserAuthService, private router: Router) {}

  ngOnInit(): void {
    const loggedUser = this.userAuthService.loggedUser;
    if (loggedUser) {
      this.initMenu(loggedUser);
    }
  }

  private initMenu(user: IUser): void {
    this.items.set([
      {
        label: 'Administration',
        items: [
          {
            label: 'Change role',
            icon: 'pi pi-pen-to-square',
            command: () => {
              this.state.set(HomeComponentState.changeRole);
            },
            disabled: user.role !== 'administrator',
          },
          {
            label: 'Users Info',
            icon: 'pi pi-users',
            command: () => {
              this.state.set(HomeComponentState.allUsersInfo);
            },
            disabled:
              user.role !== 'administrator' && user.role !== 'developer',
          },
        ],
      },
      {
        label: 'Service',
        items: [
          {
            label: 'Service Info',
            icon: 'pi pi-building-columns',
            command: () => {
              this.state.set(HomeComponentState.serviceInfo);
            },
          },
        ],
      },
      {
        label: 'Profile',
        id: 'profile',
        items: [
          {
            id: 'info',
            label: 'Info',
            icon: 'pi pi-user',
            command: () => {
              this.state.set(HomeComponentState.userInfo);
            },
          },
          {
            label: 'Logout',
            icon: 'pi pi-sign-out',
            command: () => {
              this.userAuthService.logout();
              this.router.navigate(['/login']);
            },
          },
        ],
      },
    ]);
  }
}
