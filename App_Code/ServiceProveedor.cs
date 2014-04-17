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
    public string[] GetList(string prefix, string cedulaContribuyente)
    {
        
        List<string> proveedores = new List<string>();
        prefix = "%" + prefix + "%";
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = "Data Source=54.187.92.0;Initial Catalog=SistemaContabilidad;Persist Security Info=True;User ID=admin;Password=Conta#17";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select NombreProveedor, Cedula From Proveedor Where NombreProveedor LIKE @SearchText AND Exists (Select * From Proveedores_Contribuyente Where CedulaContribuyente = @cedulaContribuyente AND CedulaProveedor = Proveedor.Cedula)";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Parameters.AddWithValue("@cedulaContribuyente", cedulaContribuyente);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        proveedores.Add(string.Format("{0}-{1}", sdr["NombreProveedor"], sdr["Cedula"]));
                    }
                }
                conn.Close();
            }
            return proveedores.ToArray();
        }
    }
    
}
