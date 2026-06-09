import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Post } from '../../core/interfaces/IPostCard';
import { PostService } from '../../core/services/post.service';
import { FormsModule } from '@angular/forms';

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
  newComment = '';

  constructor(
    private route: ActivatedRoute,
    private postService: PostService,
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    const allPosts = this.postService.getPosts();
    this.post = allPosts.find((p) => p.id === id) ?? allPosts[0];
    // Related = other posts, max 3
    this.relatedPosts = allPosts.filter((p) => p.id !== this.post?.id).slice(0, 3);
  }

  toggleVote() {
    if (this.post) this.postService.toggleVote(this.post);
  }

  toggleSave() {
    if (this.post) this.postService.toggleSave(this.post);
  }

  submitComment() {
    if (!this.newComment.trim() || !this.post) return;
    this.post.comments.unshift({
      id: Date.now(),
      author: 'You',
      content: this.newComment.trim(),
      createdAt: 'Just now',
    });
    this.post.commentsCount++;
    this.newComment = '';
  }
}
