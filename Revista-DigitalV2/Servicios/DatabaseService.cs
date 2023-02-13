using Microsoft.Data.Sqlite;
using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Servicios
{
    class DatabaseService
    {
        private SqliteConnection conexion;
        public DatabaseService()
        {
            conexion = new SqliteConnection("Data Source=revista.db");
            conexion.Open();
            SqliteCommand crearAutor = conexion.CreateCommand();
            crearAutor.CommandText = @"CREATE TABLE IF NOT EXISTS Autor (
                                    id integer PRIMARY KEY,
                                    nombre varchar(100),
                                    nickname varchar(100), imagen varchar(500), 
                                    red_social varchar(50))";
            crearAutor.ExecuteNonQuery();
            SqliteCommand crearArticulo = conexion.CreateCommand();
            crearArticulo.CommandText = @"CREATE TABLE IF NOT EXISTS Articulo (
                                        id integer PRIMARY KEY,
                                        autor integer, titulo varchar(100),
                                        cuerpo text, imagen varchar(500), seccion varchar(50), FOREIGN KEY(autor) REFERENCES Autor(autor))";
            crearArticulo.ExecuteNonQuery();

        }
        public void Cerrar()
        {
            conexion.Close();
        }
        public void CrearAutor(Autor autor)
        {

            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO Autor (nombre,nickname,imagen,red_social) VALUES(@nombre,@nickname,@imagen," +
                                        "@red_social)";
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@nickname", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@red_social", SqliteType.Text);

            comando.Parameters["@nombre"].Value = autor.Nombre;
            comando.Parameters["@nickname"].Value = autor.Nickname;
            comando.Parameters["@imagen"].Value = autor.Imagen;
            comando.Parameters["@red_social"].Value = autor.RedSocial;

            comando.ExecuteNonQuery();
        }
        public void CrearArticulo(Articulo articulo)
        {
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = @"INSERT INTO Articulo(autor,titulo,cuerpo,imagen,seccion) VALUES(@autor,@titulo,@cuerpo," +
                                    "@imagen,@seccion)";
            comando.Parameters.Add("@autor", SqliteType.Text);
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters.Add("@cuerpo", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@seccion", SqliteType.Text);

            comando.Parameters["@autor"].Value = articulo.Autor;
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.Parameters["@cuerpo"].Value = articulo.Cuerpo;
            comando.Parameters["@imagen"].Value = articulo.Imagen;
            comando.Parameters["@seccion"].Value = articulo.Seccion;

            comando.ExecuteNonQuery();

        }
        public ObservableCollection<Autor> MostrarAutores()
        {
            SqliteCommand comando = conexion.CreateCommand();

            ObservableCollection<Autor> listaAutores = new ObservableCollection<Autor>();
            comando.CommandText = @"SELECT * FROM Autor";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string nombre = (string)lector["nombre"];
                    string nickname = (string)lector["nickname"];
                    string imagen = (string)lector["imagen"];
                    string red_social = (string)lector["red_social"];
                    int id = lector.GetInt32(0);
                    listaAutores.Add(new Autor(id, nombre, nickname, imagen, red_social));
                }
            }
            lector.Close();
            return listaAutores;
        }
        public Autor MostrarAutorPorId(int idBuscar)
        {
            SqliteCommand comando = conexion.CreateCommand();

            Autor autor = new Autor();
            comando.CommandText = @"SELECT * FROM Autor Where id = "+ idBuscar;
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    autor.Nombre = (string)lector["nombre"];
                    autor.Nickname = (string)lector["nickname"];
                    autor.Imagen = (string)lector["imagen"];
                    autor.RedSocial = (string)lector["red_social"];
                    autor.Id = lector.GetInt32(0);
                    
                }
            }
            lector.Close();
            return autor;
        }
        public ObservableCollection<Articulo> MostrarArticulos()
        {
            SqliteCommand comando = conexion.CreateCommand();

            ObservableCollection<Articulo> listaArticulos = new ObservableCollection<Articulo>();
            comando.CommandText = @"SELECT * FROM Articulo";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int autor = (int)lector["autor"];
                    string titulo = (string)lector["titulo"];
                    string cuerpo = (string)lector["cuerpo"];
                    string imagen = (string)lector["imagen"];
                    string seccion = (string)lector["seccion"];
                    int id = lector.GetInt32(0);
                    listaArticulos.Add(new Articulo(id, autor, titulo, cuerpo, imagen, seccion));
                }
            }
            lector.Close();
            return listaArticulos;
        }
        public void EliminarAutor(Autor autor)
        {
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = @"DELETE FROM Autor WHERE id = " + autor.Id;
            comando.ExecuteNonQuery();

        }
        public void EliminarArticulo(Articulo articulo)
        {
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = @"DELETE FROM Articulo WHERE id =" + articulo.Id;
            comando.ExecuteNonQuery();
        }
        public void EditarAutor(Autor autor)
        {
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = @"UPDATE Autor SET nombre=@nombre,nickname=@nickname,imagen=@imagen,red_social=@red_social WHERE id = " + autor.Id;
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@nickname", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@red_social", SqliteType.Text);

            comando.Parameters["@nombre"].Value = autor.Nombre;
            comando.Parameters["@nickname"].Value = autor.Nickname;
            comando.Parameters["@imagen"].Value = autor.Imagen;
            comando.Parameters["@red_social"].Value = autor.RedSocial;
            comando.ExecuteNonQuery();

        }
        public void EditarArticulo(Articulo articulo)
        {
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = @"UPDATE Articulo SET autor=@autor,titulo=@titulo,cuerpo=@cuerpo,imagen=@imagen, seccion=@seccion WHERE id = " + articulo.Id;
            comando.Parameters.Add("@autor", SqliteType.Text);
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters.Add("@cuerpo", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@seccion", SqliteType.Text);

            comando.Parameters["@autor"].Value = articulo.Autor;
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.Parameters["@cuerpo"].Value = articulo.Cuerpo;
            comando.Parameters["@imagen"].Value = articulo.Imagen;
            comando.Parameters["@seccion"].Value = articulo.Seccion;
            comando.ExecuteNonQuery();

        }
    }
}
