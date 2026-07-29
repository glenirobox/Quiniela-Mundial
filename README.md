# Sistema de Gestión de Quinielas Mundialistas

Aplicación de escritorio desarrollada en **C#** con **Windows Forms** bajo la arquitectura **Modelo-Vista-Controlador (MVC)** y principios **SOLID / Clean Code**. Permite la administración de encuentros deportivos, registro de pronósticos, creación de quinielas públicas/privadas, tabla de posiciones y asignación automática de insignias y puntuaciones.

---

## Tecnologías Utilizadas

**Lenguaje:** C# (.NET)
**Interfaz Gráfica:** Windows Forms (WinForms)
**Arquitectura:** MVC (Models, Views, Controllers / Services)
**Persistencia:** Archivos planos `.csv` (StreamReader / StreamWriter)
**Control de Versiones:** Git & GitHub

## Estructura del Proyecto
SistemaQuinielas/
├── Controllers/       # Lógica de negocio (Usuario, Partido, Pronóstico, Insignia, etc.)
├── Models/            # Entidades del dominio (Usuario, Partido, Quiniela, etc.)
├── Views/             # Formularios e interfaz gráfica (Windows Forms)
├── Data/              # Archivos CSV para persistencia de datos
├── Documentos/        # Documentación técnica y planificación del proyecto
└── Utils/             # Clases utilitarias y gestión de sesión