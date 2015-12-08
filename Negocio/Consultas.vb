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


End Class
