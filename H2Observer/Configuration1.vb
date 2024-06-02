Imports System.IO
Imports System.Text

Imports System.IO.File

Public Class Configuration1
    Private Sub Configuration1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = True
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        TextBox8.Visible = False
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        ComboBox3.Visible = False
        Label5.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label8.Visible = False
        Button1.Visible = False
        CheckBox1.Visible = False
        TextBox1.Visible = False
        Label6.Visible = False

        TextBox2.Select()

        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim B1 = "Acceuil"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If Not (ComboBox3.Items.Contains(lang(1))) Then
                    ComboBox3.Items.Add(lang(1))
                End If
                If lang(0) = "Configuration1" And lang(1) = Langue Then
                    GroupBox1.Text = lang(2)
                    B1 = lang(3)
                    Label8.Text = lang(4)
                    Label1.Text = lang(5)
                    Label2.Text = lang(6)
                    CheckBox1.Text = lang(7)
                    Label3.Text = lang(8)
                    GroupBox3.Text = lang(9)
                    GroupBox4.Text = lang(10)
                    Label6.Text = lang(12)
                    Exit Do
                End If

            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Configuration1_load() ligne 68" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        '---------------------------------------------------------------------
        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button1, B1)
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500

        Dim hi
        For i = 0 To 23
            hi = i.ToString("00")
            ComboBox1.Items.Add(hi)
            ComboBox2.Items.Add(hi)
        Next i
        ComboBox1.Text = "08"
        ComboBox2.Text = "09"
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"

        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            Dim tableau_conf1()
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            TextBox8.Text = tableau_conf1(0)
            ComboBox1.Text = tableau_conf1(1)
            ComboBox2.Text = tableau_conf1(2)
            TextBox9.Text = tableau_conf1(3)
            TextBox10.Text = tableau_conf1(4)
            TextBox11.Text = tableau_conf1(5)
            TextBox12.Text = tableau_conf1(6)
            TextBox13.Text = tableau_conf1(7)
            TextBox14.Text = tableau_conf1(8)
            TextBox15.Text = tableau_conf1(9)
            TextBox16.Text = tableau_conf1(10)
            TextBox17.Text = tableau_conf1(11)
            TextBox18.Text = tableau_conf1(12)
            TextBox19.Text = tableau_conf1(13)
            TextBox20.Text = tableau_conf1(14)
            TextBox21.Text = tableau_conf1(15)
            TextBox22.Text = tableau_conf1(16)
            TextBox23.Text = tableau_conf1(17)
            TextBox24.Text = tableau_conf1(18)
            TextBox25.Text = tableau_conf1(19)
            TextBox26.Text = tableau_conf1(20)
            TextBox27.Text = tableau_conf1(21)
            TextBox28.Text = tableau_conf1(22)
            CheckBox1.Checked = tableau_conf1(23)
            ComboBox3.Text = tableau_conf1(24)
            TextBox1.Text = tableau_conf1(25)

            sr1.Close()

        Catch ex As Exception
            Dim erreur = " : Dans le module Configuration1_load() ligne 68" + CStr(ex.Message)
            DefLog(erreur)
        End Try

    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover

        Button1.FlatStyle = FlatStyle.Standard

    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave

        Button1.FlatStyle = FlatStyle.Flat

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim M1 = "Voulez-vous enregistrer ?"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Configuration1" And lang(1) = Langue Then
                    M1 = lang(11)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Configuration1_load() ligne 68" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        Dim rep As Integer
        rep = MsgBox(M1, vbYesNo + vbQuestion, " ")
        If rep = vbYes Then
            Dim toto = Val(TextBox1.Text)
            ' SeuilPR01 = Val(Replace(toto, ",", "."))

            Try

                Dim conf1_sw As New StreamWriter("C:\H2observer\configuration\config1.cfg")

                conf1_sw.WriteLine(TextBox8.Text + ";" + ComboBox1.Text + ";" + ComboBox2.Text _
                      + ";" + TextBox9.Text + ";" + TextBox10.Text + ";" + TextBox11.Text _
                      + ";" + TextBox12.Text + ";" + TextBox13.Text + ";" + TextBox14.Text _
                      + ";" + TextBox15.Text + ";" + TextBox16.Text + ";" + TextBox17.Text _
                      + ";" + TextBox18.Text _
                      + ";" + TextBox19.Text + ";" + TextBox20.Text + ";" + TextBox21.Text _
                      + ";" + TextBox22.Text + ";" + TextBox23.Text + ";" + TextBox24.Text _
                      + ";" + TextBox25.Text + ";" + TextBox26.Text + ";" + TextBox27.Text _
                      + ";" + TextBox28.Text + ";" + CheckBox1.Checked.ToString + ";" + ComboBox3.Text _
                      + ";" + TextBox1.Text)
                conf1_sw.Close()
                Langue = ComboBox3.Text
                Me.Close()

                If Opt_Analyses = True Then Acceuil.Button1.Visible = True
                If Opt_Alarmes = True Then Acceuil.Button9.Visible = True

                Acceuil.Button2.Visible = True
                Acceuil.Button4.Visible = True
                Acceuil.Button6.Visible = True
                Acceuil.Button5.Visible = True
                Acceuil.Button3.Visible = True
                Acceuil.Panel1.Visible = False

            Catch ex As Exception
                Dim erreur = " : Dans le module Configuration1_Button1_click() ligne 114" + CStr(ex.Message)
                DefLog(erreur)
            End Try
            Configuration()
        End If

        If rep = vbNo Then
            Me.Close()
            If Opt_Analyses = True Then Acceuil.Button1.Visible = True
            If Opt_Alarmes = True Then Acceuil.Button9.Visible = True
            Acceuil.Button2.Visible = True
            Acceuil.Button4.Visible = True
            Acceuil.Button6.Visible = True
            Acceuil.Button5.Visible = True
            Acceuil.Button3.Visible = True
            Acceuil.Panel1.Visible = False
        End If
        Acceuil.TextBox1.Select()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Close()

        If Licence_valide = False Then
            Acceuil.Button6.Visible = False
            Acceuil.Button4.Visible = False
            Acceuil.Button2.Visible = False
            Acceuil.Button5.Visible = True
        Else
            If Opt_Analyses = True Then Acceuil.Button1.Visible = True
            If Opt_Alarmes = True Then Acceuil.Button9.Visible = True
            Acceuil.Button2.Visible = True
            Acceuil.Button4.Visible = True
            Acceuil.Button6.Visible = True
            Acceuil.Button5.Visible = True
            Acceuil.Button3.Visible = True
        End If
        Acceuil.Panel1.Visible = False

    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text = Mdp_config1 Then
            GroupBox1.Visible = False
            GroupBox3.Visible = True
            GroupBox4.Visible = True
            TextBox8.Visible = True
            ComboBox1.Visible = True
            ComboBox2.Visible = True
            ComboBox3.Visible = True
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label8.Visible = True
            Button1.Visible = True
            CheckBox1.Visible = True
            Label5.Visible = True
            TextBox1.Visible = True
            Label6.Visible = True

            Dim ctrl As Control
            For Each ctrl In GroupBox3.Controls
                If TypeOf ctrl Is TextBox Then ctrl.Visible = True
            Next
            For Each ctrl In GroupBox4.Controls
                If TypeOf ctrl Is TextBox Then ctrl.Visible = True
            Next

        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        If TextBox2.PasswordChar = "*" Then TextBox2.PasswordChar = "" Else TextBox2.PasswordChar = "*"

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text > ComboBox2.Text Then ComboBox2.SelectedIndex = ComboBox1.SelectedIndex + 1

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox1.Text > ComboBox2.Text Then ComboBox2.SelectedIndex = ComboBox1.SelectedIndex + 1

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        Acceuil.Button6.Visible = False
        Acceuil.Button9.Visible = False
        Acceuil.Button4.Visible = False
        Acceuil.Button2.Visible = False
        Acceuil.Button1.Visible = False
        Acceuil.Button5.Visible = False
        Acceuil.Button3.Visible = False
        Acceuil.Panel1.Controls.Clear()
        Acceuil.Panel1.Size = New Size(1244, 500)
        Acceuil.Panel1.Location = New Point(100, 180)
        Acceuil.Panel1.Visible = True
        Control_licence.FormBorderStyle = FormBorderStyle.None
        Control_licence.TopLevel = False
        Control_licence.TopMost = False
        Control_licence.Location = New Point(0, 0)
        Control_licence.Dock = DockStyle.Fill
        Acceuil.Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Control_licence.AutoSize = True
        Acceuil.Panel1.Controls.Add(Control_licence)
        Control_licence.Visible = True

        Control_licence.Button1.Visible = True

    End Sub
End Class