## 🚗 CarFlowX

> 🎓 Bu proje, **Murat Yücedağ** hocamızın hazırladığı  
> **"Asp.Net Core Api 8.0 Onion Architecture ile BookCar Projesi"** eğitim serisi kapsamında geliştirilmiştir.

[📺 Eğitim serisine buradan ulaşabilirsiniz](https://www.udemy.com/course/aspnet-core-api-8-onion-architecture-ile-bookcar-projesi/)

---

## 📋 Proje Hakkında

**CarFlowX**, ASP.NET Core 8.0 kullanılarak geliştirilmiş bir araç kiralama web uygulamasıdır. Uygulama, Onion Architecture ile tasarlanmış olup Microsoft SQL Server veritabanı üzerinde çalışmaktadır.

**CarFlowX**, hem müşteriler hem de yöneticiler için kapsamlı bir platform sunar. Müşteriler; lokasyon, tarih ve saat seçerek uygun araçları listeleme, araç detaylarını inceleme, rezervasyon oluşturma, blog okuma ve iletişim formu gönderme gibi işlemleri yapabilirken, yöneticiler admin paneli üzerinden araçları, rezervasyonları, içerikleri ve fiyatlandırmayı merkezi biçimde yönetebilmektedir.

Projenin teknik altyapısında **CQRS** ve **MediatR** ile komut–sorgu ayrımı sağlanmış, **FluentValidation** ile doğrulama kuralları uygulanmıştır. **SignalR** entegrasyonu sayesinde sistemdeki bazı istatistikler (örneğin araç sayısı gibi veriler) gerçek zamanlı olarak istemcilere iletilmektedir. Kimlik doğrulama işlemleri ise **JWT** kullanılarak gerçekleştirilmiştir.

Bu proje, ASP.NET Core ekosistemindeki modern mimari yaklaşımları ve tasarım desenlerini öğrenmek ve uygulamak amacıyla geliştirilmiş bir eğitim projesidir.

---

## 🛠️ Kullanılan Teknolojiler

### 🔧 Backend (Web API)
- ASP.NET Core 8.0 Web API
- Swagger
- MediatR
- FluentValidation

### 🎨 Frontend (Web UI)
- HTML5
- CSS3
- JavaScript
- Bootstrap
- jQuery
- SignalR JavaScript Client
- Chart.js

### 🧩 Veri Yönetimi
- DTO katmanı
- CQRS & MediatR pattern

### 🗄️ Veritabanı
- SQL Server

### 🔐 Kimlik Doğrulama
- JWT Bearer Authentication
- Cookie tabanlı token yönetimi

### 📡 Gerçek Zamanlı İletişim
- SignalR (araç sayısının canlı güncellenmesi)

## 🏗️ Mimari
Onion Architecture sayesinde bağımlılıklar merkeze doğru yönelir. 
Domain katmanı dış katmanlardan tamamen bağımsızdır ve iş kuralları burada tanımlanır. 
Application katmanı iş akışlarını yönetirken, Persistence katmanı veri erişimini sağlar. 
Presentation katmanları ise API ve kullanıcı arayüzü üzerinden sisteme erişimi sağlar.

| Katman | Proje | Açıklama |
|--------|-------|----------|
| **Core** | CarFlowX.Domain | Varlıklar (Car, Brand, Reservation, Blog vb.) |
| **Core** | CarFlowX.Application | CQRS/MediatR komutları, sorgular ve handler'lar |
| **Infrastructure** | CarFlowX.Persistence | EF Core, repository implementasyonları |
| **Presentation** | CarFlowX.WebApi | REST API ve SignalR Hub'ları |
| **Frontends** | CarFlowX.WebUI | MVC arayüzü |
| **Dtos** | CarFlowX.Dto | Veri transfer nesneleri (DTO) |

---

## 🖼️ Ekran Görüntüleri

### 🏠 Kullanıcı Arayüzü

<div align="center">
  <img src="Images/AnaSayfa-1.png" alt="Kullanıcı Paneli-1" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-2.png" alt="Kullanıcı Paneli-2" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-3.png" alt="Kullanıcı Paneli-3" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-4.png" alt="Kullanıcı Paneli-4" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-5.png" alt="Kullanıcı Paneli-5" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-6.png" alt="Kullanıcı Paneli-6" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-7.png" alt="Kullanıcı Paneli-7" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-8.png" alt="Kullanıcı Paneli-8" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-9.png" alt="Kullanıcı Paneli-9" width="800" style="margin: 10px;">
  <img src="Images/AnaSayfa-10.png" alt="Kullanıcı Paneli-10" width="800" style="margin: 10px;">
</div>


### 🔐 Admin Paneli

<div align="center">
  <img src="Images/AdminDashboard-1.png" alt="Admin Paneli-1" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-2.png" alt="Admin Paneli-2" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-3.png" alt="Admin Paneli-3" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-4.png" alt="Admin Paneli-4" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-5.png" alt="Admin Paneli-5" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-6.png" alt="Admin Paneli-6" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-7.png" alt="Admin Paneli-7" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-8.png" alt="Admin Paneli-8" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-9.png" alt="Admin Paneli-9" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-10.png" alt="Admin Paneli-10" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-11.png" alt="Admin Paneli-11" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-12.png" alt="Admin Paneli-12" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-13.png" alt="Admin Paneli-13" width="800" style="margin: 10px;">
  <img src="Images/AdminDashboard-14.png" alt="Admin Paneli-14" width="800" style="margin: 10px;">
</div>

### 🔑 Login ve Register Sayfası

<div align="center">
  <img src="Images/Login.png" alt="Login Sayfası" width="600" style="margin: 10px;">
  <img src="Images/Register.png" alt="Register Sayfası" width="600" style="margin: 10px;">
</div>

### 🗄️ Database Diyagram

<div align="center">
  <img src="Images/Db.png" alt="Database Diyagram" width="1000" style="margin: 10px;">
</div>
