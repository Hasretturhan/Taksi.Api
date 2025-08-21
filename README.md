# Taksi Uygulaması Backend (ASP.NET Core + EF Core)

Katmanlı mimari ile geliştirilen taksi uygulaması backend’i. Aşağıdaki varlıklar için REST API sunar:

- **Passenger**, **Driver**
- **Vehicle**
- **Address**
- **Trip**
- **Payment**
- **Coupon**, **Bonus**
- **SupportRequest**

> ✅ Repository + Service deseni  
> ✅ Dependency Injection  
> ✅ SQL Server (EF Core)  
> ✅ Swagger/OpenAPI  
> ✅ Nullable Reference Types uyumlu

---

## Mimari ve Katmanlar

- **Taksi.Entities**: POCO Entity sınıfları (Passenger, Driver, Trip, vb.)
- **Taksi.Data**: `TaksiDbContext` ve **Repository** uygulamaları
- **Taksi.Business**: **Service** katmanı (iş kuralları, doğrulamalar, hashing/maskleme/ücret hesaplama)
- **Taksi.Api**: Controller’lar (REST uç noktaları, Swagger)

> Repository’lerde `GetByIdAsync` dönüşleri `Task<T?>` şeklindedir (EF `FindAsync` null döndürebilir).  
> Service katmanı; şifre **hashleme**, kart numarası **maskleme**, ücret **hesaplama** gibi teknik işlevleri üstlenir.

---

## Teknolojiler

- **.NET** 7/8 (ASP.NET Core Web API)
- **Entity Framework Core** (SQL Server)
- **Swagger / Swashbuckle**
- **Dependency Injection**, **LINQ**
- **Nullable Reference Types** açık

---
