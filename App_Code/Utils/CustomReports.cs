using System;
using System.Linq;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web;
using System.Web.UI;
public class CustomReports
{
    public void CreatePDF(String NombreContribuyente, String FechaInicio, String FechaFinal, String TipoInforme, DataTable dataTable, int tipoReporte)
    {
        Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
        System.IO.FileStream file =
            new System.IO.FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/PDFs/Reporte") + ".pdf",
            System.IO.FileMode.OpenOrCreate);
        PdfWriter writer = PdfWriter.GetInstance(doc, file);
        // calling PDFFooter class to Include in document
        writer.PageEvent = new TwoColumnHeaderFooter();
        doc.Open();

        String header = String.Format("Sistema de Contabilidad Madrigal y Madrigal\n{0}\n{1} - {2}\n{3}",NombreContribuyente,FechaInicio, FechaFinal, TipoInforme);
        String nombre = "";
        if (tipoReporte == 4)
        {
            nombre = "NombreCliente";
        }
        else if(tipoReporte==5) {
            nombre = "NombreProveedor";
        }

        var grouped = from table in dataTable.AsEnumerable()
                      group table by new { nombreCliente = table[nombre], cedulaCliente = table["Cedula"] } into groupby
                      select new
                      {
                          Value = groupby.Key,
                          ColumnValues = groupby
                      };
        
        PdfPTable tab = new PdfPTable(2);
        tab.HorizontalAlignment = 0;
        tab.TotalWidth = 750f;
        tab.LockedWidth = true;
        
        PdfPCell cell = new PdfPCell(new Phrase(header,
                            new Font(Font.FontFamily.HELVETICA, 14F,Font.BOLDITALIC)));
        cell.Colspan = 2;
        cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
        //Style
        cell.Border = Rectangle.NO_BORDER;
        tab.AddCell(cell);

        cell = new PdfPCell();
        cell.Colspan = 2;
        cell.Border = Rectangle.NO_BORDER;

        PdfPTable currentCliente = new PdfPTable(10);

        double[] arrayTotales = new double[8];

