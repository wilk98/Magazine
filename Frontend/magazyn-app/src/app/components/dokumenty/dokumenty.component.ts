import { Component, OnInit } from '@angular/core';
import { DokumentService } from '../../services/dokument.service';
import { MagazynService } from '../../services/magazyn.service';
import { EtykietaService } from '../../services/etykieta.service';
import { DostawcaService } from '../../services/dostawca.service';
import { TowarService } from '../../services/towar.service';
import { Magazyn } from '../../models/magazyn.model';
import { Etykieta } from '../../models/etykieta.model';
import { Dostawca } from '../../models/dostawca.model';
import { Towar } from '../../models/towar.model';
import { Dokument } from '../../models/dokument.model';
import { PozycjeTowaruService } from '../../services/pozycja-towaru.service';


interface PozycjaTowaruDoZapisu {
    pozycjaTowaruId: number | null;
    ilosc: number;
    cena: number;
    towarId: number;
  }
  
  interface DokumentDoZapisu {
    dokumentPrzyjeciaId: number | null;
    dataPrzyjecia: Date | string;
    magazynId: number;
    dostawcaId: number;
    etykietyIds: number[];
    pozycjeTowaru: PozycjaTowaruDoZapisu[];
  }

interface EtykietaWithSelected extends Etykieta {
  selected: boolean;
}

@Component({
  selector: 'app-dokumenty',
  templateUrl: 'dokumenty.component.html',
})
export class DokumentyComponent implements OnInit {
  magazyny: Magazyn[] = [];
  etykiety: EtykietaWithSelected[] = [];
  dostawcy: Dostawca[] = [];
  towaryList: Towar[] = [];
  dokumenty: Dokument[] = [];
  showAddEditForm = false;
  currentDokument: Dokument;

  constructor(
    private dokumentService: DokumentService,
    private magazynService: MagazynService,
    private etykietaService: EtykietaService,
    private dostawcaService: DostawcaService,
    private towarService: TowarService,
    private pozycjeTowaruService: PozycjeTowaruService
  ) {
    this.currentDokument = this.getEmptyDokument();
  }

  ngOnInit(): void {
    this.loadInitialData();
  }

  loadInitialData(): void {
    this.magazynService.getMagazyny().subscribe(data => this.magazyny = data);
    this.etykietaService.getEtykiety().subscribe(data => {
      this.etykiety = data.map(etykieta => ({
        ...etykieta,
        selected: false,
      }));
    });
    this.dostawcaService.getDostawcy().subscribe(data => this.dostawcy = data);
    this.towarService.getTowary().subscribe(data => this.towaryList = data);
    this.dokumentService.getDokumentyPrzyjecia().subscribe(data => this.dokumenty = data);
  }

  getEmptyDokument(): Dokument {
    return {
      dokumentPrzyjeciaId: null,
      dataPrzyjecia: new Date(),
      magazynId: null,
      magazyn: {} as Magazyn,
      dostawcaId: null,
      dostawca: {} as Dostawca,
      etykiety: [],
      pozycjeTowaru: [],
      statusZatwierdzenia: null,
    };
  }

  updateSelectedEtykiety(etykietaToUpdate: EtykietaWithSelected): void {
    etykietaToUpdate.selected = !etykietaToUpdate.selected;
    console.log('Etykiety po zmianie:', this.etykiety);
  }
  

  addPozycjaTowaru(): void {
    this.currentDokument.pozycjeTowaru.push({
      pozycjaTowaruId: null,
      ilosc: null,
      cena: null,
      towarId: null,
      towar: {} as Towar,
      dokumentPrzyjeciaId: this.currentDokument.dokumentPrzyjeciaId,
    });
  }

  removePozycjaTowaru(index: number, pozycjaTowaruId: number | null): void {
    if (pozycjaTowaruId) {
      this.pozycjeTowaruService.deletePozycjaTowaru(pozycjaTowaruId).subscribe({
        next: () => {
          console.log('Pozycja towaru usunięta');
        },
        error: err => console.error('Błąd przy usuwaniu pozycji towaru:', err)
      });
    }
    this.currentDokument.pozycjeTowaru.splice(index, 1);
  }
  

  saveDokument(): void {
    const selectedEtykietyIds = this.etykiety.filter(etykieta => etykieta.selected).map(etykieta => etykieta.etykietaId);
  
    const pozycjeTowaruForSave = this.currentDokument.pozycjeTowaru.map(pozycja => ({
      pozycjaTowaruId: pozycja.pozycjaTowaruId,
      ilosc: pozycja.ilosc ?? 0,
      cena: pozycja.cena ?? 0,
      towarId: pozycja.towarId ?? 0,
    }));
  
    const dokumentToSave: DokumentDoZapisu = {
      dokumentPrzyjeciaId: this.currentDokument.dokumentPrzyjeciaId,
      dataPrzyjecia: this.currentDokument.dataPrzyjecia,
      magazynId: this.currentDokument.magazynId ?? 0,
      dostawcaId: this.currentDokument.dostawcaId ?? 0,
      etykietyIds: selectedEtykietyIds,
      pozycjeTowaru: pozycjeTowaruForSave,
    };
  
    if (this.currentDokument.dokumentPrzyjeciaId) {
      this.dokumentService.editDokumentPrzyjecia(this.currentDokument.dokumentPrzyjeciaId, dokumentToSave).subscribe({
        next: () => this.resetFormAndReload(),
        error: err => console.error('Error editing document:', err),
      });
    } else {
      this.dokumentService.addDokumentPrzyjecia(dokumentToSave).subscribe({
        next: () => this.resetFormAndReload(),
        error: err => console.error('Error adding document:', err),
      });
    }
  }
  
  resetFormAndReload(): void {
    this.showAddEditForm = false;
    this.currentDokument = this.getEmptyDokument();
    this.loadInitialData();
  }

  showAddDokumentForm(): void {
    this.currentDokument = this.getEmptyDokument();
    this.resetEtykietySelection();
    this.showAddEditForm = true;
  }

  editDokument(dokument: Dokument): void {
    this.currentDokument = this.getEmptyDokument();
    this.currentDokument = {...dokument};
    this.etykiety.forEach(etykieta => etykieta.selected = false);
    this.showAddEditForm = true;
  }
  
  resetEtykietySelection(forEdit: boolean = false, dokument?: Dokument): void {
    this.etykiety = this.etykiety.map(etykieta => ({
      ...etykieta,
      selected: forEdit ? dokument?.etykiety.some(e => e.etykietaId === etykieta.etykietaId) || false : false,
    }));
  }

  zatwierdzDokument(id: number | null): void {
    if (id) {
      this.dokumentService.zatwierdzDokumentPrzyjecia(id).subscribe(() => {
        this.loadInitialData();
      });
    }
  }

  anulujDokument(id: number | null): void {
    if (id) {
      this.dokumentService.anulujDokumentPrzyjecia(id).subscribe(() => {
        this.loadInitialData();
      });
    }
  }
}
