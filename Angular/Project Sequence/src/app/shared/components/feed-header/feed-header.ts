import { Component, EventEmitter, Output } from '@angular/core';
import { SearchBar } from '../search-bar/search-bar';

@Component({
  selector: 'app-feed-header',
  standalone: true,
  imports: [SearchBar],
  templateUrl: './feed-header.html',
  styleUrl: './feed-header.scss',
})
export class FeedHeader {
  @Output() searchChange = new EventEmitter<string>();
  @Output() sortChange = new EventEmitter<string>();

  sortOptions = ['Latest', 'Top Rated', 'Most Discussed'];
  currentSort = 'Latest';

  cycleSort() {
    const idx = this.sortOptions.indexOf(this.currentSort);
    this.currentSort = this.sortOptions[(idx + 1) % this.sortOptions.length];
    this.sortChange.emit(this.currentSort);
  }

  onSearch(query: string) {
    this.searchChange.emit(query);
  }
}
