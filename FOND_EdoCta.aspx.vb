Public Class FOND_EdoCta
    Inherits System.Web.UI.Page
    Dim FecIni As Date
    Dim cFactor, Aux As String
    Dim Retencion, Rete As Decimal
    Dim Factor As Decimal
    Dim Cap As Decimal
    Dim taEdoCta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            FecIni = DataBinder.Eval(e.Row.DataItem, "FechaInicio")
            FecIni = FecIni.AddDays(FecIni.Day * -1).AddMonths(1) 'ultimo dia del mes
            Cap = taEdoCta.SumCapitalHasta(DataBinder.Eval(e.Row.DataItem, "id_fondeo"), FecIni)
            e.Row.Cells(6).Text = Cap.ToString("n2")
            Rete = DataBinder.Eval(e.Row.DataItem, "Retencion")
            Dim Cont As Integer = 0
            Aux = ""
            If Cap > 0 Then
                Factor = (Rete / Cap)
                cFactor = Factor.ToString()
                For x As Integer = 1 To cFactor.Length
                    If Mid(cFactor, x, 1) = "." Or Cont > 0 Then
                        Cont += 1
                    End If
                    If Cont >= 0 Then
                        Aux += Mid(cFactor, x, 1)
                    End If
                    If Cont = 7 Then
                        Exit For
                    End If
                Next
                Factor = Aux
                e.Row.Cells(11).Text = Math.Abs(Factor)
                e.Row.Cells(10).Text = EncuentraBaseFOR(Cap, Factor, Rete, 0.1).ToString("n2")
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