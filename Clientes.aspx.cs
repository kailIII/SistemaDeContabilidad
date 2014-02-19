using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
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
        utils.abrirPopUp("popUpCliente", "Administrar cliente");
    }
    protected void GridViewClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void GridViewClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectCliente":
                {
                    GridViewRow selectedRow = this.GridViewClientes.Rows[Convert.ToInt32(e.CommandArgument)];
                    utils.abrirPopUp("popUpCliente", "Administrar cliente");

                } break;
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {

    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpDeleteCliente", "Eliminar cliente");
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