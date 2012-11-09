using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data;

namespace TicketingSystem
{
    public class Ticket
    {
        public MemoryStream CreatePDF(DataTable database, string customerName, DateTime date, string code)
        {
            Font Helvetica12B = FontFactory.GetFont(BaseFont.HELVETICA, 12, Font.BOLD);
            Font Helvetica10 = FontFactory.GetFont(BaseFont.HELVETICA, 10, Font.NORMAL);
            Font Courier12 = FontFactory.GetFont(BaseFont.COURIER, 12, Font.NORMAL);

            MemoryStream PDFData = new MemoryStream();
            Document document = new Document(PageSize.LETTER, 50, 50, 80, 60);
            PdfWriter PDFWriter = PdfWriter.GetInstance(document, PDFData);
            PDFWriter.ViewerPreferences = PdfWriter.PageModeUseOutlines;

            // Our custom Header and Footer is done using Event Handler
            HeaderFooter PageEventHandler = new HeaderFooter();
            PDFWriter.PageEvent = PageEventHandler;

            // Define the page header
            PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 8, Font.ITALIC);
            PageEventHandler.HeaderLeft = "Ticketing system";
            PageEventHandler.HeaderRight = date.ToString("MMMM dd, yyyy HH:mm:ss");

            document.Open();

            document.Add(new Paragraph("Ticketing system", Helvetica12B));
            document.Add(new Paragraph("Orderer name: " + customerName, Helvetica10));
            document.Add(new Paragraph("Orders code: " + code, Helvetica10));
            document.Add(new Paragraph("Date: " + date.ToString("MMMM dd, yyyy HH:mm:ss"), Helvetica10));
            document.Add(new Paragraph(" ", Helvetica10));

            PdfPTable Orders = new PdfPTable(5);
            Orders.TotalWidth = document.PageSize.Width - 100;
            Orders.LockedWidth = true;
            float[] widthsTAS = { 15f, 30f, 35f, 10f, 10f };
            Orders.SetWidthPercentage(widthsTAS, document.PageSize);

            Orders.AddCell(new Paragraph("Organizer", Helvetica10));
            Orders.AddCell(new Paragraph("Date", Helvetica10));
            Orders.AddCell(new Paragraph("Title", Helvetica10));
            Orders.AddCell(new Paragraph("Row", Helvetica10));
            Orders.AddCell(new Paragraph("Number", Helvetica10));

            for (int i = 0; i < database.Rows.Count; i++)
            {
                Orders.AddCell(new Paragraph(database.Rows[i][0].ToString(), Helvetica10));
                Orders.AddCell(new Paragraph(Convert.ToDateTime(database.Rows[i][1].ToString()).ToString("MMMM dd, yyyy HH:mm"), Helvetica10));
                Orders.AddCell(new Paragraph(database.Rows[i][2].ToString(), Helvetica10));
                Orders.AddCell(new Paragraph(database.Rows[i][3].ToString(), Helvetica10));
                Orders.AddCell(new Paragraph(database.Rows[i][4].ToString(), Helvetica10));
            }

            document.Add(Orders);

            document.Close();

            return PDFData;
        }   
    }
}