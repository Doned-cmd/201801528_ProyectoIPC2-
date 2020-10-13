using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Diagnostics;

namespace ProyectoIPC2_Othello
{
    public partial class Login : System.Web.UI.Page
    {
        string[] usuarios = new string[15];
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=BRYANMENDEZ\SQLEXPRESS; Initial Catalog = ProyectoIPC2_othello; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                SqlCommand accion = new SqlCommand("select * from USUARIO where nombreUsuario ='" + Usuario.Text + "'", sqlCon);
                SqlDataReader buscar = accion.ExecuteReader();
                //if (buscar[0]!=null)
                //{
                    while (buscar.Read())
                    {
                        if (Contra.Text.Equals(buscar.GetValue(2).ToString()))
                        {
                            int contador = 0;
                            for (int i = 0; i < 8; i++) { 
                                usuarios[i] = buscar.GetValue(i).ToString();
                            contador++;
                            }


                        Session["TipoP"] = "";
                        Session["Usuario"] = usuarios;
                        Session["login"] = "";
                        LabelAlerta.Text = "Se ha iniciado sesion";
                        Response.Redirect("Inicio.aspx");
                            


                            
                            
                            //if (buscar.GetValue(2).ToString() == "1") { Response.Redirect("Vendedor.aspx"); }
                            //else if (buscar.GetValue(2).ToString() == "2") { Response.Redirect("Vendedor.aspx"); }
                            //else if (buscar.GetValue(2).ToString() == "3") { Response.Redirect("Vendedor.aspx"); }
                            //else if (buscar.GetValue(2).ToString() == "4") { Response.Redirect("Vendedor.aspx"); }
                    }
                        else
                        {
                            LabelAlerta.Text = "Error, contraseña erronea.";
                            Usuario.Text = "";
                            Contra.Text = "";
                        }
                    }
                //}
                //else
                //{
                //    LabelAlerta.Text = "Error,usuario erroneo.";
                //    Usuario.Text = "";
                //    Contra.Text = "";
                //}

            }
        }
        protected void Registro_Click(object sender, EventArgs e) 
        {
            Response.Redirect("Registro.aspx");
        }
    }
}