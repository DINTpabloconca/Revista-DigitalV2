using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            sb.Append("<!DOCTYPE html>\n");
            sb.Append("<html lang = \"en\" xmlns = \"http://www.w3.org/1999/xhtml\">\n");
            sb.Append("<head>\n");
            sb.Append("<meta charset = \"utf - 8\" />\n");
            sb.Append("<title></title>\n");
            sb.Append("</head>\n");
            sb.Append("<body>\n");

            foreach(Articulo articuloSecciones in articulos)
            {
                string seccionActual = articuloSecciones.Seccion;
                sb.Append("<h2>" + seccionActual + "</h2>\n");

                foreach(Articulo articulo in articulos)
                {
                    sb.Append("<a href=\"" + articulo.URL + "\"/>\n");
                }

            }
            sb.Append("</body>\n");
            sb.Append("</html>\n");

            StreamWriter sw = new StreamWriter("index.html");
            sw.WriteLine(sb.ToString());
            sw.Close();
        }
    }
}
