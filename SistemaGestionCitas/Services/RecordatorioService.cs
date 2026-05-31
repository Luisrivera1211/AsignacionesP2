using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Services
{
    internal class RecordatorioService : Interfaces.IRecordatorioCita
    {
        public void EnviarRecordatorio(Models.Cita cita) {
            Console.WriteLine($"Querido paciente {cita.Paciente.PrimerNombre}, su cita esta programada para {cita.Fecha} con el Dr. {cita.Medico.PrimerNombre}");
        }
    }
}
