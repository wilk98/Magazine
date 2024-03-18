import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Towar } from '../models/towar.model';
import { AppConfig } from '../config/app.config';

@Injectable({
  providedIn: 'root'
})
export class TowarService {
  private apiUrl = `${AppConfig.apiUrl}towary`;

  constructor(private http: HttpClient) { }

  getTowary(): Observable<Towar[]> {
    return this.http.get<Towar[]>(this.apiUrl);
  }

  addTowar(towar: Towar): Observable<Towar> {
    return this.http.post<Towar>(this.apiUrl, towar);
  }

  editTowar(towar: Towar): Observable<Towar> {
    return this.http.put<Towar>(`${this.apiUrl}/${towar.towarId}`, towar);
  }

  deleteTowar(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
