Public Class FOND_SaldosAll
    Inherits System.Web.UI.Page
    Dim taAll As New WEB_FinagilDSTableAdapters.FOND_SaldoGarantiasTableAdapter
    Protected Sub GridView1All_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1All.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(11).Text = CDec(taAll.SaldoGarantia(DataBinder.Eval(e.Row.DataItem, "id_fondeo"))).ToString("n2")
        End If
    End Sub
End Class