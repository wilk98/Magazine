import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dostawca } from '../models/dostawca.model';
import { AppConfig } from '../config/app.config';

@Injectable({
  providedIn: 'root'
})
export class DostawcaService {
  private apiUrl = `${AppConfig.apiUrl}dostawcy`;

  constructor(private http: HttpClient) { }

  getDostawcy(): Observable<Dostawca[]> {
    return this.http.get<Dostawca[]>(this.apiUrl);
  }
}
