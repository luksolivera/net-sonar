using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Parte_1_Corsiglia_Gonzalo
{
    public class Menu
    {
        public async Task<int> MostrarMenu()
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Registrar una nueva comanda");
            Console.WriteLine("2. Enlistar Comandas");
            Console.WriteLine("3. Salir");

            int opcion;

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Ingrese una opción válida.");
                return await MostrarMenu();
            }

            return opcion;
        }
    }
}
