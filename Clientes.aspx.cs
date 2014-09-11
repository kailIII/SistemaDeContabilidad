using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    private ControladoraCliente customerController = new ControladoraCliente();
    private static int modo = -1;
    private static int modoPaging = 1;
    private static Cliente currentCustomer;
    private CommonServices utils;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CedulaContribuyente"] = "";
        utils = new CommonServices(UpdatePopUp);
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            modoPaging = 1;
            fillGrid(customerController.consultarTodosClientes());
        }
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        modo = 1;
        clearFields();
        enableFields(true);
        enableButtonsME(false, false);
        enableButtonsAC(true);
        int lastId = customerController.getLastId() + 1;
        this.txtCodeCiente.Text = lastId.ToString();
        utils.abrirPopUp("popUpCliente", "Administrar cliente");
    }
    protected void GridViewClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridViewClientes.PageIndex = e.NewPageIndex;
        if (modoPaging == 1)
        {
            fillGrid(customerController.consultarTodosClientes());
        }
        else
        {
            fillGrid(customerController.buscarClientes(utils.procesarStringDeUI(this.txtSearch.Text.ToString())));
        }
        this.GridViewClientes.DataBind();
        this.GridViewClientes.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.GridViewClientes.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void GridViewClientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectCliente":
                {
                    GridViewRow selectedRow = this.GridViewClientes.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentCustomer = customerController.consultarCliente(utils.procesarStringDeUI(selectedRow.Cells[2].Text));
                    clearFields();
                    fillFields(currentCustomer);
                    enableFields(false);
                    enableButtonsAC(false);
                    enableButtonsME(true, true);
                    utils.abrirPopUp("popUpCliente", "Administrar cliente");

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
        utils.abrirPopUp("popUpDeleteCliente", "Eliminar cliente");
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Object[] datos = new Object[7];
        datos[0] = utils.procesarStringDeUI(this.txtCodeCiente.Text);
        datos[1] = utils.procesarStringDeUI(this.txtCustomerName.Text);
        datos[2] = utils.procesarStringDeUI(this.txtCedula.Text);
        datos[3] = utils.procesarStringDeUI(this.txtAddress.Text);
        datos[4] = utils.procesarStringDeUI(this.txtPhone.Text);
        datos[5] = utils.procesarStringDeUI(this.txtFax.Text);
        datos[6] = utils.procesarStringDeUI(this.txtEmail.Text);
        String resultado = "";
        if (modo == 1) // insertar
        {
            resultado = customerController.insertarCliente(datos);
            if (String.Equals("Se insertó correctamente el cliente", resultado))
            {
                modoPaging = 1;
                fillGrid(customerController.consultarTodosClientes());
                utils.cerrarPopUp("popUpCliente");
            }
        }
        else if (modo == 2)
        {  // modificar
            resultado = customerController.modificarCliente(datos, currentCustomer);
            if (String.Equals("Se modificó correctamente el cliente", resultado))
            {
                currentCustomer = new Cliente(); // limpio el usuario actual
                modoPaging = 1;
                fillGrid(customerController.consultarTodosClientes());
                utils.cerrarPopUp("popUpCliente");
            }
        }
        utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Cliente", resultado);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        currentCustomer = new Cliente(); // limpio el usuario actual
        utils.cerrarPopUp("popUpCliente");
    }

    protected void btnYesDel_Click(object sender, EventArgs e)
    {
        String resultado = customerController.eliminarCliente(currentCustomer);
        if (String.Equals("Se eliminó correctamente el cliente", resultado))
        {
            currentCustomer = new Cliente(); // limpio el usuario actual
            modoPaging = 1;
            fillGrid(customerController.consultarTodosClientes());
            utils.cerrarPopUp("popUpDeleteCliente");
            utils.cerrarPopUp("popUpCliente");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Cliente", resultado);
        }
        else
        {
            utils.cerrarPopUp("popUpDeleteCliente");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Cliente", resultado);
        }
    }

    protected void btnNoDel_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpDeleteCliente");
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

    protected void fillGrid(List<Cliente> clientesDt) {
        DataTable auxiliarHeaders = createHeaders();
        if (clientesDt.Count > 0)
        {
            this.GridViewClientes.Columns[0].Visible = true;
            foreach (Cliente customer in clientesDt)
            {
                Object[] datos = new Object[3];
                datos[0] = utils.procesarStringDeUI(customer.NombreCliente);
                datos[1] = utils.procesarStringDeUI(customer.Cedula);
                datos[2] = utils.procesarStringDeUI(customer.Telefono);
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.GridViewClientes.Columns[0].Visible = false;
            Object[] datos = new Object[3];
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.GridViewClientes.DataSource = auxiliarHeaders;
        this.GridViewClientes.DataBind();
        this.GridViewClientes.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.GridViewClientes.HeaderRow.ForeColor = System.Drawing.Color.White;     
    }

    protected void fillFields(Cliente cliente) {
        this.txtCustomerName.Text = utils.procesarStringDeUI(cliente.NombreCliente);
        this.txtCedula.Text = utils.procesarStringDeUI(cliente.Cedula);
        this.txtCodeCiente.Text = utils.procesarStringDeUI(cliente.IdCliente.ToString());
        this.txtEmail.Text = utils.procesarStringDeUI(cliente.Correo);
        this.txtAddress.Text = utils.procesarStringDeUI(cliente.Direccion);
        this.txtFax.Text = utils.procesarStringDeUI(cliente.Fax);
        this.txtPhone.Text = utils.procesarStringDeUI(cliente.Telefono);
    }

    protected void clearFields() {
        this.txtCustomerName.Text = "";
        this.txtCedula.Text = "";
        this.txtCodeCiente.Text = "";
        this.txtEmail.Text = "";
        this.txtAddress.Text = "";
        this.txtFax.Text = "";
        this.txtPhone.Text = "";
    }

    protected void enableFields(Boolean action)
    {
        if (action)
        {
            this.txtCustomerName.Enabled = true;
            this.txtCedula.Enabled = true;
            this.txtCodeCiente.Enabled = false;
            this.txtEmail.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtFax.Enabled = true;
            this.txtPhone.Enabled = true;
        }
        else {
            this.txtCustomerName.Enabled = false;
            this.txtCedula.Enabled = false;
            this.txtCodeCiente.Enabled = false;
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
        List<Cliente> customersList = customerController.buscarClientes(this.txtSearch.Text.ToString());
        modoPaging = 2;
        fillGrid(customersList);
    }

}