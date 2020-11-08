<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OthelloXtreme.aspx.cs" Inherits="ProyectoIPC2_Othello.Othello_Xtreme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/EstiloInicio.css" type="text/css" rel="stylesheet" media=""/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="contenedor">
        <div>
            <div class="Izq">
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>                       
                    <asp:TreeNode Text="Inicio" Value="Inicio"></asp:TreeNode>     
                    <asp:TreeNode Text="Partida" Value="Tema 3">
                        <asp:TreeNode NavigateUrl="~/CargarPartida.aspx"  Text="Cargar Partida" Value="Cargar Partida"></asp:TreeNode>
                        <asp:TreeNode   Text="Nueva partida" Value="Nueva partida"></asp:TreeNode>
                    </asp:TreeNode>

                    <asp:TreeNode Text="Jugar partida" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="" Text="Jugar contra jugador" Value="Jugar contra jugador"></asp:TreeNode>
                        <asp:TreeNode  NavigateUrl="" Text="Jugar contra máquina" Value="Jugar contra máquina"></asp:TreeNode>
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
            <div class="TableroXtreme">
               
                <asp:Panel ID="PanelTablero" runat="server" CssClass="FichasXtreme"></asp:Panel>
                                
                
                       
            </div>
            <asp:Button ID="Guardar" runat="server" Text="Guardar partida" CssClass="Guarda" OnClick="Guardar_Click"  />   
             <div class ="restultado"><asp:Label ID="Terminado" runat="server" Text="Label"></asp:Label></div>
            <div class ="Turnoactual"> <asp:Label ID="TurnoActual" runat="server" Text="Label"></asp:Label></div>
            
        </div>
    </form>
</body>
</html>
