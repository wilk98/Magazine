# Magazine
Głównym celem aplikacji jest zarządzanie procesem tworzenia dokumentów przyjęć zewnętrznych na magazyn, obejmujących informacje o dostawcach, listach towarów, magazynach docelowych oraz przypisanych etykietach.

## Struktura i Technologie
Aplikacja składa się z dwóch kluczowych komponentów:

**'Front-End'**: Zaimplementowany w Angularze, zapewnia interfejs użytkownika do interakcji z aplikacją.  
**'Back-End'**: Oparte o .NET C# REST API, odpowiedzialne za przetwarzanie logiki biznesowej oraz komunikację z bazą danych.

Dane są przechowywane w Microsoft SQL Server, a do operacji na bazie danych wykorzystywane jest ORM EF Core.

## Funkcjonalności Aplikacji
### Widoki i Operacje
Aplikacja oferuje następujące widoki i operacje:

**'Magazyny'**: Przeglądanie, dodawanie, edycja i usuwanie magazynów.  
**'Towary'**: Zarządzanie towarami, w tym dodawanie nowych pozycji, edycja i usuwanie.  
**'Dostawcy'**: Wyświetlanie listy dostawców, dodawanie, edycja i usuwanie.  
**'Etykiety'**: Wyświetlanie listy etykiet, dodawanie, edycja i usuwanie.  
**'Dokumenty przyjęć'**: Wyświetlanie dokumentów (z wyjątkiem anulowanych), dodawanie nowych, edycja (z wyjątkiem zatwierdzonych dokumentów), zatwierdzanie i anulowanie.

### Logika Aplikacji
W aplikacji obowiązują następujące zasady dotyczące dokumentów przyjęcia:

**'Dostawcy'**: Każdy dokument przyjęcia jest związany z jednym dostawcą.  
**'Etykiety'**: Dokument może mieć wiele etykiet. Jedna etykieta może być przypisana do wielu dokumentów.  
**'Pozycje Towaru'**: Dokument składa się z wielu pozycji towarowych, precyzujących ilość i cenę towarów. Każda pozycja jest powiązana tylko z jednym dokumentem.  
**'Magazyny'***: Dokument jest przypisany do jednego magazynu, ale jeden magazyn może być powiązany z wieloma dokumentami.

### Logowanie i Rejestracja
Aplikacja wykorzystuje Microsoft ASP.NET Core Identity do obsługi logowania i rejestracji użytkowników:

**'Rejestracja'**: Użytkownicy mogą tworzyć konta, używając adresu e-mail. System bezpiecznie przechowuje hasła.  
**'Logowanie'**: Po weryfikacji danych, użytkownik otrzymuje token JWT.  
**'Wylogowanie'**: Usuwa token użytkownika i kończy sesję.

Integracja Identity zabezpiecza aplikację i pozwala na rozwój funkcji związanych z zarządzaniem kontem użytkownika.

## Rozwój i Skalowalność
Aplikacja została zaprojektowana z zachowaniem najlepszych praktyk architektonicznych, co umożliwia łatwą skalowalność i rozwój w przyszłości. Kluczowym aspektem projektu jest jego modułowa struktura, podzielona na cztery główne warstwy: **'Core'**, **'Application'**, **'Infrastructure'** oraz **'API'**, co ułatwia zarządzanie kodem, testowanie oraz integrację z dodatkowymi narzędziami i usługami.

## Uruchomienie Projektu
Do uruchomienia aplikacji wymagane jest środowisko Angulara dla front-endu oraz .NET C# dla back-endu, a także dostęp do serwera Microsoft SQL Server dla bazy danych. Aplikacja jest dostosowana do lokalnego uruchomienia z domyślnymi ustawieniami portów dla obu technologii.
