import { Component } from '@angular/core';

import { Navbar } from './components/navbar/navbar';
import { Sidebar } from './components/sidebar/sidebar';
import { MainFeed } from "./components/main-feed/main-feed";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    Navbar,
    Sidebar,
    MainFeed
],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

}