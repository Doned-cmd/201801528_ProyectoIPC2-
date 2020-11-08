<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProyectoIPC2_Othello.Perfil" %>

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
                        <asp:TreeNode NavigateUrl="~/CargarPartida.aspx"  Text="Cargar Partida" Value="Cargar Partida"></asp:TreeNode>
                        <asp:TreeNode   Text="Nueva partida" Value="Nueva partida"></asp:TreeNode>
                    </asp:TreeNode>

                    <asp:TreeNode Text="Jugar partida" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="" Text="Jugar contra jugador" Value="Jugar contra jugador"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Jugar contra máquina" Value="Jugar contra máquina"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Jugar Othelo Xtreme" Value="Jugar contra máquina"></asp:TreeNode>
                    </asp:TreeNode>

                    <asp:TreeNode Text="Torneos" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="" Text="Crear torneo" Value="tema 3.1"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Informacion de torneos" Value="tema 3.1"></asp:TreeNode>
                    </asp:TreeNode>

                </Nodes>
            </asp:TreeView>
        </div>
        <div class="der">
            <div class="Othello">
                <h1>
                    <asp:Label ID="NombreUsuario" runat="server"></asp:Label>
               </h1>
            </div>
            <div class="Datos">                
                <asp:Label ID="correoelectronico" runat="server"></asp:Label>                
                <asp:Label ID="nombre" runat="server"></asp:Label>                
                <asp:Label ID="username" runat="server"></asp:Label>                
                <asp:Label ID="fechanacimiento" runat="server"></asp:Label>                
                <asp:Label ID="pais" runat="server"></asp:Label>
                <asp:Label ID="partidasGanadas" runat="server"></asp:Label>
                <asp:Label ID="partidasPerdidas" runat="server"></asp:Label>
                <asp:Label ID="partidasEmpatadas" runat="server"></asp:Label>
                <asp:Label ID="puntostorneos" runat="server"></asp:Label>
            </div>
         </div>
    </form>
</body>
</html>
