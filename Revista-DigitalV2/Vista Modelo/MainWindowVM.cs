using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_DigitalV2.Servicios;
using System.Windows.Controls;

namespace Revista_DigitalV2.Vista_Modelo
{
    class MainWindowVM : ObservableObject
    {
        private ServicioNavegacion servicioNavegacion;
        private UserControl contenidoVentana;
        public UserControl ContenidoVentana
        {
            get { return contenidoVentana; }
            set { SetProperty(ref contenidoVentana, value); }
        }
        public RelayCommand AbrirCreacionArticuloCommand { get; }
        public RelayCommand AbrirVistaAutorCommand { get; }
        public RelayCommand AbrirVistaArticuloCommand { get; }

        public MainWindowVM()
        {
            servicioNavegacion = new ServicioNavegacion();
            AbrirCreacionArticuloCommand = new RelayCommand(AbrirCreacionArticulo);
            AbrirVistaAutorCommand = new RelayCommand(AbrirVistaAutor);
            AbrirVistaArticuloCommand = new RelayCommand(AbrirVistaArticulo);
        }
        public void AbrirCreacionArticulo()
        {
            ContenidoVentana = servicioNavegacion.AbrirCreacionArticulo();
        }
        public void AbrirVistaAutor()
        {
            servicioNavegacion.AbrirVistaAutor();
        }
        public void AbrirVistaArticulo()
        {
            ContenidoVentana = servicioNavegacion.AbrirVistaArticulo();
        }
    }
}
