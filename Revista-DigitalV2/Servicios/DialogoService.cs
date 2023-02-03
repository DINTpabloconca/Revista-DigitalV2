using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Revista_DigitalV2.Servicios
{
    class DialogoService
    {
        public bool DialogoEliminar()
        {
			MessageBoxResult result = MessageBox.Show("¿Seguro que quieres eliminar este autor?", "Eliminar autor", MessageBoxButton.YesNo);
			switch (result)
			{
				case MessageBoxResult.Yes:
					return true;
					
				case MessageBoxResult.No:
					return false;
			}
			return false;
        }
    }
}
