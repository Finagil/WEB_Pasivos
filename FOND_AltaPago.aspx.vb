Public Class FOND_AltaPago
    Inherits System.Web.UI.Page
    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        Dim row As DataRowView = DetailsView1.DataItem
        TextBox1.Text = CDate(row("FechaInicio")).ToShortDateString
    End Sub

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Try
            If Validaciones() = True Then
                Dim ID As Integer = Request.QueryString("ID_fondeo")
                Dim IDF As Integer = Request.QueryString("ID_fondeador")
                Dim ta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
                Dim ta2 As New WEB_FinagilDSTableAdapters.FOND_SaldoGarantiasTableAdapter
                Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
                'If F1 <= Date.Now.Date.AddDays(Date.Now.Day * -1) Then
                '    LberrorGlobal.Text = "Fecha incorrecta, no se puede usar fecha del mes anterior."
                '    LberrorGlobal.Visible = True
                'Else
                ta.Insert(ID, "PAGO", CDec(TxtImporte.Text) * -1, CDec(TxtInteres.Text) * -1, 0, 0, F1, F1, 0, 0)
                If CkGarantia.Checked = True Then
                    If TxtGarantia.Text = "" Then TxtGarantia.Text = "Garantia Ejercida"
                    ta2.Insert(IDF, ID, CDec(TxtImporte.Text), F1, TxtGarantia.Text)
                End If
                Response.Redirect("~\FOND_ConsultaFondeo.aspx", True)
                'End If
            End If
        Catch ex As Exception
            LberrorGlobal.Text = ex.Message
            LberrorGlobal.Visible = True
        End Try
    End Sub

    Function Validaciones() As Boolean
        Validaciones = True
        If Val(TxtInteres.Text) > 0 Then
            If Val(TxtRetencion.Text) <= 0 Then
                LberrorGlobal.Text = "Falta la retención."
                Validaciones = False
            End If
        End If
        If CkGarantia.Checked = True Then
            If TxtGarantia.Text = "" Then
                LberrorGlobal.Text = "Falta el concepto de la garantía."
                Validaciones = False
            End If
        End If
        LberrorGlobal.Visible = Not Validaciones
        Return Validaciones
    End Function
End Class