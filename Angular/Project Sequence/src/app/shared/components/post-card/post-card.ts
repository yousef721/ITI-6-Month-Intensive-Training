import { Component, Input } from '@angular/core';
import { Post } from '../../../core/interfaces/IPostCard';
import { PostCardImg } from './post-card-img/post-card-img';
import { PostCardContent } from './post-card-content/post-card-content';
import { PostCardActions } from './post-card-actions/post-card-actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-card',
  standalone: true,
  imports: [PostCardImg, PostCardContent, PostCardActions],
  templateUrl: './post-card.html',
  styleUrls: ['./post-card.scss'],
})
export class PostCard {
  @Input({ required: true }) post!: Post;
  @Input() layout: 'vertical' | 'horizontal' = 'vertical';

  constructor(private router: Router) {}

  goToDetails() {
    this.router.navigate(['/posts', this.post.id]);
  }
}
