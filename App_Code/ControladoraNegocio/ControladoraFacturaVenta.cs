using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraFacturaVenta
/// </summary>
public class ControladoraFacturaVenta
{
    private ControladoraBDFacturaVenta controladoraFV;
	public ControladoraFacturaVenta()
	{
        controladoraFV = new ControladoraBDFacturaVenta();
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

    public List<FacturaVenta> consultarTodasFacturasVentas()
    {
        return controladoraFV.consultarTodasFacturasVentas();
    }

    public FacturaVenta consultarFacturaVenta(String numeroFactura, String cedulaCliente, String cedulaContribuyente)
    {
        return controladoraFV.consultarFacturaVenta(numeroFactura, cedulaCliente, cedulaContribuyente);
    }

}