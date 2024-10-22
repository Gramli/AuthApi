import { Component, OnInit, ViewChild } from '@angular/core';
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
import { IUser, IUserInfo } from '../../shared/model/user.model';
import { Router } from '@angular/router';
import { ServiceInfoComponent } from "../service-info/service-info.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  standalone: true,
  imports: [
    AvatarModule,
    AvatarGroupModule,
    CardModule,
    ButtonModule,
    ImageModule,
    MenuModule,
    CommonModule,
    ServiceInfoComponent
],
})
export class HomeComponent implements OnInit {
  readonly HomeComponentState = HomeComponentState;

  @ViewChild('menu', { static: false }) protected menu: Menu | undefined;
  protected items: MenuItem[] | undefined;
  protected state: HomeComponentState = HomeComponentState.userInfo;

  protected userInfo: IUserInfo | undefined;

  constructor(protected userService: UserService, private router: Router){
  }

  ngOnInit(): void {
    this.loadUser();
    this.initMenu();
  }

  private initMenu() : void {
    this.items = [
      {
        label: 'Administration',
        items: [
          {
            label: 'Change role',
            icon: 'pi pi-pen-to-square',
            command: () => { this.state = HomeComponentState.changeRole},
            disabled: this.userService.loggedUser?.role !== 'administrator'
          },
          {
            label: 'Users Info',
            icon: 'pi pi-users',
            command: () => { this.state = HomeComponentState.allUsersInfo},
            disabled: this.userService.loggedUser?.role !== 'administrator' && this.userService.loggedUser?.role !== 'developer'
          },
        ],
      },
      {
        label: 'Service',
        items: [
          {
            label: 'Service Info',
            icon: 'pi pi-building-columns',
            command: () => { this.state = HomeComponentState.serviceInfo}
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
              this.state = HomeComponentState.userInfo;
              this.loadUser();
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
    ];
  }

  private loadUser(): void {
    this.userService.getUserInfo().subscribe({
      next: (response)=> {
        this.userInfo = response.data;
        console.log(this.userInfo);
      },
    });
  }
}
