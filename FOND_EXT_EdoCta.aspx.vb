Public Class FOND_EXT_EdoCta
    Inherits System.Web.UI.Page
    Dim cFactor, Aux As String
    Dim Retencion, Rete As Decimal
    Dim Factor As Decimal
    Dim Pago, Pag As Decimal
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Pag = DataBinder.Eval(e.Row.DataItem, "Interes")
            Rete = DataBinder.Eval(e.Row.DataItem, "Retencion")
            Dim Cont As Integer = 0
            Aux = ""
            Factor = (Rete / Pag)
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
            e.Row.Cells(10).Text = EncuentraBaseFOR(Pag, Factor, Rete, 0.1).ToString("n2")
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
    Function EncuentraBaseFOR(Pago As Decimal, Tasa As Decimal, Rete As Decimal, Incre As Decimal) As Decimal
        Dim AuxRete As Decimal
        Dim Diff As Decimal

        For x As Integer = 1 To 1000
            AuxRete = Math.Round(Tasa * Pago, 2)
            Diff = Math.Round(Rete - AuxRete, 2)
            Select Case Math.Abs(Diff)
                Case >= 1000
                    Incre = 0.1
                Case > 100
                    Incre = 0.01
                Case > 10
                    Incre = 0.0001
                Case > 1
                    Incre = 0.00001
                Case > 0.02
                    Incre = 0.000001
                Case > 0.01
                    Incre = 0.0000001
                Case <= 0.0
                    Exit For
            End Select

            If Diff > 0 Then
                Pago += Math.Round(Pago * Incre, 6)
            Else
                Pago -= Math.Round(Pago * Incre, 6)
            End If
        Next
        Return Math.Round(Pago, 6)
    End Function
End Class