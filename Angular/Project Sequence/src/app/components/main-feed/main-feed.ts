import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryBar } from '../categorybar/categorybar';
import { Form } from '../form/form';
import { Post, PostCard } from '../post-card/post-card';
import { FeedHeader } from '../feed-header/feed-header';

@Component({
  selector: 'app-main-feed',
  standalone: true,
  imports: [CommonModule, CategoryBar, Form, FeedHeader, PostCard],
  templateUrl: './main-feed.html',
  styleUrls: ['./main-feed.css'],
})
export class MainFeed {

  posts: Post[] = [
    {
      voted: false,
      upvotes: 342,
      sourceColor: '#000',
      sourceInitial: 'V',
      sourceName: 'Vercel Blog',
      time: '2h ago',
      readTime: '4 min read',
      title: 'Next.js 15.3 Released',
      description: 'Turbopack is now production-ready.',
      comments: 48,
      images: 'https://picsum.photos/160/128?random=11',
    },
    {
      voted: false,
      upvotes: 218,
      sourceColor: '#4285F4',
      sourceInitial: 'G',
      sourceName: 'Google Engineering',
      time: '4h ago',
      readTime: '6 min read',
      title: 'Kubernetes Optimization',
      description: 'Google reduced latency by 40%',
      comments: 31,
      images: 'https://picsum.photos/160/128?random=22',
    },
  ];

  addPost($event: Post) {
    this.posts.unshift($event);
  }
}
