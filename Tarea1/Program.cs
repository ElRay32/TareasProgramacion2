using System;
using MapaDeClases.Clases;

namespace MapaDeClases
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirMapa();
            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void ImprimirMapa()
        {
            Console.WriteLine("               ┌─────────────────────────────┐");
            Console.WriteLine("               │   MiembroDeLaComunidad      │");
            Console.WriteLine("               └─────────────────────────────┘");
            Console.WriteLine("                    /          |           \\");
            Console.WriteLine("       ┌────────────────┐ ┌───────────────┐ ┌────────────────┐");
            Console.WriteLine("       │    Empleado    │ │  Estudiante   │ │    ExAlumno    │");
            Console.WriteLine("       └────────────────┘ └───────────────┘ └────────────────┘");
            Console.WriteLine("             /       \\");
            Console.WriteLine("   ┌───────────────┐ ┌──────────────────┐");
            Console.WriteLine("   │    Docente    │ │  Administrativo  │");
            Console.WriteLine("   └───────────────┘ └──────────────────┘");
            Console.WriteLine("        /      \\");
            Console.WriteLine("   ┌──────────────────┐ ┌────────────┐");
            Console.WriteLine("   │  Administrador   │ │   Maestro  │");
            Console.WriteLine("   └──────────────────┘ └────────────┘");
        }
    }
}
