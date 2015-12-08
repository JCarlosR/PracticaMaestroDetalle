Imports Negocio
Public Class RegistroDoc
    Inherits System.Web.UI.Page

    Public Shared productos As New DataTable()
    Public Shared total As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LlenarListas()
        End If

        If productos.Columns.Count = 0 Then
            productos.Columns.Add(New DataColumn("Tipo de documento"))
            productos.Columns.Add(New DataColumn("Producto"))
            productos.Columns.Add(New DataColumn("Descripción"))
            productos.Columns.Add(New DataColumn("Cantidad"))
            productos.Columns.Add(New DataColumn("Igv"))
            productos.Columns.Add(New DataColumn("Precio"))
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

        Dim proveedores As DataTable = Consultas.ListarProveedor()
        cboProveedor.DataSource = proveedores
        cboProveedor.DataTextField = "razon"
        cboProveedor.DataValueField = "proveedor"
        cboProveedor.DataBind()

        Dim pedidos As DataTable = Consultas.ListarPedido()
        cboPedidos.DataSource = pedidos
        cboPedidos.DataTextField = "pedido"
        cboPedidos.DataValueField = "pedido"
        cboPedidos.DataBind()

        Dim tipodoc As DataTable = Consultas.ListarTipoDoc()
        cboTipoDoc.DataSource = tipodoc
        cboTipoDoc.DataTextField = "descripcion"
        cboTipoDoc.DataValueField = "tipo"
        cboTipoDoc.DataBind()

        Dim marcas As DataTable = Consultas.ListarMarcas()
        cboMarca.DataSource = marcas
        cboMarca.DataTextField = "descripcion"
        cboMarca.DataValueField = "Marca"
        cboMarca.DataBind()

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

    Private Sub cargarPrecio()
        Dim precio As String = Consultas.ObtenerPrecio(cboProducto.SelectedValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
        txtPrecio.Text = precio
    End Sub
    Dim pagado As String
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Agregar un detalle
        Dim cantidad As Integer
        Dim precio As Double
        Dim igv As Double

        Try
            cantidad = CInt(txtCantidad.Text)
            precio = CDbl(txtPrecio.Text)
            pagado = cantidad * precio
            igv = CDbl(txtIgv.Text)
        Catch ex As Exception
            Return
        End Try

        If existeProducto(cboProducto.SelectedValue) Then
            Return
        End If

        productos.Rows.Add(cboTipoDoc.SelectedValue, cboProducto.SelectedValue, cboProducto.SelectedItem, cantidad, igv, precio)
        gvProductos.DataSource = productos
        gvProductos.DataBind()

        limpiarCamposAgregar()
    End Sub

    Private Function existeProducto(ByVal Producto As String) As Boolean
        For Each fila As DataRow In productos.Rows
            If fila("Producto") = Producto Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub limpiarCamposAgregar()
        txtCantidad.Text = ""
        txtIgv.Text = ""
    End Sub

    Protected Sub cboMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMarca.SelectedIndexChanged
        cargarProductos()
        cargarPrecio()
    End Sub

    Protected Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        txtIgv.Text = CDbl(txtPrecio.Text) * CInt(txtCantidad.Text) * 0.18
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("MaestroDetalleDoc.aspx")
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim Documento As String = txtDocumento.Text
        Dim FormaPago As String = cboFormaPago.SelectedValue
        Dim Personal As String = cboPersonal.SelectedValue
        Dim Pedido As String = cboPedidos.SelectedValue
        Dim Proveedor As String = cboProveedor.SelectedValue
        Dim TipoDoc As String = cboTipoDoc.SelectedValue
        Dim Cliente As String = cboCliente.SelectedValue
        Dim Fecha As Date = txtFecha.Text
        Consultas.RegistrarDocumento(Documento, TipoDoc, Pedido, Proveedor, Cliente, Fecha, Personal, Pagado, FormaPago)

        For Each fila As DataRow In productos.Rows
            Dim Producto As String = fila("Producto")
            Dim Cantidad As Integer = fila("Cantidad")
            Dim Precio As Decimal = fila("Precio")
            Dim Igv As Decimal = fila("Igv")
            Dim Tipo As String = fila("Tipo de documento")
            Consultas.RegistrarDetaDoc(Documento, Tipo, Producto, Cantidad, Igv, Precio)
        Next
    End Sub


    Protected Sub gvProductos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvProductos.RowDeleting
        productos.Rows.RemoveAt(e.RowIndex)
        gvProductos.DataSource = productos
        gvProductos.DataBind()
    End Sub
End Class