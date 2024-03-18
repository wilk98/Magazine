import { Component, OnInit } from '@angular/core';
import { Etykieta } from '../../models/etykieta.model';
import { EtykietaService } from '../../services/etykieta.service';

@Component({
  selector: 'app-etykiety',
  templateUrl: 'etykiety.component.html',
})
export class EtykietyComponent implements OnInit {
  etykiety: Etykieta[] = [];
  showAddEditForm = false;
  currentEditEtykieta: Etykieta = { etykietaId: 0, nazwa: '' };

  constructor(private etykietaService: EtykietaService) { }

  ngOnInit(): void {
    this.loadEtykiety();
  }

  loadEtykiety(): void {
    this.etykietaService.getEtykiety().subscribe((data: Etykieta[]) => {
      this.etykiety = data;
    });
  }

  showAddEtykieta(): void {
    this.currentEditEtykieta = { etykietaId: 0, nazwa: '' };
    this.showAddEditForm = true;
  }

  openEditEtykieta(etykieta: Etykieta): void {
    this.currentEditEtykieta = { ...etykieta };
    this.showAddEditForm = true;
  }

  saveEtykieta(): void {
    if (this.currentEditEtykieta.etykietaId) {
      this.etykietaService.editEtykieta(this.currentEditEtykieta).subscribe(() => {
        this.loadEtykiety();
      });
    } else {
      this.etykietaService.addEtykieta(this.currentEditEtykieta).subscribe(() => {
        this.loadEtykiety();
      });
    }
    this.showAddEditForm = false;
  }

  deleteEtykieta(id: number): void {
    this.etykietaService.deleteEtykieta(id).subscribe(() => {
      this.loadEtykiety();
    });
  }
}
