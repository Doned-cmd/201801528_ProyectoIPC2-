<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigXtreme.aspx.cs" Inherits="ProyectoIPC2_Othello.ConfigXtreme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="Estilos/Xtreme.css" type="text/css" rel="stylesheet" media=""/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
             <div class="ingTablero">
                <asp:TextBox runat="server" ID="Columnas" placeholder="Ingrese N. Columnas" CssClass ="TextoLogin"></asp:TextBox>
                <asp:TextBox runat="server" ID="Filas" placeholder="Ingrese N. Filas" CssClass ="TextoLogin" ></asp:TextBox>
            </div>
            
            <asp:Label ID="Label2" runat="server" Text="Colores Jugador 1" CssClass="Label2"></asp:Label>
            <div class ="izquierda">
            
                <asp:Button ID="Rojo1" runat="server" Text="Rojo" BackColor="Red" OnClick="Rojo_Click" CssClass="botonc" />
                <asp:Button ID="Blanco1" runat="server" Text="Blanco"  BackColor ="White" OnClick="Blanco_Click" CssClass="botonc"/>
                <asp:Button ID="Azul1" runat="server" Text="Azul"  BackColor ="Blue" OnClick="Azul_Click" CssClass="botonc"/>
                <asp:Button ID="Negro1" runat="server" Text="Negro"  BackColor ="Black" OnClick="Negro_Click" CssClass="botonc" ForeColor="White" BorderColor="Green"/>
                <asp:Button ID="Verde1" runat="server" Text="Verde"  BackColor ="Green" OnClick="Verde_Click" CssClass="botonc"/>
                <asp:Button ID="Amarillo1" runat="server" Text="Amarillo" BackColor ="Yellow" OnClick="Amarillo_Click" CssClass="botonc"/>
                <asp:Button ID="Anaranjado1" runat="server" Text="Anaranjado" BackColor ="Orange" OnClick="Anaranjado_Click" CssClass="botonc"/>
                <asp:Button ID="Violeta1" runat="server" Text="Violeta" BackColor ="Violet" OnClick="Violeta_Click" CssClass="botonc"/>
                <asp:Button ID="Celeste1" runat="server" Text="Celeste" BackColor ="SkyBlue" OnClick="Celeste_Click" CssClass="botonc"/>
                <asp:Button ID="Gris1" runat="server" Text="Gris" BackColor ="Gray" OnClick="Gris_Click" CssClass="botonc"/>

            </div>
            <div class="centro">

                <asp:Button ID="AperturaN" runat="server" Text="Apertura Normal" OnClick="Apertura_Click" />
                <asp:Button ID="AperturaP" runat="server" Text="Apertura Personalizada" OnClick="Apertura_Click" />

                <asp:Button ID="RNormal" runat="server" Text="Reto Normal" OnClick="Apertura_Click" />
                <asp:Button ID="RInverso" runat="server" Text="Reto Inverso" OnClick="Apertura_Click"/>
            </div>
            <asp:Label ID="Label1" runat="server" Text="Colores Jugador 2" CssClass="Label1"></asp:Label>
            <div class ="derecha">
            
                <asp:Button ID="Rojo2" runat="server" Text="Rojo"  BackColor ="Red" OnClick="Rojo_Click" CssClass="botonc"/>
                <asp:Button ID="Blanco2" runat="server" Text="Blanco"  BackColor ="White" OnClick="Blanco_Click" CssClass="botonc"/>
                <asp:Button ID="Azul2" runat="server" Text="Azul"  BackColor ="Blue" OnClick="Azul_Click" CssClass="botonc"/>
                <asp:Button ID="Negro2" runat="server" Text="Negro"  BackColor ="Black" OnClick="Negro_Click" CssClass="botonc" ForeColor="White" BorderColor="Green"/>
                <asp:Button ID="Verde2" runat="server" Text="Verde"   BackColor ="Green" OnClick="Verde_Click" CssClass="botonc"/>
                <asp:Button ID="Amarillo2" runat="server" Text="Amarillo"  BackColor ="Yellow" OnClick="Amarillo_Click" CssClass="botonc"/>                            
	            <asp:Button ID="Anaranjado2" runat="server" Text="Anaranjado" BackColor="Orange" OnClick="Anaranjado_Click" CssClass="botonc" />
                <asp:Button ID="Violeta2" runat="server" Text="Violeta" BackColor="Violet" OnClick="Violeta_Click" CssClass="botonc" />
                <asp:Button ID="Celeste2" runat="server" Text="Celeste" BackColor ="SkyBlue" OnClick="Celeste_Click" CssClass="botonc"/>
                <asp:Button ID="Gris2" runat="server" Text="Gris" BackColor ="Gray" OnClick="Gris_Click" CssClass="botonc"/>

            </div>

            <asp:Button ID="IniciarPartida" runat="server" Text="Iniciar Partida" OnClick="IniciarPartida_Click" CssClass="Iniciar"/>


            
        </div>
    </form>
</body>
</html>