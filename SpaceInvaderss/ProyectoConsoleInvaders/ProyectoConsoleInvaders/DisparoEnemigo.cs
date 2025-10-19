namespace ConsoleInvaders.Sprites
{
    class DisparoEnemigo : Sprite
    {
        public bool activo;

        public DisparoEnemigo(int x, int y) : base(x, y, "v") // Diseño del disparo del enemigo
        {
            activo = true;
        }

        public void Mover() // Movimiento del disparo hacia abajo
        {
            if (activo)
            {
                ejeY = ejeY + 1;
                if (ejeY > System.Console.WindowHeight)
                    activo = false;
            }
        }
        public override void Dibujar()
        {
            if (activo)
                base.Dibujar();
        }
    }
}
