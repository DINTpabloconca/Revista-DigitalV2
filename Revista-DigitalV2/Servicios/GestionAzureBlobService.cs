using Azure.Storage.Blobs;
using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_DigitalV2.Servicios
{
    class GestionAzureBlobService
    {
        string cadenaConexion = Properties.Settings.Default.cadena_conexion_azureblob;

        public string SubirPDF(Articulo articulo)
        {
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient("articulospdf");
            clienteContenedor.CreateIfNotExists();

            Stream streamPdf = File.OpenRead(articulo.Titulo + ".pdf");
            string nombrePdf = Path.GetFileName(articulo.Titulo + ".pdf");
            clienteContenedor.UploadBlob(nombrePdf, streamPdf);

            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombrePdf);
            string urlPdf = clienteBlobImagen.Uri.AbsoluteUri;
            
            return urlPdf;
        }

        public string GuardarImagenAutor(string rutaImagen)
        {
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient("imagenesautores");
            clienteContenedor.CreateIfNotExists();

            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;

            return urlImagen;
        }

        public string GuardarImagenArticulo(string rutaImagen)
        {
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient("imagenesarticulos");
            clienteContenedor.CreateIfNotExists();

            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;

            return urlImagen;
        }
    }
}
