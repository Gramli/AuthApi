import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { SelectModule } from 'primeng/select';
import { ButtonModule } from 'primeng/button';
import { AdminUserService, UserAuthService } from '../../shared';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { IUser } from '../../shared/model/user.model';

@Component({
    selector: 'app-change-role',
    imports: [SelectModule, FormsModule, ReactiveFormsModule, ButtonModule, ToastModule],
    templateUrl: './change-role.component.html',
    styleUrl: './change-role.component.scss'
})
export class ChangeRoleComponent implements OnInit {
  formGroup: WritableSignal<FormGroup> = signal(new FormGroup({}));
  userNames: WritableSignal<IUser[] | undefined> = signal(undefined);
  roles: WritableSignal<string[] | undefined> = signal(undefined);

  constructor(protected adminUserService: AdminUserService, private userAuthService: UserAuthService, private messageService: MessageService) {}

  ngOnInit() {
    this.formGroup.set(
      new FormGroup({
        user: new FormControl<IUser | null>(null, [Validators.required]),
        role: new FormControl<string | null>(null, [Validators.required]),
      })
    );

    this.loadUsers();
    this.loadRoles();
  }

  protected onSubmit(): void {
    const user = this.formGroup().get('user')?.value;
    const role = this.formGroup().get('role')?.value;

    if (role && user) {
      this.adminUserService.changeRole(user.id, role).subscribe({
        next: () => {
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'You are successfuly change role', life: 3000 });
        },
      });
    }
  }

  private loadUsers(): void {
    this.adminUserService.getUsers().subscribe({
      next: (response) => {
        this.userNames.set(response.data
          .filter((user) => user.username !== this.userAuthService.loggedUser?.username));
      },
    });
  }

  private loadRoles(): void {
    this.adminUserService.getRoles().subscribe({
      next: (response) => {
        this.roles.set(response.data);
      },
    });
  }
}
