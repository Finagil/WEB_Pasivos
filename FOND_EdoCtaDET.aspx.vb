Public Class FOND_EdoCtaDET
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim taEstatus As New WEB_FinagilDSTableAdapters.FOND_EstatusTableAdapter
        If taEstatus.ObtEstatus_ScalarQuery(CDec(Request("Mov"))) <> "NE" Then
            btnConfirmar.Text = "Datos Confirmados"
            btnConfirmar.Enabled = False
        End If
    End Sub
    Protected Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Dim taEstatus As New WEB_FinagilDSTableAdapters.FOND_EstatusTableAdapter
        taEstatus.Insert(CDec(Request("Mov")), "CERRADA", Date.Now, Session.Item("User"))
        'Response.Redirect("~/FOND_EdoCtaDET.aspx?id_fondeo={0}" & GridView1.Rows(1).Cells(1).Text & "&Fec={0:d}" & GridView1.Rows(4).Cells(0).Text & "&Mov={0}" & GridView1.Rows(4).Cells(0).Text)
        Response.Redirect("~/FOND_EdoCtaDET.aspx?id_fondeo=" & Request("id_fondeo") & "&Fec=" & Request("Fec") & "&Mov=" & Request("Mov"))
    End Sub
End Class