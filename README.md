# Test Task Iron Water Studio

### ��������������� ����������

.NET 7

### ���������

1. �������� ����������� ������� NuGet

```bash
dotnet restore

2. �������� ���� appsettings.json � �������� ������ ����������� � ������������ � ������������� ����� ���� ������.

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  // ������ ���������...
}

3. ��������� ��������

```bash
dotnet ef database update