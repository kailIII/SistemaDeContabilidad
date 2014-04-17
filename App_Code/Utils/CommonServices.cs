using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

public class CommonServices
{
    public int headerColor = 3489871;

    private UpdatePanel panel;

	public CommonServices(UpdatePanel panel)
	{
        this.panel = panel;
	}

    public void correrJavascript(String funcion)
    {
        Guid gMessage = Guid.NewGuid();
        string sMessage = funcion;

        ScriptManager.RegisterStartupScript(panel, panel.GetType(), gMessage.ToString(), sMessage, true);
    }

    public void mensajeJavascript(String mensaje, String titulo)
    {
        correrJavascript("$('#popUpMensaje').text('"+ mensaje +"');");
        correrJavascript("$('#popUpMensaje').dialog({ title: '"+ titulo +"' });");
        correrJavascript("$('#popUpMensaje').dialog('open');");
    }

    public void abrirPopUp(String popUpId, String titulo)
    {
        correrJavascript("abrirPopUp('" + popUpId + "', '" + titulo + "');");
    }


    public void abrirPopUpPersonalizado(String popUpId, String titulo,String mensaje)
    {
       correrJavascript("abrirPopUpPersonalizado('" + popUpId + "', '" + titulo + "','" + mensaje + "');");
    }

    public void cerrarPopUp(String popUpId)
    {
        correrJavascript("cerrarPopUp('" + popUpId + "');");
    }

    public String procesarStringDeUI(String linea)
    {
        return HttpUtility.HtmlDecode(linea).Trim();
    }

    public void esconderPrimerBotonDePopUp(String popUpId)
    {
        this.correrJavascript("$('#"+ popUpId +"').next().find('.ui-dialog-buttonset button:first').hide();");
    }

    public void mostrarPrimerBotonDePopUp(String popUpId)
    {
        this.correrJavascript("$('#" + popUpId + "').next().find('.ui-dialog-buttonset button:first').show();");
    }

    public void mensajeEspera(String mensaje, String titulo)
    {
        correrJavascript("$('#mensajePopUpEspera').text('" + mensaje + "');");
        correrJavascript("$('#popUpEspera').dialog({title: '" + titulo + "' });");
        correrJavascript("$('#popUpEspera').dialog('open');");
    }

    public void cerrarMensajeEspera()
    {
        correrJavascript("$('#popUpEspera').dialog('close');");
    }


    public int getAñoActual()
    {

        DateTime fecha = DateTime.Now;
        int año  = fecha.Year;
        return año;
    }

    public String montoToString(float number)
    {
        String resultado = "";
        String prueba = number.ToString();
        CultureInfo culture = new CultureInfo("en-US");
        resultado = String.Format(culture, "{0:N}", number);
        return resultado;
    }

    //Beto

    public String stringToDouble(String monto) {
        String resultado = "";
        resultado = monto.Replace(",",String.Empty);
        resultado = resultado.Replace(".", ",");
        return resultado;
    }
}