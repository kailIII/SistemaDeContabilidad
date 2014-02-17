using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Usuario
{
    private String _nombre;
    private String _apellidos;
    private String _cedula;
    private String _correo;
    private String _telefono;
    private String _contrasena;
    private String _direccion;

    public String Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public String Apellidos
    {
        get { return _apellidos; }
        set { _apellidos = value; }
    }

    public String Cedula
    {
        get { return _cedula; }
        set { _cedula = value; }
    }

    public String Correo
    {
        get { return _correo; }
        set { _correo = value; }
    }

    public String Telefono
    {
        get { return _telefono; }
        set { _telefono = value; }
    }

    public String Contrasena
    {
        get { return _contrasena; }
        set { _contrasena = value; }
    }

    public String Direccion
    {
        get { return _direccion; }
        set { _direccion = value; }
    }

	public Usuario()
	{

	}

    public Usuario(Object [] datos)
    {
        this._nombre = datos[0].ToString();
        this._apellidos = datos[1].ToString();
        this._cedula = datos[2].ToString();
        this._correo = datos[3].ToString();
        this._telefono = datos[4].ToString();
        this._contrasena = datos[5].ToString();
        this._direccion = datos[6].ToString();
    }
}