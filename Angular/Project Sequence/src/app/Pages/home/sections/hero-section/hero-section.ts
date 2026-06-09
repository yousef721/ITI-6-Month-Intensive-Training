import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { StatsService } from '../../../../core/services/stats.service';
import { IStats } from '../../../../core/interfaces/IStats';

@Component({
  standalone: true,
  selector: 'app-hero-section',
  imports: [RouterLink],
  templateUrl: './hero-section.html',
  styleUrls: ['./hero-section.scss'],
})
export class HeroSection {
  stats: IStats[] = [];

  constructor(private statsService: StatsService) {
    this.stats = this.statsService.getStats().slice(0, 3);
  }
}
