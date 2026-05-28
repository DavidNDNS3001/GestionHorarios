# Clínica Central - Sistema de Gestión de Guardias

Aplicación ASP.NET Core para la gestión de horarios, turnos médicos y registro de llamadas en guardia nocturna.

## 📋 Descripción

Sistema integral para:
- **Gestión de Médicos**: Registro de profesionales médicos por especialidad
- **Asignación de Turnos**: Calendario interactivo de turnos (diurno, nocturno, fin de semana)
- **Registro de Llamadas**: Control de llamadas realizadas al médico de guardia
- **Reportes**: Análisis de desempeño y cobertura de turnos
- **Control de Acceso**: Gestión de roles y permisos por usuario

## 🏗️ Arquitectura

- **Framework**: ASP.NET Core 8.0
- **Base de Datos**: SQL Server
- **ORM**: Entity Framework Core
- **Autenticación**: ASP.NET Core Identity
- **Patrón**: MVC con arquitectura en capas
- **Diseño**: Repositorio Genérico + Unidad de Trabajo

## 📁 Estructura del Proyecto

```
GestionHorarios/
├── GestionHorarios.Web/          # Presentación (Controladores, Vistas, Assets)
│   ├── Areas/
│   │   ├── Identity/             # Autenticación y registro
│   │   ├── Admin/                # Gestión administrativa
│   │   └── Horarios/             # Gestión de turnos y llamadas
│   ├── Controllers/
│   ├── Views/
│   └── wwwroot/
├── GestionHorarios.Datos/        # Acceso a datos
│   ├── Context/
│   ├── Repositories/
│   └── Migrations/
├── GestionHorarios.Modelos/      # Entidades y modelos
│   ├── Entidades/
│   ├── DTOs/
│   └── Enums/
└── GestionHorarios.Servicios/    # Lógica de negocio
```

## 🗄️ Tablas Principales

- **ESPECIALIDAD**: Catálogo de especialidades médicas
- **MEDICO**: Registro de profesionales médicos
- **TIPO_TURNO**: Tipos de turno disponibles
- **HORARIO_LLAMADA**: Asignación de médicos a turnos
- **USUARIO**: Control de acceso con roles
- **REGISTRO_LLAMADA**: Núcleo del sistema de guardias
- **MOTIVO_LLAMADA**: Catálogo de motivos de llamadas
- **INTERCAMBIO_TURNO**: Gestión de cambios de turno

## 🔐 Roles del Sistema

- **Admin**: Acceso completo al sistema
- **Coordinador**: Gestión de horarios y reportes
- **Enfermero**: Registro de llamadas
- **Médico**: Consulta de horarios asignados

## 📧 Funcionalidades Principales

✅ Envío de horarios por correo electrónico
✅ Panel de control en tiempo real
✅ Alertas de cobertura de turnos
✅ Reportes de desempeño médico
✅ Registro detallado de llamadas
✅ Auditoría de cambios

## 🚀 Instalación y Configuración

### Requisitos
- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022 o VS Code

### Pasos

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/DavidNDNS3001/GestionHorarios.git
   cd GestionHorarios
   ```

2. **Restaurar paquetes NuGet**
   ```bash
   dotnet restore
   ```

3. **Configurar la cadena de conexión**
   - Editar `appsettings.json` con la conexión a SQL Server

4. **Ejecutar migraciones**
   ```bash
   dotnet ef database update
   ```

5. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

## 📱 Pantallas Principales

1. **Panel**: Vista general del turno actual
2. **Médicos de Guardia**: Tarjetas con estado y estadísticas
3. **Gestión de Horarios**: Calendario interactivo
4. **Historial de Llamadas**: Registro completo con filtros
5. **Configuración**: Gestión de usuarios, roles y catálogos

## 📊 Base de Datos

Diagrama Entidad-Relación incluido en `db_schema_modelo_relacional.html`

## 👨‍💻 Desarrollo

### Convenciones

- Controladores: `[NombreEntidad]Controller`
- Vistas: `/Areas/[Area]/Views/[Controlador]/[Accion].cshtml`
- Repositorios: `I[Entidad]Repository` interface y `[Entidad]Repository` implementación

### Patrones Implementados

- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- Data Transfer Objects (DTOs)

## 📄 Licencia

Este proyecto es de uso interno de Clínica Central.

## 👤 Autor

David NDN
