Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class FOND_Fondeo_1
    Inherits System.Web.UI.Page
    Dim ta_f As New WEB_FinagilDSTableAdapters.FOND_FondeadoresTableAdapter
    Dim ta_frpt As New WEB_FinagilDSTableAdapters.FOND_FondeosRPTTableAdapter
    Dim ds_f As New WEB_FinagilDS
    Dim ta_datos As New WEB_FinagilDSTableAdapters.Vw_PasivoNoFiraTableAdapter
    Dim ta_tc As New WEB_FinagilDSTableAdapters.CONT_TiposDeCambioTableAdapter
    Dim ds_d As New WEB_FinagilDS
    Dim arreglo(11, ds_f.FOND_FondeosRPT.Rows.Count - 1) As String
    Dim rpt_RNF As New ReportDocument
    Dim rpt_RNF2 As New ReportDocument
    Dim fecha As Integer  'Month(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))
    Dim fechaYear As String  'Request.Form(txtFechaBusqueda.UniqueID)
    Dim fechaY As Integer  'Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))
    Dim dtArreglo As New DataTable("reporteNF")
    Dim longVert As Integer = 0

    Public Sub calcula()

        fecha = Month(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))
        fechaYear = Request.Form(txtFechaBusqueda.UniqueID)
        fechaY = Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))

        ta_f.Fill(ds_f.FOND_Fondeadores)
        ta_frpt.Fill(ds_f.FOND_FondeosRPT)

        Dim row As WEB_FinagilDS.FOND_FondeosRPTRow

        ReDim arreglo(11, ds_f.FOND_FondeosRPT.Rows.Count - 1)

        Dim cont As Integer = 0
        For Each row In ds_f.FOND_FondeosRPT.Rows
            arreglo(0, cont) = row.Item(0)

            arreglo(1, cont) = ta_datos.CapitalInicial(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString).ToString
            arreglo(2, cont) = Val(ta_datos.InteresInicial(row(0), "01-01-" & fechaY.ToString)) + Val(ta_datos.InteresFechaMenor(row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString)) + Val(ta_datos.PagoFechaMenor(row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString))
            arreglo(3, cont) = ta_datos.FondeosDelMes(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(4, cont) = ta_datos.PagosFondeosCapital(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(5, cont) = ta_datos.PagosFondeosInteres(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(6, cont) = ta_datos.InteresDelMes(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(7, cont) = ta_datos.Descripcion(row.Item(0)).ToString
            arreglo(8, cont) = ta_datos.Moneda(row.Item(0)).ToString
            arreglo(9, cont) = CDbl(ta_datos.InteresInicial(row.Item(0), "01-01-" & fechaY.ToString).ToString) + CDbl(ta_datos.InteresAnual(row.Item(0), "01-01-" & fechaY.ToString, fechaYear)) + CDbl(ta_datos.PagoInteresAnual(row.Item(0), "01-01-" & fechaY.ToString, fechaYear))
            arreglo(10, cont) = ta_datos.id_Fondeador(row.Item(0))
            arreglo(11, cont) = ta_datos.id_Fondeador2(row.Item(0))
            If ta_datos.Moneda(row.Item(0)).ToString <> "MXN" Then

                'Capital Inicial
                ta_datos.CapitalIniciaDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-" & fecha.ToString & "-" & fechaY.ToString)
                Dim var_capitalInicial As Double = 0
                For Each capital_inicial As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_capitalInicial += Val(capital_inicial.Importe) * Val(ta_tc.ObtieneTC(capital_inicial.FechaInicio))
                Next
                'Interes inicial 1
                ta_datos.InteresInicialDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-01-" & fechaY.ToString)
                Dim var_interesInicial1 As Double = 0
                For Each interes_inicial1 As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_interesInicial1 += Val(interes_inicial1.Interes) * Val(ta_tc.ObtieneTC(interes_inicial1.FechaInicio))
                Next
                'Interes inicial 2
                ta_datos.InteresFechaMenorDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString)
                Dim var_interesInicial2 As Double = 0
                For Each interes_inicial2 As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_interesInicial2 += Val(interes_inicial2.Interes) * Val(ta_tc.ObtieneTC(interes_inicial2.FechaInicio))
                Next
                'Interes inicial 3
                ta_datos.PagoFechaMenorDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString)
                Dim var_interesInicial3 As Double = 0
                For Each interes_inicial3 As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_interesInicial3 += Val(interes_inicial3.Interes) * Val(ta_tc.ObtieneTC(interes_inicial3.FechaInicio))
                Next
                'Fondeos del mes
                ta_datos.FondeoDelMesDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear)
                Dim var_fondeoDelMes As Double = 0
                For Each fondeoDelMes As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_fondeoDelMes += Val(fondeoDelMes.Importe) * Val(ta_tc.ObtieneTC(fondeoDelMes.FechaInicio))
                Next

                'Pagos fondeo capital
                ta_datos.PagosFondeosCapitalDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear)
                Dim var_pagosFondeoCapital As Double = 0
                For Each pagosFondeoCapital As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_pagosFondeoCapital += Val(pagosFondeoCapital.Importe) * Val(ta_tc.ObtieneTC(pagosFondeoCapital.FechaInicio))
                Next
                'Pagos fondeo interes
                ta_datos.PagosFondeosInteresDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear)
                Dim var_pagosFondeoInteres As Double = 0
                For Each pagosFondeoInteres As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_pagosFondeoInteres += Val(pagosFondeoInteres.Interes) * Val(ta_tc.ObtieneTC(pagosFondeoInteres.FechaInicio))
                Next
                'Interes del mes
                ta_datos.InteresDelMesDiv_FillBy(ds_d.Vw_PasivoNoFira, row(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear)
                Dim var_interesDelMes As Double = 0
                For Each interesDelMes As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_interesDelMes += Val(interesDelMes.Interes) * Val(ta_tc.ObtieneTC(interesDelMes.FechaInicio))
                Next
                'Interes anual
                ta_datos.InteresAnualDiv_FillBy(ds_d.Vw_PasivoNoFira, row.Item(0), "01-01-" & fechaY.ToString, fechaYear)
                Dim var_interesAnual As Double = 0
                For Each interesAnual As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_interesAnual += Val(interesAnual.Interes) * Val(ta_tc.ObtieneTC(interesAnual.FechaInicio))
                Next
                'Pago interes anual
                ta_datos.PagoInteresAnualDiv_FillBy(ds_d.Vw_PasivoNoFira, row.Item(0), "01-01-" & fechaY.ToString, fechaYear)
                Dim var_pagoInteresAnual As Double = 0
                For Each pagoInteresAnual As WEB_FinagilDS.Vw_PasivoNoFiraRow In ds_d.Vw_PasivoNoFira.Rows
                    var_pagoInteresAnual += Val(pagoInteresAnual.Interes) * Val(ta_tc.ObtieneTC(pagoInteresAnual.FechaInicio))
                Next



                longVert += 1
                ReDim Preserve arreglo(11, ds_f.FOND_FondeosRPT.Rows.Count - 1 + longVert)
                cont += 1
                arreglo(0, cont) = row.Item(0)
                If arreglo(1, cont - 1) > 0 Then
                    arreglo(1, cont) = var_capitalInicial.ToString
                Else
                    arreglo(1, cont) = 0
                End If

                If arreglo(2, cont - 1) > 0 Then
                    arreglo(2, cont) = var_interesInicial1 + var_interesInicial2 + var_interesInicial3
                Else
                    arreglo(2, cont) = 0
                End If

                If arreglo(3, cont - 1) > 0 Then
                    arreglo(3, cont) = var_fondeoDelMes
                Else
                    arreglo(3, cont) = 0
                End If

                If arreglo(4, cont - 1) > 0 Then
                    arreglo(4, cont) = var_pagosFondeoCapital
                Else
                    arreglo(4, cont) = 0
                End If

                If arreglo(5, cont - 1) > 0 Then
                    arreglo(5, cont) = var_pagosFondeoInteres
                Else
                    arreglo(5, cont) = 0
                End If

                If arreglo(6, cont - 1) > 0 Then
                    arreglo(6, cont) = var_interesDelMes
                Else
                    arreglo(6, cont) = 0
                End If

                arreglo(7, cont) = "*** " & ta_datos.Descripcion(row.Item(0)).ToString & " en MXN"
                arreglo(8, cont) = "MXN"

                If arreglo(9, cont - 1) > 0 Then
                    arreglo(9, cont) = var_interesInicial1 + var_interesAnual + var_pagoInteresAnual
                Else
                    arreglo(9, cont) = 0
                End If
                arreglo(10, cont) = ta_datos.id_Fondeador(row.Item(0))
                arreglo(11, cont) = ta_datos.id_Fondeador2(row.Item(0))
            End If
            cont += 1
        Next


        dtArreglo.Columns.Add("Fondeador")
        dtArreglo.Columns.Add("Capital_Inicial", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Interes_Inicial", Type.GetType("System.Double"))
        dtArreglo.Columns.Add("Fondeo_del_mes", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Pago_Fondeo_Capital", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Pago_Fondeo_Interes", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Interes_Mes", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Capital_Final", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Interes_Final", Type.GetType("System.Double"))
        dtArreglo.Columns.Add("Descripcion")
        dtArreglo.Columns.Add("Moneda")
        dtArreglo.Columns.Add("Fondeo")
        dtArreglo.Columns.Add("Fondeo2", Type.GetType("System.Decimal"))

        Dim rowRNF As DataRow
        Dim cont2 As Integer = 0
        For fila As Integer = 0 To ds_f.FOND_FondeosRPT.Rows.Count - 1 + longVert
            rowRNF = dtArreglo.NewRow
            rowRNF("Fondeador") = arreglo(0, cont2)
            rowRNF("Capital_Inicial") = arreglo(1, cont2)
            rowRNF("Interes_Inicial") = arreglo(2, cont2)
            rowRNF("Fondeo_del_mes") = Math.Abs(CDbl(arreglo(3, cont2)))
            rowRNF("Pago_Fondeo_Capital") = Math.Abs(CDbl(arreglo(4, cont2)))
            rowRNF("Pago_Fondeo_Interes") = arreglo(5, cont2)
            rowRNF("Interes_Mes") = arreglo(6, cont2)
            rowRNF("Descripcion") = arreglo(7, cont2)
            rowRNF("Moneda") = arreglo(8, cont2)
            rowRNF("Capital_Final") = 0
            rowRNF("Interes_Final") = arreglo(9, cont2)
            rowRNF("Fondeo") = arreglo(10, cont2)
            rowRNF("Fondeo2") = arreglo(11, cont2)
            dtArreglo.Rows.Add(rowRNF)
            cont2 += 1
        Next
    End Sub

    Protected Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

        calcula()
        'dtArreglo.WriteXml("E:\dtArregloRNF.xml", XmlWriteMode.WriteSchema)
        rpt_RNF.Load(Server.MapPath("~/rpt_RNF.rpt"))
        rpt_RNF.SetDataSource(dtArreglo)
        rpt_RNF.SetParameterValue("var_dia", Day(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))
        rpt_RNF.SetParameterValue("var_mes", MonthName(fecha))
        rpt_RNF.SetParameterValue("var_anio", Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))

        Dim rutaPDF As String = "\Pasivos\tmp\" & Date.Now.ToString("yyyyMMddmmss") & ".pdf"
        rpt_RNF.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(rutaPDF))
        Response.Write("<script>")
        rutaPDF = rutaPDF.Replace("\", "/")
        rutaPDF = rutaPDF.Replace("~", "..")
        Response.Write("window.open('" & rutaPDF & "','_blank')")
        Response.Write("</script>")
        'Response.Write(rutaPDF)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnProcesar0_Click(sender As Object, e As EventArgs) Handles btnProcesar0.Click
        calcula()
        'dtArreglo.WriteXml("E:\dtArregloRNF.xml", XmlWriteMode.WriteSchema)
        rpt_RNF.Load(Server.MapPath("~/rpt_RNF.rpt"))
        rpt_RNF.SetDataSource(dtArreglo)
        rpt_RNF.SetParameterValue("var_dia", Day(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))
        rpt_RNF.SetParameterValue("var_mes", MonthName(fecha))
        rpt_RNF.SetParameterValue("var_anio", Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))

        Dim rutaPDF As String = "\Pasivos\tmp\" & Date.Now.ToString("yyyyMMddmmss") & ".xls"
        rpt_RNF.ExportToDisk(ExportFormatType.Excel, Server.MapPath(rutaPDF))
        Response.Write("<script>")
        rutaPDF = rutaPDF.Replace("\", "/")
        rutaPDF = rutaPDF.Replace("~", "..")
        Response.Write("window.open('" & rutaPDF & "','_blank')")
        Response.Write("</script>")
        'Response.Write(rutaPDF)
    End Sub

    Protected Sub btnProcesar1_Click(sender As Object, e As EventArgs) Handles btnProcesar1.Click

        calcula()
        'dtArreglo.WriteXml("E:\dtArregloRNF.xml", XmlWriteMode.WriteSchema)
        rpt_RNF.Load(Server.MapPath("~/rptPasivosNF.rpt"))
        rpt_RNF.SetDataSource(dtArreglo)
        rpt_RNF.SetParameterValue("var_dia", Day(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))
        rpt_RNF.SetParameterValue("var_mes", MonthName(fecha))
        rpt_RNF.SetParameterValue("var_anio", Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))

        Dim rutaPDF As String = "\Pasivos\tmp\" & Date.Now.ToString("yyyyMMddmmss") & ".pdf"
        rpt_RNF.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(rutaPDF))
        Response.Write("<script>")
        rutaPDF = rutaPDF.Replace("\", "/")
        rutaPDF = rutaPDF.Replace("~", "..")
        Response.Write("window.open('" & rutaPDF & "','_blank')")
        Response.Write("</script>")
        'Response.Write(rutaPDF)

    End Sub

    Protected Sub btnProcesar2_Click(sender As Object, e As EventArgs) Handles btnProcesar2.Click
        calcula()
        'dtArreglo.WriteXml("E:\dtArregloRNF.xml", XmlWriteMode.WriteSchema)
        rpt_RNF.Load(Server.MapPath("~/rptPasivosNF.rpt"))
        rpt_RNF.SetDataSource(dtArreglo)
        rpt_RNF.SetParameterValue("var_dia", Day(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))
        rpt_RNF.SetParameterValue("var_mes", MonthName(fecha))
        rpt_RNF.SetParameterValue("var_anio", Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))

        Dim rutaPDF As String = "\Pasivos\tmp\" & Date.Now.ToString("yyyyMMddmmss") & ".xls"
        rpt_RNF.ExportToDisk(ExportFormatType.Excel, Server.MapPath(rutaPDF))
        Response.Write("<script>")
        rutaPDF = rutaPDF.Replace("\", "/")
        rutaPDF = rutaPDF.Replace("~", "..")
        Response.Write("window.open('" & rutaPDF & "','_blank')")
        Response.Write("</script>")
        'Response.Write(rutaPDF)

    End Sub

End Class