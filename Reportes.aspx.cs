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

    }
    protected void generateReport_Click(object sender, EventArgs e)
    {
        Session["FechaDesde"] = this.txtDesde.Text;
        Session["FechaHasta"] = this.txtHasta.Text;
        Session["TipoReporte"] = this.drpReportType.SelectedValue.ToString();
        Response.Redirect("~/InformeReporte.aspx");
    }
}