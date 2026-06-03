import { Component } from '@angular/core';
import { TopicChips } from '../../components/topic-chips/topic-chips';
import { CreatePost } from '../../components/create-post/create-post';
import { FeedHeader } from '../../components/feed-header/feed-header';
import { Post, PostCardHorizontal } from '../../components/post-card-horizontal/post-card-horizontal';

@Component({
  selector: 'app-post-list',
  imports: [TopicChips, CreatePost, FeedHeader, PostCardHorizontal],
  templateUrl: './post-list.html',
  styleUrl: './post-list.css',
})
export class PostList {
  post: Post = {} as Post;

  addPost(post: Post) {
    this.post = post;
  }
}
