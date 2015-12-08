<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MaestroDetalleDoc.aspx.vb" Inherits="PracticaMaestroDetalle.MaestroDetalleDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="margin-top:3em;">Listado de documentos registrados</h1>

    <div class="row">
        <div class="col-md-6">
            Desde
            <asp:TextBox ID="txtDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            Hasta
            <asp:TextBox ID="txtHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
    <div class="form-group">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success pull-right"/>
    </div>    
    
    <div class="form-group">
        <asp:GridView ID="gvDocumentos" runat="server" AllowPaging="True" PageSize="4" CssClass="table table-hover">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </div>    
    
    <div class="form-group">
        <asp:GridView ID="gvDetalles" runat="server" CssClass="table table-hover">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>  
      
    <div class="row">
        <div class="col-md-3">
            Documento
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Código del producto
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Descripción
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Cantidad
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Precio Unitario
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

    </div>

    <div class="form-group">
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary"/>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-info"/>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"/>
    </div>    
</asp:Content>
