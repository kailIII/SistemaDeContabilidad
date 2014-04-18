using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _ReporteAcumuladoVentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            ReportParameter[] parms = new ReportParameter[1];
            parms[0] = new ReportParameter("NombreContribuyente", Session["NombreContribuyente"].ToString());
            parms[0] = new ReportParameter("FechaDesde", Session["FechaDesde"].ToString());
            parms[0] = new ReportParameter("FechaHasta", Session["FechaHasta"].ToString());
            this.ReportViewer1.LocalReport.SetParameters(parms);
        }
    }


    
}