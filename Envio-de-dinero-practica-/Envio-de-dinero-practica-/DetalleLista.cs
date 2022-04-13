using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleLista
    {
        public List<Movimiento> Movimientos { get; set; }
        public int CodigoError { get; set; }

        public DetalleLista() { }
        public DetalleLista(List<Movimiento> movimientos)
        {
            this.Movimientos = movimientos;
        }
        public DetalleLista (int codigoError)
        {
            this.CodigoError = codigoError;
        }
    }
}
