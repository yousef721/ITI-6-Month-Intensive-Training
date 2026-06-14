import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICategory } from '../interfaces/ICategory';

@Injectable({
    providedIn: 'root',
})
export class CategoryService {
    private http = inject(HttpClient);

    private apiUrl = 'http://localhost:3000/categories';

    getCategories() {
        return this.http.get<ICategory[]>(this.apiUrl);
    }
}