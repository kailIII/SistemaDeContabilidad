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
        Clientes cliente = new Clientes(datos);
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
        Clientes clienteNuevo = new Clientes(datosNuevos);
        Clientes clienteViejo = new Clientes(datosViejos);
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

    public String modificarCliente(Object[] datosNuevos, Clientes clienteViejo)
    {
        String resultado = "";
        Clientes clienteNuevo = new Clientes(datosNuevos);
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
        Clientes cliente = new Clientes(datos);
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

    public String eliminarCliente(Clientes cliente)
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

    public List<Clientes> consultarTodosClientes()
    {
        return controladoraBDCliente.consultarTodosClientes();
    }

    public Clientes consultarCliente(String cedula)
    {
        return controladoraBDCliente.consultarCliente(cedula);
    }

}