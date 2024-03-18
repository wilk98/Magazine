import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Etykieta } from '../models/etykieta.model';
import { AppConfig } from '../config/app.config';

@Injectable({
  providedIn: 'root'
})
export class EtykietaService {
  private apiUrl = `${AppConfig.apiUrl}etykiety`;

  constructor(private http: HttpClient) { }

  getEtykiety(): Observable<Etykieta[]> {
    return this.http.get<Etykieta[]>(this.apiUrl);
  }

  addEtykieta(etykieta: Etykieta): Observable<Etykieta> {
    return this.http.post<Etykieta>(this.apiUrl, etykieta);
  }

  editEtykieta(etykieta: Etykieta): Observable<Etykieta> {
    return this.http.put<Etykieta>(`${this.apiUrl}/${etykieta.etykietaId}`, etykieta);
  }

  deleteEtykieta(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
