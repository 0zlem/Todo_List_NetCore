# Todo List - .NET 9 (Clean Architecture)

Bu proje, .NET 9 kullanılarak Clean Architecture prensipleri ile geliştirilmiş bir Todo List Web API uygulamasıdır. Proje katmanlı mimari ile düzenlenmiştir ve PostgreSQL veritabanı ile çalışmaktadır.

## Özellikler

- **Todo CRUD İşlemleri**: Todo oluşturma, listeleme, güncelleme ve silme.
- **Katmanlı Mimari**: Domain, Application, Infrastructure ve WebAPI katmanları.
- **CQRS & MediatR**: Komut ve sorgular MediatR ile yönetilir.
- **Form & Input Doğrulama**: FluentValidation ile veri doğrulama.
- **Veritabanı Yönetimi**: EF Core ve PostgreSQL ile veri yönetimi.
- **OData & Swagger**: API endpoint’leri için filtreleme, sıralama ve dokümantasyon.

## Kullanılan Teknolojiler

- **.NET 9.0** – Backend framework
- **ASP.NET Core Web API** – API katmanı
- **Entity Framework Core 9.0** – ORM
- **PostgreSQL (Npgsql)** – Veritabanı
- **MediatR** – CQRS tabanlı komut ve sorgular
- **FluentValidation** – Input doğrulama
- **OData** – Endpoint filtreleme ve sıralama
- **Swagger/OpenAPI** – API dokümantasyonu

## Kurulum

1. Depoyu klonlayın:

```bash
git clone https://github.com/0zlem/Todo_List_NetCore.git
cd Todo_List_NetCore
