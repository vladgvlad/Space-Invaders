using System;

namespace ConsoleInvaders
{
    class ConfiguracionConsola // clase para que al abrir el proyecto en otro ordenador, no ocurra ningún error
    {
        public static void Configurar()
        {
            try
            {
                Console.SetWindowSize(80, 24);
                Console.SetBufferSize(80, 24);
            }
            catch (Exception)
            {

            }
            Console.CursorVisible = false;
        }
    }
}
