import { Component } from '@angular/core';
// import { PostCardVertical } from '../../../../components/post-card/post-card-vertical/post-card-vertical';
import { TopicChips } from '../../../../components/topic-chips/topic-chips';
import { RouterLink } from '@angular/router';
import { PostCard } from '../../../../components/post-card/post-card';
import { Post } from '../../../../interfaces/IPostCard';
import { PostService } from '../../../../services/postService';

@Component({
  selector: 'app-post-section',
  imports: [TopicChips, RouterLink, PostCard],
  templateUrl: './post-section.html',
  styleUrl: './post-section.css',
})
export class PostSection {
  posts: Post[] = [];

  constructor(private postService: PostService) {
    this.posts = this.postService.getPosts();
  }
}
