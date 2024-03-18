import { Component, OnInit } from '@angular/core';
import { MagazynService } from '../../services/magazyn.service';
import { Magazyn } from '../../models/magazyn.model';

@Component({
  selector: 'app-magazyny',
  templateUrl: './magazyny.component.html',
})
export class MagazynyComponent implements OnInit {
  magazyny: Magazyn[] = [];
  showAddEditForm = false;
  currentEditMagazyn: Magazyn = { magazynId: 0, nazwa: '', symbol: '' };

  constructor(private magazynService: MagazynService) { }

  ngOnInit(): void {
    this.loadMagazyny();
  }

  loadMagazyny(): void {
    this.magazynService.getMagazyny().subscribe((data: Magazyn[]) => {
      this.magazyny = data;
    });
  }

  showAddMagazyn(): void {
    this.currentEditMagazyn = { magazynId: 0, nazwa: '', symbol: '' };
    this.showAddEditForm = true;
  }

  openEditMagazyn(magazyn: Magazyn): void {
    this.currentEditMagazyn = { ...magazyn };
    this.showAddEditForm = true;
  }

  saveMagazyn(): void {
    if (this.currentEditMagazyn.magazynId) {
      this.magazynService.editMagazyn(this.currentEditMagazyn).subscribe(() => {
        this.loadMagazyny();
      });
    } else {
      this.magazynService.addMagazyn(this.currentEditMagazyn).subscribe(() => {
        this.loadMagazyny();
      });
    }
    this.showAddEditForm = false;
  }

  deleteMagazyn(id: number): void {
    console
    this.magazynService.deleteMagazyn(id).subscribe(() => {
      this.loadMagazyny();
    });
  }
}
