import { Etykieta } from './etykieta.model';
import { Magazyn } from './magazyn.model'; 
import { Dostawca } from './dostawca.model';
import { PozycjaTowaru } from './pozycja-towaru.model';

export interface Dokument {
  dokumentPrzyjeciaId: number | null;
  dataPrzyjecia: Date | string;
  magazynId: number | null;
  magazyn?: Magazyn | null;
  dostawcaId: number | null;
  dostawca?: Dostawca | null;
  etykiety: Etykieta[];
  pozycjeTowaru: PozycjaTowaru[];
  statusZatwierdzenia: boolean | null;
}

