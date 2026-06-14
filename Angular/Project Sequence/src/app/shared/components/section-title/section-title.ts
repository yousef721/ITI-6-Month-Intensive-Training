import { Component, input, Input } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-section-title',
  imports: [],
  templateUrl: './section-title.html',
  styleUrl: './section-title.scss',
})
export class SectionTitle {
  @Input() label!: string;
  @Input() title!: string;
  @Input() subtitle?: string;
}
