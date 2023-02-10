using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Servicios
{
    class GenerarPáginaService
    {
        public void GenerarHTML(ObservableCollection<Articulo> articulos)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang = \"en\" xmlns = \"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<meta charset = \"utf - 8\" />");
            sb.Append("<title></title>");
            sb.Append("</head>");
            sb.Append("<body>");

            foreach(Articulo articuloSecciones in articulos)
            {
                string seccionActual = articuloSecciones.Seccion;
                sb.Append("<h2>" + seccionActual + "</h2>");

                foreach(Articulo articulo in articulos)
                {
                    sb.Append("<a href=\"" + articulo.URL + "\"/>");
                }

            }
            sb.Append("</body>");
            sb.Append("</html> ");

        }
    }
}
