using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmpresaConstructora
{

    public class Program
    {
        public static void Main()
        {
            Empresa empresa = new Empresa("Constructora XYZ");

            // Datos iniciales para pruebas
            empresa.GruposDeObreros.Add(new GrupoObrero(1));
            empresa.ObrasEnEjecucion.Add(new Obra(new Persona("Carlos", "Gomez", 10101010),null, 1, 25, 5000000));
                                                


            int opcion;
            do
            {
                Console.WriteLine("\nMENÚ DE OPCIONES");
                Console.WriteLine("1. Contratar Obrero");
                Console.WriteLine("2. Eliminar Obrero");
                Console.WriteLine("3. Contratar Jefe de Obra");
                Console.WriteLine("4. Submenú de Impresión");
                Console.WriteLine("5. Modificar Avance de Obra");
                Console.WriteLine("6. Dar de Baja a un Jefe");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Nombre: "); string nombre = Console.ReadLine();
                            Console.Write("Apellido: "); string apellido = Console.ReadLine();
                            Console.Write("DNI: "); int dni = int.Parse(Console.ReadLine());
                            Console.Write("Legajo: "); int legajo = int.Parse(Console.ReadLine());
                            Console.Write("Sueldo: "); double sueldo = double.Parse(Console.ReadLine());
                            Console.Write("Cargo: "); string cargo = Console.ReadLine();
                            Console.Write("Código de grupo: "); int codGrupo = int.Parse(Console.ReadLine());
                            GrupoObrero grupo = empresa.GruposDeObreros.Find(g => g.CodigoObra == codGrupo);
                            if (grupo != null)
                            {
                                empresa.ContratarObrero(new Obrero(nombre, apellido, dni, legajo, sueldo, cargo), grupo);
                            }
                            else
                            {
                                Console.WriteLine("Grupo no encontrado.");
                            }
                            break;
                        case 2:
                            Console.Write("DNI del obrero a eliminar: ");
                            empresa.EliminarObrero(int.Parse(Console.ReadLine()));
                            break;
                        case 3:
                            Console.Write("Nombre: "); string n = Console.ReadLine();
                            Console.Write("Apellido: "); string a = Console.ReadLine();
                            Console.Write("DNI: "); int d = int.Parse(Console.ReadLine());
                            Console.Write("Legajo: "); int l = int.Parse(Console.ReadLine());
                            Console.Write("Sueldo: "); double s = double.Parse(Console.ReadLine());
                            Console.Write("Cargo: "); string c = Console.ReadLine();
                            Console.Write("Bonificación: "); double b = double.Parse(Console.ReadLine());
                            Console.Write("Obra: "); string o = Console.ReadLine();
                            Console.Write("Código de obra: "); int co = int.Parse(Console.ReadLine());
                            GrupoObrero grupoObrero = empresa.GruposDeObreros.Find(g => g.CodigoObra == co);
                            if (grupoObrero != null)
                            {
                                empresa.ContratarJefe(new JefeObra(n, a, d, l, s, c, b, o, grupoObrero),co);
                            }
                            else
                            {
                                Console.WriteLine("No se encontró el grupo de obra.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("-- Impresiones --");
                            empresa.ImprimirObreros();
                            empresa.ImprimirObrasEnEjecucion();
                            empresa.ImprimirObrasFinalizadas();
                            empresa.ImprimirJefes();
                            Console.WriteLine($"% Remodelaciones Pendientes: {empresa.PorcentajeRemodelacionesPendientes()}%");
                            break;
                        case 5:
                            Console.Write("Código de obra: "); int cod = int.Parse(Console.ReadLine());
                            Console.Write("Nuevo avance (%): "); int av = int.Parse(Console.ReadLine());
                            empresa.ModificarAvanceDeObra(cod, av);
                            break;
                        case 6:
                            Console.Write("DNI del jefe a dar de baja: ");
                            empresa.DarDeBajaJefe(int.Parse(Console.ReadLine()));
                            break;
                    }
                }
                catch (ValueErrorException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            } while (opcion != 0);
        }
    }
}


 