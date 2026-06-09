import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PostCard } from '../../../../shared/components/post-card/post-card';
import { Post } from '../../../../core/interfaces/IPostCard';
import { PostService } from '../../../../core/services/post.service';

@Component({
  standalone: true,
  selector: 'app-post-section',
  imports: [RouterLink, PostCard],
  templateUrl: './post-section.html',
  styleUrl: './post-section.scss',
})
export class PostSection {
  posts: Post[] = [];

  constructor(private postService: PostService) {
    this.posts = this.postService.getPosts().slice(0, 3);
  }
}
