<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoIPC2_Othello.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Estilos/Estilo1.css" type="text/css" rel="stylesheet" media=""/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
     <form id="form1" runat="server">
        <div class="formularioLogin">

            <asp:TextBox runat="server" ID="Usuario" placeholder="Usuario" CssClass ="TextoLogin"></asp:TextBox>
            <asp:TextBox runat="server" ID="Contra" placeholder="Contraseña" CssClass ="TextoLogin" ></asp:TextBox>

            <asp:Button ID="Iniciar" runat="server" Text="Iniciar sesion" CssClass="BotonLogin"  OnClick="Login_Click" />
            <asp:Button ID="Registrar" runat="server" Text="Registarse"   OnClick="Registro_Click" />
            <asp:Label ID="LabelAlerta" runat="server" Text=""></asp:Label>
            
        </div>
    </form>
</body>
</html>


