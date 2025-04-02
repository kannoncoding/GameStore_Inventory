# 🎮 GameStore_Inventory

Aplicación de escritorio desarrollada en **C# con .NET 8.0 y Windows Forms**, diseñada para administrar el inventario de videojuegos de la cadena de tiendas **45GAMES4U**. Proyecto desarrollado con arquitectura por capas y persistencia de datos en **SQL Server Express**.

---

## 🏗️ Estructura por capas

La solución está organizada en proyectos independientes (.DLL) para cumplir con buenas prácticas de arquitectura:

| Proyecto                  | Tipo                      | Descripción |
|---------------------------|---------------------------|-------------|
| `_GameStore.Entidades`    | Class Library             | Define las clases de entidad del dominio (Videojuego, Cliente, Tienda, etc). |
| `_GameStore.Datos`        | Class Library             | Implementa el acceso a datos usando SQL Server Express (ADO.NET). |
| `_GameStore.Logica`       | Class Library             | Contiene la lógica de negocio y validaciones. |
| `_GameStore.Presentacion` | Windows Forms (.NET 8.0)  | Interfaz gráfica para el usuario final. |

---

## 🧠 Funcionalidades

- Registrar y consultar **Tipos de Videojuegos**
- Registrar y consultar **Videojuegos**
- Registrar y consultar **Administradores**
- Registrar y consultar **Tiendas**
- Registrar y consultar **Inventario** por tienda
- Registrar y consultar **Clientes**
- Interfaz de usuario con menú de navegación
- Uso de **DataGridView** con columnas configuradas manualmente
- Manejo de **excepciones controladas**
- **ComboBox no editables** para selección de datos relacionados
- Uso exclusivo de **arreglos de entidades** en la versión sin base de datos (ya migrada)

---

## 💾 Base de datos

- **Motor**: SQL Server Express (LocalDB)
- **Nombre de la base**: `BD_45GAMES4U`
- El esquema incluye relaciones entre entidades con claves foráneas y restricciones.
- Acceso a datos mediante `SqlConnection`, `SqlCommand` y `SqlDataReader` (sin ORM).

---

## 📋 Requisitos técnicos

- Visual Studio Community 2022
- .NET 8.0 SDK
- SQL Server Express (LocalDB o instancia completa)
- Windows Forms Desktop Development workload

---

## 👨‍🎓 Información académica

- **Universidad**: Universidad Estatal a Distancia (UNED)
- **Curso**: Programación Avanzada
- **Proyecto**: Administración de Inventario de Videojuegos para 45GAMES4U
- **Estudiante**: Jorge Luis Arias Melendez
- **Cuatrimestre**: 1er Cuatrimestre 2025

---

## 📌 Notas

- Cada archivo `.cs` incluye comentarios superiores con información del estudiante, curso y descripción del archivo.
- Este proyecto no utiliza colecciones (`List`, `Dictionary`, etc.) por lineamientos académicos: solo se usaron arreglos antes de incorporar persistencia en SQL.
- Todos los `ComboBox` se llenan desde base de datos y no permiten entrada manual.

---

## 🔐 Licencia

Proyecto desarrollado con fines educativos. No se permite su uso comercial sin autorización del autor.
