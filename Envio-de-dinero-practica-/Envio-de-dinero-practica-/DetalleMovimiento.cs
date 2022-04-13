using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleMovimiento
    {
        public int CodigoValidacion { get; set; }
        public string ErrorValidacion { get; set; }

        public DetalleMovimiento() { }
        public DetalleMovimiento(int codigoValidacion)
        {
            this.CodigoValidacion = codigoValidacion;
            this.ErrorValidacion = "";
        }
        public DetalleMovimiento(int codigoValidacion, string errorValidacion)
        {
            this.CodigoValidacion = codigoValidacion;
            this.ErrorValidacion = errorValidacion;
        }
    }
}
