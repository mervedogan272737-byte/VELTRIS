VELTRIS
Enterprise Security Intelligence Platform

Kurumsal güvenlik operasyonları için tehdit, olay, zafiyet, varlık, risk ve yapay zekâ destekli güvenlik analizini tek platformda birleştiren modüler Security Intelligence platformu.

Platform Durumu
Bileşen	Durum
Kimlik doğrulama	✅ Hazır
JWT Authentication	✅ Hazır
JWT Authorization	✅ Hazır
İlk kurulum sistemi	✅ Hazır
Yönetici rolü	✅ Hazır
Yetki modeli	✅ Hazır
Dashboard	✅ Hazır
Tehdit yönetimi	✅ Hazır
Olay yönetimi	✅ Hazır
Zafiyet yönetimi	✅ Hazır
Varlık yönetimi	✅ Hazır
Risk motoru	✅ Hazır
AI risk analiz altyapısı	✅ Hazır
PostgreSQL	✅ Hazır
Entity Framework Core	✅ Hazır
Swagger / OpenAPI	✅ Hazır
Production API Publish	✅ Hazır
Next.js Production Build	✅ Hazır
1. Sistem Mimarisi
                    VELTRIS PLATFORM
                           │
                           ▼
                ┌─────────────────────┐
                │     Next.js Web     │
                │ React + TypeScript  │
                └──────────┬──────────┘
                           │
                        HTTPS
                           │
                           ▼
                ┌─────────────────────┐
                │    ASP.NET Core     │
                │      REST API       │
                └──────────┬──────────┘
                           │
          ┌────────────────┼────────────────┐
          │                │                │
          ▼                ▼                ▼
     Authentication   Security Core     AI Layer
     Authorization    Risk Engine       Analysis
          │                │                │
          └────────────────┼────────────────┘
                           │
                           ▼
                ┌─────────────────────┐
                │ Entity Framework    │
                │      Core           │
                └──────────┬──────────┘
                           │
                           ▼
                ┌─────────────────────┐
                │      PostgreSQL     │
                └─────────────────────┘
2. Teknoloji Stack
Backend
.NET 10
ASP.NET Core Web API
C#
Entity Framework Core 10
Npgsql
PostgreSQL
JWT Bearer Authentication
Swagger / OpenAPI
Dependency Injection
Middleware
Async / Await
CancellationToken
Frontend
Next.js 16
React 19
TypeScript
Tailwind CSS
Lucide React
Recharts
Infrastructure
Docker
Docker Compose
PostgreSQL Container
Git
GitHub
PowerShell
Visual Studio Code
3. Proje Klasör Yapısı
VELTRIS/
│
├── apps/
│   │
│   ├── api/
│   │   ├── Application/
│   │   │   ├── Ai/
│   │   │   ├── Auth/
│   │   │   ├── Dashboard/
│   │   │   ├── Guvenlik/
│   │   │   ├── Kurulum/
│   │   │   └── Services/
│   │   │
│   │   ├── Controllers/
│   │   ├── Domain/
│   │   │   └── Entities/
│   │   ├── Infrastructure/
│   │   │   ├── Data/
│   │   │   ├── Health/
│   │   │   └── Security/
│   │   ├── Middleware/
│   │   ├── Migrations/
│   │   ├── Models/
│   │   ├── Program.cs
│   │   └── Veltris.Api.csproj
│   │
│   └── web/
│       ├── public/
│       ├── src/
│       │   ├── app/
│       │   ├── components/
│       │   ├── config/
│       │   ├── lib/
│       │   └── types/
│       ├── package.json
│       └── next.config.ts
│
├── infrastructure/
│   └── postgres/
│       ├── docker-compose.yml
│       └── .env.example
│
├── README.md
└── .gitignore
4. Kimlik Doğrulama

VELTRIS JWT tabanlı authentication kullanır.

Kullanıcı
   │
   ▼
E-posta + Şifre
   │
   ▼
POST /api/kimlik/giris
   │
   ▼
Parola Hash Doğrulaması
   │
   ▼
Kullanıcı
   │
   ▼
Rol
   │
   ▼
Yetkiler
   │
   ▼
JWT
   │
   ▼
Authenticated Session

JWT içerisinde:

Kullanıcı kimliği
Kurum kimliği
E-posta
Roller
Yetkiler

taşınacak şekilde yapılandırılmıştır.

5. İlk Kurulum Sistemi

VELTRIS sabit kullanıcı veya demo hesapla teslim edilmez.

Kullanıcı sayısı = 0
        │
        ▼
İlk Kurulum
        │
        ▼
Gerçek kullanıcı bilgileri
        │
        ▼
