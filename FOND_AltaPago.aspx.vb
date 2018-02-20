Public Class FOND_AltaPago
    Inherits System.Web.UI.Page
    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        Dim row As DataRowView = DetailsView1.DataItem
        TextBox1.Text = CDate(row("FechaInicio")).ToShortDateString
    End Sub

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Dim ID As Integer = Request.QueryString("ID_fondeo")
        Dim ta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
        ta.Insert(ID, "PAGO", CDec(TxtImporte.Text) * -1, CDec(TxtInteres.Text) * -1, 0, 0, TextBox1.Text, TextBox1.Text)
        Response.Redirect("~\FOND_ConsultaFondeo.aspx", True)
    End Sub
End Class