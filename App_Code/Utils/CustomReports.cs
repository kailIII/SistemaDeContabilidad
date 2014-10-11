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
    public String CreatePDF(String NombreContribuyente, String FechaInicio, String FechaFinal, String TipoInforme, DataTable dataTable, int tipoReporte)
    {
        DateTime dt = DateTime.Now;
        Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
        String namePDF = "Reporte" + String.Format("{0}{1}{2}", dt.Minute,dt.Second,dt.Millisecond) + ".pdf";
        System.IO.FileStream file =
            new System.IO.FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/PDFs/") + namePDF,
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

        float[] arrayTotales = new float[8];

        foreach (var key in grouped)
        {
            float [] arraySubtotales = new float[8];

            PdfPCell cellAuxiliar = new PdfPCell(new Phrase(String.Format("{0} - {1}", key.Value.nombreCliente.ToString(), key.Value.cedulaCliente.ToString()),
                    new Font(Font.FontFamily.HELVETICA, 10F, Font.BOLD)));
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
                                    new PdfPCell(GetCellBold("Total"))                
                };
            PdfPRow rowTitles = new PdfPRow(titles);
            currentCliente.Rows.Add(rowTitles);

            foreach (var columnValue in key.ColumnValues)
            {
                CultureInfo culture = new CultureInfo("en-US");

                float montoExento = float.Parse(replaceDotComa(columnValue["MontoExento"].ToString()), culture.NumberFormat);
                float descuentoExento = float.Parse(replaceDotComa(columnValue["DescuentoExento"].ToString()), culture.NumberFormat);
                float subtotalExento = float.Parse(replaceDotComa(columnValue["SubtotalExento"].ToString()), culture.NumberFormat);
                float montoGravado = float.Parse(replaceDotComa(columnValue["MontoGravado"].ToString()), culture.NumberFormat);
                float descuentoGravado = float.Parse(replaceDotComa(columnValue["DescuentoGravado"].ToString()), culture.NumberFormat);
                float impuestoVenta = float.Parse(replaceDotComa(columnValue["ImpuestoVenta"].ToString()), culture.NumberFormat);
                float subtotalGravado = float.Parse(replaceDotComa(columnValue["SubtotalGravado"].ToString()), culture.NumberFormat);
                float totalFactura = float.Parse(replaceDotComa(columnValue["TotalFactura"].ToString()), culture.NumberFormat);

                arraySubtotales[0] += montoExento;
                arraySubtotales[1] += descuentoExento;
                arraySubtotales[2] += subtotalExento;
                arraySubtotales[3] += montoGravado;
                arraySubtotales[4] += descuentoGravado;
                arraySubtotales[5] += impuestoVenta;
                arraySubtotales[6] += subtotalGravado;
                arraySubtotales[7] += totalFactura;
                PdfPCell[] cells = new PdfPCell[] { new PdfPCell(GetCell(columnValue["NumeroFactura"].ToString())),
                                    new PdfPCell(GetCell(columnValue["Fecha"].ToString().Substring(0, 10))),
                                    new PdfPCell(GetCell(montoExento.ToString("0,0.00", new CultureInfo("en-US")))),
                                    new PdfPCell(GetCell(descuentoExento.ToString("0,0.00", new CultureInfo("en-US")))),
                                    new PdfPCell(GetCell(subtotalExento.ToString("0,0.00", new CultureInfo("en-US")))),
                                    new PdfPCell(GetCell(montoGravado.ToString("0,0.00", new CultureInfo("en-US")))),
                                    new PdfPCell(GetCell(descuentoGravado.ToString("0,0.00", new CultureInfo("en-US")))),
                                    new PdfPCell(GetCell(impuestoVenta.ToString("0,0.00", new CultureInfo("en-US")))),
                                    new PdfPCell(GetCell(subtotalGravado.ToString("0,0.00", new CultureInfo("en-US")))),
                                    //new PdfPCell(GetCell(columnValue["Flete"].ToString())),
                                    new PdfPCell(GetCell(totalFactura.ToString("0,0.00", new CultureInfo("en-US"))))
                
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

        return namePDF;
        
    }

    public PdfPCell GetCell(String text) {
        PdfPCell cellAuxiliar = new PdfPCell(new Phrase(text,
                new Font(Font.FontFamily.HELVETICA, 11F)));
        cellAuxiliar.Border = Rectangle.NO_BORDER;
        cellAuxiliar.HorizontalAlignment = Element.ALIGN_RIGHT;
        return cellAuxiliar;
    }

    public PdfPCell GetCellBold(String text)
    {
        PdfPCell cellAuxiliar = new PdfPCell(new Phrase(text,
                new Font(Font.FontFamily.HELVETICA, 11F,Font.BOLD)));
        cellAuxiliar.Border = Rectangle.NO_BORDER;
        cellAuxiliar.HorizontalAlignment = Element.ALIGN_RIGHT;
        return cellAuxiliar;
    }

    public String replaceDotComa(String monto)
    {
        String resultado = "";
        resultado = monto.Replace(",", ".");
        return resultado;
    }

}