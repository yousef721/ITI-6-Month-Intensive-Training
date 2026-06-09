import { Component, Input } from '@angular/core';
import { IUser } from '../../../core/interfaces/IUser';

@Component({
  standalone: true,
  selector: 'app-user-card',
  imports: [],
  templateUrl: './user-card.html',
  styleUrl: './user-card.scss',
})
export class UserCard {
  @Input({ required: true }) user!: IUser;
}
