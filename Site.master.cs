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
            this.lblCerrarSesion.Text = "| Bienvenid@, " + Session["Usuario"].ToString();
            MultiViewSiteMaster.SetActiveView(VistaPrincipal);

            if (Session["CedulaContribuyente"].ToString().Equals(""))
            {
                MenuItem newMenuItem = new MenuItem("Inicio", "m0", "", "~/Default.aspx");
                NavigationMenu.Items.Add(newMenuItem);
                newMenuItem = new MenuItem("Usuarios", "m0", "", "~/Usuarios.aspx");
                NavigationMenu.Items.Add(newMenuItem);
                newMenuItem = new MenuItem("Contribuyentes", "m0", "", "~/Contribuyentes.aspx");
                NavigationMenu.Items.Add(newMenuItem);
                newMenuItem = new MenuItem("Clientes", "m0", "", "~/Clientes.aspx");
                NavigationMenu.Items.Add(newMenuItem);
                newMenuItem = new MenuItem("Proveedores", "m0", "", "~/Proveedores.aspx");
                NavigationMenu.Items.Add(newMenuItem);
            }
            else {
                MenuItem newMenuItem = new MenuItem("Detalle", "m0", "", "~/DetalleContribuyente.aspx");
                NavigationMenu.Items.Add(newMenuItem);
                newMenuItem = new MenuItem("Contribuyentes", "m0", "", "~/Contribuyentes.aspx");
                NavigationMenu.Items.Add(newMenuItem);      
            }


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
            Session["Usuario"] = controladoraUsuario.consultarNombre(correoUsuario, password);
            Response.Redirect("~/Default.aspx");
        }
        else {
            this.lblErrorUsuario.Visible = true;
        }
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["Nombre"] = "";
        Session["Usuario"] = "";
        Response.Redirect("~/Default.aspx");
    }
}