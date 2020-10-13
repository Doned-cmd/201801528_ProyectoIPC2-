using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProyectoIPC2_Othello
{
    public partial class CargarPartida : System.Web.UI.Page
    {
        static public int[,] Tablero = new int[8, 8];
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
            XmlNodeList tablero = DocumentoXml.GetElementsByTagName("tablero");
            foreach (XmlElement nodoTablero in tablero)
            {
                XmlNodeList  ficha = ((XmlElement)nodoTablero).GetElementsByTagName("ficha");
                XmlNodeList siguienteTiro = ((XmlElement)nodoTablero).GetElementsByTagName("siguienteTiro");

                foreach (XmlElement nodoficha in ficha)
                {

                    int column = 0;
                    int fil = 0;
                    int colour = 0;

                    XmlNodeList color = nodoficha.GetElementsByTagName("color");
                    XmlNodeList columna = nodoficha.GetElementsByTagName("columna");
                    XmlNodeList fila = nodoficha.GetElementsByTagName("fila");

                    if (color[0].InnerText == "blanco") { colour = 1; }
                    else if (color[0].InnerText == "negro") { colour = 2; }
                    else { colour = 3; }

                    if (columna[0].InnerText == "A") { column = 0; }
                    else if (columna[0].InnerText == "B") { column = 1; }
                    else if (columna[0].InnerText == "C") { column = 2; }
                    else if (columna[0].InnerText == "D") { column = 3; }
                    else if (columna[0].InnerText == "E") { column = 4; }
                    else if (columna[0].InnerText == "F") { column = 5; }
                    else if (columna[0].InnerText == "G") { column = 6; }
                    else if (columna[0].InnerText == "H") { column = 7; }
                    else { column = 9; }


                    fil = Int32.Parse(fila[0].InnerText) -1;


                    if ((column != 9) & (colour != 3) & (fil < 8) & (fil >= 0)) {
                        Tablero[fil, column] = colour; }
                }
                foreach (XmlElement nodosiguienteTiro in siguienteTiro) 
                {
                    XmlNodeList colorS = nodosiguienteTiro.GetElementsByTagName("color");

                    if (colorS[0].InnerText == "blanco") { Inicio.contador = 1; }
                    else if (colorS[0].InnerText == "negro") { Inicio.contador = 2; }
                }

            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((Tablero[i, j] == 1) || (Tablero[i, j] == 2)) { }
                    else { Tablero[i, j] = 0; }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((Tablero[i, j] == 1) || (Tablero[i, j] == 2))
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if ((Tablero[i + 1, j] != 0) || (Tablero[i, j + 1] != 0) || (Tablero[i + 1, j + 1] != 0)) { }
                                else { Tablero[i, j] = 0; }
                            }
                            else if (j == 7) {
                                if ((Tablero[i + 1, j] != 0) || (Tablero[i, j - 1] != 0) || (Tablero[i + 1, j - 1] != 0)) { }
                                else { Tablero[i, j] = 0; }
                            }
                            else {
                                if ((Tablero[i + 1, j] != 0) || (Tablero[i, j - 1] != 0) || (Tablero[i + 1, j - 1] != 0) || (Tablero[i, j + 1] != 0) || (Tablero[i + 1, j + 1] != 0)) { }
                                else { Tablero[i, j] = 0; }
                            }
                        }
                        else if (i == 7)
                        {
                            if (j == 0) {
                                if ((Tablero[i - 1, j] != 0) || (Tablero[i, j + 1] != 0) || (Tablero[i - 1, j + 1] != 0)) { }
                                else { Tablero[i, j] = 0; }
                            }
                            else if (j == 7) {
                                if ((Tablero[i - 1, j] != 0) || (Tablero[i, j - 1] != 0) || (Tablero[i - 1, j - 1] != 0)) { }
                                else { Tablero[i, j] = 0; }
                            }
                            else {
                                if ((Tablero[i - 1, j] != 0) || (Tablero[i, j - 1] != 0) || (Tablero[i - 1, j - 1] != 0) || (Tablero[i, j + 1] != 0) || (Tablero[i - 1, j + 1] != 0)) { }
                                else { Tablero[i, j] = 0; }
                            }
                        }

                        else if (j == 0) {
                            if ((Tablero[i + 1, j] != 0) || (Tablero[i - 1, j] != 0) || (Tablero[i - 1, j + 1] != 0) || (Tablero[i + 1, j + 1] != 0) || (Tablero[i, j + 1] != 0)) { }
                            else { Tablero[i, j] = 0; }
                        }

                        else if (j == 7) {
                            if ((Tablero[i + 1, j] != 0) || (Tablero[i - 1, j] != 0) || (Tablero[i - 1, j - 1] != 0) || (Tablero[i + 1, j - 1] != 0) || (Tablero[i, j - 1] != 0)) { }
                            else { Tablero[i, j] = 0; }
                        }
                        else {
                            if ((Tablero[i + 1, j] != 0) || (Tablero[i - 1, j] != 0) || (Tablero[i, j + 1] != 0) || (Tablero[i, j - 1] != 0) || (Tablero[i + 1, j + 1] != 0) || (Tablero[i - 1, j - 1] != 0)  || (Tablero[i + 1, j - 1] != 0) || (Tablero[i - 1, j + 1] != 0)) { }
                            else { Tablero[i, j] = 0; }
                        }
                    }
                }
            }
           
            Inicio.Tablero = Tablero;
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

            if(Session["TipoP"].ToString() == "J") { Response.Redirect("Juego.aspx"); }
            else if (Session["TipoP"].ToString() == "M") { Response.Redirect("JuegoContraMaquina.aspx"); }
            
            //}
            //catch (Exception ex)
            //{
               
            //}
            //CargarXML(fileUpload.FileName);
            //Response.Redirect("Juego.aspx");

        }
    }
}