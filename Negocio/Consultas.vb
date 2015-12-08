Imports System.Data.SqlClient
Public Class Consultas

    Inherits Conexion

    Public Shared Function ListarPedidos(ByVal inicio As Date, ByVal fin As Date) As DataTable
        Try
            Dim sql As String = "SP_ListarPedidos"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio
            cmd.Parameters.Add("@fin", SqlDbType.Date).Value = fin

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function MostrarDetalle(ByVal pedido As String) As DataTable
        Try
            Dim sql As String = "SP_MostrarDetalle"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@pedido", SqlDbType.Char).Value = pedido

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarClientes() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_Clientes"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarPersonal() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_Personal"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarFormaPago() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_FormaPago"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarMarcas() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_Marca"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarProductos(ByVal marca As String) As DataTable
        Try
            Dim sql As String = "SP_MarcaProducto"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@marca", SqlDbType.Char).Value = marca

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ObtenerPrecio(ByVal producto As String) As Double
        Try
            Dim sql As String = "SP_PrecioProducto"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@producto", SqlDbType.Char).Value = producto

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    ' Pedido, FormaPago, Personal, Cliente, Fecha, Estado

    Public Shared Function RegistrarPedido(ByVal Pedido As String, ByVal FormaPago As String, ByVal Personal As String, ByVal Cliente As String, ByVal Fecha As Date) As String
        Try
            Dim sql As String = "SP_RegistrarPedido"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Pedido", SqlDbType.Char).Value = Pedido
            cmd.Parameters.Add("@FormaPago", SqlDbType.Char).Value = FormaPago
            cmd.Parameters.Add("@Personal", SqlDbType.Char).Value = Personal
            cmd.Parameters.Add("@Cliente", SqlDbType.Char).Value = Cliente
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha
            Dim i As Integer = cmd.ExecuteNonQuery()
            Return "Se modificaron exitosamente " + CStr(i) + " filas."
        Catch ex As Exception
            Return "Ocurrió un error inesperado: " + ex.ToString
        Finally
            cerrarConexion()
        End Try
    End Function


    ' Pedido, Producto, Cantidad, PrecUnit
    Public Shared Function RegistrarDetaPedido(ByVal Pedido As String, ByVal Producto As String, ByVal Cantidad As Integer, ByVal PrecUnit As Decimal) As String
        Try
            Dim sql As String = "SP_RegistrarDetaPedido"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Pedido", SqlDbType.Char).Value = Pedido
            cmd.Parameters.Add("@Producto", SqlDbType.Char).Value = Producto
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
            cmd.Parameters.Add("@PrecUnit", SqlDbType.Decimal).Value = PrecUnit
            Dim i As Integer = cmd.ExecuteNonQuery()
            Return "Se modificaron exitosamente " + CStr(i) + " filas."
        Catch ex As Exception
            Return "Ocurrió un error inesperado: " + ex.ToString
        Finally
            cerrarConexion()
        End Try
    End Function

    'Logica para el maestro-detalle de documentos 
    Public Shared Function ListarDocumentos(ByVal inicio As Date, ByVal fin As Date) As DataTable
        Try
            Dim sql As String = "SP_ListarDocumentos"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio
            cmd.Parameters.Add("@fin", SqlDbType.Date).Value = fin

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function MostrarDetalleDoc(ByVal documento As String) As DataTable
        Try
            Dim sql As String = "SP_MostrarDetalleDoc"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@documento", SqlDbType.Char).Value = documento

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarProveedor() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_Proveedor"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarPedido() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_Pedido"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function ListarTipoDoc() As DataTable
        Try
            Dim sql As String = "SELECT * FROM V_TipoDoc"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.Text

            Dim tabla As New DataTable
            Dim adap As New SqlDataAdapter(cmd)
            adap.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                Return Nothing
            Else
                Return tabla
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        Finally
            cerrarConexion()
        End Try
    End Function
    'Documento, TipoDoc, Pedido, Proveedor, Cliente, Fecha, Personal, Pagado, FormaPago
    Public Shared Function RegistrarDocumento(ByVal Documento As String, ByVal TipoDoc As String, ByVal Pedido As String, ByVal Proveedor As String, ByVal Cliente As String, ByVal Fecha As Date, ByVal Personal As String, ByVal Pagado As String, ByVal FormaPago As String) As String
        Try
            Dim sql As String = "SP_RegistrarDocumento"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Documento", SqlDbType.Char).Value = Documento
            cmd.Parameters.Add("@TipoDoc", SqlDbType.Char).Value = TipoDoc
            cmd.Parameters.Add("@Proveedor", SqlDbType.Char).Value = Proveedor
            cmd.Parameters.Add("@Pedido", SqlDbType.Char).Value = Pedido
            cmd.Parameters.Add("@Cliente", SqlDbType.Char).Value = Cliente
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha
            cmd.Parameters.Add("@Personal", SqlDbType.Char).Value = Personal
            cmd.Parameters.Add("@Pagado", SqlDbType.Decimal).Value = CDec(Pagado)
            cmd.Parameters.Add("@FormaPago", SqlDbType.Char).Value = FormaPago
            Dim i As Integer = cmd.ExecuteNonQuery()
            Return "Se insertaron exitosamente " + CStr(i) + " filas."
        Catch ex As Exception
            Return "Ocurrió un error inesperado: " + ex.ToString
        Finally
            cerrarConexion()
        End Try
    End Function
    'Documento, Tipo, Producto, Cantidad, Igv, Precio
    Public Shared Function RegistrarDetaDoc(ByVal Documento As String, ByVal Tipo As String, ByVal Producto As String, ByVal Cantidad As Integer, ByVal Igv As Decimal, ByVal PrecUnit As Decimal) As String
        Try
            Dim sql As String = "SP_RegistrarDetaDoc"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Documento", SqlDbType.Char).Value = Documento
            cmd.Parameters.Add("@TipoDoc", SqlDbType.Char).Value = Tipo
            cmd.Parameters.Add("@Producto", SqlDbType.Char).Value = Producto
            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Cantidad
            cmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = Igv
            cmd.Parameters.Add("@PrecUnit", SqlDbType.Decimal).Value = PrecUnit
            Dim i As Integer = cmd.ExecuteNonQuery()
            Return "Se modificaron exitosamente " + CStr(i) + " filas."
        Catch ex As Exception
            Return "Ocurrió un error inesperado: " + ex.ToString
        Finally
            cerrarConexion()
        End Try
    End Function
    '(Documento, Pedido, Producto, Cantidad, PrecUnit
    Public Shared Function ModificarDetalleDoc(ByVal Documento As String, ByVal Producto As String, ByVal Cantidad As String, ByRef Igv As String, ByVal PrecUnit As String) As String
        Try
            Dim sql As String = "SP_ModificarDetaDoc"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Documento", SqlDbType.Char).Value = Documento
            cmd.Parameters.Add("@Producto", SqlDbType.Char).Value = Producto
            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Cantidad
            cmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = Igv
            cmd.Parameters.Add("@PrecUnit", SqlDbType.Decimal).Value = PrecUnit
            Dim i As Integer = cmd.ExecuteNonQuery()
            Return "Se modificaron exitosamente " + CStr(i) + " filas."
        Catch ex As Exception
            Return "Ocurrió un error inesperado: " + ex.ToString
        Finally
            cerrarConexion()
        End Try
    End Function

    Public Shared Function EliminarDetalleDoc(ByVal Documento As String, ByVal Producto As String)
        Try
            Dim sql As String = "SP_EliminarDetaDoc"
            Dim cmd As New SqlCommand(sql, abrirConexion())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Documento", SqlDbType.Char).Value = Documento
            cmd.Parameters.Add("@Producto", SqlDbType.Char).Value = Producto

            Dim i As Integer = cmd.ExecuteNonQuery()
            Return "Se modificaron exitosamente " + CStr(i) + " filas."
        Catch ex As Exception
            Return "Ocurrió un error inesperado: " + ex.ToString
        Finally
            cerrarConexion()
        End Try
    End Function

End Class
