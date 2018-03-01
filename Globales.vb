Imports System.Net.Mail
Module Globales

    Public Function CalculaDias() As Integer
        Dim fecha_inicial As Date = Date.Now
        Dim fecha_final As Date = "31/12/" & Date.Now.Year.ToString
        Dim dias As Integer
        While fecha_inicial <= fecha_final
            If fecha_inicial.DayOfWeek <> DayOfWeek.Saturday And fecha_inicial.DayOfWeek <> DayOfWeek.Sunday Then
                dias = dias + 1
            End If
            fecha_inicial = fecha_inicial.AddDays(1)
        End While
        Return (dias)
    End Function

    Public Function DiasHabiles(ByVal F1 As Date, ByVal F2 As Date) As Integer
        Dim dias As Integer
        While F1 < F2
            If F1.DayOfWeek <> DayOfWeek.Saturday And F1.DayOfWeek <> DayOfWeek.Sunday Then
                dias = dias + 1
            End If
            F1 = F1.AddDays(1)
        End While
        Return (dias)
    End Function

    'Public Sub MandaCorreo(ByVal id As Integer, ByVal Notas As String)
    '    Dim tp As New ProductionDSTableAdapters.PromotoresTableAdapter
    '    Dim ts As New ProductionDSTableAdapters.PROM_SeguimientoTableAdapter
    '    Dim tts As New ProductionDS.PROM_SeguimientoDataTable
    '    Dim rr As ProductionDS.PROM_SeguimientoRow
    '    ts.FillByID(tts, id)
    '    rr = tts.Rows(0)
    '    Dim para As String = tp.SacaCorreo(rr.Promotor)
    '    Dim Mensaje As String = ""
    '    Mensaje += "<b>Asignación de prospecto:</b> " & rr.NombreProspecto & "<br>"
    '    Mensaje += "<b>Fecha :</b> " & rr.Fecha.ToShortDateString & "<br>"
    '    Mensaje += "<b>Notas :</b> " & Notas & "<br>"
    '    EnviaCorreo(para, Mensaje, "Asignación de prospecto: " & rr.NombreProspecto)
    'End Sub

    Public Sub EnviaCorreo(ByVal De As String, ByVal Para As String, ByVal Mensaje As String, ByVal Asunto As String)
        Dim Mensage As New MailMessage(De, Trim(Para), Trim(Asunto), Mensaje)
        Dim Cliente As New SmtpClient(My.Settings.SmtpSRV, My.Settings.SmtpPORT)
        Mensage.IsBodyHtml = True
        Cliente.Send(Mensage)
    End Sub

    'Public Sub CargaFacturas()
    '    Dim Baan As New BaanDSTableAdapters.ttfacr962200TableAdapter
    '    Dim Tbaan As New BaanDS.ttfacr962200DataTable
    '    Dim ta As New WEB_FinagilDSTableAdapters.WEB_FacturasTableAdapter
    '    Baan.Fill(Tbaan, Date.Now.AddDays(-40))
    '    For Each r As BaanDS.ttfacr962200Row In Tbaan.Rows
    '        If ta.ExisteFactura(r.factura) <= 0 Then
    '            ta.InsertNuevo(r.factura.Trim, r.rfc.Trim, r.importe, r.fechaproceso, r.fechavencimiento)
    '        End If
    '    Next
    'End Sub

    Public Function EncuentraBaseFOR(Capital As Decimal, Tasa As Decimal, Rete As Decimal, Incre As Decimal) As Decimal
        Dim AuxRete As Decimal
        Dim Diff As Decimal

        For x As Integer = 1 To 1000
            AuxRete = Math.Round(Tasa * Capital, 2)
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
                Capital += Math.Round(Capital * Incre, 6)
            Else
                Capital -= Math.Round(Capital * Incre, 6)
            End If
        Next
        Return Math.Round(Capital, 6)
    End Function

End Module
