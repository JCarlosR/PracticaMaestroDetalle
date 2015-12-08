<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MaestroDetalle.aspx.vb" Inherits="PracticaMaestroDetalle.MaestroDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Desde&nbsp;
    <asp:TextBox ID="txtDesde" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    Hasta&nbsp;<asp:TextBox ID="txtHasta" runat="server" TextMode="Date"></asp:TextBox>&nbsp;
    <asp:Button ID="btnBuscar" runat="server" Height="33px" Text="Buscar" Width="88px" />
    <asp:GridView ID="gvPedidos" runat="server" AllowPaging="True" Height="218px" PageSize="4" Width="329px">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvDetalles" runat="server" Width="330px">
    </asp:GridView>
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />&nbsp;
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
</asp:Content>
