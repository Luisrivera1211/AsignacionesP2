using SistemaGestionCitas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionCitas.Interfaces
{
    internal interface IRecordatorioCita
    {
        void EnviarRecordatorio(Cita cita);
    }
}
