import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IUser } from '../../../core/interfaces/IUser';

@Component({
  selector: 'app-left-sidebar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './left-sidebar.html',
  styleUrls: ['./left-sidebar.scss'],
})
export class LeftSidebar {

  @Input() user!: IUser;

  menuItems = [
    { name: 'My Feed', icon: '🏠', count: 12 },
    { name: 'Popular', icon: '🔥' },
    { name: 'Most Upvoted', icon: '⚡' },
    { name: 'Bookmarks', icon: '🔖' },
  ];

  topics = [
    { name: 'Dev News', icon: '📰', count: 12 },
    { name: 'AI', icon: '🤖', count: 8 },
    { name: 'Frontend', icon: '🖥️', count: 15 },
    { name: 'Backend', icon: '⚙️', count: 6 },
  ];

  activeItem = '';

  setActive(name: string) {
    this.activeItem = name;
  }
}