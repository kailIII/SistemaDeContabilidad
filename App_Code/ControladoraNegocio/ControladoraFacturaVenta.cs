using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraFacturaVenta
/// </summary>
public class ControladoraFacturaVenta
{
    private ControladoraBDFacturaVenta controladoraFV;
    private ControladoraCliente controladoraCliente;
	public ControladoraFacturaVenta()
	{
        controladoraFV = new ControladoraBDFacturaVenta();
        controladoraCliente = new ControladoraCliente();
	}

    public String insertarFacturaVenta(Object[] datos)
    {
        String resultado = "";
        FacturaVenta fv = new FacturaVenta(datos);
        Boolean seInserto = controladoraFV.insertarFacturaVenta(fv);
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

    public String modificarFacturaVenta(Object[] datosNuevos, FacturaVenta facturaVieja)
    {
        String resultado = "";
        FacturaVenta fvNueva = new FacturaVenta(datosNuevos);
        Boolean seModifico = controladoraFV.modificarFacturaVenta(fvNueva, facturaVieja);
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

    public String eliminarFacturaVenta(FacturaVenta fv)
    {
        String resultado = "";
        Boolean seElimino = controladoraFV.eliminarFacturaVenta(fv);
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

    public List<FacturaVenta> consultarTodasFacturasVentas(String cedulaContribuyente)
    {
        return controladoraFV.consultarTodasFacturasVentas(cedulaContribuyente);
    }

    public FacturaVenta consultarFacturaVenta(String numeroFactura, String cedulaCliente, String cedulaContribuyente)
    {
        return controladoraFV.consultarFacturaVenta(numeroFactura, cedulaCliente, cedulaContribuyente);
    }

    public String retornarNombreCliente(String cedulaCliente) {
        return controladoraCliente.retornarNombreCliente(cedulaCliente);
    }

    public String retornarCedulaCliente(String nombreCliente)
    {
        return controladoraCliente.consultarCedulaCliente(nombreCliente);
    }

    public List<FacturaVenta> buscarFacturasVentas(String cedulaContribuyente, String aBuscar)
    {
        return controladoraFV.buscarFacturasVenta(cedulaContribuyente, aBuscar);
    }

    public int existenFacturas(String cedulaContribuyente, String cedulaCliente)
    {
        return controladoraFV.existenFacturas(cedulaContribuyente, cedulaCliente);
    }

}