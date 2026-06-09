import { Component } from '@angular/core';
import { HeroSection } from './sections/hero-section/hero-section';
import { FeatureSection } from './sections/feature-section/feature-section';
import { CommunitySection } from './sections/community-section/community-section';

@Component({
  standalone: true,
  selector: 'app-about',
  imports: [HeroSection, FeatureSection, CommunitySection],
  templateUrl: './about.html',
  styleUrl: './about.scss',
})
export class About {}