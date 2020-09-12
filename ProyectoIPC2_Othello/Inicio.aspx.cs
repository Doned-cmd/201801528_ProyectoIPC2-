using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2_Othello
{
    public partial class Inicio : System.Web.UI.Page
    {
        static public int[,] Tablero = new int[8, 8];
        static public int contador = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] usuariocarg = (string[])Session["Usuario"];

            if (Session["login"] != "" ) { Response.Redirect("Login.aspx"); }
            else
            {
                Tablero[3, 3] = 2;
                Tablero[3, 4] = 1;
                Tablero[4, 3] = 1;
                Tablero[4, 4] = 2;
            }
        }

            protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}