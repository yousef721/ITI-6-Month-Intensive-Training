import { Injectable } from '@angular/core';
import { IStats } from '../interfaces/IStats';
import { STATS } from '../data/stats.data';

@Injectable({
  providedIn: 'root',
})
export class StatsService {
  getStats(): IStats[] {
    return STATS;
  }
}
