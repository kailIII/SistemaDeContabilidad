using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ControladoraUsuario
/// </summary>
public class ControladoraUsuario
{
    private ControladoraBDUsuario controladoraBDUsuario;
	public ControladoraUsuario()
	{
        controladoraBDUsuario = new ControladoraBDUsuario();
	}

    public String insertarUsuario(Object [] datos) {
        String resultado = "";
        Usuario usuario = new Usuario(datos);
        Boolean seInserto = controladoraBDUsuario.insertarUsuario(usuario);
        if (seInserto)
        {
            resultado = "Se insertó correctamente el usuario";
        }
        else {
            resultado = "Ocurrió un error al insertar el usuario";
        }
        return resultado;
    }

    public String modificarUsuario(Object [] datosNuevos, Object [] datosViejos) {
        String resultado = "";
        Usuario usuarioNuevo = new Usuario(datosNuevos);
        Usuario usuarioViejo = new Usuario(datosViejos);
        Boolean seModifico = controladoraBDUsuario.modificarUsuario(usuarioNuevo, usuarioViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el usuario";
        }
        else {
            resultado = "Ocurrió un error al modificar el usuario";
        }
        return resultado;
    }

    public String modificarUsuario(Object[] datosNuevos, Usuario usuarioViejo)
    {
        String resultado = "";
        Usuario usuarioNuevo = new Usuario(datosNuevos);
        Boolean seModifico = controladoraBDUsuario.modificarUsuario(usuarioNuevo, usuarioViejo);
        if (seModifico)
        {
            resultado = "Se modificó correctamente el usuario";
        }
        else
        {
            resultado = "Ocurrió un error al modificar el usuario";
        }
        return resultado;
    }

    public String eliminarUsuario(Object[] datos)
    {
        String resultado = "";
        Usuario usuario = new Usuario(datos);
        Boolean seElimino = controladoraBDUsuario.eliminarUsuario(usuario);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el usuario";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el usuario";
        }
        return resultado;
    }

    public String eliminarUsuario(Usuario usuario)
    {
        String resultado = "";
        Boolean seElimino = controladoraBDUsuario.eliminarUsuario(usuario);
        if (seElimino)
        {
            resultado = "Se eliminó correctamente el usuario";
        }
        else
        {
            resultado = "Ocurrió un error al eliminar el usuario";
        }
        return resultado;
    }

    public List<Usuario> consultarTodosUsuarios() {
        return controladoraBDUsuario.consultarTodosUsuarios();
    }

    public Usuario consultarUsuario(String cedula) {
        return controladoraBDUsuario.consultarUsuario(cedula);
    }

    public Boolean existeUsuario(String correo, String password) {
        return controladoraBDUsuario.existeUsuario(correo, password);
    }
}