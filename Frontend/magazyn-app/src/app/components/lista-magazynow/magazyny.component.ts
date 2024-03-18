import { Component, OnInit } from '@angular/core';
import { MagazynService } from '../../services/magazyn.service';
import { Magazyn } from '../../models/magazyn.model';

@Component({
  selector: 'app-magazyny',
  templateUrl: 'magazyny.component.html',
})
export class MagazynyComponent implements OnInit {
  magazyny: Magazyn[] = [];

  constructor(private magazynService: MagazynService) { }

  ngOnInit(): void {
    this.loadMagazyny();
  }

  loadMagazyny(): void {
    this.magazynService.getMagazyny().subscribe((data: Magazyn[]) => {
      this.magazyny = data;
    });
  }
}
