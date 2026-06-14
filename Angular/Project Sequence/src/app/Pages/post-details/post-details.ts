import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { Post } from '../../core/interfaces/IPostCard';
import { PostService } from '../../core/services/post.service';
import { CategoryService } from '../../core/services/category.service';
import { ICategory } from '../../core/interfaces/ICategory';

@Component({
  standalone: true,
  selector: 'app-post-details',
  imports: [RouterLink, FormsModule],
  templateUrl: './post-details.html',
  styleUrl: './post-details.scss',
})
export class PostDetails implements OnInit {
  post: Post | undefined;
  relatedPosts: Post[] = [];
  categories: ICategory[] = [];
  newComment = '';

  constructor(
    private route: ActivatedRoute,
    private postService: PostService,
    private categoryService: CategoryService,
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');

      this.postService.getPosts().subscribe({
        next: (posts) => {
          this.post = posts.find(p => String(p.id) === String(id));

          if (!this.post) return;

          this.relatedPosts = posts
            .filter(p => String(p.id) !== String(this.post!.id))
            .slice(0, 3);
        }
      });
    });

    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
      }
    });
  }

  toggleVote() {
    if (!this.post) return;

    this.postService.toggleVote(this.post).subscribe({
      next: (updated) => {
        this.post = updated;
      }
    });
  }

  toggleSave() {
    if (!this.post) return;

    this.postService.toggleSave(this.post).subscribe({
      next: (updated) => {
        this.post = updated;
      }
    });
  }

  submitComment() {
    if (!this.newComment.trim() || !this.post) return;

    const updatedPost: Post = {
      ...this.post,
      comments: [
        {
          id: Date.now(),
          author: 'You',
          content: this.newComment.trim(),
          createdAt: 'Just now',
        },
        ...this.post.comments,
      ],
      commentsCount: this.post.commentsCount + 1,
    };

    this.postService.updatePost(updatedPost).subscribe({
      next: (updated) => {
        this.post = updated;
        this.newComment = '';
      }
    });
  }
}