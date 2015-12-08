Imports Negocio
Public Class MaestroDetalleDoc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtDesde.Text = "2003-01-01"
            txtHasta.Text = Date.Today.ToString("yyyy-MM-dd")
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarDocumentos()
    End Sub

    Public Sub cargarDocumentos()
        Dim documentos As DataTable = Consultas.ListarDocumentos(txtDesde.Text, txtHasta.Text)
        gvDocumentos.DataSource = documentos
        gvDocumentos.DataBind()
    End Sub



    Protected Sub gvDocumentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDocumentos.SelectedIndexChanged
        Dim detalles As DataTable = Consultas.MostrarDetalleDoc(gvDocumentos.SelectedRow.Cells(1).Text)
        gvDetalles.DataSource = detalles
        gvDetalles.DataBind()
    End Sub

    Protected Sub gvDocumentos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvDocumentos.PageIndexChanging
        gvDocumentos.PageIndex = e.NewPageIndex
        cargarDocumentos()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("RegistroDoc.aspx")
    End Sub


    Protected Sub gvDetalles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDetalles.SelectedIndexChanged
        txtDocumento.Text = gvDetalles.SelectedRow.Cells(1).Text
        txtCodigo.Text = gvDetalles.SelectedRow.Cells(2).Text
        txtDescripcion.Text = gvDetalles.SelectedRow.Cells(4).Text
        txtCantidad.Text = gvDetalles.SelectedRow.Cells(5).Text
        txtPrecio.Text = gvDetalles.SelectedRow.Cells(7).Text

    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim Documento As String = txtDocumento.Text
        Dim Producto As String = txtCodigo.Text
        Dim Cantidad As String = txtCantidad.Text
        Dim PrecUnit As String = txtPrecio.Text
        Dim Igv As Decimal = Cantidad * PrecUnit * 0.18

        Consultas.ModificarDetalleDoc(Documento, Producto, Cantidad, Igv, PrecUnit)
        Response.Redirect("MaestroDetalleDoc.aspx")
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Documento As String = txtDocumento.Text
        Dim Producto As String = txtCodigo.Text
        Consultas.EliminarDetalleDoc(Documento, Producto)
        Response.Redirect("MaestroDetalleDoc.aspx")
    End Sub
End Class