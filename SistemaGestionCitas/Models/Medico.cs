using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Models
{
    internal class Medico : Persona
    {
        public Especialidad Especialidad { get; set; }
        public string Exequatur { get; set; }
    }
}
