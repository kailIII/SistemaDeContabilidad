using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataSetContribuyentesTableAdapters;
using System.Data;

/// <summary>
/// Descripción breve de ControladoraBDContribuyentes
/// </summary>
public class ControladoraBDContribuyentes
{
    private ContribuyenteTableAdapter _adapter;
	public ControladoraBDContribuyentes()
	{
        _adapter = new ContribuyenteTableAdapter();
	}

    public List<Contribuyente> consultarTodosContribuyentes()
    {
        List<Contribuyente> resultado = new List<Contribuyente>();
        DataTable dtContribuyente = new DataTable();
        dtContribuyente = _adapter.GetData();
        foreach (DataRow fila in dtContribuyente.Rows)
        {
            Object[] datos = new Object[11];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            datos[7] = fila[7].ToString();
            datos[8] = fila[8].ToString();
            datos[9] = fila[9].ToString();
            datos[10] = fila[10].ToString();
            Contribuyente cliente = new Contribuyente(datos);
            resultado.Add(cliente);
        }

        return resultado;
    }
}