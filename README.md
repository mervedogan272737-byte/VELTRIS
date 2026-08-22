# VELTRIS

## Enterprise Security Intelligence Platform

VELTRIS; kurumsal güvenlik operasyonlarının merkezi olarak yönetilmesi amacıyla geliştirilen, tehdit yönetimi, olay yönetimi, zafiyet yönetimi, varlık yönetimi, risk analizi ve yapay zekâ destekli güvenlik değerlendirmesini tek bir platform altında birleştiren modüler Enterprise Security Intelligence platformudur.

VELTRIS'in temel yaklaşımı; güvenlik operasyonlarında farklı kaynaklardan oluşan bilgilerin merkezi bir güvenlik veri modelinde toplanması, güvenlik süreçlerine ayrıştırılması, risk seviyelerine göre değerlendirilmesi ve operasyon ekiplerine karar desteği sağlayacak şekilde sunulmasıdır.

Platformun çekirdek ürün mimarisi tamamlanmış olup müşteri ortamına özel production entegrasyonları bu çekirdek yapı üzerinden uygulanabilecek şekilde tasarlanmıştır.

---

# 1. Ürün Vizyonu

Kurumsal güvenlik ortamlarında tehditler, olaylar, zafiyetler, varlıklar, kullanıcılar, ağ sistemleri ve harici güvenlik servisleri farklı platformlarda bulunabilir.

Bu yapı güvenlik ekiplerinin aşağıdaki sorulara hızlı cevap vermesini zorlaştırabilir:

* Hangi varlıklar kritik?
* Hangi tehditler aktif?
* Hangi olaylar öncelikli?
* Hangi zafiyetler operasyonel açıdan daha riskli?
* Mevcut güvenlik riski hangi bileşenlerden oluşuyor?
* Hangi güvenlik olayları aynı tehdit ile ilişkili?
* Hangi risklerin müdahale önceliği daha yüksek?
* Yapay zekâ destekli analiz ile hangi güvenlik kararları desteklenebilir?

VELTRIS bu problemleri merkezi bir Security Intelligence platformu ile çözmek üzere tasarlanmıştır.

VELTRIS'in temel yaklaşımı:

**Güvenlik Verisi → Normalizasyon → Güvenlik Modülleri → Risk Analizi → AI Analizi → Operasyonel Karar Desteği**

---

# 2. Ürün Kapsamı

VELTRIS çekirdek platformunda aşağıdaki ana sistemler bulunmaktadır:

| Sistem                           | Durum |
| -------------------------------- | ----- |
| Kimlik doğrulama                 | Hazır |
| JWT authentication               | Hazır |
| JWT authorization                | Hazır |
| Rol yönetimi                     | Hazır |
| Yetki yönetimi                   | Hazır |
| İlk kurulum                      | Hazır |
| Gerçek yönetici hesabı oluşturma | Hazır |
| Kurum modeli                     | Hazır |
| Dashboard                        | Hazır |
| Tehdit yönetimi                  | Hazır |
| Olay yönetimi                    | Hazır |
| Zafiyet yönetimi                 | Hazır |
| Varlık yönetimi                  | Hazır |
| Risk motoru                      | Hazır |
| AI analiz altyapısı              | Hazır |
| PostgreSQL veri katmanı          | Hazır |
| Entity Framework Core            | Hazır |
| REST API                         | Hazır |
| Swagger / OpenAPI                | Hazır |
| Next.js web uygulaması           | Hazır |
| Production build                 | Hazır |
| API publish                      | Hazır |
| EF Core migration yapısı         | Hazır |
| Git / GitHub repository yapısı   | Hazır |

Buradaki “hazır” ifadesi çekirdek ürün mimarisinin ve ilgili yazılım bileşenlerinin oluşturulduğunu ifade eder.

Müşteriye özel SIEM, EDR, Threat Intelligence, AI provider, SSO, MFA, cloud, firewall, SMTP, monitoring veya diğer harici servis bağlantıları müşterinin production altyapısına göre ayrıca yapılandırılabilir.

---

# 3. Temel Ürün Modülleri

VELTRIS'in çekirdek güvenlik modülleri:

1. Kimlik ve erişim yönetimi
2. İlk kurulum
3. Kullanıcı ve rol yönetimi
4. Dashboard
5. Tehdit yönetimi
6. Olay yönetimi
7. Zafiyet yönetimi
8. Varlık yönetimi
9. Risk motoru
10. AI güvenlik analiz altyapısı

