import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Post } from '../../interfaces/IPostCard';
import { PostCardImg } from './post-card-img/post-card-img';
import { PostCardContent } from './post-card-content/post-card-content';
import { PostCardActions } from './post-card-actions/post-card-actions';

@Component({
  selector: 'app-post-card',
  standalone: true,
  imports: [CommonModule, PostCardImg, PostCardContent, PostCardActions],
  templateUrl: './post-card.html',
  styleUrls: ['./post-card.css'],
})
export class PostCard {
  @Input({ required: true }) post!: Post;

  @Input() layout: 'vertical' | 'horizontal' = 'vertical';
}
