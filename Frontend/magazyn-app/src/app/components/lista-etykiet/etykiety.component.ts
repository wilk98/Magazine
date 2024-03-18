import { Component, OnInit } from '@angular/core';
import { Etykieta } from '../../models/etykieta.model';
import { EtykietaService } from '../../services/etykieta.service';

@Component({
  selector: 'app-etykiety',
  templateUrl: 'etykiety.component.html',
})
export class EtykietyComponent implements OnInit {
  etykiety: Etykieta[] = [];

  constructor(private etykietaService: EtykietaService) { }

  ngOnInit(): void {
    this.loadEtykiety();
  }

  loadEtykiety(): void {
    this.etykietaService.getEtykiety().subscribe((data: Etykieta[]) => {
      this.etykiety = data;
    });
  }
}
