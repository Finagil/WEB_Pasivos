Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class FOND_Fondeo_1
    Inherits System.Web.UI.Page
    Dim ta_f As New WEB_FinagilDSTableAdapters.FOND_Fondeadores1TableAdapter
    Dim ds_f As New WEB_FinagilDS
    Dim ta_datos As New WEB_FinagilDSTableAdapters.Vw_PasivoNoFiraTableAdapter
    Dim ds_d As New WEB_FinagilDS


    Protected Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

        ta_f.Fill(ds_f.FOND_Fondeadores1)
        Dim arreglo(ds_f.FOND_Fondeadores1.Rows.Count - 1, 8) As String
        Dim row As WEB_FinagilDS.FOND_Fondeadores1Row
        Dim fecha As Integer = Month(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))) 'Date.Now.Month
        Dim cont As Integer = 0
        For Each row In ds_f.FOND_Fondeadores1.Rows
            arreglo(cont, 0) = row.Item(1)
            arreglo(cont, 1) = ta_datos.CapitalInicial(fecha, row.Item(0)).ToString
            arreglo(cont, 2) = ta_datos.InteresInicial(fecha, row.Item(0)).ToString
            arreglo(cont, 3) = ta_datos.FondeosDelMes(fecha, row.Item(0)).ToString
            arreglo(cont, 4) = ta_datos.PagosFondeosCapital(fecha, row.Item(0)).ToString
            arreglo(cont, 5) = ta_datos.PagosFondeosInteres(fecha, row.Item(0)).ToString
            arreglo(cont, 6) = ta_datos.InteresDelMes(fecha, row.Item(0)).ToString
            arreglo(cont, 7) = ta_datos.Descripcion(row.Item(0)).ToString
            arreglo(cont, 8) = ta_datos.Moneda(row.Item(0)).ToString
            cont += 1
        Next

        Dim dtArreglo As New DataTable("reporteNF")
        dtArreglo.Columns.Add("Fondeador")
        dtArreglo.Columns.Add("Capital_Inicial", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Interes_Inicial", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Fondeo_del_mes", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Pago_Fondeo_Capital", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Pago_Fondeo_Interes", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Interes_Mes", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Capital_Final", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Interes_Final", Type.GetType("System.Decimal"))
        dtArreglo.Columns.Add("Descripcion")
        dtArreglo.Columns.Add("Moneda")

        Dim rowRNF As DataRow
        Dim cont2 As Integer = 0
        For fila As Integer = 0 To ds_f.FOND_Fondeadores1.Rows.Count - 1
            rowRNF = dtArreglo.NewRow
            rowRNF("Fondeador") = arreglo(cont2, 0)
            rowRNF("Capital_Inicial") = arreglo(cont2, 1)
            rowRNF("Interes_Inicial") = arreglo(cont2, 2)
            rowRNF("Fondeo_del_mes") = arreglo(cont2, 3)
            rowRNF("Pago_Fondeo_Capital") = arreglo(cont2, 4)
            rowRNF("Pago_Fondeo_Interes") = arreglo(cont2, 5)
            rowRNF("Interes_Mes") = arreglo(cont2, 6)
            rowRNF("Descripcion") = arreglo(cont2, 7)
            rowRNF("Moneda") = arreglo(cont2, 8)
            rowRNF("Capital_Final") = 0
            rowRNF("Interes_Final") = 0
            dtArreglo.Rows.Add(rowRNF)
            cont2 += 1
        Next

        'dtArreglo.WriteXml("E:\dtArregloRNF.xml", XmlWriteMode.WriteSchema)

        Dim rpt_RNF As New ReportDocument
        rpt_RNF.Load(Server.MapPath("~/rpt_RNF.rpt"))
        rpt_RNF.SetDataSource(dtArreglo)
        rpt_RNF.SetParameterValue("var_dia", Day(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))
        rpt_RNF.SetParameterValue("var_mes", MonthName(fecha))
        rpt_RNF.SetParameterValue("var_anio", Year(DateTime.Parse(Request.Form(txtFechaBusqueda.UniqueID))))

        Dim ruta As String = "~\tmp\" & Date.Now.ToString("yyyyMMddmmss") & ".pdf"
        rpt_RNF.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(ruta))
        Response.Write("<script>")
        ruta = ruta.Replace("\", "/")
        ruta = ruta.Replace("~", ".")
        Response.Write("window.open('" & ruta & "','_blank')")
        Response.Write("</script>")
        Response.Write(ruta)

    End Sub

End Class