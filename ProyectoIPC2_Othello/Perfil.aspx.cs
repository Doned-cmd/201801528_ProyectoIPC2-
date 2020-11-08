using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2_Othello
{
    public partial class Perfil : System.Web.UI.Page
    {
        string[] usuarios;
        static public int[,] Tablero = new int[8, 8];        
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] usuariocarg = (string[])Session["Usuario"];            
            if (Session["login"] != "") { Response.Redirect("Login.aspx"); }
            else
            {
                usuarios = (string[])Session["Usuario"];
                correoelectronico.Text = "Correo Electronico: "+usuarios[1].ToString();
                nombre.Text = "Nombre: " + usuarios[3].ToString() + " " + usuarios[4].ToString();
                username.Text = "Nombre de usuario: " + usuarios[5].ToString();
                fechanacimiento.Text = "Fecha de Nacimiento: " + usuarios[6].ToString();
                pais.Text = "Pais: " + usuarios[7].ToString();
                MostrarResultados(Int32.Parse(usuarios[0]));
            }
        }

        protected void MostrarResultados( int usuario)
        {

            int totalempatado=0;
            int totalperdido=0;
            int totalganado=0;
            string connectionString = @"Data Source=BRYANMENDEZ\SQLEXPRESS; Initial Catalog = ProyectoIPC2_othello; Integrated Security=True;";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                
                SqlCommand accion = new SqlCommand("SELECT count(idartida)  FROM PARTIDA  WHERE ( resultado = 'Perdio' and usuario = "+usuario+" )", sqlCon);
                SqlCommand accion2 = new SqlCommand("SELECT count(idartida) FROM PARTIDA  WHERE ( resultado = 'Gano' and usuario = " + usuario + " )", sqlCon);
                SqlCommand accion3 = new SqlCommand("SELECT count(idartida)  FROM PARTIDA  WHERE ( resultado = 'Empato' and usuario = " + usuario + " )", sqlCon);
                SqlCommand accion4 = new SqlCommand("SELECT count(idartida)  FROM PARTIDA  WHERE ( resultado = 'Empato' and usuario = " + usuario + " )", sqlCon);
                SqlDataReader buscar = accion.ExecuteReader();
                
                
                while (buscar.Read())
                { totalperdido = Int32.Parse(buscar.GetValue(0).ToString());  }
                buscar.Close();
                SqlDataReader buscar2 = accion2.ExecuteReader();
                while (buscar2.Read())
                { totalganado = Int32.Parse(buscar2.GetValue(0).ToString()); }
                buscar2.Close();
                SqlDataReader buscar3 = accion3.ExecuteReader();                
                while (buscar3.Read())
                { totalempatado = Int32.Parse(buscar3.GetValue(0).ToString()); }
                buscar3.Close();

                partidasEmpatadas.Text = "Partidas Empatadas: " +totalempatado.ToString();
                partidasGanadas.Text = "Partidas Ganadas: "+totalganado.ToString();
                partidasPerdidas.Text = "Partidas Perdidas: "+totalperdido.ToString();
                }
            }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode nodo = TreeView1.SelectedNode;
            string textoNodo = nodo.Text.ToString();

            if (textoNodo == "Nueva partida")
            {
                Tablero = new int[8, 8];
                Tablero[3, 3] = 1;
                Tablero[3, 4] = 2;
                Tablero[4, 3] = 2;
                Tablero[4, 4] = 1;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((Tablero[i, j] == 1) || (Tablero[i, j] == 2)) { }
                        else Tablero[i, j] = 0;
                    }
                }

                Inicio.Tablero = Tablero;
                Response.Redirect("Juego.aspx");
            }
            else if (textoNodo == "Jugar contra máquina")
            {
                Tablero = new int[8, 8];
                Tablero[3, 3] = 1;
                Tablero[3, 4] = 2;
                Tablero[4, 3] = 2;
                Tablero[4, 4] = 1;

                Session["TipoP"] = "M";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((Tablero[i, j] == 1) || (Tablero[i, j] == 2)) { }
                        else Tablero[i, j] = 0;
                    }
                }
                Inicio.Tablero = Tablero;
                Response.Redirect("JuegoContraMaquina.aspx");
            }
            else if (textoNodo == "Jugar contra jugador")
            {
                Tablero = new int[8, 8];

                Tablero[3, 3] = 1;
                Tablero[3, 4] = 2;
                Tablero[4, 3] = 2;
                Tablero[4, 4] = 1;

                Session["TipoP"] = "J";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((Tablero[i, j] == 1) || (Tablero[i, j] == 2)) { }
                        else Tablero[i, j] = 0;
                    }
                }
                Inicio.Tablero = Tablero;
                Response.Redirect("Juego.aspx");
            }
            else if (textoNodo == "Jugar Othelo Xtreme")
            {
                Response.Redirect("ConfigXtreme.aspx");
            }
            else if (textoNodo == "Perfil")
            {
                Response.Redirect("Perfil.aspx");
            }

        }
    }
}