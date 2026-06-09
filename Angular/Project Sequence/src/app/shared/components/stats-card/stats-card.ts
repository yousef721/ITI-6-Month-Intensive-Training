import { Component, Input } from '@angular/core';
import { IStats } from '../../../core/interfaces/IStats';

@Component({
  standalone: true,
  selector: 'app-stats-card',
  imports: [],
  templateUrl: './stats-card.html',
  styleUrl: './stats-card.scss',
})
export class StatsCard {
  @Input({ required: true }) stat!: IStats;
}
