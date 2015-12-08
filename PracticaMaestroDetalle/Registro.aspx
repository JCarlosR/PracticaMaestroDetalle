<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="PracticaMaestroDetalle.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Pedido
        <asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Fecha
        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
    </p>
    <p>
        Cliente
        <asp:DropDownList ID="cboCliente" runat="server" Height="16px" Width="144px">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Personal
        <asp:DropDownList ID="cboPersonal" runat="server" Height="18px" Width="137px">
        </asp:DropDownList>
    </p>
    <p>
        Forma pago
        <asp:DropDownList ID="cboFormaPago" runat="server" Height="16px" Width="131px">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Detalle pedido</p>
    <p>
        Marca&nbsp;
        <asp:DropDownList ID="cboMarca" runat="server" Height="16px" Width="155px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Producto
        <asp:DropDownList ID="cboProducto" runat="server" Height="20px" Width="132px" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        Cantidad
        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; Precio
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="118px" />
    </p>
    <p>
        <asp:GridView ID="gvProductos" runat="server" Height="125px" Width="426px">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        Total Pedido
        <asp:TextBox ID="txtTotalPedido" runat="server"></asp:TextBox>
    </p>
    <div>
        <asp:Button ID="btnGuardar" runat="server" Text="Registrar pedido" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </div>
</asp:Content>
