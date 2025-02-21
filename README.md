
# Prueba Técnica N5 Backend - Johans Cuellar

El proyecto fue elaborado usando Net Core 8

Tecnologias:

- Net Core 8
- EF Core
- Arquitectura limpia
- Unit of Work y patrón CQRS
- Pruebas Unitarias

## 1. Pasos para instalar el proyecto

### 1.1 Crear la base de datos PermissionsDb

Ejecutar el siguiente script en SQL Server

```sh
- Comando: CREATE DATABASE PermissionsDb
```
### 1.2 Migración con las tablas

Se crean automáticamente al correr la API

## 2. Kafka y Elastic Searh

Se utilizan los puertos por defecto

```sh
- Kakfa: "http://localhost:9092"
- Elastic: "http://localhost:9200"
```

