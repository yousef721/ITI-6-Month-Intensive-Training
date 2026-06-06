import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-post-card-img',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-card-img.html',
  styleUrls: ['./post-card-img.css'],
})
export class PostCardImg {
  @Input() src: string = '';
  @Input() alt: string = '';
  @Input() layout: 'vertical' | 'horizontal' = 'vertical';
}
