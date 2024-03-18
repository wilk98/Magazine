import { Component, OnInit } from '@angular/core';
import { Towar } from '../../models/towar.model';
import { TowarService } from '../../services/towar.service';

@Component({
  selector: 'app-towary',
  templateUrl: 'towary.component.html',
})
export class TowaryComponent implements OnInit {
  towary: Towar[] = [];

  constructor(private towarService: TowarService) { }

  ngOnInit(): void {
    this.loadTowary();
  }

  loadTowary(): void {
    this.towarService.getTowary().subscribe((data: Towar[]) => {
      this.towary = data;
    });
  }
}
