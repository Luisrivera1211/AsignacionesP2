# Sistema de Nomina

## Que hace este sistema?

Sistema dirigido al departamento de Recursos Humanos para gestionar
los pagos semanales de empleados. Permite agregar, modificar y generar
reportes de nómina para cada tipo de empleado.

## Estructura del proyecto

SistemaNomina/
├── Models/
│ ├── Empleado.cs
│ ├── EmpleadoAsalariado.cs
│ ├── EmpleadoAsalariadoPorComision.cs
│ ├── EmpleadoPorComision.cs
│ └── EmpleadoPorHoras.cs
└── Program.cs

## Como ejecutarlo

1. Clonar el repositorio
2. Abrir `SistemaNomina.sln` en Visual Studio
3. Presionar `F5` o `Ctrl + F5` para ejecutar

## Conceptos aplicados

- **Polimorfismo dinámico** — cada tipo de empleado implementa
  su propio `CalcularPago()` mediante `override`
- **Herencia** — todos los empleados heredan de la clase abstracta `Empleado`
- **Principio Open/Closed** — el sistema es extensible sin modificar
  el código existente

## Autor

**Luis Alberto Moscoso Rivera** -- **Matricula: 2025-2065**
