import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStats } from '../interfaces/IStats';

@Injectable({
  providedIn: 'root',
})
export class StatsService {
  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:3000/stats';

  getStats() {
    return this.http.get<IStats[]>(this.apiUrl);
  }
}