Bu modüllerin tamamı aynı domain ve veri katmanı üzerinde çalışacak şekilde tasarlanmıştır.

---

# 4. Teknoloji Mimarisi

## Backend

* .NET 10
* ASP.NET Core Web API
* C#
* Entity Framework Core 10
* Npgsql
* PostgreSQL
* JWT Bearer Authentication
* Swagger / OpenAPI
* Dependency Injection
* Middleware pipeline
* Async/Await
* CancellationToken
* REST API

## Frontend

* Next.js 16
* React 19
* TypeScript
* Tailwind CSS
* Lucide React
* Recharts

## Infrastructure

* Docker
* Docker Compose
* PostgreSQL
* Git
* GitHub
* PowerShell
* Visual Studio Code

---

# 5. Sistem Mimarisi

VELTRIS katmanlı bir mimari kullanır.

## Presentation Layer

Next.js ve React tabanlı web uygulaması.

Sorumlulukları:

* Kullanıcı arayüzü
* Dashboard
* Güvenlik modülleri
* İlk kurulum
* Authentication akışı
* API iletişimi
* Kullanıcı oturumu
* Veri görselleştirme

## API Layer

ASP.NET Core Web API.

Sorumlulukları:

* HTTP API
* Authentication
* Authorization
* Request validation
* Controller işlemleri
* API response modelleri
* Güvenlik kontrolleri

## Application Layer

İş kurallarının ve uygulama servislerinin bulunduğu katmandır.

Başlıca alanlar:

* Auth
* Dashboard
* Guvenlik
* Kurulum
* AI
* Services

## Domain Layer

VELTRIS'in temel iş varlıklarını içerir.

Başlıca domain varlıkları:

* Kurum
* Kullanıcı
* Rol
* Yetki
* Kullanıcı Rolü
* Rol Yetkisi
* Güvenlik Tehdidi
* Güvenlik Olayı
* Güvenlik Zafiyeti
* Güvenlik Varlığı

## Infrastructure Layer

Altyapı servislerini içerir.

Başlıca alanlar:

* PostgreSQL
* Entity Framework Core
* Database Context
* Entity configurations
* JWT
* Password hashing
* Health checks
* Database services

---

# 6. Proje Klasör Yapısı

VELTRIS repository yapısı:

```text
VELTRIS/
├── apps/
│   ├── api/
│   │   ├── Application/
│   │   │   ├── Ai/
│   │   │   ├── Auth/
│   │   │   ├── Dashboard/
│   │   │   ├── Guvenlik/
│   │   │   ├── Kurulum/
│   │   │   └── Services/
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
```

---

# 7. Kimlik Doğrulama Mimarisi

VELTRIS JWT Bearer authentication kullanır.

Kimlik doğrulama akışı:

1. Kullanıcı e-posta ve şifresini gönderir.
2. API kullanıcıyı PostgreSQL üzerinden bulur.
3. Parola hash doğrulaması yapılır.
4. Kullanıcının kurumu belirlenir.
5. Kullanıcının rolleri belirlenir.
6. Kullanıcının yetkileri belirlenir.
7. JWT oluşturulur.
8. Frontend token ile authenticated API çağrıları yapar.

JWT yapısında aşağıdaki bilgilerin taşınması desteklenmektedir:

* Kullanıcı kimliği
* Kurum kimliği
* E-posta
* Roller
* Yetkiler

---

# 8. İlk Kurulum Mimarisi

VELTRIS sabit kullanıcı hesabı veya demo hesabı ile teslim edilmez.

İlk kurulum sistemi kullanıcı sayısının sıfır olduğu durumda aktif olur.

Müşteri:

* Adını girer.
* Soyadını girer.
* E-posta adresini girer.
* Güvenli şifresini belirler.

Sistem:

* Kullanıcıyı oluşturur.
* Yönetici rolünü oluşturur.
* Sistem yetkilerini oluşturur.
* Yetkileri yönetici rolüne bağlar.
* Kullanıcıyı yönetici rolüne bağlar.
* JWT oluşturur.
* Kullanıcıyı uygulamaya alır.

Bu yapı sayesinde kaynak kodunda:

* sabit kullanıcı,
* demo kullanıcı,
* sabit parola,
* müşteri production kimliği

bulundurulmasına gerek kalmaz.

---

# 9. İlk Kurulum API

İlk kurulum endpointleri:

* GET `/api/kurulum/durum`
* POST `/api/kurulum/yonetici`

