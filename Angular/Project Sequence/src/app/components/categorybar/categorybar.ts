import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // *ngFor

@Component({
  selector: 'app-categorybar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './categorybar.html',
  styleUrls: ['./categorybar.css'],
})
export class CategoryBar {

  tabs = [
    { label: '✨ For You', active: true },
    { label: '🔥 Trending', active: false },
    { label: '🤖 AI & ML', active: false },
    { label: '☁️ DevOps', active: false },
    { label: '🖥️ Frontend', active: false },
    { label: '⚙️ Backend', active: false },
    { label: '🔒 Security', active: false },
    { label: '📦 Open Source', active: false },
  ];

  selectTab(selected: { label: string; active: boolean }) {
    this.tabs.forEach(t => (t.active = false));
    selected.active = true;
  }
}