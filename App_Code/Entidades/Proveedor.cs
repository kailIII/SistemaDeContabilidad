using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Proveedor
/// </summary>
public class Proveedor
{
    private int _idProveedor;
    private String _nombreProveedor;
    private String _cedula;
    private String _direccion;
    private String _telefono;
    private String _fax;
    private String _correo;

    public int IdProveedor
    {
        get { return _idProveedor; }
        set { _idProveedor = value; }
    }


    public String NombreProveedor
    {
        get { return _nombreProveedor; }
        set { _nombreProveedor = value; }
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

    public Proveedor() { 
    
    }

    public Proveedor(Object[] datos)
	{
        this._idProveedor = Convert.ToInt32(datos[0].ToString());
        this._nombreProveedor = datos[1].ToString();
        this._cedula = datos[2].ToString();
        this._direccion = datos[3].ToString();
        this._telefono = datos[4].ToString();
        this._fax = datos[5].ToString();
        this._correo = datos[6].ToString();
	}
}