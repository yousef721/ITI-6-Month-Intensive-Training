import { Component, inject } from '@angular/core';
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

  statsService = inject(StatsService);

  ngOnInit() {
    this.statsService.getStats().subscribe({
      next: (stats: IStats[]) => {
        this.stats = stats.slice(0, 3);
      }
    });
  }
}
