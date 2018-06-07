Public Class FOND_EdoCta
    Inherits System.Web.UI.Page
    Dim FecIni, FecFin As Date
    Dim cFactor, Aux As String
    Dim Retencion, Rete, Inte, InteAcum As Decimal
    Dim Factor, Pago As Decimal
    Dim Cap, CapFinal As Decimal
    Dim taEdoCta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim ID As Integer = 0
        If e.Row.RowType = DataControlRowType.DataRow Then
            ID = DataBinder.Eval(e.Row.DataItem, "id_fondeo")
            FecIni = DataBinder.Eval(e.Row.DataItem, "FechaInicio")
            FecFin = DataBinder.Eval(e.Row.DataItem, "FechaFin")
            FecIni = FecIni.AddDays(FecIni.Day * -1).AddMonths(1) 'ultimo dia del mes
            Cap = DataBinder.Eval(e.Row.DataItem, "Promedio")
            e.Row.Cells(6).Text = CDec(taEdoCta.SumCapitalHasta(ID, FecIni)).ToString("n2")
            CapFinal = e.Row.Cells(6).Text
            Rete = DataBinder.Eval(e.Row.DataItem, "Retencion")
            Inte = DataBinder.Eval(e.Row.DataItem, "Interes")
            Dim Cont As Integer = 0
            Aux = ""
            If Cap > 0 Then
                Factor = Math.Round(Rete / Cap, 6)
                cFactor = Factor.ToString()
                e.Row.Cells(10).Text = EncuentraBaseFOR(Cap, Factor, Rete, 0.1).ToString("n2") ' base
                e.Row.Cells(11).Text = Math.Abs(Factor) ' factor
                e.Row.Cells(13).Text = CDec(taEdoCta.CapitalPagado(ID, FecFin.Month, FecFin.Year)).ToString("n2")
                e.Row.Cells(14).Text = CDec(taEdoCta.InteresPagado(ID, FecFin.Month, FecFin.Year)).ToString("n2")
                e.Row.Cells(15).Text = CDec(taEdoCta.RetencionPagada(ID, FecFin.Month, FecFin.Year)).ToString("n2")
                'Pago = CDec(e.Row.Cells(13).Text)
                Pago = CDec(e.Row.Cells(14).Text)
                'Pago += CDec(e.Row.Cells(15).Text)
                e.Row.Cells(16).Text = Math.Abs(CapFinal + Inte + InteAcum + Pago).ToString("n2") ' Saldo Neto
                InteAcum = CDec(e.Row.Cells(16).Text) - CapFinal
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            'e.Row.Cells(0).Text = "Totales"
            'e.Row.Cells(1).Text = Pago.ToString("n2")
            'e.Row.Cells(2).Text = Fondeo.ToString("n2")
            'e.Row.Cells(3).Text = Interes.ToString("n2")
            'e.Row.Cells(4).Text = Retencion.ToString("n2")
            'e.Row.Cells(5).Text = PagoNeto.ToString("n2")
            'e.Row.HorizontalAlign = HorizontalAlign.Center
            'e.Row.Font.Bold = True
            'Label3.Text = "Saldo: " & Saldo.ToString("n2")
            ''Himporte.Value = total1.ToString("n2")
        End If
    End Sub
End Class