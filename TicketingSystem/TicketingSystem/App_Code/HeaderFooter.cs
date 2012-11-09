using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf; 

namespace TicketingSystem
{
    public class HeaderFooter : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate template;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;
        BaseFont gf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        #region Properties
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _HeaderLeft;
        public string HeaderLeft
        {
            get { return _HeaderLeft; }
            set { _HeaderLeft = value; }
        }

        private string _HeaderRight;
        public string HeaderRight
        {
            get { return _HeaderRight; }
            set { _HeaderRight = value; }
        }

        private Font _HeaderFont;
        public Font HeaderFont
        {
            get { return _HeaderFont; }
            set { _HeaderFont = value; }
        }

        private Font _FooterFont;
        public Font FooterFont
        {
            get { return _FooterFont; }
            set { _FooterFont = value; }
        }
        #endregion

        // we override the onOpenDocument method
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                gf = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException)
            {
            }
            catch (System.IO.IOException)
            {
            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            Rectangle pageSize = document.PageSize;

            if (HeaderLeft + HeaderRight != string.Empty)
            {
                cb.BeginText();
                cb.SetFontAndSize(gf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(50), pageSize.GetTop(50));
                cb.ShowText(HeaderLeft);
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(gf, 8);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, HeaderRight, pageSize.GetRight(50), pageSize.GetTop(50), 0);
                cb.EndText();

                cb.SetRGBColorFill(0, 0, 0);
                cb.MoveTo(50, pageSize.Top - 54);
                cb.LineTo(pageSize.Right - 50, pageSize.Top - 54);
                cb.SetLineWidth(0.75f);
                cb.Fill();
                cb.Stroke();

            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            Rectangle pageSize = document.PageSize;

            int pageN = writer.PageNumber;
            String text = "Page " + pageN + "/";
            float len = bf.GetWidthPoint(text, 8);

            cb.SetRGBColorFill(0, 0, 0);

            // Line separated fotter from rest of sheet
            cb.MoveTo(50, pageSize.Bottom + 60);
            cb.LineTo(pageSize.Right - 50, pageSize.Bottom + 60);
            cb.SetLineWidth(0.75f);
            cb.Fill();
            cb.Stroke();

            cb.BeginText();
            cb.SetFontAndSize(gf, 8);
            cb.SetTextMatrix(pageSize.GetLeft(((pageSize.Width - 80) / 2) + len), pageSize.GetBottom(50));
            cb.ShowText(text);
            cb.EndText();

            cb.AddTemplate(template, pageSize.GetLeft(((pageSize.Width - 80) / 2) + len + len - 2), pageSize.GetBottom(50));

            cb.BeginText();
            cb.SetFontAndSize(gf, 8);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "generated on Ticketing System", pageSize.GetRight(50), pageSize.GetBottom(50), 0);
            cb.EndText();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            template.BeginText();
            template.SetFontAndSize(gf, 8);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
}