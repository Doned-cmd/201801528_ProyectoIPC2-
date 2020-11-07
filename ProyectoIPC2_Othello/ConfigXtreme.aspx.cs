using System;
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

        static public int[,] Tablero;
        static public Button[,] TableroBotones;
        int colores1 = 0;
        int colores2 = 0;

        bool unavez = true;

        public static ListaDobleCircular ColoresJ1;
        public static ListaDobleCircular ColoresJ2;
        public static int filas;
        public static int columnas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (unavez)
            {
                ListaDobleCircular ColoresJ1 = new ListaDobleCircular();
                ListaDobleCircular ColoresJ2 = new ListaDobleCircular();
                unavez = false;
            }
        }

   
        protected void IniciarPartida_Click(object sender, EventArgs e)
        {            

            try
            {
                filas = Int32.Parse(Filas.Text);
                columnas = Int32.Parse(Columnas.Text);      
                
                if ((filas <= 20) & (columnas <= 20) & (colores1 > 0) & (colores2 > 0)) {

                    Tablero = new int[filas,columnas];
                    TableroBotones = new Button[filas, columnas];
                    for (int x = 0; x < filas; x++) {
                        for (int y = 0; y < columnas; y++)
                        {
                            Tablero[x, y] = 0;                            
                        }
                    }
                    Response.Redirect("OthelloXtreme.aspx");
                }
            }
            catch (FormatException){}            
        }

        protected void Rojo_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton.ID == "Rojo1")
            {
                if (colores1 < 6){
                    ColoresJ1.addLast(Color.Red);
                    colores1++;
                    Rojo1.Enabled = false;
                    Rojo2.Enabled = false;
                }
            }
            else if (boton.ID == "Rojo2")
            {
                if (colores2 < 6){
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
            if (boton.ID == "Blanco1") {
                if (colores1 < 6) {
                    ColoresJ1.addLast(Color.White);
                    colores1++;
                    Blanco1.Enabled = false;
                    Blanco2.Enabled = false;
                }
            }
            else if (boton.ID == "Blanco2") {
                if (colores2 < 6) {
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
            if (boton.ID == "Azul1") {
                if (colores1 < 6) {
                    ColoresJ1.addLast(Color.Blue);
                    colores1++;
                    Azul1.Enabled = false;
                    Azul2.Enabled = false;
                }
            }
            else if (boton.ID == "Azul2") {
                if (colores2 < 6) {
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
            if (boton.ID == "Negro1") {

                if (colores1 < 6) {
                    ColoresJ1.addLast(Color.Black);
                    colores1++;
                    Negro1.Enabled = false;
                    Negro2.Enabled = false;
                }
            }
            else if (boton.ID == "Negro2") {

                if (colores2 < 6) {
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
            if (boton.ID == "Verde1") {
                if (colores1 < 6) {
                    ColoresJ1.addLast(Color.Green);
                    colores1++;
                    Verde1.Enabled = false;
                    Verde2.Enabled = false;
                }
            }
            else if (boton.ID == "Verde2") {
                if (colores2 < 6) {
                    ColoresJ2.addLast(Color.Green);
                    colores2++;
                    Verde1.Enabled = false;
                    Verde2.Enabled = false;
                }
            }
            
        }

        protected void Amarillo_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if(boton.ID == "Amarillo1") {
                if (colores1 < 6) {
                    ColoresJ1.addLast(Color.Yellow);
                    colores1++;
                    Amarillo1.Enabled = false;
                    Amarillo2.Enabled = false;
                }
            }
            else if (boton.ID == "Amarillo2") {
                if (colores2 < 6) {
                    ColoresJ2.addLast(Color.Yellow);
                    colores2++;
                    Amarillo1.Enabled = false;
                    Amarillo2.Enabled = false;
                }
            }
        }
    }


    public class ListaDobleCircular{

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
            Nodo nuevo = new Nodo(data,null,null);
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
                Nodo nuevo = new Nodo(data,null,null);
                nuevo.setNext(head);
                nuevo.setBack(end);
                head.setBack(nuevo);
                end.setNext(nuevo);
                end = nuevo;
                size++;
            }
        }

        public Boolean remove(Color data)
        {
            Nodo value = search(data);
            if (value != null)
            {
                if (size == 1)
                {
                    head = null;
                    end = null;
                }
                else if (value == head)
                {
                    head = head.getNext();
                    head.setBack(end);
                    end.setNext(head);
                }
                else if (value == end)
                {
                    end = end.getBack();
                    end.setNext(head);
                    head.setBack(end);
                }
                else
                {
                    value.getBack().setNext(value.getNext());
                    value.getNext().setBack(value.getBack());
                }
                size--;
                return true;
            }
            return false;
        }

        public Nodo search(Color data)
        {
            if (!isEmpty())
            {
                Nodo aux = head;
                do
                {
                    if (aux.getData().ToArgb().CompareTo(data.ToArgb()) == 0)
                    {
                        return aux;
                    }
                    aux = aux.getNext();
                } while (aux != head);
            }
            return null;
        }

        public Nodo searchIndex(int index)
        {
            int contador = 0;
            if (!isEmpty())
            {
                Nodo aux = head;
                while (contador < index) {
                    aux = aux.getNext();
                }
                return aux;
            }
            return null;
        }     
    }

    public class Nodo {

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