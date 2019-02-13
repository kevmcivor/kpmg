import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, WebStorageStateStore, User } from 'oidc-client';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _userManager ;
  private _user: User = null;

  constructor() {
    this._userManager = new UserManager(getClientSettings());
    this._userManager.getUser().then(user => {
      if (user && ! user.expired) {
        this._user = user;
      }
    });
    this._userManager.events.addUserLoaded(args => {
      this._userManager.getUser().then(user => {
        this._user = user;
      });
    });
  }

  isLoggedIn(): boolean {
    return this._user && this._user.access_token && !this._user.expired;
  }

  isAdmin(): boolean {
    return this.isLoggedIn() && this.getClaims().role === 'Admin';
  }

  isEmployee(): boolean {
    return this.isLoggedIn() && this.getClaims().role === 'Employee';
  }

  getClaims(): any {
    return this._user.profile;
  }

  getAuthorizationHeaderValue(): string {
    return `${this._user.token_type} ${this._user.access_token}`;
  }

  login(): Promise<void> {
    return this._userManager.signinRedirect();
  }

  logout(): Promise<any> {
    return this._userManager.signoutRedirect();
  }

  getAccessToken(): string {
    return this._user ? this._user.access_token : '';
  }

  async completeAuthentication(): Promise<void> {
    const user = await this._userManager.signinRedirectCallback();
    this._user = user;
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: Constants.StsAuthority,
    client_id: Constants.ClientId,
    redirect_uri: Constants.AuthRedirectUri,
    post_logout_redirect_uri: Constants.LogoutRedirectUri,
    userStore: new WebStorageStateStore({ store: window.localStorage }),
    response_type: 'code',
    scope: 'openid profile api1',
    filterProtocolClaims: true,
    loadUserInfo: true
  };
}
