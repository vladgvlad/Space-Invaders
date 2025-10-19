namespace ConsoleInvaders.Sprites
{
    class Barrera : Sprite  //Clase que se hereda de Sprite
    {
        int vidas;
        public Barrera(int x, int y) : base(x, y, "----")
        {
            vidas = 2;  //La barrera tendra 2 vidas antes de desaparecer
        }
        public bool Destruida()
        {
            return (vidas <= 0);
        }
        public void RecibirDanio()
        {
            vidas = vidas - 1;
        }
        public override void Dibujar()  //Metodo para dibujar la barrera
        {
            if (!Destruida())
                base.Dibujar();
        }
    }
}
