import { Component } from '@angular/core';
import { TopicChips } from '../../components/topic-chips/topic-chips';
import { CreatePost } from '../../components/create-post/create-post';
import { FeedHeader } from '../../components/feed-header/feed-header';
// import { PostCardHorizontal } from '../../components/post-card/post-card-horizontal/post-card-horizontal';
import { LeftSidebar } from '../../components/left-sidebar/left-sidebar';
import { RightSidebar } from '../../components/right-sidebar/right-sidebar';
import { PostService } from '../../services/postService';
import { Post } from '../../interfaces/IPostCard';
import { PostCard } from '../../components/post-card/post-card';

@Component({
  selector: 'app-post-list',
  imports: [TopicChips, CreatePost, FeedHeader, LeftSidebar, RightSidebar, PostCard],
  templateUrl: './post-list.html',
  styleUrl: './post-list.css',
})
export class PostList {
  posts: Post[] = [];

  constructor(private postService: PostService) {
    this.posts = this.postService.getPosts();
  }

  addPost(post: Post) {
    this.postService.addPost(post);
  }
}
