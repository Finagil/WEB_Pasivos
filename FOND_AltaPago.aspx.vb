Public Class FOND_AltaPago
    Inherits System.Web.UI.Page

    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        Dim id As Integer = Request.QueryString("ID_FONDEO")
        Dim row As DataRowView = DetailsView1.DataItem
        If row("Tipo_Fondeo") = "INDIVIDUAL" Then
            Dim TA As New WEB_FinagilDSTableAdapters.Vw_FondeosTableAdapter
            If TA.NoMinistraciones(id) >= DetailsView1.DataKey(1) Then
                BotonEnviar1.Visible = False
            End If
        End If
        TextBox1.Text = Today.ToShortDateString
    End Sub

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Dim ID As Integer = Request.QueryString("ID_fondeo")
        Dim IDF As Integer = Request.QueryString("ID_fondeador")
        Dim ta2 As New WEB_FinagilDSTableAdapters.FOND_SaldoGarantiasTableAdapter
        Dim ta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
        Dim TasaRete As Decimal = ta.TasaRetencion(IDF)
        Try
            If Validaciones(TasaRete) = True Then
                Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
                'If F1 < CDate(Session("FechaAplicacion")) Then
                '    LberrorGlobal.Text = "Fecha incorrecta, no se pueden usar fecha anteriores al " & CDate(Session("FechaAplicacion")).ToShortDateString
                '    LberrorGlobal.Visible = True
                'Else
                ta.Insert(ID, "PAGO", CDec(TxtImporte.Text) * -1, CDec(TxtInteres.Text) * -1, CDec(TxtRetencion.Text) * -1, 0, F1, F1, 0, 0, 0, CmbBanco.selectedValue)
                If CkGarantia.Checked = True Then
                    If TxtGarantia.Text = "" Then TxtGarantia.Text = "Garantia Ejercida"
                    ta2.Insert(IDF, ID, CDec(TxtImporte.Text), F1, TxtGarantia.Text)
                End If
                ProcesaCalculos(ID)
                Response.Redirect("~\FOND_ConsultaFondeo.aspx", True)
                'End If
            End If
        Catch ex As Exception
            LberrorGlobal.Text = ex.Message
            LberrorGlobal.Visible = True
        End Try
    End Sub

    Function Validaciones(TasaRete As Decimal) As Boolean
        Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
        Validaciones = True
        If Val(TxtInteres.Text) > 0 And TasaRete > 0 Then
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
        If F1 <= Date.Now.Date.AddDays(-6) Then
            'LberrorGlobal.Text = "Fecha incorrecta, solo se pueden usar fechas de 6 días anteriores al día de hoy."
            'LberrorGlobal.Visible = True
            'Validaciones = False
        End If
        LberrorGlobal.Visible = Not Validaciones
        Return Validaciones
    End Function
End Class