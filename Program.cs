    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    namespace LABO7
    {
         class Program
        {

            static void Main(string[] args)

            {

            //=============== SISTEMA DE ANÁLISIS VEHICULAR Y SINCRONIZACIÓN DE SEMÁFOROS ===============   
            string Ovalo;
                int flujo;
                int opcion;
                string respuesta = "si";
                // creamos listas para almacenar
                List<string> historial = new List<string>();
                List<int> flujosRegistrados = new List<int>();


            // cuando el usuario salga del programa después de realizar sus registros
            // los datos se mantendrán guardados en el archivo txt y al volver a ingresar 
            // al programa se cargarán los datos anteriores para que el usuario pueda ver su historial complet
            Funciones.CargarDatos(historial, flujosRegistrados);

            // mediante la estructura do-while (mostramos el menú para que al menos se ejecute una vez
            do
                {
                // MENÚ INTERACTIVO

                    Console.WriteLine("\n==== SISTEMA DE SINCRONIZACIÓN VEHICULAR ====");
                    Console.WriteLine("1. Analizar Óvalo Izaguirre");
                    Console.WriteLine("2. Analizar Óvalo Tomás Valle");
                    Console.WriteLine("3. Ver Historial de Análisis ");
                    Console.WriteLine("4. Ver Flujos Ordenados de Menor a Mayor (Método Burbuja)");
                    Console.WriteLine("5. Exportar Reporte");
                    Console.Write("Seleccione una opción: ");
                     opcion = int.Parse(Console.ReadLine());

                    // usamos la estructura switch case para realizar una acción según
                    // la opción elegida por el usuario
                    switch(opcion)
                    {
                        case 1:
                        case 2:
                        // como la opción hacen los mismo registran
                        // utilizamos un if-else (para determinar cual Óvalo desea registrar)
                            if (opcion == 1)
                            {
                                Ovalo = "Óvalo Izaguirre";
                            }
                            else
                            {
                                Ovalo = "Óvalo Tomás Valle";
                            }

                            //aqui pedimos que ingrese los datos el usuario
                            Console.WriteLine($"Ingrese el flujo vehicular detectado en {Ovalo}: ");
                            flujo = int.Parse(Console.ReadLine());

                        // un while para corroborar que el usuario no ingrese valores negativos
                        // y si es así pedirle que ingrese los datos de nuevo
                        while ( flujo < 0)
                        {
                            Console.WriteLine("¡Entrada inválida!. El flujo debe ser un número entero positivo.");
                            Console.WriteLine($"Ingrese nuevamente el flujo vehicular detectado en {Ovalo}: ");
                            flujo = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine();
                        

                             // procedemos a llamar a la funciones
                            string Ntrafico = Funciones.NivelDeTráfico(flujo);
                            int tiempo = Funciones.TiempoSemáforo(Ntrafico);

                        // finalmente mostramos en pantalla
                            Console.WriteLine($"\n>> Nivel de tráfico detectado: {Ntrafico}");
                            Console.WriteLine($">> El tiempo de luz verde sugerido es: {tiempo} segundos.\n");

                            // guardamos el registro para poder mostrar el historial
                       string registro = $"{DateTime.Now.ToString("HH:mm:ss")} | {Ovalo}: {flujo} vehículos -> Tráfico {Ntrafico}, {tiempo}s";
                            historial.Add(registro);
                            flujosRegistrados.Add(flujo);

                        // guardams los datos en el archivo txt para que se mantegan

                        Funciones.GuardarDatos(historial);
                        break;

                        case 3:
                        // llamamos a la función para mostrar los registros
                        Funciones.HistorialdeRegistro(historial);

                            break;

                        case 4:

                        // aquí mostramos los registros ordenados 
                            Console.WriteLine("\n--- Flujo Vehicular Ordenado ---");

                        // si no hay registros almacenados mostramos un mensaje
                            if (historial.Count == 0)
                                Console.WriteLine("Aún no hay datos para ordenar");

                            // si hay procedemos a mostrar
                            else
                            {
                                // se crea una copia para no modificar el orden de registro original
                                List<int> FlujosOrdenados = new List<int>(flujosRegistrados);

                                // LLamamos a la función para que ordene
                                Funciones.OrdenamientoBurbuja(FlujosOrdenados);

                                Console.WriteLine("Flujo vehicular registrado (de menor a mayor congestión):");
                            // mediante foreach mostramos en pantalla
                                foreach (int c in FlujosOrdenados)
                                {
                                    Console.WriteLine($"- {c} vehículos");
                                }
                            }
                            break;

                            case 5:
                        // generamos el reporte para guardarlo en un archivo txt
                   
                            Console.WriteLine("\nGenerando reporte...");

                            // verificamos si hay datos para guardar
                            if (historial.Count > 0)
                            {
                            // llamamos a la función para guardar los datos en el archivo txt
                            Funciones.GuardarDatos(historial);
                            Console.WriteLine("¡Éxito! El archivo se ha guardado correctamente.");
                            }
                            // si no encuentra mostramos un mensaje
                            else
                            {
                                Console.WriteLine("No hay registros en el historial para guardar.");
                            }
                       
                            break;

                        default:
                        // si el usuario ingresa una opción fuera del rango (1-5) le mostramos un mensaje 
                        // para que vuelva a intentarlo
                            Console.WriteLine("Opción inválida.¡Vuelva a intentarlo! Seleccione un número del 1 al 5.");
                            Console.WriteLine("Presione cualquier tecla para continuar......");
                            Console.ReadKey();
                            continue;
                    }

                 // preguntamos al usuario su desea salir
    
                    Console.WriteLine("\n¿Desea realizar otro registro? (si/no)");
                    //  ToLower() pasa a minúsculas
                    respuesta = Console.ReadLine().ToLower();
        
                } while (respuesta == "si"); 
            }
        }
    }
