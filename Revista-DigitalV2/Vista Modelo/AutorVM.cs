using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_DigitalV2.Modelo;
using Revista_DigitalV2.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Vista_Modelo
{
    class AutorVM : ObservableObject
    {
        private bool estaEditando;
        public RelayCommand SelectImagenCommand { get; }

        public RelayCommand GuardarAutorCommand { get; }
        public RelayCommand EditarAutorCommand { get; }
        public RelayCommand EliminarAutorCommand { get; }


        private string imagenSeleccionadaPorUsuario;
        public string ImagenSeleccionadaPorUsuario
        {
            get { return imagenSeleccionadaPorUsuario; }
            set { SetProperty(ref imagenSeleccionadaPorUsuario, value); }
        }

        private ObservableCollection<string> redes;
        public ObservableCollection<string> Redes
        {
            get { return redes; }
            set { SetProperty(ref redes, value); }
        }
        private ObservableCollection<Autor> listaAutores;
        public ObservableCollection<Autor> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }
        private Autor autorSeleccionado;

        public Autor AutorSeleccionado
        {
            get { return autorSeleccionado; }
            set { SetProperty(ref autorSeleccionado, value); }
        }
        private Autor autorAEditar;

        public Autor AutorAEditar
        {
            get { return autorAEditar; }
            set { SetProperty(ref autorAEditar, value); }
        }
        private Autor autorFormulario;

        public Autor AutorFormulario
        {
            get { return autorFormulario; }
            set { SetProperty(ref autorFormulario, value); }
        }
        private Autor autorNuevo;

        public Autor AutorNuevo
        {
            get { return autorNuevo; }
            set { SetProperty(ref autorNuevo, value); }
        }
        private DatabaseService database;
        private DialogoService dialogoService;
        private ServicioCreacionArticulo servicioArticulo;

        private GestionAzureBlobService gestionAzureBlobService; 
        public AutorVM()
        {
            estaEditando = false;
            Redes = new ObservableCollection<string>();
            Redes.Add("Instagram");
            Redes.Add("Twitter");
            Redes.Add("Facebook");

            SelectImagenCommand = new RelayCommand(SeleccionarImagenAutor);
            GuardarAutorCommand = new RelayCommand(GuardarAutor);
            EditarAutorCommand = new RelayCommand(EditarAutor);
            EliminarAutorCommand = new RelayCommand(EliminarAutor);

            database = new DatabaseService();
            dialogoService = new DialogoService();
            servicioArticulo = new ServicioCreacionArticulo();
            gestionAzureBlobService = new GestionAzureBlobService();

            ListaAutores = database.MostrarAutores();
            autorFormulario = new Autor();
            autorNuevo = new Autor();
        }

        private void EliminarAutor()
        {
            if (dialogoService.DialogoEliminar())
            {
                Autor autor = AutorSeleccionado;
                ListaAutores.Remove(autor);
                database.EliminarAutor(autor);
            }
        }

        private void EditarAutor()
        {
            AutorAEditar = new Autor(AutorSeleccionado.Id, AutorSeleccionado.Nombre, AutorSeleccionado.Nickname, AutorSeleccionado.Imagen, AutorSeleccionado.RedSocial);
            AutorFormulario = AutorAEditar;
            estaEditando = true;
        }

        public void SeleccionarImagenAutor()
        {
            ImagenSeleccionadaPorUsuario = servicioArticulo.ExaminaImagen();
        }
        public void GuardarAutor()
        {
            if(estaEditando)
            {
                database.EditarAutor(AutorAEditar);
                ListaAutores = database.MostrarAutores();
            }
            else
            {
                AutorNuevo = AutorFormulario;
                Autor autor = new Autor(AutorNuevo.Nombre, AutorNuevo.Nickname, ImagenSeleccionadaPorUsuario, AutorNuevo.RedSocial);
                database.CrearAutor(autor);
                ListaAutores = database.MostrarAutores();
            }

        }
    }
}
