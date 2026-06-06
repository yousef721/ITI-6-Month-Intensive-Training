export interface Comment {
  id: number;
  author: string;
  content: string;
  createdAt: string;
}

export interface Post {
  id: number;

  voted: boolean;
  saved: boolean;

  upvotes: number;

  sourceColor: string;
  sourceInitial: string;
  sourceName: string;

  time: string;
  readTime: string;

  title: string;
  description: string;

  commentsCount: number;
  comments: Comment[];

  image: string;

  hashtags: string[];
}
