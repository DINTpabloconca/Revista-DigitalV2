
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
        bool VistaArticulo = false;
        VistaArticuloUserControl vista = null;

        public CreacionArticuloUserControl AbrirCreacionArticulo()
        {
            return new CreacionArticuloUserControl();
        }
        public VistaAutorUserControl AbrirVistaAutor()
        {
            return new VistaAutorUserControl();
        }

        public VistaArticuloUserControl AbrirVistaArticulo()
        {
           
            if (!VistaArticulo)
            {
                vista = new VistaArticuloUserControl();
                VistaArticulo = true;
                return vista;
            }
            else
                return vista;

        }
    }
}
