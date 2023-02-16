using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_DigitalV2.Modelo;
using Revista_DigitalV2.Servicios;
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

        private DatabaseService servicioDatabaseService;
        public DialogoService dialogoService;
        private GenerarPaginaService generarPaginaService;
        public RelayCommand PublicarArticuloCommand { get; }

        public VistaArticuloVM()
        {
            servicioDatabaseService = new DatabaseService();
            generarPaginaService = new GenerarPaginaService();

            dialogoService = new DialogoService();
            ListaArticulos = servicioDatabaseService.MostrarArticulos();

            ArticuloSeleccionado = null;
            EliminarArticuloCommand = new RelayCommand(EliminarArticulo);
            PublicarArticuloCommand = new RelayCommand(GeneraPagina);

        }

        public void GeneraPagina()
        {
            generarPaginaService.GenerarHTML(ListaArticulos);
        }

        public void EliminarArticulo()
        {
            if (dialogoService.DialogoEliminarArticulo())
            {
                servicioDatabaseService.EliminarArticulo(ArticuloSeleccionado);
                ListaArticulos.Remove(ArticuloSeleccionado);
                ArticuloSeleccionado = null;
            }

        }
        

    }
}
