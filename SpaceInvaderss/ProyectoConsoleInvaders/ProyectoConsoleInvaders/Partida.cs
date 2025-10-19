using System;
using ConsoleInvaders.Sprites;

namespace ConsoleInvaders
{
    class Partida
    {
        const int anchoPantalla = 80;   //Medidas de la pantalla
        const int altoPantalla = 24;
        string nombreDelJugador;
        int puntosPartida;
        int vidas;

        DisparoEnemigo[] disparosEnemigos = new DisparoEnemigo[100]; 
        int cantidadDeDisparos;

        Barrera[] barreras = new Barrera[100];
        int cantidadDeBarreras;
        public Partida(string nombre)
        {
            nombreDelJugador = nombre;   //Ponemos casi todos los datos de la partida en 0
            vidas = 3;
            puntosPartida = 0;
            cantidadDeDisparos = 0;
            cantidadDeBarreras = 0;
        }
        void LimpiarPantalla()
        {
            Console.SetCursorPosition(0, 0);

            // Recorre cada línea de la pantalla y escribe espacios para borrar contenido 
            for (int i = 0; i < altoPantalla; i++)
            {
                Console.Write(new string(' ', anchoPantalla));

                if (i < altoPantalla - 1) // Salto a la siguiente línea
                {
                    Console.WriteLine();
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        public void Jugar()
        {
            Nave nave = new Nave();
            Disparo disparoJugador = new Disparo();
            BloqueEnemigos bloque = new BloqueEnemigos();
            Ovni ovni = new Ovni();

            barreras[0] = new Barrera(5, 15); cantidadDeBarreras++;
            barreras[1] = new Barrera(20, 15); cantidadDeBarreras++; // Coordenadas de las barreras
            barreras[2] = new Barrera(35, 15); cantidadDeBarreras++;
            barreras[3] = new Barrera(50, 15); cantidadDeBarreras++;
            barreras[4] = new Barrera(65, 15); cantidadDeBarreras++;
            barreras[5] = new Barrera(5, 18); cantidadDeBarreras++;
            barreras[6] = new Barrera(20, 18); cantidadDeBarreras++;
            barreras[7] = new Barrera(35, 18); cantidadDeBarreras++;
            barreras[8] = new Barrera(50, 18); cantidadDeBarreras++;
            barreras[9] = new Barrera(65, 18); cantidadDeBarreras++;

            bool salir = false;
            Random aleatorio = new Random();
            DateTime inicio = DateTime.Now;
            string tiempoFinal = "";

            while (!salir)
            {
                LimpiarPantalla();
                TimeSpan temporizador = DateTime.Now - inicio;
                tiempoFinal = temporizador.Minutes.ToString("00") + ":" + temporizador.Seconds.ToString("00");

                Console.Write("Jugador: " + nombreDelJugador + ";  Puntos: " + puntosPartida + ";  Vidas: " + vidas + ";  Tiempo: " + tiempoFinal);
                // Datos de la partida

                nave.Dibujar();
                disparoJugador.Dibujar();
                bloque.Dibujar();
                ovni.Dibujar();

                for (int i = 0; i < cantidadDeDisparos; i++)
                {
                    disparosEnemigos[i].Dibujar();
                }

                for (int i = 0; i < cantidadDeBarreras; i++)
                {
                    barreras[i].Dibujar();
                }

                bloque.Mover();
                disparoJugador.Mover();
                ovni.Mover();

                for (int i = 0; i < cantidadDeDisparos; i++)
                {
                    disparosEnemigos[i].Mover();
                }

                Enemigo[] enemigos = bloque.CargarEnemigos();

                for (int i = 0; i < enemigos.Length; i++)
                {
                    if (enemigos[i].vivo && aleatorio.Next(1000) < 5)
                    {
                        int coordenadaDisparoEjeX = enemigos[i].ObtenerPosicionX() + enemigos[i].TamanoImagen() / 2;
                        int coordenadaDisparoEjeY = enemigos[i].ObtenerPosicionY() + 1;
                        if (cantidadDeDisparos < 100)

                        {
                            disparosEnemigos[cantidadDeDisparos] = new DisparoEnemigo(coordenadaDisparoEjeX, coordenadaDisparoEjeY);
                            cantidadDeDisparos++;
                        }
                    }
                }

                for (int i = 0; i < enemigos.Length; i++)
                {
                    if (enemigos[i].vivo && disparoJugador.activo && Colision(disparoJugador, enemigos[i]))
                    {
                        disparoJugador.Desactivar(); //Si impactamos en una nave, el marcador sube 10 puntos
                        enemigos[i].vivo = false;
                        puntosPartida += 10;
                        break;
                    }
                }

                if (ovni.activo && disparoJugador.activo &&
                    Colision(disparoJugador, ovni))

                {
                    disparoJugador.Desactivar(); //Si el disparo impacta con el ovni ganamos 50 puntos
                    ovni.Desactivar();
                    puntosPartida += 50;
                }

                for (int i = cantidadDeDisparos - 1; i >= 0; i--)
                {
                    if (Colision(disparosEnemigos[i], nave))
                    {
                        for (int j = i; j < cantidadDeDisparos - 1; j++) //Si un enemigo dispara y nos impacta, se quita 1 vida
                        {
                            disparosEnemigos[j] = disparosEnemigos[j + 1];
                        }

                        cantidadDeDisparos--;
                        vidas--;

                        if (vidas <= 0) //Si las vidas llegan a 0, se acaba la aprtida
                        {
                            salir = true;
                        }
                    }
                }

                if (disparoJugador.activo)
                {
                    for (int i = 0; i < cantidadDeBarreras; i++)
                    {
                        if (Colision(disparoJugador, barreras[i]))
                        {

                            disparoJugador.Desactivar();
                            barreras[i].RecibirDanio();
                            if (barreras[i].Destruida())
                            {
                                for (int j = i; j < cantidadDeBarreras - 1; j++) //Si el disparo enemigo impacta con la barrea, se le resta una vida
                                {
                                    barreras[j] = barreras[j + 1];
                                }
                                cantidadDeBarreras--;
                                i--; 
                            }
                        }
                    }
                }

                for (int i = cantidadDeDisparos - 1; i >= 0; i--)
                {
                    for (int j = 0; j < cantidadDeBarreras; j++)
                    {
                        if (Colision(disparosEnemigos[i], barreras[j]))
                        {

                            // Eliminar disparo enemigo

                            for (int k = i; k < cantidadDeDisparos - 1; k++)
                            {
                                disparosEnemigos[k] = disparosEnemigos[k + 1];
                            }
                            cantidadDeDisparos--;
                            barreras[j].RecibirDanio();
                            if (barreras[j].Destruida())
                            {
                                for (int k = j; k < cantidadDeBarreras - 1; k++)
                                {
                                    barreras[k] = barreras[k + 1];
                                }
                                cantidadDeBarreras--;
                                j--;
                            }
                            break;
                        }
                    }
                }

                if (!bloque.Enemigos())
                {
                    salir = true;
                }


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.Escape) // Salir al pulsar ESC
                    {
                        salir = true;
                    }
                    else if (tecla.Key == ConsoleKey.LeftArrow)
                    {
                        nave.MoverIzquierda();
                    }
                    else if (tecla.Key == ConsoleKey.RightArrow) // Con las flechas se mueve la nave
                    {
                        nave.MoverDerecha();
                    }
                    else if (tecla.Key == ConsoleKey.Spacebar) // Y con el espacio se dispara
                    {
                        int xDisp = nave.ObtenerPosicionX() + nave.TamanoImagen() / 2;
                        int yDisp = nave.ObtenerPosicionY() - 1;
                        disparoJugador.Disparar(xDisp, yDisp);
                    }
                }

                Thread.Sleep(60); // Velocidad del movimiento de las naves
            }

            Podio.Actualizar(nombreDelJugador, puntosPartida);
            Console.Clear();
            Console.WriteLine("Tu puntuación es de: " + puntosPartida + " puntos");  //Tu puntuación al terminar la partida: 
            Console.WriteLine();
            Console.WriteLine("Has durado: " + tiempoFinal + " segundos.");
            Console.WriteLine();
            Console.WriteLine("Mejores puntaciones: ");

            string[] nombresPantalla = new string[10];
            int[] puntosPantalla = new int[10];
            Podio.Obtener(nombresPantalla, puntosPantalla);
            for (int i = 0; i < 10; i++)
            {
                if (nombresPantalla[i] != "")
                {
                    Console.WriteLine(nombresPantalla[i] + ": " + puntosPantalla[i]);
                }
            }
            Console.WriteLine("Presiona cualquier tecla para volver al menú: ");
            Console.ReadKey(true);
        }

        // Métodopara detectar colisiones 
        bool Colision(Sprite objetoA, Sprite objetoB)
        {
            int izquierdaA = objetoA.ObtenerPosicionX();
            int derechaA = izquierdaA + objetoA.TamanoImagen();
            int izquierdaB = objetoB.ObtenerPosicionX();
            int derechaB = izquierdaB + objetoB.TamanoImagen();

            bool colisionX = derechaA > izquierdaB && izquierdaA < derechaB;
            bool colisionY = objetoA.ObtenerPosicionY() == objetoB.ObtenerPosicionY();

            return colisionX && colisionY;
        }
    }
}
