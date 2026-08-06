# WinTempCleaner

WinTempCleaner is a temporary files cleaner. It searches your temporary files directory and automatically cleans it for you.

---

## Features

*   **Error Handling:** Uses exception handling to skip files currently in use by system or in need of higher permission.
*   **Execution Report:** Provides a detailed summary of successful and failed deletions. 

---

## How Run

### Run from the source

1.  **Prerequisites:** You need to have the **.NET SDK** installed on your machine (Version 8.0 or higher recommended).
2.  **Clone the repository:**
    ```bash
    git clone https://github.com/Tzavi727/WinTempCleaner.git
    ```
3.  **Navigate to the project folder:**
    ```bash
    cd WinTempCleaner
    ```
4.  **Run the application:**
    ```bash
    dotnet run
    ```