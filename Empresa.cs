using EmpresaConstructora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmpresaConstructora
{
    public class Empresa
    {
        public string NombreEmpresa { get; set; }
        public List<Obra> ObrasEnEjecucion { get; set; }

        public List<Obra> ObrasFinalizadas { get; set; }

        public List<GrupoObrero> GruposDeObreros { get; set; }

        public List<Obrero> Obreros { get; set; }

        public List<JefeObra> Jefes { get; set; }

        public void ContratarObrero(Obrero o, GrupoObrero g)
        {
            Obreros.Add(o);
            g.Obreros.Add(o);

        }

        public Empresa(string nombreEmpresa)
        {
            NombreEmpresa = nombreEmpresa;
            ObrasEnEjecucion = new List<Obra>();
            ObrasFinalizadas = new List<Obra>();
            GruposDeObreros = new List<GrupoObrero>();
            Obreros = new List<Obrero>();
            Jefes = new List<JefeObra>();
        }
        public void EliminarObrero(int dni)
        {
            var obrero = Obreros.Find(o => o.Dni == dni);
            if (obrero != null)
            {
                foreach (var grupo in GruposDeObreros)
                {
                    grupo.Obreros.Remove(obrero);
                }
                Obreros.Remove(obrero);
            }
        }

        public void ContratarJefe(JefeObra jefe, int codigoObra)
        {
            GrupoObrero GrupoLibre = GruposDeObreros.Find(g => g.EstaLibre());
            if (GrupoLibre == null)
            {
                throw new ValueErrorException("No hay grupos de obreros disponibles");
            }
            jefe.Grupos = GrupoLibre;
            Jefes.Add(jefe);
            Obra obra = ObrasEnEjecucion.Find(o => o.CodigoObra == codigoObra);
            if (obra != null)
            {
                obra.Jefe = jefe;
                jefe.Obra = obra.TipoObra;
            }
        }

        public void DarDeBajaJefe(int dni)
        {
            JefeObra jefe = Jefes.Find(j => j.Dni == dni);
            if (jefe != null)
            {
                foreach (var obra in ObrasEnEjecucion)
                {
                    if (obra.Jefe != null && obra.Jefe.Dni == jefe.Dni)
                    {
                        obra.Jefe = null;
                    }
                }
                jefe.Grupos.Obreros.Clear();
                Jefes.Remove(jefe);
            }


        }

        public void ModificarAvanceDeObra(int codigoObra, int porcentaje)
        {
            Obra obra = ObrasEnEjecucion.Find(o => o.CodigoObra == codigoObra);
            if (obra != null)
            {
                obra.AvanceObra = porcentaje;
                if (obra.EstaFinalizado())
                {
                    ObrasFinalizadas.Add(obra);
                    ObrasEnEjecucion.Remove(obra);
                }
            }
        }

        public void ImprimirObreros()
        {
            foreach (var obrero in Obreros)
            {
                Console.WriteLine($"Obrero: {obrero.Nombre} {obrero.Apellido}, Cargo: {obrero.Cargo}, Sueldo{obrero.Sueldo}");
            }
        }

        public void ImprimirObrasEnEjecucion()
        {
            foreach (var obra in ObrasEnEjecucion)
            {
                Console.WriteLine($"Obra: {obra.CodigoObra}- Tipo: {obra.TipoObra}, Avance: {obra.AvanceObra}%");
            }
        }
        public void ImprimirObrasFinalizadas()
        {
            foreach (var obra in ObrasFinalizadas)
            {
                Console.WriteLine($"Obra: {obra.CodigoObra} Finalizada - Tipo: {obra.TipoObra}");
            }
        }

        public void ImprimirJefes()
        {
            foreach (var jefe in Jefes)
            {
                Console.WriteLine($"Jefe: {jefe.Nombre} {jefe.Apellido}, Bonificación: {jefe.Bonificacion}");
            }
        }

        public float PorcentajeRemodelacionesPendientes()
        {
            int total = ObrasEnEjecucion.Count + ObrasFinalizadas.Count;

            if (total == 0)
            {
                return 0;
            }

            int remodelacionesPendientes = ObrasEnEjecucion
                .FindAll(o => string.Equals(o.TipoObra, "remodelacion", StringComparison.OrdinalIgnoreCase))
                .Count;

            return (float)remodelacionesPendientes / total * 100;
        }

        //Función recursiva: Cuenta cantidad de obreros con una lista
        public int ContarObrerosRecursivo(List<Obrero> obreros, int index = 0)
        {
            if (index >= obreros.Count)
            {
                return 0;
            }
            return 1 + ContarObrerosRecursivo(obreros, index + 1);
        }
    }
}
       
        //ContratarObrero(o: Obrero, g: Grupo); listo
        //EliminarObrero(dni: string); listo
        //ContratarJefe(j: JefeDeObra); listo
        //DarDeBajaJefe(dni: string); listo
        //ModificarAvanceObra(codigoObra: string, porcentaje: int) LISTO
        //ImprimirObreros() listo
        //ImprimirObrasEnEjecucion() listo
        //ImprimirObrasFinalizadas() listo
        //ImprimirJefes() listo 
        //PorcentajeRemodelacionesPendientes(): float listo
