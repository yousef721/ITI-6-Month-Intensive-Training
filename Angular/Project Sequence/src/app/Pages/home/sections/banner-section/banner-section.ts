import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-banner-section',
  imports: [RouterLink],
  templateUrl: './banner-section.html',
  styleUrls: ['./banner-section.scss'],
})
export class Banner {}
