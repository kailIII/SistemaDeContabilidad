using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraContribuyentes
/// </summary>
public class ControladoraContribuyentes
{
    private ControladoraBDContribuyentes controladoraBDContribuyente;
    private ControladoraCliente customerController;
    private ControladoraProveedor proveedorController;
    private ControladoraFacturaCompra fcController;
    private ControladoraFacturaVenta fvController;
	public ControladoraContribuyentes()
	{
        controladoraBDContribuyente = new ControladoraBDContribuyentes();
        customerController = new ControladoraCliente();
        proveedorController = new ControladoraProveedor();
        fcController = new ControladoraFacturaCompra();
        fvController = new ControladoraFacturaVenta();
	}

    public List<Contribuyente> consultarTodosContribuyentes()
    {
        return controladoraBDContribuyente.consultarTodosContribuyentes();
    }

    public String insertarContribuyente(Object[] datos)
    {
        String resultado = "";
        Contribuyente contribuyente = new Contribuyente(datos);
        Boolean seInserto = controladoraBDContribuyente.insertarContribuyente(contribuyente);
        if (seInserto)
        {
            resultado = "Se insertó correctamente el contribuyente";
        }
        else
        {
            resultado = "Ocurrió un error al insertar el contribuyente";
        }
        return resultado;
    }

    public String modificarContribuyente(Object[] datosNuevos, Contribuyente contribuyenteViejo)
    {
        String resultado = "";
        Contribuyente contribuyenteNuevo = new Contribuyente(datosNuevos);
        Boolean seModifico = controladoraBDContribuyente.modificarContribuyente(contribuyenteNuevo, contribuyenteViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el contribuyente";
        }
        else
        {
            resultado = "Ocurrió un error al modificar el contribuyente";
        }
        return resultado;
    }

    public String eliminarContribuyente(Contribuyente contribuyente)
    {
        String resultado = "";
        Boolean seElimino = controladoraBDContribuyente.eliminarContribuyente(contribuyente);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el contribuyente";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el contribuyente";
        }
        return resultado;
    }

    public Contribuyente consultarContribuyente(String id)
    {
        return controladoraBDContribuyente.consultarContribuyente(id);
    }

    public int getLastId()
    {
        int resultado = controladoraBDContribuyente.getLastId();
        if (resultado == 1)
        {
            if (controladoraBDContribuyente.consultarTodosContribuyentes().Count == 0)
            {
                resultado = 0;
            }
        }
        return resultado;
    }

    public List<Contribuyente> buscarContribuyentes(String aBuscar)
    {
        return controladoraBDContribuyente.buscarContribuyentes(aBuscar);
    }

    public List<Proveedor> consultarSeleccionarProveedores(String cedulaContribuyente)
    {
        return proveedorController.consultarSeleccionarProveedores(cedulaContribuyente);
    }

    public List<Proveedor> consultarProveedoresSeleccionados(String cedulaContribuyente)
    {
        return proveedorController.consultarProveedoresSeleccionados(cedulaContribuyente);
    }

    public List<Cliente> consultarSeleccionarClientes(String cedulaContribuyente)
    {
        return customerController.consultarSeleccionarClientes(cedulaContribuyente);
    }

    public List<Cliente> consultarClientesSeleccionados(String cedulaContribuyente)
    {
        return customerController.consultarClientesSeleccionados(cedulaContribuyente);
    }

    public int existenFacturasVentas(String cedulaContribuyente, String cedulaCliente) {
        return fvController.existenFacturas(cedulaContribuyente, cedulaCliente);
    }

    public int existenFacturasCompras(String cedulaContribuyente, String cedulaProveedor)
    {
        return fcController.existenFacturas(cedulaContribuyente, cedulaProveedor);
    }

    //IE Proveedores_Contribuyentes

    public Boolean insertarProveedorContribuyente(String cedulaContribuyente, String cedulaProveedor)
    {
        return controladoraBDContribuyente.insertarProveedorContribuyente(cedulaContribuyente, cedulaProveedor);
    }

    public Boolean eliminarProveedorContribuyente(String cedulaContribuyente, String cedulaProveedor)
    {
        Boolean resultado = false;
        if (fcController.existenFacturas(cedulaContribuyente, cedulaProveedor) == 0)
        {
            resultado = controladoraBDContribuyente.eliminarProveedorContribuyente(cedulaContribuyente, cedulaProveedor);
        }
        else {
            resultado = false;
        }
        return resultado;
    }

    //IE Clientes_Contribuyentes

    public Boolean insertarClienteContribuyente(String cedulaContribuyente, String cedulaCliente)
    {
        return controladoraBDContribuyente.insertarClienteContribuyente(cedulaContribuyente, cedulaCliente);
    }

    public Boolean eliminarClienteContribuyente(String cedulaContribuyente, String cedulaCliente)
    {
        Boolean resultado = false;
        if (fvController.existenFacturas(cedulaContribuyente, cedulaCliente) == 0)
        {
            resultado = controladoraBDContribuyente.eliminarClienteContribuyente(cedulaContribuyente, cedulaCliente);
        }
        else
        {
            resultado = false;
        }
        return resultado;
    }

}