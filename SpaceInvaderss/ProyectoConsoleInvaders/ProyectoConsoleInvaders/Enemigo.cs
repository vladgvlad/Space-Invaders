using System;

namespace ConsoleInvaders.Sprites
{
    class Enemigo : Sprite
    {
        public bool vivo;  //Averiguamos si el enemigo esta vivo o destruido
        public string color; //Color de las naves de los enemigos

        public Enemigo(int x, int y, string img) : base(x, y, img)
        {
            vivo = true;
        }
        public virtual void MoverX(int movimientoX) //Movimiento de la nave en el eje x
        {
            ejeX = ejeX + movimientoX;
        }
        public override void Dibujar()
        {
            if (vivo)
            {
                ConsoleColor colorAnterior = Console.ForegroundColor;
                // Asignamos el color a los enemigos
                if (color == "amarillo")
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (color == "azul")
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (color == "rojo")
                    Console.ForegroundColor = ConsoleColor.Red;

                base.Dibujar();
                Console.ForegroundColor = colorAnterior;
            }
        }
    }
}
