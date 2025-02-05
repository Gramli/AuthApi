import {
  Component,
  OnInit,
  signal,
  ViewChild,
  WritableSignal,
} from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { ImageModule } from 'primeng/image';
import { Menu, MenuModule } from 'primeng/menu';
import { HomeComponentState } from './model';
import { CommonModule } from '@angular/common';
import { UserService } from '../../shared';
import { Router } from '@angular/router';
import { ServiceInfoComponent } from '../service-info/service-info.component';
import { UserInfoComponent } from '../user-info/user-info.component';
import { UsersInfoComponent } from '../users-info/users-info.component';
import { ChangeRoleComponent } from '../change-role/change-role.component';
import { IUser } from '../../shared/model/user.model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss',
    imports: [
        AvatarModule,
        AvatarGroupModule,
        CardModule,
        ButtonModule,
        ImageModule,
        MenuModule,
        CommonModule,
        ServiceInfoComponent,
        UserInfoComponent,
        UsersInfoComponent,
        ChangeRoleComponent,
    ]
})
export class HomeComponent implements OnInit {
  readonly HomeComponentState = HomeComponentState;

  @ViewChild('menu', { static: false }) protected menu: Menu | undefined;
  protected items: WritableSignal<MenuItem[] | undefined> = signal(undefined);
  protected state: WritableSignal<HomeComponentState> = signal(
    HomeComponentState.userInfo
  );

  constructor(protected userService: UserService, private router: Router) {}

  ngOnInit(): void {
    const loggedUser = this.userService.loggedUser;
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
              this.userService.logout();
              this.router.navigate(['/login']);
            },
          },
        ],
      },
    ]);
  }
}
