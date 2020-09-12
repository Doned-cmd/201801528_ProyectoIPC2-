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

        
        static public int[,] Tablero = Inicio.Tablero;

        

        static public int contador = Inicio.contador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Tablero[3, 3] = 2;
            Tablero[3, 4] = 1;
            Tablero[4, 3] = 2;
            Tablero[4, 4] = 1;
            Cambiarcolor();
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

        }

        protected void Boton_click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
           

            switch (boton.ID) {
                case "F1_C1":
                    if (contador == 1) { contador = 2; Tablero[0, 0] = 1; }
                    else { contador = 1; Tablero[0, 0] = 2; }
                    break;

                case "F1_C2":
                    if (contador == 1) { contador = 2; Tablero[0, 1] = 1; }
                    else { contador = 1; Tablero[0, 1] = 2; }
                    break;

                case "F1_C3":
                    if (contador == 1) { contador = 2; Tablero[0, 2] = 1; }
                    else { contador = 1; Tablero[0, 2] = 2; }
                    break;

                case "F1_C4":
                    if (contador == 1) { contador = 2; Tablero[0, 3] = 1; }
                    else { contador = 1; Tablero[0, 3] = 2; }
                    break;

                case "F1_C5":
                    if (contador == 1) { contador = 2; Tablero[0, 4] = 1; }
                    else { contador = 1; Tablero[0, 4] = 2; }
                    break;

                case "F1_C6":
                    if (contador == 1) { contador = 2; Tablero[0, 5] = 1; }
                    else { contador = 1; Tablero[0, 5] = 2; }
                    break;

                case "F1_C7":
                    if (contador == 1) { contador = 2; Tablero[0, 6] = 1; }
                    else { contador = 1; Tablero[0, 6] = 2; }
                    break;

                case "F1_C8":
                    if (contador == 1) { contador = 2; Tablero[0, 7] = 1; }
                    else { contador = 1; Tablero[0, 7] = 2; }
                    break;

                case "F2_C1":
                    if (contador == 1) { contador = 2; Tablero[1, 0] = 1; }
                    else { contador = 1; Tablero[1, 0] = 2; }
                    break;

                case "F2_C2":
                    if (contador == 1) { contador = 2; Tablero[1, 1] = 1; }
                    else { contador = 1; Tablero[1, 1] = 2; }
                    break;

                case "F2_C3":
                    if (contador == 1) { contador = 2; Tablero[1, 2] = 1; }
                    else { contador = 1; Tablero[1, 2] = 2; }
                    break;

                case "F2_C4":
                    if (contador == 1) { contador = 2; Tablero[1, 3] = 1; }
                    else { contador = 1; Tablero[1, 3] = 2; }
                    break;

                case "F2_C5":
                    if (contador == 1) { contador = 2; Tablero[1, 4] = 1; }
                    else { contador = 1; Tablero[1, 4] = 2; }
                    break;

                case "F2_C6":
                    if (contador == 1) { contador = 2; Tablero[1, 5] = 1; }
                    else { contador = 1; Tablero[1, 5] = 2; }
                    break;

                case "F2_C7":
                    if (contador == 1) { contador = 2; Tablero[1, 6] = 1; }
                    else { contador = 1; Tablero[1, 6] = 2; }
                    break;

                case "F2_C8":
                    if (contador == 1) { contador = 2; Tablero[1, 7] = 1; }
                    else { contador = 1; Tablero[1, 7] = 2; }
                    break;

                case "F3_C1":
                    if (contador == 1) { contador = 2; Tablero[2, 0] = 1; }
                    else { contador = 1; Tablero[2, 0] = 2; }
                    break;

                case "F3_C2":
                    if (contador == 1) { contador = 2; Tablero[2, 1] = 1; }
                    else { contador = 1; Tablero[2, 1] = 2; }
                    break;

                case "F3_C3":
                    if (contador == 1) { contador = 2; Tablero[2, 2] = 1; }
                    else { contador = 1; Tablero[2, 2] = 2; }
                    break;

                case "F3_C4":
                    if (contador == 1) { contador = 2; Tablero[2, 3] = 1; }
                    else { contador = 1; Tablero[2, 3] = 2; }
                    break;

                case "F3_C5":
                    if (contador == 1) { contador = 2; Tablero[2, 4] = 1; }
                    else { contador = 1; Tablero[2, 4] = 2; }
                    break;

                case "F3_C6":
                    if (contador == 1) { contador = 2; Tablero[2, 5] = 1; }
                    else { contador = 1; Tablero[2, 5] = 2; }
                    break;

                case "F3_C7":
                    if (contador == 1) { contador = 2; Tablero[2, 6] = 1; }
                    else { contador = 1; Tablero[2, 6] = 2; }
                    break;

                case "F3_C8":
                    if (contador == 1) { contador = 2; Tablero[2, 7] = 1; }
                    else { contador = 1; Tablero[2, 7] = 2; }
                    break;

                case "F4_C1":
                    if (contador == 1) { contador = 2; Tablero[3, 0] = 1; }
                    else { contador = 1; Tablero[3, 0] = 2; }
                    break;

                case "F4_C2":
                    if (contador == 1) { contador = 2; Tablero[3, 1] = 1; }
                    else { contador = 1; Tablero[3, 1] = 2; }
                    break;

                case "F4_C3":
                    if (contador == 1) { contador = 2; Tablero[3, 2] = 1; }
                    else { contador = 1; Tablero[3, 2] = 2; }
                    break;

                case "F4_C4":
                    if (contador == 1) { contador = 2; Tablero[3, 3] = 1; }
                    else { contador = 1; Tablero[3, 3] = 2; }
                    break;

                case "F4_C5":
                    if (contador == 1) { contador = 2; Tablero[3, 4] = 1; }
                    else { contador = 1; Tablero[3, 4] = 2; }
                    break;

                case "F4_C6":
                    if (contador == 1) { contador = 2; Tablero[3, 5] = 1; }
                    else { contador = 1; Tablero[3, 5] = 2; }
                    break;

                case "F4_C7":
                    if (contador == 1) { contador = 2; Tablero[3, 6] = 1; }
                    else { contador = 1; Tablero[3, 6] = 2; }
                    break;

                case "F4_C8":
                    if (contador == 1) { contador = 2; Tablero[3, 7] = 1; }
                    else { contador = 1; Tablero[3, 7] = 2; }
                    break;

                case "F5_C1":
                    if (contador == 1) { contador = 2; Tablero[4, 0] = 1; }
                    else { contador = 1; Tablero[4, 0] = 2; }
                    break;

                case "F5_C2":
                    if (contador == 1) { contador = 2; Tablero[4, 1] = 1; }
                    else { contador = 1; Tablero[4, 1] = 2; }
                    break;

                case "F5_C3":
                    if (contador == 1) { contador = 2; Tablero[4, 2] = 1; }
                    else { contador = 1; Tablero[4, 2] = 2; }
                    break;

                case "F5_C4":
                    if (contador == 1) { contador = 2; Tablero[4, 3] = 1; }
                    else { contador = 1; Tablero[4, 3] = 2; }
                    break;

                case "F5_C5":
                    if (contador == 1) { contador = 2; Tablero[4, 4] = 1; }
                    else { contador = 1; Tablero[4, 4] = 2; }
                    break;

                case "F5_C6":
                    if (contador == 1) { contador = 2; Tablero[4, 5] = 1; }
                    else { contador = 1; Tablero[4, 5] = 2; }
                    break;

                case "F5_C7":
                    if (contador == 1) { contador = 2; Tablero[4, 6] = 1; }
                    else { contador = 1; Tablero[4, 6] = 2; }
                    break;

                case "F5_C8":
                    if (contador == 1) { contador = 2; Tablero[4, 7] = 1; }
                    else { contador = 1; Tablero[4, 7] = 2; }
                    break;

                case "F6_C1":
                    if (contador == 1) { contador = 2; Tablero[5, 0] = 1; }
                    else { contador = 1; Tablero[5, 0] = 2; }
                    break;

                case "F6_C2":
                    if (contador == 1) { contador = 2; Tablero[5, 1] = 1; }
                    else { contador = 1; Tablero[5, 1] = 2; }
                    break;

                case "F6_C3":
                    if (contador == 1) { contador = 2; Tablero[5, 2] = 1; }
                    else { contador = 1; Tablero[5, 2] = 2; }
                    break;

                case "F6_C4":
                    if (contador == 1) { contador = 2; Tablero[5, 3] = 1; }
                    else { contador = 1; Tablero[5, 3] = 2; }
                    break;

                case "F6_C5":
                    if (contador == 1) { contador = 2; Tablero[5, 4] = 1; }
                    else { contador = 1; Tablero[5, 4] = 2; }
                    break;

                case "F6_C6":
                    if (contador == 1) { contador = 2; Tablero[5, 5] = 1; }
                    else { contador = 1; Tablero[5, 5] = 2; }
                    break;

                case "F6_C7":
                    if (contador == 1) { contador = 2; Tablero[5, 6] = 1; }
                    else { contador = 1; Tablero[5, 6] = 2; }
                    break;

                case "F6_C8":
                    if (contador == 1) { contador = 2; Tablero[5, 7] = 1; }
                    else { contador = 1; Tablero[5, 7] = 2; }
                    break;

                case "F7_C1":
                    if (contador == 1) { contador = 2; Tablero[6, 0] = 1; }
                    else { contador = 1; Tablero[6, 0] = 2; }
                    break;

                case "F7_C2":
                    if (contador == 1) { contador = 2; Tablero[6, 1] = 1; }
                    else { contador = 1; Tablero[6, 1] = 2; }
                    break;

                case "F7_C3":
                    if (contador == 1) { contador = 2; Tablero[6, 2] = 1; }
                    else { contador = 1; Tablero[6, 2] = 2; }
                    break;

                case "F7_C4":
                    if (contador == 1) { contador = 2; Tablero[6, 3] = 1; }
                    else { contador = 1; Tablero[6, 3] = 2; }
                    break;

                case "F7_C5":
                    if (contador == 1) { contador = 2; Tablero[6, 4] = 1; }
                    else { contador = 1; Tablero[6, 4] = 2; }
                    break;

                case "F7_C6":
                    if (contador == 1) { contador = 2; Tablero[6, 5] = 1; }
                    else { contador = 1; Tablero[6, 5] = 2; }
                    break;

                case "F7_C7":
                    if (contador == 1) { contador = 2; Tablero[6, 6] = 1; }
                    else { contador = 1; Tablero[6, 6] = 2; }
                    break;

                case "F7_C8":
                    if (contador == 1) { contador = 2; Tablero[6, 7] = 1; }
                    else { contador = 1; Tablero[6, 7] = 2; }
                    break;

                case "F8_C1":
                    if (contador == 1) { contador = 2; Tablero[7, 0] = 1; }
                    else { contador = 1; Tablero[7, 0] = 2; }
                    break;

                case "F8_C2":
                    if (contador == 1) { contador = 2; Tablero[7, 1] = 1; }
                    else { contador = 1; Tablero[7, 1] = 2; }
                    break;

                case "F8_C3":
                    if (contador == 1) { contador = 2; Tablero[7, 2] = 1; }
                    else { contador = 1; Tablero[7, 2] = 2; }
                    break;

                case "F8_C4":
                    if (contador == 1) { contador = 2; Tablero[7, 3] = 1; }
                    else { contador = 1; Tablero[7, 3] = 2; }
                    break;

                case "F8_C5":
                    if (contador == 1) { contador = 2; Tablero[7, 4] = 1; }
                    else { contador = 1; Tablero[7, 4] = 2; }
                    break;

                case "F8_C6":
                    if (contador == 1) { contador = 2; Tablero[7, 5] = 1; }
                    else { contador = 1; Tablero[7, 5] = 2; }
                    break;

                case "F8_C7":
                    if (contador == 1) { contador = 2; Tablero[7, 6] = 1; }
                    else { contador = 1; Tablero[7, 6] = 2; }
                    break;

                case "F8_C8":
                    if (contador == 1) { contador = 2; Tablero[7, 7] = 1; }
                    else { contador = 1; Tablero[7, 7] = 2; }
                    break;
            }
            Cambiarcolor();
        }

    }
}