import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { IUser } from '../../core/interfaces/IUser';
import { AuthService } from '../../core/services/auth.service';
import { UserCard } from '../../shared/components/user-card/user-card';
import { POSTS } from '../../core/data/posts.data';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule, UserCard],
  templateUrl: './profile.html',
  styleUrls: ['./profile.scss'],
})

export class Profile implements OnInit {
  currentUser!: IUser;

  myPosts = POSTS;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    const user = this.authService.getLoggedInUser();

    if (!user) {
      this.router.navigate(['/login']);
      return;
    }

    this.currentUser = user;

    this.settings = {
      displayName: user.name,
      email: user.email,
      bio: user.bio,
    };
  }

  stats = {
    postsSaved: POSTS.filter((p) => p.saved).length,
    upvotesGiven: POSTS.reduce((sum, p) => sum + p.upvotes, 0),
    comments: POSTS.reduce((sum, p) => sum + p.commentsCount, 0),
  };

  settings = {
    displayName: '',
    email: '',
    bio: '',
  };

  saveProfile() {
    const updatedUser = {
      ...this.currentUser,
      name: this.settings.displayName,
      email: this.settings.email,
      bio: this.settings.bio,
    };
  
    localStorage.setItem(
      'loggedInUser',
      JSON.stringify(updatedUser)
    );
  
    localStorage.setItem(
      'user',
      JSON.stringify(updatedUser)
    );
  
    this.currentUser = updatedUser;
  
    alert('Profile updated successfully');
  }
}
