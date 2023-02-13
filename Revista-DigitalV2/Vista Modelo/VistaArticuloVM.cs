using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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

        public RelayCommand EliminarArticuloCommand { get; }

        private Articulo articuloSeleccionado;

        public Articulo ArticuloSeleccionado
        {
            get { return articuloSeleccionado; }
            set { SetProperty(ref articuloSeleccionado, value); }
        }


        public VistaArticuloVM()
        {
            ListaArticulos = new ObservableCollection<Articulo>();
            // ejemplos articulos
            ListaArticulos.Add(new Articulo(2, "In", "a", "b", "d"));
            ArticuloSeleccionado = null;
            EliminarArticuloCommand = new RelayCommand(EliminarArticulo);

        }


        public void EliminarArticulo ()
        {
            ListaArticulos.Remove(ArticuloSeleccionado);
            ArticuloSeleccionado = null;
        }
        

    }
}
