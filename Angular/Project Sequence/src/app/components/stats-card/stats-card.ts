import { Component, Input } from '@angular/core';
import { IStatsCard } from '../../interfaces/IStatsCard';

@Component({
  selector: 'app-stats-card',
  imports: [],
  templateUrl: './stats-card.html',
  styleUrl: './stats-card.css',
})
export class StatsCard {
  @Input() stat!: IStatsCard;
}
