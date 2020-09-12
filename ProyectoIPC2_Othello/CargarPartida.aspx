<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargarPartida.aspx.cs" Inherits="ProyectoIPC2_Othello.CargarPartida" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" ID="fileUpload" />
            <asp:Button ID="Cargar" runat="server" Text="Cargar partida" OnClick="Cargar_Click" />
        </div>
    </form>
</body>
</html>
