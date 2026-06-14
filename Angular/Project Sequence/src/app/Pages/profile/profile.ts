import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { IUser } from '../../core/interfaces/IUser';
import { AuthService } from '../../core/services/auth.service';
import { UserCard } from '../../shared/components/user-card/user-card';
import { StatsCard } from '../../shared/components/stats-card/stats-card';
import { PostService } from '../../core/services/post.service';
import { Post } from '../../core/interfaces/IPostCard';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule, UserCard, StatsCard],
  templateUrl: './profile.html',
  styleUrls: ['./profile.scss'],
})

export class Profile implements OnInit {
  currentUser!: IUser;

  settings = {
    displayName: '',
    email: '',
    bio: '',
  };

  myPosts: Post[] = [];
  savedPosts: Post[] = [];
  allPosts: Post[] = [];

  constructor(
    private authService: AuthService,
    private postService: PostService,
    private router: Router
  ) { }

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
    this.postService.getPosts().subscribe({
      next: (posts) => {
        this.allPosts = posts;
        this.myPosts = posts.filter(
          (post) => String(post.userId) === String(this.currentUser.id)
        );
        this.savedPosts = posts.filter((post) => post.saved);
        this.calculateStats();
      },
    });
  }
  stats = {
    postsSaved: '0',
    upvotesGiven: '0',
    comments: '0',
  };

  calculateStats() {
    this.stats = {
      postsSaved: this.allPosts
        .filter((p) => p.saved)
        .length
        .toString(),

      upvotesGiven: this.allPosts
        .filter((p) => p.voted)
        .length
        .toString(),

      comments: this.allPosts
        .reduce((sum, p) => sum + p.commentsCount, 0)
        .toString(),
    };
  }

  goToDetails(postId?: number) {
    if (!postId) return;

    this.router.navigate(['/posts', postId]);
  }

  saveProfile() {
    const updatedUser = {
      ...this.currentUser,
      name: this.settings.displayName,
      email: this.settings.email,
      bio: this.settings.bio,
    };

    this.authService.updateUser(updatedUser);

    this.currentUser = updatedUser;

    alert('Profile updated successfully');
  }
}