import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface Post {
  voted: boolean;
  upvotes: number;
  sourceColor: string;
  sourceInitial: string;
  sourceName: string;
  time: string;
  readTime: string;
  title: string;
  description: string;
  comments: number;
  images?: string;
}
@Component({
  selector: 'app-post-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-card.html',
  styleUrls: ['./post-card.css'],
})
export class PostCard implements OnChanges {
  @Input() post!: Post;

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

  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['post'].firstChange) {
      this.posts.unshift(this.post);
    }
  }

  toggleVote(post: Post) {
    post.voted = !post.voted;
  }
}
