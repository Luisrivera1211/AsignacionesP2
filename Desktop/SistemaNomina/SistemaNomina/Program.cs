using SistemaNomina.Models;
Console.OutputEncoding = System.Text.Encoding.UTF8;


List<Empleado> empleados = new List<Empleado>();
int opcion;

do
{

    Console.WriteLine("\n==== SISTEMA DE NOMINA ====");
    Console.WriteLine("1. Agregar Empleados");
    Console.WriteLine("2. Ver Empleados");
    Console.WriteLine("3. Reporte Semanal");
    Console.WriteLine("4. Actualizar Empleado");
    Console.WriteLine("5. Salir");
    Console.Write("Opcion: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {

        case 1:
            AgregarEmpleado();
            break;
        case 2:
            VerEmpleados();
            break;
        case 3:
            ReporteSemanal();
            break;
        case 4:
            ActualizarEmpleado();
            break;
    }

} while (opcion != 5);


// Funciones dentro del switch

void AgregarEmpleado() {
    Console.WriteLine("\nQue tipo de empleado desea añadir?");
    Console.WriteLine("1. Asalariado");
    Console.WriteLine("2. Por Horas");
    Console.WriteLine("3. Por Comision");
    Console.WriteLine("4. Asalariado por Comision");
    Console.Write("Opcion: ");
    int tipo = int.Parse(Console.ReadLine());

    switch (tipo) {

        case 1:
            Console.Write("Primer nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido paterno: ");
            string apellido = Console.ReadLine();
            Console.Write("Numero de seguro social: ");
            string nss = Console.ReadLine();
            Console.Write("Salario semanal: ");
            decimal salario = decimal.Parse(Console.ReadLine());

            empleados.Add(new EmpleadoAsalariado {
                PrimerNombre = nombre,
                ApellidoPaterno = apellido,
                NumeroSeguroSocial = nss,
                SalarioSemanal = salario
            });
            break;

        case 2:
            Console.Write("Apellido Paterno: ");
            string apellidoH = Console.ReadLine();
            Console.Write("Numero de seguro social: ");
            string nssH = Console.ReadLine();
            Console.Write("Sueldo por hora: ");
            decimal tarifa = decimal.Parse(Console.ReadLine());
            Console.Write("Horas trabajadas: ");
            decimal horas = decimal.Parse(Console.ReadLine());

            empleados.Add(new EmpleadoPorHoras
            {
                PrimerNombre = "",
                ApellidoPaterno = apellidoH,
                NumeroSeguroSocial = nssH,
                SueldoPorHora = tarifa,
                HorasTrabajadas = horas

            });
            break;

        case 3:
            Console.Write("Primer nombre: ");
            string nombreC = Console.ReadLine();
            Console.Write("Apellido paterno: ");
            string apellidoC = Console.ReadLine();
            Console.Write("Numero de seguro social: ");
            string nssC = Console.ReadLine();
            Console.Write("Ventas brutas: ");
            decimal ventas = decimal.Parse(Console.ReadLine());
            Console.Write("Tarifa de comision: ");
            decimal comision = decimal.Parse(Console.ReadLine());

            empleados.Add(new EmpleadoPorComision
            {
                PrimerNombre = nombreC,
                ApellidoPaterno = apellidoC,
                NumeroSeguroSocial = nssC,
                VentasBrutas = ventas,
                TarifaComision = comision
            });
            break;

        case 4:
            Console.Write("Primer nombre: ");
            string nombreM = Console.ReadLine();
            Console.Write("Apellido paterno: ");
            string apellidoM = Console.ReadLine();
            Console.Write("Numero de seguro social: ");
            string nssM = Console.ReadLine();
            Console.Write("Ventas Brutas: ");
            decimal ventasM = decimal.Parse(Console.ReadLine());
            Console.Write("Tarifa de comision: ");
            decimal comisionM = decimal.Parse(Console.ReadLine());
            Console.Write("Salario base: ");
            decimal baseM = decimal.Parse(Console.ReadLine());

            empleados.Add(new EmpleadoAsalariadoPorComision
            {
                PrimerNombre = nombreM,
                ApellidoPaterno = apellidoM,
                NumeroSeguroSocial = nssM,
                VentasBrutas = ventasM,
                TarifaComision = comisionM,
                SalarioBase = baseM
            });

            break;

    }

     Console.WriteLine("Empleado agregado correctamente");

}

void VerEmpleados() {
    if (empleados.Count == 0) {

        Console.WriteLine("\nNo hay empleados registrados");
        return;
        
    }

    Console.WriteLine("\n==== EMPLEADOS ====");
    foreach (Empleado emp in empleados) {
        Console.WriteLine(emp);
    }
}

void ReporteSemanal() {

    if (empleados.Count == 0) { 
        
        Console.WriteLine("\nNo hay empleados registrados.");
        return;

    }

    Console.WriteLine("\n===== REPORTE SEMANAL =====");
    decimal totalNomina = 0;

    foreach (Empleado emp in empleados) {
        decimal pago = emp.CalcularPago();
        Console.WriteLine($"{emp} -- Pago: {pago:C}");
        totalNomina += pago;
    }

    Console.WriteLine($"\nTotal nomina: {totalNomina:C}");

}

void ActualizarEmpleado()
{
    if (empleados.Count == 0)
    {
        Console.WriteLine("\nNo hay empleados registrados.");
        return;
    }

    Console.WriteLine("\n===== SELECCIONA EMPLEADO =====");
    for (int i = 0; i < empleados.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {empleados[i]}");
    }

    Console.Write("Número de empleado a actualizar: ");
    int indice = int.Parse(Console.ReadLine()) - 1;

    Empleado emp = empleados[indice];

    if (emp is EmpleadoAsalariado a)
    {
        Console.Write("Nuevo salario semanal: ");
        a.SalarioSemanal = decimal.Parse(Console.ReadLine());
    }
    else if (emp is EmpleadoPorHoras h)
    {
        Console.Write("Nuevo sueldo por hora: ");
        h.SueldoPorHora = decimal.Parse(Console.ReadLine());
        Console.Write("Nuevas horas trabajadas: ");
        h.HorasTrabajadas = decimal.Parse(Console.ReadLine());
    }
    else if (emp is EmpleadoPorComision c)
    {
        Console.Write("Nuevas ventas brutas: ");
        c.VentasBrutas = decimal.Parse(Console.ReadLine());
        Console.Write("Nueva tarifa de comisión: ");
        c.TarifaComision = decimal.Parse(Console.ReadLine());
    }
    else if (emp is EmpleadoAsalariadoPorComision m)
    {
        Console.Write("Nuevas ventas brutas: ");
        m.VentasBrutas = decimal.Parse(Console.ReadLine());
        Console.Write("Nueva tarifa de comisión: ");
        m.TarifaComision = decimal.Parse(Console.ReadLine());
        Console.Write("Nuevo salario base: ");
        m.SalarioBase = decimal.Parse(Console.ReadLine());
    }

    Console.WriteLine("Empleado actualizado. Nuevo pago: " + emp.CalcularPago().ToString("C"));
}