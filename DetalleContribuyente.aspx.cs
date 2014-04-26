using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _DetalleContribuyente : System.Web.UI.Page
{
    private ControladoraContribuyentes contribuController = new ControladoraContribuyentes();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["NombreContribuyente"] = "";
        if (!Session["CedulaContribuyente"].ToString().Equals(""))
        {
            if (!Page.IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                clearFields();
                fillFields(Session["CedulaContribuyente"].ToString());
            }
        }
        else {
            Session["CedulaContribuyente"] = "";
            Response.Redirect("~/Contribuyentes.aspx");
        }
    }

    private void clearFields() {
        this.txtNameContribuyente.Text = "";
        this.txtCedulaContribuyente.Text = "";
        this.txtNameRepresentante.Text = "";
        this.txtAddress.Text = "";
        this.txtTipoContribuyente.Text = "";
        this.txtLastPeriod.Text = "";

    }

    private String formatAddress(String provincia, String canton, String distrito, String address) {
        String resultado = "";
        resultado = provincia + ", " + canton + ", " + distrito + ", " + address + ".";
        return resultado;
    }

    private void fillFields(String cedulaContribuyente) {
        Contribuyente contribuyente = contribuController.consultarContribuyente(cedulaContribuyente);
        this.txtNameContribuyente.Text = contribuyente.NombreContribuyente;
        this.txtCedulaContribuyente.Text = contribuyente.CedulaContribuyente;
        this.txtNameRepresentante.Text = contribuyente.NombreRepresentante;
        this.txtAddress.Text = formatAddress(contribuyente.Provincia, contribuyente.Canton, contribuyente.Distrito, contribuyente.Direccion);
        this.txtTipoContribuyente.Text = returnType(contribuyente.Tipo);
        this.txtLastPeriod.Text = contribuyente.UltimoPeriodo;
    }

    private String returnType(int type) {
        String resultado = "";
        if(type==0){
            resultado = "Contribuyente Físico";
        }
        else if(type==1){
            resultado = "Contribuyente Jurídico";
        }
        return resultado;
    }

    protected void facVentasClicked_Click(object sender, EventArgs e)
    {
        Session["NombreContribuyente"] = this.txtNameContribuyente.Text.ToString();
        Response.Redirect("~/FacturaciónVentas.aspx");
    }
    protected void facComprasClicked_Click(object sender, EventArgs e)
    {
        Session["NombreContribuyente"] = this.txtNameContribuyente.Text.ToString();
        Response.Redirect("~/FacturaciónCompras.aspx");
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["NombreContribuyente"] = this.txtNameContribuyente.Text.ToString();
        Response.Redirect("~/Reportes.aspx");
    }
}