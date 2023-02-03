using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
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
                                        autor varchar(100), titulo varchar(100),
                                        cuerpo text, imagen varchar(500), seccion varchar(50))";
            crearArticulo.ExecuteNonQuery();
            conexion.Close();
        }
    }
    }
