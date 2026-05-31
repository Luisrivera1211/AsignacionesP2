using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Data
{
    internal class PacienteRepositorio
    {
    
    private List<Models.Paciente> pacientes = new List<Models.Paciente>();

    public void RegistrarPaciente(Models.Paciente paciente)
        {
            pacientes.Add(paciente);
        }

        public List<Models.Paciente> ObtenerPacientes()
        {
            return pacientes;
        }

        public Models.Paciente ObtenerPorCedula(string cedula)
        {
            return pacientes.Where(p => p.Cedula == cedula).FirstOrDefault();
        }

        public Models.Paciente ObtenerPorNombre(string nombre)
        {

            return pacientes.Where(p => p.PrimerNombre == nombre).FirstOrDefault();
        }

    }
}
