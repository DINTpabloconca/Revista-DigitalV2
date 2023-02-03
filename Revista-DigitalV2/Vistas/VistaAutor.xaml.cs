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
    /// Lógica de interacción para VistaAutor.xaml
    /// </summary>
    public partial class VistaAutor : Window
    {
        AutorVM vm;
        public VistaAutor()
        {
            InitializeComponent();
            vm = new AutorVM();
            this.DataContext = vm;
        }
    }
}
