import { Towar } from './towar.model';
import { Dokument } from './dokument.model';

export interface PozycjaTowaru {
    pozycjaTowaruId: number | null;
    ilosc: number | null;
    cena: number | null;
    towarId: number | null;
    towar?: Towar | null;
    dokumentPrzyjeciaId: number | null;
    dokumentPrzyjecia?: Dokument;
  }
