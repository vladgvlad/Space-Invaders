namespace ConsoleInvaders.Sprites
{
    class Nave : Sprite
    {
        int limiteIzq = 3;
        int limiteDer = 75;  //Limites de la pantalla para mover tu nave

        public Nave() : base(40, 20, "/\\")  //Posicion inicial de tu nave y su diseño
        {
        }

        public void MoverDerecha()
        {
            if (ejeX < limiteDer)  //De cuanto en cuanto se va a mover la nave a la derecha
            {
                ejeX = ejeX + 2;
            }
        }

        public void MoverIzquierda()
        {
            if (ejeX > limiteIzq) //De cuanto en cuanto se va a mover la nave a la izquierda
            {
                ejeX = ejeX - 2;
            }
        }
    }
}
