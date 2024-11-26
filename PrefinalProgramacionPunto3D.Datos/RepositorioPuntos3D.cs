using PrefinalProgramacionPunto3D.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefinalProgramacionPunto3D.Datos
{
    public class RepositorioPuntos3D
    {
        private List<Punto3D> lista;

        public RepositorioPuntos3D()
        {
            lista = new List<Punto3D>();
        }

        public void AgregarPunto(Punto3D punto)
        {
            lista.Add(punto);
        }

        public void EliminarPunto(Punto3D punto)
        {
            lista.Remove(punto);
        }

        public bool Existe(Punto3D punto)
        {
            return lista.Any(p => p.X == punto.X && p.Y == punto.Y && p.Z == punto.Z);
        }

        public int GetCantidad()
        {
            return lista.Count;
        }

        public List<Punto3D> GetLista()
        {
            return lista;
        }

        public List<Punto3D> OrdernarPorDistanciaOrigen()
        {
            return lista.OrderBy(p => p.GetDistanciaOrigen()).ToList();
        }

        public List<Punto3D> OrdernarPorDistanciaOrigenDesendiente()
        {
            return lista.OrderByDescending(p => p.GetDistanciaOrigen()).ToList();
        }

    }
}
