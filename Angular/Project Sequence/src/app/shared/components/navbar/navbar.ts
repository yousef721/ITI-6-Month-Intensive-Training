import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.scss'],
})
export class Navbar {
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  get user() {
    return this.authService.getLoggedInUser();
  }

  logout() {
    this.authService.logout();

    this.router.navigate(['/home']);
  }
}