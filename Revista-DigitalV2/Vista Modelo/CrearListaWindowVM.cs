using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Revista_DigitalV2.Mensajes;
using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Vista_Modelo
{
    class CrearListaWindowVM : ObservableRecipient
    {
        private string palabraEscrita;

        public string PalabraEscrita
        {
            get { return palabraEscrita; }
            set { SetProperty(ref palabraEscrita, value); }
        }

        private ObservableCollection<string> listaPalabras;

        public ObservableCollection<string> ListaPalabras
        {
            get { return listaPalabras; }
            set { SetProperty(ref listaPalabras, value); }
        }

        private string palabraSeleccionada;

        public string PalabraSeleccionada
        {
            get { return palabraSeleccionada; }
            set { SetProperty(ref palabraSeleccionada, value); }
        }

        private ListaPalabrasProhibidas añadirLista;

        public ListaPalabrasProhibidas AñadirLista
        {
            get { return añadirLista; }
            set { SetProperty(ref añadirLista, value); }
        }


        public RelayCommand AñadirPalabraCommand { get; }
        public RelayCommand EliminarPalabraCommand { get; }

        public CrearListaWindowVM()
        {
            PalabraEscrita = "";
            ListaPalabras = new ObservableCollection<string>();
            PalabraSeleccionada = null;
            AñadirPalabraCommand = new RelayCommand(AñadirPalabra);
            EliminarPalabraCommand = new RelayCommand(EliminarPalabra);
            AñadirLista = new ListaPalabrasProhibidas();

            WeakReferenceMessenger.Default.Send(new TextoModificadoMessage(AñadirLista));
        }

        public void AñadirPalabra()
        {
            ListaPalabras.Add(PalabraEscrita);
            PalabraEscrita = "";
        }
        public void EliminarPalabra()
        {
            ListaPalabras.Remove(PalabraSeleccionada);
        }

    }
}
