import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IFeatureCard } from '../interfaces/IFeatureCard';

@Injectable({
  providedIn: 'root',
})
export class FeatureService {
  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:3000/features';

  getFeatures() {
    return this.http.get<IFeatureCard[]>(this.apiUrl);
  }
}