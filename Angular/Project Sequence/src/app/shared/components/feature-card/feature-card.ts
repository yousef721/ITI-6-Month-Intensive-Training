import { Component, Input } from '@angular/core';
import { IFeatureCard } from '../../../core/interfaces/IFeatureCard';

@Component({
  standalone: true,
  selector: 'app-feature-card',
  imports: [],
  templateUrl: './feature-card.html',
  styleUrl: './feature-card.scss',
})
export class FeatureCard {
  @Input({ required: true }) feature!: IFeatureCard;
}