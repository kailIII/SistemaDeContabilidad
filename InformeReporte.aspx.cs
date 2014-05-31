using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Data.Odbc;
using DataSetReportesTableAdapters;
using System.Globalization;

public partial class InformeReporte : System.Web.UI.Page
{
    private ControladoraFacturaVenta controladoraFV = new ControladoraFacturaVenta();
    reporteAcumuladoVentasTableAdapter adapterReportesAcumuladoVentas = new reporteAcumuladoVentasTableAdapter();
    reporteAcumuladoComprasTableAdapter adapterReportesAcumuladoCompras = new reporteAcumuladoComprasTableAdapter();
    totalesAcumuladoComprasTableAdapter adapterTotalesComprasAcumuladas = new totalesAcumuladoComprasTableAdapter();
    totalesAcumuladoVentasTableAdapter adapterTotalesVentasAcumuladas = new totalesAcumuladoVentasTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            fillReport(Convert.ToInt32(Session["TipoReporte"].ToString()));
        }
    }

    public void fillReport(int reportType){
        this.ReportViewer1.Reset();

        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("SistemaDeContabilidadReportes.rdlc");

        ReportParameter[] parms = new ReportParameter[12];
        parms[0] = new ReportParameter("NombreContribuyente", Session["NombreContribuyente"].ToString());
        parms[1] = new ReportParameter("FechaDesde", Session["FechaDesde"].ToString());
        parms[2] = new ReportParameter("FechaHasta", Session["FechaHasta"].ToString());

        DateTime fechaDesde = DateTime.ParseExact(Session["FechaDesde"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fechaHasta = DateTime.ParseExact(Session["FechaHasta"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        DataTable result = new DataTable();
        DataTable resultadosGenerales = new DataTable();

        //depends on the report type

        if(reportType==0){
            result = adapterReportesAcumuladoCompras.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            resultadosGenerales = adapterTotalesComprasAcumuladas.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            parms[3] = new ReportParameter("TipoReporte", "Reporte Acumulado de Compras");
        }
        else if(reportType==1){
            result = adapterReportesAcumuladoVentas.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            resultadosGenerales = adapterTotalesVentasAcumuladas.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            parms[3] = new ReportParameter("TipoReporte", "Reporte Acumulado de Ventas");
        }

        foreach(DataRow r in resultadosGenerales.Rows){
            parms[4] = new ReportParameter("SubExento", r[0].ToString());
            parms[5] = new ReportParameter("DescExento", r[1].ToString());
            parms[6] = new ReportParameter("ExentoGeneral", r[2].ToString());
            parms[7] = new ReportParameter("SubGravado", r[3].ToString());
            parms[8] = new ReportParameter("DescGravado", r[4].ToString());
            parms[9] = new ReportParameter("ImpuestoGeneral", r[5].ToString());
            parms[10] = new ReportParameter("GravadoGeneral", r[6].ToString());
            parms[11] = new ReportParameter("TotalGeneral", r[7].ToString());
        }

        this.ReportViewer1.LocalReport.SetParameters(parms);
        

        ReportDataSource rds = new ReportDataSource("DataSet1", result);
        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(rds);
        this.ReportViewer1.DataBind();
        this.ReportViewer1.LocalReport.Refresh();    
    }

}