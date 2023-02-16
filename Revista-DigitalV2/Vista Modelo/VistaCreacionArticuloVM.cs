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

        public DatabaseService servicioDatabaseService;

        public RelayCommand AñadirArticuloCommand { get; }

        public RelayCommand ExaminarImagenCommand { get; }

        public RelayCommand VaciarArticuloCommand { get; }

        private ObservableCollection<Autor> listaAutores;

        public ObservableCollection<Autor> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }

        private string autorObjeto;

        public string AutorObjeto
        {
            get { return autorObjeto; }
            set { SetProperty(ref autorObjeto, value); }
        }


        private Articulo articuloCreado;

        public Articulo ArticuloCreado
        {
            get { return articuloCreado; }
            set { SetProperty(ref articuloCreado, value); }
        }

        

        public VistaCreacionArticuloVM()
        {
            // Servicios
            servicioDatabaseService = new DatabaseService();
            servicioArticulo = new ServicioCreacionArticulo();
            servicioGenerarPDFService = new GenerarPDFService();
            servicioPDFAzureService = new GestionAzureBlobService();

            //Cambiar por la base de datos
            ListaAutores = servicioDatabaseService.MostrarAutores();
            
            AutorObjeto = "";

            ArticuloCreado = new Articulo();
            AñadirArticuloCommand = new RelayCommand(AñadirArticulo);
            ExaminarImagenCommand = new RelayCommand(ExaminarImagen);
            VaciarArticuloCommand = new RelayCommand(VaciarArticulo);
        }

        public void AñadirArticulo()
        {
            //Aquí añadir el artículo a la base de datos
            //Acceder a la base de datos para obtener el id del autor con su nickname
            ArticuloCreado.Autor = servicioDatabaseService.MostrarAutorPorNickname(AutorObjeto).Id;
            servicioDatabaseService.CrearArticulo(ArticuloCreado);
            //La parte de publicar deberia de ir en la vista de administrar articulos
            //Autor nAutor = null;
            //nAutor = servicioDatabaseService.MostrarAutorPorId(ArticuloCreado.Autor);
            //servicioGenerarPDFService.GenerarPdf(ArticuloCreado, nAutor);
            //servicioPDFAzureService.SubirPDF(ArticuloCreado);

            //Aquí se vuelve a dejar vacío el artículo
            VaciarArticulo();

            // Borrar archivos locales
            //File.Delete("downloadedImage.png");
            //File.Delete("Articulo.pdf");
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
