import { Component } from '@angular/core';
import { TopicChips } from '../../shared/components/topic-chips/topic-chips';
import { CreatePost } from '../../shared/components/create-post/create-post';
import { FeedHeader } from '../../shared/components/feed-header/feed-header';
import { LeftSidebar } from '../../shared/components/left-sidebar/left-sidebar';
import { RightSidebar } from '../../shared/components/right-sidebar/right-sidebar';
import { PostCard } from '../../shared/components/post-card/post-card';
import { PostService } from '../../core/services/post.service';
import { Post } from '../../core/interfaces/IPostCard';

@Component({
  standalone: true,
  selector: 'app-post-list',
  imports: [TopicChips, CreatePost, FeedHeader, LeftSidebar, RightSidebar, PostCard],
  templateUrl: './post-list.html',
  styleUrl: './post-list.scss',
})
export class PostList {
  private allPosts: Post[] = [];
  posts: Post[] = [];

  searchQuery = '';
  currentSort = 'Latest';

  constructor(private postService: PostService) {
    this.allPosts = this.postService.getPosts();
    this.posts = [...this.allPosts];
  }

  onSearch(query: string) {
    this.searchQuery = query;
    this.applyFilters();
  }

  onSort(sort: string) {
    this.currentSort = sort;
    this.applyFilters();
  }

  addPost(post: Post) {
    this.postService.addPost(post);
    this.allPosts = this.postService.getPosts();
    this.applyFilters();
  }

  private applyFilters() {
    let filtered = [...this.allPosts];

    // Search filter
    if (this.searchQuery.trim()) {
      const q = this.searchQuery.toLowerCase();
      filtered = filtered.filter(
        (p) =>
          p.title.toLowerCase().includes(q) ||
          p.description.toLowerCase().includes(q) ||
          p.hashtags?.some((t) => t.toLowerCase().includes(q)),
      );
    }

    // Sort
    switch (this.currentSort) {
      case 'Top Rated':
        filtered.sort((a, b) => b.upvotes - a.upvotes);
        break;
      case 'Most Discussed':
        filtered.sort((a, b) => b.commentsCount - a.commentsCount);
        break;
      default:
        break;
    }

    this.posts = filtered;
  }
}
