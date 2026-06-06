import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Post } from '../../../interfaces/IPostCard';

@Component({
  selector: 'app-post-card-content',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-card-content.html',
  styleUrls: ['./post-card-content.css'],
})
export class PostCardContent {
  @Input({ required: true }) post!: Post;
  
}
