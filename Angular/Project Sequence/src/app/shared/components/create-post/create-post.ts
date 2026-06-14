import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { Post } from '../../../core/interfaces/IPostCard';
import { AuthService } from '../../../core/services/auth.service';
import { ICategory } from '../../../core/interfaces/ICategory';
import { CategoryService } from '../../../core/services/category.service';
import { PostService } from '../../../core/services/post.service';

@Component({
  selector: 'app-create-post',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './create-post.html',
  styleUrls: ['./create-post.scss'],
})

export class CreatePost implements OnInit {
  @Output() postCreated = new EventEmitter<void>();

  categories: ICategory[] = [];
  expanded = false;
  selectedImage = '';
  justPublished = false;
  imageError = false;
  publishError = '';
  fileInputRef: HTMLInputElement | null = null;

  constructor(
    private authService: AuthService,
    private categoryService: CategoryService,
    private postService: PostService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
    });
  }

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
    category: new FormControl<number | null>(null, Validators.required),
  });

  onTriggerFocus() {
    if (!this.authService.getLoggedInUser()) {
      this.router.navigate(['/login']);
      return;
    }

    this.expanded = true;
  }

  onImageSelected(event: Event) {
    const input = event.target as HTMLInputElement;

    this.fileInputRef = input;

    if (!input.files?.length) return;

    const file = input.files[0];

    this.compressImage(file)
      .then((dataUrl) => {
        this.selectedImage = dataUrl;
        this.imageError = false;
        this.publishError = '';
      })
      .catch(() => {
        this.selectedImage = '';
        this.imageError = true;
        this.publishError = 'Could not process the selected image. Try another file.';
      });
  }

  private compressImage(file: File, maxWidth = 640, quality = 0.65): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.onload = () => {
        const img = new Image();

        img.onload = () => {
          const canvas = document.createElement('canvas');
          let { width, height } = img;

          if (width > maxWidth) {
            height = Math.round((height * maxWidth) / width);
            width = maxWidth;
          }

          canvas.width = width;
          canvas.height = height;

          const ctx = canvas.getContext('2d');
          if (!ctx) {
            reject(new Error('Canvas not supported'));
            return;
          }

          ctx.drawImage(img, 0, 0, width, height);
          resolve(canvas.toDataURL('image/jpeg', quality));
        };

        img.onerror = () => reject(new Error('Image load failed'));
        img.src = reader.result as string;
      };

      reader.onerror = () => reject(new Error('File read failed'));
      reader.readAsDataURL(file);
    });
  }

  private randomUpvotes = () => Math.floor(Math.random() * 500);

  private randomComments = () => Math.floor(Math.random() * 100);

  private randomReadTime = () => `${Math.floor(Math.random() * 10) + 1} min read`;

  private randomTime = () =>
    ['just now', '5m ago', '10m ago', '1h ago', '3h ago'][Math.floor(Math.random() * 5)];

  private resetForm() {
    this.postForm.reset({ category: null });

    this.selectedImage = '';
    this.imageError = false;
    this.publishError = '';
    this.expanded = false;

    if (this.fileInputRef) {
      this.fileInputRef.value = '';
      this.fileInputRef = null;
    }
  }
  publish() {
    const currentUser = this.authService.getLoggedInUser();

    if (!currentUser) {
      this.router.navigate(['/login']);
      return;
    }

    if (!this.selectedImage) {
      this.imageError = true;
    }

    if (this.postForm.invalid || !this.selectedImage) {
      this.postForm.markAllAsTouched();
      return;
    }

    const value = this.postForm.value;

    const selectedCategory = this.categories.find(
      (c) => String(c.id) === String(value.category)
    );

    const newPost: Post = {
      userId: currentUser.id,
      voted: false,
      saved: false,
      upvotes: this.randomUpvotes(),

      sourceName: value.sourceName,
      sourceInitial:
        (value.sourceName || currentUser.name)?.charAt(0).toUpperCase() || '?',

      time: this.randomTime(),
      readTime: this.randomReadTime(),

      title: value.title,
      description: value.description,

      commentsCount: this.randomComments(),
      comments: [],

      hashtags: selectedCategory ? [selectedCategory.name] : [],

      categoryId: value.category!,

      image: this.selectedImage,
    };

    this.publishError = '';

    this.postService.addPost(newPost).subscribe({
      next: () => {
        this.justPublished = true;

        setTimeout(() => {
          this.justPublished = false;
        }, 600);

        this.resetForm();
        this.postCreated.emit();
      },
      error: () => {
        this.publishError =
          'Failed to publish post. Make sure json-server is running (npm run server) and try again.';
      },
    });
  }
  cancel() {
    this.resetForm();
  }
}