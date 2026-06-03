import { Component } from '@angular/core';
import { Navbar } from './components/navbar/navbar';
// import { Sidebar } from './components/sidebar/sidebar';
// import { MainFeed } from "./components/main-feed/main-feed";
import { RouterOutlet } from "@angular/router";
import { Footer } from "./components/footer/footer";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    Navbar,
    // Sidebar,
    // MainFeed,
    RouterOutlet,
    Footer
],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

}