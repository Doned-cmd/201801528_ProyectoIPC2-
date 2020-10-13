using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace ProyectoIPC2_Othello
{
    public partial class Juego : System.Web.UI.Page
    {


        //Tablero
        public int[,] Tablero;

        //Guardar xml
        static int xmlcounter = 0;

        //Guardar los datos del usuario
        string[] usuarios;

        //Turnos
        static public bool Nohayjugadasposibles = false;
        private bool NohayturnoLocal = false, NohayturnoInv = false;
        static public int TurnoJugador;
        private static int primermovimiento;

        //Puntuacion
        static int puntajejugador1, puntajejugador2, casillasrestantes;
        static string ganador;

        //Turnos random
        private static Random random = new Random();

        //Iniciar las variables una sola vez
        public static bool keyonce = true;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != "") { Response.Redirect("Login.aspx"); }
            else
            {
                usuarios = (string[])Session["Usuario"];



                if (keyonce)
                {
                    primermovimiento = random.Next(1, 3);
                    TurnoJugador = Inicio.contador;
                    //primermovimiento = 2;
                    //if (primermovimiento == 2) {
                    //    if (Maquina()) { TurnoJugador = 1; }                        
                    //}
                    //else { }

                    Tablero = Inicio.Tablero;
                    keyonce = false;
                }


                if (primermovimiento == 1)
                {
                    if (TurnoJugador == 1) { TurnoActual.Text = "Turno de la maquina, porfavor de click para que realize su movimiento"; }
                    else if (TurnoJugador == 2) { TurnoActual.Text = "Turno del jugador: " + usuarios[5].ToString(); }
                }
                else if (primermovimiento == 2)
                {
                    if (TurnoJugador == 2) { TurnoActual.Text = "Turno de la maquina, porfavor de click para que realize su movimiento"; }
                    else if (TurnoJugador == 1) { TurnoActual.Text = "Turno del jugador: " + usuarios[5].ToString(); }
                }


                Cambiarcolor();
            }
        }

        public void Cambiarcolor() {
            if (Tablero[0, 0] == 0) { F1_C1.BackColor = Color.Transparent; }
            else if (Tablero[0, 0] == 1) { F1_C1.BackColor = Color.LightGray; }
            else if (Tablero[0, 0] == 2) { F1_C1.BackColor = Color.Black; }

            if (Tablero[0, 1] == 0) { F1_C2.BackColor = Color.Transparent; }
            else if (Tablero[0, 1] == 1) { F1_C2.BackColor = Color.LightGray; }
            else if (Tablero[0, 1] == 2) { F1_C2.BackColor = Color.Black; }
            
            if (Tablero[0, 2] == 0) { F1_C3.BackColor = Color.Transparent; }
            else if (Tablero[0, 2] == 1) { F1_C3.BackColor = Color.LightGray; }
            else if (Tablero[0, 2] == 2) { F1_C3.BackColor = Color.Black; }

            if (Tablero[0, 3] == 0) { F1_C4.BackColor = Color.Transparent; }
            else if (Tablero[0, 3] == 1) { F1_C4.BackColor = Color.LightGray; }
            else if (Tablero[0, 3] == 2) { F1_C4.BackColor = Color.Black; }

            if (Tablero[0, 4] == 0) { F1_C5.BackColor = Color.Transparent; }
            else if (Tablero[0, 4] == 1) { F1_C5.BackColor = Color.LightGray; }
            else if (Tablero[0,4] == 2) { F1_C5.BackColor = Color.Black; }

            if (Tablero[0, 5] == 0) { F1_C6.BackColor = Color.Transparent; }
            else if (Tablero[0, 5] == 1) { F1_C6.BackColor = Color.LightGray; }
            else if (Tablero[0, 5] == 2) { F1_C6.BackColor = Color.Black; }

            if (Tablero[0, 6] == 0) { F1_C7.BackColor = Color.Transparent; }
            else if (Tablero[0, 6] == 1) { F1_C7.BackColor = Color.LightGray; }
            else if (Tablero[0, 6] == 2) { F1_C7.BackColor = Color.Black; }

            if (Tablero[0, 7] == 0) { F1_C8.BackColor = Color.Transparent; }
            else if (Tablero[0, 7] == 1) { F1_C8.BackColor = Color.LightGray; }
            else if (Tablero[0, 7] == 2) { F1_C8.BackColor = Color.Black; }
//-------------------------------------------------------------------------
            if (Tablero[1, 0] == 0) { F2_C1.BackColor = Color.Transparent; }
            else if (Tablero[1, 0] == 1) { F2_C1.BackColor = Color.LightGray; }
            else if (Tablero[1, 0] == 2) { F2_C1.BackColor = Color.Black; }

            if (Tablero[1, 1] == 0) { F2_C2.BackColor = Color.Transparent; }
            else if (Tablero[1, 1] == 1) { F2_C2.BackColor = Color.LightGray; }
            else if (Tablero[1, 1] == 2) { F2_C2.BackColor = Color.Black; }

            if (Tablero[1, 2] == 0) { F2_C3.BackColor = Color.Transparent; }
            else if (Tablero[1, 2] == 1) { F2_C3.BackColor = Color.LightGray; }
            else if (Tablero[1, 2] == 2) { F2_C3.BackColor = Color.Black; }

            if (Tablero[1, 3] == 0) { F2_C4.BackColor = Color.Transparent; }
            else if (Tablero[1, 3] == 1) { F2_C4.BackColor = Color.LightGray; }
            else if (Tablero[1, 3] == 2) { F2_C4.BackColor = Color.Black; }

            if (Tablero[1, 4] == 0) { F2_C5.BackColor = Color.Transparent; }
            else if (Tablero[1, 4] == 1) { F2_C5.BackColor = Color.LightGray; }
            else if (Tablero[1, 4] == 2) { F2_C5.BackColor = Color.Black; }

            if (Tablero[1, 5] == 0) { F2_C6.BackColor = Color.Transparent; }
            else if (Tablero[1, 5] == 1) { F2_C6.BackColor = Color.LightGray; }
            else if (Tablero[1, 5] == 2) { F2_C6.BackColor = Color.Black; }

            if (Tablero[1, 6] == 0) { F2_C7.BackColor = Color.Transparent; }
            else if (Tablero[1, 6] == 1) { F2_C7.BackColor = Color.LightGray; }
            else if (Tablero[1, 6] == 2) { F2_C7.BackColor = Color.Black; }

            if (Tablero[1, 7] == 0) { F2_C8.BackColor = Color.Transparent; }
            else if (Tablero[1, 7] == 1) { F2_C8.BackColor = Color.LightGray; }
            else if (Tablero[1, 7] == 2) { F2_C8.BackColor = Color.Black; }
//------------------------------------------------------------
            if (Tablero[2, 0] == 0) { F3_C1.BackColor = Color.Transparent; }
            else if (Tablero[2, 0] == 1) { F3_C1.BackColor = Color.LightGray; }
            else if (Tablero[2, 0] == 2) { F3_C1.BackColor = Color.Black; }

            if (Tablero[2, 1] == 0) { F3_C2.BackColor = Color.Transparent; }
            else if (Tablero[2, 1] == 1) { F3_C2.BackColor = Color.LightGray; }
            else if (Tablero[2, 1] == 2) { F3_C2.BackColor = Color.Black; }

            if (Tablero[2, 2] == 0) { F3_C3.BackColor = Color.Transparent; }
            else if (Tablero[2, 2] == 1) { F3_C3.BackColor = Color.LightGray; }
            else if (Tablero[2, 2] == 2) { F3_C3.BackColor = Color.Black; }

            if (Tablero[2, 3] == 0) { F3_C4.BackColor = Color.Transparent; }
            else if (Tablero[2, 3] == 1) { F3_C4.BackColor = Color.LightGray; }
            else if (Tablero[2, 3] == 2) { F3_C4.BackColor = Color.Black; }

            if (Tablero[2, 4] == 0) { F3_C5.BackColor = Color.Transparent; }
            else if (Tablero[2, 4] == 1) { F3_C5.BackColor = Color.LightGray; }
            else if (Tablero[2, 4] == 2) { F3_C5.BackColor = Color.Black; }

            if (Tablero[2, 5] == 0) { F3_C6.BackColor = Color.Transparent; }
            else if (Tablero[2, 5] == 1) { F3_C6.BackColor = Color.LightGray; }
            else if (Tablero[2, 5] == 2) { F3_C6.BackColor = Color.Black; }

            if (Tablero[2, 6] == 0) { F3_C7.BackColor = Color.Transparent; }
            else if (Tablero[2, 6] == 1) { F3_C7.BackColor = Color.LightGray; }
            else if (Tablero[2, 6] == 2) { F3_C7.BackColor = Color.Black; }

            if (Tablero[2, 7] == 0) { F3_C8.BackColor = Color.Transparent; }
            else if (Tablero[2, 7] == 1) { F3_C8.BackColor = Color.LightGray; }
            else if (Tablero[2, 7] == 2) { F3_C8.BackColor = Color.Black; }
//------------------------------------------------------------
            if (Tablero[3, 0] == 0) { F4_C1.BackColor = Color.Transparent; }
            else if (Tablero[3, 0] == 1) { F4_C1.BackColor = Color.LightGray; }
            else if (Tablero[3, 0] == 2) { F4_C1.BackColor = Color.Black; }

            if (Tablero[3, 1] == 0) { F4_C2.BackColor = Color.Transparent; }
            else if (Tablero[3, 1] == 1) { F4_C2.BackColor = Color.LightGray; }
            else if (Tablero[3, 1] == 2) { F4_C2.BackColor = Color.Black; }

            if (Tablero[3, 2] == 0) { F4_C3.BackColor = Color.Transparent; }
            else if (Tablero[3, 2] == 1) { F4_C3.BackColor = Color.LightGray; }
            else if (Tablero[3, 2] == 2) { F4_C3.BackColor = Color.Black; }

            if (Tablero[3, 3] == 0) { F4_C4.BackColor = Color.Transparent; }
            else if (Tablero[3, 3] == 1) { F4_C4.BackColor = Color.LightGray; }
            else if (Tablero[3, 3] == 2) { F4_C4.BackColor = Color.Black; }

            if (Tablero[3, 4] == 0) { F4_C5.BackColor = Color.Transparent; }
            else if (Tablero[3, 4] == 1) { F4_C5.BackColor = Color.LightGray; }
            else if (Tablero[3, 4] == 2) { F4_C5.BackColor = Color.Black; }
            
            if (Tablero[3, 5] == 0) { F4_C6.BackColor = Color.Transparent; }
            else if (Tablero[3, 5] == 1) { F4_C6.BackColor = Color.LightGray; }
            else if (Tablero[3, 5] == 2) { F4_C6.BackColor = Color.Black; }

            if (Tablero[3, 6] == 0) { F4_C7.BackColor = Color.Transparent; }
            else if (Tablero[3, 6] == 1) { F4_C7.BackColor = Color.LightGray; }
            else if (Tablero[3, 6] == 2) { F4_C7.BackColor = Color.Black; }

            if (Tablero[3, 7] == 0) { F4_C8.BackColor = Color.Transparent; }
            else if (Tablero[3, 7] == 1) { F4_C8.BackColor = Color.LightGray; }
            else if (Tablero[3, 7] == 2) { F4_C8.BackColor = Color.Black; }
//------------------------------------------------------------


            if (Tablero[4, 0] == 0) { F5_C1.BackColor = Color.Transparent; }
            else if (Tablero[4, 0] == 1) { F5_C1.BackColor = Color.LightGray; }
            else if (Tablero[4, 0] == 2) { F5_C1.BackColor = Color.Black; }

            if (Tablero[4, 1] == 0) { F5_C2.BackColor = Color.Transparent; }
            else if (Tablero[4, 1] == 1) { F5_C2.BackColor = Color.LightGray; }
            else if (Tablero[4, 1] == 2) { F5_C2.BackColor = Color.Black; }

            if (Tablero[4, 2] == 0) { F5_C3.BackColor = Color.Transparent; }
            else if (Tablero[4, 2] == 1) { F5_C3.BackColor = Color.LightGray; }
            else if (Tablero[4, 2] == 2) { F5_C3.BackColor = Color.Black; }

            if (Tablero[4, 3] == 0) { F5_C4.BackColor = Color.Transparent; }
            else if (Tablero[4, 3] == 1) { F5_C4.BackColor = Color.LightGray; }
            else if (Tablero[4, 3] == 2) { F5_C4.BackColor = Color.Black; }

            if (Tablero[4, 4] == 0) { F5_C5.BackColor = Color.Transparent; }
            else if (Tablero[4, 4] == 1) { F5_C5.BackColor = Color.LightGray; }
            else if (Tablero[4, 4] == 2) { F5_C5.BackColor = Color.Black; }

            if (Tablero[4, 5] == 0) { F5_C6.BackColor = Color.Transparent; }
            else if (Tablero[4, 5] == 1) { F5_C6.BackColor = Color.LightGray; }
            else if (Tablero[4, 5] == 2) { F5_C6.BackColor = Color.Black; }

            if (Tablero[4, 6] == 0) { F5_C7.BackColor = Color.Transparent; }
            else if (Tablero[4, 6] == 1) { F5_C7.BackColor = Color.LightGray; }
            else if (Tablero[4, 6] == 2) { F5_C7.BackColor = Color.Black; }

            if (Tablero[4, 7] == 0) { F5_C8.BackColor = Color.Transparent; }
            else if (Tablero[4, 7] == 1) { F5_C8.BackColor = Color.LightGray; }
            else if (Tablero[4, 7] == 2) { F5_C8.BackColor = Color.Black; }
//------------------------------------------------------------

            if (Tablero[5, 0] == 0) { F6_C1.BackColor = Color.Transparent; }
            else if (Tablero[5, 0] == 1) { F6_C1.BackColor = Color.LightGray; }
            else if (Tablero[5, 0] == 2) { F6_C1.BackColor = Color.Black; }

            if (Tablero[5, 1] == 0) { F6_C2.BackColor = Color.Transparent; }
            else if (Tablero[5, 1] == 1) { F6_C2.BackColor = Color.LightGray; }
            else if (Tablero[5, 1] == 2) { F6_C2.BackColor = Color.Black; }

            if (Tablero[5, 2] == 0) { F6_C3.BackColor = Color.Transparent; }
            else if (Tablero[5, 2] == 1) { F6_C3.BackColor = Color.LightGray; }
            else if (Tablero[5, 2] == 2) { F6_C3.BackColor = Color.Black; }

            if (Tablero[5, 3] == 0) { F6_C4.BackColor = Color.Transparent; }
            else if (Tablero[5, 3] == 1) { F6_C4.BackColor = Color.LightGray; }
            else if (Tablero[5, 3] == 2) { F6_C4.BackColor = Color.Black; }

            if (Tablero[5, 4] == 0) { F6_C5.BackColor = Color.Transparent; }
            else if (Tablero[5, 4] == 1) { F6_C5.BackColor = Color.LightGray; }
            else if (Tablero[5, 4] == 2) { F6_C5.BackColor = Color.Black; }

            if (Tablero[5, 5] == 0) { F6_C6.BackColor = Color.Transparent; }
            else if (Tablero[5, 5] == 1) { F6_C6.BackColor = Color.LightGray; }
            else if (Tablero[5, 5] == 2) { F6_C6.BackColor = Color.Black; }

            if (Tablero[5, 6] == 0) { F6_C7.BackColor = Color.Transparent; }
            else if (Tablero[5, 6] == 1) { F6_C7.BackColor = Color.LightGray; }
            else if (Tablero[5, 6] == 2) { F6_C7.BackColor = Color.Black; }

            if (Tablero[5, 7] == 0) { F6_C8.BackColor = Color.Transparent; }
            else if (Tablero[5, 7] == 1) { F6_C8.BackColor = Color.LightGray; }
            else if (Tablero[5, 7] == 2) { F6_C8.BackColor = Color.Black; }
//-------------------------------------------------

            if (Tablero[6, 0] == 0) { F7_C1.BackColor = Color.Transparent; }
            else if (Tablero[6, 0] == 1) { F7_C1.BackColor = Color.LightGray; }
            else if (Tablero[6, 0] == 2) { F7_C1.BackColor = Color.Black; }

            if (Tablero[6, 1] == 0) { F7_C2.BackColor = Color.Transparent; }
            else if (Tablero[6, 1] == 1) { F7_C2.BackColor = Color.LightGray; }
            else if (Tablero[6, 1] == 2) { F7_C2.BackColor = Color.Black; }

            if (Tablero[6, 2] == 0) { F7_C3.BackColor = Color.Transparent; }
            else if (Tablero[6, 2] == 1) { F7_C3.BackColor = Color.LightGray; }
            else if (Tablero[6, 2] == 2) { F7_C3.BackColor = Color.Black; }

            if (Tablero[6, 3] == 0) { F7_C4.BackColor = Color.Transparent; }
            else if (Tablero[6, 3] == 1) { F7_C4.BackColor = Color.LightGray; }
            else if (Tablero[6, 3] == 2) { F7_C4.BackColor = Color.Black; }

            if (Tablero[6, 4] == 0) { F7_C5.BackColor = Color.Transparent; }
            else if (Tablero[6, 4] == 1) { F7_C5.BackColor = Color.LightGray; }
            else if (Tablero[6, 4] == 2) { F7_C5.BackColor = Color.Black; }

            if (Tablero[6, 5] == 0) { F7_C6.BackColor = Color.Transparent; }
            else if (Tablero[6, 5] == 1) { F7_C6.BackColor = Color.LightGray; }
            else if (Tablero[6, 5] == 2) { F7_C6.BackColor = Color.Black; }

            if (Tablero[6, 6] == 0) { F7_C7.BackColor = Color.Transparent; }
            else if (Tablero[6, 6] == 1) { F7_C7.BackColor = Color.LightGray; }
            else if (Tablero[6, 6] == 2) { F7_C7.BackColor = Color.Black; }

            if (Tablero[6, 7] == 0) { F7_C8.BackColor = Color.Transparent; }
            else if (Tablero[6, 7] == 1) { F7_C8.BackColor = Color.LightGray; }
            else if (Tablero[6, 7] == 2) { F7_C8.BackColor = Color.Black; }

 //-------------------------------------------------

            if (Tablero[7, 0] == 0) { F8_C1.BackColor = Color.Transparent; }
            else if (Tablero[7, 0] == 1) { F8_C1.BackColor = Color.LightGray; }
            else if (Tablero[7, 0] == 2) { F8_C1.BackColor = Color.Black; }

            if (Tablero[7, 1] == 0) { F8_C2.BackColor = Color.Transparent; }
            else if (Tablero[7, 1] == 1) { F8_C2.BackColor = Color.LightGray; }
            else if (Tablero[7, 1] == 2) { F8_C2.BackColor = Color.Black; }

            if (Tablero[7, 2] == 0) { F8_C3.BackColor = Color.Transparent; }
            else if (Tablero[7, 2] == 1) { F8_C3.BackColor = Color.LightGray; }
            else if (Tablero[7, 2] == 2) { F8_C3.BackColor = Color.Black; }

            if (Tablero[7, 3] == 0) { F8_C4.BackColor = Color.Transparent; }
            else if (Tablero[7, 3] == 1) { F8_C4.BackColor = Color.LightGray ; }
            else if (Tablero[7, 3] == 2) { F8_C4.BackColor = Color.Black; }

            if (Tablero[7, 4] == 0) { F8_C5.BackColor = Color.Transparent; }
            else if (Tablero[7, 4] == 1) { F8_C5.BackColor = Color.LightGray; }
            else if (Tablero[7, 4] == 2) { F8_C5.BackColor = Color.Black; }

            if (Tablero[7, 5] == 0) { F8_C6.BackColor = Color.Transparent; }
            else if (Tablero[7, 5] == 1) { F8_C6.BackColor = Color.LightGray; }
            else if (Tablero[7, 5] == 2) { F8_C6.BackColor = Color.Black; }

            if (Tablero[7, 6] == 0) { F8_C7.BackColor = Color.Transparent; }
            else if (Tablero[7, 6] == 1) { F8_C7.BackColor = Color.LightGray; ; }
            else if (Tablero[7, 6] == 2) { F8_C7.BackColor = Color.Black; }

            if (Tablero[7, 7] == 0) { F8_C8.BackColor = Color.Transparent; }
            else if (Tablero[7, 7] == 1) { F8_C8.BackColor = Color.LightGray; }
            else if (Tablero[7, 7] == 2) { F8_C8.BackColor = Color.Black; }

        }
        

        protected void Guardar_Click(object sender, EventArgs e)
        {
            string NombrePath = "D:/Escritorio/USAC/IPC 2/Semestre 2/Desarollo Proyecto/Proyecto con web forms/ProyectoIPC2_Othello/XML/"+"Partida-"+ usuarios[5] + xmlcounter+".xml";
            xmlcounter++;
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            XElement nodoRaiz = new XElement("tablero");
            document.Add(nodoRaiz);
            
            for (int f = 0; f < Tablero.GetLength(0); f++) 
            {
                for (int c = 0; c < Tablero.GetLength(1); c++) 
                {

                    XElement ficha = new XElement("ficha");
                    if (Tablero[f, c] == 1) 
                    {
                        string column = "";
                        if (c == 0) { column = "A"; }
                        else if (c == 1) { column = "B"; }
                        else if (c == 2) { column = "C"; }
                        else if (c == 3) { column = "D"; }
                        else if (c == 4) { column = "E"; }
                        else if (c == 5) { column = "F"; }
                        else if (c == 6) { column = "G"; }
                        else if (c == 7) { column = "H"; }
                        int Fil = f + 1;

                        ficha.Add(new XElement("color","blanco"));
                        ficha.Add(new XElement("columna", column));
                        ficha.Add(new XElement("fila", Fil+""));
                        nodoRaiz.Add(ficha);
                    }
                    else if (Tablero[f,c] == 2) 
                    {
                        string column = "";
                        if (c == 0) { column = "A"; }
                        else if (c == 1) { column = "B"; }
                        else if (c == 2) { column = "C"; }
                        else if (c == 3) { column = "D"; }
                        else if (c == 4) { column = "E"; }
                        else if (c == 5) { column = "F"; }
                        else if (c == 6) { column = "G"; }
                        else if (c == 7) { column = "H"; }
                        int Fil = f + 1;

                        ficha.Add(new XElement("color", "negro"));
                        ficha.Add(new XElement("columna", column));
                        ficha.Add(new XElement("fila", Fil+""));
                        nodoRaiz.Add(ficha);
                    }
                }
            }

            XElement siguienteTiro = new XElement("siguienteTiro");
            if (TurnoJugador == 1) {  siguienteTiro.Add(new XElement("color",  "blanco"));  }
            else if (TurnoJugador == 2) {  siguienteTiro.Add(new XElement("color", "negro")); }
            nodoRaiz.Add(siguienteTiro);
            document.Save(NombrePath);
        }

        protected void Pasar_click(object sender, EventArgs e)
        { }
        protected void Boton_click(object sender, EventArgs e)
        {

            Button boton = sender as Button;
            int turnoactual = TurnoJugador;


            if (!Nohayjugadasposibles)
            {
                selectcolor(boton);

                Cambiarcolor();
            }



            bool jugadasiguiente1 = false;
            bool jugadasiguiente2 = false;

            bool flagci = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Tablero[i, j] == 0)
                    {
                        if (ValidarJuego(i, j, turnoactual)) { Nohayjugadasposibles = false; flagci = true; break; }
                        else { Nohayjugadasposibles = true; }
                    }
                }
                if (flagci) { break; }
            }

            if (jugadasiguiente1 & jugadasiguiente2) { Nohayjugadasposibles = true; }

            ContarPuntaje();

            if (Nohayjugadasposibles)
            { ganadort(); }
        }

        protected void ganadort()
        {
            if (puntajejugador1 > puntajejugador2)
            {
                if (primermovimiento == 2) { ganador = "El ganador fue " + usuarios[5].ToString(); }
                else if (primermovimiento == 1) { ganador = "El ganador fue " + "Invitado"; }
            }
            else if (puntajejugador2 > puntajejugador1)
            {
                if (primermovimiento == 1) { ganador = "El ganador fue " + usuarios[5].ToString(); }
                else if (primermovimiento == 2) { ganador = "El ganador fue " + "Invitado"; }
            }
            else if (puntajejugador1 == puntajejugador2) { ganador = "El resultado fue un empate"; }
            Terminado.Text = "Ejecucion terminada. " + ganador + "";
        }


        protected void selectcolor(Button boton) 
        {
            switch (boton.ID)
            {
                case "F1_C1":
                    if (Tablero[0, 0] == 0){
                        if (ValidarTurno(0,0,TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 0] = 2; }
                        }
                    }
                        break; 

                case "F1_C2":
                    if (Tablero[0, 1] == 0)
                    {
                        if (ValidarTurno(0, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; }
                            else { TurnoJugador = 1; }
                        }
                    }
                    break;

                case "F1_C3":
                    if (Tablero[0, 2] == 0)
                    {
                        if (ValidarTurno(0, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 2] = 2; }
                        }
                    }
                    break;

                case "F1_C4":
                    if (Tablero[0, 3] == 0)
                    {
                        if (ValidarTurno(0, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 3] = 2; }
                        }
                    }
                    break;

                case "F1_C5":
                    if (Tablero[0, 4] == 0)
                    {
                        if (ValidarTurno(0, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 4] = 2; }
                        }
                    }
                    break;

                case "F1_C6":
                    if (Tablero[0, 5] == 0)
                    {
                        if (ValidarTurno(0, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 5] = 2; }
                        }
                    }
                    break;

                case "F1_C7":
                    if (Tablero[0, 6] == 0)
                    {
                        if (ValidarTurno(0, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 6] = 2; }
                        }
                    }
                    break;

                case "F1_C8":
                    if (Tablero[0, 7] == 0)
                    {
                        if (ValidarTurno(0, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 7] = 2; }
                        }
                    }
                    break;

                case "F2_C1":
                    if (Tablero[1, 0] == 0)
                    {
                        if (ValidarTurno(0, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 0] = 2; }
                        }
                    }
                    break;

                case "F2_C2":
                    if (Tablero[1, 1] == 0)
                    {
                        if (ValidarTurno(1, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 1] = 2; }
                        }
                    }
                    break;

                case "F2_C3":
                    if (Tablero[1, 2] == 0)
                    {
                        if (ValidarTurno(1, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 2] = 2; }
                        }
                    }
                    break;

                case "F2_C4":
                    if (Tablero[1, 3] == 0)
                    {
                        if (ValidarTurno(1, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 3] = 2; }
                        }
                    }
                    break;

                case "F2_C5":
                    if (Tablero[1, 4] == 0)
                    {
                        if (ValidarTurno(1, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 4] = 2; }
                        }
                    }
                    break;

                case "F2_C6":
                    if (Tablero[1, 5] == 0)
                    {
                        if (ValidarTurno(1, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 5] = 2; }
                        }
                    }
                    break;

                case "F2_C7":
                    if (Tablero[1, 6] == 0)
                    {
                        if (ValidarTurno(1, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 6] = 2; }
                        }
                    }
                    break;

                case "F2_C8":
                    if (Tablero[1, 7] == 0)
                    {
                        if (ValidarTurno(1, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[1, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[1, 7] = 2; }
                        }
                    }
                    break;

                case "F3_C1":
                    if (Tablero[2, 0] == 0)
                    {
                        if (ValidarTurno(2, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 0] = 2; }
                        }
                    }
                    break;

                case "F3_C2":
                    if (Tablero[2, 1] == 0)
                    {
                        if (ValidarTurno(2, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 1] = 2; }
                        }
                    }
                    break;

                case "F3_C3":
                    if (Tablero[2, 2] == 0)
                    {
                        if (ValidarTurno(2, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 2] = 2; }
                        }
                    }
                    break;

                case "F3_C4":
                    if (Tablero[2, 3] == 0)
                    {
                        if (ValidarTurno(2, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 3] = 2; }
                        }
                    }
                    break;

                case "F3_C5":
                    if (Tablero[2, 4] == 0)
                    {
                        if (ValidarTurno(2, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 4] = 2; }
                        }
                    }
                    break;

                case "F3_C6":
                    if (Tablero[2, 5] == 0)
                    {
                        if (ValidarTurno(2, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 5] = 2; }
                        }
                    }
                    break;

                case "F3_C7":
                    if (Tablero[2, 6] == 0)
                    {
                        if (ValidarTurno(2, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 6] = 2; }
                        }
                    }
                    break;

                case "F3_C8":
                    if (Tablero[2, 7] == 0)
                    {
                        if (ValidarTurno(2, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[2, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[2, 7] = 2; }
                        }
                    }
                    break;

                case "F4_C1":
                    if (Tablero[3, 0] == 0)
                    {
                        if (ValidarTurno(3, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 0] = 2; }
                        }
                    }
                    break;

                case "F4_C2":
                    if (Tablero[3, 1] == 0)
                    {
                        if (ValidarTurno(3, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 1] = 2; }
                        }
                    }
                    break;

                case "F4_C3":
                    if (Tablero[3, 2] == 0)
                    {
                        if (ValidarTurno(3, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 2] = 2; }
                        }
                    }
                    break;

                case "F4_C4":
                    if (Tablero[3, 3] == 0)
                    {
                        if (ValidarTurno(3, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 3] = 2; }
                        }
                    }
                    break;

                case "F4_C5":
                    if (Tablero[3, 4] == 0)
                    {
                        if (ValidarTurno(3, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 4] = 2; }
                        }
                    }
                    break;

                case "F4_C6":
                    if (Tablero[3, 5] == 0)
                    {
                        if (ValidarTurno(3, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 5] = 2; }
                        }
                    }
                    break;

                case "F4_C7":
                    if (Tablero[3, 6] == 0)
                    {
                        if (ValidarTurno(3, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 6] = 2; }
                        }
                    }
                    break;

                case "F4_C8":
                    if (Tablero[3, 7] == 0)
                    {
                        if (ValidarTurno(3, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[3, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[3, 7] = 2; }
                        }
                    }
                    break;

                case "F5_C1":
                    if (Tablero[4, 0] == 0)
                    {
                        if (ValidarTurno(4, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 0] = 2; }
                        }
                    }
                    break;

                case "F5_C2":
                    if (Tablero[4, 1] == 0)
                    {
                        if (ValidarTurno(4, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 1] = 2; }
                        }
                    }
                    break;

                case "F5_C3":
                    if (Tablero[4, 2] == 0)
                    {
                        if (ValidarTurno(4, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 2] = 2; }
                        }
                    }
                    break;

                case "F5_C4":
                    if (Tablero[4, 3] == 0)
                    {
                        if (ValidarTurno(4, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 3] = 2; }
                        }
                    }
                    break;

                case "F5_C5":
                    if (Tablero[4, 4] == 0)
                    {
                        if (ValidarTurno(4, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 4] = 2; }
                        }
                    }
                    break;

                case "F5_C6":
                    if (Tablero[4, 5] == 0)
                    {
                        if (ValidarTurno(4, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 5] = 2; }
                        }
                    }
                    break;

                case "F5_C7":
                    if (Tablero[4, 6] == 0)
                    {
                        if (ValidarTurno(4, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 6] = 2; }
                        }
                    }
                    break;

                case "F5_C8":
                    if (Tablero[4, 7] == 0)
                    {
                        if (ValidarTurno(4, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[4, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[4, 7] = 2; }
                        }
                    }
                    break;

                case "F6_C1":
                    if (Tablero[5, 0] == 0)
                    {
                        if (ValidarTurno(5, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 0] = 2; }
                        }
                    }
                    break;

                case "F6_C2":
                    if (Tablero[5, 1] == 0)
                    {
                        if (ValidarTurno(5, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 1] = 2; }
                        }
                    }
                    break;

                case "F6_C3":
                    if (Tablero[5, 2] == 0)
                    {
                        if (ValidarTurno(5, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 2] = 2; }
                        }
                    }
                    break;

                case "F6_C4":
                    if (Tablero[5, 3] == 0)
                    {
                        if (ValidarTurno(5, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 3] = 2; }
                        }
                    }
                    break;

                case "F6_C5":
                    if (Tablero[5, 4] == 0)
                    {
                        if (ValidarTurno(5, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 4] = 2; }
                        }
                    }
                    break;

                case "F6_C6":
                    if (Tablero[5, 5] == 0)
                    {
                        if (ValidarTurno(5, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 5] = 2; }
                        }
                    }
                    break;

                case "F6_C7":
                    if (Tablero[5, 6] == 0)
                    {
                        if (ValidarTurno(5, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 6] = 2; }
                        }
                    }
                    break;

                case "F6_C8":
                    if (Tablero[5, 7] == 0)
                    {
                        if (ValidarTurno(5, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[5, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[5, 7] = 2; }
                        }
                    }
                    break;

                case "F7_C1":
                    if (Tablero[6, 0] == 0)
                    {
                        if (ValidarTurno(6, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 0] = 2; }
                        }
                    }
                    break;

                case "F7_C2":
                    if (Tablero[6, 1] == 0)
                    {
                        if (ValidarTurno(6, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 1] = 2; }
                        }
                    }
                    break;

                case "F7_C3":
                    if (Tablero[6, 2] == 0)
                    {
                        if (ValidarTurno(6, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 2] = 2; }
                        }
                    }
                    break;

                case "F7_C4":
                    if (Tablero[6, 3] == 0)
                    {
                        if (ValidarTurno(6, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 3] = 2; }
                        }
                    }
                    break;

                case "F7_C5":
                    if (Tablero[6, 4] == 0)
                    {
                        if (ValidarTurno(6, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 4] = 2; }
                        }
                    }
                    break;

                case "F7_C6":
                    if (Tablero[6, 5] == 0)
                    {
                        if (ValidarTurno(6, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 5] = 2; }
                        }
                    }
                    break;

                case "F7_C7":
                    if (Tablero[6, 6] == 0)
                    {
                        if (ValidarTurno(6, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 6] = 2; }
                        }
                    }
                    break;

                case "F7_C8":
                    if (Tablero[6, 7] == 0)
                    {
                        if (ValidarTurno(6, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[6, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[6, 7] = 2; }
                        }
                    }
                    break;

                case "F8_C1":
                    if (Tablero[7, 0] == 0)
                    {
                        if (ValidarTurno(7, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 0] = 2; }
                        }
                    }
                    break;

                case "F8_C2":
                    if (Tablero[7, 1] == 0)
                    {
                        if (ValidarTurno(7, 1, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 1] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 1] = 2; }
                        }
                    }
                    break;

                case "F8_C3":
                    if (Tablero[7, 2] == 0)
                    {
                        if (ValidarTurno(7, 2, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 2] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 2] = 2; }
                        }
                    }
                    break;

                case "F8_C4":
                    if (Tablero[7, 3] == 0)
                    {
                        if (ValidarTurno(7, 3, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 3] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 3] = 2; }
                        }
                    }
                    break;

                case "F8_C5":
                    if (Tablero[7, 4] == 0)
                    {
                        if (ValidarTurno(7, 4, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 4] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 4] = 2; }
                        }
                    }
                    break;

                case "F8_C6":
                    if (Tablero[7, 5] == 0)
                    {
                        if (ValidarTurno(7, 5, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 5] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 5] = 2; }
                        }
                    }
                    break;

                case "F8_C7":
                    if (Tablero[7, 6] == 0)
                    {
                        if (ValidarTurno(7, 6, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 6] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 6] = 2; }
                        }
                    }
                    break;

                case "F8_C8":
                    if (Tablero[7, 7] == 0)
                    {
                        if (ValidarTurno(7, 7, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[7, 7] = 1; }
                            else { TurnoJugador = 1; Tablero[7, 7] = 2; }
                        }
                    }
                    break;
            }
        }

        public bool ValidarTurno(int fila, int columna, int TurnoJugador)
        {
            bool valido = false;
            int sw1 = 0, sw2 = 0, sw3 = 0, sw4 = 0, sw5 = 0, sw6 = 0, sw7 = 0, sw8 = 0;
            int cont1 = 0, cont2 = 0, cont3 = 0, cont4 = 0, cont5 = 0, cont6 = 0, cont7 = 0, cont8 = 0;
            for (int x = 1; x <= 7; x++)
            {
                if (fila + x <= 7 && columna + x <= 7 && sw1 == 0)
                {
                    if (Tablero[fila + x, columna + x] == 0) sw1 = 1;
                    else if (Tablero[fila + x, columna + x] == TurnoJugador)
                    {
                        if (cont1 > 0)
                        {
                            for (int y = 0; y <= cont1; y++)
                            {                               
                                Tablero[fila + y, columna + y] = TurnoJugador;
                                sw1 = 1;
                                valido = true;                                
                            }
                        }
                        else sw1 = 1;
                    }
                    else cont1 = cont1 + 1;
                }

                if (fila - x >= 0 && columna - x >= 0 && sw2 == 0)
                {
                    if (Tablero[fila - x, columna - x] == 0) sw2 = 1;
                    else if (Tablero[fila - x, columna - x] == TurnoJugador)
                    {
                        if (cont2 > 0)
                        {
                            for (int y = 0; y <= cont2; y++)
                            {                               
                                Tablero[fila - y, columna - y] = TurnoJugador;
                                sw2 = 1;
                                valido = true;                                
                            }
                        }
                        else sw2 = 1;
                    }
                    else cont2 = cont2 + 1;
                }
                if (fila - x >= 0 && columna + x <= 7 && sw3 == 0)
                {
                    if (Tablero[fila - x, columna + x] == 0) sw3 = 1;
                    else if (Tablero[fila - x, columna + x] == TurnoJugador)
                    {
                        if (cont3 > 0)
                        {
                            for (int y = 0; y <= cont3; y++)
                            {                              
                                Tablero[fila - y, columna + y] = TurnoJugador;
                                sw3 = 1;
                                valido = true;                                
                            }
                        }
                        else sw3 = 1;
                    }
                    else cont3 = cont3 + 1;
                }
                if (fila + x <= 7 && columna - x >= 0 && sw4 == 0)
                {
                    if (Tablero[fila + x, columna - x] == 0) sw4 = 1;
                    else if (Tablero[fila + x, columna - x] == TurnoJugador)
                    {
                        if (cont4 > 0)
                        {
                            for (int y = 0; y <= cont4; y++)
                            {                             
                                Tablero[fila + y, columna - y] = TurnoJugador;
                                sw4 = 1;
                                valido = true;                             
                            }
                        }
                        else sw4 = 1;
                    }
                    else cont4 = cont4 + 1;
                }
                if (columna - x >= 0 && sw5 == 0)
                {
                    if (Tablero[fila, columna - x] == 0) sw5 = 1;
                    else if (Tablero[fila, columna - x] == TurnoJugador)
                    {
                        if (cont5 > 0)
                        {
                            for (int y = 0; y <= cont5; y++)
                            {                                
                                Tablero[fila, columna - y] = TurnoJugador;
                                sw5 = 1;
                                valido = true;                                
                            }
                        }
                        else sw5 = 1;
                    }
                    else cont5 = cont5 + 1;
                }
                if (columna + x <= 7 && sw6 == 0)
                {
                    if (Tablero[fila, columna + x] == 0) sw6 = 1;
                    else if (Tablero[fila, columna + x] == TurnoJugador)
                    {
                        if (cont6 > 0)
                        {
                            for (int y = 0; y <= cont6; y++)
                            {                             
                                Tablero[fila, columna + y] = TurnoJugador;
                                sw6 = 1;
                                valido = true;
                            }
                        }
                        else sw6 = 1;
                    }
                    else cont6 = cont6 + 1;
                }
                if (fila - x >= 0 && sw7 == 0)
                {
                    if (Tablero[fila - x, columna] == 0) sw7 = 1;
                    else if (Tablero[fila - x, columna] == TurnoJugador)
                    {
                        if (cont7 > 0)
                        {
                            for (int y = 0; y <= cont7; y++)
                            {                               
                                Tablero[fila - y, columna] = TurnoJugador;
                                sw7 = 1;
                                valido = true;                                                               
                            }
                        }
                        else sw7 = 1;
                    }
                    else cont7 = cont7 + 1;
                }
                if (fila + x <= 7 && sw8 == 0)
                {
                    if (Tablero[fila + x, columna] == 0) sw8 = 1;
                    else if (Tablero[fila + x, columna] == TurnoJugador)
                    {
                        if (cont8 > 0)
                        {
                            for (int y = 0; y <= cont8; y++)
                            {                                
                                Tablero[fila + y, columna] = TurnoJugador;
                                sw8 = 1;
                                valido = true;                                
                            }
                        }
                        else sw8 = 1;
                    }
                    else cont8 = cont8 + 1;
                }
            }
            return valido;
        }
        
        
        public bool ValidarJuego(int fila, int columna, int TurnoJugador)
        {
            bool valido = false;
            int sw1 = 0, sw2 = 0, sw3 = 0, sw4 = 0, sw5 = 0, sw6 = 0, sw7 = 0, sw8 = 0;
            int cont1 = 0, cont2 = 0, cont3 = 0, cont4 = 0, cont5 = 0, cont6 = 0, cont7 = 0, cont8 = 0;
            for (int x = 1; x <= 7; x++)
            {
                if (fila + x <= 7 && columna + x <= 7 && sw1 == 0)
                {
                    if (Tablero[fila + x, columna + x] == 0) sw1 = 1;
                    else if (Tablero[fila + x, columna + x] == TurnoJugador)
                    {
                        if (cont1 > 0)
                        {
                            for (int y = 0; y <= cont1; y++)
                            {                                
                                sw1 = 1;
                                valido = true;
                            }
                        }
                        else sw1 = 1;
                    }
                    else cont1 = cont1 + 1;
                }

                if (fila - x >= 0 && columna - x >= 0 && sw2 == 0)
                {
                    if (Tablero[fila - x, columna - x] == 0) sw2 = 1;
                    else if (Tablero[fila - x, columna - x] == TurnoJugador)
                    {
                        if (cont2 > 0)
                        {
                            for (int y = 0; y <= cont2; y++)
                            {                               
                                sw2 = 1;
                                valido = true;
                            }
                        }
                        else sw2 = 1;
                    }
                    else cont2 = cont2 + 1;
                }
                if (fila - x >= 0 && columna + x <= 7 && sw3 == 0)
                {
                    if (Tablero[fila - x, columna + x] == 0) sw3 = 1;
                    else if (Tablero[fila - x, columna + x] == TurnoJugador)
                    {
                        if (cont3 > 0)
                        {
                            for (int y = 0; y <= cont3; y++)
                            {                                
                                sw3 = 1;
                                valido = true;
                            }
                        }
                        else sw3 = 1;
                    }
                    else cont3 = cont3 + 1;
                }
                if (fila + x <= 7 && columna - x >= 0 && sw4 == 0)
                {
                    if (Tablero[fila + x, columna - x] == 0) sw4 = 1;
                    else if (Tablero[fila + x, columna - x] == TurnoJugador)
                    {
                        if (cont4 > 0)
                        {
                            for (int y = 0; y <= cont4; y++)
                            {                                
                                sw4 = 1;
                                valido = true;
                            }
                        }
                        else sw4 = 1;
                    }
                    else cont4 = cont4 + 1;
                }
                if (columna - x >= 0 && sw5 == 0)
                {
                    if (Tablero[fila, columna - x] == 0) sw5 = 1;
                    else if (Tablero[fila, columna - x] == TurnoJugador)
                    {
                        if (cont5 > 0)
                        {
                            for (int y = 0; y <= cont5; y++)
                            {                               
                                sw5 = 1;
                                valido = true;
                            }
                        }
                        else sw5 = 1;
                    }
                    else cont5 = cont5 + 1;
                }
                if (columna + x <= 7 && sw6 == 0)
                {
                    if (Tablero[fila, columna + x] == 0) sw6 = 1;
                    else if (Tablero[fila, columna + x] == TurnoJugador)
                    {
                        if (cont6 > 0)
                        {
                            for (int y = 0; y <= cont6; y++)
                            {                               
                                sw6 = 1;
                                valido = true;
                            }
                        }
                        else sw6 = 1;
                    }
                    else cont6 = cont6 + 1;
                }
                if (fila - x >= 0 && sw7 == 0)
                {
                    if (Tablero[fila - x, columna] == 0) sw7 = 1;
                    else if (Tablero[fila - x, columna] == TurnoJugador)
                    {
                        if (cont7 > 0)
                        {
                            for (int y = 0; y <= cont7; y++)
                            {                                
                                sw7 = 1;
                                valido = true;
                            }
                        }
                        else sw7 = 1;
                    }
                    else cont7 = cont7 + 1;
                }
                if (fila + x <= 7 && sw8 == 0)
                {
                    if (Tablero[fila + x, columna] == 0) sw8 = 1;
                    else if (Tablero[fila + x, columna] == TurnoJugador)
                    {
                        if (cont8 > 0)
                        {
                            for (int y = 0; y <= cont8; y++)
                            {                                
                                sw8 = 1;
                                valido = true;
                            }
                        }
                        else sw8 = 1;
                    }
                    else cont8 = cont8 + 1;
                }
            }
            return valido;
        }

        public void ContarPuntaje()
        {
            int PJugador1 = 0, PJugador2 = 0, vacio = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Tablero[i, j] == 1) { PJugador1 = PJugador1 + 1; }
                    else if (Tablero[i, j] == 2) { PJugador2 = PJugador2 + 1; }
                    else vacio = vacio + 1;
                }
            }
            puntajejugador1 = PJugador1;
            puntajejugador2 = PJugador2;
            if (vacio == 0) { Nohayjugadasposibles = true; }
        }

    }
}