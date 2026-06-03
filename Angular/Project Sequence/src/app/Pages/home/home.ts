import { Component } from '@angular/core';
import { HeroSection } from "./sections/hero-section/hero-section";
import { PostSection } from "./sections/post-section/post-section";
import { Banner } from "./sections/banner-section/banner-section";

@Component({
  selector: 'app-home',
  imports: [HeroSection, PostSection, Banner],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

}
