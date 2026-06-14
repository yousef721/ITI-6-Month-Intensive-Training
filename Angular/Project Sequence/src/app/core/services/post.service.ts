import { inject, Injectable } from '@angular/core';
import { Post } from '../interfaces/IPostCard';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class PostService {
  private http = inject(HttpClient)
  private apiUrl = 'http://localhost:3000/posts';

  getPosts() {
    return this.http.get<Post[]>(this.apiUrl);
  }

  addPost(post: Post) {
    return this.http.post<Post>(this.apiUrl, post);
  }

  updatePost(post: Post) {
    return this.http.put<Post>(`${this.apiUrl}/${post.id}`, post);
  }

  toggleVote(post: Post) {
    const updatedPost = {
      ...post,
      voted: !post.voted,
      upvotes: post.voted
        ? post.upvotes - 1
        : post.upvotes + 1,
    };

    return this.http.put<Post>(`${this.apiUrl}/${post.id}`, updatedPost);
  }

  toggleSave(post: Post) {
    const updatedPost = {
      ...post,
      saved: !post.saved,
    };

    return this.http.put<Post>(`${this.apiUrl}/${post.id}`, updatedPost);
  }

  deletePost(id: number) {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
