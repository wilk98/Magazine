import { Routes } from '@angular/router';
import { MagazynyComponent } from './components/lista-magazynow/magazyny.component';


export const routes: Routes = [
    { path: 'magazyny', component: MagazynyComponent },
    { path: '', redirectTo: '/magazyny', pathMatch: 'full' }
];
