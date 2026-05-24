import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Post } from '../post-card/post-card';

interface FormData {
  title: string;
  url: string;
  description: string;
  category: string;
  image?: string;
}
@Component({
  selector: 'app-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './form.html',
  styleUrls: ['./form.css'],
})
export class Form {
  @Output() postCreated = new EventEmitter<Post>();

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

  formData: FormData = {
    title: '',
    url: '',
    description: '',
    category: '',
    image: '',
  };

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

  private randomSourceName(): string {
    const sources = ['You', 'Dev Blog', 'Tech Weekly', 'Angular Hub', 'Code Times'];
    return sources[Math.floor(Math.random() * sources.length)];
  }

  private randomInitial(name: string): string {
    return name.charAt(0).toUpperCase();
  }

  publish() {
    if (!this.formData.title.trim()) return;

    const sourceName = this.randomSourceName();

    const newPost: Post = {
      voted: false,

      upvotes: this.randomUpvotes(),

      sourceColor: this.randomColor(),

      sourceName: sourceName,

      sourceInitial: this.randomInitial(sourceName),

      time: this.randomTime(),

      readTime: this.randomReadTime(),

      title: this.formData.title,

      description: this.formData.description,

      comments: this.randomComments(),

      images: this.formData.image || 'https://picsum.photos/160/128?random=99',
    };

    this.postCreated.emit(newPost);

    this.formData = {
      title: '',
      url: '',
      description: '',
      category: '',
      image: '',
    };

    this.expanded = false;
  }

  cancel() {
    this.expanded = false;
  }
}
