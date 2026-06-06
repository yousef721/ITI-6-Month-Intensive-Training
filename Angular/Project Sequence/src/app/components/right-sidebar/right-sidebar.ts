import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-right-sidebar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './right-sidebar.html',
  styleUrls: ['./right-sidebar.css'],
})
export class RightSidebar {
  trendingTags = [
    '#nextjs',
    '#rust',
    '#kubernetes',
    '#typescript',
    '#llm',
    '#wasm',
    '#tailwind',
    '#bun',
  ];

  weeklyLeaders = [
    { initial: 'V', name: 'Vercel Blog', posts: 24, upvotes: 1200 },
    { initial: 'G', name: 'Google Eng', posts: 18, upvotes: 890 },
  ];
}
