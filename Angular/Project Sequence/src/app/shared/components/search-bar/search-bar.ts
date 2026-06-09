import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-search-bar',
  imports: [FormsModule],
  templateUrl: './search-bar.html',
  styleUrl: './search-bar.scss',
})
export class SearchBar {
  @Output() searchChange = new EventEmitter<string>();

  query = '';

  onInput() {
    this.searchChange.emit(this.query);
  }
}
