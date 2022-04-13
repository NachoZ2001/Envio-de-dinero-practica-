using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int DniUsuarioEnvia { get; set; }
        public int DniUsuarioRecibe { get; set; }

        public Movimiento() { }
        public Movimiento(int id, DateTime fechaMovimiento, string descripcion, decimal monto, int dniUsuarioEnvia, int dniUsuarioRecibe)
        {
            this.Id = id;
            this.FechaMovimiento = fechaMovimiento;
            this.Descripcion = descripcion;
            this.Monto = monto;
            this.DniUsuarioEnvia = dniUsuarioEnvia;
            this.DniUsuarioRecibe = dniUsuarioRecibe;
        }
    }
}
