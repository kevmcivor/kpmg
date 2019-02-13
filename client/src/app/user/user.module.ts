import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'auth-callback', component: AuthCallbackComponent }
];

@NgModule({
  declarations: [LoginComponent, AuthCallbackComponent],
  imports: [
    CommonModule,
    [RouterModule.forChild(routes)]
  ],
  exports: [LoginComponent]
})
export class UserModule { }
