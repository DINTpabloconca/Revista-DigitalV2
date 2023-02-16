using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Mensajes
{
    class ListaModificadaMessage : ValueChangedMessage<ObservableCollection<ListaPalabrasProhibidas>>
    {
        public ListaModificadaMessage(ObservableCollection<ListaPalabrasProhibidas> lista) : base(lista) { }
    }
}
