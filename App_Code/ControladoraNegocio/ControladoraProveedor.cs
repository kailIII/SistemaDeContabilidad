﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraProveedor
/// </summary>
public class ControladoraProveedor
{
    ControladoraBDProveedor controladoraBDProveedor;
	public ControladoraProveedor()
	{
        controladoraBDProveedor = new ControladoraBDProveedor();
	}

    public String insertarProveedor(Object[] datos)
    {
        String resultado = "";
        Proveedor proveedor = new Proveedor(datos);
        Boolean seInserto = controladoraBDProveedor.insertarProveedor(proveedor);
        if (seInserto)
        {
            resultado = "Se insertó correctamente el proveedor";
        }
        else
        {
            resultado = "Ocurrió un error al insertar el proveedor";
        }
        return resultado;
    }

    public String modificarProveedor(Object[] datosNuevos, Object[] datosViejos)
    {
        String resultado = "";
        Proveedor proveedorNuevo = new Proveedor(datosNuevos);
        Proveedor proveedorViejo = new Proveedor(datosViejos);
        Boolean seModifico = controladoraBDProveedor.modificarProveedor(proveedorNuevo, proveedorViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el proveedor";
        }
        else
        {
            resultado = "Ocurrió un error al modificar el proveedor";
        }
        return resultado;
    }

    public String modificarProveedor(Object[] datosNuevos, Proveedor proveedorViejo)
    {
        String resultado = "";
        Proveedor proveedorNuevo = new Proveedor(datosNuevos);
        Boolean seModifico = controladoraBDProveedor.modificarProveedor(proveedorNuevo, proveedorViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el proveedor";
        }
        else
        {
            resultado = "Ocurrió un error al modificar el proveedor";
        }
        return resultado;
    }

    public String eliminarProveedor(Object[] datos)
    {
        String resultado = "";
        Proveedor proveedor = new Proveedor(datos);
        Boolean seElimino = controladoraBDProveedor.eliminarProveedor(proveedor);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el proveedor";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el proveedor";
        }
        return resultado;
    }

    public String eliminarProveedor(Proveedor proveedor)
    {
        String resultado = "";
        Boolean seElimino = controladoraBDProveedor.eliminarProveedor(proveedor);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el proveedor";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el proveedor";
        }
        return resultado;
    }

    public List<Proveedor> consultarTodosProveedores()
    {
        return controladoraBDProveedor.consultarTodosProveedores();
    }

    public Proveedor consultarProveedor(String cedula)
    {
        return controladoraBDProveedor.consultarProveedor(cedula);
    }

    public int getLastId()
    {
        int resultado = controladoraBDProveedor.getLastId();
        if (resultado == 1)
        {
            if (controladoraBDProveedor.consultarTodosProveedores().Count == 0)
            {
                resultado = 0;
            }
        }
        return resultado;
    }

}