# Test Task Iron Water Studio

### Предварительные требования

.NET 7

### Установка

1. Обновите зависимости пакетов NuGet

```
dotnet restore
```

2. Откройте файл appsettings.json и обновите строку подключения в соответствии с конфигурацией вашей базы данных.

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  // другие настройки...
}
```

3. Выполните миграции

```
dotnet ef database update
```