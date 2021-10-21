
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using System.Linq;

namespace ConversorDeArquivo
{
    public class ConversorPDF
    {
        public static void GerarPDF(FileStream txt)
        {
            var nomeTXTCompleto = txt.Name.Split('\\').ToList().Last();
            var nomeTXT = nomeTXTCompleto.Split('.').ToList().First() + ".pdf";

            var writer = new PdfWriter(JsonConfig.Out_PDF + $"\\{nomeTXT}");
            var pdfDocument = new PdfDocument(writer);
            var pdf = new Document(pdfDocument);

            #region Estilos
            PdfFont fontCorpo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            Style helvetica24r = new();
            helvetica24r.SetFont(fontCorpo).SetFontSize(24);
            #endregion

            #region Parágrafos
            Paragraph body = new Paragraph().SetTextAlignment(TextAlignment.LEFT).AddStyle(helvetica24r);
            #endregion

            pdf.Add(body);

            pdf.Close();
        }
    }
}
