using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contribuyentes : System.Web.UI.Page
{
    private CommonServices utils;
    private ControladoraContribuyentes contribuyenteController = new ControladoraContribuyentes();
    private static int modo = -1;
    private static Contribuyente currentContribuyente;
    protected void Page_Load(object sender, EventArgs e)
    {
        utils = new CommonServices(UpdatePopUp);
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            fillGrid();
        }
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        modo = 1;
        clearFields();
        enableFields(true);
        enableButtonsME(false, false);
        enableButtonsAC(true);
        int lastId = contribuyenteController.getLastId() + 1;
        this.txtcodeContribuyente.Text = lastId.ToString();
        utils.abrirPopUp("popUpInfoContribuyente", "Administrar contribuyente");
    }
/*    protected void btnSeleccionar_Click(object sender, EventArgs e)
    {
        fillGrid();
        utils.abrirPopUp("popUpContribuyente", "Seleccione un contribuyente");
    }*/
    protected void GridViewContribuyentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridViewContribuyentes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectContribuyente":
                {
                    GridViewRow selectedRow = this.GridViewContribuyentes.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentContribuyente = contribuyenteController.consultarContribuyente(selectedRow.Cells[2].Text);
                    clearFields();
                    fillFields(currentContribuyente);
                    enableFields(false);
                    enableButtonsAC(false);
                    enableButtonsME(true, true);
                    utils.abrirPopUp("popUpInfoContribuyente", "Administrar Contribuyente");

                } break;
        }
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

    protected void clearFields()
    {
        this.txtcodeContribuyente.Text = "";
        this.txtNombreContribuyente.Text = "";
        this.txtCedulaContribuyente.Text = "";
        this.txtNombreRepresentante.Text = "";
        this.txtCedulaRepresentante.Text = "";
        this.txtProvincia.Text = "";
        this.txtCanton.Text = "";
        this.txtDistrito.Text = "";
        this.txtDirección.Text = "";
        this.txtTipo.Text = "";
        this.txtUltimoPeriodo.Text = "";
    }

    protected void fillFields(Contribuyente contribuyente)
    {
        this.txtcodeContribuyente.Text = contribuyente.IdContribuyente.ToString();
        this.txtNombreContribuyente.Text = contribuyente.NombreContribuyente;
        this.txtCedulaContribuyente.Text = contribuyente.CedulaContribuyente;
        this.txtNombreRepresentante.Text = contribuyente.NombreRepresentante;
        this.txtCedulaRepresentante.Text = contribuyente.CedulaRepresentante;
        this.txtProvincia.Text = contribuyente.Provincia;
        this.txtCanton.Text = contribuyente.Canton;
        this.txtDistrito.Text = contribuyente.Distrito;
        this.txtDirección.Text = contribuyente.Direccion;
        this.txtTipo.Text = contribuyente.Tipo.ToString();
        this.txtUltimoPeriodo.Text = contribuyente.UltimoPeriodo;
    }

    protected void enableFields(Boolean action)
    {
        if (action)
        {
            this.txtcodeContribuyente.Enabled = false;
            this.txtNombreContribuyente.Enabled = true;
            this.txtCedulaContribuyente.Enabled = true;
            this.txtNombreRepresentante.Enabled = true;
            this.txtCedulaRepresentante.Enabled = true;
            this.txtProvincia.Enabled = true;
            this.txtCanton.Enabled = true;
            this.txtDistrito.Enabled = true;
            this.txtDirección.Enabled = true;
            this.txtTipo.Enabled = true;
            this.txtUltimoPeriodo.Enabled = true;
        }
        else
        {
            this.txtcodeContribuyente.Enabled = false;
            this.txtNombreContribuyente.Enabled = false;
            this.txtCedulaContribuyente.Enabled = false;
            this.txtNombreRepresentante.Enabled = false;
            this.txtCedulaRepresentante.Enabled = false;
            this.txtProvincia.Enabled = false;
            this.txtCanton.Enabled = false;
            this.txtDistrito.Enabled = false;
            this.txtDirección.Enabled = false;
            this.txtTipo.Enabled = false;
            this.txtUltimoPeriodo.Enabled = false;
        }

    }

    protected void enableButtonsME(Boolean update, Boolean delete)
    {
        this.updateButton.Enabled = (update ? true : false);
        this.deleteButton.Enabled = (delete ? true : false);
    }

    protected void enableButtonsAC(Boolean action)
    {
        if (action)
        {
            this.btnAceptar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }
        else
        {
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        modo = 2;
        enableFields(true);
        enableButtonsME(false, true);
        enableButtonsAC(true);
    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpDeleteContribuyente", "Eliminar contribuyente");
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

        Object[] datos = new Object[11];
        datos[0] = this.txtcodeContribuyente.Text;
        datos[1] = this.txtCedulaContribuyente.Text;
        datos[2] = this.txtNombreContribuyente.Text;
        datos[3] = this.txtNombreRepresentante.Text;
        datos[4] = this.txtCedulaRepresentante.Text;
        datos[5] = this.txtProvincia.Text;
        datos[6] = this.txtCanton.Text;
        datos[7] = this.txtDistrito.Text;
        datos[8] = this.txtDirección.Text;
        datos[9] = this.txtTipo.Text;
        datos[10] = this.txtUltimoPeriodo.Text;
        String resultado = "";
        if (modo == 1) // insertar
        {
            resultado = contribuyenteController.insertarContribuyente(datos);
            if (String.Equals("Se insertó correctamente el contribuyente", resultado))
            {
                fillGrid();
                utils.cerrarPopUp("popUpInfoContribuyente");
            }
        }
        else if (modo == 2)
        {  // modificar
            resultado = contribuyenteController.modificarContribuyente(datos, currentContribuyente);
            if (String.Equals("Se modificó correctamente el contribuyente", resultado))
            {
                currentContribuyente = new Contribuyente(); // limpio el usuario actual
                fillGrid();
                utils.cerrarPopUp("popUpInfoContribuyente");
            }
        }
        utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Contribuyente", resultado);
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        currentContribuyente = new Contribuyente(); // limpio el usuario actual
        utils.cerrarPopUp("popUpInfoContribuyente");
    }
    protected void btnYesDel_Click(object sender, EventArgs e)
    {
        String resultado = contribuyenteController.eliminarContribuyente(currentContribuyente);
        if (String.Equals("Se eliminó correctamente el contribuyente", resultado))
        {
            currentContribuyente = new Contribuyente(); // limpio el usuario actual
            fillGrid();
            utils.cerrarPopUp("popUpDeleteContribuyente");
            utils.cerrarPopUp("popUpInfoContribuyente");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Contribuyente", resultado);
        }
        else
        {
            utils.cerrarPopUp("popUpDeleteContribuyente");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Contribuyente", resultado);
        }
    }
    protected void btnNoDel_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpDeleteContribuyente");
    }
}