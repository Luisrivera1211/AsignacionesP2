using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Models
{
    internal class Cita
    {
        public DateTime Fecha { get; set; }
        public Especialidad Especialidad { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        public EstadoCita Estado { get; set; }

    }
}
