# VELTRIS

## Enterprise Security Intelligence Platform

VELTRIS; tehdit, olay, zafiyet ve varlık yönetimini risk analizi ve AI destekli güvenlik değerlendirmesiyle birleştiren modern güvenlik istihbarat platformudur.

### Durum

Referans ürün altyapısı hazırlanmıştır.

### Teknolojiler

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Authentication / Authorization
- Next.js 16
- React 19
- TypeScript
- Tailwind CSS
- Swagger / OpenAPI

### Modüller

- Kimlik doğrulama
- İlk kurulum
- Yönetici rolü ve yetkileri
- Dashboard
- Tehdit yönetimi
- Olay yönetimi
- Zafiyet yönetimi
- Varlık yönetimi
- Risk motoru
- AI risk analiz altyapısı

### İlk Kurulum

VELTRIS sabit veya demo kullanıcı hesabıyla teslim edilmez.

İlk çalıştırmada müşteri kendi gerçek hesabını oluşturur. Yönetici rolü ve sistem yetkileri otomatik bağlanır.

### Güvenlik

Kaynak kodunda müşteri parolası, VPS bilgisi, domain bilgisi veya production secret bulunmaz.

Sahte tehdit, olay, zafiyet ve varlık verisi eklenmez.

### Production

Müşteri ortamında VPS, domain, SSL, PostgreSQL, DNS ve gerekli harici servisler ayrıca yapılandırılır.

### Frontend

/
 /tehditler
 /olaylar
 /zafiyetler
 /varliklar
 /risk
 /ai

### Geliştirici

Yazılım Uzmanı Merve Kılıç

Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç
