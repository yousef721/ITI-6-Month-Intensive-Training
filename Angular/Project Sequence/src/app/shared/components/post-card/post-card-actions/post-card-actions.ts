import { Component, Input } from '@angular/core';
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

  constructor(private postService: PostService) {}

  toggleVote() {
    this.postService.toggleVote(this.post);
  }

  toggleSave() {
    this.postService.toggleSave(this.post);
  }
}
