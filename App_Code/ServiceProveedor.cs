using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Descripción breve de ServiceProveedor
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
 [System.Web.Script.Services.ScriptService]
public class ServiceProveedor : System.Web.Services.WebService {

    public ServiceProveedor () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetList(string prefix)
    {
        
        List<string> proveedores = new List<string>();
        prefix = "%" + prefix + "%";
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["SistemaContabilidadConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select NombreProveedor, CedulaProveedor from Proveedores_Contribuyente where " +
                "NombreProveedor like @SearchText";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        proveedores.Add(string.Format("{0}-{1}", sdr["NombreProveedor"], sdr["CedulaProveedor"]));
                    }
                }
                conn.Close();
            }
            return proveedores.ToArray();
        }
    }
    
}
