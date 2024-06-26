# System biblioteczny

### Autor
* Grzegorz Dynak

### Data wykonania
* 29.12.23 - 03.06.24

### Opis
Projekt ma na celu dostarczenie aplikacji webowej przeznaczonej do zarządzania biblioteką. Aplikacja dostarcza podstawowe funcjonalności zarówno dla bibliotekarzy jak i czytelników.
#### Bibliotekarze mogą:
* dodawać książki, czytelników oraz edytować istniejące rekordy
* wypożyczać oraz zwracać książki
* monitorować zarezerwowane i wypożyczone książki użytkowników
#### Czytelnicy mogą:
* przeglądać wszystkie książki, także te które są przez nich zarezerwowane, wypożyczone czy dodane do ulubionych
* zarządzać swoimi rezerwacjami, przedłużać termin oddania książki
* zarządzać swoim kontem i sprawdzać historię aktywności

### Użyte technologie
* Baza danych:
  * SQL Server
  * Entity Framework Core
* Backend:
  * ASP.NET Core
  * C#
* Frontend:
  * Blazor
  * Bootstrap
 
 #### Uzasadnienie
 Blazor pozwala w prosty sposób na stworzenie strony internetowej, która będzie łatwa w obsłudze dla użytkownika, a przy tym będzie dobrze wyglądać.
 Poza tym strona była projektowana w taki sposób aby mogła być bez problemu wyświetlona na ekranie smartfona, przez co nie było potrzeby projektowania aplikacji.
 Bootstrap daje dostęp do gotowych komponentów które sprawiają że strona wygląda bardziej nowocześnie.
 Entity Framework Core pozwala na prostą obsługę bazy danych.

 ### Projekt architektury
![architecture-project drawio](https://github.com/gregusio/library-management-system/assets/77176069/20353236-2126-464f-9a83-01166298bba7)

### Projekt bazy danych
![database-diagram](https://github.com/gregusio/library-management-system/assets/77176069/398a99c7-fffe-4660-84d9-31addd705bfd)

