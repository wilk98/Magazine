import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MagazynyComponent } from './components/lista-magazynow/magazyny.component';
import { TowaryComponent } from './components/lista-towarow/towary.component';
import { DostawcyComponent } from './components/lista-dostawcow/dostawcy.component';
import { EtykietyComponent } from './components/lista-etykiet/etykiety.component';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    MagazynyComponent,
    TowaryComponent,
    DostawcyComponent,
    EtykietyComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
