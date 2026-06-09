import { Injectable } from '@angular/core';
import { POSTS } from '../data/posts.data';
import { Post } from '../interfaces/IPostCard';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private readonly STORAGE_KEY = 'posts';

  private posts: Post[] = [];

  constructor() {
    const storedPosts = localStorage.getItem(this.STORAGE_KEY);

    if (storedPosts) {
      this.posts = JSON.parse(storedPosts);
    } else {
      this.posts = POSTS;
      this.savePosts();
    }
  }

  getPosts(): Post[] {
    return this.posts;
  }

  addPost(post: Post) {
    const newPost: Post = {
      ...post,
      id: Date.now(),
    };

    this.posts.unshift(newPost);
    this.savePosts();
  }

  toggleVote(post: Post) {
    post.voted = !post.voted;
    post.upvotes += post.voted ? 1 : -1;

    this.savePosts();
  }

  toggleSave(post: Post) {
    post.saved = !post.saved;

    this.savePosts();
  }

  private savePosts() {
    localStorage.setItem(this.STORAGE_KEY, JSON.stringify(this.posts));
  }
}
