Partial Public Class ConfReembolso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Session.Item("FechaReem") = GridView1.SelectedDataKey(1)
        Response.Redirect("~\DetalleReembolso.aspx")
    End Sub
End Class