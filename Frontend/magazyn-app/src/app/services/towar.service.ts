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
}
