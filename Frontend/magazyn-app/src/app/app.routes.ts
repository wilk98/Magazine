import { Routes } from '@angular/router';
import { MagazynyComponent } from './components/lista-magazynow/magazyny.component';
import { TowaryComponent } from './components/lista-towarow/towary.component';
import { DostawcyComponent } from './components/lista-dostawcow/dostawcy.component';
import { EtykietyComponent } from './components/lista-etykiet/etykiety.component';

export const routes: Routes = [
    { path: 'magazyny', component: MagazynyComponent },
    { path: 'towary', component: TowaryComponent },
    { path: 'dostawcy', component: DostawcyComponent },
    { path: 'etykiety', component: EtykietyComponent },
    { path: '', redirectTo: '/magazyny', pathMatch: 'full' }
];
