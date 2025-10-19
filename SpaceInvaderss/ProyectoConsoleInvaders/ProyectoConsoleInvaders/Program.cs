using System;

namespace ConsoleInvaders
{
    class Program
    {
        static void Main()
        {
            ConfiguracionConsola.Configurar();

            Console.Write("Escribe tu nombre: ");
            string nombre = Console.ReadLine();

            if (nombre == "")
            nombre = "Jugador";

            Juego juego = new Juego(nombre);
            juego.Iniciar();
        }
    }
}
