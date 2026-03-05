# 🚀 MicroCommerce API - .NET 8 Clean Architecture

MicroCommerce, kurumsal standartlarda geliştirilmiş, ölçeklenebilir ve sürdürülebilir bir E-Ticaret Backend sistemidir. Bu proje, sadece kod yazmak için değil; doğru mimari desenlerin (Design Patterns) ve modern yazılım prensiplerinin (SOLID) bir araya getirilmesi amacıyla tasarlanmıştır.

---

## 🏗️ Mimari Yapı (Clean Architecture)

Bu proje **"Onion Architecture" (Soğan Mimarisi)** prensibiyle 4 ana katmandan oluşur. Bu sayede iş mantığı (Business Logic), veritabanı veya API teknolojilerinden tamamen bağımsızdır.

-   **Domain:** Projenin kalbi. Entity'ler, enum'lar ve arayüzler yer alır. Hiçbir dış bağımlılığı yoktur.
-   **Application:** CQRS pattern (MediatR) ile iş mantığının yönetildiği katman. DTO'lar, Validator'lar ve Mapper'lar burada bulunur.
-   **Infrastructure:** Veritabanı (EF Core), Repository implementasyonları ve Identity servislerinin yer aldığı katman.
-   **WebAPI:** Dış dünyaya açılan kapı. Middleware yönetimi, JWT yapılandırması ve Controller'lar bu katmandadır.

---

## 🛠️ Kullanılan Teknolojiler ve Yapılar

| Teknoloji | Açıklama |
| :--- | :--- |
| **.NET 8** | Modern, yüksek performanslı cross-platform çalışma ortamı. |
| **PostgreSQL** | Güçlü, açık kaynaklı ilişkisel veritabanı. |
| **EF Core** | Code-First yaklaşımı ile gelişmiş ORM yönetimi. |
| **MediatR (CQRS)** | Komut ve sorguların ayrılması, kodun daha temiz ve test edilebilir olması. |
| **ASP.NET Core Identity** | Kurumsal düzeyde kullanıcı ve rol yönetimi altyapısı. |
| **JWT Authentication** | Stateless (durumsuz) ve güvenli kimlik doğrulama. |
| **FluentValidation** | Merkezi ve güçlü veri doğrulama yönetimi. |
| **AutoMapper** | Nesneler arası (Entity <-> DTO) otomatik dönüşüm. |

---

## 🔥 Öne Çıkan Özellikler

-   ✅ **Global Exception Handling:** Tüm hatalar merkezi bir Middleware üzerinden yakalanır ve kullanıcıya standart bir formatta dönülür.
-   ✅ **Soft Delete:** Veriler fiziksel olarak silinmez, `IsDeleted` flag'i ile işaretlenir ve otomatik olarak filtrelenir.
-   ✅ **MediatR Pipeline Behaviors:** Tüm istekler handler'a ulaşmadan önce otomatik olarak doğrulanır (Validation) ve çalışma süreleri loglanır (Logging).
-   ✅ **Swagger Security:** Swagger UI üzerinden JWT Token ile yetkilendirme (Authorize) desteği.
-   ✅ **Generic Repository & Unit of Work:** Veritabanı işlemlerinde kod tekrarını önleyen ve transactional bütünlüğü sağlayan yapılar.

---

## 🚀 Başlangıç

### 1. Veritabanı Yapılandırması
`appsettings.json` dosyasındaki bağlantı dizesini kendi PostgreSQL bilgilerinizle güncelleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=MicroCommerceDb;Username=postgres;Password=YOUR_PASSWORD"
}
```

### 2. Migration Uygulama
Terminalde aşağıdaki komutları sırasıyla çalıştırarak veritabanınızı oluşturun:

```bash
dotnet ef migrations add InitialCreate --project src/MicroCommerce.Infrastructure --startup-project src/MicroCommerce.WebAPI
dotnet ef database update --project src/MicroCommerce.Infrastructure --startup-project src/MicroCommerce.WebAPI
```

### 3. Projeyi Çalıştırma
```bash
dotnet run --project src/MicroCommerce.WebAPI
```
Uygulama çalıştıktan sonra `https://localhost:{port}/index.html` adresinden Swagger arayüzüne erişebilirsiniz.

---

## 📂 Proje Klasör Yapısı

```text
MicroCommerce/
├── src/
│   ├── MicroCommerce.Domain         # Entities, Enums, Interfaces
│   ├── MicroCommerce.Application    # CQRS, DTOs, Handlers, Validators
│   ├── MicroCommerce.Infrastructure # Data Access, Identity, Persistence
│   └── MicroCommerce.WebAPI         # Controllers, Middlewares, Program.cs
└── MicroCommerce.sln
```

---

## 📄 Lisans
Bu proje eğitim amaçlı geliştirilmiş olup her türlü geliştirmeye açıktır.
