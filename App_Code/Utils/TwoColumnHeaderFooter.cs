using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
public class TwoColumnHeaderFooter : PdfPageEventHelper
{
    // This is the contentbyte object of the writer
    PdfContentByte cb;
    // we will put the final number of pages in a template
    PdfTemplate template;
    // this is the BaseFont we are going to use for the header / footer
    BaseFont bf = null;
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
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }
        catch (DocumentException de)
        {
        }
        catch (System.IO.IOException ioe)
        {
        }
    }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        Rectangle pageSize = document.PageSize;
        if ("Prueba titulo" != string.Empty)
        {
           /* cb.BeginText();
            cb.SetFontAndSize(bf, 15);
            cb.SetRGBColorFill(0, 0, 0);
            cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));
            cb.ShowText("JUAN AZOFEIFA JIMENEZ\n");
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bf, 15);
            cb.SetRGBColorFill(0, 0, 0);
            cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(60));
            cb.ShowText("01/08/2014 - 31/08/2014\n");
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bf, 15);
            cb.SetRGBColorFill(0, 0, 0);
            cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(80));
            cb.ShowText("Reporte acumulado de compras");
            cb.EndText();*/
        }
    }
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        int pageN = writer.PageNumber;
        String text = "Página " + pageN + " de ";
        float len = bf.GetWidthPoint(text, 8);
        Rectangle pageSize = document.PageSize;
        cb.SetRGBColorFill(100, 100, 100);
        cb.BeginText();
        cb.SetFontAndSize(bf, 8);
        cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
        cb.ShowText(text);
        cb.EndText();
        cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));

        cb.BeginText();
        cb.SetFontAndSize(bf, 8);
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
            PrintTime.ToString(),
            pageSize.GetRight(40),
            pageSize.GetBottom(30), 0);
        cb.EndText();
    }
    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        base.OnCloseDocument(writer, document);
        template.BeginText();
        template.SetFontAndSize(bf, 8);
        template.SetTextMatrix(0, 0);
        template.ShowText("" + (writer.PageNumber - 1));
        template.EndText();
    }
}
