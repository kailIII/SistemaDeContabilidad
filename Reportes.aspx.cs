using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Reportes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        this.lblMonto.Visible = false;
        this.txtMonto.Visible = false;
        this.txtMonto.Text = "0";

    }
    protected void generateReport_Click(object sender, EventArgs e)
    {
        Session["FechaDesde"] = this.txtDesde.Text;
        Session["FechaHasta"] = this.txtHasta.Text;
        Session["TipoReporte"] = this.drpReportType.SelectedValue.ToString();
        Session["MontoCorte"] = this.txtMonto.Text;
        Response.Redirect("~/InformeReporte.aspx");
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
}