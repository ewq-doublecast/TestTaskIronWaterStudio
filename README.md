# Test Task Iron Water Studio

### ��������������� ����������

.NET 7

### ���������

1. �������� ����������� ������� NuGet

```
dotnet restore
```

2. �������� ���� appsettings.json � �������� ������ ����������� � ������������ � ������������� ����� ���� ������.

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  // ������ ���������...
}
```

3. ��������� ��������

```
dotnet ef database update
```