Kullanıcı oluştur
        │
        ▼
Yönetici rolü oluştur
        │
        ▼
Sistem yetkilerini oluştur
        │
        ▼
Kullanıcı → Yönetici
        │
        ▼
JWT
        │
        ▼
Dashboard

İlk kurulum endpointleri:

GET  /api/kurulum/durum
POST /api/kurulum/yonetici
6. Rol ve Yetki Sistemi
Kullanıcı
    │
    ▼
KullanıcıRol
    │
    ▼
Rol
    │
    ▼
RolYetki
    │
    ▼
Yetki

Yönetici rolü için temel sistem yetkileri:

dashboard.goruntule

tehdit.goruntule
tehdit.olustur
tehdit.guncelle
tehdit.sil

olay.goruntule
olay.olustur
olay.guncelle
olay.sil

zafiyet.goruntule
zafiyet.olustur
zafiyet.guncelle
zafiyet.sil

varlik.goruntule
varlik.olustur
varlik.guncelle
varlik.sil

risk.goruntule
ai.goruntule

kullanici.yonet
rol.yonet

Genişletilebilir roller:

Administrator
Security Manager
SOC Analyst
Security Analyst
Auditor
Viewer
7. Kurum Modeli

VELTRIS veri modelinde Kurum tenant sınırı olarak kullanılır.

Kurum
│
├── Kullanıcılar
├── Tehditler
├── Olaylar
├── Zafiyetler
└── Varlıklar

Bu yapı müşteri verilerinin kurum bazında ayrıştırılmasını destekleyecek şekilde tasarlanmıştır.

8. Tehdit Yönetimi

Tehdit modeli:

GuvenlikTehdidi
│
├── Id
├── KurumId
├── Baslik
├── Aciklama
├── Kaynak
├── Seviye
├── Durum
├── RiskSkoru
├── Gosterge
├── OlusturulmaTarihiUtc
└── GuncellenmeTarihiUtc

API:

GET    /api/tehditler
POST   /api/tehditler
PUT    /api/tehditler/{id}
DELETE /api/tehditler/{id}
9. Olay Yönetimi

Olay modeli:

GuvenlikOlayi
│
├── Id
├── KurumId
├── Baslik
├── Aciklama
├── Oncelik
├── Durum
├── RiskSkoru
├── TehditId
├── OlusturulmaTarihiUtc
└── GuncellenmeTarihiUtc

API:

GET    /api/olaylar
POST   /api/olaylar
PUT    /api/olaylar/{id}
DELETE /api/olaylar/{id}

Tehdit ve olay ilişkisi risk analizinde kullanılabilir.

10. Zafiyet Yönetimi

Zafiyet modeli:

GuvenlikZafiyeti
│
├── Id
├── KurumId
├── Baslik
├── CveKodu
├── CvssSkoru
├── Seviye
├── Durum
├── EtkilenenVarlikSayisi
├── CozumNotu
├── OlusturulmaTarihiUtc
└── GuncellenmeTarihiUtc

API:

GET    /api/zafiyetler
POST   /api/zafiyetler
PUT    /api/zafiyetler/{id}
DELETE /api/zafiyetler/{id}
11. Varlık Yönetimi

Varlık modeli:

GuvenlikVarligi
│
├── Id
├── KurumId
├── Ad
├── VarlikTuru
├── HostAdi
├── IpAdresi
├── IsletimSistemi
├── Kritiklik
├── Durum
├── OlusturulmaTarihiUtc
└── GuncellenmeTarihiUtc

API:

GET    /api/varliklar
POST   /api/varliklar
PUT    /api/varliklar/{id}
DELETE /api/varliklar/{id}

Desteklenebilecek varlık tipleri:

Server
Endpoint
Database
Application
Network Device
Cloud Resource
Container
Workstation
12. Risk Motoru

Temel girdiler:

Threat Risk
Incident Risk
Vulnerability Risk
Asset Criticality

Genel akış:

Threat Data
    +
Incident Data
    +
Vulnerability Data
    +
Asset Context
    │
    ▼
Risk Engine
    │
    ▼
Risk Score
    │
    ▼
Risk Level

Risk skorları:

0 - 39     Düşük
40 - 69    Orta
70 - 89    Yüksek
90 - 100   Kritik

API:

GET /api/risk/ozet
13. AI Katmanı

AI katmanı VELTRIS çekirdeğinden ayrıştırılmıştır.

VELTRIS Security Data
        │
        ▼
Risk Engine
        │
        ▼
AI Analysis Layer
        │
        ▼
Security Interpretation
        │
        ▼
Analyst Decision Support

Kullanım alanları:

