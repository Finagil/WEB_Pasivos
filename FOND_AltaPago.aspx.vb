﻿Public Class FOND_AltaPago
    Inherits System.Web.UI.Page
    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        Dim row As DataRowView = DetailsView1.DataItem
        TextBox1.Text = CDate(row("FechaInicio")).ToShortDateString
    End Sub

    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Try
            If Validaciones() = True Then
                Dim ID As Integer = Request.QueryString("ID_fondeo")
                Dim ta As New WEB_FinagilDSTableAdapters.FOND_EstadoCuentaTableAdapter
                Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
                ta.Insert(ID, "PAGO", CDec(TxtImporte.Text) * -1, CDec(TxtInteres.Text) * -1, 0, 0, F1, F1, 0, 0)
                Response.Redirect("~\FOND_ConsultaFondeo.aspx", True)
            End If
        Catch ex As Exception
            LberrorGlobal.Text = ex.Message
            LberrorGlobal.Visible = True
        End Try
    End Sub

    Function Validaciones() As Boolean
        Validaciones = True
        If Val(TxtInteres.Text) > 0 Then
            If Val(TxtRetencion.Text) <= 0 Then
                LberrorGlobal.Text = "Falta la retención."
                Validaciones = False
            End If
        End If
        LberrorGlobal.Visible = Not Validaciones
        Return Validaciones
    End Function
End Class