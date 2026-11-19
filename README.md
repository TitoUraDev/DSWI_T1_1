# DSWI_T1_01 · Evaluación T1 — Desarrollo de Servicios Web I

**Institución:** Instituto de Educación Superior CIBERTEC · Dirección Académica · Carreras Profesionales
**Curso:** 0265 – Desarrollo de Servicios Web I
**Profesor:** Luis Angel Salvatierra Aquino
**Ciclo:** Sexto · **Semestre:** 2026 – 3 · **Grupo:** 01 · **Filial:** A · **Fecha:** 18/11/2026

## Cumplimiento de la evaluación

### Consideraciones generales

- [x] Proyecto creado con la nomenclatura indicada: **`DSWI_T1_01`** (01 = número de grupo)
- [x] Estructura de carpetas por capas: `Controllers`, `Models`, `Models/ViewModels`, `Views`, `Data`, `Repositories`, `Services`, `Database`
- [x] Aplicación Web en .NET Core con C# utilizando el patrón **MVC**

### Pregunta 01 — Lógica de negocio (09 puntos)

**Préstamos**

- [x] Más de 5000 $ → cobra en **3 cuotas**
- [x] Menos de 1000 $ → cobra en **1 cuota**
- [x] Entre 2000 y 3000 $ → cobra en **2 cuotas**
- [x] En los demás casos → cobra en **5 cuotas**
- [x] Menos de 4000 $ → interés del **12%**; en caso contrario, **10%**
- [x] Calcula el total de la deuda con interés y lo divide en cuotas iguales
- [x] Informa **en cuántas cuotas** debe pagar y **de cuánto es cada cuota**
- [x] La empresa solo ingresa el **monto del préstamo**

**Envíos**

- [x] Más de 50 kg → **2,50 $ por kilo**
- [x] Menos de 5 kg → **4 $ por kilo**
- [x] Entre 10 y 20 kg → **3 $ por kilo**
- [x] En los demás casos → **3,50 $ por kilo**
- [x] Envío internacional → recargo fijo de **15 $**; nacional → sin recargo
- [x] Informa **el costo por kilo** y **el total a pagar**
- [x] La empresa ingresa el **peso** del paquete y **si el envío es internacional (sí/no)**

### Pregunta 02 — Entity Framework y mantenimiento (11 puntos)

- [x] Dependencias de **Entity Framework** añadidas al proyecto
- [x] Script **ClinicaDB** del docente ejecutado en SQL Server (`Database/01_ClinicaDB.sql`)
- [x] **Scaffold**: tablas relacionadas generadas en el directorio `Models` y el contexto en `Data`
- [x] Interfaces **Repository** y **Service** para cada tabla, con las funciones *obtener todos los registros* y *obtener un registro por ID*
- [x] Clases que implementan las interfaces y desarrollo de las funciones
- [x] Interfaces y clases registradas en `Program.cs` con **inyección de dependencias**
- [x] Mantenimiento de las tablas con las operaciones **listar, crear y editar** utilizando **procedimientos almacenados** (`Database/02_StoredProcedures.sql`)
- [x] Operación **eliminar** añadida al mantenimiento, también mediante procedimientos almacenados

### Estructura del proyecto

```
DSWI_T1_01/
├── Controllers/      Prestamo, Envio, Pacientes, Citas, Home
├── Models/           Paciente, Cita  ·  ViewModels/  Prestamo, Envio, formularios
├── Data/             ClinicaBdContext (contexto generado con Scaffold)
├── Repositories/     Interfaces + implementaciones (procedimientos almacenados)
├── Services/         Interfaces + implementaciones  ·  calculadoras de negocio
├── Views/            Prestamo, Envio, Pacientes, Citas, Home
└── Database/         01_ClinicaDB.sql  ·  02_StoredProcedures.sql
```

## Integrantes

| Código | Nombre y apellidos |
|---|---|
| i202333946 | Tito Ura |
| i202501591 | Maria Huaman Pahuara |
| I202406413 | Luis Paredes Ramos |
| i201915806 | Joel Arturo Cueva Montalban |
