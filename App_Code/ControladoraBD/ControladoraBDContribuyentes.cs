using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataSetContribuyentesTableAdapters;
using System.Data;
using System.Data.SqlClient;

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
            Contribuyente contribuyente = new Contribuyente(datos);
            resultado.Add(contribuyente);
        }

        return resultado;
    }

    public Contribuyente consultarContribuyente(String id)
    {
        DataTable dtContribuyente = new DataTable();
        dtContribuyente = _adapter.consultarContribuyente(id);
        Contribuyente contribuyente = new Contribuyente();
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
            contribuyente = new Contribuyente(datos);
        }
        return contribuyente;
    }

    public Boolean insertarContribuyente(Contribuyente contribuyente)
    {
        Boolean resultado = false;
        try
        {
            _adapter.Insert(contribuyente.CedulaContribuyente, contribuyente.NombreContribuyente, contribuyente.NombreRepresentante, contribuyente.CedulaRepresentante, contribuyente.Provincia, contribuyente.Canton, contribuyente.Distrito, contribuyente.Direccion, contribuyente.Tipo, contribuyente.UltimoPeriodo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean modificarContribuyente(Contribuyente contribuyenteNuevo, Contribuyente contribuyenteViejo) {
        Boolean resultado = false;
        try
        {
            //_adapter.Update(contribuyenteOriginal.CedulaContribuyente, contribuyenteOriginal.NombreContribuyente, contribuyenteOriginal.NombreRepresentante, contribuyenteOriginal.CedulaRepresentante, contribuyenteOriginal.Provincia, contribuyenteOriginal.Canton, contribuyenteOriginal.Distrito, contribuyenteOriginal.Tipo, contribuyenteOriginal.UltimoPeriodo, contribuyenteViejo.IdContribuyente, contribuyenteViejo.CedulaContribuyente, contribuyenteViejo.NombreContribuyente, contribuyenteViejo.NombreRepresentante, contribuyenteViejo.CedulaRepresentante, contribuyenteViejo.Provincia, contribuyenteViejo.Canton, contribuyenteViejo.Distrito, contribuyenteViejo.Direccion, contribuyenteViejo.Tipo, contribuyenteViejo.UltimoPeriodo);
            _adapter.Update(contribuyenteNuevo.CedulaContribuyente, contribuyenteNuevo.NombreContribuyente, contribuyenteNuevo.NombreRepresentante, contribuyenteNuevo.CedulaRepresentante, contribuyenteNuevo.Provincia, contribuyenteNuevo.Canton, contribuyenteNuevo.Distrito, contribuyenteNuevo.Direccion, contribuyenteNuevo.Tipo, contribuyenteNuevo.UltimoPeriodo, contribuyenteViejo.IdContribuyente, contribuyenteViejo.CedulaContribuyente, contribuyenteViejo.NombreContribuyente, contribuyenteViejo.NombreRepresentante, contribuyenteViejo.CedulaRepresentante, contribuyenteViejo.Provincia, contribuyenteViejo.Canton, contribuyenteViejo.Distrito, contribuyenteViejo.Direccion, contribuyenteViejo.Tipo, contribuyenteViejo.UltimoPeriodo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;    
    }

    public Boolean eliminarContribuyente(Contribuyente contribuyente) {
        Boolean resultado = false;
        try
        {
            _adapter.Delete(contribuyente.IdContribuyente, contribuyente.CedulaContribuyente, contribuyente.NombreContribuyente, contribuyente.NombreRepresentante, contribuyente.CedulaRepresentante, contribuyente.Provincia, contribuyente.Canton, contribuyente.Distrito, contribuyente.Direccion, contribuyente.Tipo, contribuyente.UltimoPeriodo);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;     
    }

    public int getLastId()
    {
        int resultado;
        try
        {
            resultado = (int)_adapter.getLastId();
        }
        catch (Exception e)
        {
            resultado = 0;
        }
        return resultado;
    }

    public List<Contribuyente> buscarContribuyentes(String aBuscar)
    {
        List<Contribuyente> resultado = new List<Contribuyente>();
        String aux = "%" + aBuscar + "%";
        DataTable dtContribuyente = new DataTable();
        dtContribuyente = _adapter.buscarContribuyentes(aux);
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
            Contribuyente contribuyente = new Contribuyente(datos);
            resultado.Add(contribuyente);
        }

        return resultado;
    }

}