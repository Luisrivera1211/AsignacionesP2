using SistemaGestionCitas.Services;

namespace SistemaGestionCitas {

    internal class Program
    {
        static void Main(string[] args) {

            var citaRepositorio = new Data.CitaRepositorio();
            var medicoRepositortio = new Data.MedicoRepositorio();
            var especialidadRespositorio = new Data.EspecialidadRepositorio();
            var pacienteRepositorio = new Data.PacienteRepositorio();

            var citaService = new Services.CitaService(citaRepositorio);
            var medicoService = new Services.MedicoService(medicoRepositortio);
            var especialidadService = new Services.EspecialidadService(especialidadRespositorio);
            var pacienteService = new Services.PacienteService(pacienteRepositorio);


            bool ejecutando = true;

            while (ejecutando) {

                Console.WriteLine("=== Sistema de Gestion de Citas ===");
                Console.WriteLine("1. Registrar Paciente");
                Console.WriteLine("2. Registrar Medico");
                Console.WriteLine("3. Regisrar especialidad");
                Console.WriteLine("4. Asignar Medico a una especialidad");
                Console.WriteLine("5. Agendar cita");
                Console.WriteLine("6. Consultar citas por paciente");
                Console.WriteLine("7. Consultar citas por medico");
                Console.WriteLine("8. Cancelar cita");
                Console.WriteLine("9. Reprogramar cita");
                Console.WriteLine("10. Enviar recordatorio");
                Console.WriteLine("11. Salir");

                Console.Write("Seleccione una Opcion: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        {
                            Console.WriteLine("Ingrese el primer nombre: ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido paterno: ");
                            string apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese el numero de telefono: ");
                            string telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo electronico: ");
                            string correo = Console.ReadLine();
                            Console.WriteLine("Ingrese la cedula: ");
                            string cedula = Console.ReadLine();

                            var paciente = new Models.Paciente
                            {
                                PrimerNombre = nombre,
                                ApellidoPaterno = apellido,
                                Telefono = telefono,
                                Correo = correo,
                                Cedula = cedula,
                            };

                            pacienteService.RegistrarPaciente(paciente);
                            Console.WriteLine("Paciente registrado Exitosamente!");
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("Ingrese el primer nombre: ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el apellido paterno: ");
                            string apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese el numero de telefono: ");
                            string telefono = Console.ReadLine();
                            Console.WriteLine("Ingrese el correo electronico: ");
                            string correo = Console.ReadLine();
                            var especialidades = especialidadService.ListarEspecialidades();
                            Console.WriteLine("Especialidades disponibles");
                            for (int i = 0; i < especialidades.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {especialidades[i].Nombre}");
                            }
                            Console.WriteLine("Seleccione el numero de especialidades");
                            int indice = int.Parse(Console.ReadLine()) - 1;
                            Models.Especialidad especialidad = especialidades[indice];
                            Console.WriteLine("Ingrese el exequatur: ");
                            string exequatur = Console.ReadLine();

                            var medico = new Models.Medico
                            {
                                PrimerNombre = nombre,
                                ApellidoPaterno = apellido,
                                Telefono = telefono,
                                Correo = correo,
                                Especialidad = especialidad,
                                Exequatur = exequatur
                            };

                            medicoService.RegistrarMedico(medico);
                            Console.WriteLine("Medico registrado Exitosamente!");
                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("Nombre de la Especialidad");
                            string especialidad = Console.ReadLine();
                            var nuevaEspecialidad = new Models.Especialidad
                            {
                                Nombre = especialidad
                            };
                            especialidadService.RegistrarEspecialidad(nuevaEspecialidad);
                            Console.WriteLine("Especialidad registrada exitosamente!");
                             break;
                        }                      

                    case "4":
                        {
                            var medicos = medicoService.ListarMedicos();
                            Console.WriteLine("Médicos disponibles:");
                            for (int i = 0; i < medicos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {medicos[i].PrimerNombre}");
                            }
                            Console.WriteLine("Seleccione el número de médico:");
                            int indiceMedico = int.Parse(Console.ReadLine()) - 1;
                            Models.Medico medicoSeleccionado = medicos[indiceMedico];

                            var especialidades = especialidadService.ListarEspecialidades();
                            Console.WriteLine("Especialidades disponibles:");
                            for (int i = 0; i < especialidades.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {especialidades[i].Nombre}");
                            }
                            Console.WriteLine("Seleccione el número de especialidad:");
                            int indiceEspecialidad = int.Parse(Console.ReadLine()) - 1;
                            Models.Especialidad especialidadSeleccionada = especialidades[indiceEspecialidad];

                            medicoService.AsignarEspecialidad(medicoSeleccionado, especialidadSeleccionada);
                            Console.WriteLine("Especialidad asignada exitosamente!");
                            break;
                        }

                    case "5":
                        {
                            Console.WriteLine("Seleccione la especialidad de la cita:");
                            var especialidades = especialidadService.ListarEspecialidades();
                            Console.WriteLine("Especialidades disponibles:");
                            for (int i = 0; i < especialidades.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {especialidades[i].Nombre}");
                            }
                            int indiceEspecialidad = int.Parse(Console.ReadLine()) - 1;
                            Models.Especialidad especialidadSeleccionada = especialidades[indiceEspecialidad];

                            var medicos = medicoService.ListarMedicos();
                            Console.WriteLine("Médicos disponibles:");
                            for (int i = 0; i < medicos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {medicos[i].PrimerNombre}");
                            }
                            int indiceMedico = int.Parse(Console.ReadLine()) - 1;
                            Models.Medico medicoSeleccionado = medicos[indiceMedico];


                            var pacientes = pacienteService.ObtenerPacientes();
                            Console.WriteLine("Pacientes disponibles:");
                            for (int i = 0; i < pacientes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {pacientes[i].PrimerNombre}");
                            }
                            int indicePaciente = int.Parse(Console.ReadLine()) - 1;
                            Models.Paciente pacienteSeleccionado = pacientes[indicePaciente];

                            Console.WriteLine("Ingrese la fecha de la cita:");
                            DateTime fecha = DateTime.Parse(Console.ReadLine());

                            var cita = new Models.Cita
                            {
                                Fecha = fecha,
                                Especialidad = especialidadSeleccionada,
                                Medico = medicoSeleccionado,
                                Paciente = pacienteSeleccionado,
                                Estado = Models.EstadoCita.Pendiente
                            };

                            try
                            {
                                citaService.AgendarCita(cita);
                                Console.WriteLine("Cita agendada exitosamente!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }

                    case "6":
                        {
                            var pacientes = pacienteService.ObtenerPacientes();
                            Console.WriteLine("Pacientes disponibles:");
                            for (int i = 0; i < pacientes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {pacientes[i].PrimerNombre}");
                            }
                            Console.WriteLine("Seleccione el número de paciente:");
                            int indicePaciente = int.Parse(Console.ReadLine()) - 1;
                            Models.Paciente pacienteSeleccionado = pacientes[indicePaciente];
                            var citas = citaService.ObtenerCitasPorPaciente(pacienteSeleccionado);
                            Console.WriteLine("Citas del paciente:");
                            foreach (var cita in citas)
                            {
                                Console.WriteLine($"Fecha: {cita.Fecha} - Médico: {cita.Medico.PrimerNombre} - Estado: {cita.Estado}");
                            }
                            break;
                        }

                    case "7":
                        {
                            var medicos = medicoService.ListarMedicos();
                            Console.WriteLine("Médicos disponibles:");
                            for (int i = 0; i < medicos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {medicos[i].PrimerNombre}");
                            }
                            Console.WriteLine("Seleccione el número de médico:");
                            int indiceMedico = int.Parse(Console.ReadLine()) - 1;
                            Models.Medico medicoSeleccionado = medicos[indiceMedico];
                            var citas = citaService.ObtenerCitasPorMedico(medicoSeleccionado);
                            Console.WriteLine("Citas del médico:");
                            foreach (var cita in citas)
                            {
                                Console.WriteLine($"Fecha: {cita.Fecha} - Paciente: {cita.Paciente.PrimerNombre} - Estado: {cita.Estado}");
                            }
                            break;
                        }
              
                    case "8":
                        {
                            var todasLasCitas = citaService.ObtenerTodasLasCitas();
                            Console.WriteLine("Citas disponibles:");
                            for (int i = 0; i < todasLasCitas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Paciente: {todasLasCitas[i].Paciente.PrimerNombre} - Médico: {todasLasCitas[i].Medico.PrimerNombre} - Fecha: {todasLasCitas[i].Fecha}");
                            }
                            Console.WriteLine("Seleccione el número de cita a cancelar:");
                            int indiceCita = int.Parse(Console.ReadLine()) - 1;
                            Models.Cita citaSeleccionada = todasLasCitas[indiceCita];
                            try
                            {
                                citaService.CancelarCita(citaSeleccionada);
                                Console.WriteLine("Cita cancelada exitosamente!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }

                    case "9":
                        {
                            var todasLasCitas = citaService.ObtenerTodasLasCitas();
                            Console.WriteLine("Citas disponibles:");
                            for (int i = 0; i < todasLasCitas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Paciente: {todasLasCitas[i].Paciente.PrimerNombre} - Médico: {todasLasCitas[i].Medico.PrimerNombre} - Fecha: {todasLasCitas[i].Fecha}");
                            }
                            Console.WriteLine("Seleccione el número de cita a reprogramar:");
                            int indiceCita = int.Parse(Console.ReadLine()) - 1;
                            Models.Cita citaSeleccionada = todasLasCitas[indiceCita];
                            Console.WriteLine("Ingrese la nueva fecha:");
                            DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());
                            try
                            {
                                citaService.ReprogramarCita(citaSeleccionada, nuevaFecha);
                                Console.WriteLine("Cita reprogramada exitosamente!");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }

                    case "10":
                        {
                            var todasLasCitas = citaService.ObtenerTodasLasCitas();
                            Console.WriteLine("Citas disponibles:");
                            for (int i = 0; i < todasLasCitas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Paciente: {todasLasCitas[i].Paciente.PrimerNombre} - Fecha: {todasLasCitas[i].Fecha}");
                            }
                            Console.WriteLine("Seleccione el número de cita para enviar recordatorio:");
                            int indiceCita = int.Parse(Console.ReadLine()) - 1;
                            Models.Cita citaSeleccionada = todasLasCitas[indiceCita];
                            var recordatorio = new Services.RecordatorioService();
                            recordatorio.EnviarRecordatorio(citaSeleccionada);
                            break;
                        }

                    case "11":
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }


        }
    
    }


}