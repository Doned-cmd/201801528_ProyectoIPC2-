<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoIPC2_Othello.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/EstiloInicio.css" type="text/css" rel="stylesheet" media=""/>
    <title></title>
</head>
<body>
    <form id="form1" class="contenedor" runat="server">
        <div class="Izq">
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>                             
                    <asp:TreeNode Text="Partida" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="~/CargarPartida.aspx" Text="Cargar Partida" Value="tema 3.1"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="~/Juego.aspx" Text="Nueva partida" Value="tema 3.1"></asp:TreeNode>
                    </asp:TreeNode>

                    <asp:TreeNode Text="Jugar partida" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="" Text="Jugar contra jugador" Value="5"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Jugar contra máquina" Value="tema 3.1"></asp:TreeNode>
                    </asp:TreeNode>

                    <asp:TreeNode Text="Torneos" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="" Text="Crear torneo" Value="tema 3.1"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Informacion de torneos" Value="tema 3.1"></asp:TreeNode>
                    </asp:TreeNode>

                    <asp:TreeNode Text="Usuario"   Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="" Text="Informacion" Value="tema 3.1"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Partidas jugadas" Value="tema 3.1"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Torneos en marcha" Value="tema 3.1"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
        <div class="der">
            <div class="Othello">
                <h1>OTHELLO</h1>
            </div>
            <div class="imageninicio">
                <img src="Imagenes/imagen1.jpg" width="650"/>
            </div>
         </div>
    </form>
</body>
</html>
