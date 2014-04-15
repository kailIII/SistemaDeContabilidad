using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraFacturaCompra
/// </summary>
public class ControladoraFacturaCompra
{
    private ControladoraBDFacturaCompra controladoraFC;
    private ControladoraProveedor controladoraProveedor;
	public ControladoraFacturaCompra()
	{
        controladoraFC = new ControladoraBDFacturaCompra();
        controladoraProveedor = new ControladoraProveedor();
	}

    public String insertarFacturaCompra(Object[] datos)
    {
        String resultado = "";
        FacturaCompra fv = new FacturaCompra(datos);
        Boolean seInserto = controladoraFC.insertarFacturaCompra(fv);
        if (seInserto)
        {
            resultado = "Se insertó correctamente la factura";
        }
        else
        {
            resultado = "Ocurrió un error al insertar la factura";
        }
        return resultado;
    }

    public String modificarFacturaCompra(Object[] datosNuevos, FacturaCompra facturaVieja)
    {
        String resultado = "";
        FacturaCompra fvNueva = new FacturaCompra(datosNuevos);
        Boolean seModifico = controladoraFC.modificarFacturaCompra(fvNueva, facturaVieja);
        if (seModifico)
        {
            resultado = "Se modificó correctamente la factura";
        }
        else
        {
            resultado = "Ocurrió un error al modificar la factura";
        }
        return resultado;
    }

    public String eliminarFacturaCompra(FacturaCompra fv)
    {
        String resultado = "";
        Boolean seElimino = controladoraFC.eliminarFacturaCompra(fv);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente la factura";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar la factura";
        }
        return resultado;
    }

    public List<FacturaCompra> consultarTodasFacturasCompras()
    {
        return controladoraFC.consultarTodasFacturasCompras();
    }

    public FacturaCompra consultarFacturaCompra(String numeroFactura, String cedulaProveedor, String cedulaContribuyente)
    {
        return controladoraFC.consultarFacturaCompra(numeroFactura, cedulaProveedor, cedulaContribuyente);
    }

    public String retornarNombreProveedor(String cedulaProveedor)
    {
        return controladoraProveedor.retornarNombreProveedor(cedulaProveedor);
    }

    public String retornarCedulaProveedor(String nombreProveedor)
    {
        return controladoraProveedor.consultarCedulaProveedor(nombreProveedor);
    }

    public List<FacturaCompra> buscarFacturasCompras(String cedulaContribuyente, String aBuscar)
    {
        return controladoraFC.buscarFacturasCompras(cedulaContribuyente, aBuscar);
    }

}