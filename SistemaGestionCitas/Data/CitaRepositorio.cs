using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace SistemaGestionCitas.Data
{
    internal class CitaRepositorio
    {
        private List<Models.Cita> citas = new List<Models.Cita>();

        public void AgendarCita(Models.Cita cita) {
            citas.Add(cita);
        }

        public void CancelarCita(Models.Cita cita)
        {
            cita.Estado = Models.EstadoCita.Cancelada;
        }

        public void ReprogramarCita(Models.Cita cita, DateTime nuevaFecha ) { 
            cita.Fecha = nuevaFecha;
            cita.Estado = Models.EstadoCita.Reprogramada;
        }

        public List<Models.Cita> ObtenerCitasPorPaciente(Models.Paciente paciente) {
            return citas.Where(c => c.Paciente == paciente).ToList();
        }

        public List<Models.Cita> ObtenerCitasPorMedico(Models.Medico medico) { 
                
            return citas.Where(c => c.Medico == medico).ToList();

        }
        public List<Models.Cita> ObtenerTodas()
        {
            return citas;
        }


    }
}
