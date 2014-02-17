﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios : System.Web.UI.Page
{
    private CommonServices utils;
    private ControladoraUsuario userController = new ControladoraUsuario();
    private static int modo = -1;
    private static Usuario currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        utils = new CommonServices(UpdatePopUp);
        if(!Page.IsPostBack){
            Page.MaintainScrollPositionOnPostBack = true;          
            fillGrid();
        }
    }

    protected DataTable createHeaders() {
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
        column.ColumnName = "Correo";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Teléfono";
        dt.Columns.Add(column);

        return dt;  
    }

    protected void fillGrid() {
        DataTable auxiliarHeaders = createHeaders();
        List<Usuario> usersDt = userController.consultarTodosUsuarios();
        if (usersDt.Count > 0)
        {
            foreach (Usuario user in usersDt)
            {
                Object[] datos = new Object[4];
                datos[0] = user.Nombre + " " + user.Apellidos;
                datos[1] = user.Cedula;
                datos[2] = user.Correo;
                datos[3] = user.Telefono;
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else {
            Object[] datos = new Object[4];
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            datos[3] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.GridViewUsers.DataSource = auxiliarHeaders;
        this.GridViewUsers.DataBind();
        this.GridViewUsers.HeaderRow.BackColor = System.Drawing.Color.FromArgb(13337903);
        this.GridViewUsers.HeaderRow.ForeColor = System.Drawing.Color.White;              
    }

    protected void fillFields(Usuario user) {
        this.txtUserName.Text = user.Nombre;
        this.txtLastName.Text = user.Apellidos;
        this.txtCedula.Text = user.Cedula;
        this.txtEmail.Text = user.Correo;
        this.txtPass.Text = user.Contrasena;
        this.txtConfPass.Text = user.Contrasena;
        this.txtPhone.Text = user.Telefono;
        this.txtAddress.Text = user.Direccion;    
    }

    protected void clearFields()
    {
        this.txtUserName.Text = "";
        this.txtLastName.Text = "";
        this.txtCedula.Text = "";
        this.txtEmail.Text = "";
        this.txtPass.Text = "";
        this.txtConfPass.Text = "";
        this.txtPhone.Text = "";
        this.txtAddress.Text = "";
    }

    protected void enableFields(Boolean action) {
        if (action)
        {
            this.txtUserName.Enabled = true;
            this.txtLastName.Enabled = true;
            this.txtCedula.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtPass.Enabled = true;
            this.txtConfPass.Enabled = true;
            this.txtPhone.Enabled = true;
            this.txtAddress.Enabled = true;
        }
        else
        {
            this.txtUserName.Enabled = false;
            this.txtLastName.Enabled = false;
            this.txtCedula.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtPass.Enabled = false;
            this.txtConfPass.Enabled = false;
            this.txtPhone.Enabled = false;
            this.txtAddress.Enabled = false;
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

    protected void visibleButtonsME(Boolean accept, Boolean cancel) { 
        this.updateButton.Visible = (accept ? true : false);
        this.deleteButton.Visible = (cancel ? true : false);
    }

    protected void visibleButtonsAC(Boolean action)
    {
        if (action)
        {
            this.btnAceptar.Visible = true;
            this.btnCancelar.Visible = true;
        }
        else
        {
            this.btnAceptar.Visible = false;
            this.btnCancelar.Visible = false;
        }
    }

    protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectUser":
                {
                    GridViewRow selectedRow = this.GridViewUsers.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentUser = userController.consultarUsuario(selectedRow.Cells[2].Text);
                    clearFields();
                    fillFields(currentUser);
                    enableFields(false);
                    visibleButtonsAC(false);
                    visibleButtonsME(true, true);
                    utils.abrirPopUp("popUpUsuario", "Administrar usuario");

                } break;
        }
    }

    protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        modo = 1;
        clearFields();
        enableFields(true);
        visibleButtonsME(false, false);
        visibleButtonsAC(true);
        utils.abrirPopUp("popUpUsuario", "Administrar usuario");
    }


    protected void updateButton_Click(object sender, EventArgs e)
    {
        modo = 2;
        enableFields(true);
        visibleButtonsME(false, true);
        visibleButtonsAC(true);
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Object[] datos = new Object[7];
        datos[0] = this.txtUserName.Text;
        datos[1] = this.txtLastName.Text;
        datos[2] = this.txtCedula.Text;
        datos[3] = this.txtEmail.Text;
        datos[4] = this.txtPhone.Text;
        datos[5] = this.txtPass.Text;
        datos[6] = this.txtAddress.Text;
        String resultado = "";
        if (modo == 1) // insertar
        {
            resultado = userController.insertarUsuario(datos);
            if(String.Equals("Se insertó correctamente el usuario", resultado)){
                fillGrid();
                utils.cerrarPopUp("popUpUsuario");       
            }
        }
        else if(modo == 2) {  // modificar
            resultado = userController.modificarUsuario(datos, currentUser);
            if (String.Equals("Se modificó correctamente el usuario", resultado))
            {
                currentUser = new Usuario(); // limpio el usuario actual
                fillGrid();
                utils.cerrarPopUp("popUpUsuario");
            }
        }
        utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Usuario", resultado);
    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpDelete", "Eliminar usuario");
    }
    protected void btnYesDel_Click(object sender, EventArgs e)
    {
        String resultado = userController.eliminarUsuario(currentUser);
        if (String.Equals("Se eliminó correctamente el usuario", resultado))
        {
            currentUser = new Usuario(); // limpio el usuario actual
            fillGrid();
            utils.cerrarPopUp("popUpDelete");
            utils.cerrarPopUp("popUpUsuario");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Usuario", resultado);
        }
        else{
            utils.cerrarPopUp("popUpDelete");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Administrar Usuario", resultado);
        }
    }
    protected void btnNoDel_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpDelete");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        currentUser = new Usuario(); // limpio el usuario actual
        utils.cerrarPopUp("popUpUsuario");
    }
}