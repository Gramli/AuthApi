import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { ImageModule } from 'primeng/image';
import { MenuModule } from 'primeng/menu';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  standalone: true,
  imports: [AvatarModule, AvatarGroupModule, CardModule, ButtonModule, ImageModule, MenuModule  ]
})
export class HomeComponent  implements OnInit {
  items: MenuItem[] | undefined;

  ngOnInit(): void {
    this.items = [
      { label: 'New', icon: 'pi pi-plus' },
      { label: 'Search', icon: 'pi pi-search' }
    ];
  }
}
