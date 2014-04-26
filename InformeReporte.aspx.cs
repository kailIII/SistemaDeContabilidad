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

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            fillReport(Convert.ToInt32(Session["TipoReporte"].ToString()));
        }
    }

    public void fillReport(int reportType){
        this.ReportViewer1.Reset();

        this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("SistemaDeContabilidadReportes.rdlc");

        ReportParameter[] parms = new ReportParameter[4];
        parms[0] = new ReportParameter("NombreContribuyente", Session["NombreContribuyente"].ToString());
        parms[1] = new ReportParameter("FechaDesde", Session["FechaDesde"].ToString());
        parms[2] = new ReportParameter("FechaHasta", Session["FechaHasta"].ToString());

        DateTime fechaDesde = DateTime.ParseExact(Session["FechaDesde"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fechaHasta = DateTime.ParseExact(Session["FechaHasta"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        DataTable result = new DataTable();

        //depends on the report type

        if(reportType==0){
            result = adapterReportesAcumuladoCompras.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            parms[3] = new ReportParameter("TipoReporte", "Reporte Acumulado de Compras");
        }
        else if(reportType==1){
            result = adapterReportesAcumuladoVentas.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            parms[3] = new ReportParameter("TipoReporte", "Reporte Acumulado de Ventas");
        }

        this.ReportViewer1.LocalReport.SetParameters(parms);
        

        ReportDataSource rds = new ReportDataSource("DataSet1", result);
        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(rds);
        this.ReportViewer1.DataBind();
        this.ReportViewer1.LocalReport.Refresh();    
    }

}