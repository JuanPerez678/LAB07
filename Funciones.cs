using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABO7
{
    internal class Funciones
    {
        static string archivo = "Reporte_Tráfico.txt";
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

        // 5) FUNCIÓN PARA GUARDAR LOS REGISTROS EN UN ARCHIVO DE TEXTO
        public static void GuardarDatos(List<string> historial)
        {
            try
            {
                // Guarda directamente todo el historial de texto
                File.WriteAllLines(archivo, historial);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error al guardar] No se pudo escribir en el archivo: {ex.Message}");
            }

        }
        public static void CargarDatos(List<string> historial, List<int> flujos)
        {
            try
            {
                // verificamos que el archiv exista 
                if (File.Exists(archivo))
                {
                    // limpiamos la memoria antes de cargar los datos 
                    historial.Clear();
                    flujos.Clear();
                    
                    // leemos las líneas del archivo y lo guardamos en un arreglo 
                    string[] lineas = File.ReadAllLines(archivo);
                    // recorremos el arreglo
                    foreach(string l in lineas)
                    {
                        historial.Add(l);

                        // aqui delimitamos para obtener el número de vehículos registrado
                        // para posteriormete si el usuario desea visualizar
                        // el flujo vehicular ordenado poder mostrarlo
                        if (l.Contains(": ") && l.Contains(" vehículos"))
                        {
                            int posicionInicio = l.IndexOf(": ") + 2;
                            int posicionFin = l.IndexOf(" vehículos");

                            // cortamos la parte que contiene solo el número
                            string numero = l.Substring(posicionInicio, posicionFin - posicionInicio);
                            if (int.TryParse(numero, out int numeroConver))
                            {
                                flujos.Add(numeroConver);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error al cargar] No se pudo leer el archivo: {ex.Message}");
            }
        }
    }
}
