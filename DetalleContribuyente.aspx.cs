using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _DetalleContribuyente : System.Web.UI.Page
{
    private ControladoraContribuyentes contribuController = new ControladoraContribuyentes();
    private CommonServices utils;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["NombreContribuyente"] = "";
        utils = new CommonServices(UpdateSelectDate);
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
        this.txtNameContribuyente.Text = utils.procesarStringDeUI(contribuyente.NombreContribuyente);
        this.txtCedulaContribuyente.Text = utils.procesarStringDeUI(contribuyente.CedulaContribuyente);
        this.txtNameRepresentante.Text = utils.procesarStringDeUI(contribuyente.NombreRepresentante);
        this.txtAddress.Text = utils.procesarStringDeUI((formatAddress(contribuyente.Provincia, contribuyente.Canton, contribuyente.Distrito, contribuyente.Direccion)));
        this.txtTipoContribuyente.Text = returnType(contribuyente.Tipo);
        this.txtLastPeriod.Text = utils.procesarStringDeUI(contribuyente.UltimoPeriodo);
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
        utils.abrirPopUp("popUpSelectDateVentas", "Facturación Ventas");
    }
    protected void facComprasClicked_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpSelectDateCompras", "Facturación Compras");
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Session["NombreContribuyente"] = this.txtNameContribuyente.Text.ToString();
        Response.Redirect("~/Reportes.aspx");
        
    }
    protected void btnYesDel_Click(object sender, EventArgs e)
    {
        if (!this.hfDateVentas.Value.ToString().Equals(""))
        {
            utils.cerrarPopUp("popUpSelectDateVentas");
            Session["FechaProceso"] = this.hfDateVentas.Value.ToString();
            Session["NombreContribuyente"] = this.txtNameContribuyente.Text.ToString();
            Response.Redirect("~/FacturaciónVentas.aspx");
        }
        else {
            utils.abrirPopUpPersonalizado("popUpMensaje", "Atención", "Es necesario ingresar una fecha para la inclusión de facturas");
        }
    }
    protected void btnNoDel_Click(object sender, EventArgs e)
    {
        this.hfDateVentas.Value = "";
        utils.cerrarPopUp("popUpSelectDateVentas");
    }
    protected void btnYesDel_Click1(object sender, EventArgs e)
    {
        if (!this.hfDateCompras.Value.ToString().Equals(""))
        {
            utils.cerrarPopUp("popUpSelectDateCompras");
            Session["FechaProceso"] = this.hfDateCompras.Value.ToString();
            Session["NombreContribuyente"] = this.txtNameContribuyente.Text.ToString();
            Response.Redirect("~/FacturaciónCompras.aspx");
        }
        else
        {
            utils.abrirPopUpPersonalizado("popUpMensaje", "Atención", "Es necesario ingresar una fecha para la inclusión de facturas");
        }
    }
    protected void btnNoDel_Click1(object sender, EventArgs e)
    {
        this.hfDateCompras.Value = "";
        utils.cerrarPopUp("popUpSelectDateCompras");
    }
}