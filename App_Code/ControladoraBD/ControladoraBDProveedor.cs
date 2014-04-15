using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataSetProveedorTableAdapters;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ControladoraBDProveedor
/// </summary>
public class ControladoraBDProveedor
{
    private ProveedorTableAdapter _adapter;
	public ControladoraBDProveedor()
	{
        _adapter = new ProveedorTableAdapter();
	}

    public Boolean insertarProveedor(Proveedor proveedor)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Insert(proveedor.NombreProveedor, proveedor.Cedula, proveedor.Direccion, proveedor.Telefono, proveedor.Fax, proveedor.Correo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean modificarProveedor(Proveedor proveedorNuevo, Proveedor proveedorViejo)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Update(proveedorViejo.NombreProveedor, proveedorViejo.Direccion, proveedorViejo.Telefono, proveedorViejo.Fax, proveedorViejo.Correo, proveedorNuevo.IdProveedor, proveedorViejo.NombreProveedor, proveedorViejo.Cedula, proveedorViejo.Direccion, proveedorViejo.Telefono, proveedorViejo.Fax, proveedorViejo.Correo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean eliminarProveedor(Proveedor proveedor)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Delete(proveedor.IdProveedor, proveedor.NombreProveedor, proveedor.Cedula, proveedor.Direccion, proveedor.Telefono, proveedor.Fax, proveedor.Correo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public List<Proveedor> consultarTodosProveedores()
    {
        List<Proveedor> resultado = new List<Proveedor>();
        DataTable dtProveedor = new DataTable();
        dtProveedor = _adapter.GetData();
        foreach (DataRow fila in dtProveedor.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            Proveedor proveedor = new Proveedor(datos);
            resultado.Add(proveedor);
        }

        return resultado;
    }

    public Proveedor consultarProveedor(String cedula)
    {
        DataTable dtProveedor = new DataTable();
        dtProveedor = _adapter.consultarProveedor(cedula);
        Proveedor proveedor = new Proveedor();
        foreach (DataRow fila in dtProveedor.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            proveedor = new Proveedor(datos);
        }
        return proveedor;
    }

    public String consultarCedulaProveedor(String nombre)
    {
        DataTable dtProveedor = new DataTable();
        dtProveedor = _adapter.consultarCedula(nombre);
        Proveedor proveedor = new Proveedor();
        foreach (DataRow fila in dtProveedor.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            proveedor = new Proveedor(datos);
        }
        return proveedor.Cedula;
    }

    public int getLastId()
    {
        int resultado;
        try
        {
            resultado = (int)_adapter.lastID();
        }
        catch (Exception e)
        {
            resultado = 0;
        }
        return resultado;
    }

    public String retornarNombreProveedor(String cedulaProveedor)
    {
        return this.consultarProveedor(cedulaProveedor).NombreProveedor;
    }

    public List<Proveedor> buscarProveedores(String aBuscar)
    {
        List<Proveedor> resultado = new List<Proveedor>();
        String aux = "%" + aBuscar + "%";
        DataTable dtProveedor = new DataTable();
        dtProveedor = _adapter.buscarProveedores(aux);
        foreach (DataRow fila in dtProveedor.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            Proveedor proveedor = new Proveedor(datos);
            resultado.Add(proveedor);
        }

        return resultado;
    }

}