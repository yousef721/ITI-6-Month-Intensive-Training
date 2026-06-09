import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { StatsCard } from '../../../../shared/components/stats-card/stats-card';
import { IStats } from '../../../../core/interfaces/IStats';
import { StatsService } from '../../../../core/services/stats.service';

@Component({
  standalone: true,
  selector: 'app-community-section',
  imports: [StatsCard, RouterLink],
  templateUrl: './community-section.html',
  styleUrl: './community-section.scss',
})
export class CommunitySection {
  stats: IStats[] = [];
  
  constructor(private statsService: StatsService) {
    this.stats = this.statsService.getStats();
  }
}
