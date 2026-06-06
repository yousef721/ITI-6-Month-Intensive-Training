import { Component } from '@angular/core';
import { FeatureCard } from '../../../../components/feature-card/feature-card';
import { IFeatureCard } from '../../../../interfaces/IFeatureCard';

@Component({
  selector: 'app-feature-section',
  imports: [FeatureCard],
  templateUrl: './feature-section.html',
  styleUrl: './feature-section.css',
})
export class FeatureSection {
  features: IFeatureCard[] = [
    {
      icon: '🔍',
      title: 'Smart Discovery',
      description:
        'Our algorithm surfaces the most relevant content based on your interests, reading history, and community votes.',
    },
    {
      icon: '🌍',
      title: 'Global Community',
      description:
        '14,000+ developers from 80+ countries reading, discussing, and contributing to the platform every day.',
    },
    {
      icon: '⚡',
      title: 'Always Fresh',
      description:
        '128+ new articles indexed daily from top engineering blogs, open-source projects, and community contributors.',
    },
  ];
}
