import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Post } from '../post-card/post-card';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './form.html',
  styleUrls: ['./form.css'],
})
export class Form {
  @Output() postCreated = new EventEmitter<Post>();

  get f() {
    return this.postForm.controls;
  }

  expanded = false;

  categories: string[] = [
    'AI & Machine Learning',
    'DevOps & Cloud',
    'Frontend Development',
    'Backend & APIs',
    'Security',
    'Open Source',
    'Mobile Development',
    'Databases',
    'Career & Productivity',
  ];

  onTriggerFocus() {
    this.expanded = true;
  }

  private randomColor(): string {
    const colors = ['#000', '#4285F4', '#FF5722', '#9C27B0', '#4CAF50', '#FF9800'];
    return colors[Math.floor(Math.random() * colors.length)];
  }

  private randomUpvotes(): number {
    return Math.floor(Math.random() * 500); // 0 - 499
  }

  private randomComments(): number {
    return Math.floor(Math.random() * 100); // 0 - 99
  }

  private randomReadTime(): string {
    const minutes = Math.floor(Math.random() * 10) + 1;
    return `${minutes} min read`;
  }

  private randomTime(): string {
    const times = ['just now', '5m ago', '10m ago', '1h ago', '3h ago'];
    return times[Math.floor(Math.random() * times.length)];
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

    category: new FormControl('', [Validators.required]),
  });

  publish() {
    if (this.postForm.invalid) {
      this.postForm.markAllAsTouched();
      return;
    }

    const value = this.postForm.value;

    const newPost: Post = {
      voted: false,
      upvotes: this.randomUpvotes(),
      sourceColor: this.randomColor(),
      sourceName: value.sourceName || 'You',
      sourceInitial: value.sourceName?.charAt(0).toUpperCase() || 'Y',
      time: this.randomTime(),
      readTime: this.randomReadTime(),
      title: value.title,
      description: value.description,
      comments: this.randomComments(),
      images: value.image || 'https://picsum.photos/160/128?random=99',
    };

    this.postCreated.emit(newPost);

    this.postForm.reset(); 
    this.expanded = false;
  }

  cancel() {
    this.expanded = false;
  }
}