Risk özetleme
Olay açıklama
Tehdit yorumlama
Zafiyet değerlendirme
Güvenlik analizi
Analist karar desteği
Doğal dil güvenlik raporları

AI sağlayıcısı production ortamında müşteri ihtiyaçlarına göre yapılandırılabilir.

14. Dashboard

Dashboard bileşenleri:

Güvenlik Skoru
Aktif Tehditler
Açık Olaylar
Zafiyetler

Güvenlik Aktivitesi

AI Risk Analizi

Aktif Tehditler

Canlı Aktivite

AI Motoru
Veri İşleme
Sensör Ağı

API:

GET /api/dashboard/ozet
15. API Endpointleri
Kimlik
GET  /api/kimlik/durum
POST /api/kimlik/giris
GET  /api/kimlik/ben
Kurulum
GET  /api/kurulum/durum
POST /api/kurulum/yonetici
Dashboard
GET /api/dashboard/ozet
Tehdit
GET    /api/tehditler
POST   /api/tehditler
PUT    /api/tehditler/{id}
DELETE /api/tehditler/{id}
Olay
GET    /api/olaylar
POST   /api/olaylar
PUT    /api/olaylar/{id}
DELETE /api/olaylar/{id}
Zafiyet
GET    /api/zafiyetler
POST   /api/zafiyetler
PUT    /api/zafiyetler/{id}
DELETE /api/zafiyetler/{id}
Varlık
GET    /api/varliklar
POST   /api/varliklar
PUT    /api/varliklar/{id}
DELETE /api/varliklar/{id}
Analiz
GET /api/risk/ozet
GET /api/ai/risk-analizi
16. Frontend Routes
/
├── /tehditler
├── /olaylar
├── /zafiyetler
├── /varliklar
├── /risk
└── /ai
17. Frontend API Katmanı

Dosya:

apps/web/src/lib/api/veltris-api.ts

Sorumluluklar:

API adresi yönetimi
HTTP istekleri
Timeout yönetimi
JSON parsing
HTTP hata yönetimi
JWT Bearer token
Login
Kullanıcı bilgisi
Dashboard
Modül API çağrıları
18. PostgreSQL

Veri akışı:

ASP.NET Core
      │
      ▼
Entity Framework Core
      │
      ▼
Npgsql
      │
      ▼
PostgreSQL

Migration geçmişi:

BaslangicVeritabani
DomainModeli
GuvenlikModulleri

Database değişiklikleri EF Core migration üzerinden uygulanır.

19. Veri Modeli
Kurum
│
├── Kullanici
│   └── KullaniciRol
│       └── Rol
│           └── RolYetki
│               └── Yetki
│
├── GuvenlikTehdidi
├── GuvenlikOlayi
├── GuvenlikZafiyeti
└── GuvenlikVarligi
20. Güvenlik
Authentication

JWT Bearer Authentication.

Authorization

Rol ve yetki tabanlı erişim.

Password

Plaintext parola tutulmaz.

Tenant Isolation

Kurum bazlı veri modeli.

Secrets

Production secret değerleri repository içerisinde tutulmaz.

Error Handling

Merkezi middleware yaklaşımı.

API Protection

Yetkili operasyonlarda [Authorize].

21. Secret Yönetimi

Repository içerisine gerçek değerlerle aşağıdaki bilgiler eklenmez:

Database Password
JWT Secret
AI API Key
Cloud Credential
VPS Password
SSH Private Key
SMTP Password
Third-Party API Secret

Development:

appsettings.Development.json
.env

Production:

Environment Variables
Secret Store
Vault
Cloud Secret Manager
22. Docker PostgreSQL
infrastructure/postgres/
│
├── docker-compose.yml
└── .env.example

Başlatma:

docker compose -f infrastructure/postgres/docker-compose.yml up -d
23. Lokal Kurulum
Gereksinimler
.NET 10
Node.js
npm
Docker
PostgreSQL
Git
PowerShell
PostgreSQL
Copy-Item infrastructure\postgres\.env.example infrastructure\postgres\.env

Local .env içerisinde PostgreSQL parolası belirlenir.

docker compose -f infrastructure/postgres/docker-compose.yml up -d
Database
dotnet ef database update --project apps/api/Veltris.Api.csproj
API
dotnet run --project apps/api/Veltris.Api.csproj
Frontend
cd apps/web
npm install
npm run dev
24. Production Build
API
dotnet publish apps/api/Veltris.Api.csproj `
  --configuration Release `
  --output apps/api/bin/Release/net10.0/publish