İlk kurulum yalnızca uygulamanın yapılandırılmamış olduğu başlangıç durumunda kullanılmak üzere tasarlanmıştır.

Kurulum tamamlandıktan sonra ikinci bir kullanıcının aynı akışla yönetici hesabı oluşturmasına izin verilmemesi hedeflenmiştir.

---

# 10. Rol ve Yetki Mimarisi

VELTRIS authorization katmanı rol ve yetki ilişkisi üzerine kuruludur.

Temel ilişki:

**Kullanıcı → KullanıcıRol → Rol → RolYetki → Yetki**

Sistem içerisinde yönetici rolü için aşağıdaki yetkiler tanımlanmıştır:

### Dashboard

* dashboard.goruntule

### Tehdit

* tehdit.goruntule
* tehdit.olustur
* tehdit.guncelle
* tehdit.sil

### Olay

* olay.goruntule
* olay.olustur
* olay.guncelle
* olay.sil

### Zafiyet

* zafiyet.goruntule
* zafiyet.olustur
* zafiyet.guncelle
* zafiyet.sil

### Varlık

* varlik.goruntule
* varlik.olustur
* varlik.guncelle
* varlik.sil

### Risk ve AI

* risk.goruntule
* ai.goruntule

### Yönetim

* kullanici.yonet
* rol.yonet

Bu yapı yeni roller ve yeni izinler eklenebilecek şekilde genişletilebilir.

---

# 11. Kurum ve Tenant Modeli

VELTRIS'in temel veri izolasyon modeli `Kurum` varlığıdır.

Bir kurum altında:

* Kullanıcılar
* Tehditler
* Olaylar
* Zafiyetler
* Varlıklar

tutulabilir.

Kurum kimliği kullanıcı ve güvenlik kayıtlarıyla ilişkilendirilerek müşteri verilerinin kurumsal kapsam içerisinde değerlendirilmesine olanak sağlar.

Bu model ileride gerçek multi-tenant production mimarisine genişletilebilir.

---

# 12. Dashboard

VELTRIS dashboard uygulamanın merkezi güvenlik görünümüdür.

Dashboard üzerinde aşağıdaki güvenlik göstergeleri bulunur:

* Güvenlik skoru
* Aktif tehdit sayısı
* Kritik tehdit sayısı
* Açık olay sayısı
* Yüksek öncelikli olay sayısı
* Zafiyet sayısı
* Kritik zafiyet sayısı
* AI motor durumu
* Veri işleme durumu
* Sensör ağı durumu
* Aktif tehdit listesi
* Güvenlik aktiviteleri
* Risk analizi

Dashboard statik demo veri yerine API katmanından gelen güvenlik verileri üzerine kurulmuştur.

---

# 13. Tehdit Yönetimi

Tehdit yönetimi aktif ve geçmiş güvenlik tehditlerinin merkezi yönetimini sağlar.

Tehdit entity alanları:

* Id
* KurumId
* Baslik
* Aciklama
* Kaynak
* Seviye
* Durum
* RiskSkoru
* Gosterge
* OlusturulmaTarihiUtc
* GuncellenmeTarihiUtc

Temel API:

* GET `/api/tehditler`
* POST `/api/tehditler`
* PUT `/api/tehditler/{id}`
* DELETE `/api/tehditler/{id}`

Üretim ortamında Threat Intelligence feed'leri ve diğer güvenlik kaynakları bu modüle bağlanabilir.

---

# 14. Olay Yönetimi

Olay yönetimi güvenlik olaylarının operasyonel olarak takip edilmesini sağlar.

Olay entity alanları:

* Id
* KurumId
* Baslik
* Aciklama
* Oncelik
* Durum
* RiskSkoru
* TehditId
* OlusturulmaTarihiUtc
* GuncellenmeTarihiUtc

Temel API:

* GET `/api/olaylar`
* POST `/api/olaylar`
* PUT `/api/olaylar/{id}`
* DELETE `/api/olaylar/{id}`

Olay ile tehdit arasındaki ilişki risk analizi içerisinde kullanılabilecek şekilde modellenmiştir.

---

# 15. Zafiyet Yönetimi

Zafiyet yönetimi güvenlik açıklarının merkezi olarak yönetilmesini sağlar.

Zafiyet entity alanları:

* Id
* KurumId
* Baslik
* CveKodu
* CvssSkoru
* Seviye
* Durum
* EtkilenenVarlikSayisi
* CozumNotu
* OlusturulmaTarihiUtc
* GuncellenmeTarihiUtc

