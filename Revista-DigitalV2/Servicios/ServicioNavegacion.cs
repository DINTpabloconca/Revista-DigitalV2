
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Revista_DigitalV2.Vistas;


namespace Revista_DigitalV2.Servicios
{
    class ServicioNavegacion
    {
        public CreacionArticuloUserControl AbrirCreacionArticulo()
        {
            return new CreacionArticuloUserControl();
        }
        public bool? AbrirVistaAutor()
        {
            VistaAutor vistaAutor = new VistaAutor();
            return vistaAutor.ShowDialog();
        }
    }
}
