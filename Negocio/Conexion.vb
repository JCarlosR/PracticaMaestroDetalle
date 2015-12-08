Imports System.Data.SqlClient

Public Class Conexion
    Shared con As New SqlConnection("Server=.; Initial catalog=TenebrosaOLTP; Integrated security=true")

    Public Shared Function abrirConexion() As SqlConnection
        con.Open()
        Return con
    End Function

    Public Shared Function cerrarConexion()
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        Return True
    End Function

End Class
