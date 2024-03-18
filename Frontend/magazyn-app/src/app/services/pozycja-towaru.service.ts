import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConfig } from '../config/app.config';


@Injectable({
  providedIn: 'root'
})
export class PozycjeTowaruService {
  private apiUrl = `${AppConfig.apiUrl}PozycjeTowaru`;

  constructor(private http: HttpClient) { }

  deletePozycjaTowaru(pozycjaTowaruId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${pozycjaTowaruId}`);
  }
}
