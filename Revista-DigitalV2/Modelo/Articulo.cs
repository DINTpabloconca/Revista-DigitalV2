using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Modelo
{
    class Articulo : ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private int autor;

        public int Autor
        {
            get { return autor; }
            set { SetProperty(ref autor, value); }
        }

        private string seccion;

        public string Seccion
        {
            get { return seccion; }
            set { SetProperty(ref seccion, value); }
        }


        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        private string cuerpo;

        public string Cuerpo
        {
            get { return cuerpo; }
            set { SetProperty(ref cuerpo, value); }
        }

        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }

        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { SetProperty(ref nickname, value); }
        }

        private string url;

        public string URL
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }


        public Articulo(int idAutor, string titulo, string cuerpo, string imagen, string seccion)
        {
            Autor = idAutor;
            Titulo = titulo;
            Cuerpo = cuerpo;
            Imagen = imagen;
            Seccion = seccion;
            /* Nickname desde la base de datos con el idAutor*/
            Nickname = null;

        }
        public Articulo(int id,int idAutor, string titulo, string cuerpo, string imagen, string seccion)
        {
            Id = id;
            Autor = idAutor;
            Titulo = titulo;
            Cuerpo = cuerpo;
            Imagen = imagen;
            Seccion = seccion;
            /* Nickname desde la base de datos con el idAutor*/
            Nickname = null;
        }


        public Articulo()
        {
            URL = String.Empty;
        }

    }
}
