# Test Task Iron Water Studio

### Предварительные требования

.NET 7

### Установка

1. Обновите зависимости пакетов NuGet

```bash
dotnet restore

2. Откройте файл appsettings.json и обновите строку подключения в соответствии с конфигурацией вашей базы данных.

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  // другие настройки...
}

3. Выполните миграции

```bash
dotnet ef database update