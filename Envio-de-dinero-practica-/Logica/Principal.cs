using Entidades;
namespace Logica
{
    public class LogicaAplicacion
    {
        public List<Usuario>? Usuarios { get; set; }
        public List<Movimiento>? Movimientos { get; set; }

        const int codigoValidacionCorrecta = 201;
        const int codigoValidacionIncorrecta = 400;
        const int codigoNoExisteDni = 404;

        public DetalleMovimiento CrearMovimiento(int dniUsuarioEnvia, int dniUsuarioRecibe, string descripcion, decimal montoEnviar)
        {
            Usuario usuarioEnvia = EncontrarUsuario(dniUsuarioEnvia);
            Usuario usuarioRecibe = EncontrarUsuario(dniUsuarioRecibe);
            if (usuarioEnvia != null && usuarioRecibe != null && usuarioEnvia.Saldo <= montoEnviar)
            {
                Movimiento nuevoMovimientoUsuarioEnvia = new Movimiento(Movimientos.Count + 1, DateTime.Now.Date, descripcion, montoEnviar * -1, usuarioEnvia.Dni, usuarioRecibe.Dni);
                usuarioEnvia.MovimientosUsuario.Add(nuevoMovimientoUsuarioEnvia);
                Movimiento nuevoMovimientoUsuarioRecibe = new Movimiento(Movimientos.Count + 1, DateTime.Now.Date, descripcion, montoEnviar, usuarioEnvia.Dni, usuarioRecibe.Dni);
                usuarioRecibe.MovimientosUsuario.Add(nuevoMovimientoUsuarioRecibe);
                usuarioEnvia.Saldo = usuarioEnvia.Saldo - montoEnviar;
                usuarioRecibe.Saldo = usuarioRecibe.Saldo + montoEnviar;
                DetalleMovimiento detalleMovimiento = new DetalleMovimiento(codigoValidacionCorrecta);
                Movimientos.Add(nuevoMovimientoUsuarioRecibe);
                Movimientos.Add(nuevoMovimientoUsuarioEnvia);
                return detalleMovimiento;
            }
            else
            {
                string descripcionValidacionIncorrecta = "El monto a enviar es mayor al saldo disponible del usuario emisor";
                if (usuarioEnvia == null)
                {
                    descripcionValidacionIncorrecta = "No coincide el DNI ingresado del usuario emisor";
                }
                else
                {
                    descripcionValidacionIncorrecta = "No coincide el DNI ingresado del usuario receptor";
                }
                DetalleMovimiento detalleMovimiento = new DetalleMovimiento(codigoValidacionIncorrecta, descripcionValidacionIncorrecta);
                return detalleMovimiento;
            }
        }

        public bool CancelarMovimiento(int idMovimiento)
        {
            Movimiento? movimiento = Movimientos.Find(x => x.Id == idMovimiento);
            if (movimiento != null)
            {
                Usuario usuarioRecibe = EncontrarUsuario(movimiento.DniUsuarioRecibe);
                Usuario usuarioEnvia = EncontrarUsuario(movimiento.DniUsuarioEnvia);
                CrearMovimiento(usuarioRecibe.Dni, usuarioEnvia.Dni, "Cancelacion" + movimiento.Descripcion, movimiento.Monto);
                usuarioEnvia.MovimientosUsuario.Remove(movimiento);
                usuarioRecibe.MovimientosUsuario.Remove(movimiento);
                return true;
            }
            return false;
        }

        public List<Movimiento> RetornarListaMovimientos(int dni)
        {

            Usuario usuario = EncontrarUsuario(dni);
            if (usuario != null)
            {
                return usuario.MovimientosUsuario;
            }
            else
            {
                throw new Exception($"{codigoNoExisteDni}");
            }
        }

        public Usuario EncontrarUsuario(int dniUsuario)
        {
            return Usuarios.Find(x => x.Dni == dniUsuario);
        }
    }
}