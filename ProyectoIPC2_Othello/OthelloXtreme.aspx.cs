﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProyectoIPC2_Othello
{
    public partial class Othello_Xtreme : System.Web.UI.Page
    {

        //Tablero
        public int[,] Tablero = ConfigXtreme.Tablero;
        public Button[,] TableroBottones = ConfigXtreme.TableroBotones;
        int ContarHastaTurno4;
        int columas = ConfigXtreme.columnas;
        int filas = ConfigXtreme.filas;
        //Guardar xml
        static int xmlcounter = 0;

        //Guardar los datos del usuario
        string[] usuarios;

        //Turnos
        static public bool Nohayjugadasposibles = false;
        private bool NohayturnoLocal = false, NohayturnoInv = false;
        static public int TurnoJugador;
        private static int primermovimiento;
        private static int turnosllevadosxJ1, turnosllevadosxJ2;

        //Puntuacion
        static int puntajejugador1, puntajejugador2, casillasrestantes;
        static string ganador;

        //Turnos random
        private static Random random = new Random();

        //Iniciar las variables una sola vez
        public static bool keyonce = true;



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
                Response.Redirect("Juego.aspx");
            }
            else if (textoNodo == "Inicio") { Response.Redirect("Inicio.aspx"); }
            else if (textoNodo == "Jugar contra máquina")
            {

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != "") { Response.Redirect("Login.aspx"); }
            else
            {
                usuarios = (string[])Session["Usuario"];



                if (keyonce)
                {
                    //inicar variables
                    primermovimiento = random.Next(1, 3);
                    TurnoJugador = Inicio.contador;
                    Tablero = Inicio.Tablero;
                    NohayturnoLocal = false;
                    NohayturnoInv = false;
                    keyonce = false;
                    turnosllevadosxJ1 = 0;
                    turnosllevadosxJ2 = 0;
                    Terminado.Text = "";
                    TurnoActual.Text = "";
                    //Comprobar si hay movimientos posibles la primera ronda
                    validarTurnoCompleto(TurnoJugador);


                    //inicar tablero
                    for (int x = 0; x < columas; x++)
                    {
                        for (int y = 0; y < filas; y++)
                        {

                        }
                    }

                }




                if (primermovimiento == 1)
                {
                    if (TurnoJugador == 1) { TurnoActual.Text = "Turno del jugador invitado, Fichas blancas"; }
                    else if (TurnoJugador == 2) { TurnoActual.Text = "Turno del jugador: " + usuarios[5].ToString() + " ,Fichas negras"; }


                }
                else if (primermovimiento == 2)
                {
                    if (TurnoJugador == 2) { TurnoActual.Text = "Turno del jugador invitado, Fichas negras"; }
                    else if (TurnoJugador == 1) { TurnoActual.Text = "Turno del jugador: " + usuarios[5].ToString() + " ,Fichas blancas"; }
                }




                if (Nohayjugadasposibles) { ContarPuntaje(); ganadort(); }

                Cambiarcolor();
            }
        }

        public void Cambiarcolor()
        {                               

        }



        public void validarTurnoCompleto(int turnoJugador)
        {
            //validar con los dos jugadores si hay turnos posibles
            bool flagci = false;
            int sw1 = 0;
            int sw2 = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Tablero[i, j] == 0)
                    {
                        if (primermovimiento == 1)
                        {

                            if (sw1 == 0)
                            {

                                if (ValidarJuego(i, j, turnoJugador)) { NohayturnoLocal = false; sw1 = 1; }
                                else { NohayturnoLocal = true; }
                            }
                            if (sw2 == 0)
                            {
                                if (ValidarJuego(i, j, turnoJugador - 1)) { NohayturnoInv = false; sw2 = 1; }
                                else { NohayturnoInv = true; }
                            }
                            if (sw1 != 0 && sw2 != 0) { flagci = true; break; }
                        }


                        else if (primermovimiento == 2)
                        {

                            if (sw1 == 0)
                            {

                                if (ValidarJuego(i, j, turnoJugador)) { NohayturnoInv = false; sw1 = 1; }
                                else { NohayturnoInv = true; }
                            }
                            if (sw2 == 0)
                            {
                                if (ValidarJuego(i, j, turnoJugador - 1)) { NohayturnoLocal = false; sw2 = 1; }
                                else { NohayturnoLocal = true; }
                            }
                            if (sw1 != 0 && sw2 != 0) { flagci = true; break; }
                        }
                    }


                }
                if (flagci) { break; }
            }

            //validar el punteo
            ContarPuntaje();

            //si ya no hay movimientos posibles o algun jugador no cuenta con movimientos
            if (NohayturnoInv && NohayturnoLocal) { Nohayjugadasposibles = true; }

            else if (primermovimiento == 1)
            {
                if (NohayturnoLocal) { TurnoJugador = 1; NohayturnoLocal = false; }
            }
            else if (primermovimiento == 2)
            {
                if (NohayturnoInv) { TurnoJugador = 1; NohayturnoInv = false; }
            }

            //Mostrar quien gano
            if (Nohayjugadasposibles)
            { ganadort(); }

        }



        protected void Guardar_Click(object sender, EventArgs e)
        {
            string NombrePath = "C:/Users/bryan/Desktop/Proyecto IPC2/Proyecto con web forms/ProyectoIPC2_Othello/XML/" + "Partida-" + usuarios[5] + xmlcounter + ".xml";
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

                        ficha.Add(new XElement("color", "blanco"));
                        ficha.Add(new XElement("columna", column));
                        ficha.Add(new XElement("fila", Fil + ""));
                        nodoRaiz.Add(ficha);
                    }
                    else if (Tablero[f, c] == 2)
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
                        ficha.Add(new XElement("fila", Fil + ""));
                        nodoRaiz.Add(ficha);
                    }
                }
            }

            XElement siguienteTiro = new XElement("siguienteTiro");
            if (TurnoJugador == 1) { siguienteTiro.Add(new XElement("color", "blanco")); }
            else if (TurnoJugador == 2) { siguienteTiro.Add(new XElement("color", "negro")); }
            nodoRaiz.Add(siguienteTiro);
            document.Save(NombrePath);
        }

        protected void Boton_click(object sender, EventArgs e)
        {

            Button boton = sender as Button;



            if (primermovimiento == 1)
            {
                int turnoJugador = TurnoJugador;
                if (TurnoJugador == 2)
                {
                    selectcolor(boton);
                    Cambiarcolor();
                    turnosllevadosxJ1 += 1;
                    validarTurnoCompleto(turnoJugador);
                }
                else if (TurnoJugador == 1)
                {
                    selectcolor(boton);
                    Cambiarcolor();
                    turnosllevadosxJ2 += 1;
                    validarTurnoCompleto(TurnoJugador);
                }
            }
            if (primermovimiento == 2)
            {
                int turnoJugador = TurnoJugador;
                if (TurnoJugador == 1)
                {
                    selectcolor(boton);
                    Cambiarcolor();
                    turnosllevadosxJ1 += 1;
                    validarTurnoCompleto(TurnoJugador);
                }
                else if (TurnoJugador == 2)
                {
                    selectcolor(boton);
                    Cambiarcolor();
                    turnosllevadosxJ2 += 1;
                    validarTurnoCompleto(turnoJugador);

                }
            }



            //Mostrar de quien es el turno

            if (primermovimiento == 1)
            {
                if (TurnoJugador == 1) { TurnoActual.Text = "Turno del jugador invitado" + ", Fichas blancas"; }
                else if (TurnoJugador == 2) { TurnoActual.Text = "Turno del jugador: " + usuarios[5].ToString() + ", Fichas negras"; }


            }
            else if (primermovimiento == 2)
            {
                if (TurnoJugador == 2) { TurnoActual.Text = "Turno del jugador invitado , Fichas negras"; }
                else if (TurnoJugador == 1) { TurnoActual.Text = "Turno del jugador: " + usuarios[5].ToString() + ", Fichas blancas"; }
            }


            Cambiarcolor();
        }

        protected void Pasar_click(object sender, EventArgs e)
        {
            if (primermovimiento == 1)
            {
                if (TurnoJugador == 1)
                {
                    //if (Maquina()) { }
                    //else { validarTurnoCompleto(TurnoJugador); }
                }
            }
            else if (primermovimiento == 2)
            {
                if (TurnoJugador == 2)
                {
                    //if (Maquina()) { TurnoJugador = 1; }
                    //else { validarTurnoCompleto(TurnoJugador); }

                }
            }

            //Mostrar de quien es el turno

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

        protected void Registrar_partida(string resultado, int movimientos, int id)
        {
            string connectionString = @"Data Source=BRYANMENDEZ\SQLEXPRESS; Initial Catalog = ProyectoIPC2_othello; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string carga = "insert into PARTIDA (tipo,resultado,movimientos,usuario) values ('" + "Juego Contra Maquina" + "','" + resultado + "'," + movimientos + "," + id + ");";

                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(carga, sqlCon);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }
        }


        protected void ganadort()
        {
            if (puntajejugador1 > puntajejugador2)
            {
                if (primermovimiento == 2) { ganador = "El ganador fue " + usuarios[5].ToString(); Registrar_partida("Gano", turnosllevadosxJ1, Int32.Parse(usuarios[0])); }
                else if (primermovimiento == 1) { ganador = "El ganador fue " + "Invitado"; Registrar_partida("Perdio", turnosllevadosxJ1, Int32.Parse(usuarios[0])); }
            }
            else if (puntajejugador2 > puntajejugador1)
            {
                if (primermovimiento == 1) { ganador = "El ganador fue " + usuarios[5].ToString(); Registrar_partida("Gano", turnosllevadosxJ1, Int32.Parse(usuarios[0])); }
                else if (primermovimiento == 2) { ganador = "El ganador fue " + "Invitado"; Registrar_partida("Perdio", turnosllevadosxJ1, Int32.Parse(usuarios[0])); }
            }
            else if (puntajejugador1 == puntajejugador2) { ganador = "El resultado fue un empate"; Registrar_partida("Empato", turnosllevadosxJ1, Int32.Parse(usuarios[0])); }
            Terminado.Text = "Ejecucion terminada. " + ganador + "";
        }


        protected void selectcolor(Button boton)
        {
            switch (boton.ID)
            {
                case "F1_C1":
                    if (Tablero[0, 0] == 0)
                    {
                        if (ValidarTurno(0, 0, TurnoJugador))
                        {
                            if (TurnoJugador == 1) { TurnoJugador = 2; Tablero[0, 0] = 1; }
                            else { TurnoJugador = 1; Tablero[0, 0] = 2; }
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
            casillasrestantes = vacio;
            if (vacio == 0) { Nohayjugadasposibles = true; }
        }


    }
}