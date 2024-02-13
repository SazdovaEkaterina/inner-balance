import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, tap, catchError } from 'rxjs';
import { YogaClass } from '../models/yoga-class';

@Injectable({
  providedIn: 'root'
})
export class YogaClassesService {

  constructor(
    @Inject(HttpClient) private readonly http: HttpClient
  ) { }

  getAll(): Observable<YogaClass[]> {
    return this.http.get<YogaClass[]>('https://localhost:7057/api/yoga-classes')
      .pipe(
        tap(data => console.log('Get all: ', JSON.stringify(data))),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`https://localhost:7057/api/yoga-classes/${id}/delete`);
  }
}
