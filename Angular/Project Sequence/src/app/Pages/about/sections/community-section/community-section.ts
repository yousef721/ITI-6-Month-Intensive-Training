import { Component } from '@angular/core';
import { StatsCard } from '../../../../components/stats-card/stats-card';
import { IStatsCard } from '../../../../interfaces/IStatsCard';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-community-section',
  imports: [StatsCard, RouterLink],
  templateUrl: './community-section.html',
  styleUrl: './community-section.css',
})
export class CommunitySection {
  stats: IStatsCard[] = [
    {
      title: '14K+',
      value: 'Developers',
    },
    {
      title: '128',
      value: 'Articles/day',
    },
    {
      title: '50+',
      value: 'Topics',
    },
    {
      title: '2021',
      value: 'Founded',
    },
  ];
}
