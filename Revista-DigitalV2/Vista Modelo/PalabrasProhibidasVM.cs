using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Revista_DigitalV2.Mensajes;
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
    class PalabrasProhibidasVM : ObservableObject
    {
        ServicioNavegacion servicioNavegacion;

        public RelayCommand AbrirVistaCrearListaCommand { get; }

        private ObservableCollection<ListaPalabrasProhibidas> listaProhibida;

        public ObservableCollection<ListaPalabrasProhibidas> ListaProhibida
        {
            get { return listaProhibida; }
            set { SetProperty(ref listaProhibida, value); }
        }

        private ListaPalabrasProhibidas listaSeleccionada;

        public ListaPalabrasProhibidas ListaSeleccionada
        {
            get { return listaSeleccionada; }
            set { SetProperty(ref listaSeleccionada, value); }
        }

        private ListaPalabrasProhibidas lista;

        public ListaPalabrasProhibidas Lista
        {
            get { return lista; }
            set { SetProperty(ref lista, value); }
        }

        public RelayCommand EliminarListaCommand { get; }

        public PalabrasProhibidasVM()
        {
            servicioNavegacion = new ServicioNavegacion();
            ListaProhibida = new ObservableCollection<ListaPalabrasProhibidas>();
            ListaSeleccionada = null;
            AbrirVistaCrearListaCommand = new RelayCommand(AbrirVistaCrearLista);
            EliminarListaCommand = new RelayCommand(EliminarLista);

            WeakReferenceMessenger.Default.Register<TextoModificadoMessage>(this, (r, m) =>
             {
                 Lista = m.Value;
             });

            WeakReferenceMessenger.Default.Send(new ListaModificadaMessage(ListaProhibida));
        }

        public void AbrirVistaCrearLista()
        {
            bool success = false;
            switch(servicioNavegacion.AbrirVistaCrearLista())
            {
                case true:
                    success = true;
                    break;
                case false:
                    success = false;
                    break;
                case null:
                    success = false;
                    break;
            }
            if (success)
            {
                
                ListaProhibida.Add(new ListaPalabrasProhibidas(Lista));
            }
        }

        public void EliminarLista()
        {
            ListaProhibida.Remove(ListaSeleccionada);
        }
    }
}
