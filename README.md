# 📦 System Zarządzania Inwentarzem Biurowym

**Projekt zaliczeniowy z programowania w technologii .NET/WPF**

> Aplikacja desktopowa zaprojektowana do efektywnego prowadzenia ewidencji wyposażenia biura. Pozwala na kompleksowe zarządzanie sprzętem IT, meblami oraz akcesoriami biurowymi, zapewniając trwałość danych i intuicyjną obsługę.

---

## 🏛️ Struktura Projektu

Aplikacja opiera się na architekturze umożliwiającej separację logiki biznesowej od interfejsu użytkownika.

| Komponent             | Opis Funkcjonalny                                                                                                 |
| --------------------- | ----------------------------------------------------------------------------------------------------------------- |
| **Interfejs (UI)** | Okno główne z listą przedmiotów, formularzami edycji oraz dynamicznym systemem filtrowania.                        |
| **Baza Danych (JSON)**| Plik `inventory.json` przechowujący stan inwentarza w ustrukturyzowanym formacie tekstowym.                        |
| **Moduł Raportów** | Silnik generujący zestawienia w formacie `.txt`, pozwalający na szybki eksport danych do dokumentu zewnętrznego. |
| **Logika Walidacji** | System sprawdzający poprawność wprowadzanych danych (ilość, nazwa) przed ich trwałym zapisem.                     |

---

## 🛠️ Stos Technologiczny

Projekt został zbudowany przy użyciu nowoczesnych narzędzi platformy .NET.

| Technologia           | Opis i zastosowanie                                                                               |
| --------------------- | ------------------------------------------------------------------------------------------------- |
| 🖼️ **WPF / XAML** | Framework wykorzystany do budowy nowoczesnego i przejrzystego interfejsu użytkownika.              |
| ⚙️ **C# / .NET** | Główny język programowania obsługujący logikę biznesową i operacje na danych.                     |
| 📦 **Newtonsoft.Json**| Biblioteka NuGet do serializacji danych, zapewniająca lekką i wydajną bazę danych w pliku JSON.   |
| 📂 **System.IO** | Przestrzeń nazw odpowiedzialna za fizyczny zapis i odczyt plików inwentarza oraz raportów.        |

---

## ✨ Kluczowe Funkcjonalności

* **Pełny moduł CRUD:** Użytkownik ma możliwość dodawania, wyświetlania, edytowania oraz trwałego usuwania przedmiotów z inwentarza.
* **Wyszukiwanie Real-Time:** Zaimplementowana funkcja filtrowania listy w czasie rzeczywistym – tabela aktualizuje się dynamicznie podczas wpisywania nazwy.
* **Bezpieczeństwo Danych:** System potwierdzeń (MessageBox) przy próbie usunięcia elementu zapobiega przypadkowej utracie informacji.
* **Automatyczne Raportowanie:** Generowanie raportu `.txt` jednym kliknięciem, który po utworzeniu jest automatycznie otwierany w systemowym edytorze (np. Notatnik).
* **Walidacja Formularzy:** Blokada dodawania pustych rekordów lub ujemnych stanów magazynowych, co gwarantuje spójność bazy danych.

---
## 🚀 Uruchomienie Projektu

Aplikacja jest gotowa do uruchomienia po sklonowaniu repozytorium i otwarciu w środowisku Visual Studio.

## 📂 Struktura Plików

```
WpfInventory/
├── 📄 App.xaml            
├── 📄 App.xaml.cs         
├── 📄 AssemblyInfo.cs     
├── 📄 MainWindow.xaml     
├── 📄 MainWindow.xaml.cs 
├── 📄 Przedmiot.cs       
└── 📄 WpfInventory.csproj 

```



### 🌐 Instrukcja krok po kroku
1. Pobierz kod źródłowy i otwórz plik **WpfInventory.sln**.
2. Poczekaj na automatyczne przywrócenie pakietów NuGet (**Newtonsoft.Json**).
3. Naciśnij klawisz **F5**, aby skompilować i uruchomić aplikację.
4. Plik bazy danych oraz raporty znajdziesz po pierwszym uruchomieniu w folderze: `bin/Debug`.

---
**Autor:** Tomasz Złotkowski
