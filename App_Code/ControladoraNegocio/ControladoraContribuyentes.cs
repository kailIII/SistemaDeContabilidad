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
	public ControladoraContribuyentes()
	{
        controladoraBDContribuyente = new ControladoraBDContribuyentes();
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

}