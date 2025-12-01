# NewControlHorario

Aplicación web para control horario de empleados con backend en ASP.NET Core y frontend en Vue + Vuetify. El proyecto sigue una arquitectura por capas (API, Aplicación, Dominio e Infraestructura) y se distribuye como solución de .NET y SPA independiente.

## Estructura del repositorio
- **src/**: solución .NET con las capas de la API.
- **frontend/**: SPA en Vue 3 con Vuetify y Pinia.
- **docs/**: documentación funcional y técnica, incluido el plan de desarrollo.

## Pasos de puesta en marcha
1. **Backend**
   - Requiere .NET 8 SDK.
   - Restaurar y compilar con `dotnet restore` y `dotnet build` desde la carpeta raíz de la solución.
   - Configurar cadenas de conexión y claves JWT mediante variables de entorno o secretos de usuario.
2. **Frontend**
   - Node 18+ y npm instalados.
   - Desde `frontend/`: `npm install` y `npm run dev` o `npm run build`.

## Flujo de ramas y PR
- Trabaja en ramas de característica derivadas de `work`.
- Abre un Pull Request hacia `work` y asegúrate de que las comprobaciones de CI y revisiones estén en verde.
- Si el PR aparece como **Draft/Open** y no permite fusionar:
  - Marca el PR como "Ready for review".
  - Comprueba que no haya conflictos con `work` y que todas las comprobaciones obligatorias estén aprobadas.
  - Añade los comentarios requeridos por la plantilla (si aplica) y asigna revisores.
- Usa squash merge para mantener el historial limpio salvo que se acuerde lo contrario.

## Recursos adicionales
- Consulta `docs/PlanDesarrollo.md` para un resumen de arquitectura y módulos previstos.
