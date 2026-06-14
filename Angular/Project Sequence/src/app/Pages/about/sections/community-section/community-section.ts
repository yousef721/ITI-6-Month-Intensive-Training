import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { StatsCard } from '../../../../shared/components/stats-card/stats-card';
import { IStats } from '../../../../core/interfaces/IStats';
import { StatsService } from '../../../../core/services/stats.service';
import { SectionTitle } from "../../../../shared/components/section-title/section-title";

@Component({
  standalone: true,
  selector: 'app-community-section',
  imports: [StatsCard, RouterLink, SectionTitle],
  templateUrl: './community-section.html',
  styleUrl: './community-section.scss',
})
export class CommunitySection {
  stats: IStats[] = [];

  private statsService = inject(StatsService);

  ngOnInit() {
    this.statsService.getStats().subscribe({
      next: (data) => {
        this.stats = data;
      }
    });
  }
}
