import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryBar } from '../categorybar/categorybar';
import { Form } from '../form/form';
import { Post, PostCard } from '../post-card/post-card';
import { FeedHeader } from '../feed-header/feed-header';

@Component({
  selector: 'app-main-feed',
  standalone: true,
  imports: [CommonModule, CategoryBar, Form, FeedHeader, PostCard],
  templateUrl: './main-feed.html',
  styleUrls: ['./main-feed.css'],
})
export class MainFeed {

  post: Post = {} as Post;

  addPost(post: Post) {
    this.post = post;
  }
}
