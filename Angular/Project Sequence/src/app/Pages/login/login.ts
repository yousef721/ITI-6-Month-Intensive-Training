import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  form: FormGroup;
  submitted = false;
  loginError = false;
  loading = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      rememberMe: [false],
    });
  }

  get email() {
    return this.form.get('email')!;
  }

  get password() {
    return this.form.get('password')!;
  }

  get rememberMe() {
    return this.form.get('rememberMe')!;
  }

  onSubmit() {
    this.submitted = true;
    this.loginError = false;

    if (this.form.invalid) return;

    this.loading = true;

    const { email, password, rememberMe } = this.form.value;

    const user = this.authService.login(email, password);

    this.loading = false;

    if (user) {
      const storage = rememberMe ? localStorage : sessionStorage;

      storage.setItem('loggedInUser', JSON.stringify(user));

      this.router.navigate(['/home']);
    } else {
      this.loginError = true;
    }
  }
}