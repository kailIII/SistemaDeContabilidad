using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataSetUsuarioTableAdapters;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ControladoraBDUsuario
/// </summary>
public class ControladoraBDUsuario
{
    private UsuarioTableAdapter adapter;
	public ControladoraBDUsuario()
	{
        adapter = new UsuarioTableAdapter();
	}

    public Boolean insertarUsuario(Usuario usuario) {
        Boolean resultado = false;
        try {
            adapter.Insert(usuario.Nombre, usuario.Apellidos, usuario.Cedula, usuario.Correo, usuario.Telefono, usuario.Contrasena, usuario.Direccion);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean modificarUsuario(Usuario usuarioNuevo, Usuario usuarioViejo)
    {
        Boolean resultado = false;
        try
        {
            adapter.Update(usuarioNuevo.Nombre, usuarioNuevo.Apellidos, usuarioNuevo.Cedula, usuarioNuevo.Correo, usuarioNuevo.Telefono, usuarioNuevo.Contrasena, usuarioNuevo.Direccion, usuarioViejo.Nombre, usuarioViejo.Apellidos, usuarioViejo.Cedula, usuarioViejo.Correo, usuarioViejo.Telefono, usuarioViejo.Contrasena, usuarioViejo.Direccion);
            resultado = true;
        }
        catch (SqlException e)
        {
            resultado = false;
        }
        return resultado;
    }

    public Boolean eliminarUsuario(Usuario usuario) {
        Boolean resultado = false;
        try {
            adapter.Delete(usuario.Nombre, usuario.Apellidos, usuario.Cedula, usuario.Correo, usuario.Telefono, usuario.Contrasena, usuario.Direccion);
            resultado = true;
        }
        catch(SqlException e){
            resultado = false;
        }

        return resultado;
    }

    public List<Usuario> consultarTodosUsuarios() {
        List<Usuario> resultado = new List<Usuario>();
        DataTable dtUsuario = new DataTable();
        dtUsuario = adapter.GetData();
        foreach (DataRow fila in dtUsuario.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            Usuario usuario = new Usuario(datos);
            resultado.Add(usuario);
        }

        return resultado;
    }

    public Boolean existeUsuario(String correo, String password) {
        Boolean resultado = false;
        int index = (int)adapter.existeUsuario(correo, password);
        if(index>0){
            resultado = true;
        }
        return resultado;
    }

    public Usuario consultarUsuario(String cedula) {
        DataTable dtUsuario = new DataTable();
        dtUsuario = adapter.consultarUsuario(cedula);
        Usuario usuario = new Usuario();
        foreach (DataRow fila in dtUsuario.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            usuario = new Usuario(datos);
        }
        return usuario;
    }

    public List<Usuario> buscarUsuarios(String aBuscar)
    {
        List<Usuario> resultado = new List<Usuario>();
        String aux = "%" + aBuscar + "%";
        DataTable dtUsuario = new DataTable();
        dtUsuario = adapter.buscarUsuarios(aux);
        foreach (DataRow fila in dtUsuario.Rows)
        {
            Object[] datos = new Object[7];
            datos[0] = fila[0].ToString();
            datos[1] = fila[1].ToString();
            datos[2] = fila[2].ToString();
            datos[3] = fila[3].ToString();
            datos[4] = fila[4].ToString();
            datos[5] = fila[5].ToString();
            datos[6] = fila[6].ToString();
            Usuario usuario = new Usuario(datos);
            resultado.Add(usuario);
        }

        return resultado;
    }


}