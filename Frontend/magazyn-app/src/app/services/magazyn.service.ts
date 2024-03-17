import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Magazyn } from '../models/magazyn.model';
import { AppConfig } from '../config/app.config';

@Injectable({
  providedIn: 'root'
})
export class MagazynService {
  private apiUrl = `${AppConfig.apiUrl}magazyny`;

  constructor(private http: HttpClient) { }

  getMagazyny(): Observable<Magazyn[]> {
    return this.http.get<Magazyn[]>(this.apiUrl);
  }
}
