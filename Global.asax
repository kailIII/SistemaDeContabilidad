﻿<%@ Application Language="C#" %>
<%@ Import Namespace="SistemaDeContabilidad" %>
<%@ Import Namespace="System.Web.Optimization" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        AuthConfig.RegisterOpenAuth();
    }
    
    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session["Usuario"] = "";
        Session["Nombre"] = "";
        Session["CedulaContribuyente"] = "";
        Session["NombreContribuyente"] = "";
        Session["FechaProceso"] = "";
        Session["FechaDesde"] = "";
        Session["FechaHasta"] = "";
        Session["TipoReporte"] = "";
        Session["MontoCorte"] = "";
    }

    void Session_End(object sender, EventArgs e)
    {
        Session["Usuario"] = "";
        Session["Nombre"] = "";
        Session["CedulaContribuyente"] = "";
        Session["NombreContribuyente"] = "";
        Session["FechaProceso"] = "";
        Session["FechaDesde"] = "";
        Session["FechaHasta"] = "";
        Session["TipoReporte"] = "";
        Session["MontoCorte"] = "";
    }    

</script>
