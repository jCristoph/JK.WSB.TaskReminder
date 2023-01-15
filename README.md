Wymagania funkcjonalne:
1. Użytkownik ma możliwość stworzenia konta i zalogowania się na niego
2. Użytkownik ma możliwość przeglądania nowych zadań
3. Użytkownik ma możliwość edycji instniejących zadań i dodawania nowych
4. Użytkownik ma możliwość dodawania do zadań tzw. podzadań (ang. steps)

Wymagania pozafunkcjonalne:
1. łatwość użycia - aplikacja jest intuicyjna, nie wymaga szkolenia by zacząć z niej korzystać
2. mobilność - aplikacja jest dostępna na wielu urządzeniach zarówno mobilnych jak i stacjonarnych.

Opis projektu:
Aplikacja TaskReminder to aplikacja webowa pozwalająca na tworzenie zadań i ich rozplanowanie. Użytkownik tworzy własne konto i przypisuje do niego nowe zdania. 
Dzięki temu z aplikacji można korzystać z wielu urządzeń jednocześnie w wielu miejscach. Aplikacja jest zaprojektowana w taki sposób aby wspierać urządzenia mobilne 
jak i stacjonarne. W aplikacji każde zadanie może być zaznaczone jako ulubione lub zakończone. Dodatkowo jest możliwość ustawienia daty przypomnienia oraz daty zakończenia.
Użytkownik ma do dyspozycji miejce na notatkę. Każde zadanie może być edytowane lub może mieć dodane podzadanie. 

Potencjalni klienci:
1. Firmy chcące mieć kontrolę nad zadaniami poszczególnych pracowników
2. Każda osoba chcąca w graficzny sposób zaplanować obowiązki na najbliższy czas

Korzyści biznesowe:
1. Długoterminowe planowanie zadań przekłada się na lepszą wydajność użytkowników.
2. Użytkownik ma dodatkowe narzędzie dzięki, któremu nie zapomni o ważnych spotkaniach

Dokumentacja techniczna:

Projekt napisany jest w języku C# przy pomocy frameworka ASP.Net Core oraz Blazor dla .Net 6.
Baza danych została oparta o relacyjną bazę danych Microsoft SQL Server.
Do przeprowadzania operacji na bazie danych użyto ORM w postaci EntityFramework Core w wersji 6.
Aplikacja kliencka komunikuje się z serwerem za pomocą REST API.
Dalsze prace rozwojowe dla aplikacji to dodanie przypomnień mailowych, możliwość edycji konta, modernizacja widoków oraz większa interaktywność
zadań i podzadań.

Dokumentacja api jest dostępna pod adresem /swagger/index.html
Diagram Bazy Danych znajudje się w projekcie Server w folderze Data
