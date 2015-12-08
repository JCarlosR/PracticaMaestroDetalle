<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="PracticaMaestroDetalle.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 style="margin-top:3em;">Cabecera del pedido</h3>

    <div class="form-group">
        Pedido
        <asp:TextBox ID="txtPedido" runat="server" CssClass="form-control" required></asp:TextBox>
    </div>    

    <div class="form-group">
        Fecha
        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control" required></asp:TextBox>
    </div>

    <div class="form-group">
        Cliente
        <asp:DropDownList ID="cboCliente" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>

    <div class="form-group">
        Personal
        <asp:DropDownList ID="cboPersonal" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>

    <div class="form-group">
        Forma pago
        <asp:DropDownList ID="cboFormaPago" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>

    <h3>Detalles del pedido</h3>

    <div class="row">
        <div class="col-md-6">
            Marca
            <asp:DropDownList ID="cboMarca" runat="server" AutoPostBack="True" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            Producto
            <asp:DropDownList ID="cboProducto" runat="server" AutoPostBack="True" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            Cantidad
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" type="number" min="0"></asp:TextBox>
        </div>
        <div class="col-md-6">
            Precio
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" step="0.01" min="0" TextMode="Number"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
       <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success pull-right" />
    </div>

    <div class="form-group">
        <asp:GridView ID="gvProductos" runat="server" CssClass="table table-hover">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="form-group">
        Total Pedido
        <asp:TextBox ID="txtTotalPedido" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnGuardar" runat="server" Text="Registrar pedido" CssClass="btn btn-primary" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
    </div>
</asp:Content>
