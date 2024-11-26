using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefinalProgramacionPunto3D.Entidades
{
    public class Punto3D
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string Color { get; set; }

        public Punto3D() { }

        public Punto3D(int x, int y, int z, string color)
        {
            X = x;
            Y = y;
            Z = z;
            Color = color;
        }

        public double GetDistanciaOrigen()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        public string MostrarTexto()
        {
            return $"Punto3D(X: {X}, Y: {Y}, Z: {Z})";
        }

    }
}
