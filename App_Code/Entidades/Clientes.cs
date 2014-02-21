using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Clientes
/// </summary>
public class Clientes
{
    private int _idCliente;
    private String _nombreCliente;
    private String _cedula;
    private String _direccion;
    private String _telefono;
    private String _fax;
    private String _correo;

    public int IdCliente
    {
        get { return _idCliente; }
        set { _idCliente = value; }
    }
    

    public String NombreCliente
    {
        get { return _nombreCliente; }
        set { _nombreCliente = value; }
    }
    

    public String Cedula
    {
        get { return _cedula; }
        set { _cedula = value; }
    }
    

    public String Direccion
    {
        get { return _direccion; }
        set { _direccion = value; }
    }
    

    public String Telefono
    {
        get { return _telefono; }
        set { _telefono = value; }
    }
    

    public String Fax
    {
        get { return _fax; }
        set { _fax = value; }
    }
    

    public String Correo
    {
        get { return _correo; }
        set { _correo = value; }
    }

    public Clientes() { 
    
    }

	public Clientes(Object [] datos)
	{
        this._idCliente = Convert.ToInt32(datos[0].ToString());
        this._nombreCliente = datos[1].ToString();
        this._cedula = datos[2].ToString();
        this._direccion = datos[3].ToString();
        this._telefono = datos[4].ToString();
        this._fax = datos[5].ToString();
        this._correo = datos[6].ToString();
	}


}