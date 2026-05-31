using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Data
{
    internal class EspecialidadRepositorio
    {
        private List<Models.Especialidad> especialidades = new List<Models.Especialidad>();

        public void RegistrarEspecialidad(Models.Especialidad especialidad) {
            especialidades.Add(especialidad);
        }

        public List<Models.Especialidad> ListarEspecialidades() { 
            return especialidades;
        }
    }
}
