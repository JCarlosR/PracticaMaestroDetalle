Imports Negocio
Public Class MaestroDetalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtDesde.Text = "2003-01-01"
            txtHasta.Text = Date.Today.ToString("yyyy-MM-dd")
        End If

    End Sub


    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarPedidos()
    End Sub

    Protected Sub gvPedidos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPedidos.PageIndexChanging
        gvPedidos.PageIndex = e.NewPageIndex
        cargarPedidos()
    End Sub

    Public Sub cargarPedidos()
        Dim pedidos As DataTable = Consultas.ListarPedidos(txtDesde.Text, txtHasta.Text)
        gvPedidos.DataSource = pedidos
        gvPedidos.DataBind()
    End Sub

    Protected Sub gvPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvPedidos.SelectedIndexChanged
        Dim detalles As DataTable = Consultas.MostrarDetalle(gvPedidos.SelectedRow.Cells(1).Text)
        gvDetalles.DataSource = detalles
        gvDetalles.DataBind()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("Registro.aspx")
    End Sub

End Class