using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Revista_DigitalV2
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("OTE4NTAxQDMyMzAyZTM0MmUzMEZPU0Q5VEtWQzB3WXlDZGFvNVM2dEw0cFNPVlVpUTgyWVFMdkFQNzAwckk9");

        }
    }
}
