import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';
import { IUser } from '../../core/interfaces/IUser';

@Component({
  standalone: true,
  selector: 'app-signup',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './signup.html',
  styleUrl: './signup.scss',
})
export class Signup {
  form: FormGroup;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(/^(?=.*[A-Z])(?=.*\d).+$/),
        ],
      ],
      terms: [false, Validators.requiredTrue],
    });
  }

  get name() {
    return this.form.get('name')!;
  }

  get email() {
    return this.form.get('email')!;
  }

  get password() {
    return this.form.get('password')!;
  }

  get terms() {
    return this.form.get('terms')!;
  }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) return;

    const value = this.form.value;

    const user: IUser = {
      name: value.name,
      email: value.email,
      password: value.password,
      avatarInitial: value.name.charAt(0).toUpperCase(),
      bio: 'New member',
      badges: ['🚀 New User'],
    };

    this.authService.saveUser(user);

    this.authService.login(value.email, value.password);

    this.router.navigate(['/home']);
  }
}