Frontend
cd apps/web
npm run build
npm run start
25. Production Mimarisi
                        INTERNET
                            │
                            ▼
                     Reverse Proxy
                  Nginx / Caddy / Cloud
                            │
              ┌─────────────┴─────────────┐
              │                           │
              ▼                           ▼
       Next.js Frontend             ASP.NET Core API
                                          │
                                          ▼
                                      PostgreSQL
                                          │
                         ┌────────────────┼────────────────┐
                         │                │                │
                         ▼                ▼                ▼
                        EDR              SIEM             AI
26. Müşteri Ortamına Ait Bileşenler
VPS
Domain
DNS
SSL/TLS
PostgreSQL
Firewall
Reverse Proxy
EDR
SIEM
IAM
Threat Intelligence
Vulnerability Scanner
AI Provider
SMTP
Object Storage
Cloud Credentials

Bu bilgilerin gerçek değerleri VELTRIS kaynak koduna dahil edilmez.

27. Entegrasyon Mimarisi

Desteklenebilecek güvenlik veri kaynakları:

EDR
SIEM
IAM
Firewall
Network
Threat Intelligence
Vulnerability Scanner
Cloud
Application Logs

Genel akış:

External Security Sources
          │
          ▼
      VELTRIS API
          │
          ▼
Normalization / Processing
          │
          ▼
Security Modules
          │
          ▼
Risk Engine
          │
          ▼
AI Analysis
28. Production Güvenlik Gereksinimleri
HTTPS
JWT Secret Rotation
Strong Database Credentials
Firewall
Database Network Isolation
Reverse Proxy
Least Privilege
RBAC
Backup
Restore Testing
Monitoring
Logging
Secret Management

PostgreSQL production ortamında doğrudan internet erişimine açılmamalıdır.

29. Backup

Önerilen yapı:

Primary PostgreSQL
      │
      ├── Scheduled Backup
      ├── Off-Site Backup
      └── Restore Verification

Backup işlemlerinin düzenli geri yükleme testi yapılmalıdır.

30. Monitoring

Production ortamında:

Application Logs
API Health
Database Health
Request Latency
Authentication Failures
Security Events
Error Tracking
Metrics
Alerting

kullanılabilir.

31. Release Quality Gates
.NET Build
    ↓
EF Migration Check
    ↓
Database Update
    ↓
Frontend Build
    ↓
Secret Scan
    ↓
API Publish
    ↓
Final Release
32. Referans Proje Politikası
Repository içerisinde bulunmaz
❌ Sabit kullanıcı hesabı
❌ Demo hesabı
❌ Sabit production şifresi
❌ Müşteri VPS bilgisi
❌ Müşteri domain bilgisi
❌ Production secret
❌ Gerçek müşteri verisi
❌ Sahte güvenlik verisi
Repository içerisinde bulunur
✅ Authentication altyapısı
✅ Authorization altyapısı
✅ PostgreSQL modeli
✅ EF Core migrations
✅ REST API
✅ Risk motoru
✅ AI entegrasyon noktası
✅ Production build yapısı
33. Ekran Görüntüleri

Önerilen yapı:

docs/
└── screenshots/
    ├── setup.png
    ├── dashboard.png
    ├── threats.png
    ├── incidents.png
    ├── vulnerabilities.png
    ├── assets.png
    ├── risk.png
    └── ai.png
34. Swagger / OpenAPI

Development ortamı:

https://localhost:7043/swagger

Production ortamında Swagger güvenlik politikasına göre:

Disabled

veya:

Internal Access

olarak yapılandırılabilir.

35. Roadmap
Core Platform
✅ Authentication
✅ Authorization
✅ First Setup
✅ Dashboard
✅ Threat Management
✅ Incident Management
✅ Vulnerability Management
✅ Asset Management
✅ Risk Engine
✅ AI Integration Architecture
✅ PostgreSQL
✅ EF Core Migrations
✅ Production Build
Advanced Production Integrations
⬜ SIEM connectors
⬜ EDR connectors
⬜ IAM / SSO
⬜ OIDC / OAuth2
⬜ MFA
⬜ Threat Intelligence feeds
⬜ Vulnerability scanner integrations
⬜ Advanced correlation engine
⬜ Background workers
⬜ Message queue
⬜ Audit trail
⬜ Advanced reporting
⬜ Notification engine
⬜ AI orchestration
⬜ Enterprise monitoring
36. Geliştirici

Yazılım Uzmanı Merve Kılıç

VELTRIS — Enterprise Security Intelligence Platform

Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç

37. Ticari Kullanım

VELTRIS ticari ürün olarak geliştirilmektedir.

Kaynak kodunun izinsiz:

yeniden dağıtılması,
kopyalanması,
satılması,
yeniden markalanması,
ticari ürün olarak sunulması

proje sahibinin izni olmadan yapılamaz.
