using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private ControladoraUsuario controladoraUsuario = new ControladoraUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.Compare("", (string)Session["Nombre"]) == 0)
        {
            MultiViewSiteMaster.SetActiveView(VistaLogin);
        }
        else{
            MultiViewSiteMaster.SetActiveView(VistaPrincipal);
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        String correoUsuario = this.txtUsuario.Text;
        String password = this.txtContrasena.Text;
        Boolean siExiste = controladoraUsuario.existeUsuario(correoUsuario, password);
        if (siExiste)
        {
            Session["Nombre"] = correoUsuario;
            Response.Redirect("~/Default.aspx");
        }
        else {
            this.lblErrorUsuario.Visible = true;
        }
    }
}