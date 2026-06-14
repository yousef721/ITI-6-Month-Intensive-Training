import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PostCard } from '../../../../shared/components/post-card/post-card';
import { Post } from '../../../../core/interfaces/IPostCard';
import { PostService } from '../../../../core/services/post.service';
import { SectionTitle } from '../../../../shared/components/section-title/section-title';

@Component({
  standalone: true,
  selector: 'app-post-section',
  imports: [RouterLink, PostCard, SectionTitle],
  templateUrl: './post-section.html',
  styleUrl: './post-section.scss',
})
export class PostSection {
  posts: Post[] = [];

  postService = inject(PostService);

  ngOnInit() {
    this.postService.getPosts().subscribe({
      next: (posts) => {
        this.posts = posts.slice(0, 3);
      }
    });
  }
}
