Partial Public Class AltaFondeo
    Inherits System.Web.UI.Page


    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Dim ta As New WEB_FinagilDSTableAdapters.FOND_FondeosTableAdapter
        Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
        Dim F2 As DateTime = DateTime.Parse(Request.Form(TextBox2.UniqueID))
        ta.Insert(cmbFondeador.SelectedValue, cmbTipoFondeo.SelectedValue, TxtDesc.Text,
                  F1, F2, CmbTasas.SelectedValue, CDec(TxtDiff.Text),
                  FileUpload1.FileName, "VIGENTE")
        If FileUpload1.FileName.Length > 0 Then
            Dim ID As Integer = ta.MaxID
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Docs/") & ID.ToString & FileUpload1.FileName)
            Session.Item("ID_fondeo") = ID
        End If
        Response.Redirect("~\FOND_AltaCapital.aspx", True)
    End Sub

End Class