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

    Public Sub EnviaCorreo(ByVal De As String, ByVal Para As String, ByVal Mensaje As String, ByVal Asunto As String)
        Dim taCorreos As New WEB_FinagilDSTableAdapters.GEN_Correos_SistemaFinagilTableAdapter
        taCorreos.Insert(De, Para, Asunto, Mensaje, False, Date.Now, "")
        taCorreos.Dispose()
    End Sub

    Public Function EncuentraBaseFOR(Capital As Decimal, Tasa As Decimal, Rete As Decimal, Incre As Decimal) As Decimal
        Dim AuxRete As Decimal
        Dim Diff As Decimal

        For x As Integer = 1 To 100000
            AuxRete = Math.Round(Tasa * Capital, 6)
            Diff = Math.Round(Rete - AuxRete, 2)
            Select Case Math.Abs(Diff)
                Case 0.0
                    Exit For
                Case Else
                    Incre = 0.01
            End Select

            If Diff > 0 Then
                Capital += Incre
            Else
                Capital -= Incre
            End If
        Next
        Return Math.Round(Capital, 4)
    End Function

    Sub ProcesaCalculos(ID As Integer)
        If System.IO.File.Exists(My.Settings.RutaPROC1 & My.Settings.PROC) Then
            Shell(My.Settings.RutaPROC1 & My.Settings.PROC & " PASIVOS " & ID, AppWinStyle.NormalFocus, True)
        Else
            If System.IO.File.Exists(My.Settings.RutaPROC2 & My.Settings.PROC) Then
                Shell(My.Settings.RutaPROC2 & My.Settings.PROC & " PASIVOS " & ID, AppWinStyle.NormalFocus, True)
            End If
        End If
    End Sub

End Module
