import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dokument } from '../models/dokument.model';
import { AppConfig } from '../config/app.config';

interface PozycjaTowaruDoZapisu {
  ilosc: number;
  cena: number;
  towarId: number;
}

interface DokumentDoZapisu {
  dataPrzyjecia: Date | string;
  magazynId: number;
  dostawcaId: number;
  etykietyIds: number[];
  pozycjeTowaru: PozycjaTowaruDoZapisu[];
}

@Injectable({
  providedIn: 'root'
})
export class DokumentService {
  private apiUrl = `${AppConfig.apiUrl}dokumenty`;

  constructor(private http: HttpClient) { }

  getDokumentyPrzyjecia(): Observable<Dokument[]> {
    return this.http.get<Dokument[]>(`${this.apiUrl}`);
  }

  addDokumentPrzyjecia(dokument: DokumentDoZapisu): Observable<Dokument> {
    console.log(dokument)
    return this.http.post<Dokument>(this.apiUrl, dokument);
  }
  
  zatwierdzDokumentPrzyjecia(id: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${id}/zatwierdz`, {});
  }

  anulujDokumentPrzyjecia(id: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${id}/anuluj`, {});
  }

  editDokumentPrzyjecia(id: number, dokument: DokumentDoZapisu): Observable<void> {
    console.log(dokument, id)
    return this.http.put<void>(`${this.apiUrl}/${id}`, dokument);
  }
}