        foreach (var key in grouped)
        {
            double [] arraySubtotales = new double[8];

            PdfPCell cellAuxiliar = new PdfPCell(new Phrase(String.Format("{0} - {1}", key.Value.nombreCliente.ToString(), key.Value.cedulaCliente.ToString()),
                    new Font(Font.FontFamily.HELVETICA, 12F, Font.BOLD)));
            cellAuxiliar.Colspan = 10;
            cellAuxiliar.Border = Rectangle.NO_BORDER;
            currentCliente.AddCell(cellAuxiliar);
            PdfPCell[] titles = new PdfPCell[] { new PdfPCell(GetCellBold("# factura")),
                                    new PdfPCell(GetCellBold("Fecha")),
                                    new PdfPCell(GetCellBold("Exento")),
                                    new PdfPCell(GetCellBold("Descuento")),
                                    new PdfPCell(GetCellBold("Subtotal")),
                                    new PdfPCell(GetCellBold("Gravado")),
                                    new PdfPCell(GetCellBold("Descuento")),
                                    new PdfPCell(GetCellBold("I.V")),
                                    new PdfPCell(GetCellBold("Subtotal")),
                                    //new PdfPCell(GetCellBold("Flete")),
                                    new PdfPCell(GetCellBold("Total"))                
                };
            PdfPRow rowTitles = new PdfPRow(titles);
            currentCliente.Rows.Add(rowTitles);

            foreach (var columnValue in key.ColumnValues)
            {
                CultureInfo culture = new CultureInfo("en-US");
                //String a = columnValue["MontoExento"].ToString();
                arraySubtotales[0] += Convert.ToDouble(columnValue["MontoExento"].ToString(), culture);
                arraySubtotales[1] += Convert.ToDouble(columnValue["DescuentoExento"].ToString(), culture);
                arraySubtotales[2] += Convert.ToDouble(columnValue["SubtotalExento"].ToString(), culture);
                arraySubtotales[3] += Convert.ToDouble(columnValue["MontoGravado"].ToString(), culture);
                arraySubtotales[4] += Convert.ToDouble(columnValue["DescuentoGravado"].ToString(), culture);
                arraySubtotales[5] += Convert.ToDouble(columnValue["ImpuestoVenta"].ToString(), culture);
                arraySubtotales[6] += Convert.ToDouble(columnValue["SubtotalGravado"].ToString(), culture);
                arraySubtotales[7] += Convert.ToDouble(columnValue["TotalFactura"].ToString(), culture);
                PdfPCell[] cells = new PdfPCell[] { new PdfPCell(GetCell(columnValue["NumeroFactura"].ToString())),
                                    new PdfPCell(GetCell(columnValue["Fecha"].ToString().Substring(0, 10))),
                                    new PdfPCell(GetCell(columnValue["MontoExento"].ToString())),
                                    new PdfPCell(GetCell(columnValue["DescuentoExento"].ToString())),
                                    new PdfPCell(GetCell(columnValue["SubtotalExento"].ToString())),
                                    new PdfPCell(GetCell(columnValue["MontoGravado"].ToString())),
                                    new PdfPCell(GetCell(columnValue["DescuentoGravado"].ToString())),
                                    new PdfPCell(GetCell(columnValue["ImpuestoVenta"].ToString())),
                                    new PdfPCell(GetCell(columnValue["SubtotalGravado"].ToString())),
                                    //new PdfPCell(GetCell(columnValue["Flete"].ToString())),
                                    new PdfPCell(GetCell(columnValue["TotalFactura"].ToString()))
                
                };
                PdfPRow row = new PdfPRow(cells);
                currentCliente.Rows.Add(row);
            }

                arrayTotales[0] += arraySubtotales[0];
                arrayTotales[1] += arraySubtotales[1];
                arrayTotales[2] += arraySubtotales[2];
                arrayTotales[3] += arraySubtotales[3];
                arrayTotales[4] += arraySubtotales[4];
                arrayTotales[5] += arraySubtotales[5];
                arrayTotales[6] += arraySubtotales[6];
                arrayTotales[7] += arraySubtotales[7];

                PdfPCell[] cellsSubtotales = new PdfPCell[] { 
                    new PdfPCell(GetCellBold("")),
                    new PdfPCell(GetCellBold("")),
                    new PdfPCell(GetCellBold(arraySubtotales[0].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[1].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[2].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[3].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[4].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[5].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[6].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arraySubtotales[7].ToString("0,0.00", new CultureInfo("en-US"))))
                
                };

            PdfPRow rowSubtotales = new PdfPRow(cellsSubtotales);
            currentCliente.Rows.Add(rowSubtotales);
        }

        PdfPCell[] cellsTotales = new PdfPCell[] { 
                    new PdfPCell(GetCellBold("")),
                    new PdfPCell(GetCellBold("")),
                    new PdfPCell(GetCellBold(arrayTotales[0].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[1].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[2].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[3].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[4].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[5].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[6].ToString("0,0.00", new CultureInfo("en-US")))),
                    new PdfPCell(GetCellBold(arrayTotales[7].ToString("0,0.00", new CultureInfo("en-US"))))
                
                };

        PdfPRow rowTotales = new PdfPRow(cellsTotales);
        
        currentCliente.Rows.Add(rowTotales);

        currentCliente.WidthPercentage = 100f;
       
        cell.AddElement(currentCliente);
        cell.HorizontalAlignment = 0;
        tab.AddCell(cell);

        tab.HeaderRows = 1;
        doc.Add(tab);
        doc.Close();
        file.Close();
        
        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.AppendHeader("Content-Disposition", "attachment; filename=buylist.pdf");
        //Response.TransmitFile(System.Web.Hosting.HostingEnvironment.MapPath("~/PDFs/Reporte.pdf"));
    }

    public PdfPCell GetCell(String text) {
        PdfPCell cellAuxiliar = new PdfPCell(new Phrase(text,
                new Font(Font.FontFamily.HELVETICA, 12F)));
        cellAuxiliar.Border = Rectangle.NO_BORDER;
        return cellAuxiliar;
    }

    public PdfPCell GetCellBold(String text)
    {
        PdfPCell cellAuxiliar = new PdfPCell(new Phrase(text,
                new Font(Font.FontFamily.HELVETICA, 12F,Font.BOLD)));
        cellAuxiliar.Border = Rectangle.NO_BORDER;
        return cellAuxiliar;
    }

}