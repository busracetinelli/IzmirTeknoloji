## 🧠 İzmir Teknoloji ve İnovasyon – Sayı İşlemleri Web Projesi

Bu proje, kullanıcıların giriş yaparak sisteme sayı göndermelerini, en büyük asal sayının hesaplanmasını ve işlem geçmişlerini görmelerini sağlar. Ayrıca admin kullanıcılar tüm işlem geçmişlerini görüntüleyebilir.

---

### 🏗️ Proje Mimarisi

- **Frontend**: ASP.NET Core MVC (Razor View)
- **Backend**: ASP.NET Core Web API (.NET 6)
- **Authentication**: JWT Token
- **Authorization**: Role-based (Admin / User)
- **Database**: Entity Framework Core (SQL Server)
- **UI**: Bootstrap + KaiAdmin Teması
- **Mimari Yapı**: Onion Architecture + CQRS + MediatR

---

### 🚀 Başlıca Özellikler

| Özellik               | Açıklama                                                                            |
| --------------------- | ----------------------------------------------------------------------------------- |
| 🧑‍💻 Kullanıcı Kaydı | Yeni kullanıcı oluşturur, ardından otomatik olarak giriş yapar.                     |
| 🔐 JWT Tabanlı Giriş  | Giriş yapan kullanıcıya JWT token verilir ve frontend’de session’a yazılır.         |
| 🧠 Sayı Gönderme      | Giriş yapan kullanıcı, sayı göndererek en büyük asal sayıyı hesaplatır.             |
| 📜 İşlem Geçmişi      | Kullanıcı kendi işlem geçmişini; admin ise tüm kullanıcılarınkini görebilir.        |
| 🛡️ Rol Yönetimi      | İlk kayıt olan kullanıcıya `User` rolü verilir. `Admin` rolü veritabanından atanır. |
| 🧰 CQRS + MediatR     | Tüm işlemler ayrı `Command` ve `Query` handler'ı üzerinden yönetilir.               |

---

### ⚙️ Kurulum Adımları

#### 1. Klonla

```bash
git clone https://github.com/kullaniciadi/proje-adi.git
```

#### 2. Backend Ayarları (API Projesi)

- `appsettings.json` içerisine doğru connection string girilmelidir.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=IzmirTeknoloji;Trusted_Connection=True;"
}
```

- Migration ve DB oluşturma:

```bash
cd backend-projesi
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### 3. Frontend Ayarları (MVC)

- Razor View’lar sadece API ile iletişim kurar.
- `Session` kullanımı için:

```csharp
services.AddSession();
app.UseSession();
```

#### 4. Projeyi Çalıştır:

```bash
dotnet run --project BackendProjesi
dotnet run --project FrontendProjesi
```

---

### 🧰 CQRS ve MediatR Kullanımı

Backend projesi, **CQRS (Command Query Responsibility Segregation)** desenine göre yapılandırılmıştır.\
Bu yapı sayesinde her iş mantığı işlemi (kayıt ekleme, güncelleme, listeleme vs.) ayrı bir **Command/Query Handler** üzerinden yönetilir.

#### Örnekler:

- `RegisterUserCommandHandler`
- `LoginQueryHandler`
- `CreateTransactionCommandHandler`
- `GetUserTransactionsQueryHandler`

#### Kullanılan Temel Araçlar:

- `MediatR` – Handler altyapısı
- `FluentValidation` – Request doğrulama
- `JWT` – Token üretimi

---

### 📦 Kullanılan NuGet Paketleri

| Paket                                                                | Açıklama                    |
| -------------------------------------------------------------------- | --------------------------- |
| `Microsoft.AspNetCore.Authentication.JwtBearer`                      | JWT tabanlı oturum yönetimi |
| `Microsoft.EntityFrameworkCore.SqlServer`                            | EF Core SQL Server Provider |
| `MediatR` / `MediatR.Extensions.Microsoft.DependencyInjection`       | CQRS altyapısı              |
| `FluentValidation`                                                   | Form ve API istek doğrulama |
| `System.IdentityModel.Tokens.Jwt`                                    | JWT token işleme            |
| `Newtonsoft.Json`                                                    | JSON işlemleri (opsiyonel)  |

---

### 🔐 Oturum Yönetimi

- Giriş başarılıysa `accessToken` session’a kaydedilir.
- Token doğrulama tüm API isteklerinde `Authorization: Bearer {token}` ile yapılır.
- Kullanıcı email’i ve rolü session’da saklanır.

---

### 📊 Veritabanı Tabloları

- `Users`
- `TransactionHistory`
- `LoginHistory`
- `Roles` (Admin / User)

---

### 🧪 Test Kullanıcıları

| E-posta                                                        | Şifre        | Rol   |
| -------------------------------------------------------------- | ------------ | ----- |
| [deneme@deneme.com](mailto\:deneme@deneme.com)                 | deneme.123\* | User  |
| [busracetinellii@gmail.com](mailto\:busracetinellii@gmail.com) | Busra.123\*  | Admin |

> `Admin` rolü veritabanı üzerinden atanmalıdır.

---

### 👩‍💼 Geliştirici

> Bu proje İzmir Teknoloji ve İnovasyon için [**Büşra Çetinelli**](https://www.linkedin.com/in/busracetinelli/) tarafından geliştirilmiştir.

