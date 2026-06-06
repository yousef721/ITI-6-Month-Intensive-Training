import { Component, Input } from '@angular/core';
import { IFeatureCard } from '../../interfaces/IFeatureCard';

@Component({
  selector: 'app-feature-card',
  imports: [],
  templateUrl: './feature-card.html',
  styleUrl: './feature-card.css',
})
export class FeatureCard {
  @Input() feature!: IFeatureCard;
}
