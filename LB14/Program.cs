using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB14
{
    class Program
    {
        static string[] ids = new string[60]; 
        static int[] edades = new int[60];    
        static string[] vacunados = new string[60]; 
        static int contador = 0;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("" +
                    "================================\n" +
                    "Encuesta Covid - 19 \n" +
                    "================================\n" +
                    "1: Realizar Encuesta\n" +
                    "2: Mostrar Datos de la encuesta\n" +
                    "3: Mostrar Resultados\n" +
                    "4: Buscar Personas por edad\n" +
                    "5: Salir\n" +
                    "================================\n" +
                    "Ingrese una opción:\n");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            RealizarEncuesta();
                            break;
                        case 2:
                            MostrarDatos();
                            break;
                        case 3:
                            MostrarResultados();
                            break;
                        case 4:
                            BuscarPorEdad();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                            break;
                    }

                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcion != 5);
        }

        static void RealizarEncuesta()
        {
            Console.Clear();
            Console.WriteLine("" +
                "===========================\n" +
                "Encuesta de vacunación\n" +
                "===========================\n");
            Console.Write("¿Qué edad tienes?: ");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("" +
                              "Te has vacunado\n" +
                              "1: Sí\n" +
                              "2: No\n" +
                              "===========================\n" +
                              "Ingrese una opción: \n");
            int opcionVacuna = int.Parse(Console.ReadLine());

            ids[contador] = contador.ToString("D4");
            edades[contador] = edad;
            vacunados[contador] = (opcionVacuna == 1) ? "Si" : "No";
            Console.Clear();
            Console.WriteLine("" +
                "===========================\n" +
                "Encuesta de vacunación\n" +
                "===========================\n" +
                "¡Gracias por participar!\n" +
                "===========================\n");
            _ = ids[contador];
            contador++;
        }

        static void MostrarDatos()
        {
            Console.Clear();
            Console.WriteLine("" +
                "===========================\n" +
                "Datos de la encuesta\n" +
                "===========================\n" +
                "ID   | Edad | Vacunado\n" +
                "===========================\n");

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{ids[i]}   | {edades[i]}   | {vacunados[i]}");
            }

            Console.WriteLine("===========================\n");
        }

        static void MostrarResultados()
        {
            Console.Clear();
            Console.WriteLine("" +
                "===========================\n" +
                "Resultados de la encuesta\n" +
                "===========================\n" +
                $"{ContarVacunados()} personas se han vacunado\n" +
                $"{ContarNoVacunados()} personas no se han vacunado\n" +
                $"Existen:\n" +
                $"{ContarPersonasPorEdad(1, 20)} personas entre 01 y 20 años\n" +
                $"{ContarPersonasPorEdad(21, 30)} personas entre 21 y 30 años\n" +
                $"{ContarPersonasPorEdad(31, 40)} personas entre 31 y 40 años\n" +
                $"{ContarPersonasPorEdad(41, 50)} personas entre 41 y 50 años\n" +
                $"{ContarPersonasPorEdad(51, 60)} personas entre 51 y 60 años\n" +
                $"{ContarPersonasPorEdad(61, int.MaxValue)} personas de más de 61 años\n" +
                "===========================\n" );
        }

        static int ContarVacunados()
        {
            int count = 0;
            for (int i = 0; i < contador; i++)
            {
                if (vacunados[i] == "Si")
                {
                    count++;
                }
            }
            return count;
        }

        static int ContarNoVacunados()
        {
            int count = 0;
            for (int i = 0; i < contador; i++)
            {
                if (vacunados[i] == "No")
                {
                    count++;
                }
            }
            return count;
        }

        static int ContarPersonasPorEdad(int edadMin, int edadMax)
        {
            int count = 0;
            for (int i = 0; i < contador; i++)
            {
                if (edades[i] >= edadMin && edades[i] <= edadMax)
                {
                    count++;
                }
            }
            return count;
        }

        static void BuscarPorEdad()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Buscar Personas por Edad");
            Console.WriteLine("================================");

            Console.Write("¿Qué edad quieres buscar?: ");
            int edadBuscada;

            if (int.TryParse(Console.ReadLine(), out edadBuscada))
            {
                int vacunadosConEdad = 0;
                int noVacunadosConEdad = 0;

                for (int i = 0; i < contador; i++)
                {
                    if (edades[i] == edadBuscada)
                    {
                        if (vacunados[i] == "Si")
                        {
                            vacunadosConEdad++;
                        }
                        else
                        {
                            noVacunadosConEdad++;
                        }
                    }
                }

                Console.WriteLine("================================");
                Console.WriteLine($"{vacunadosConEdad.ToString("D2")} se vacunaron");
                Console.WriteLine($"{noVacunadosConEdad.ToString("D2")} no se vacunaron");
                Console.WriteLine("================================");
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
        }
    }

}
