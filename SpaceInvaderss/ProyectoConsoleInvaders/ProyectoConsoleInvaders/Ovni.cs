using System;

namespace ConsoleInvaders.Sprites
{
    class Ovni : Enemigo
    {
        public bool activo;
        static Random rd = new Random();

        public Ovni() : base(-30, 2, "<-O->") //Diseño del ovni
        {
            activo = false;
        }

        public override void Dibujar() //Metodo para dibujar al ovni en la pantalla si esta activo
        {
            if (activo)
                base.Dibujar();
        }

        public void Mover()
        {
            if (activo)
            {
                if (ejeX < Console.WindowWidth)
                    ejeX = ejeX + 1;
                else
                    activo = false;
            }
            else
            {
                if (rd.Next(1000) < 5)
                {
                    ejeX = -5;
                    ejeY = 2;
                    activo = true;
                }
            }
        }

        public void Desactivar()
        {
            activo = false;
        }
    }
}
