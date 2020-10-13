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
        static public int contador = 2;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] usuariocarg = (string[])Session["Usuario"];
            contador = 2;            
            if (Session["login"] != "") {Response.Redirect("Login.aspx");}
            else
            {
                Tablero = new int[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((Tablero[i, j] == 1) || (Tablero[i, j] == 2)) { }
                        else Tablero[i, j] = 0;
                    }
                }
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode nodo = TreeView1.SelectedNode;
            string textoNodo = nodo.Text.ToString();
            
            if (textoNodo == "Nueva partida") {
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


                Response.Redirect("Juego.aspx");
            }

        }
    }
}