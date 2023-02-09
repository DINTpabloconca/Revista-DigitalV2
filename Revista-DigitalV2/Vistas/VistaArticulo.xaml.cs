using Revista_DigitalV2.Vista_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Revista_DigitalV2.Vistas
{
    /// <summary>
    /// Lógica de interacción para VistaArticulo.xaml
    /// </summary>
    public partial class VistaArticulo : Window
    {
        VistaArticuloVM vm;
        public VistaArticulo()
        {
            vm = new VistaArticuloVM();
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
