using Microsoft.Toolkit.Mvvm.ComponentModel;
using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Vista_Modelo
{
    class VistaArticuloVM : ObservableObject
    {
        private ObservableCollection<Articulo> listaArticulos;

        public ObservableCollection<Articulo> ListaArticulos
        {
            get { return listaArticulos; }
            set { SetProperty(ref listaArticulos, value); }
        }

        public VistaArticuloVM()
        {
            ListaArticulos = new ObservableCollection<Articulo>();
            // ejemplos articulos
            ListaArticulos.Add(new Articulo(new Autor("Juan", "Ju", ".", "twitter"), "In", "a", "b", "d"));
        
        }
        

    }
}
