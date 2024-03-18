import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MagazynyComponent } from './components/magazyny/magazyny.component';
import { TowaryComponent } from './components/towary/towary.component';
import { DostawcyComponent } from './components/dostawcy/dostawcy.component';
import { EtykietyComponent } from './components/etykiety/etykiety.component';
import { DokumentyComponent } from './components/dokumenty/dokumenty.component';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';
import { FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MagazynyComponent,
    TowaryComponent,
    DostawcyComponent,
    EtykietyComponent,
    DokumentyComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