Temel API:

* GET `/api/zafiyetler`
* POST `/api/zafiyetler`
* PUT `/api/zafiyetler/{id}`
* DELETE `/api/zafiyetler/{id}`

Zafiyet yönetimi ileride vulnerability scanner entegrasyonlarıyla otomatik veri alımına uygun bir veri modeline sahiptir.

---

# 16. Varlık Yönetimi

Varlık yönetimi kurum içerisindeki güvenlik varlıklarının merkezi kayıt sistemidir.

Varlık entity alanları:

* Id
* KurumId
* Ad
* VarlikTuru
* HostAdi
* IpAdresi
* IsletimSistemi
* Kritiklik
* Durum
* OlusturulmaTarihiUtc
* GuncellenmeTarihiUtc

Varlık türleri:

* Server
* Endpoint
* Database
* Application
* Network Device
* Cloud Resource
* Container
* Workstation

Temel API:

* GET `/api/varliklar`
* POST `/api/varliklar`
* PUT `/api/varliklar/{id}`
* DELETE `/api/varliklar/{id}`

---

# 17. Risk Motoru

Risk motoru VELTRIS'in temel karar destek bileşenlerinden biridir.

Risk değerlendirmesinde:

* Tehdit riskleri
* Olay riskleri
* Zafiyet riskleri
* Varlık kritiklik seviyeleri

kullanılır.

Risk motoru farklı güvenlik sinyallerini tek bir risk skoru altında değerlendirmek üzere yapılandırılmıştır.

Risk seviyeleri:

* 0–39: Düşük
* 40–69: Orta
* 70–89: Yüksek
* 90–100: Kritik

Temel API:

* GET `/api/risk/ozet`

Risk motoru ilerleyen production entegrasyonlarından gelen ilave güvenlik sinyalleriyle genişletilebilir.

---

# 18. AI Security Intelligence Katmanı

VELTRIS AI katmanı doğrudan ürünün güvenlik çekirdeğinden ayrıştırılmıştır.

Bu yapı aşağıdaki kullanım alanlarını desteklemek üzere tasarlanmıştır:

* Risk özetleme
* Olay yorumlama
* Tehdit analizi
* Zafiyet yorumlama
* Güvenlik verisi bağlamsallaştırma
* Analist karar desteği
* Doğal dil güvenlik raporları
* Risk açıklaması
* Güvenlik operasyonlarının hızlandırılması

AI katmanının temel amacı mevcut güvenlik verilerini anlamlandırmak ve analistlere karar desteği sağlamaktır.

AI sağlayıcısı müşteri production ortamında müşterinin seçtiği servis veya kurumsal AI altyapısına bağlanabilir.

---

# 19. AI API

Temel analiz endpointi:

* GET `/api/ai/risk-analizi`

Bu endpoint risk motoru çıktısını AI analiz katmanına taşımak üzere tasarlanmıştır.

Production AI bağlantısında kullanılabilecek mimariler:

* Harici AI API
* Enterprise AI Gateway
* Private LLM
* On-Premise AI
* Cloud AI

Seçilen sağlayıcının gerçek API anahtarları repository içerisinde tutulmaz.

---

# 20. REST API Mimarisi

VELTRIS REST API yaklaşımını kullanır.

### Kimlik

* GET `/api/kimlik/durum`
* POST `/api/kimlik/giris`
* GET `/api/kimlik/ben`

### Kurulum

* GET `/api/kurulum/durum`
* POST `/api/kurulum/yonetici`

### Dashboard

* GET `/api/dashboard/ozet`

### Tehdit

* GET `/api/tehditler`
* POST `/api/tehditler`
* PUT `/api/tehditler/{id}`
* DELETE `/api/tehditler/{id}`

### Olay

* GET `/api/olaylar`
* POST `/api/olaylar`
* PUT `/api/olaylar/{id}`
* DELETE `/api/olaylar/{id}`

### Zafiyet

* GET `/api/zafiyetler`
* POST `/api/zafiyetler`
* PUT `/api/zafiyetler/{id}`
* DELETE `/api/zafiyetler/{id}`

### Varlık

* GET `/api/varliklar`
* POST `/api/varliklar`
* PUT `/api/varliklar/{id}`
* DELETE `/api/varliklar/{id}`

### Risk ve AI

* GET `/api/risk/ozet`
* GET `/api/ai/risk-analizi`

---

# 21. Frontend Route Mimarisi

