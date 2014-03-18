<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inici.aspx.cs" Inherits="Inici" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estils/usuaris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Panel ID="login" runat="server">
    
  	<header>Identificació d’usuari</header>

    <asp:Label ID="lblusers" runat="server" Text="Usuari" CssClass="etiquetasNormales"></asp:Label>
    <asp:TextBox ID="txtusuari" runat="server" CssClass="textboxes"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidatorUser" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtusuari" CssClass="Errores"></asp:RequiredFieldValidator>
    <br />

 <asp:Label ID="lblpass" runat="server" Text="Contrasenya" CssClass="etiquetasNormales"></asp:Label>
    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="textboxes"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtpass" CssClass="Errores"></asp:RequiredFieldValidator>
 <br /><br />
<asp:ImageButton ID="btnConectar" runat="server" ImageUrl="~/Imatges/login_32.png" OnClick="btnConectar_Click"></asp:ImageButton>
       <asp:Label ID="lblErrors" runat="server" Text="" CssClass="Errores"></asp:Label>

      </asp:Panel>

    </div>
    </form>
</body>
</html>
