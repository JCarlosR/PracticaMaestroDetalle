Imports Negocio
Public Class Registro
    Inherits System.Web.UI.Page

    Public Shared productos As New DataTable()
    Public Shared total As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LlenarListas()
        End If

        If productos.Columns.Count = 0 Then
            productos.Columns.Add(New DataColumn("Producto"))
            productos.Columns.Add(New DataColumn("Descripcion"))
            productos.Columns.Add(New DataColumn("Cantidad"))
            productos.Columns.Add(New DataColumn("Precio"))
            productos.Columns.Add(New DataColumn("Subtotal"))
        End If
    End Sub

    Public Sub LlenarListas()
        Dim clientes As DataTable = Consultas.ListarClientes()
        cboCliente.DataSource = clientes
        cboCliente.DataTextField = "Nombre"
        cboCliente.DataValueField = "Cliente"
        cboCliente.DataBind()

        Dim personal As DataTable = Consultas.ListarPersonal()
        cboPersonal.DataSource = personal
        cboPersonal.DataTextField = "Nombre"
        cboPersonal.DataValueField = "Personal"
        cboPersonal.DataBind()

        Dim formaspago As DataTable = Consultas.ListarFormaPago()
        cboFormaPago.DataSource = formaspago
        cboFormaPago.DataTextField = "descripcion"
        cboFormaPago.DataValueField = "FormaPago"
        cboFormaPago.DataBind()

        Dim marcas As DataTable = Consultas.ListarMarcas()
        cboMarca.DataSource = marcas
        cboMarca.DataTextField = "descripcion"
        cboMarca.DataValueField = "Marca"
        cboMarca.DataBind()

        cargarProductos()
        cargarPrecio()
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Agregar un detalle
        Dim cantidad As Integer = CInt(txtCantidad.Text)
        Dim precio As Double = CDbl(txtPrecio.Text)
        Dim subtotal As Double = cantidad * precio

        ' Actualizar el campo total pedido
        total += subtotal
        txtTotalPedido.Text = total

        productos.Rows.Add(cboProducto.SelectedValue, cboProducto.SelectedItem, cantidad, precio, subtotal)
        gvProductos.DataSource = productos
        gvProductos.DataBind()

        limpiarCamposAgregar()
    End Sub

    Private Sub limpiarCamposAgregar()
        txtCantidad.Text = ""
    End Sub

    Protected Sub cboMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMarca.SelectedIndexChanged
        cargarProductos()
        cargarPrecio()
    End Sub

    Private Sub cargarProductos()
        Dim productos As DataTable = Consultas.ListarProductos(cboMarca.SelectedValue)
        cboProducto.DataSource = productos
        cboProducto.DataTextField = "descripcion"
        cboProducto.DataValueField = "Producto"
        cboProducto.DataBind()
    End Sub

   
    Protected Sub cboProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProducto.SelectedIndexChanged
        cargarPrecio()
    End Sub

    Private Sub cargarPrecio()
        Dim precio As String = Consultas.ObtenerPrecio(cboProducto.SelectedValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
        txtPrecio.Text = precio
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("MaestroDetalle.aspx")
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim Pedido As String = txtPedido.Text
        Dim FormaPago As String = cboFormaPago.SelectedValue
        Dim Personal As String = cboPersonal.SelectedValue
        Dim Cliente As String = cboCliente.SelectedValue
        Dim Fecha As Date = txtFecha.Text
        Consultas.RegistrarPedido(Pedido, FormaPago, Personal, Cliente, Fecha)

        For Each fila As DataRow In productos.Rows
            Dim Producto As String = fila("Producto")
            Dim Cantidad As Integer = fila("Cantidad")
            Dim Precio As Decimal = fila("Precio")

            Consultas.RegistrarDetaPedido(Pedido, Producto, Cantidad, Precio)
        Next

    End Sub

End Class