
namespace SistemaNomina.Models
{
    public abstract class Empleado
    {
        public string PrimerNombre { get; set; }
        public string ApellidoPaterno { get; set;}
        public string NumeroSeguroSocial { get; set; }

        // Cada sublacse implementara el siguiente metodo a su propia manera
        public abstract decimal CalcularPago();

        public override string ToString()
        {
            return $"{PrimerNombre} {ApellidoPaterno} | NSS: {NumeroSeguroSocial}";
        }

    }
}
