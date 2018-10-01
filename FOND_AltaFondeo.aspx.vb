Imports System.IO
Partial Public Class AltaFondeo
    Inherits System.Web.UI.Page

    Protected Function ValidaArchivo() As Boolean
        ValidaArchivo = True
        If cmbTipoFondeo.Text = "1" And CmbTasas.Text <> "Tasa Fija" Then
            LbErrorGlobal.Text = "Un Credito INDIVIDUAL solo puede tener Tasa Fija."
            ValidaArchivo = False
        End If
        If FileUpload2.FileName.Length > 0 Then
            Dim Linea As String
            Dim Datos() As String
            FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Docs/") & FileUpload2.FileName)
            Dim F As New StreamReader(Server.MapPath("~/Docs/") & FileUpload2.FileName)
            While Not F.EndOfStream
                Linea = F.ReadLine
                Datos = Linea.Split(",")
                If Datos.Length <> 2 Then ValidaArchivo = False
                If Not IsDate(Datos(0)) Then ValidaArchivo = False
                If Not IsNumeric(Datos(1)) Then ValidaArchivo = False
                Lberror.Text = "Archivo Inválido"
            End While
        Else
            If cmbTipoFondeo.Text = "1" Then
                ValidaArchivo = False
                Lberror.Text = "Se requiere tabla de pagos"
            End If
        End If
        Lberror.Visible = Not ValidaArchivo
        LbErrorGlobal.Visible = Not ValidaArchivo
        Return ValidaArchivo
    End Function
    Protected Sub BotonEnviar1_Click(sender As Object, e As EventArgs) Handles BotonEnviar1.Click
        Try
            If ValidaArchivo() Then
                Dim ta As New WEB_FinagilDSTableAdapters.FOND_FondeosTableAdapter
                Dim F1 As DateTime = DateTime.Parse(Request.Form(TextBox1.UniqueID))
                Dim F2 As DateTime = DateTime.Parse(Request.Form(TextBox2.UniqueID))
                Dim F3 As DateTime = DateTime.Parse(Request.Form(TextBox3.UniqueID))

                If F1 <= Date.Now.Date.AddDays(Date.Now.Day * -1) Then
                    LbErrorGlobal.Text = "Fecha incorrecta, no se puede usar fecha del mes anterior."
                    LbErrorGlobal.Visible = True
                Else
                    ta.Insert(cmbFondeador.SelectedValue, cmbTipoFondeo.SelectedValue, TxtDesc.Text.ToUpper,
                            F1, F2, CmbTasas.SelectedValue, CDec(TxtDiff.Text),
                            FileUpload1.FileName, "VIGENTE", F3, cmbMoneda.SelectedValue, CkFactoraje.Checked)
                    Dim ID As Integer = ta.MaxID
                    If FileUpload1.FileName.Length > 0 Then
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Docs/") & ID.ToString & FileUpload1.FileName)
                    End If
                    If FileUpload2.FileName.Length > 0 Then
                        Dim Linea As String
                        Dim Datos() As String
                        Dim F As New StreamReader(Server.MapPath("~/Docs/") & FileUpload2.FileName)
                        Dim ta1 As New WEB_FinagilDSTableAdapters.FOND_FechasPagoCapitalTableAdapter
                        While Not F.EndOfStream
                            Linea = F.ReadLine
                            Datos = Linea.Split(",")
                            ta1.Insert(ID, Datos(0), Datos(1))
                        End While
                    End If
                    Response.Redirect("~\FOND_AltaCapital.aspx?id_fondeo=" & ID, True)
                End If
            End If
        Catch ex As Exception
            LbErrorGlobal.Text = ex.Message
            LbErrorGlobal.Visible = True
        End Try
    End Sub


End Class