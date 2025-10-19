namespace ConsoleInvaders.Sprites
{
    class Disparo : Sprite
    {
        public bool activo;  // Noa ayuda a saber si el disparo esta en movimiento 

        public Disparo() : base(-1, -1, "|")
        {
            activo = false;
        }

        public void Disparar(int x, int y)
        {
            if (!activo)
            {
                ejeX = x;  // Dispara en la posicion de nve al darle a espacio
                ejeY = y;
                activo = true;
            }
        }
        public void Mover()
        {
            if (activo)
            {
                ejeY = ejeY - 1;  // Hace que el disparo vaya arriba
                if (ejeY < 0)
                    activo = false;
            }
        }

        public override void Dibujar()
        {
            if (activo)
                base.Dibujar();
        }

        public void Desactivar()
        {
            activo = false;
        }
    }
}
