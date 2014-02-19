using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proveedores : System.Web.UI.Page
{
    private CommonServices utils;

    protected void Page_Load(object sender, EventArgs e)
    {
        utils = new CommonServices(UpdatePopUp);
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpProveedor", "Administrar proveedor");
    }
    protected void GridViewProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void GridViewProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectProveedor":
                {
                    GridViewRow selectedRow = this.GridViewProveedores.Rows[Convert.ToInt32(e.CommandArgument)];
                    utils.abrirPopUp("popUpProveedor", "Administrar proveedor");

                } break;
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {

    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpDeleteProveedor", "Eliminar proveedor");
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void btnYesDel_Click(object sender, EventArgs e)
    {

    }

    protected void btnNoDel_Click(object sender, EventArgs e)
    {

    }
}