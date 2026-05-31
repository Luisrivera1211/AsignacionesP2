using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Services
{
    internal class EspecialidadService
    {
       private Data.EspecialidadRepositorio _especialidadRepositorio;

        public EspecialidadService(Data.EspecialidadRepositorio especialidadService) { 
            _especialidadRepositorio = especialidadService;
        }

        public void RegistrarEspecialidad(Models.Especialidad especialidad) {
            if (especialidad == null) throw new ArgumentNullException(nameof(especialidad));
            _especialidadRepositorio.RegistrarEspecialidad(especialidad);
        }

        public List<Models.Especialidad> ListarEspecialidades() {
           return _especialidadRepositorio.ListarEspecialidades();
        }
    }
}
