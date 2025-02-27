﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIPC2_Othello
{
    public partial class ConfigXtreme : System.Web.UI.Page
    {
        static public int[,] Tablerox;
        static public int[,] TableroCambiarColorx;
        static public Button[,] TableroBotonesx;
        public static Panel[,] TableroPanelesx;
        public static bool aperturaper = true;
        public static bool rInverso = true;
        static int colores1 = 0;
        static int colores2 = 0;

        static bool unavez = true;

        public static ListaDobleCircular ColoresJ1 = new ListaDobleCircular();
        public static ListaDobleCircular ColoresJ2 = new ListaDobleCircular();
        public static int filas;
        public static int columnas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (unavez)
            {
                ColoresJ1 = new ListaDobleCircular();
                ColoresJ2 = new ListaDobleCircular();
                AperturaN.Enabled = true;
                AperturaP.Enabled = false;
                RInverso.Enabled = false;
                RNormal.Enabled = true;
                unavez = false;
            }
        }


        protected void IniciarPartida_Click(object sender, EventArgs e)
        {

            try
            {
                filas = Int32.Parse(Filas.Text.ToString());
                columnas = Int32.Parse(Columnas.Text.ToString());

                if ((filas <= 20) & (columnas <= 20) & (filas >= 6) & (columnas >= 6) & (colores1 > 0) & (colores2 > 0) & (filas % 2 == 0) & (columnas % 2 == 0))
                {

                    Tablerox = new int[filas, columnas];
                    TableroCambiarColorx = new int[filas, columnas];
                    TableroBotonesx = new Button[filas, columnas];
                    TableroPanelesx = new Panel[filas, columnas];

                    for (int x = 0; x < filas; x++)
                    {
                        for (int y = 0; y < columnas; y++)
                        {
                            Tablerox[x, y] = 0;
                            TableroCambiarColorx[x, y] = 1;
                        }
                    }

                    if (!aperturaper) {
                        int mitadx = columnas / 2;
                        int mitady = filas / 2;

                        Tablerox[mitadx, mitady] = 2;
                        Tablerox[mitadx+1, mitady] = 1;
                        Tablerox[mitadx, mitady+1] = 1;
                        Tablerox[mitadx+1, mitady+1] = 2;
                    }

                    Othello_Xtreme.Tablero = Tablerox;
                    Othello_Xtreme.TableroBottones = TableroBotonesx;
                    Othello_Xtreme.TableroCambiarColor = TableroCambiarColorx;
                    Othello_Xtreme.TableroPaneles = TableroPanelesx;


                    Othello_Xtreme.aperturaper = aperturaper;
                    Othello_Xtreme.rInverso = rInverso;
                    Othello_Xtreme.columnas = columnas;
                    Othello_Xtreme.filas = filas;
                    Othello_Xtreme.ColoresJ1 = ColoresJ1;
                    Othello_Xtreme.ColoresJ2 = ColoresJ2;

                    
                    Response.Redirect("OthelloXtreme.aspx");
                }
            }
            catch (FormatException) { }
        }

        protected void Rojo_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Rojo1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Red);
                    colores1++;
                    Rojo1.Enabled = false;
                    Rojo2.Enabled = false;
                }
            }
            else if (boton.ID == "Rojo2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Red);
                    colores2++;
                    Rojo1.Enabled = false;
                    Rojo2.Enabled = false;
                }
            }
        }

        protected void Blanco_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Blanco1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.White);
                    colores1++;
                    Blanco1.Enabled = false;
                    Blanco2.Enabled = false;
                }
            }
            else if (boton.ID == "Blanco2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.White);
                    colores2++;
                    Blanco1.Enabled = false;
                    Blanco2.Enabled = false;
                }
            }
        }

        protected void Azul_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Azul1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Blue);
                    colores1++;
                    Azul1.Enabled = false;
                    Azul2.Enabled = false;
                }
            }
            else if (boton.ID == "Azul2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Blue);
                    colores2++;
                    Azul1.Enabled = false;
                    Azul2.Enabled = false;
                }
            }
        }

        protected void Negro_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Negro1")
            {

                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Black);
                    colores1++;
                    Negro1.Enabled = false;
                    Negro2.Enabled = false;
                }
            }
            else if (boton.ID == "Negro2")
            {

                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Black);
                    colores2++;
                    Negro1.Enabled = false;
                    Negro2.Enabled = false;
                }
            }
        }

        protected void Verde_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Verde1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Green);
                    colores1++;
                    Verde1.Enabled = false;
                    Verde2.Enabled = false;
                }
            }
            else if (boton.ID == "Verde2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Green);
                    colores2++;
                    Verde1.Enabled = false;
                    Verde2.Enabled = false;
                }
            }

        }

        protected void Anaranjado_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Anaranjado1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Orange);
                    colores1++;
                    Anaranjado1.Enabled = false;
                    Anaranjado2.Enabled = false;

                }
            }
            else if (boton.ID == "Anaranjado2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Orange);
                    colores2++;
                    Anaranjado1.Enabled = false;
                    Anaranjado2.Enabled = false;
                }
            }

        }


        protected void Violeta_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Violeta1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Violet);
                    colores1++;
                    Violeta1.Enabled = false;
                    Violeta2.Enabled = false;
                }
            }
            else if (boton.ID == "Violeta2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Violet);
                    colores2++;
                    Violeta1.Enabled = false;
                    Violeta2.Enabled = false;
                }
            }

        }

        protected void Amarillo_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton.ID == "Amarillo1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Yellow);
                    colores1++;
                    Amarillo1.Enabled = false;
                    Amarillo2.Enabled = false;
                }
            }
            else if (boton.ID == "Amarillo2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Yellow);
                    colores2++;
                    Amarillo1.Enabled = false;
                    Amarillo2.Enabled = false;
                }
            }
        }

        protected void Gris_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton.ID == "Gris1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.Gray);
                    colores1++;
                    Gris1.Enabled = false;
                    Gris2.Enabled = false;
                }
            }
            else if (boton.ID == "Gris2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.Gray);
                    colores2++;
                    Gris1.Enabled = false;
                    Gris2.Enabled = false;
                }
            }

        }

        protected void Celeste_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton.ID == "Celeste1")
            {
                if (colores1 < 6)
                {
                    ColoresJ1.addLast(Color.SkyBlue);
                    colores1++;
                    Celeste1.Enabled = false;
                    Celeste2.Enabled = false;
                }
            }
            else if (boton.ID == "Celeste2")
            {
                if (colores2 < 6)
                {
                    ColoresJ2.addLast(Color.SkyBlue);
                    colores2++;
                    Celeste1.Enabled = false;
                    Celeste2.Enabled = false;
                }
            }
        }

        protected void Apertura_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "AperturaN")
            {
                if (colores1 < 6)
                {
                    aperturaper = false;
                    AperturaN.Enabled = false;
                    AperturaP.Enabled = true;
                }
            }
            else if (boton.ID == "AperturaP")
            {
                if (colores2 < 6)
                {
                    aperturaper = true;
                    AperturaN.Enabled = true;
                    AperturaP.Enabled = false;
                }
            }
            else if (boton.ID == "RNormal")
            {
                if (colores2 < 6)
                {
                    rInverso = false;
                    RInverso.Enabled = true;
                    RNormal.Enabled = false;
                }
            }
            else if (boton.ID == "RInverso")
            {
                if (colores2 < 6)
                {
                    rInverso = true;
                    RInverso.Enabled = false;
                    RNormal.Enabled = true;
                }
            }
        }
    }


    public class ListaDobleCircular
    {

        private Nodo head;
        private Nodo end;
        private int size;

        public ListaDobleCircular()
        {
            this.head = null;
            this.end = null;
            this.size = 0;
        }

        public Nodo getHead()
        {
            return head;
        }

        public void setHead(Nodo head)
        {
            this.head = head;
        }

        public Nodo getEnd()
        {
            return end;
        }

        public void setEnd(Nodo end)
        {
            this.end = end;
        }

        public int getSize()
        {
            return size;
        }

        public void setSize(int size)
        {
            this.size = size;
        }

        public Boolean isEmpty()
        {
            return size == 0;
        }

        public void addFirst(Color data)
        {
            Nodo nuevo = new Nodo(data, null, null);
            if (isEmpty())
            {
                nuevo.setNext(nuevo);
                nuevo.setBack(nuevo);
                head = nuevo;
                end = nuevo;
            }
            else
            {
                nuevo.setNext(head);
                nuevo.setBack(end);
                head.setBack(nuevo);
                end.setNext(nuevo);
                head = nuevo;
            }
            size++;
        }

        public void addLast(Color data)
        {

            if (isEmpty())
            {
                addFirst(data);
            }
            else
            {
                Nodo nuevo = new Nodo(data, null, null);
                nuevo.setNext(head);
                nuevo.setBack(end);
                head.setBack(nuevo);
                end.setNext(nuevo);
                end = nuevo;
                size++;
            }
        }


        public bool search(Color data)
        {
            if (!isEmpty())
            {
                Nodo aux = head;
                do
                {
                    if (aux.getData().ToArgb().CompareTo(data.ToArgb()) == 0)
                    {
                        return true;
                    }
                    aux = aux.getNext();
                } while (aux != head);
            }
            return false;
        }

        public Nodo searchIndex(int index)
        {
            int contador = 0;
            if (!isEmpty())
            {
                Nodo aux = head;
                while (contador < index)
                {
                    aux = aux.getNext();
                    contador++;
                }
                return aux;
            }
            return null;
        }
    }

    public class Nodo
    {

        private Color data;
        private Nodo next;
        private Nodo back;

        public Nodo(Color data, Nodo next, Nodo back)
        {
            this.data = data;
            this.next = next;
            this.back = back;
        }

        //public Nodo(Color data)
        //{
        //    Nodo nuevo = new  Nodo(data, null, null);
        //}
        public Color getData()
        {
            return data;
        }

        public void setData(Color data)
        {
            this.data = data;
        }

        public Nodo getNext()
        {
            return next;
        }

        public void setNext(Nodo next)
        {
            this.next = next;
        }

        public Nodo getBack()
        {
            return back;
        }

        public void setBack(Nodo back)
        {
            this.back = back;
        }

    }


}