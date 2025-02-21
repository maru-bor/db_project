# Databázový projekt
Databázový projekt s konzolovým uživatelským rozhraním umožňující práci s databází. Tento projekt byl programován pouze v C# a také využívá návrhové vzory Singleton a DAO.

## Jak program připojit k databázi
- Importovat soubor **db_export.sql** do vlastního databázového serveru (pro strukturování samotné databáze)
- V souboru **App.config** nastavit přístupové informace pro připojení k databázi:
    - **UserID**: hodnotu nastavit na vaše přihlašovací jméno
    - **Password**: hodnotu nastavit na vaše přihlašovací heslo
    - **IntialCatalog**: hodnotu nastavit na jméno databáze
    - **DataSource**: hodnotu nastavit na jméno serveru
- Nakonec spuštění programu -> zobrazení konzolového uživatelského rozhraní

## Testovací scénáře
- Pro projekt byl také vytvořen PDF soubor s testovacími scénáři **test_case_dbproject**. Podle testovacích scénářů by se mělo otestovat:
    - spustitelnost programu 
    - zobrazení záznamů v tabulkách databáze
    - přidání nových záznamů do tabulek databáze
    
    
    
