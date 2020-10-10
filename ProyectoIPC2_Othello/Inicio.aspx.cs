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

            if (Session["login"] != "") {Response.Redirect("Login.aspx");}
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((Tablero[i,j] == 1)|(Tablero[i,j] == 2 )) { }
                        else Tablero[i, j] = 0;
                    }
                }


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