using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using DataSetReportesTableAdapters;

public partial class _Reportes : System.Web.UI.Page
{
    reporteDetalladoVentasTableAdapter adapterReporteDetalladoVentas = new reporteDetalladoVentasTableAdapter();
    reporteDetalladoComprasTableAdapter adapterReporteDetalladoCompras = new reporteDetalladoComprasTableAdapter();
    //private CommonServices utils;
    protected void Page_Load(object sender, EventArgs e)
    {
        //utils = new CommonServices(UpdateSelectCliente);
        Session["TipoReporte"] = "";
        if (!Session["CedulaContribuyente"].ToString().Equals(""))
        {
            this.lblNameContribuyente.Text = "Nombre del contribuyente: " + Session["NombreContribuyente"].ToString();
            if (!Page.IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                fillDrpType();
            }
        }
        else
        {
            Session["CedulaContribuyente"] = "";
            Response.Redirect("~/Contribuyentes.aspx");
        }
    }

    protected void fillDrpType()
    {
        this.drpReportType.Items.Clear();
        ListItem newItem = new ListItem();
        newItem.Text = "Informe Acumulado de Compras";
        newItem.Value = "0";
        drpReportType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Informe Acumulado de Ventas";
        newItem.Value = "1";
        drpReportType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Informe Acumulado de Compras Sin Impuesto";
        newItem.Value = "2";
        drpReportType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Informe Acumulado de Ventas Sin Impuesto";
        newItem.Value = "3";
        drpReportType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Informe Detallado de Ventas";
        newItem.Value = "4";
        drpReportType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Informe Detallado de Compras";
        newItem.Value = "5";
        drpReportType.Items.Add(newItem);
        /*newItem = new ListItem();
        newItem.Text = "Informe Detallado de Ventas para un cliente";
        newItem.Value = "6";
        drpReportType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Informe Detallado de Compras para un proveedor";
        newItem.Value = "7";
        drpReportType.Items.Add(newItem);*/
        this.lblMonto.Visible = false;
        this.txtMonto.Visible = false;
        this.txtMonto.Text = "0";

    }
    protected void generateReport_Click(object sender, EventArgs e)
    {
        int selected = Convert.ToInt32(this.drpReportType.SelectedValue.ToString());
        if (selected == 4 || selected == 5)
        {
            fillDetailReport(this.drpReportType.SelectedValue);
        }
        /*else if(selected==6){
            utils.abrirPopUp("popUpSelectCliente", "Seleccionar cliente");
        }
        else if(selected==7){
            utils.abrirPopUp("popUpSelectProveedor", "Seleccionar proveedor");
        }*/
        else {
            Session["FechaDesde"] = this.txtDesde.Text;
            Session["FechaHasta"] = this.txtHasta.Text;
            Session["TipoReporte"] = this.drpReportType.SelectedValue.ToString();
            Session["MontoCorte"] = this.txtMonto.Text;
            Response.Redirect("~/InformeReporte.aspx");
        }
    }
    protected void drpReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpReportType.SelectedIndex == 2 || this.drpReportType.SelectedIndex == 3)
        {
            this.lblMonto.Visible = true;
            this.txtMonto.Visible = true;
        }
        else {
            this.lblMonto.Visible = false;
            this.txtMonto.Visible = false;
            this.txtMonto.Text = "0";
        }
    }

    public void fillDetailReport(String type)
    {
        DateTime fechaDesde = DateTime.ParseExact(this.txtDesde.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime fechaHasta = DateTime.ParseExact(this.txtHasta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DataTable dt = new DataTable();
        CustomReports custom = new CustomReports();
        String pdfName = "";
        if(this.drpReportType.SelectedValue.Equals("4")){
            dt = adapterReporteDetalladoVentas.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            pdfName = custom.CreatePDF(Session["NombreContribuyente"].ToString(), this.txtDesde.Text, this.txtHasta.Text, "Informe detallado ventas", dt, 4);
        }
        else if (this.drpReportType.SelectedValue.Equals("5"))
        {
            dt = adapterReporteDetalladoCompras.GetData(fechaDesde, fechaHasta, Session["CedulaContribuyente"].ToString());
            pdfName = custom.CreatePDF(Session["NombreContribuyente"].ToString(), this.txtDesde.Text, this.txtHasta.Text, "Informe detallado compras", dt, 5);
        }
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
        Response.TransmitFile(System.Web.Hosting.HostingEnvironment.MapPath("~/PDFs/"+pdfName));
    }
    /*protected void btnAceptarCliente_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpSelectCliente");
    }
    protected void btnAceptarProveedor_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpSelectProveedor");
    }*/
}