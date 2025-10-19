using System;

namespace ConsoleInvaders.Sprites
{
    class Sprite
    {
        protected int ejeX, ejeY;
        protected string imagen;

        public Sprite(int x, int y, string img) // Constructor que inicializa la posición y la imagen del sprite
        {
            ejeX = x;
            ejeY = y;
            imagen = img;
        }

        public int TamanoImagen()
        {
            return imagen.Length;
        }

        public virtual void Dibujar() // Método para dibujar el sprite en la consola
        {
            if (ejeX >= 0 && ejeY >= 0 &&
                ejeX < Console.WindowWidth && ejeY < Console.WindowHeight)
            {
                Console.SetCursorPosition(ejeX, ejeY);
                Console.Write(imagen);
            }
        }

        public void MoverX(int dato) 
        {
            ejeX = ejeX + dato;
        }

        public int ObtenerPosicionX() //Metodo que devuelve la posicion actual de Y
        {
            return ejeX;
        }

        public int ObtenerPosicionY() //Metodo que devuelve la posicion actual de X
        {
            return ejeY;
        }
    }
}
