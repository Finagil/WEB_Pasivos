Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
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
        'Session.Item("Movimiento") = "0"
        Dim taEstatus As New WEB_FinagilDSTableAdapters.FOND_EstatusTableAdapter
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnConf As Button = e.Row.Cells(17).FindControl("btnConfirmacion")
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
            End If
            e.Row.Cells(13).Text = CDec(taEdoCta.CapitalPagado(ID, FecFin.Month, FecFin.Year)).ToString("n2")
            e.Row.Cells(14).Text = CDec(taEdoCta.InteresPagado(ID, FecFin.Month, FecFin.Year)).ToString("n2")
            e.Row.Cells(15).Text = CDec(taEdoCta.RetencionPagada(ID, FecFin.Month, FecFin.Year)).ToString("n2")
            Pago = CDec(e.Row.Cells(14).Text)
            e.Row.Cells(16).Text = Math.Abs(CapFinal + Inte + InteAcum + Pago).ToString("n2") ' Saldo Neto
            InteAcum = CDec(e.Row.Cells(16).Text) - CapFinal
            'Session.Item("Movimiento") = DataBinder.Eval(e.Row.DataItem, "id_Movimiento")
            If taEstatus.ObtEstatus_ScalarQuery(DataBinder.Eval(e.Row.DataItem, "id_Movimiento")) = "NE" Then
                btnConf.Enabled = False
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

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim ta_datos As New WEB_FinagilDSTableAdapters.Vw_PasivoNoFiraTableAdapter

        Dim dia As Integer = Day(DateTime.Parse(Me.GridView1.Rows(e.CommandArgument).Cells(3).Text))
        Dim mes As Integer = Month(DateTime.Parse(Me.GridView1.Rows(e.CommandArgument).Cells(3).Text))
        Dim anio As Integer = Year(DateTime.Parse(Me.GridView1.Rows(e.CommandArgument).Cells(3).Text))
        Dim fecha As String = Me.GridView1.Rows(e.CommandArgument).Cells(3).Text

        If e.CommandName = "Confirmacion" Then
            Dim rptSolPago As New ReportDocument
            rptSolPago.Load(Server.MapPath("~/rptConfirmacionSaldos.rpt"))

            rptSolPago.SetParameterValue("var_fondeador", Me.DetailsView1.Rows(1).Cells(1).Text)
            rptSolPago.SetParameterValue("var_anio", Year(CDate(Me.GridView1.Rows(e.CommandArgument).Cells(3).Text)))
            rptSolPago.SetParameterValue("var_mes", MonthName(Month(CDate(Me.GridView1.Rows(e.CommandArgument).Cells(3).Text))))
            rptSolPago.SetParameterValue("var_tasaret", Me.GridView1.Rows(e.CommandArgument).Cells(5).Text)
            rptSolPago.SetParameterValue("var_capital", FormatCurrency(CDec(Me.GridView1.Rows(e.CommandArgument).Cells(6).Text)))
            'rptSolPago.SetParameterValue("var_capital", CDec(ta_datos.CapitalInicial(Me.DetailsView1.Rows(11).Cells(1).Text, "01-" & mes & "-" & anio).ToString) - CDec(ta_datos.FondeosDelMes(Me.DetailsView1.Rows(11).Cells(1).Text, "01-" & mes & "-" & anio, fecha).ToString) - CDec(ta_datos.PagosFondeosCapital(Me.DetailsView1.Rows(11).Cells(1).Text, "01-" & mes & "-" & anio, fecha).ToString))
            'rptSolPago.SetParameterValue("var_interes", FormatCurrency(CDec(Me.GridView1.Rows(e.CommandArgument).Cells(7).Text)))
            rptSolPago.SetParameterValue("var_interes", FormatCurrency(CDbl(ta_datos.InteresInicial(Me.DetailsView1.Rows(11).Cells(1).Text, "01-01-" & anio).ToString) + CDbl(ta_datos.InteresAnual(Me.DetailsView1.Rows(11).Cells(1).Text, "01-01-" & anio.ToString, fecha)) + CDbl(ta_datos.PagoInteresAnual(Me.DetailsView1.Rows(11).Cells(1).Text, "01-01-" & anio.ToString, fecha))))

            rptSolPago.SetParameterValue("var_retencion", FormatCurrency(CDec(Me.GridView1.Rows(e.CommandArgument).Cells(8).Text)))
            rptSolPago.SetParameterValue("var_neto", FormatCurrency(CDec(Me.GridView1.Rows(e.CommandArgument).Cells(9).Text)))
            rptSolPago.SetParameterValue("var_base", Me.GridView1.Rows(e.CommandArgument).Cells(10).Text)
            rptSolPago.SetParameterValue("var_tasaocuota", Me.GridView1.Rows(e.CommandArgument).Cells(11).Text)
            rptSolPago.SetParameterValue("var_tasaretL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(5).Text, "MXN"))
            rptSolPago.SetParameterValue("var_capitalL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(6).Text, "MXN"))
            rptSolPago.SetParameterValue("var_interesL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(7).Text, "MXN"))
            rptSolPago.SetParameterValue("var_retencionL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(8).Text, "MXN"))
            rptSolPago.SetParameterValue("var_netoL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(9).Text, "MXN"))
            rptSolPago.SetParameterValue("var_baseL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(10).Text, "MXN"))
            rptSolPago.SetParameterValue("var_tasaocuotaL", Letras(Me.GridView1.Rows(e.CommandArgument).Cells(11).Text, "MXN"))

            Dim rutaPDF As String = "\Pasivos\tmp\" & Me.DetailsView1.Rows(1).Cells(1).Text & ".pdf"
            rptSolPago.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(rutaPDF))
            Response.Write("<script>")
            rutaPDF = rutaPDF.Replace("\", "/")
            rutaPDF = rutaPDF.Replace("~", "..")
            Response.Write("window.open('" & rutaPDF & "','popup','_blank','width=200,height=200')")
            Response.Write("</script>")
        End If
    End Sub
End Class