import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Post } from '../../../interfaces/IPostCard';

@Component({
  selector: 'app-post-card-actions',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-card-actions.html',
  styleUrls: ['./post-card-actions.css'],
})
export class PostCardActions {
  @Input() post!: Post;

  @Input() layout: 'horizontal' | 'vertical' = 'horizontal';

  get firstTwoTags(): string[] {
    return this.post.hashtags?.slice(0, 2) ?? [];
  }

  toggleVote() {
    this.post.voted = !this.post.voted;
    this.post.upvotes += this.post.voted ? 1 : -1;
  }

  toggleSave() {
    this.post.saved = !this.post.saved;
  }
}
