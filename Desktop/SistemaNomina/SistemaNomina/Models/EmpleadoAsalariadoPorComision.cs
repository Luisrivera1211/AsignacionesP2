
namespace SistemaNomina.Models
{
    public class EmpleadoAsalariadoPorComision : EmpleadoPorComision
    {
        public decimal SalarioBase { get; set; }

        public override decimal CalcularPago()
        {
            return (VentasBrutas * TarifaComision) + SalarioBase + (SalarioBase * 0.10m);
        }

    }
}
