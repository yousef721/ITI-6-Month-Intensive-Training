import { Injectable } from '@angular/core';
import { IFeatureCard } from '../interfaces/IFeatureCard';
import { FEATURE } from '../data/feature.data';

@Injectable({
  providedIn: 'root',
})
export class FeatureService {
  getFeatures(): IFeatureCard[] {
    return FEATURE;
  }
}
