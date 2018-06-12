Public Class AltaCapital
    Inherits System.Web.UI.Page
    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        Dim id As Integer = Request.QueryString("ID_FONDEO")
        Dim row As DataRowView = DetailsView1.DataItem
        If Not IsNothing(row) Then
            If row("Tipo_Fondeo") = "INDIVIDUAL" Then
                Dim TA As New WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter
                If TA.NoMinistraciones(id) >= DetailsView1.DataKey(1) Then
                    BotonEnviar1.Visible = False
                End If
            End If
        End If
        TextBox1.Text = Today.ToShortDateString
    End Sub

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Try
            Dim ID As Integer = Request.QueryString("ID_fondeo")
            Dim ta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
            Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
            If F1 <= Date.Now.Date.AddDays(-6) Then
                LberrorGlobal.Text = "Fecha incorrecta, solo se pueden usar fechas de 6 días anteriores al día de hoy."
                LberrorGlobal.Visible = True
            Else
                ta.Insert(ID, "CAPITAL", TxtImporte.Text, 0, 0, 0, F1, F1, TxtImporte.Text, TxtImporte.Text)
                ProcesaCalculos(ID)
                Response.Redirect("~\FOND_ConsultaFondeo.aspx", True)
            End If
        Catch ex As Exception
            LberrorGlobal.Text = ex.Message
            LberrorGlobal.Visible = True
        End Try
    End Sub
End Class