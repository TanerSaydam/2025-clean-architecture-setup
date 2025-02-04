# 2025 Yılı Clean Architecture Setup

Bu repoda, 2025 yılı için projelerimizde başlangıç olarak kullanabileceğiniz modern ve modüler bir Clean Architecture yapısı sunulmaktadır.

## Video Linki:
1. https://youtube.com/live/byiN2UZXXJQ
2. https://youtube.com/live/kFiBEheyNOw

## Proje İçeriği

### Mimari Yapı
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**:
  - Result Pattern
  - Repository Pattern
  - CQRS Pattern
  - UnitOfWork Pattern

### Kullanılan Kütüphaneler
- **MediatR**: CQRS ve mesajlaşma işlemleri için.
- **TS.Result**: Standart sonuç modellemeleri için.
- **Mapster**: Nesne eşlemeleri için.
- **FluentValidation**: Doğrulama işlemleri için.
- **TS.EntityFrameworkCore.GenericRepository**: Genel amaçlı repository işlemleri için.
- **EntityFrameworkCore**: ORM (Object-Relational Mapping) için.
- **OData**: Sorgulama ve veri erişiminde esneklik sağlamak için.
- **Scrutor**: Dependency Injection yönetimi ve dinamik servis kaydı için.
- **Microsoft.AspNetCore.Authentication.JwtBearer**: Authentication yönetimi için
- **Keycloak.AuthServices.Authentication**: Keyloak ile Authentication yönetimi için

## Kurulum ve Kullanım
1. **Depoyu Klonlayın**:
   ```bash
   git clone https://github.com/tanersaydam/2025-clean-architecture-setup.git
   cd 2025-clean-architecture-setup

2. **Keycloak Docker Kodu**:
   ```bash
    docker run -d --name keycloak -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:25.0.2 start-dev
   ```
