using SistemaGestionCitas.Data;
using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Services
{
    internal class MedicoService
    {
        private Data.MedicoRepositorio _medicoRepositorio;

        public MedicoService(Data.MedicoRepositorio medicoService)
        {
            _medicoRepositorio = medicoService;
        }

        public void RegistrarMedico(Models.Medico medico) {
            if (medico == null) throw new ArgumentNullException(nameof(medico));
            _medicoRepositorio.RegistrarMedico(medico);
        }

        public List<Models.Medico> ListarMedicos() {
            return _medicoRepositorio.ListarMedicos();
        }

        public Models.Medico ObtenerPorExequatur(string exequatur) { 
            return _medicoRepositorio.ObtenerPorExequatur(exequatur);
        }

        public Models.Medico ObtenerPorNombre(string nombre) {
            return _medicoRepositorio.ObtenerPorNombre(nombre);
        }

        public void AsignarEspecialidad(Models.Medico medico, Models.Especialidad especialidad)
        {
            if (medico == null) throw new ArgumentNullException(nameof(medico));
            if (especialidad == null) throw new ArgumentNullException(nameof(especialidad));
            medico.Especialidad = especialidad;
        }

    }
}
