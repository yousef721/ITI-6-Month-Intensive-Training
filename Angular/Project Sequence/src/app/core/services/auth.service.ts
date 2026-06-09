import { Injectable } from '@angular/core';
import { IUser } from '../interfaces/IUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private USER_KEY = 'user';
  private LOGGED_IN_USER = 'loggedInUser';

  saveUser(user: IUser): void {
    localStorage.setItem(this.USER_KEY, JSON.stringify(user));
  }

  getUser(): IUser | null {
    const data = localStorage.getItem(this.USER_KEY);
    return data ? JSON.parse(data) : null;
  }

  login(email: string, password: string): IUser | null {
    const user = this.getUser();

    if (!user) return null;

    if (user.email === email && user.password === password) {
      localStorage.setItem(this.LOGGED_IN_USER, JSON.stringify(user));
      return user;
    }

    return null;
  }

  getLoggedInUser(): IUser | null {
    const data = localStorage.getItem(this.LOGGED_IN_USER);
    return data ? JSON.parse(data) : null;
  }

  isLoggedIn(): boolean {
    return !!this.getLoggedInUser();
  }

  logout(): void {
    localStorage.removeItem(this.LOGGED_IN_USER);
  }
}
