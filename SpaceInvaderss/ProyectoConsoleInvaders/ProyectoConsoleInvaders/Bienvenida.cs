using System;

namespace ConsoleInvaders
{
    class Bienvenida
    {
        string nombreDelJugador;
        bool salir;
        public Bienvenida(string nombre)
        {
            nombreDelJugador = nombre;
            salir = false;
        }
        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine(nombreDelJugador + ", bienvenido a Console Invaders!!");
            Console.WriteLine();
            Console.WriteLine("Para poder mover tu nave usa las flechas de derecha e izquierda");
            Console.WriteLine();
            Console.WriteLine("Para poder disparar con la nave pulsa Espacio");
            Console.WriteLine();
            Console.WriteLine("Para empezar a jugar pulsa Enter");
            Console.WriteLine();
            Console.WriteLine("Y para salir del juego pulsa ESC");

            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.Escape)
            {
                salir = true;
            }
        }
        public bool Salir()
        {
            return salir;
        }
    }
}
