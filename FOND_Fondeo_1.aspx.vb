Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class FOND_Fondeo_1
    Inherits System.Web.UI.Page
    Dim ta_f As New WEB_FinagilDSTableAdapters.FOND_FondeadoresTableAdapter
    Dim ta_frpt As New WEB_FinagilDSTableAdapters.FOND_FondeosRPTTableAdapter
    Dim ds_f As New WEB_FinagilDS
    Dim ta_datos As New WEB_FinagilDSTableAdapters.Vw_PasivoNoFiraTableAdapter
    Dim ds_d As New WEB_FinagilDS
    Dim arreglo(ds_f.FOND_FondeosRPT.Rows.Count - 1, 11) As String
    Dim rpt_RNF As New ReportDocument
    Dim rpt_RNF2 As New ReportDocument
    Dim fecha As Integer  'Month(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))
    Dim fechaYear As String  'Request.Form(txtFechaBusqueda.UniqueID)
    Dim fechaY As Integer  'Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))
    Dim dtArreglo As New DataTable("reporteNF")

    Public Sub calcula()

        fecha = Month(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))
        fechaYear = Request.Form(txtFechaBusqueda.UniqueID)
        fechaY = Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID)))

        ta_f.Fill(ds_f.FOND_Fondeadores)
        ta_frpt.Fill(ds_f.FOND_FondeosRPT)

        Dim row As WEB_FinagilDS.FOND_FondeosRPTRow

        ReDim arreglo(ds_f.FOND_FondeosRPT.Rows.Count - 1, 11)

        Dim cont As Integer = 0
        For Each row In ds_f.FOND_FondeosRPT.Rows
            arreglo(cont, 0) = row.Item(0)
            arreglo(cont, 1) = ta_datos.CapitalInicial(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString).ToString
            'MsgBox((ta_datos.InteresInicial(row(0), "01-01-" & fechaY.ToString)).ToString + vbNewLine + (ta_datos.InteresFechaMenor(row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString)).ToString + vbNewLine + (ta_datos.PagoFechaMenor(row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString)).ToString)
            arreglo(cont, 2) = Val(ta_datos.InteresInicial(row(0), "01-01-" & fechaY.ToString)) + Val(ta_datos.InteresFechaMenor(row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString)) + Val(ta_datos.PagoFechaMenor(row(0), "01-01-" & fechaY.ToString, "01-" & fecha.ToString & "-" & fechaY.ToString))
            arreglo(cont, 3) = ta_datos.FondeosDelMes(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(cont, 4) = ta_datos.PagosFondeosCapital(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(cont, 5) = ta_datos.PagosFondeosInteres(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(cont, 6) = ta_datos.InteresDelMes(row.Item(0), "01-" & fecha.ToString & "-" & fechaY.ToString, fechaYear).ToString
            arreglo(cont, 7) = ta_datos.Descripcion(row.Item(0)).ToString
            arreglo(cont, 8) = ta_datos.Moneda(row.Item(0)).ToString
            arreglo(cont, 9) = CDbl(ta_datos.InteresInicial(row.Item(0), "01-01-" & fechaY.ToString).ToString) + CDbl(ta_datos.InteresAnual(row.Item(0), "01-01-" & fechaY.ToString, fechaYear)) + CDbl(ta_datos.PagoInteresAnual(row.Item(0), "01-01-" & fechaY.ToString, fechaYear))
            arreglo(cont, 10) = ta_datos.id_Fondeador(row.Item(0))
            arreglo(cont, 11) = ta_datos.id_Fondeador2(row.Item(0))
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
        For fila As Integer = 0 To ds_f.FOND_FondeosRPT.Rows.Count - 1
            rowRNF = dtArreglo.NewRow
            rowRNF("Fondeador") = arreglo(cont2, 0)
            rowRNF("Capital_Inicial") = arreglo(cont2, 1)
            rowRNF("Interes_Inicial") = arreglo(cont2, 2)
            rowRNF("Fondeo_del_mes") = Math.Abs(CDbl(arreglo(cont2, 3)))
            rowRNF("Pago_Fondeo_Capital") = Math.Abs(CDbl(arreglo(cont2, 4)))
            rowRNF("Pago_Fondeo_Interes") = arreglo(cont2, 5)
            rowRNF("Interes_Mes") = arreglo(cont2, 6)
            rowRNF("Descripcion") = arreglo(cont2, 7)
            rowRNF("Moneda") = arreglo(cont2, 8)
            rowRNF("Capital_Final") = 0
            rowRNF("Interes_Final") = arreglo(cont2, 9)
            rowRNF("Fondeo") = arreglo(cont2, 10)
            rowRNF("Fondeo2") = arreglo(cont2, 11)
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