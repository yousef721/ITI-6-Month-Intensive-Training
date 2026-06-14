import { Component, inject, Input } from '@angular/core';
import { Post } from '../../../../core/interfaces/IPostCard';
import { PostService } from '../../../../core/services/post.service';

@Component({
  selector: 'app-post-card-actions',
  standalone: true,
  imports: [],
  templateUrl: './post-card-actions.html',
  styleUrls: ['./post-card-actions.scss'],
})
export class PostCardActions {
  @Input() post!: Post;
  @Input() layout: 'horizontal' | 'vertical' = 'horizontal';

  postService = inject(PostService);

  toggleVote() {
    this.postService.toggleVote(this.post).subscribe({
      next: (updatedPost) => {
        this.post = updatedPost;
      },
      error: (err) => {
        console.error('Failed to vote', err);
      },
    });
  }

  toggleSave() {
    this.postService.toggleSave(this.post).subscribe({
      next: (updatedPost) => {
        this.post = updatedPost;
      },
      error: (err) => {
        console.error('Failed to save post', err);
      },
    });
  }
}
