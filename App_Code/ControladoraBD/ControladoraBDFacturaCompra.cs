using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataSetFacturaCompraTableAdapters;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ControladoraBDFacturaCompra
/// </summary>
public class ControladoraBDFacturaCompra
{
    private FacturaCompraTableAdapter _adapter;

    public ControladoraBDFacturaCompra()
	{
        _adapter = new FacturaCompraTableAdapter();
	}

    public Boolean insertarFacturaCompra(FacturaCompra factura)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Insert(factura.NumeroFactura, factura.CedulaContribuyente, factura.CedulaProveedor, factura.Fecha, factura.TipoFactura, factura.Plazo, factura.Vencimiento, factura.MontoExento, factura.PorcentajeDescuentoExento, factura.DescuentoExento, factura.SubtotalExento, factura.MontoGravado, factura.PorcentajeDescuentoGravado, factura.DescuentoGravado, factura.SubtotalGravado, factura.ImpuestoVenta, factura.Flete, factura.TotalFactura);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean modificarFacturaCompra(FacturaCompra facturaNueva, FacturaCompra facturaVieja)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Update(facturaNueva.NumeroFactura, facturaNueva.CedulaContribuyente, facturaNueva.CedulaProveedor, facturaNueva.Fecha, facturaNueva.TipoFactura, facturaNueva.Plazo, facturaNueva.Vencimiento, facturaNueva.MontoExento, facturaNueva.PorcentajeDescuentoExento, facturaNueva.DescuentoExento, facturaNueva.SubtotalExento, facturaNueva.MontoGravado, facturaNueva.PorcentajeDescuentoGravado, facturaNueva.DescuentoGravado, facturaNueva.SubtotalGravado, facturaNueva.ImpuestoVenta, facturaNueva.Flete, facturaNueva.TotalFactura, facturaVieja.NumeroFactura, facturaVieja.CedulaContribuyente, facturaVieja.CedulaProveedor, facturaVieja.Fecha, facturaVieja.TipoFactura, facturaVieja.Plazo, facturaVieja.Vencimiento, facturaVieja.MontoExento, facturaVieja.PorcentajeDescuentoExento, facturaVieja.DescuentoExento, facturaVieja.SubtotalExento, facturaVieja.MontoGravado, facturaVieja.PorcentajeDescuentoGravado, facturaVieja.DescuentoGravado, facturaVieja.SubtotalGravado, facturaVieja.ImpuestoVenta, facturaVieja.Flete, facturaVieja.TotalFactura);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean eliminarFacturaCompra(FacturaCompra factura)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Delete(factura.NumeroFactura, factura.CedulaContribuyente, factura.CedulaProveedor, factura.Fecha, factura.TipoFactura, factura.Plazo, factura.Vencimiento, factura.MontoExento, factura.PorcentajeDescuentoExento, factura.DescuentoExento, factura.SubtotalExento, factura.MontoGravado, factura.PorcentajeDescuentoGravado, factura.DescuentoGravado, factura.SubtotalGravado, factura.ImpuestoVenta, factura.Flete, factura.TotalFactura);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public List<FacturaCompra> consultarTodasFacturasCompras()
    {
        List<FacturaCompra> resultado = new List<FacturaCompra>();
        DataTable dtFC = new DataTable();
        dtFC = _adapter.GetData();
        foreach (DataRow fila in dtFC.Rows)
        {
            Object[] datos = new Object[18];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            datos[7] = fila[7].ToString();
            datos[8] = fila[8].ToString();
            datos[9] = fila[9].ToString();
            datos[10] = fila[10].ToString();
            datos[11] = fila[11].ToString();
            datos[12] = fila[12].ToString();
            datos[13] = fila[13].ToString();
            datos[14] = fila[14].ToString();
            datos[15] = fila[15].ToString();
            datos[16] = fila[16].ToString();
            datos[17] = fila[17].ToString();
            FacturaCompra facturaCompra = new FacturaCompra(datos);
            resultado.Add(facturaCompra);
        }

        return resultado;
    }

    public FacturaCompra consultarFacturaCompra(String numeroFactura, String cedulaProveedor, String cedulaContribuyente)
    {
        DataTable dtFV = new DataTable();
        dtFV = _adapter.consultaFacturaCompra(numeroFactura, cedulaContribuyente, cedulaProveedor);
        FacturaCompra resultado = new FacturaCompra();
        foreach (DataRow fila in dtFV.Rows)
        {
            Object[] datos = new Object[18];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            datos[7] = fila[7].ToString();
            datos[8] = fila[8].ToString();
            datos[9] = fila[9].ToString();
            datos[10] = fila[10].ToString();
            datos[11] = fila[11].ToString();
            datos[12] = fila[12].ToString();
            datos[13] = fila[13].ToString();
            datos[14] = fila[14].ToString();
            datos[15] = fila[15].ToString();
            datos[16] = fila[16].ToString();
            datos[17] = fila[17].ToString();
            resultado = new FacturaCompra(datos);
        }

        return resultado;
    }


}