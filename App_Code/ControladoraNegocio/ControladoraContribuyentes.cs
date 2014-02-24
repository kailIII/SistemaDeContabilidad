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
}