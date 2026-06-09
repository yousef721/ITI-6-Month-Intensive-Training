import { Component } from '@angular/core';
import { HeroSection } from './sections/hero-section/hero-section';
import { PostSection } from './sections/post-section/post-section';
import { Banner } from './sections/banner-section/banner-section';

@Component({
  standalone: true,
  selector: 'app-home',
  imports: [HeroSection, PostSection, Banner],
  templateUrl: './home.html',
  styleUrls: ['./home.scss'],
})
export class Home {}