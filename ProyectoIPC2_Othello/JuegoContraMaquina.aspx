<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JuegoContraMaquina.aspx.cs" Inherits="ProyectoIPC2_Othello.JuegoContraMaquina" %>

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
            <asp:TreeView ID="TreeView1" runat="server" >
                <Nodes>                             
                    <asp:TreeNode Text="Partida" Value="Tema 3">
                        <asp:TreeNode  NavigateUrl="~/CargaPartida.aspx" Text="Cargar Partida" Value="tema 3.1"></asp:TreeNode>
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
            
            <div class="Tablero">
                <img src="Imagenes/Tablero.png" width="660"/>
                <div class="Fichas">
                    <asp:Button ID="F1_C1" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C2" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C3" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C4" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C5" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C6" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C7" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F1_C8" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />

                    <asp:Button ID="F2_C1" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C2" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C3" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C4" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C5" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C6" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C7" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />
                    <asp:Button ID="F2_C8" runat="server"  CssClass="ficha fi2" OnClick="Boton_click"  />

                    <asp:Button ID="F3_C1" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C2" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C3" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C4" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C5" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C6" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C7" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />
                    <asp:Button ID="F3_C8" runat="server"  CssClass="ficha fi3" OnClick="Boton_click"  />

                    <asp:Button ID="F4_C1" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C2" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C3" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C4" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C5" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C6" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C7" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F4_C8" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />

                    <asp:Button ID="F5_C1" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C2" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C3" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C4" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C5" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C6" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C7" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F5_C8" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />

                    <asp:Button ID="F6_C1" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C2" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C3" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C4" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C5" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C6" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C7" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F6_C8" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />

                    <asp:Button ID="F7_C1" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C2" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C3" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C4" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C5" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C6" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C7" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F7_C8" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />

                    <asp:Button ID="F8_C1" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C2" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C3" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C4" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C5" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C6" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C7" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />
                    <asp:Button ID="F8_C8" runat="server"  CssClass="ficha fi1" OnClick="Boton_click"  />

                </div>
                <asp:Button ID="Guardar" runat="server" Text="Guardar partida" CssClass="Guarda" OnClick="Guardar_Click"  />                
            </div>
            <div class ="restultado"><asp:Label ID="Terminado" runat="server" Text="Label"></asp:Label></div>
            <div class ="restultado"> <asp:Label ID="Juegoterminado" runat="server" Text="Label"></asp:Label></div>
            
        </div>
    </form>
</body>
</html>
