﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacturaciónVentas : System.Web.UI.Page
{
    private CommonServices utils;
    private ControladoraFacturaVenta fvController = new ControladoraFacturaVenta();
    private static int modo = -1;
    private static int modoPaging = 1;
    private static FacturaVenta currentFV;
    protected void Page_Load(object sender, EventArgs e)
    {
        utils = new CommonServices(UpdatePopUp);
        if (!Page.IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            clearFields();
            enableFields(false);
            enableButtonsIME(true, false, false); //Check it
            enableButtonsAC(false);
            modoPaging = 1;
            fillGrid(fvController.consultarTodasFacturasVentas());
            fillDrpType();
        }
    }
    protected void updateButton_Click(object sender, EventArgs e)
    {
        modo = 2;
        enableFields(true);
        enableButtonsIME(false, false, true);
        enableButtonsAC(true);
    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        utils.abrirPopUp("popUpDeleteFacturaVenta", "Eliminar factura");
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //quitar esto
        Object[] datos = new Object[18];
        datos[0] = this.txtInvoiceNumber.Text;
        datos[1] = 145145145;
        datos[2] = this.hfCustomerName.Value.ToString();
        datos[3] = this.txtDate.Text;
        datos[4] = this.drpType.SelectedItem.Value;
        datos[5] = this.txtTerm.Text;
        datos[6] = this.txtExpiration.Text;
        datos[7] = utils.stringToDouble(this.txtMontoExempt.Text);
        datos[8] = utils.stringToDouble(this.txtPorDescExempt.Text);
        datos[9] = utils.stringToDouble(this.txtDesExempt.Text);
        datos[10] = utils.stringToDouble(this.txtSubExempt.Text);
        datos[11] = utils.stringToDouble(this.txtMontoTaxed.Text);
        datos[12] = utils.stringToDouble(this.txtPorDescTaxed.Text);
        datos[13] = utils.stringToDouble(this.txtDesTaxed.Text);
        datos[14] = utils.stringToDouble(this.txtSubTaxed.Text);
        datos[15] = utils.stringToDouble(this.txtIV.Text);
        datos[16] = utils.stringToDouble(this.txtFlete.Text);
        datos[17] = utils.stringToDouble(this.txtTotal.Text);
        String resultado = "";
        Boolean action = false;
        if (modo == 1) // insertar
        {
            resultado = fvController.insertarFacturaVenta(datos);
            if (String.Equals("Se insertó correctamente la factura", resultado))
            {
                action = true;
            }
        }
        else if (modo == 2)
        {  // modificar
            resultado = fvController.modificarFacturaVenta(datos, currentFV);
            currentFV = new FacturaVenta();
            if (String.Equals("Se modificó correctamente la factura", resultado))
            {
                action = true;
            }
        }
        utils.abrirPopUpPersonalizado("popUpMensaje", "Facturación Ventas", resultado);
        if(action){
            clearFields();
            enableFields(false);
            enableButtonsAC(false);
            enableButtonsIME(true, true, true);
            modoPaging = 1;
            fillGrid(fvController.consultarTodasFacturasVentas());
        }
        //utils.abrirPopUpPersonalizado("popUpMensaje", "Cliente seleccionado", "Cliente: " + this.txtProvCust.Text.ToString() + " con Id: " + this.hfCustomerName.Value.ToString());
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        clearFields();
        enableFields(false);
        enableButtonsIME(true, false, false); //Check it
        enableButtonsAC(false);
        currentFV = new FacturaVenta(); //limpio
    }
    protected void insertButton_Click(object sender, EventArgs e)
    {
        modo = 1;
        clearFields();
        enableFields(true);
        enableButtonsIME(false, false, false);
        enableButtonsAC(true);
    }

    //Fields methods

    protected void fillFields(FacturaVenta fv)
    {
        this.txtProvCust.Text = fvController.retornarNombreCliente(fv.CedulaCliente);
        this.hfCustomerName.Value = fv.CedulaCliente;
        this.txtInvoiceNumber.Text = fv.NumeroFactura;
        this.txtDate.Text = fv.Fecha.ToShortDateString();

        if (this.drpType.Items.FindByValue(fv.TipoFactura.ToString()) != null)
        {
            ListItem aux = this.drpType.Items.FindByValue(fv.TipoFactura.ToString());
            this.drpType.SelectedValue = aux.Value;
        }
        this.txtTerm.Text = fv.Plazo.ToString();
        this.txtExpiration.Text = fv.Vencimiento.ToShortDateString();
        this.txtMontoExempt.Text = utils.montoToString(fv.MontoExento);
        this.txtPorDescExempt.Text = utils.montoToString(fv.PorcentajeDescuentoExento);
        this.txtDesExempt.Text = utils.montoToString(fv.DescuentoExento);
        this.txtSubExempt.Text = utils.montoToString(fv.SubtotalExento);
        this.txtMontoTaxed.Text = utils.montoToString(fv.MontoGravado);
        this.txtPorDescTaxed.Text = utils.montoToString(fv.PorcentajeDescuentoGravado);
        this.txtDesTaxed.Text = utils.montoToString(fv.DescuentoGravado);
        this.txtSubTaxed.Text = utils.montoToString(fv.SubtotalGravado);
        this.txtIV.Text = utils.montoToString(fv.ImpuestoVenta);
        this.txtFlete.Text = utils.montoToString(fv.Flete);
        this.txtTotal.Text = utils.montoToString(fv.TotalFactura);
    }

    protected void clearFields()
    {
        this.txtProvCust.Text = "";
        this.txtInvoiceNumber.Text = "";
        this.txtDate.Text = "";
        this.drpType.SelectedIndex = 0;
        this.txtTerm.Text = "0";
        this.txtExpiration.Text = "";
        this.txtMontoExempt.Text = "0.00";
        this.txtPorDescExempt.Text = "0.00";
        this.txtDesExempt.Text = "0.00";
        this.txtSubExempt.Text = "0.00";
        this.txtMontoTaxed.Text = "0.00";
        this.txtPorDescTaxed.Text = "0.00";
        this.txtDesTaxed.Text = "0.00";
        this.txtSubTaxed.Text = "0.00";
        this.txtIV.Text = "0.00";
        this.txtFlete.Text = "0.00";
        this.txtTotal.Text = "0.00";
    }

    protected void enableFields(Boolean action)
    {
        if (action)
        {
            this.txtProvCust.Enabled = true;
            this.txtInvoiceNumber.Enabled = true;
            this.txtDate.Enabled = true;
            this.drpType.Enabled = true;
            this.txtTerm.Enabled = true;
            this.txtExpiration.Enabled = false;
            this.txtMontoExempt.Enabled = true;
            this.txtPorDescExempt.Enabled = false;
            this.txtDesExempt.Enabled = true;
            this.txtSubExempt.Enabled = true;
            this.txtMontoTaxed.Enabled = true;
            this.txtPorDescTaxed.Enabled = false;
            this.txtDesTaxed.Enabled = true;
            this.txtSubTaxed.Enabled = true;
            this.txtIV.Enabled = true;
            this.txtFlete.Enabled = true;
            this.txtTotal.Enabled = true;
        }
        else
        {
            this.txtProvCust.Enabled = false;
            this.txtInvoiceNumber.Enabled = false;
            this.txtDate.Enabled = false;
            this.drpType.Enabled = false;
            this.txtTerm.Enabled = false;
            this.txtExpiration.Enabled = false;
            this.txtMontoExempt.Enabled = false;
            this.txtPorDescExempt.Enabled = false;
            this.txtDesExempt.Enabled = false;
            this.txtSubExempt.Enabled = false;
            this.txtMontoTaxed.Enabled = false;
            this.txtPorDescTaxed.Enabled = false;
            this.txtDesTaxed.Enabled = false;
            this.txtSubTaxed.Enabled = false;
            this.txtIV.Enabled = false;
            this.txtFlete.Enabled = false;
            this.txtTotal.Enabled = false;
        }

    }

    protected void enableButtonsIME(Boolean insert, Boolean update, Boolean delete)
    {
        this.updateButton.Enabled = (update ? true : false);
        this.deleteButton.Enabled = (delete ? true : false);
        this.insertButton.Enabled = (insert ? true : false);
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

    protected void GridViewFacturaVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridViewFacturaVentas.PageIndex = e.NewPageIndex;
        if (modoPaging == 1)
        {
            fillGrid(fvController.consultarTodasFacturasVentas());
        }
        else
        {
            fillGrid(fvController.buscarFacturasVentas("145145145", this.txtSearch.Text.ToString()));
        }
        this.GridViewFacturaVentas.DataBind();
        this.GridViewFacturaVentas.HeaderRow.BackColor = System.Drawing.Color.FromArgb(13337903);
        this.GridViewFacturaVentas.HeaderRow.ForeColor = System.Drawing.Color.White;
    }
    protected void GridViewFacturaVentas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectFV":
                {
                    GridViewRow selectedRow = this.GridViewFacturaVentas.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentFV = fvController.consultarFacturaVenta(selectedRow.Cells[1].Text, fvController.retornarCedulaCliente(selectedRow.Cells[2].Text), "145145145");
                    clearFields();
                    enableFields(false);
                    enableButtonsAC(false);
                    enableButtonsIME(true, true, true);
                    fillFields(currentFV);
                } break;
        }
    }

    protected DataTable createHeaders()
    {
        DataTable dt = new DataTable();
        DataColumn column;

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Numero Factura";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Cliente";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "Fecha";
        dt.Columns.Add(column);

        return dt;
    }

    protected void fillDrpType() {
        this.drpType.Items.Clear();
        ListItem newItem = new ListItem();
        newItem.Text = "Factura Contado";
        newItem.Value = "0";
        drpType.Items.Add(newItem);
        newItem = new ListItem();
        newItem.Text = "Factura Credito";
        newItem.Value = "1";
        drpType.Items.Add(newItem);

    }

    protected void fillGrid(List<FacturaVenta> fvDt)
    {
        DataTable auxiliarHeaders = createHeaders();
        //List<FacturaVenta> fvDt = fvController.consultarTodasFacturasVentas();
        if (fvDt.Count > 0)
        {
            this.GridViewFacturaVentas.Columns[0].Visible = true;
            foreach (FacturaVenta factura in fvDt)
            {
                Object[] datos = new Object[3];
                datos[0] = factura.NumeroFactura;
                datos[1] = fvController.retornarNombreCliente(factura.CedulaCliente);
                datos[2] = factura.Fecha;
                auxiliarHeaders.Rows.Add(datos);
            }
        }
        else
        {
            this.GridViewFacturaVentas.Columns[0].Visible = false;
            Object[] datos = new Object[3];
            datos[0] = "-";
            datos[1] = "-";
            datos[2] = "-";
            auxiliarHeaders.Rows.Add(datos);
        }
        this.GridViewFacturaVentas.DataSource = auxiliarHeaders;
        this.GridViewFacturaVentas.DataBind();
        this.GridViewFacturaVentas.HeaderRow.BackColor = System.Drawing.Color.FromArgb(13337903);
        this.GridViewFacturaVentas.HeaderRow.ForeColor = System.Drawing.Color.White;
    }
    protected void btnYesDel_Click(object sender, EventArgs e)
    {
        String resultado = fvController.eliminarFacturaVenta(currentFV);
        if (String.Equals("Se eliminó correctamente la factura", resultado))
        {
            currentFV = new FacturaVenta(); //limpio
            clearFields();
            modoPaging = 1;
            fillGrid(fvController.consultarTodasFacturasVentas());
            utils.cerrarPopUp("popUpDeleteFacturaVenta");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Facturación Ventas", resultado);
        }
        else
        {
            utils.cerrarPopUp("popUpDeleteFacturaVenta");
            utils.abrirPopUpPersonalizado("popUpMensaje", "Facturación Ventas", resultado);
        }
    }
    protected void btnNoDel_Click(object sender, EventArgs e)
    {
        utils.cerrarPopUp("popUpDeleteFacturaVenta");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<FacturaVenta> fvList = fvController.buscarFacturasVentas("145145145", this.txtSearch.Text.ToString());
        modoPaging = 2;
        fillGrid(fvList);
    }
}
