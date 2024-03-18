import { Component, OnInit } from '@angular/core';
import { Towar } from '../../models/towar.model';
import { TowarService } from '../../services/towar.service';

@Component({
  selector: 'app-towary',
  templateUrl: 'towary.component.html',
})
export class TowaryComponent implements OnInit {
  towary: Towar[] = [];
  showAddEditForm = false;
  currentEditTowar: Towar = { towarId: 0, nazwa: '', kod: '' };

  constructor(private towarService: TowarService) { }

  ngOnInit(): void {
    this.loadTowary();
  }

  loadTowary(): void {
    this.towarService.getTowary().subscribe((data: Towar[]) => {
      this.towary = data;
    });
  }

  showAddTowar(): void {
    this.currentEditTowar = { towarId: 0, nazwa: '', kod: '' };
    this.showAddEditForm = true;
  }

  openEditTowar(towar: Towar): void {
    this.currentEditTowar = { ...towar };
    this.showAddEditForm = true;
  }

  saveTowar(): void {
    if (this.currentEditTowar.towarId) {
      this.towarService.editTowar(this.currentEditTowar).subscribe(() => {
        this.loadTowary();
      });
    } else {
      this.towarService.addTowar(this.currentEditTowar).subscribe(() => {
        this.loadTowary();
      });
    }
    this.showAddEditForm = false;
  }

  deleteTowar(id: number): void {
    this.towarService.deleteTowar(id).subscribe(() => {
      this.loadTowary();
    });
  }
}
