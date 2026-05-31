# Sistema de Gestión de Citas Médicas

Sistema desarrollado en C# como solución a la gestión manual de citas en una clínica médica. Aplica principios de diseño de software como SoC, DRY, KISS, YAGNI y SOLID.

## Problema
La clínica manejaba sus citas de forma manual generando problemas como citas duplicadas, cancelaciones mal registradas e información repetida de pacientes y médicos.

## Funcionalidades
1. Registrar pacientes
2. Registrar médicos
3. Registrar especialidades médicas
4. Asignar médicos a una especialidad
5. Agendar citas médicas
6. Consultar citas por paciente
7. Consultar citas por médico
8. Cancelar citas
9. Reprogramar citas
10. Enviar recordatorio de cita

## Estructura del proyecto
- **Models** — Entidades del sistema: Paciente, Medico, Especialidad, Cita
- **Data** — Repositorios con colecciones en memoria
- **Services** — Lógica de negocio
- **Interfaces** — Contratos de comportamiento

## Principios aplicados
- **SoC** — Sistema dividido en 4 capas con responsabilidades claras
- **DRY** — Clase abstracta `Persona` evita repetir atributos comunes
- **KISS** — Solución simple sin funcionalidades innecesarias
- **YAGNI** — No se implementaron facturación, historial clínico ni recetas médicas
- **SRP** — Cada clase tiene una única razón para cambiar
- **OCP** — `IRecordatorioCita` permite agregar nuevos tipos de recordatorio sin modificar el código existente
- **LSP** — `Medico` y `Paciente` heredan correctamente de `Persona`
- **ISP** — Interfaz con un único método necesario
- **DIP** — Los servicios reciben repositorios por constructor

## Tecnologías
- C# / .NET
- Aplicación de consola
- Almacenamiento en memoria

## Autor
Luis Rivera
