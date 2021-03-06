﻿using System;
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
    private static int tipoManager = -1;
    private static int modoPaging = 1;
    private static int modoPagingManager = 1;
    private static Contribuyente currentContribuyente;
    protected void Page_Load(object sender, EventArgs e)
    {
        utils = new CommonServices(UpdatePopUp);
        Session["CedulaContribuyente"] = "";
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            modoPaging = 1;
            modoPagingManager = 1;
            fillDrpType();
            fillGrid(contribuyenteController.consultarTodosContribuyentes());
            clearFields();
            hiddenFields();
        }
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        clearFields();
        modo = 1;
        enableFields(true);
        enableButtonsME(false, false, false, false);
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
        this.GridViewContribuyentes.PageIndex = e.NewPageIndex;
        if (modoPaging == 1)
        {
            fillGrid(contribuyenteController.consultarTodosContribuyentes());
        }
        else
        {
            fillGrid(contribuyenteController.buscarContribuyentes(utils.procesarStringDeUI(this.txtSearch.Text.ToString())));
        }
        this.GridViewContribuyentes.DataBind();
        this.GridViewContribuyentes.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.GridViewContribuyentes.HeaderRow.ForeColor = System.Drawing.Color.White;
    }
    protected void GridViewContribuyentes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectContribuyente":
                {
                    GridViewRow selectedRow = this.GridViewContribuyentes.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentContribuyente = contribuyenteController.consultarContribuyente(utils.procesarStringDeUI(selectedRow.Cells[3].Text));
                    clearFields();
                    fillFields(currentContribuyente);
                    enableFields(false);
                    enableButtonsAC(false);
                    enableButtonsME(true, true, true, true);
                    utils.abrirPopUp("popUpInfoContribuyente", "Administrar Contribuyente");

                } break;
            case "infoContribuyente":
                {
                    GridViewRow selectedRow = this.GridViewContribuyentes.Rows[Convert.ToInt32(e.CommandArgument)];
                    Session["CedulaContribuyente"] = utils.procesarStringDeUI(selectedRow.Cells[3].Text);
                    Response.Redirect("~/DetalleContribuyente.aspx");
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

    protected void fillDrpType()
    {
        this.drpType.Items.Clear();
        ListItem newItem = new ListItem();
        newItem.Text = "Contribuyente Físico";
        newItem.Value = "0";
        drpType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Contribuyente Jurídico";
        newItem.Value = "1";
        drpType.Items.Add(newItem);
    }

    protected void fillGrid(List<Contribuyente> contribuyentesDT)
    {
        DataTable auxiliarHeaders = createHeaders();
        if (contribuyentesDT.Count > 0)
        {
            this.GridViewContribuyentes.Columns[0].Visible = true;
            this.GridViewContribuyentes.Columns[1].Visible = true;
            foreach (Contribuyente contribuyente in contribuyentesDT)
            {
                Object[] datos = new Object[3];
                datos[0] = utils.procesarStringDeUI(contribuyente.NombreContribuyente);
                datos[1] = utils.procesarStringDeUI(contribuyente.CedulaContribuyente);
                datos[2] = utils.procesarStringDeUI(contribuyente.NombreRepresentante);
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.GridViewContribuyentes.Columns[0].Visible = false;
            this.GridViewContribuyentes.Columns[1].Visible = false;
            Object[] datos = new Object[3];
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.GridViewContribuyentes.DataSource = auxiliarHeaders;
        this.GridViewContribuyentes.DataBind();
        this.GridViewContribuyentes.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.GridViewContribuyentes.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void clearFields()
    {
        modo = -1;
        this.txtcodeContribuyente.Text = "";
        this.txtNombreContribuyente.Text = "";
        this.txtCedulaContribuyente.Text = "";
        this.txtNombreRepresentante.Text = "";
        this.txtCedulaRepresentante.Text = "";
        this.txtProvincia.Text = "";
        this.txtCanton.Text = "";
        this.txtDistrito.Text = "";
        this.txtDirección.Text = "";
        this.drpType.SelectedIndex = 0;
        this.txtUltimoPeriodo.Text = "";
    }

    protected void fillFields(Contribuyente contribuyente)
    {
        this.txtcodeContribuyente.Text = utils.procesarStringDeUI(contribuyente.IdContribuyente.ToString());
        this.txtNombreContribuyente.Text = utils.procesarStringDeUI(contribuyente.NombreContribuyente);
        this.txtCedulaContribuyente.Text = utils.procesarStringDeUI(contribuyente.CedulaContribuyente);
        this.txtNombreRepresentante.Text = utils.procesarStringDeUI(contribuyente.NombreRepresentante);
        this.txtCedulaRepresentante.Text = utils.procesarStringDeUI(contribuyente.CedulaRepresentante);
        this.txtProvincia.Text = utils.procesarStringDeUI(contribuyente.Provincia);
        this.txtCanton.Text = utils.procesarStringDeUI(contribuyente.Canton);
        this.txtDistrito.Text = utils.procesarStringDeUI(contribuyente.Distrito);
        this.txtDirección.Text = utils.procesarStringDeUI(contribuyente.Direccion);
        if (this.drpType.Items.FindByValue(contribuyente.Tipo.ToString()) != null)
        {
            ListItem aux = this.drpType.Items.FindByValue(contribuyente.Tipo.ToString());
            this.drpType.SelectedValue = aux.Value;
            hiddenFields();
        }
        this.txtUltimoPeriodo.Text = utils.procesarStringDeUI(contribuyente.UltimoPeriodo);
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
            this.drpType.Enabled = true;
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
            this.drpType.Enabled = false;
            this.txtUltimoPeriodo.Enabled = false;
        }

    }

    protected void enableButtonsME(Boolean update, Boolean delete, Boolean mc, Boolean mp)
    {
        this.manageProveedor.Enabled = (mp ? true : false);
        this.manageCustomer.Enabled = (mc ? true : false);
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
        enableButtonsME(false, true, false, false);
        enableButtonsAC(true);
    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpDeleteContribuyente", "Eliminar contribuyente");
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

        Object[] datos = new Object[11];
        datos[0] = utils.procesarStringDeUI(this.txtcodeContribuyente.Text);
        datos[1] = utils.procesarStringDeUI(this.txtCedulaContribuyente.Text);
        datos[2] = utils.procesarStringDeUI(this.txtNombreContribuyente.Text);
        datos[3] = utils.procesarStringDeUI(this.txtNombreRepresentante.Text);
        datos[4] = utils.procesarStringDeUI(this.txtCedulaRepresentante.Text);
        datos[5] = utils.procesarStringDeUI(this.txtProvincia.Text);
        datos[6] = utils.procesarStringDeUI(this.txtCanton.Text);
        datos[7] = utils.procesarStringDeUI(this.txtDistrito.Text);
        datos[8] = utils.procesarStringDeUI(this.txtDirección.Text);
        datos[9] = this.drpType.SelectedItem.Value;
        datos[10] = utils.procesarStringDeUI(this.txtUltimoPeriodo.Text);
        String resultado = "";
        if (modo == 1) // insertar
        {
            resultado = contribuyenteController.insertarContribuyente(datos);
            if (String.Equals("Se insertó correctamente el contribuyente", resultado))
            {
                modoPaging = 1;
                fillGrid(contribuyenteController.consultarTodosContribuyentes());
                utils.cerrarPopUp("popUpInfoContribuyente");
            }
        }
        else if (modo == 2)
        {  // modificar
            resultado = contribuyenteController.modificarContribuyente(datos, currentContribuyente);
            if (String.Equals("Se modificó correctamente el contribuyente", resultado))
            {
                currentContribuyente = new Contribuyente(); // limpio el usuario actual
                modoPaging = 1;
                fillGrid(contribuyenteController.consultarTodosContribuyentes());
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
            modoPaging = 1;
            fillGrid(contribuyenteController.consultarTodosContribuyentes());
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<Contribuyente> contribuyentesList = contribuyenteController.buscarContribuyentes(this.txtSearch.Text.ToString());
        modoPaging = 2;
        fillGrid(contribuyentesList);
    }
    protected void manageCustomer_Click(object sender, EventArgs e)
    {
        tipoManager = 1;
        fillGridSeleccionarClientes(contribuyenteController.consultarSeleccionarClientes(currentContribuyente.CedulaContribuyente));
        fillGridClientesSeleccionados(contribuyenteController.consultarClientesSeleccionados(currentContribuyente.CedulaContribuyente));
        utils.abrirPopUp("ManageCustomerProveedorPopUp","Asociar Clientes");
    }
    protected void manageProveedor_Click(object sender, EventArgs e)
    {
        tipoManager = 2;
        fillGridSeleccionarProveedores(contribuyenteController.consultarSeleccionarProveedores(currentContribuyente.CedulaContribuyente));
        fillGridProveedoresSeleccionados(contribuyenteController.consultarProveedoresSeleccionados(currentContribuyente.CedulaContribuyente));
        utils.abrirPopUp("ManageCustomerProveedorPopUp", "Asociar Proveedores");
    }
    protected void GridSeleccionar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grid_Seleccionar.PageIndex = e.NewPageIndex;
        if (modoPagingManager == 1)
        {
            if (tipoManager == 1)
            {
                fillGridSeleccionarClientes(contribuyenteController.consultarSeleccionarClientes(currentContribuyente.CedulaContribuyente));
            }
            else if (tipoManager == 2)
            {
                fillGridSeleccionarProveedores(contribuyenteController.consultarSeleccionarProveedores(currentContribuyente.CedulaContribuyente));
            }
        }
        else if (modoPagingManager == 2)
        {
            if (tipoManager == 1)
            {//cliente
                List<Cliente> clienteList = contribuyenteController.buscarClientesDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchAvailables.Text));
                fillGridSeleccionarClientes(clienteList);
            }
            else if (tipoManager == 2)
            { //proveedor
                List<Proveedor> proveedoresList = contribuyenteController.buscarProveedoresDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchAvailables.Text));
                fillGridSeleccionarProveedores(proveedoresList);
            }
        }
        this.grid_Seleccionar.DataBind();
        this.grid_Seleccionar.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.grid_Seleccionar.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void GridSeleccionados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grid_Seleccionados.PageIndex = e.NewPageIndex;
        if (modoPagingManager == 1)
        {
            if (tipoManager == 1)
            {
                fillGridClientesSeleccionados(contribuyenteController.consultarClientesSeleccionados(currentContribuyente.CedulaContribuyente));
            }
            else if (tipoManager == 2)
            {
                fillGridProveedoresSeleccionados(contribuyenteController.consultarProveedoresSeleccionados(currentContribuyente.CedulaContribuyente));
            }
        }
        else if (modoPagingManager == 2)
        {
            if (tipoManager == 1)
            {//cliente
                List<Cliente> clienteList = contribuyenteController.buscarClientesNoDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchAvailables.Text));
                fillGridClientesSeleccionados(clienteList);
            }
            else if (tipoManager == 2)
            { //proveedor
                List<Proveedor> proveedoresList = contribuyenteController.buscarProveedoresNoDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchAvailables.Text));
                fillGridProveedoresSeleccionados(proveedoresList);
            }
        }
        this.grid_Seleccionados.DataBind();
        this.grid_Seleccionados.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.grid_Seleccionados.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected DataTable createHeadersManager()
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

        return dt;
    }

    protected void fillGridSeleccionarClientes(List<Cliente> clientesDT)
    {
        DataTable auxiliarHeaders = createHeadersManager();
        if (clientesDT.Count > 0)
        {
            this.grid_Seleccionar.Columns[0].Visible = true;
            foreach (Cliente cliente in clientesDT)
            {
                Object[] datos = new Object[2];
                datos[0] = utils.procesarStringDeUI(cliente.NombreCliente);
                datos[1] = utils.procesarStringDeUI(cliente.Cedula);
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.grid_Seleccionar.Columns[0].Visible = false;
            Object[] datos = new Object[2];
            datos[0] = "-";
            datos[1] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.grid_Seleccionar.DataSource = auxiliarHeaders;
        this.grid_Seleccionar.DataBind();
        this.grid_Seleccionar.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.grid_Seleccionar.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void fillGridClientesSeleccionados(List<Cliente> clientesDT)
    {
        DataTable auxiliarHeaders = createHeadersManager();
        if (clientesDT.Count > 0)
        {
            this.grid_Seleccionados.Columns[0].Visible = true;
            foreach (Cliente cliente in clientesDT)
            {
                Object[] datos = new Object[2];
                datos[0] = utils.procesarStringDeUI(cliente.NombreCliente);
                datos[1] = utils.procesarStringDeUI(cliente.Cedula);
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.grid_Seleccionados.Columns[0].Visible = false;
            Object[] datos = new Object[2];
            datos[0] = "-";
            datos[1] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.grid_Seleccionados.DataSource = auxiliarHeaders;
        this.grid_Seleccionados.DataBind();
        this.grid_Seleccionados.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.grid_Seleccionados.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void fillGridSeleccionarProveedores(List<Proveedor> proveedoresDT)
    {
        DataTable auxiliarHeaders = createHeadersManager();
        if (proveedoresDT.Count > 0)
        {
            this.grid_Seleccionar.Columns[0].Visible = true;
            foreach (Proveedor proveedor in proveedoresDT)
            {
                Object[] datos = new Object[2];
                datos[0] = utils.procesarStringDeUI(proveedor.NombreProveedor);
                datos[1] = utils.procesarStringDeUI(proveedor.Cedula);
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.grid_Seleccionar.Columns[0].Visible = false;
            Object[] datos = new Object[2];
            datos[0] = "-";
            datos[1] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.grid_Seleccionar.DataSource = auxiliarHeaders;
        this.grid_Seleccionar.DataBind();
        this.grid_Seleccionar.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.grid_Seleccionar.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void fillGridProveedoresSeleccionados(List<Proveedor> proveedoresDT)
    {
        DataTable auxiliarHeaders = createHeadersManager();
        if (proveedoresDT.Count > 0)
        {
            this.grid_Seleccionados.Columns[0].Visible = true;
            foreach (Proveedor proveedor in proveedoresDT)
            {
                Object[] datos = new Object[2];
                datos[0] = utils.procesarStringDeUI(proveedor.NombreProveedor);
                datos[1] = utils.procesarStringDeUI(proveedor.Cedula);
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.grid_Seleccionados.Columns[0].Visible = false;
            Object[] datos = new Object[2];
            datos[0] = "-";
            datos[1] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.grid_Seleccionados.DataSource = auxiliarHeaders;
        this.grid_Seleccionados.DataBind();
        this.grid_Seleccionados.HeaderRow.BackColor = System.Drawing.Color.FromArgb(utils.headerColor);
        this.grid_Seleccionados.HeaderRow.ForeColor = System.Drawing.Color.White;
    }

    protected void grid_Seleccionados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "eliminarAsociacion":
                {
                    GridViewRow selectedRow = this.grid_Seleccionados.Rows[Convert.ToInt32(e.CommandArgument)];
                    Boolean siElimino = false;
                    if (tipoManager == 1)
                    {
                        siElimino = contribuyenteController.eliminarClienteContribuyente(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(selectedRow.Cells[2].Text));
                        if(siElimino){
                            fillGridSeleccionarClientes(contribuyenteController.consultarSeleccionarClientes(currentContribuyente.CedulaContribuyente));
                            fillGridClientesSeleccionados(contribuyenteController.consultarClientesSeleccionados(currentContribuyente.CedulaContribuyente));
                            modoPagingManager = 1;
                        }
                        
                    }
                    else if(tipoManager==2) {
                        siElimino = contribuyenteController.eliminarProveedorContribuyente(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(selectedRow.Cells[2].Text));
                        if (siElimino)
                        {
                            fillGridSeleccionarProveedores(contribuyenteController.consultarSeleccionarProveedores(currentContribuyente.CedulaContribuyente));
                            fillGridProveedoresSeleccionados(contribuyenteController.consultarProveedoresSeleccionados(currentContribuyente.CedulaContribuyente));
                            modoPagingManager = 1;
                        }
                    }
                    if(!siElimino){
                        utils.abrirPopUpPersonalizado("popUpMensaje", "Atención", "El item seleccionado posee facturas asociadas, no se puede desasociar");
                    }
                    
                } break;
        }
    }
    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rowItem in this.grid_Seleccionar.Rows)
        {
            Boolean siInserto = false;
            var chk = (CheckBox)(rowItem.Cells[0].FindControl("checkSeleccionar"));
            if (chk.Checked)
            {
                if (tipoManager == 1)
                {
                    siInserto = contribuyenteController.insertarClienteContribuyente(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(rowItem.Cells[2].Text));
                }
                else if (tipoManager == 2)
                {
                    siInserto = contribuyenteController.insertarProveedorContribuyente(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(rowItem.Cells[2].Text));
                }
            }
        }
        if(tipoManager==1){
            fillGridSeleccionarClientes(contribuyenteController.consultarSeleccionarClientes(currentContribuyente.CedulaContribuyente));
            fillGridClientesSeleccionados(contribuyenteController.consultarClientesSeleccionados(currentContribuyente.CedulaContribuyente));
            modoPagingManager = 1;
        }
        else if(tipoManager == 2){
            fillGridSeleccionarProveedores(contribuyenteController.consultarSeleccionarProveedores(currentContribuyente.CedulaContribuyente));
            fillGridProveedoresSeleccionados(contribuyenteController.consultarProveedoresSeleccionados(currentContribuyente.CedulaContribuyente));
            modoPagingManager = 1;
        }
    }
    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpType.SelectedIndex == 0)
        {
            this.lblNombreRepresentante.Visible = false;
            this.txtCedulaRepresentante.Visible = false;
            this.txtCedulaRepresentante.Text = "";
            this.lblCedulaRepresentante.Visible = false;
            this.txtNombreRepresentante.Visible = false;
            this.txtNombreRepresentante.Text = "";
        }
        else {
            this.lblNombreRepresentante.Visible = true;
            this.txtCedulaRepresentante.Visible = true;
            this.lblCedulaRepresentante.Visible = true;
            this.txtNombreRepresentante.Visible = true;
        }
    }

    private void hiddenFields() {
        if (this.drpType.SelectedIndex == 0)
        {
            this.lblNombreRepresentante.Visible = false;
            this.txtCedulaRepresentante.Visible = false;
            this.lblCedulaRepresentante.Visible = false;
            this.txtNombreRepresentante.Visible = false;
        }
        else
        {
            this.lblNombreRepresentante.Visible = true;
            this.txtCedulaRepresentante.Visible = true;
            this.lblCedulaRepresentante.Visible = true;
            this.txtNombreRepresentante.Visible = true;
        }    
    }
    protected void btnSearchAvailables_Click(object sender, EventArgs e)
    {
        if(tipoManager==1){//cliente
            List<Cliente> clienteList = contribuyenteController.buscarClientesDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchAvailables.Text));
            fillGridSeleccionarClientes(clienteList);
        }
        else if(tipoManager==2){ //proveedor
            List<Proveedor> proveedoresList = contribuyenteController.buscarProveedoresDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchAvailables.Text));
            fillGridSeleccionarProveedores(proveedoresList);
        }
        modoPagingManager = 2;
        
    }
    protected void btnSearchUnavailables_Click(object sender, EventArgs e)
    {
        if (tipoManager == 1)
        {//cliente
            List<Cliente> clienteList = contribuyenteController.buscarClientesNoDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchUnavailables.Text));
            fillGridClientesSeleccionados(clienteList);
        }
        else if (tipoManager == 2)
        { //proveedor
            List<Proveedor> proveedoresList = contribuyenteController.buscarProveedoresNoDisponibles(currentContribuyente.CedulaContribuyente, utils.procesarStringDeUI(this.txtSearchUnavailables.Text));
            fillGridProveedoresSeleccionados(proveedoresList);
        }
        modoPagingManager = 2;
    }
}