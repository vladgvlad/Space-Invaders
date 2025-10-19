using System;

namespace ConsoleInvaders.Sprites
{
    class BloqueEnemigos
    {
        Enemigo[,] matriz; // Matriz que va a rpresenta el bloque de los enemigos
        int filas;
        int columnas;
        int direccion = 1;

        public BloqueEnemigos()
        {
            filas = 3;   //Numero de filas que van a tner los enemigos
            columnas = 10; // Numero de enemigos por fila
            matriz = new Enemigo[filas, columnas];


            int inicioEnemigoX = 15, inicioEnemigoY = 5; // Coordenadas de los enemigos
            int distanciaX = 6, distanciaY = 2;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    int x = inicioEnemigoX + j * distanciaX;
                    int y = inicioEnemigoY + i * distanciaY;
                    matriz[i, j] = new Enemigo(x, y, "XX");
         

                    // Cambiamos de color los enemigos
                    if (i == 0)
                    {
                        matriz[i, j].color = "amarillo"; 
                    }
                    else if (i == 1)
                    {
                        matriz[i, j].color = "azul";    
                    }
                    else
                    {
                        matriz[i, j].color = "rojo";     
                    }
                }
            }
        }
        public void Dibujar()
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    matriz[i, j].Dibujar();
                }
            }
        }
        public void Mover()
        {
            int minX = 10000;  
            int maxX = 0;      

            MoverEnemigos();             // Hace que todos los enemigos vayan juntos a la misma dirección
            ActualizarLimites(ref minX, ref maxX); 
            AjustarDireccion(minX, maxX); 
        }

        private void MoverEnemigos()
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    matriz[i, j].MoverX(direccion); 
                }
            }
        }

        private void ActualizarLimites(ref int minX, ref int maxX)  //Busqca al enemigo que mas a la derecha e izquierda esté
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (matriz[i, j].vivo)
                    {
                        int ex = matriz[i, j].ObtenerPosicionX();
                        int ancho = matriz[i, j].TamanoImagen();

                        minX = Math.Min(minX, ex);
                        maxX = Math.Max(maxX, ex + ancho);
                    }
                }
            }
        }

        private void AjustarDireccion(int minX, int maxX)
        { // Limites para que los enemigos no se salgan de la pantalla
            if (minX < 3)
            {
                direccion = 1;
            }

            if (maxX > 75)
            {
                direccion = -1;
            }
        }

        public Enemigo[] CargarEnemigos()
        {
            Enemigo[] todos = new Enemigo[filas * columnas];
            int k = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    todos[k] = matriz[i, j];
                    k++;
                }
            }
            return todos;
        }

        public bool Enemigos() //Metodo para saber si todos los enemigos siguen vivos
        {
            Enemigo[] todos = CargarEnemigos();
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].vivo)
                    return true;
            }
            return false;
        }
    }
}
