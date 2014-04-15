using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraCliente
/// </summary>
public class ControladoraCliente
{
    private ControladoraBDCliente controladoraBDCliente;
	public ControladoraCliente()
	{
        controladoraBDCliente = new ControladoraBDCliente();
	}

    public String insertarCliente(Object[] datos)
    {
        String resultado = "";
        Cliente cliente = new Cliente(datos);
        Boolean seInserto = controladoraBDCliente.insertarCliente(cliente);
        if (seInserto)
        {
            resultado = "Se insertó correctamente el cliente";
        }
        else
        {
            resultado = "Ocurrió un error al insertar el cliente";
        }
        return resultado;
    }

    public String modificarCliente(Object[] datosNuevos, Object[] datosViejos)
    {
        String resultado = "";
        Cliente clienteNuevo = new Cliente(datosNuevos);
        Cliente clienteViejo = new Cliente(datosViejos);
        Boolean seModifico = controladoraBDCliente.modificarCliente(clienteNuevo, clienteViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el cliente";
        }
        else
        {
            resultado = "Ocurrió un error al modificar el cliente";
        }
        return resultado;
    }

    public String modificarCliente(Object[] datosNuevos, Cliente clienteViejo)
    {
        String resultado = "";
        Cliente clienteNuevo = new Cliente(datosNuevos);
        Boolean seModifico = controladoraBDCliente.modificarCliente(clienteNuevo, clienteViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el cliente";
        }
        else
        {
            resultado = "Ocurrió un error al modificar el cliente";
        }
        return resultado;
    }

    public String eliminarCliente(Object[] datos)
    {
        String resultado = "";
        Cliente cliente = new Cliente(datos);
        Boolean seElimino = controladoraBDCliente.eliminarCliente(cliente);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el cliente";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el cliente";
        }
        return resultado;
    }

    public String eliminarCliente(Cliente cliente)
    {
        String resultado = "";
        Boolean seElimino = controladoraBDCliente.eliminarCliente(cliente);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el cliente";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el cliente";
        }
        return resultado;
    }

    public List<Cliente> consultarTodosClientes()
    {
        return controladoraBDCliente.consultarTodosClientes();
    }

    public Cliente consultarCliente(String cedula)
    {
        return controladoraBDCliente.consultarCliente(cedula);
    }

    public int getLastId(){
        int resultado =  controladoraBDCliente.getLastId();
        if (resultado == 1)
        {
            if (controladoraBDCliente.consultarTodosClientes().Count == 0)
            {
                resultado = 0;
            }
        }
        return resultado;
    }

    public String retornarNombreCliente(String cedulaCliente)
    {
        return controladoraBDCliente.retornarNombreCliente(cedulaCliente);
    }

    public String consultarCedulaCliente(String nombre)
    {
        return controladoraBDCliente.consultarCedulaCliente(nombre);
    }

    public List<Cliente> buscarClientes(String aBuscar)
    {
        return controladoraBDCliente.buscarClientes(aBuscar);
    }

}