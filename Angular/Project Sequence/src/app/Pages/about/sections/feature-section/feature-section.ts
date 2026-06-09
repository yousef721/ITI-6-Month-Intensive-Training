import { Component } from '@angular/core';
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
export class FeatureSection {
  features: IFeatureCard[];

  constructor(private featureService: FeatureService) {
    this.features = this.featureService.getFeatures();
  }
}
