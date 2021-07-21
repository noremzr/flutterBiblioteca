Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Http
Imports biblioteca_api_extension_dll.Usuarios
Imports biblioteca_api_extension_dll.Compartilhados.Connection
Imports biblioteca_api_extension_dll

<RoutePrefix("api/usuarios")>
Public Class UsuarioController
    Inherits ApiController

    ' GET api/values
    <HttpPost>
    <Route("GetUsuarios")>
    Public Function GetUsuarios(<FromBody> usuarioFiltro As UsuarioFilter) As List(Of Usuario)
        Dim conexao As SqlConnection = GetConnection()
        Dim UsuarioDAO As New UsuarioDAO(conexao)
        'Dim listaUsuarios As List(Of Usuario) = UsuarioDAO.FindAll(usuarioFiltro)
        'Return listaUsuarios
        Return Nothing
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/values
    <Route("CadastrarUsuario")>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/values/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
