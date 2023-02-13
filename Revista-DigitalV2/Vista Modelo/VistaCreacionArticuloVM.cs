using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_DigitalV2.Modelo;
using Revista_DigitalV2.Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Vista_Modelo
{
    class VistaCreacionArticuloVM : ObservableObject
    {
        public ServicioCreacionArticulo servicioArticulo;

        public GenerarPDFService servicioGenerarPDFService;

        public GestionAzureBlobService servicioPDFAzureService;

        public RelayCommand AñadirArticuloCommand { get; }

        public RelayCommand ExaminarImagenCommand { get; }

        public RelayCommand VaciarArticuloCommand { get; }

        private ObservableCollection<Autor> listaAutores;

        public ObservableCollection<Autor> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }



        private Articulo articuloCreado;

        public Articulo ArticuloCreado
        {
            get { return articuloCreado; }
            set { SetProperty(ref articuloCreado, value); }
        }

        

        public VistaCreacionArticuloVM()
        {
            //Cambiar por la base de datos
            ListaAutores = new ObservableCollection<Autor>();
            //Prueba (Borrar)
            ListaAutores.Add(new Autor("Pedro", "Pedri", "C:/image.jpg", "facebook"));
            ListaAutores.Add(new Autor("Juan", "Joaco", "C:/image.png", "twitter"));
            // Servicios
            servicioArticulo = new ServicioCreacionArticulo();
            servicioGenerarPDFService = new GenerarPDFService();
            servicioPDFAzureService = new GestionAzureBlobService();


            ArticuloCreado = new Articulo();
            AñadirArticuloCommand = new RelayCommand(AñadirArticulo);
            ExaminarImagenCommand = new RelayCommand(ExaminarImagen);
            VaciarArticuloCommand = new RelayCommand(VaciarArticulo);
        }

        public void AñadirArticulo()
        {
            //Aquí añadir el artículo a la base de datos
            servicioGenerarPDFService.GenerarPdf(ArticuloCreado);
            servicioPDFAzureService.SubirPDF(ArticuloCreado);

            //Aquí se vuelve a dejar vacío el artículo
            VaciarArticulo();

            // Borrar archivos locales
            File.Delete("downloadedImage.png");
            File.Delete("Articulo.pdf");
        }

        public void VaciarArticulo()
        {
            ArticuloCreado = new Articulo();
        }
        public void ExaminarImagen()
        {
            ArticuloCreado.Imagen = servicioArticulo.ExaminaImagen();

        }
    }
}
