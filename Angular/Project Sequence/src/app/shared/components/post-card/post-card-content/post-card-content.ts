import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Post } from '../../../../core/interfaces/IPostCard';

@Component({
  selector: 'app-post-card-content',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-card-content.html',
  styleUrls: ['./post-card-content.scss'],
})
export class PostCardContent {
  @Input({ required: true }) post!: Post;

  get sourceAvatarClass(): string {
    const seed = this.post.sourceName || this.post.sourceInitial || '';
    const index = Array.from(seed).reduce((sum, c) => sum + c.charCodeAt(0), 0) % 6;
    return `app-avatar-palette-${index}`;
  }
}
