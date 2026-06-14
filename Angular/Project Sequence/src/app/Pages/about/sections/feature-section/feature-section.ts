import { Component, inject, OnInit } from '@angular/core';
import { FeatureCard } from '../../../../shared/components/feature-card/feature-card';
import { IFeatureCard } from '../../../../core/interfaces/IFeatureCard';
import { FeatureService } from '../../../../core/services/feature.service';

@Component({
  standalone: true,
  selector: 'app-feature-section',
  imports: [FeatureCard],
  templateUrl: './feature-section.html',
  styleUrl: './feature-section.scss',
})
export class FeatureSection implements OnInit {
  features: IFeatureCard[] = [];

  featureService = inject(FeatureService);

  ngOnInit() {
    this.featureService.getFeatures().subscribe({
      next: (data) => {
        this.features = data;
      }
    });
  }
}
