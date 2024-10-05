import { Routes } from '@angular/router';
import { AuthorizeGuard } from './shared/guards/authorize.guard';
import { HomeComponent, LoginComponent, RegisterComponent } from './core';

export const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthorizeGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];
