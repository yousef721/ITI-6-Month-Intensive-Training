import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { Post } from '../../interfaces/IPostCard';
import { CATEGORIES } from '../../data/categoriesData';

@Component({
  selector: 'app-create-post',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './create-post.html',
  styleUrls: ['./create-post.css'],
})
export class CreatePost {
  @Output() postCreated = new EventEmitter<Post>();

  categories = CATEGORIES;
  expanded = false;
  selectedImage = '';
  justPublished = false;
  imageError = false;
  fileInputRef: HTMLInputElement | null = null;

  get f() {
    return this.postForm.controls;
  }

  postForm: FormGroup = new FormGroup({
    sourceName: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(50),
    ]),
    title: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
      Validators.maxLength(100),
    ]),
    url: new FormControl('', [Validators.pattern(/^(https?:\/\/)?([\w\-])+(\.[\w\-]+)+[/#?]?.*$/)]),
    description: new FormControl('', [
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(200),
    ]),
    category: new FormControl(null, Validators.required),
  });

  onTriggerFocus() {
    this.expanded = true;
  }

  onImageSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    this.fileInputRef = input;
    if (!input.files?.length) return;
    const reader = new FileReader();
    reader.onload = () => {
      this.selectedImage = reader.result as string;
      this.imageError = false;
    };
    reader.readAsDataURL(input.files[0]);
  }

  private randomColor(): string {
    const colors = ['#000000', '#4285F4', '#FF5722', '#9C27B0', '#4CAF50', '#FF9800'];
    return colors[Math.floor(Math.random() * colors.length)];
  }

  private randomUpvotes = () => Math.floor(Math.random() * 500);
  private randomComments = () => Math.floor(Math.random() * 100);
  private randomReadTime = () => `${Math.floor(Math.random() * 10) + 1} min read`;
  private randomTime = () =>
    ['just now', '5m ago', '10m ago', '1h ago', '3h ago'][Math.floor(Math.random() * 5)];

  publish() {
    if (!this.selectedImage) {
      this.imageError = true;
    }

    if (this.postForm.invalid || !this.selectedImage) {
      this.postForm.markAllAsTouched();
      return;
    }

    const value = this.postForm.value;

    const newPost: Post = {
      id: Date.now(),
      voted: false,
      saved: false,
      upvotes: this.randomUpvotes(),
      sourceColor: this.randomColor(),
      sourceName: value.sourceName || 'Anonymous',
      sourceInitial: value.sourceName?.charAt(0).toUpperCase() || '?',
      time: this.randomTime(),
      readTime: this.randomReadTime(),
      title: value.title,
      description: value.description,
      commentsCount: this.randomComments(),
      comments: [],
      hashtags: value.category ? [value.category] : [],
      image: this.selectedImage,
    };

    this.postCreated.emit(newPost);

    this.justPublished = true;
    setTimeout(() => (this.justPublished = false), 600);

    this.postForm.reset({ category: null });
    this.selectedImage = '';
    this.imageError = false;
    this.expanded = false;

    if (this.fileInputRef) {
      this.fileInputRef.value = '';
      this.fileInputRef = null;
    }
  }

  cancel() {
    this.expanded = false;
    this.selectedImage = '';
    this.imageError = false;
    
    this.postForm.reset({ category: null });
    if (this.fileInputRef) {
      this.fileInputRef.value = '';
      this.fileInputRef = null;
    }
  }
}
