import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { CardModule } from 'primeng/card';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginOrRegisterComponent } from '../shared';
import { ToastModule } from 'primeng/toast';


@NgModule({
  declarations: [LoginComponent, RegisterComponent, HomeComponent],
  imports: [
    CommonModule,
    ButtonModule,
    FormsModule,
    LoginOrRegisterComponent,
    CardModule,
    RouterLink, 
    RouterOutlet,
    ToastModule
  ],
  exports:[LoginComponent, RegisterComponent, HomeComponent],
})
export class CoreModule { }
