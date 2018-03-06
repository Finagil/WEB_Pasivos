Public Class FOND_SaldoGaratiaDet
    Inherits System.Web.UI.Page

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click

        Try
            Dim ID As Integer = Request.QueryString("ID_fondeador")
            Dim ta As New WEB_FinagilDSTableAdapters.FOND_SaldoGarantiasTableAdapter
            Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
            'If F1 <= Date.Now.Date.AddDays(Date.Now.Day * -1) Then
            '    LberrorGlobal.Text = "Fecha incorrecta, no se puede usar fecha del mes anterior."
            '    LberrorGlobal.Visible = True
            'Else
            ta.Insert(ID, 0, CDec(TxtImporte.Text) * -1, F1, "PAGO - " & TxtConcepto.Text.ToUpper)
            Response.Redirect("~\FOND_SaldoGaratiaDet.aspx?id_fondeador=" & ID, True)
            'end fi
        Catch ex As Exception
            LberrorGlobal.Text = ex.Message
            LberrorGlobal.Visible = True
        End Try
    End Sub
End Class