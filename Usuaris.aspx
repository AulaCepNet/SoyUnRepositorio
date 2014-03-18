<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuaris.master" AutoEventWireup="true" CodeFile="Usuaris.aspx.cs" Inherits="Usuaris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="PanelUsuari" runat="server" CssClass="PnalesUsuari">
   
    	<header>
            <asp:Label ID="lbltituoHeader" runat="server" Text="Label"></asp:Label>
    	</header>
<asp:Label ID="Label1" runat="server" Text="Nom usuari" CssClass="etiquetasNormales"></asp:Label>
<asp:TextBox ID="txtuser" runat="server" CssClass="textboxes"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredUser" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtuser"></asp:RequiredFieldValidator>
  <br />
<asp:Label ID="Label2" runat="server" Text="Contrasenya" CssClass="etiquetasNormales"></asp:Label>
<asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="textboxes"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredPass" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtpass" ControlToCompare="txtpass"></asp:RequiredFieldValidator>
  <br />

<asp:Label ID="Label3" runat="server" Text="Confirmar contrasenya" CssClass="etiquetasNormales"></asp:Label>
<asp:TextBox ID="txtconfirm" runat="server" TextMode="Password" CssClass="textboxes"></asp:TextBox>
  <asp:CompareValidator ID="ComparePass" runat="server" ErrorMessage="Contraseña y confimación no coinciden" ControlToCompare="txtpass" ControlToValidate="txtconfirm"></asp:CompareValidator>
 <br />

<asp:Label ID="Label4" runat="server" Text="Cognoms" CssClass="etiquetasNormales"></asp:Label>
<asp:TextBox ID="txtcognoms" runat="server" CssClass="textboxes" ></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldcognom" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtcognoms"></asp:RequiredFieldValidator>
  <br />

         <asp:Label ID="Label5" runat="server" Text="Nom" CssClass="etiquetasNormales"></asp:Label>
<asp:TextBox ID="txtnom" runat="server" CssClass="textboxes"></asp:TextBox>
<asp:RequiredFieldValidator ID="Requirednom" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtnom"></asp:RequiredFieldValidator>
<br />
         
              <asp:Label ID="Label6" runat="server" Text="Correu electrònic" CssClass="etiquetasNormales"></asp:Label>
<asp:TextBox ID="txtcorreo" runat="server" CssClass="textboxes"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredMail" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtcorreo"></asp:RequiredFieldValidator>
<br />     
         
     <!--pone que se a de poner nombre otra vez... no lo creo-->
         
    <asp:ImageButton ID="imgAceptar" runat="server" ImageUrl="~/Imatges/accept_48.png" OnClick="imgAceptar_Click"></asp:ImageButton>     
    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Imatges/cancel_48.png" CausesValidation="False" OnClick="imgCancel_Click"></asp:ImageButton>     
     <asp:Label ID="lblErrorBotonces" runat="server" Text=""></asp:Label>                     
   </asp:Panel>
 
     <asp:Panel ID="PanelUsuaris" runat="server" CssClass="PnalesUsuari">
    	<header>
            Tots els usuaris
    	</header>

<asp:ImageButton ID="imgAlta" runat="server" ImageUrl="~/Imatges/add_user.png" OnClick="imgAlta_Click"></asp:ImageButton>
<asp:Label ID="lblMissatgesAlta" runat="server" Text=""></asp:Label>
           <br /><br />

           <!-- En aquesta GridView no s’han de generar els camps automàticament.?¿?¿?¿?-->
<asp:GridView ID="dgvUsers" runat="server" OnRowDeleting="dgvUsers_RowDeleting" OnSelectedIndexChanged="dgvUsers_SelectedIndexChanged" AutoGenerateColumns="False"></asp:GridView>
    </asp:Panel>
</asp:Content>