VELTRIS web uygulaması aşağıdaki route'lara sahiptir:

* `/`
* `/tehditler`
* `/olaylar`
* `/zafiyetler`
* `/varliklar`
* `/risk`
* `/ai`

Bu route yapısı güvenlik operasyon modüllerinin ayrı ekranlar halinde yönetilmesini sağlar.

---

# 22. Frontend API Katmanı

Frontend API katmanı:

`apps/web/src/lib/api/veltris-api.ts`

Bu katman:

* API URL yönetimi
* GET/POST istekleri
* Authentication header
* JWT token yönetimi
* Timeout kontrolü
* JSON response yönetimi
* HTTP hata yönetimi
* Login işlemleri
* Kullanıcı bilgileri
* Dashboard verileri
* Güvenlik modülü çağrıları

için merkezi yapı sağlar.

Bu sayede UI bileşenleri doğrudan dağınık HTTP kodları kullanmak yerine ortak API katmanından faydalanır.

---

# 23. PostgreSQL Veri Katmanı

VELTRIS veri erişim zinciri:

ASP.NET Core

→ Entity Framework Core

→ Npgsql

→ PostgreSQL

şeklindedir.

PostgreSQL, platformun kalıcı güvenlik verilerinin ana veri deposudur.

---

# 24. Entity Framework Core

Entity Framework Core VELTRIS'in ORM katmanıdır.

Ana görevleri:

* Entity mapping
* Database queries
* Change tracking
* Migration
* Schema management
* Transaction management
* Relation mapping

---

# 25. Database Migration Sistemi

VELTRIS migration geçmişi:

* BaslangicVeritabani
* DomainModeli
* GuvenlikModulleri

Migration yaklaşımı sayesinde veri modeli değişiklikleri sürümlendirilebilir şekilde uygulanır.

Production deployment sırasında veritabanı değişikliklerinin kontrollü şekilde uygulanması amaçlanır.

---

# 26. Ana Veri Modeli

VELTRIS ana domain ilişkileri:

* Kurum
* Kullanici
* KullaniciRol
* Rol
* RolYetki
* Yetki
* GuvenlikTehdidi
* GuvenlikOlayi
* GuvenlikZafiyeti
* GuvenlikVarligi

Bu yapı authentication, authorization ve security operations katmanlarının aynı domain modeli içinde çalışmasını sağlar.

---

# 27. Güvenlik Mimarisi

VELTRIS security-first yaklaşım kullanır.

Temel güvenlik prensipleri:

* JWT authentication
* Role based authorization
* Permission based authorization
* Password hashing
* Tenant-aware data model
* Centralized error handling
* Secure secret management
* Production secret isolation
* Least privilege
* API access control

Plaintext parola saklanmaz.

---

# 28. Parola Güvenliği

Kullanıcı parolaları plaintext olarak PostgreSQL'e yazılmaz.

Parola:

1. Kullanıcı tarafından girilir.
2. Hash servisine gönderilir.
3. Hash database'e kaydedilir.
4. Login sırasında hash doğrulaması yapılır.

Bu sayede veri tabanında gerçek parola değerlerinin tutulması engellenir.

---

# 29. Secret Yönetimi

Repository içerisinde aşağıdaki gerçek değerler bulunmaz:

* Database password
* JWT secret
* AI API key
* VPS credentials
* SSH private key
* SMTP password
* Cloud credentials
* Third-party API secrets

Development değerleri local configuration üzerinden sağlanabilir.

Production değerleri ise güvenli secret mekanizmaları üzerinden verilmelidir.

Önerilen production mekanizmaları:

* Environment variables
* Secret Store
* Vault
* Cloud Secret Manager

---

# 30. Docker PostgreSQL

PostgreSQL altyapısı:

`infrastructure/postgres/docker-compose.yml`

Environment örneği:

`infrastructure/postgres/.env.example`

Bu yapı local geliştirme ve müşteri ortamına uyarlanabilir PostgreSQL altyapısı sağlamak için hazırlanmıştır.

---

# 31. Lokal Kurulum

Gereksinimler:

* .NET 10
* Node.js
* npm
* Docker
* PostgreSQL
* Git
* PowerShell

PostgreSQL başlatma:

```powershell
docker compose -f infrastructure/postgres/docker-compose.yml up -d
```

Database migration:

```powershell
dotnet ef database update --project apps/api/Veltris.Api.csproj
```

API:

```powershell
dotnet run --project apps/api/Veltris.Api.csproj
```

Frontend:

