using SistemaGestionCitas.Data;
using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Services
{
    internal class CitaService
    {
        private Data.CitaRepositorio _citaRepositorio;

        public CitaService(Data.CitaRepositorio citaRepositorio) {
            _citaRepositorio = citaRepositorio;
        }

        public void AgendarCita(Models.Cita cita) {
            if (cita == null) throw new ArgumentNullException(nameof(cita));

            var citaExistente = _citaRepositorio.ObtenerCitasPorMedico(cita.Medico)
            .Where(c => c.Fecha == cita.Fecha).FirstOrDefault();

            if (citaExistente != null) throw new InvalidOperationException("El medico ya tiene una cita en esa fecha");

            _citaRepositorio.AgendarCita(cita);
        }

        public void CancelarCita(Models.Cita cita) {
            if (cita == null) throw new ArgumentNullException(nameof(cita));
            _citaRepositorio.CancelarCita(cita);
        }

        public void ReprogramarCita(Models.Cita cita, DateTime nuevaFecha) {
            if (cita == null) throw new ArgumentNullException(nameof(cita));
            _citaRepositorio.ReprogramarCita(cita, nuevaFecha);
        }

        public List<Models.Cita> ObtenerCitasPorPaciente(Models.Paciente paciente) {
            if (paciente == null) throw new ArgumentNullException(nameof(paciente));
            return _citaRepositorio.ObtenerCitasPorPaciente(paciente);
        }

        public List<Models.Cita> ObtenerCitasPorMedico(Models.Medico medico) { 
            if (medico == null) throw new ArgumentNullException(nameof(medico));
            return _citaRepositorio.ObtenerCitasPorMedico(medico);
        }

        public List<Models.Cita> ObtenerTodasLasCitas()
        {
            return _citaRepositorio.ObtenerTodas();
        }
    }
}
