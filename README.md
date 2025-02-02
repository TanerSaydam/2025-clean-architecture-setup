# 2025 Y�l� Clean Architecture Setup

Bu repoda, 2025 y�l� i�in projelerimizde ba�lang�� olarak kullanabilece�iniz modern ve mod�ler bir Clean Architecture yap�s� sunulmaktad�r.

## Video Linki:
https://youtube.com/live/byiN2UZXXJQ

## Proje ��eri�i

### Mimari Yap�
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**:
  - Result Pattern
  - Repository Pattern
  - CQRS Pattern
  - UnitOfWork Pattern

### Kullan�lan K�t�phaneler
- **MediatR**: CQRS ve mesajla�ma i�lemleri i�in.
- **TS.Result**: Standart sonu� modellemeleri i�in.
- **Mapster**: Nesne e�lemeleri i�in.
- **FluentValidation**: Do�rulama i�lemleri i�in.
- **TS.EntityFrameworkCore.GenericRepository**: Genel ama�l� repository i�lemleri i�in.
- **EntityFrameworkCore**: ORM (Object-Relational Mapping) i�in.
- **OData**: Sorgulama ve veri eri�iminde esneklik sa�lamak i�in.
- **Scrutor**: Dependency Injection y�netimi ve dinamik servis kayd� i�in.

## Kurulum ve Kullan�m
1. **Depoyu Klonlay�n**:
   ```bash
   git clone https://github.com/tanersaydam/2025-clean-architecture-setup.git
   cd 2025-clean-architecture-setup

2. **Keycloak Docker Kodu**:
   ```bash
    docker run -d --name keycloak -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:25.0.2 start-dev
   ```