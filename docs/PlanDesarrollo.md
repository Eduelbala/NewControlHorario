# Plan de desarrollo para aplicación web de control horario

Este documento resume la arquitectura y los componentes clave para construir una aplicación web de control horario de empleados con backend en **.NET 8 (ASP.NET Core)** y frontend en **Vue.js + Vuetify**.

## Estructura general del proyecto
- **Backend (.NET 8 API)** organizado en solución con capas separadas:
  - **Web API** (controladores/endpoints, autenticación, DTOs).
  - **Aplicación/Lógica de negocio** (servicios y reglas de dominio).
  - **Dominio** (entidades y contratos de repositorio, sin dependencias externas).
  - **Infraestructura** (DbContext de EF Core 8, repositorios, migraciones).
- **Frontend (Vue.js + Vuetify)** como SPA independiente: componentes por módulo, Vue Router para navegación y Pinia/Vuex para estado.
- Integración vía **inyección de dependencias** en ASP.NET Core y llamadas HTTP desde el frontend.

## Modelo de datos (principales entidades)
- **Usuario**: email único, hash de contraseña, datos básicos, estado (activo/inactivo). Relación muchos a muchos con **Rol** y uno a muchos con registros/solicitudes.
- **Rol**: nombre y descripción. Relación muchos a muchos con **Usuario** y con **Permiso** (si se gestiona granularidad).
- **Permiso (opcional)**: privilegios específicos asignables a roles.
- **RegistroHorario**: timestamp y tipo (Entrada, Salida, InicioDescanso, FinDescanso) con comentario opcional.
- **HoraExtra**: fecha, horas, motivo, estado (Pendiente/Aprobada/Rechazada) y aprobador opcional.
- **Incidencia**: tipo (Ausencia, LlegadaTarde, Enfermedad, Vacaciones, etc.), fecha o rango, observaciones, estado y aprobador.
- **Descanso**: opcional si no se deduce de registros; representa periodo con inicio/fin.

## Arquitectura y patrones
- **N-capas / Clean Architecture ligera** respetando SOLID.
- Repositorios por agregado opcionales y uso del **DbContext como Unit of Work**.
- Controladores ligeros; lógica de negocio en servicios. DTOs y AutoMapper donde aplique.
- Posible uso de **CQRS** en módulos que lo requieran (no obligatorio inicialmente).

## Autenticación y autorización
- **ASP.NET Core Identity** con email/contraseña, hashes seguros y políticas de contraseñas.
- **JWT** para sesiones stateless en el SPA (claims de roles/permisos); **refresh tokens** para extender sesión.
- **Roles** (Administrador, Supervisor, Empleado, etc.) y **políticas de permisos** ([Authorize(Roles)] o [Authorize(Policy)]).
- Opcional tabla **Permiso** y relación Rol-Permiso para gestión dinámica desde UI.
- Considerar bloqueo por intentos fallidos, confirmación de email y recuperación de contraseña.

## Consideraciones de seguridad
- Todo el tráfico bajo **HTTPS** y secretos (cadena de conexión, claves JWT) en almacenes seguros/variables de entorno.
- Validación de entrada (anotaciones/FluentValidation), límites de payload y logging seguro.
- Prevención de **SQL injection** usando LINQ parametrizado; sanitizar contenido libre para evitar XSS.
- Configurar **CORS** para orígenes permitidos y políticas de bloqueo/expiración de token.

## Módulos funcionales
- **Usuarios**: crear/editar/desactivar usuarios, asignar roles, resetear contraseña, listados con filtros y paginación.
- **Roles y permisos**: CRUD de roles, asignación de permisos (checkboxes por categoría), protección para roles base.
- **Registro de entradas/salidas**: fichar entrada/salida y descansos; estado actual del usuario; correcciones por supervisor; historial con filtros.
- **Horas extra**: solicitudes por empleado, aprobación/rechazo por supervisor, motivos y comentarios.
- **Incidencias**: reporte de ausencias/retrasos/vacaciones; flujos de aprobación; soporte de rangos de fecha.
- **Descansos**: uso de registros Inicio/Fin de descanso; validación de duración y seguimiento.
- **Informes**: consultas por usuario/rango/tipo (horas trabajadas, horas extra, incidencias); exportación CSV/Excel y posibles gráficos.

## Propuesta de UI (Vue + Vuetify)
- **Layout** con drawer lateral dinámico según rol y app bar con perfil/cerrar sesión.
- **Login** simple con validación y mensajes de error.
- **Dashboard** con estado de fichaje (empleado) o KPIs resumidos (admin).
- Vistas por módulo con **v-data-table/v-card**: formularios de creación/edición en diálogos, filtros de fecha/usuario, acciones de aprobación y confirmaciones.
- Diseño **responsivo** y accesible, uso de snackbars para feedback y loading states en botones.

## Operaciones clave y validaciones
- Evitar fichajes duplicados (entrada sin salida previa) y validar descansos máximos.
- Restricciones de eliminación (p. ej., no borrar usuarios con historial; usar soft-delete).
- Índices en campos de búsqueda frecuente (UsuarioId+Fecha en registros).
- **Seed** inicial para roles básicos, permisos estándar y tipos de incidencia comunes.

## DevOps y migraciones
- **EF Core Migrations** para evolucionar el esquema SQL Server.
- Separar perfiles de configuración por entorno (Development/Staging/Production).
- Backups periódicos de base de datos y monitoreo/logging centralizado.
