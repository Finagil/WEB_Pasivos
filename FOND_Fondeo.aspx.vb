Partial Public Class FOND_Fondeo
    Inherits System.Web.UI.Page
    Dim total1 As Decimal
    Dim FechaReem As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = "Detalle del Reembolso "
        FechaReem = Session("FechaReem")
        total1 = 0
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            total1 += DataBinder.Eval(e.Row.DataItem, "PrecioOperacion") + DataBinder.Eval(e.Row.DataItem, "Interes") + DataBinder.Eval(e.Row.DataItem, "Retencion")
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(2).Text = "Totales"
            e.Row.Cells(4).Text = total1.ToString("n2")
            e.Row.HorizontalAlign = HorizontalAlign.Center
            e.Row.Font.Bold = True
            Label3.Text = "Total del Reembolso: " & total1.ToString("n2")
            Himporte.Value = total1.ToString("n2")
        End If
    End Sub


    Protected Sub BotonEnviar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonEnviar1.Click
        Lberror.Visible = False
        Dim Fon As New WEB_FinagilDSTableAdapters.WEB_LotesTableAdapter
        Fon.Reembolsado(FechaReem)

        Dim Msg As String
        Dim Asunto As String
        Msg = "El usuario " & Session("User") & " acaba de confirmar un reembolso:<br>"
        Msg += "Fecha: " & FechaReem & "<br>"
        Msg += "Importe: " & Himporte.Value & "<br>"
        Msg += "<A HREF='http://finagil.com.mx/factoraje'>Web de Factoraje</A>"
        Asunto = "Reembolso Confirmado: " & FechaReem & " (Factoraje)"

        EnviaCorreo(Session("Correo"), My.Settings.CorreoAdmin, Msg, Asunto)
        EnviaCorreo(Session("Correo"), My.Settings.CorreoAdmin2, Msg, Asunto)
        EnviaCorreo(Session("Correo"), "mfuentes@lamoderna.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "ysegura@lamoderna.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "msegura@lamoderna.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "mrodrig@lamoderna.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "hmontes@lamoderna.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "mjimhab@lamoderna.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "ecacerest@finagil.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "gisvazquez@finagil.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "epineda@finagil.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "vcruz@finagil.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "jdelgado@finagil.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "cmonroy@finagil.com.mx", Msg, Asunto)
        EnviaCorreo(Session("Correo"), "gbello@finagil.com.mx", Msg, Asunto)

        'faltan los del PALM

        Response.Redirect("~\Default.aspx")

    End Sub
End Class