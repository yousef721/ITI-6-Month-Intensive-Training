import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface Post {
  voted: boolean;
  upvotes: number;
  sourceColor: string;
  sourceInitial: string;
  sourceName: string;
  time: string;
  readTime: string;
  title: string;
  description: string;
  comments: number;
  images?: string;
}
@Component({
  selector: 'app-post-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-card.html',
  styleUrls: ['./post-card.css'],
})
export class PostCard {

  @Input() post!: Post;

  toggleVote(post: Post) {
    post.voted = !post.voted;
  }
}