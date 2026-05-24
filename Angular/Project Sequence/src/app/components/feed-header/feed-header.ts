import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-feed-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './feed-header.html',
  styleUrls: ['./feed-header.css'],
})
export class FeedHeader {

  articleCount = 128;

  sortOptions = ['Latest', 'Top Rated', 'Most Discussed'];

  currentSort = 'Latest';

  cycleSort() {
    const idx = this.sortOptions.indexOf(this.currentSort);

    this.currentSort = this.sortOptions[(idx + 1) % this.sortOptions.length];
  }
}