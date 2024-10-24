import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { UserService } from '../../shared';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-change-role',
  standalone: true,
  imports: [DropdownModule, FormsModule, ReactiveFormsModule, ButtonModule, ToastModule],
  templateUrl: './change-role.component.html',
  styleUrl: './change-role.component.scss',
})
export class ChangeRoleComponent implements OnInit {
  formGroup: WritableSignal<FormGroup> = signal(new FormGroup({}));
  userNames: WritableSignal<string[] | undefined> = signal(undefined);
  roles: WritableSignal<string[]> = signal([
    'user',
    'developer',
    'administrator',
  ]);

  constructor(protected userService: UserService, private messageService: MessageService) {}

  ngOnInit() {
    this.formGroup.set(
      new FormGroup({
        userName: new FormControl<string | null>(null, [Validators.required]),
        role: new FormControl<string | null>(null, [Validators.required]),
      })
    );

    this.loadUsers();
  }

  protected onSubmit(): void {
    const userName = this.formGroup().get('userName')?.value;
    const role = this.formGroup().get('role')?.value;
    if (role && userName) {
      this.userService.changeRole(userName, role).subscribe({
        next: (response) => {
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'You are successfuly change role', life: 3000 });
        },
      });
    }
  }

  private loadUsers(): void {
    this.userService.getUsersInfo().subscribe({
      next: (response) => {
        this.userNames.set(response.data
          .filter((user) => user.username !== this.userService.loggedUser?.username)
          .map((user) => user.username));
      },
    });
  }
}
