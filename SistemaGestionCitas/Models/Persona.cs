using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SistemaGestionCitas.Models
{
    internal abstract class Persona
    {
        public string PrimerNombre { get; set; }
        public string ApellidoPaterno { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

    }
}
