import { Component, OnInit } from '@angular/core';
import { Dostawca } from '../../models/dostawca.model';
import { DostawcaService } from '../../services/dostawca.service';

@Component({
  selector: 'app-dostawcy',
  templateUrl: 'dostawcy.component.html',
})
export class DostawcyComponent implements OnInit {
  dostawcy: Dostawca[] = [];
  showAddEditForm = false;
  currentEditDostawca: Dostawca = { dostawcaId: 0, nazwaFirmy: '', adres: '' };

  constructor(private dostawcaService: DostawcaService) { }

  ngOnInit(): void {
    this.loadDostawcy();
  }

  loadDostawcy(): void {
    this.dostawcaService.getDostawcy().subscribe((data: Dostawca[]) => {
      this.dostawcy = data;
    });
  }
  showAddDostawca(): void {
    this.currentEditDostawca = { dostawcaId: 0, nazwaFirmy: '', adres: '' };
    this.showAddEditForm = true;
  }

  openEditDostawca(dostawca: Dostawca): void {
    this.currentEditDostawca = { ...dostawca };
    this.showAddEditForm = true;
  }

  saveDostawca(): void {
    if (this.currentEditDostawca.dostawcaId) {
      this.dostawcaService.editDostawca(this.currentEditDostawca).subscribe(() => {
        this.loadDostawcy();
      });
    } else {
      this.dostawcaService.addDostawca(this.currentEditDostawca).subscribe(() => {
        this.loadDostawcy();
      });
    }
    this.showAddEditForm = false;
  }

  deleteDostawca(id: number): void {
    this.dostawcaService.deleteDostawca(id).subscribe(() => {
      this.loadDostawcy();
    });
  }
}

