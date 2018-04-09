Public Class FOND_Tabla
    Inherits System.Web.UI.Page
    Dim Total As Decimal

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Total += DataBinder.Eval(e.Row.DataItem, "Capital")
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(3).Text = Total.ToString("n2")
        End If
    End Sub
End Class