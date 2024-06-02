Imports System.Deployment.Application
Public Class Infos
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
        If Opt_Analyses = True Then Acceuil.Button1.Visible = True
        If Opt_Alarmes = True Then Acceuil.Button9.Visible = True
        Acceuil.Button2.Visible = True
        Acceuil.Button4.Visible = True
        Acceuil.Button6.Visible = True
        Acceuil.Button5.Visible = True
        Acceuil.Button3.Visible = True
        Acceuil.Panel1.Visible = False
        Acceuil.TextBox1.Select()

    End Sub

    Private Sub Infos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim B1 = "Acceuil"
        Dim B2 = "Contact"
        Dim B3 = "Envoyer le message"

        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Infos" And lang(1) = Langue Then
                    B1 = lang(2)
                    B2 = lang(3)
                    GroupBox1.Text = lang(4)
                    Label3.Text = lang(5)
                    Label4.Text = lang(6)
                    Label5.Text = lang(7)
                    Label6.Text = lang(8)
                    Label8.Text = lang(9)
                    Label7.Text = lang(10)
                    Label9.Text = lang(11)
                    B3 = lang(12)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try
        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button1, B1)
        tooltip1.SetToolTip(Button2, B2)
        tooltip1.SetToolTip(Button3, B3)
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500

    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover

        Button1.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave

        Button1.FlatStyle = FlatStyle.Flat

    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover

        Button2.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave

        Button2.FlatStyle = FlatStyle.Flat

    End Sub
    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover

        Button3.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave

        Button3.FlatStyle = FlatStyle.Flat

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        If GroupBox1.Visible = True Then
            GroupBox1.Visible = False
            PictureBox1.Visible = True
        Else
            GroupBox1.Visible = True
            PictureBox1.Visible = False
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim M1 = "Veuillez remplir les champs obligatoires"
        Dim M2 = "Message envoyé"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Infos" And lang(1) = Langue Then
                    M1 = lang(13)
                    M2 = lang(14)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        Dim mess = TextBox1.Text + "   " + TextBox2.Text + "   " + TextBox3.Text + "   " + TextBox4.Text + "   " + TextBox5.Text + "   " + RichTextBox1.Text
        Dim ema = TextBox5.Text
        If TextBox1.Text = "" Or TextBox5.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox(M1)
        Else
            Envoie_contact_mail(mess)
            MsgBox(M2)
            GroupBox1.Visible = False
            Button2.Visible = True
            PictureBox1.Visible = True

        End If
    End Sub

End Class