```powershell
cd apps/web
npm install
npm run dev
```

---

# 32. Production Build

API:

```powershell
dotnet publish apps/api/Veltris.Api.csproj --configuration Release
```

Frontend:

```powershell
cd apps/web
npm run build
npm run start
```

---

# 33. Production Deployment Modeli

VELTRIS çekirdek ürünü customer-independent olarak hazırlanmıştır.

Production ortamında tipik yapı:

* Reverse Proxy
* Next.js Frontend
* ASP.NET Core API
* PostgreSQL
* Firewall
* SSL/TLS
* Monitoring
* Backup

şeklindedir.

Müşteri altyapısına göre Docker veya native deployment modelleri kullanılabilir.

---

# 34. Müşteri Production Ortamı

Ürün çekirdeği tamamlandıktan sonra müşterinin kendi ortamına bağlanabilecek bileşenler:

* VPS
* Domain
* DNS
* SSL
* PostgreSQL
* Firewall
* Reverse Proxy
* SIEM
* EDR
* IAM
* Threat Intelligence
* Vulnerability Scanner
* AI Provider
* SMTP
* Object Storage
* Monitoring
* Alerting

Bu bileşenler VELTRIS çekirdeğinin eksik parçaları değildir.

Bunlar müşteri altyapısına ve müşteri güvenlik operasyonlarına özel production entegrasyonlarıdır.

---

# 35. Harici Güvenlik Entegrasyonları

VELTRIS aşağıdaki güvenlik kaynaklarıyla entegre edilebilecek şekilde tasarlanmıştır:

### SIEM

* Security event
* Correlation result
* Incident
* Alert

### EDR

* Endpoint detection
* Malware alert
* Process event
* Host state

### IAM

* Login events
* Authentication failures
* Identity events
* User lifecycle

### Threat Intelligence

* IP
* Domain
* Hash
* IOC
* Threat indicator

### Vulnerability Scanner

* CVE
* CVSS
* Affected assets
* Remediation status

### Network Security

* Firewall events
* IDS / IPS alerts
* Network anomalies

### Cloud Security

* Cloud assets
* Cloud alerts
* Identity events
* Configuration findings

---

# 36. Entegrasyon Mimarisi

Harici güvenlik verileri aşağıdaki operasyonel zincire bağlanabilir:

Harici Güvenlik Kaynakları

→ VELTRIS API

→ Veri Normalizasyonu

→ Güvenlik Modülleri

→ Risk Motoru

→ AI Analizi

→ Dashboard / Operasyon

Bu mimari sayesinde farklı güvenlik sağlayıcılarından gelen veriler ortak VELTRIS domain modeli içerisinde işlenebilir.

---

# 37. Production Güvenlik Gereksinimleri

Önerilen minimum production güvenliği:

* HTTPS
* Strong database credentials
* JWT secret rotation
* Firewall
* Database isolation
* Reverse proxy
* RBAC
* Least privilege
* Backup
* Restore testing
* Monitoring
* Logging
* Secret management

PostgreSQL doğrudan public internet erişimine açılmamalıdır.

---

# 38. Backup

Production veritabanında düzenli backup politikası uygulanmalıdır.

Önerilen yapı:

* Scheduled backup
* Off-site backup
* Backup retention
* Backup integrity check
* Restore verification

Yedekleme yalnızca yedek dosyasının oluşturulması olarak değerlendirilmemeli, düzenli restore testiyle doğrulanmalıdır.

---

# 39. Monitoring ve Observability

Production deployment sırasında aşağıdaki observability katmanları kullanılabilir:

* Application logs
* API health
* Database health
* Error tracking
* Request latency
* Authentication failures
* Security events
* Metrics
* Alerting

Bu yapı müşterinin mevcut monitoring veya SIEM altyapısına bağlanabilir.

---

# 40. Swagger / OpenAPI

Development ortamında API dokümantasyonu Swagger / OpenAPI üzerinden sunulur.

Development endpoint:

`https://localhost:7043/swagger`

Production ortamında Swagger:

* kapatılabilir,
* internal network'e açılabilir,
* authentication arkasına alınabilir.

---

# 41. Health ve Sistem İzleme

VELTRIS içerisinde sistem sağlığı ve altyapı durumunun kontrol edilebilmesine yönelik servisler bulunmaktadır.

Kontrol edilebilecek temel alanlar:

* API durumu
* Database bağlantısı
* Uygulama durumu
* Sistem servisleri
* Çalışan altyapı bileşenleri

