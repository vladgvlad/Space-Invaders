namespace ConsoleInvaders
{
    class Juego
    {
        string nombreDelJugador; //Nombre del jugador que va a jugar Console Inavders
        public Juego(string nombre)
        {
            nombreDelJugador = nombre; //Guardamos el nombre 
        }
        public void Iniciar()
        {
            bool salirDelJuego = false;
            while (!salirDelJuego)
            {
                Bienvenida pantalla = new Bienvenida(nombreDelJugador);
                pantalla.MostrarMenu();

                if (pantalla.Salir())
                {
                    salirDelJuego = true; //Si el jugador decide salir con el Esc, se actualiza
                                         
                }
                else
                {
                    Partida partida = new Partida(nombreDelJugador); // Sino la partida empieza
                    partida.Jugar();
                }
            }
        }
    }
}
