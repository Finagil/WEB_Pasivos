Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case UCase(Session.Item("TipoCadena"))
            Case "PAS"
                Response.Redirect("~/FOND_EXT_ConsultaFondeo.aspx", True)
            Case "ADMON"
                Response.Redirect("~/ConfReembolso.aspx", True)
            Case Else
                Response.Redirect("~/LoginX.aspx", True)
        End Select
    End Sub

End Class