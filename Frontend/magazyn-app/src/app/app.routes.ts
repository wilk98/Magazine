import { Routes } from '@angular/router';
import { MagazynyComponent } from './components/magazyny/magazyny.component';
import { TowaryComponent } from './components/towary/towary.component';
import { DostawcyComponent } from './components/dostawcy/dostawcy.component';
import { EtykietyComponent } from './components/etykiety/etykiety.component';
import { DokumentyComponent } from './components/dokumenty/dokumenty.component';
import { LoginComponent } from './components/logowanie/login.component';
import { RegisterComponent } from './components/rejestracja/register.component';



export const routes: Routes = [
    { path: 'magazyny', component: MagazynyComponent },
    { path: 'towary', component: TowaryComponent },
    { path: 'dostawcy', component: DostawcyComponent },
    { path: 'etykiety', component: EtykietyComponent },
    { path: 'dokumenty', component: DokumentyComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'dokumenty', component: DokumentyComponent },
    { path: '', redirectTo: '/magazyny', pathMatch: 'full' }
];
