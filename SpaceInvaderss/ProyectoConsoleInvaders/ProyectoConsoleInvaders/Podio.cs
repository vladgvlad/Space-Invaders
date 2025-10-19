using System;
using System.IO;

namespace ConsoleInvaders
{
    class Podio
    {
        static string[] nombres = new string[10];
        static int[] puntos = new int[10];
        static string nombreArchivo = "podio.txt"; //Las marcas se almacenan en un archivo: 

        public static void Actualizar(string jugador, int puntosObtenidos)
        {
            LeerScores();

            int posicion = -1;
            for (int i = 0; i < 10; i++) //Almacenamos las marcas de distintos jugadores
            {
                if (nombres[i] == "")
                {
                    posicion = i;
                    break;
                }
            }
            if (posicion == -1)
            {
                int min = puntos[0];
                posicion = 0;
                for (int i = 1; i < 10; i++)
                {
                    if (puntos[i] < min)
                    {
                        min = puntos[i];
                        posicion = i;
                    }
                }
                if (puntosObtenidos <= puntos[posicion])
                {
                    GuardarScores();
                    return;
                }
            }
            nombres[posicion] = jugador;
            puntos[posicion] = puntosObtenidos;

            // Ordenamos con el metodo burbuja
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (puntos[i] < puntos[j])
                    {
                        int tempPts = puntos[i];
                        puntos[i] = puntos[j];
                        puntos[j] = tempPts;
                        string tempNom = nombres[i];
                        nombres[i] = nombres[j];
                        nombres[j] = tempNom;
                    }
                }
            }
            GuardarScores();
        }

        public static void LeerScores() //Metodo para leer las marcas de los jugadores desde el archivo
        {
            for (int i = 0; i < 10; i++)
            {
                nombres[i] = "";
                puntos[i] = 0;
            }
            if (File.Exists(nombreArchivo))
            {
                string[] lineas = File.ReadAllLines(nombreArchivo);
                for (int i = 0; i < lineas.Length && i < 10; i++)
                {
                    string linea = lineas[i];
                    int pos = linea.IndexOf(",");
                    if (pos > 0)
                    {
                        nombres[i] = linea.Substring(0, pos);
                        int val = 0;
                        int.TryParse(linea.Substring(pos + 1), out val);
                        puntos[i] = val;
                    }
                }
            }
        }

        public static void GuardarScores() //Metodo para guardar las puntuaciones en el archivo
        {
            string salida = "";
            for (int i = 0; i < 10; i++)
            {
                if (nombres[i] != "")
                    salida = salida + nombres[i] + "," + puntos[i] + "\n";
            }
            File.WriteAllText(nombreArchivo, salida);
        }

        public static void Obtener(string[] outNombres, int[] outPuntos) //metodo para obtener las posiciones de las mejores puntuaciones
        {
            for (int i = 0; i < 10; i++)
            {
                outNombres[i] = nombres[i];
                outPuntos[i] = puntos[i];
            }
        }
    }
}
