using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2_Othello
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
           
            string connectionString = @"Data Source=BRYANMENDEZ\SQLEXPRESS; Initial Catalog = ProyectoIPC2_othello; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string carga = "insert into USUARIO (correo,contraseña,nombre,apellido,nombreUsuario,fechaNacimiento,pais) values ('" + CorreoElec.Text + "','" + Contra.Text + "','" + Nombres.Text + "','" + Apellidos.Text + "','" + NombreUsuario.Text + "','" + FechaNac.Text + "','" + Pais.SelectedValue + "');";

                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(carga, sqlCon);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }
           
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

       
    }
}