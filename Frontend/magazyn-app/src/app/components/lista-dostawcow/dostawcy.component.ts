import { Component, OnInit } from '@angular/core';
import { Dostawca } from '../../models/dostawca.model';
import { DostawcaService } from '../../services/dostawca.service';

@Component({
  selector: 'app-dostawcy',
  templateUrl: 'dostawcy.component.html',
})
export class DostawcyComponent implements OnInit {
  dostawcy: Dostawca[] = [];

  constructor(private dostawcaService: DostawcaService) { }

  ngOnInit(): void {
    this.loadDostawcy();
  }

  loadDostawcy(): void {
    this.dostawcaService.getDostawcy().subscribe((data: Dostawca[]) => {
      this.dostawcy = data;
    });
  }
}
