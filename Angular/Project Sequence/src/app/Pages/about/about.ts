import { Component } from '@angular/core';
import { HeroSection } from './sections/hero-section/hero-section';
import { CommunitySection } from './sections/community-section/community-section';
import { FeatureSection } from './sections/feature-section/feature-section';

@Component({
  selector: 'app-about',
  imports: [HeroSection, CommunitySection, FeatureSection],
  templateUrl: './about.html',
  styleUrl: './about.css',
})
export class About {}
