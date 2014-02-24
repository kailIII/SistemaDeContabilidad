using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private CommonServices utils;
    private ControladoraContribuyentes contribuyenteController = new ControladoraContribuyentes();
    protected void Page_Load(object sender, EventArgs e)
    {
        utils = new CommonServices(UpdateInfo);
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpInfoContribuyente", "Administrar contribuyente");
    }
    protected void btnSeleccionar_Click(object sender, EventArgs e)
    {
        fillGrid();
        utils.abrirPopUp("popUpContribuyente", "Seleccione un contribuyente");
    }
    protected void GridViewContribuyentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridViewContribuyentes_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected DataTable createHeaders()
    {
        DataTable dt = new DataTable();
        DataColumn column;

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Nombre contribuyente";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Cédula contribuyente";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Nombre representante";
        dt.Columns.Add(column);

        return dt;
    }

    protected void fillGrid()
    {
        DataTable auxiliarHeaders = createHeaders();
        List<Contribuyente> contribuyentesDT = contribuyenteController.consultarTodosContribuyentes();
        if (contribuyentesDT.Count > 0)
        {
            this.GridViewContribuyentes.Columns[0].Visible = true;
            foreach (Contribuyente contribuyente in contribuyentesDT)
            {
                Object[] datos = new Object[3];
                datos[0] = contribuyente.NombreContribuyente;
                datos[1] = contribuyente.CedulaContribuyente;
                datos[2] = contribuyente.NombreRepresentante;
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.GridViewContribuyentes.Columns[0].Visible = false;
            Object[] datos = new Object[3];
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.GridViewContribuyentes.DataSource = auxiliarHeaders;
        this.GridViewContribuyentes.DataBind();
        this.GridViewContribuyentes.HeaderRow.BackColor = System.Drawing.Color.FromArgb(13337903);
        this.GridViewContribuyentes.HeaderRow.ForeColor = System.Drawing.Color.White;
    }
    protected void updateButton_Click(object sender, EventArgs e)
    {

    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {

    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
}