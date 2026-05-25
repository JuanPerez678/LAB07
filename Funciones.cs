using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABO7
{
    internal class Funciones
    {
        // 1) FUNCIÓN PARA DETERMINAR EL NIVEL DEL TRÁFICO
        public static string NivelDeTráfico(int cantidadDeVehículos)
        {
            if (cantidadDeVehículos > 1100)
                return "ALTO";

            else if (cantidadDeVehículos > 600)
                return "INTERMEDIO";

            else
                return "BAJO";

        }
        // 2) FUNCIÓN PARA DETERMINAR EL TIEMPO DEL SEMÁFORO
        public static int TiempoSemáforo(string NiveldeTráfico)
        {
            if (NiveldeTráfico == "ALTO")
                return 60;

            else if (NiveldeTráfico == "INTERMEDIO")
                return 45;

            else
                return 30;
        }


        // 3) FUNCIÓN PARA MOSTRAR EL HISTORIAL DE REGISTRO

       public static void HistorialdeRegistro(List<string> historial)
        {
            if (historial.Count == 0)
            {
                // si no hay nd mostramos un mensaje
                Console.WriteLine("Aún no hay registros");
            } 
            else
            {
                // si hay mostramos los registros guardados en la lista
                foreach (string r in historial)
                {
                    Console.WriteLine(r);
                }
            }

        }
        // 4) FUNCIÓN PARA ORDENAR EL REGISTRO DE MAYOR A MENOR (Bucle Burbuja)
        public static void OrdenamientoBurbuja(List<int> lista)
        {
            int c = lista.Count;
            for (int i = 0; i < c - 1; i++)
            {
                for (int j = 0; j < c - 1 - i; j++)
                {
                    if (lista[j] > lista[j + 1]) // comparación
                    {
                        int aux = lista[j]; // Intercambio
                        lista[j] = lista[j + 1];
                        lista[j + 1] = aux;
                    }
                }
            }
        }
      
    }
}
