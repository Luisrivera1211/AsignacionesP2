using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Services
{
    internal class PacienteService
    {

        private Data.PacienteRepositorio _pacienteRepositorio;

        public PacienteService(Data.PacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public void RegistrarPaciente(Models.Paciente paciente)
        {
            if (paciente == null) throw new ArgumentNullException(nameof(paciente));
            _pacienteRepositorio.RegistrarPaciente(paciente);
        }

        public List<Models.Paciente> ObtenerPacientes()
        {
            return _pacienteRepositorio.ObtenerPacientes();
        }

        public Models.Paciente ObtenerPorCedula(string cedula)
        {
            return _pacienteRepositorio.ObtenerPorCedula(cedula);
        }

        public Models.Paciente ObtenerPorNombre(string nombre)
        {

            return _pacienteRepositorio.ObtenerPorNombre(nombre);
        }

    }
}
