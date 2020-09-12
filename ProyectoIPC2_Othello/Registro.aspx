<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoIPC2_Othello.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Estilos/Estilos2.css" type="text/css" rel="stylesheet" media=""/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="formularioRegistro">
            <asp:TextBox runat="server" ID="Nombres" placeholder="Nombres" CssClass ="TextoRegistro"></asp:TextBox>
            <asp:TextBox runat="server" ID="Apellidos" placeholder="Apellidos" CssClass ="TextoRegistro" ></asp:TextBox>
            <asp:TextBox runat="server" ID="Contra" placeholder="Contraseña" CssClass ="TextoRegistro" ></asp:TextBox>
            <asp:TextBox runat="server" ID="NombreUsuario" placeholder="Nombre de Usuario" CssClass ="TextoRegistro"></asp:TextBox>
            
            <asp:TextBox runat="server" ID="CorreoElec" placeholder="Correo Electronico" CssClass ="TextoRegistro"></asp:TextBox>
            
            <asp:DropDownList ID="Pais" runat="server" CssClass ="TextoRegistro"><asp:ListItem>Guatemala</asp:ListItem><asp:ListItem>Mexico</asp:ListItem>
                <asp:ListItem>Argentina</asp:ListItem><asp:ListItem>Uruguay</asp:ListItem><asp:ListItem>EL salvador</asp:ListItem><asp:ListItem>Honduras</asp:ListItem>
                <asp:ListItem>Nicaragua</asp:ListItem>
            </asp:DropDownList>

           <asp:TextBox runat="server" ID="FechaNac" CssClass ="TextoRegistro" TextMode="Date" ></asp:TextBox>


            <asp:Button ID="Registrar" runat="server" Text="Registrarse" CssClass="BotonRegistro"  OnClick="Registrar_Click" />
            <asp:Button ID="Regresar" runat="server" Text="Regresar" CssClass="BotonRegresar"  OnClick="Regresar_Click" />
            <asp:Label ID="LabelPeligro" runat="server" Text=""></asp:Label>
        </div>
        
    </form>
</body>
</html>