Bu yapı production monitoring sistemleriyle genişletilebilir.

---

# 42. Release Kalite Süreci

VELTRIS release yaklaşımında temel kalite kontrolleri:

1. Backend build
2. Entity Framework migration kontrolü
3. Database update
4. Frontend production build
5. Secret scan
6. API publish
7. Dosya ve deployment kontrolü
8. Release

Amaç production'a hatalı veya eksik build gönderilmesini engellemektir.

---

# 43. Git ve GitHub

VELTRIS source control:

* Git
* GitHub
* main branch

üzerinde tutulmaktadır.

Repository:

https://github.com/mervedogan272737-byte/VELTRIS

Repository public olarak yayınlanmış referans ürün kodunu içermektedir.

---

# 44. Repository Güvenlik Politikası

Repository içerisinde bulunmaz:

* Sabit kullanıcı
* Demo kullanıcı
* Sabit production şifresi
* Gerçek müşteri parolası
* Müşteri VPS bilgisi
* Müşteri domain bilgisi
* Production secret
* Gerçek müşteri verisi
* Gerçek harici servis credential'ı
* Sahte security incident verisi

Repository içerisinde bulunur:

* Authentication altyapısı
* Authorization altyapısı
* Database modeli
* Migration sistemi
* REST API
* Security modules
* Risk engine
* AI integration architecture
* Frontend
* Production build yapılandırması
* İlk kurulum sistemi

---

# 45. Sahte Veri Politikası

VELTRIS referans repository'sine gerçek müşteri verisi eklenmez.

Aynı şekilde güvenlik ürününün gerçek çalışıyormuş izlenimi verecek şekilde sahte:

* Tehdit
* Olay
* Zafiyet
* Varlık
* Incident
* Security alert

kayıtları yüklenmez.

Platform gerçek production verisinin müşteri ortamında sisteme aktarılmasına göre tasarlanmıştır.

---

# 46. Müşteri İlk Kurulum Akışı

Müşteri production ortamında ilk erişimde:

1. VELTRIS açılır.
2. İlk kurulum durumu kontrol edilir.
3. Yönetici hesabı oluşturma ekranı açılır.
4. Gerçek kullanıcı bilgileri girilir.
5. Güvenli şifre belirlenir.
6. Kullanıcı PostgreSQL'e kaydedilir.
7. Yönetici rolü oluşturulur.
8. Sistem yetkileri bağlanır.
9. Kullanıcı role bağlanır.
10. JWT oluşturulur.
11. Dashboard açılır.

Bu işlem ürünün gerçek müşteri hesabı ile kullanılmasını sağlar.

---

# 47. Ürün Yaşam Döngüsü

VELTRIS kullanım modeli:

**Kurulum → Yapılandırma → Entegrasyon → Güvenlik Verisi → Risk Analizi → Operasyon → İzleme**

Kurulum aşaması VELTRIS çekirdek ürününün standart kısmıdır.

Entegrasyon ve production yapılandırmaları ise müşteri ortamına göre değişebilir.

---

# 48. Ölçeklenebilirlik

VELTRIS'in modüler yapısı aşağıdaki genişlemelere uygundur:

* Yeni güvenlik modülleri
* Yeni API endpointleri
* Yeni roller
* Yeni yetkiler
* Yeni veri sağlayıcıları
* Yeni AI sağlayıcıları
* Yeni security integrations
* Background workers
* Queue systems
* Event-driven architecture
* Distributed services
* Horizontal scaling

Gerekli görüldüğünde ASP.NET Core API, PostgreSQL ve frontend katmanları bağımsız olarak ölçeklendirilebilir.

---

# 49. Enterprise Genişleme Alanları

Ürünün çekirdek mimarisi üzerine aşağıdaki enterprise özellikleri eklenebilir:

* SSO
* OIDC
* OAuth2
* MFA
* Audit Log
* Advanced RBAC
* Advanced Tenant Management
* SIEM Connectors
* EDR Connectors
* Threat Intelligence Feeds
* Vulnerability Scanner Connectors
* Notification Engine
* Background Processing
* Queue Infrastructure
* Advanced Correlation Engine
* Reporting Engine
* AI Orchestration
* Enterprise Monitoring
* High Availability
* Disaster Recovery

Bu özelliklerin tamamı müşterinin kullanım senaryosuna göre devreye alınabilir.

---

# 50. Ürün Kalite Yaklaşımı

VELTRIS geliştirme yaklaşımında temel prensipler:

