using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Contribuyente
/// </summary>
public class Contribuyente
{
    private int idContribuyente;
    private String cedulaContribuyente;
    private String nombreContribuyente;
    private String cedulaRepresentante;
    private String nombreRepresentante;
    private String provincia;
    private String canton;
    private String distrito;
    private String direccion;
    private int tipo;
    private String ultimoPeriodo;

    public String NombreContribuyente
    {
        get { return nombreContribuyente; }
        set { nombreContribuyente = value; }
    }
    

    public String CedulaRepresentante
    {
        get { return cedulaRepresentante; }
        set { cedulaRepresentante = value; }
    }
    

    public String NombreRepresentante
    {
        get { return nombreRepresentante; }
        set { nombreRepresentante = value; }
    }
    

    public String Provincia
    {
        get { return provincia; }
        set { provincia = value; }
    }
    

    public String Canton
    {
        get { return canton; }
        set { canton = value; }
    }
    

    public String Distrito
    {
        get { return distrito; }
        set { distrito = value; }
    }
    

    public String Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }
    

    public int Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }
    

    public String UltimoPeriodo
    {
        get { return ultimoPeriodo; }
        set { ultimoPeriodo = value; }
    }

    public int IdContribuyente
    {
        get { return idContribuyente; }
        set { idContribuyente = value; }
    }

    public String CedulaContribuyente
    {
        get { return cedulaContribuyente; }
        set { cedulaContribuyente = value; }
    }

	public Contribuyente()
	{

	}

    public Contribuyente(Object [] datos)
    {
        this.idContribuyente = Convert.ToInt32(datos[0].ToString());
        this.cedulaContribuyente = datos[1].ToString();
        this.nombreContribuyente = datos[2].ToString();
        this.cedulaRepresentante = datos[3].ToString();
        this.nombreRepresentante = datos[4].ToString();
        this.provincia = datos[5].ToString();
        this.canton = datos[6].ToString();
        this.distrito = datos[7].ToString();
        this.direccion = datos[8].ToString();
        this.tipo = Convert.ToInt32(datos[9].ToString());
        this.ultimoPeriodo = datos[10].ToString();
    }
}