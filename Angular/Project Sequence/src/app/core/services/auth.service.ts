import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../interfaces/IUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:3000/users';

  private users: IUser[] = [];

  private loggedUser: IUser | null = null;

  constructor() {
    this.loadUsers();
  }

  loadUsers(): void {
    this.http.get<IUser[]>(this.apiUrl).subscribe({
      next: (data) => {
        this.users = data;
      },
    });

    const stored = localStorage.getItem('loggedInUser');
    if (stored) {
      this.loggedUser = JSON.parse(stored);
    }
  }

  register(user: IUser): IUser | null {
    const newUser = {
      ...user,
      id: Date.now(),
    };

    this.http.post<IUser>(this.apiUrl, newUser).subscribe({
      next: (created) => {
        this.users.push(created);
        this.loggedUser = created;

        localStorage.setItem(
          'loggedInUser',
          JSON.stringify(created)
        );
      },
    });

    return newUser;
  }

  login(email: string, password: string) {
    const user = this.users.find(
      (u) => u.email === email && u.password === password
    );

    if (!user) return null;

    this.loggedUser = user;

    localStorage.setItem('loggedInUser', JSON.stringify(user));

    return user;
  }

  getLoggedInUser() {
    return this.loggedUser;
  }

  logout(): void {
    this.loggedUser = null;
    localStorage.removeItem('loggedInUser');
  }

  updateUser(user: IUser) {
    this.loggedUser = user;

    localStorage.setItem(
      'loggedInUser',
      JSON.stringify(user)
    );
  }
}