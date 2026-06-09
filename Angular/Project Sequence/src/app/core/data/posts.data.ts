import { Post } from '../interfaces/IPostCard';

export const POSTS: Post[] = [
  {
    id: 1,
    voted: false,
    saved: false,

    upvotes: 342,

    sourceColor: '#000',
    sourceInitial: 'V',
    sourceName: 'Vercel Blog',

    time: '2h ago',
    readTime: '4 min read',

    title: 'Next.js 15.3 Released',
    description: 'Turbopack is now production-ready, bringing massive build speed improvements.',

    commentsCount: 2,

    comments: [
      {
        id: 1,
        author: 'Ahmed',
        content: 'Amazing update!',
        createdAt: '1 hour ago',
      },
      {
        id: 2,
        author: 'Sara',
        content: 'Build speed is crazy now.',
        createdAt: '45 min ago',
      },
    ],

    image: 'images/post-1.jpeg',

    hashtags: ['webdev', 'nextjs', 'frontend'],
  },

  {
    id: 2,
    voted: true,
    saved: true,

    upvotes: 218,

    sourceColor: '#4285F4',
    sourceInitial: 'G',
    sourceName: 'Google Engineering',

    time: '4h ago',
    readTime: '6 min read',

    title: 'Kubernetes Optimization Guide',
    description: 'Google reduced latency by 40% using new scheduling algorithms.',

    commentsCount: 1,

    comments: [
      {
        id: 1,
        author: 'Mohamed',
        content: 'Very useful article.',
        createdAt: '30 min ago',
      },
    ],

    image: 'images/post-2.jpeg',

    hashtags: ['kubernetes', 'cloud', 'devops'],
  },
];
