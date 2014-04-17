using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proveedores : System.Web.UI.Page
{
    private ControladoraProveedor proveedorController = new ControladoraProveedor();
    private static int modo = -1;
    private static int modoPaging = 1;
    private static Proveedor currentProveedor;
    private CommonServices utils;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CedulaContribuyente"] = "";
        utils = new CommonServices(UpdatePopUp);
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            modoPaging = 1;
            fillGrid(proveedorController.consultarTodosProveedores());
        }
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        modo = 1;
        clearFields();
        enableFields(true);
        enableButtonsME(false, false);
        enableButtonsAC(true);
        int lastId = proveedorController.getLastId() + 1;
        this.txtCodeProveedor.Text = lastId.ToString();
        utils.abrirPopUp("popUpProveedor", "Administrar proveedor");
    }
    protected void GridViewProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridViewProveedores.PageIndex = e.NewPageIndex;
        if (modoPaging == 1)
        {
            fillGrid(proveedorController.consultarTodosProveedores());
        }
        else
        {
            fillGrid(proveedorController.buscarProveedores(this.txtSearch.Text.ToString()));
        }
        this.GridViewProveedores.DataBind();
        this.GridViewProveedores.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.GridViewProveedores.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void GridViewProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectProveedor":
                {
                    GridViewRow selectedRow = this.GridViewProveedores.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentProveedor = proveedorController.consultarProveedor(selectedRow.Cells[2].Text);
                    clearFields();
                    fillFields(currentProveedor);
                    enableFields(false);
                    enableButtonsAC(false);
                    enableButtonsME(true, true);
                    utils.abrirPopUp("popUpProveedor", "Administrar proveedor");
                } break;
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
        utils.abrirPopUp("popUpDeleteProveedor", "Eliminar proveedor");
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Object[] datos = new Object[7];
        datos[0] = this.txtCodeProveedor.Text;
        datos[1] = this.txtProveedorName.Text;
        datos[2] = this.txtCedula.Text;
        datos[3] = this.txtAddress.Text;
        datos[4] = this.txtPhone.Text;
        datos[5] = this.txtFax.Text;
        datos[6] = this.txtEmail.Text;
        String resultado = "";
        if (modo == 1) // insertar
        {
            resultado = proveedorController.insertarProveedor(datos);
            if (String.Equals("Se insertó correctamente el proveedor", resultado))
            {
                modoPaging = 1;
                fillGrid(proveedorController.consultarTodosProveedores());
                utils.cerrarPopUp("popUpProveedor");
            }
        }
        else if (modo == 2)
        {  // modificar
            resultado = proveedorController.modificarProveedor(datos, currentProveedor);
            if (String.Equals("Se modificó correctamente el proveedor", resultado))
            {
                currentProveedor = new Proveedor(); // limpio el usuario actual
                modoPaging = 1;
                fillGrid(proveedorController.consultarTodosProveedores());
                utils.cerrarPopUp("popUpProveedor");
            }
        }
        utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Proveedor", resultado);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        currentProveedor = new Proveedor(); // limpio el usuario actual
        utils.cerrarPopUp("popUpProveedor");
    }

    protected void btnYesDel_Click(object sender, EventArgs e)
    {
        String resultado = proveedorController.eliminarProveedor(currentProveedor);
        if (String.Equals("Se eliminó correctamente el proveedor", resultado))
        {
            currentProveedor = new Proveedor(); // limpio el usuario actual
            modoPaging = 1;
            fillGrid(proveedorController.consultarTodosProveedores());
            utils.cerrarPopUp("popUpDeleteProveedor");
            utils.cerrarPopUp("popUpProveedor");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Proveedor", resultado);
        }
        else
        {
            utils.cerrarPopUp("popUpDeleteProveedor");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Proveedor", resultado);
        }
    }

    protected void btnNoDel_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpDeleteProveedor");
    }

    protected DataTable createHeaders()
    {
        DataTable dt = new DataTable();
        DataColumn column;

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Nombre";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Cédula";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Teléfono";
        dt.Columns.Add(column);

        return dt;
    }

    protected void fillGrid(List<Proveedor> proveedoresDt)
    {
        DataTable auxiliarHeaders = createHeaders();
        if (proveedoresDt.Count > 0)
        {
            this.GridViewProveedores.Columns[0].Visible = true;
            foreach (Proveedor proveedor in proveedoresDt)
            {
                Object[] datos = new Object[3];
                datos[0] = proveedor.NombreProveedor;
                datos[1] = proveedor.Cedula;
                datos[2] = proveedor.Telefono;
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.GridViewProveedores.Columns[0].Visible = false;
            Object[] datos = new Object[3];
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.GridViewProveedores.DataSource = auxiliarHeaders;
        this.GridViewProveedores.DataBind();
        this.GridViewProveedores.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.GridViewProveedores.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void fillFields(Proveedor proveedor)
    {
        this.txtProveedorName.Text = proveedor.NombreProveedor;
        this.txtCedula.Text = proveedor.Cedula;
        this.txtCodeProveedor.Text = proveedor.IdProveedor.ToString();
        this.txtEmail.Text = proveedor.Correo;
        this.txtAddress.Text = proveedor.Direccion;
        this.txtFax.Text = proveedor.Fax;
        this.txtPhone.Text = proveedor.Telefono;
    }

    protected void clearFields()
    {
        this.txtProveedorName.Text = "";
        this.txtCedula.Text = "";
        this.txtCodeProveedor.Text = "";
        this.txtEmail.Text = "";
        this.txtAddress.Text = "";
        this.txtFax.Text = "";
        this.txtPhone.Text = "";
    }

    protected void enableFields(Boolean action)
    {
        if (action)
        {
            this.txtProveedorName.Enabled = true;
            this.txtCedula.Enabled = true;
            this.txtCodeProveedor.Enabled = false;
            this.txtEmail.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtFax.Enabled = true;
            this.txtPhone.Enabled = true;
        }
        else
        {
            this.txtProveedorName.Enabled = false;
            this.txtCedula.Enabled = false;
            this.txtCodeProveedor.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtAddress.Enabled = false;
            this.txtFax.Enabled = false;
            this.txtPhone.Enabled = false;
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<Proveedor> customersList = proveedorController.buscarProveedores(this.txtSearch.Text.ToString());
        modoPaging = 2;
        fillGrid(customersList);
    }

}