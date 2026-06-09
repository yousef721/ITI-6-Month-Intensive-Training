import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) return;

    const { email, password } = this.form.value;

    const user = this.authService.login(email, password);

    if (user) {
      this.router.navigate(['/home']);
    } else {
      alert('Invalid credentials');
    }
  }
}
