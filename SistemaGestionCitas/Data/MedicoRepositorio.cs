using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Data
{
    internal class MedicoRepositorio
    {
        private List<Models.Medico> medicos = new List<Models.Medico>();

        public void RegistrarMedico(Models.Medico medico)
        {
            medicos.Add(medico);
        }

        public List<Models.Medico> ListarMedicos() {
            return medicos;
        }

        public Models.Medico ObtenerPorExequatur(string exequatur) { 
            return medicos.Where(m => m.Exequatur == exequatur).FirstOrDefault();
        }

        public Models.Medico ObtenerPorNombre(string nombre) {

            return medicos.Where(m => m.PrimerNombre == nombre).FirstOrDefault();
        }
    }

}
