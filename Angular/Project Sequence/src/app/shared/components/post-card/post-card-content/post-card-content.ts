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

}
