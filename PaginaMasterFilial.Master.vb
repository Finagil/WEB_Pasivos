Partial Public Class PaginaMasterFilial
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LbDias.Text = "Pasivos Finagil"
        'If UCase(Session.Item("User")) = "RALCANTARA" Then
        '    Menu1.Items(2).Enabled = True
        'End If
    End Sub

End Class