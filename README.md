System Zarządzania Inwentarzem Biurowym
Autor: Tomasz Złotkowski

 1. Opis projektu
Aplikacja została przygotowana jako projekt zaliczeniowy. Jej głównym celem jest prowadzenie ewidencji wyposażenia biura, takiego jak sprzęt IT, meble czy akcesoria biurowe. 
Program pozwala na pełne zarządzanie danymi (dodawanie, wyświetlanie, edycję i usuwanie) oraz zapewnia ich trwałość dzięki zapisowi do plików lokalnych w formacie JSON.

 2. Główne funkcjonalności
* Zarządzanie przedmiotami: Użytkownik może dodawać nowe pozycje, edytować istniejące oraz usuwać te, które nie są już potrzebne.
* Bezpieczeństwo operacji: Przy próbie usunięcia przedmiotu aplikacja wyświetla okno z zapytaniem o potwierdzenie. Zapobiega to przypadkowej utracie danych przez błędne kliknięcie.
* Wyszukiwarka: Zaimplementowałem funkcję filtrowania listy w czasie rzeczywistym. Tabela aktualizuje się automatycznie już w trakcie wpisywania nazwy przedmiotu.
* System raportowania: Program posiada funkcję generowania czytelnego raportu tekstowego (plik .txt). Po utworzeniu raportu system automatycznie otwiera go w domyślnym edytorze (np. Notatniku).
* Trwałość danych: Do składowania informacji wykorzystałem bibliotekę Newtonsoft.Json. Dzięki temu baza danych jest lekka, czytelna  i nie wymaga instalowania dodatkowych serwerów bazy danych.
* Walidacja: Aplikacja sprawdza poprawność wprowadzanych danych, np. blokuje możliwość dodania przedmiotu bez nazwy lub z ujemną ilością, po klinięciu usuń pyta czy na pewno użytkownik checo to zrobić.

 3. Technologie i biblioteki
* WPF / XAML – wykorzystane do stworzenia interfejsu użytkownika.
* C# / .NET – logika biznesowa programu.
* Newtonsoft.Json – biblioteka do obsługi plików bazy danych.
* System.Diagnostics – wykorzystane do automatycznego otwierania wygenerowanych raportów.

 4. Instrukcja uruchomienia
1. Pobierz kod źródłowy i otwórz plik **WpfInventory.sln** w środowisku Visual Studio.
2. Przy pierwszym uruchomieniu system NuGet powinien automatycznie pobrać bibliotekę Newtonsoft.Json.
3. Uruchom program klawiszem **F5**.
4. Plik bazy danych (`inventory.json`) oraz generowane raporty tekstowe znajdują się w folderze projektu: `bin/Debug`.


