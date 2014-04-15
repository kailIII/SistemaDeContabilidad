using DataSetClienteTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraBDCliente
/// </summary>
public class ControladoraBDCliente
{
    private ClienteTableAdapter _adapter;

	public ControladoraBDCliente()
	{
        _adapter = new ClienteTableAdapter();
	}

    public Boolean insertarCliente(Cliente cliente)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Insert(cliente.NombreCliente, cliente.Cedula, cliente.Direccion, cliente.Telefono, cliente.Fax, cliente.Correo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean modificarCliente(Cliente clienteNuevo, Cliente clienteViejo)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Update(clienteViejo.NombreCliente, clienteViejo.Direccion, clienteViejo.Telefono, clienteViejo.Fax, clienteViejo.Correo, clienteNuevo.IdCliente, clienteViejo.NombreCliente, clienteViejo.Cedula, clienteViejo.Direccion, clienteViejo.Telefono, clienteViejo.Fax, clienteViejo.Correo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean eliminarCliente(Cliente cliente) {
        Boolean resultado = false;
        try
        {
            _adapter.Delete(cliente.IdCliente, cliente.NombreCliente, cliente.Cedula, cliente.Direccion, cliente.Telefono, cliente.Fax, cliente.Correo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;    
    }

    public List<Cliente> consultarTodosClientes()
    {
        List<Cliente> resultado = new List<Cliente>();
        DataTable dtCliente = new DataTable();
        dtCliente = _adapter.GetData();
        foreach (DataRow fila in dtCliente.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            Cliente cliente = new Cliente(datos);
            resultado.Add(cliente);
        }

        return resultado;
    }

    public Cliente consultarCliente(String cedula)
    {
        DataTable dtCliente = new DataTable();
        dtCliente = _adapter.consultarCliente(cedula);
        Cliente cliente = new Cliente();
        foreach (DataRow fila in dtCliente.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            cliente = new Cliente(datos);
        }
        return cliente;
    }

    public String consultarCedulaCliente(String nombre)
    {
        DataTable dtCliente = new DataTable();
        dtCliente = _adapter.consultarCedula(nombre);
        Cliente cliente = new Cliente();
        foreach (DataRow fila in dtCliente.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            cliente = new Cliente(datos);
        }
        return cliente.Cedula;
    }

    public int getLastId() {
        int resultado;
        try { 
            resultado = (int)_adapter.lastID();
        }
        catch(Exception e){
            resultado = 0;
        }
        return resultado;
    }

    public String retornarNombreCliente(String cedulaCliente)
    {
        return this.consultarCliente(cedulaCliente).NombreCliente;
    }

    public List<Cliente> buscarClientes(String aBuscar)
    {
        List<Cliente> resultado = new List<Cliente>();
        String aux = "%" + aBuscar + "%";
        DataTable dtCliente = new DataTable();
        dtCliente = _adapter.buscarClientes(aux);
        foreach (DataRow fila in dtCliente.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            Cliente cliente = new Cliente(datos);
            resultado.Add(cliente);
        }

        return resultado;
    }


}