import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './home/login/login.component';
import {HomeComponent} from './home/home/home.component';
import {
  AuthGuardService as AuthGuard
} from './_services/auth-guard.service';
import {RegisterComponent} from './home/register/register.component';
const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'admin', loadChildren: ()=> import('./admin/admin.module').then(m => m.AdminModule),canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
