<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuaris.master" AutoEventWireup="true" CodeFile="Inici_NOVAA.aspx.cs" Inherits="Inici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <panel id="login">
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

      </panel>

</asp:Content>

