using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacturaciónVentas : System.Web.UI.Page
{
    private CommonServices utils;
    private ControladoraFacturaVenta fvController = new ControladoraFacturaVenta();
    private static int modo = -1;
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
            fillGrid();
        }
    }
    protected void updateButton_Click(object sender, EventArgs e)
    {
        modo = 2;
        enableFields(true);
        enableButtonsIME(false, false, false);
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
        datos[2] = this.txtProvCust.Text;
        datos[3] = this.txtDate.Text;
        datos[4] = this.txtInvoiceType.Text;
        datos[5] = this.txtTerm.Text;
        datos[6] = this.txtExpiration.Text;
        datos[7] = this.txtMontoExempt.Text;
        datos[8] = this.txtPorDescExempt.Text;
        datos[9] = this.txtDesExempt.Text;
        datos[10] = this.txtSubExempt.Text;
        datos[11] = this.txtMontoTaxed.Text;
        datos[12] = this.txtPorDescTaxed.Text;
        datos[13] = this.txtDesTaxed.Text;
        datos[14] = this.txtSubTaxed.Text;
        datos[15] = this.txtIV.Text;
        datos[16] = this.txtFlete.Text;
        datos[17] = this.txtTotal.Text;
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
            fillGrid();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        clearFields();
        enableFields(false);
        enableButtonsIME(true, false, false); //Check it
        enableButtonsAC(false);
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
        this.txtProvCust.Text = fv.CedulaCliente;
        this.txtInvoiceNumber.Text = fv.NumeroFactura;
        this.txtDate.Text = fv.Fecha.ToString();
        this.txtInvoiceType.Text = fv.TipoFactura.ToString();
        this.txtTerm.Text = fv.Plazo.ToString();
        this.txtExpiration.Text = fv.Vencimiento.ToShortDateString();
        this.txtMontoExempt.Text = fv.MontoExento.ToString();
        this.txtPorDescExempt.Text = fv.PorcentajeDescuentoExento.ToString();
        this.txtDesExempt.Text = fv.DescuentoExento.ToString();
        this.txtSubExempt.Text = fv.SubtotalExento.ToString();
        this.txtMontoTaxed.Text = fv.MontoGravado.ToString();
        this.txtPorDescTaxed.Text = fv.PorcentajeDescuentoGravado.ToString();
        this.txtDesTaxed.Text = fv.DescuentoGravado.ToString();
        this.txtSubTaxed.Text = fv.SubtotalGravado.ToString();
        this.txtIV.Text = fv.ImpuestoVenta.ToString();
        this.txtFlete.Text = fv.Flete.ToString();
        this.txtTotal.Text = fv.TotalFactura.ToString();
    }

    protected void clearFields()
    {
        this.txtProvCust.Text = "";
        this.txtInvoiceNumber.Text = "";
        this.txtDate.Text = "";
        this.txtInvoiceType.Text = "";
        this.txtTerm.Text = "";
        this.txtExpiration.Text = "";
        this.txtMontoExempt.Text = "";
        this.txtPorDescExempt.Text = "";
        this.txtDesExempt.Text = "";
        this.txtSubExempt.Text = "";
        this.txtMontoTaxed.Text = "";
        this.txtPorDescTaxed.Text = "";
        this.txtDesTaxed.Text = "";
        this.txtSubTaxed.Text = "";
        this.txtIV.Text = "";
        this.txtFlete.Text = "";
        this.txtTotal.Text = "";
    }

    protected void enableFields(Boolean action)
    {
        if (action)
        {
            this.txtProvCust.Enabled = true;
            this.txtInvoiceNumber.Enabled = true;
            this.txtDate.Enabled = true;
            this.txtInvoiceType.Enabled = true;
            this.txtTerm.Enabled = true;
            this.txtExpiration.Enabled = true;
            this.txtMontoExempt.Enabled = true;
            this.txtPorDescExempt.Enabled = true;
            this.txtDesExempt.Enabled = true;
            this.txtSubExempt.Enabled = true;
            this.txtMontoTaxed.Enabled = true;
            this.txtPorDescTaxed.Enabled = true;
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
            this.txtInvoiceType.Enabled = false;
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

    }
    protected void GridViewFacturaVentas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "selectFV":
                {
                    GridViewRow selectedRow = this.GridViewFacturaVentas.Rows[Convert.ToInt32(e.CommandArgument)];
                    currentFV = fvController.consultarFacturaVenta(selectedRow.Cells[1].Text, selectedRow.Cells[2].Text, "145145145");
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

    protected void fillGrid()
    {
        DataTable auxiliarHeaders = createHeaders();
        List<FacturaVenta> fvDt = fvController.consultarTodasFacturasVentas();
        if (fvDt.Count > 0)
        {
            this.GridViewFacturaVentas.Columns[0].Visible = true;
            foreach (FacturaVenta factura in fvDt)
            {
                Object[] datos = new Object[3];
                datos[0] = factura.NumeroFactura;
                datos[1] = factura.CedulaCliente;
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
            fillGrid();
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
}
