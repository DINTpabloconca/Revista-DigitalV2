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
		public bool DialogoEliminarArticulo()
		{
			MessageBoxResult result = MessageBox.Show("¿Seguro que quieres eliminar este articulo?", "Eliminar articulo", MessageBoxButton.YesNo);
			switch (result)
			{
				case MessageBoxResult.Yes:
					return true;

				case MessageBoxResult.No:
					return false;
			}
			return false;
		}
		public void DialogoErrorEliminacion()
		{
			MessageBoxResult result = MessageBox.Show("No se ha podido eliminar el autor porque tiene articulos asociados"
				, "Eliminar autor", MessageBoxButton.OK);
		}
	}
}