* Modüler mimari
* Katmanlı mimari
* Merkezi API istemcisi
* Merkezi hata yönetimi
* Güvenlik odaklı erişim
* Migration tabanlı database yönetimi
* Production build kontrolü
* Secret isolation
* Customer-specific deployment
* Genişletilebilir integration architecture

---

# 51. Frontend Deneyimi

VELTRIS web arayüzü güvenlik operasyonlarında hızlı bilgi taraması amacıyla tasarlanmıştır.

Arayüz hedefleri:

* Açık ve temiz görünüm
* Kurumsal kullanım
* Hızlı bilgi erişimi
* Güvenlik seviyelerinin kolay ayırt edilmesi
* Modüler navigation
* Responsive yapı
* Dashboard odaklı kullanım
* API verilerine dayalı ekranlar

---

# 52. Web Route'ları

Ana route'lar:

* `/`
* `/tehditler`
* `/olaylar`
* `/zafiyetler`
* `/varliklar`
* `/risk`
* `/ai`

Her route kendi güvenlik operasyon alanını temsil eder.

---

# 53. Production Deployment Sorumluluk Ayrımı

VELTRIS çekirdek ürün:

* Source code
* Application
* Database model
* API
* Frontend
* Security modules
* Risk engine
* AI integration architecture
* Initial setup

müşteri production altyapısı:

* VPS
* Domain
* DNS
* SSL
* Firewall
* Database credentials
* External services
* Security product credentials
* AI provider credentials
* Monitoring infrastructure
* Backup infrastructure

olarak ayrıştırılır.

Bu ayrım ürünün taşınabilirliğini ve güvenli deployment modelini korur.

---

# 54. Roadmap ve Enterprise Entegrasyon Modeli

VELTRIS çekirdek ürününün geliştirme aşaması tamamlanmıştır.

Sonraki aşamalar müşteri ihtiyaçlarına göre production entegrasyonlarıdır.

Örnek:

**VELTRIS Core**

*

**Customer Infrastructure**

*

**Customer Security Integrations**

*

**Customer AI Services**

=

**Enterprise Security Intelligence Platform**

Bu model sayesinde her müşteriye aynı güvenlik çekirdeği sunulurken production entegrasyonları müşterinin mevcut altyapısına göre özelleştirilebilir.

---

# 55. Lisans ve Ticari Kullanım

VELTRIS ticari ürün olarak geliştirilmiştir.

Kaynak kodunun proje sahibinin izni olmadan:

* yeniden dağıtılması,
* kopyalanması,
* satılması,
* yeniden markalanması,
* başka bir ticari ürün içerisinde kullanılması

yasaktır.

Ticari kullanım, lisanslama ve deployment koşulları proje sahibi ile müşteri arasındaki ticari anlaşmaya göre belirlenir.

---

# 56. Geliştirici

**Yazılım Uzmanı Merve Kılıç**

VELTRIS
Enterprise Security Intelligence Platform

Copyright (c) 2026 Yazılım Uzmanı Merve Kılıç

---

# 57. Repository

GitHub:

https://github.com/mervedogan272737-byte/VELTRIS

---

# 58. Sonuç

VELTRIS; kurumsal güvenlik operasyonlarını merkezi bir platform altında yönetmek üzere geliştirilmiş, modüler ve genişletilebilir Security Intelligence ürünüdür.

Çekirdek ürün:

* Authentication
* Authorization
* İlk kurulum
* Dashboard
* Tehdit yönetimi
* Olay yönetimi
* Zafiyet yönetimi
* Varlık yönetimi
* Risk motoru
* AI analiz altyapısı
* PostgreSQL
* REST API
* Next.js frontend
* Production build

bileşenlerini kapsar.

VELTRIS'in mimari yaklaşımı, müşterinin mevcut güvenlik altyapısıyla birleştirilebilen merkezi bir güvenlik operasyon platformu oluşturmayı hedefler.

Müşterinin ihtiyacına göre SIEM, EDR, Threat Intelligence, Vulnerability Scanner, IAM, SSO, MFA, AI ve diğer enterprise servisleri VELTRIS çekirdeğine production ortamında entegre edilebilir.

VELTRIS'in temel ürün yaklaşımı:

**Güvenlik Verisini Merkezi Yönet.
Riski Ölç.
Tehdidi Anla.
Olayı Yönet.
Zafiyeti Önceliklendir.
Varlığı Koru.
AI ile Karar Desteği Sağla.**
