import { Component, Input } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-stats-card',
  templateUrl: './stats-card.html',
  styleUrls: ['./stats-card.scss'],
})
export class StatsCard {
  @Input({ required: true }) number!: string;
  @Input({ required: true }) label!: string;
}
