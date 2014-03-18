<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUsuaris.master" AutoEventWireup="true" CodeFile="Rols.aspx.cs" Inherits="Rols" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="PanelRols" runat="server">
        <header>
            Rols
        </header>
    
        <asp:Panel ID="PanelLlistaRols" runat="server" CssClass="PanelLlistaRolsPanelUnRol">
            <asp:ImageButton ID="imgAddRol" runat="server" ImageUrl="~/Imatges/add_user.png" OnClick="imgAddRol_Click" />
            <asp:Label ID="lblmensagesRols" runat="server" Text="Label" CssClass="Errores"></asp:Label>
            <br /><br />
            <asp:GridView ID="dgvRoles" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvRoles_RowDeleting" OnSelectedIndexChanging="dgvRoles_SelectedIndexChanging"></asp:GridView>
        </asp:Panel>

        <asp:Panel ID="PanelUnRol" runat="server" CssClass="PanelLlistaRolsPanelUnRol">

            <header>
                <asp:Label ID="lblTituloPanelRol" runat="server" Text="Label"></asp:Label>
            </header>
            <asp:Label ID="lblRol" runat="server" Text="Rol"></asp:Label>
            <asp:TextBox ID="txtNomRol" runat="server" ControlToValidate="txtNomRol"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNomRol"></asp:RequiredFieldValidator>
            <br />

              <asp:Panel ID="Panelesq" runat="server" CssClass="PanelDretaEsquerraBoton">
              <header>Usu. assignats</header>
                  <asp:ListBox ID="lstAsignats" runat="server"></asp:ListBox>
              </asp:Panel>

              <asp:Panel ID="PanelBotonsAgregar" runat="server" CssClass="PanelDretaEsquerraBoton">
                  <asp:Button ID="btpasar" runat="server" Text=">>" OnClick="btpasar_Click" />
                  <br />
                  <asp:Button ID="bttraer" runat="server" Text="<<" OnClick="bttraer_Click" />
              </asp:Panel>
            
              <asp:Panel ID="Paneldreta" runat="server" CssClass="PanelDretaEsquerraBoton">
              <header>Usu. possibles</header>
                   <asp:ListBox ID="lstPosiibles" runat="server" SelectionMode="Multiple"></asp:ListBox>
              </asp:Panel>

            <asp:Panel ID="PanelBotons" runat="server" CssClass="Panelbotons">
                <asp:ImageButton ID="imgAccept" runat="server" ImageUrl="~/Imatges/accept_48.png" OnClick="imgAccept_Click" />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imatges/cancel_48.png" CausesValidation="False" OnClick="ImageButton1_Click" />
            </asp:Panel>
       
        </asp:Panel>


    
    </asp:Panel>



</asp:Content>

