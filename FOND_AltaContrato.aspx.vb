Imports System.IO
Partial Public Class AltaContrato
    Inherits System.Web.UI.Page

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Try
            Dim ID As Integer = Request.QueryString("ID_fondeo")
            Dim ta As New WEB_FinagilDSTableAdapters.FOND_FondeosTableAdapter
            If FileUpload1.FileName.Length > 0 Then
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Docs/") & ID.ToString & FileUpload1.FileName)
            End If
            ta.UpdateDoc(ID.ToString & FileUpload1.FileName, ID)
            Response.Redirect("~/FOND_ConsultaFondeo.aspx", True)
        Catch ex As Exception
            LbErrorGlobal.Text = ex.Message
            LbErrorGlobal.Visible = True
        End Try
    End Sub


End Class