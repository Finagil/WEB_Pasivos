Public Class AltaCapital
    Inherits System.Web.UI.Page
    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        Dim id As Integer = Request.QueryString("ID_fondeo")
        Dim row As DataRowView = DetailsView1.DataItem
        If row("Tipo_Fondeo") = "INDIVIDUAL" Then
            Dim TA As New WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter
            If TA.NoMinistraciones(id) >= DetailsView1.DataKey(1) Then
                BotonEnviar1.Visible = False
            End If
        End If
        TextBox1.Text = CDate(row("FechaInicio")).ToShortDateString
    End Sub

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Dim ID As Integer = Request.QueryString("ID_fondeo")
        Dim ta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
        ta.Insert(ID, "CAPITAL", TxtImporte.Text, 0, 0, 0, TextBox1.Text, TextBox1.Text)
        Response.Redirect("~\FOND_ConsultaFondeo.aspx", True)
    End Sub
End Class