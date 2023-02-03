using Azure.Storage.Blobs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Revista_DigitalV2.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Revista_DigitalV2.Servicios
{
    class GenerarPDFService
    {
        public void GenerarPdf(Articulo articuloModel)
        {
            WebClient mywebClient = new WebClient();
            mywebClient.DownloadFile(articuloModel.Imagen, "downloadedImage.png");

            byte[] imageData = File.ReadAllBytes("downloadedImage.png");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text(articuloModel.Titulo)
                        .SemiBold().FontSize(36).FontColor(Colors.LightGreen.Medium);

                    page.Content()
                        .PaddingVertical(1, QuestPDF.Infrastructure.Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Item().Text(articuloModel.Seccion).FontSize(25).SemiBold();
                            x.Spacing(20);
                            x.Item().Image(imageData);
                            x.Spacing(5);
                            x.Item().Text(articuloModel.Cuerpo);
                            
                        });

                    page.Footer()
                        .AlignLeft()
                        .Text(x =>
                        {
                            x.Span("Autor: ");
                            x.Span(articuloModel.Autor);
                        });
                    page.Footer()
                        .AlignRight()
                        .Column(x =>
                        {
                            x.Item().Image(articuloModel.Autor/*.redSocial*/);
                            x.Item().Text(articuloModel.Autor/*.NickName*/);
                        });
                });
            })
            .GeneratePdf(articuloModel.Titulo+".pdf");
        }        
    }
}
