using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProyectoIPC2_Othello
{
    public partial class CargarPartidaX : System.Web.UI.Page
    {        
        static public int[,] Tablerox;
        static public int[,] TableroCambiarColorx;
        public static Color[,] Tablerocolores;
        static public Button[,] TableroBotonesx;
        public static Panel[,] TableroPanelesx;
        public static ListaDobleCircular ColoresJ1 = new ListaDobleCircular();
        public static ListaDobleCircular ColoresJ2 = new ListaDobleCircular();        
        protected void Page_Load(object sender, EventArgs e)
        {
            string datos = "";
            // CargarXML(datos);
            //Response.Redirect("Juego.aspx");
        }

        public void CargarXML(XmlDocument datos)
        {
            XmlDocument DocumentoXml = datos;
            //DocumentoXml.Load(datos);
            


            XmlNodeList partida = DocumentoXml.GetElementsByTagName("partida");
            foreach (XmlElement nodoPartida in partida)
            {

                XmlNodeList filas = ((XmlElement)nodoPartida).GetElementsByTagName("filas");
                XmlNodeList columnas = ((XmlElement)nodoPartida).GetElementsByTagName("columnas");

                XmlNodeList jugador1 = ((XmlElement)nodoPartida).GetElementsByTagName("Jugador1");
                XmlNodeList jugador2 = ((XmlElement)nodoPartida).GetElementsByTagName("Jugador2");
                XmlNodeList modalidad = ((XmlElement)nodoPartida).GetElementsByTagName("Modalidad");
                XmlNodeList tablero = ((XmlElement)nodoPartida).GetElementsByTagName("tablero");

                Othello_Xtreme.filas = Int32.Parse(filas[0].InnerText);
                Othello_Xtreme.columnas = Int32.Parse(columnas[0].InnerText);


                Tablerox = new int[Othello_Xtreme.filas, Othello_Xtreme.columnas];
                TableroBotonesx = new Button[Othello_Xtreme.filas, Othello_Xtreme.columnas];
                TableroCambiarColorx = new int[Othello_Xtreme.filas, Othello_Xtreme.columnas];
                TableroPanelesx = new Panel[Othello_Xtreme.filas, Othello_Xtreme.columnas];
                Tablerocolores = new Color[Othello_Xtreme.filas, Othello_Xtreme.columnas];


                foreach (XmlElement nodoJugador1 in jugador1) {
                    XmlNodeList color = ((XmlElement)nodoJugador1).GetElementsByTagName("color");

                    foreach (XmlElement nodoColor in color)
                    {
                        Color colorx = new Color();
                        if (nodoColor.InnerText == "rojo") { colorx = Color.Red; }
                        else if (nodoColor.InnerText == "amarillo") { colorx = Color.Yellow; }
                        else if (nodoColor.InnerText == "azul") { colorx = Color.Blue; }
                        else if (nodoColor.InnerText == "anaranjado") { colorx = Color.Orange; }
                        else if (nodoColor.InnerText == "verde") { colorx = Color.Green; }
                        else if (nodoColor.InnerText == "violeta") { colorx = Color.Violet; }
                        else if (nodoColor.InnerText == "blanco") { colorx = Color.White; }
                        else if (nodoColor.InnerText == "negro") { colorx = Color.Black; }
                        else if (nodoColor.InnerText == "celeste") { colorx = Color.SkyBlue; }
                        else if (nodoColor.InnerText == "gris") { colorx = Color.Gray; }

                        ColoresJ1.addLast(colorx);
                    }
                }


                foreach (XmlElement nodoJugador2 in jugador2) {
                    XmlNodeList color = ((XmlElement)nodoJugador2).GetElementsByTagName("color");

                    foreach (XmlElement nodoColor in color)
                    {
                        Color colorx = new Color();
                        if (nodoColor.InnerText == "rojo") { colorx = Color.Red; }
                        else if (nodoColor.InnerText == "amarillo") { colorx = Color.Yellow; }
                        else if (nodoColor.InnerText == "azul") { colorx = Color.Blue; }
                        else if (nodoColor.InnerText == "anaranjado") { colorx = Color.Orange; }
                        else if (nodoColor.InnerText == "verde") { colorx = Color.Green; }
                        else if (nodoColor.InnerText == "violeta") { colorx = Color.Violet; }
                        else if (nodoColor.InnerText == "blanco") { colorx = Color.White; }
                        else if (nodoColor.InnerText == "negro") { colorx = Color.Black; }
                        else if (nodoColor.InnerText == "celeste") { colorx = Color.SkyBlue; }
                        else if (nodoColor.InnerText == "gris") { colorx = Color.Gray; }

                        ColoresJ2.addLast(colorx);
                    }
                }

                foreach (XmlElement nodoModalidad in modalidad) { }

                foreach (XmlElement nodoTablero in tablero)
                {
                    XmlNodeList ficha = ((XmlElement)nodoTablero).GetElementsByTagName("ficha");
                    XmlNodeList siguienteTiro = ((XmlElement)nodoTablero).GetElementsByTagName("siguienteTiro");

                    foreach (XmlElement nodoficha in ficha)
                    {

                        int column = 0;
                        int fil = 0;
                        int colour = 0;

                        XmlNodeList color = nodoficha.GetElementsByTagName("color");
                        XmlNodeList columna = nodoficha.GetElementsByTagName("columna");
                        XmlNodeList fila = nodoficha.GetElementsByTagName("fila");


                        Color colorx = new Color();
                        if (color[0].InnerText == "rojo") { colorx = Color.Red; }
                        else if (color[0].InnerText == "amarillo") { colorx = Color.Yellow; }
                        else if (color[0].InnerText == "azul") { colorx = Color.Blue; }
                        else if (color[0].InnerText == "anaranjado") { colorx = Color.Orange; }
                        else if (color[0].InnerText == "verde") { colorx = Color.Green; }
                        else if (color[0].InnerText == "violeta") { colorx = Color.Violet; }
                        else if (color[0].InnerText == "blanco") { colorx = Color.White; }
                        else if (color[0].InnerText == "negro") { colorx = Color.Black; }
                        else if (color[0].InnerText == "celeste") { colorx = Color.SkyBlue; }
                        else if (color[0].InnerText == "gris") { colorx = Color.Gray; }

                        if (ColoresJ1.search(colorx)) { colour = 1; }
                        else if (ColoresJ2.search(colorx)) { colour = 2; }                        


                        if (columna[0].InnerText == "A") { column = 0; }
                        else if (columna[0].InnerText == "B") { column = 1; }
                        else if (columna[0].InnerText == "C") { column = 2; }
                        else if (columna[0].InnerText == "D") { column = 3; }
                        else if (columna[0].InnerText == "E") { column = 4; }
                        else if (columna[0].InnerText == "F") { column = 5; }
                        else if (columna[0].InnerText == "G") { column = 6; }
                        else if (columna[0].InnerText == "H") { column = 7; }
                        else if (columna[0].InnerText == "I") { column = 8; }
                        else if (columna[0].InnerText == "J") { column = 9; }
                        else if (columna[0].InnerText == "K") { column = 10; }
                        else if (columna[0].InnerText == "L") { column = 11; }
                        else if (columna[0].InnerText == "M") { column = 12; }
                        else if (columna[0].InnerText == "N") { column = 13; }
                        else if (columna[0].InnerText == "O") { column = 14; }
                        else if (columna[0].InnerText == "P") { column = 15; }
                        else if (columna[0].InnerText == "Q") { column = 16; }
                        else if (columna[0].InnerText == "R") { column = 17; }
                        else if (columna[0].InnerText == "S") { column = 18; }
                        else if (columna[0].InnerText == "T") { column = 19; }
                        else { column = 20; }


                        fil = Int32.Parse(fila[0].InnerText) - 1;


                        if ((column != 20) & (colour != 3) & (fil < 20) & (fil >= 0))
                        {
                            Tablerox[fil, column] = colour;
                            Tablerocolores[fil, column] = colorx;
                            TableroCambiarColorx[fil, column] = 0;
                        }
                    }

                    foreach (XmlElement nodosiguienteTiro in siguienteTiro)
                    {
                        XmlNodeList colorS = nodosiguienteTiro.GetElementsByTagName("color");

                        Color color = new Color();
                        if (colorS[0].InnerText == "rojo") { color = Color.Red; }
                        else if (colorS[0].InnerText == "amarillo") { color = Color.Yellow; }
                        else if (colorS[0].InnerText == "azul") { color = Color.Blue; }
                        else if (colorS[0].InnerText == "anaranjado") { color = Color.Orange; }
                        else if (colorS[0].InnerText == "verde") { color = Color.Green; }
                        else if (colorS[0].InnerText == "violeta") { color = Color.Violet; }
                        else if (colorS[0].InnerText == "blanco") { color = Color.White; }
                        else if (colorS[0].InnerText == "negro") { color = Color.Black; }
                        else if (colorS[0].InnerText == "celeste") { color = Color.SkyBlue; }
                        else if (colorS[0].InnerText == "gris") { color = Color.Gray; }



                        if (ColoresJ1.search(color)) { Othello_Xtreme.TurnoJugador = 1; }
                        else if (ColoresJ2.search(color)) { Othello_Xtreme.TurnoJugador = 2; }
                    }

                }
            }



            


            //Arreglar tablero

            for (int i = 0; i < Othello_Xtreme.filas; i++)
            {
                for (int j = 0; j < Othello_Xtreme.columnas; j++)
                {
                    if ((Tablerox[i, j] == 1) || (Tablerox[i, j] == 2)) { }
                    else { Tablerox[i, j] = 0; Tablerocolores[i, j] = Color.Brown; TableroCambiarColorx[i, j] = 1; }
                }
            }

            for (int i = 0; i < Othello_Xtreme.filas; i++)
            {
                for (int j = 0; j < Othello_Xtreme.columnas; j++)
                {
                                      
                    if ((Tablerox[i, j] == 1) || (Tablerox[i, j] == 2))
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if ((Tablerox[i + 1, j] != 0) || (Tablerox[i, j + 1] != 0) || (Tablerox[i + 1, j + 1] != 0)) { }
                                else { Tablerox[i, j] = 0; }
                            }
                            else if (j == 7)
                            {
                                if ((Tablerox[i + 1, j] != 0) || (Tablerox[i, j - 1] != 0) || (Tablerox[i + 1, j - 1] != 0)) { }
                                else { Tablerox[i, j] = 0; }
                            }
                            else
                            {
                                if ((Tablerox[i + 1, j] != 0) || (Tablerox[i, j - 1] != 0) || (Tablerox[i + 1, j - 1] != 0) || (Tablerox[i, j + 1] != 0) || (Tablerox[i + 1, j + 1] != 0)) { }
                                else { Tablerox[i, j] = 0; }
                            }
                        }
                        else if (i == 7)
                        {
                            if (j == 0)
                            {
                                if ((Tablerox[i - 1, j] != 0) || (Tablerox[i, j + 1] != 0) || (Tablerox[i - 1, j + 1] != 0)) { }
                                else { Tablerox[i, j] = 0; }
                            }
                            else if (j == 7)
                            {
                                if ((Tablerox[i - 1, j] != 0) || (Tablerox[i, j - 1] != 0) || (Tablerox[i - 1, j - 1] != 0)) { }
                                else { Tablerox[i, j] = 0; }
                            }
                            else
                            {
                                if ((Tablerox[i - 1, j] != 0) || (Tablerox[i, j - 1] != 0) || (Tablerox[i - 1, j - 1] != 0) || (Tablerox[i, j + 1] != 0) || (Tablerox[i - 1, j + 1] != 0)) { }
                                else { Tablerox[i, j] = 0; }
                            }
                        }

                        else if (j == 0)
                        {
                            if ((Tablerox[i + 1, j] != 0) || (Tablerox[i - 1, j] != 0) || (Tablerox[i - 1, j + 1] != 0) || (Tablerox[i + 1, j + 1] != 0) || (Tablerox[i, j + 1] != 0)) { }
                            else { Tablerox[i, j] = 0; }
                        }

                        else if (j == 7)
                        {
                            if ((Tablerox[i + 1, j] != 0) || (Tablerox[i - 1, j] != 0) || (Tablerox[i - 1, j - 1] != 0) || (Tablerox[i + 1, j - 1] != 0) || (Tablerox[i, j - 1] != 0)) { }
                            else { Tablerox[i, j] = 0; }
                        }
                        else
                        {
                            if ((Tablerox[i + 1, j] != 0) || (Tablerox[i - 1, j] != 0) || (Tablerox[i, j + 1] != 0) || (Tablerox[i, j - 1] != 0) || (Tablerox[i + 1, j + 1] != 0) || (Tablerox[i - 1, j - 1] != 0) || (Tablerox[i + 1, j - 1] != 0) || (Tablerox[i - 1, j + 1] != 0)) { }
                            else { Tablerox[i, j] = 0; }
                        }
                    }
                }
            }
            Othello_Xtreme.Tablero = Tablerox;
            Othello_Xtreme.TableroBottones = TableroBotonesx;
            Othello_Xtreme.TableroCambiarColor = TableroCambiarColorx;
            Othello_Xtreme.TableroPaneles = TableroPanelesx;
            Othello_Xtreme.Tablerocolores = Tablerocolores;

            Othello_Xtreme.ColoresJ1 = ColoresJ1;
            Othello_Xtreme.ColoresJ2 = ColoresJ2;            
        }

        protected void Cargar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //string filename = Path.GetFileName(fileUpload.FileName);
            //fileUpload.SaveAs(Server.MapPath("~/") + filename);
            //CargarXML("D:/Escritorio/USAC/IPC 2/Semestre 2/Desarollo Proyecto/Proyecto con web forms/ProyectoIPC2_Othello/XML/Documento.xml");


            //CargarXML(Path.GetFileName());
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(fileUpload.FileContent);
            CargarXML(myDoc);
            Othello_Xtreme.haycolores = true;
            Response.Redirect("OthelloXtreme.aspx");          

            //}
            //catch (Exception ex)
            //{

            //}
            //CargarXML(fileUpload.FileName);
            //Response.Redirect("Juego.aspx");

        }
    }
}