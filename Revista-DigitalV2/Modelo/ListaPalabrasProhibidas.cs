using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Modelo
{
    class ListaPalabrasProhibidas : ObservableObject
    {
        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        private ObservableCollection<string> lista;

        public ObservableCollection<string> Lista
        {
            get { return lista; }
            set { SetProperty(ref lista, value) ; }
        }


        public ListaPalabrasProhibidas()
        {
            Titulo = "";
            Lista = new ObservableCollection<string>();
        }

        public ListaPalabrasProhibidas(ListaPalabrasProhibidas value)
        {
            Titulo = value.Titulo;
            Lista = value.Lista;
        }


    }
}
