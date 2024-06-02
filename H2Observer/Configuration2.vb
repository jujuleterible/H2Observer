Imports System.IO
Imports System.Text
Public Class Configuration2
    Dim i_click = 0
    Private Sub Configuration2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GroupBox6.Visible = True
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        GroupBox5.Visible = False
        Button1.Visible = False
        TextBox10.Select()

        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        If Not File.Exists("C:\H2observer\configuration\config1.cfg") Then Langue = "English"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim B1 = "Home"

        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Configuration2" And lang(1) = Langue Then
                    GroupBox6.Text = lang(2)
                    B1 = lang(3)
                    GroupBox5.Text = lang(4)
                    Label12.Text = lang(5)
                    Label11.Text = lang(6)
                    RadioButton1.Text = lang(7)
                    RadioButton2.Text = lang(8)
                    RadioButton3.Text = lang(9)
                    GroupBox1.Text = lang(10)
                    Label1.Text = lang(11)
                    Label2.Text = lang(12)
                    Label3.Text = lang(13)
                    Label17.Text = lang(14)
                    GroupBox2.Text = lang(15)
                    Label6.Text = lang(16)
                    Label15.Text = lang(17)
                    Label5.Text = lang(18)
                    Label16.Text = lang(19)
                    Label4.Text = lang(20)
                    Label7.Text = lang(21)
                    GroupBox4.Text = lang(22)
                    Label9.Text = lang(23)
                    Label10.Text = lang(24)
                    Label8.Text = lang(25)
                    Label14.Text = lang(26)
                    GroupBox3.Text = lang(27)
                    CheckBox1.Text = lang(28)
                    CheckBox2.Text = lang(29)
                    Label18.Text = lang(31)
                    CheckBox3.Text = lang(32)
                    CheckBox4.Text = lang(33)
                    Exit Do
                End If

            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Configuration1_load() ligne 65" + CStr(ex.Message)
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

        Dim crypt
        Dim fil2 As String = "C:\H2observer\configuration\config2.cfg"
        Dim tableau_conf2()
        Try
            FileOpen(1, (fil2), OpenMode.Input)
            Do
                crypt = LineInput(1)
            Loop Until EOF(1)
            FileClose(1)

            ' decodage

            Dim mesbytes() As Byte = Convert.FromBase64String(crypt)
            Dim new_chaines = Encoding.UTF8.GetString(mesbytes)
            tableau_conf2 = Split(new_chaines, ";")
            Label20.Text = tableau_conf2(0)  'NUM SERIE
            'TextBox12.Text = tableau_conf2(0)
            TextBox11.Text = tableau_conf2(1)
            TextBox1.Text = tableau_conf2(2)
            TextBox2.Text = tableau_conf2(3)
            TextBox3.Text = tableau_conf2(4)
            TextBox9.Text = tableau_conf2(5)
            TextBox8.Text = tableau_conf2(6)
            TextBox6.Text = tableau_conf2(7)
            TextBox5.Text = tableau_conf2(8)
            TextBox4.Text = tableau_conf2(9)
            TextBox7.Text = tableau_conf2(10)
            CheckBox1.Checked = tableau_conf2(11)
            CheckBox2.Checked = tableau_conf2(12)
            RadioButton1.Checked = tableau_conf2(13)
            RadioButton2.Checked = tableau_conf2(14)
            TextBox17.Text = tableau_conf2(15)
            RadioButton3.Checked = tableau_conf2(16)
            Label19.Text = tableau_conf2(17) 'CLE EXPIRATION
            CheckBox3.Checked = tableau_conf2(18)
            CheckBox4.Checked = tableau_conf2(19)
            'fin decodage
            TextBox13.Text = TextBox9.Text
            TextBox14.Text = TextBox8.Text
            TextBox15.Text = TextBox6.Text
            TextBox16.Text = TextBox5.Text
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Configuration2_load() ligne 126" + CStr(ex.Message)
            DefLog(erreur)
            'Label20.Text = Num_série
            'Label19.Text = Date_expiration
        End Try

        TextBox13.ForeColor = Color.Black
        TextBox14.ForeColor = Color.Black
        TextBox15.ForeColor = Color.Black
        TextBox16.ForeColor = Color.Black
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover

        Button1.FlatStyle = FlatStyle.Standard

    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave

        Button1.FlatStyle = FlatStyle.Flat

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ip = TextBox1.Text
        ' cryptage en 64 bit
        Dim chaines = (Label20.Text + ";" + TextBox11.Text + ";" + TextBox1.Text _
                              + ";" + TextBox2.Text + ";" + TextBox3.Text + ";" + TextBox9.Text _
                              + ";" + TextBox8.Text + ";" + TextBox6.Text + ";" + TextBox5.Text _
                              + ";" + TextBox4.Text + ";" + TextBox7.Text + ";" + CStr(CheckBox1.Checked) _
                              + ";" + CStr(CheckBox2.Checked) + ";" + CStr(RadioButton1.Checked) _
                              + ";" + CStr(RadioButton2.Checked) + ";" + TextBox17.Text + ";" + CStr(RadioButton3.Checked) _
                              + ";" + Label19.Text + ";" + CStr(CheckBox3.Checked) + ";" + CStr(CheckBox4.Checked))
        Dim mesbytes() As Byte = Encoding.UTF8.GetBytes(chaines)
            Dim new_chaines = Convert.ToBase64String(mesbytes)
            ' fin cryptage

            Dim Mdp_config1
            Dim Mdp_config2
        Dim rep As Integer
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim M1 = "Voulez-vous enregistrer ?"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Configuration2" And lang(1) = Langue Then
                    M1 = lang(30)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Configuration2_Button1_Click() ligne 180" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        rep = MsgBox(M1, vbYesNo + vbQuestion, " ")
        If rep = vbYes Then
            If TextBox9.Text = TextBox13.Text And TextBox8.Text = TextBox14.Text And TextBox6.Text = TextBox15.Text And TextBox5.Text = TextBox16.Text Then
                Try 'création de config2.cfg
                    Dim conf2_sw As New StreamWriter("C:\H2observer\configuration\config2.cfg")
                    conf2_sw.WriteLine(new_chaines)
                    conf2_sw.Close()
                    Num_série = Label20.Text
                    Mdp_config1 = TextBox9.Text
                    Mdp_config2 = TextBox8.Text
                    Opt_Analyses = CheckBox1.Checked
                    Opt_Alarmes = CheckBox2.Checked
                    Ver1 = RadioButton1.Checked
                    Ver2 = RadioButton2.Checked
                    Ver3 = RadioButton3.Checked
                    Port = TextBox17.Text
                    Date_expiration = Label19.Text
                    SSL = CheckBox3.Checked
                    Certif = CheckBox4.Checked
                    Me.Close()

                    Configuration()

                    If Opt_Analyses = True And Licence_valide = True Then Acceuil.Button1.Visible = True
                    If Opt_Alarmes = True And Licence_valide = True Then Acceuil.Button9.Visible = True
                    If Licence_valide = True Then
                        Acceuil.Label1.Visible = True
                        Acceuil.Label3.Visible = True
                        Acceuil.Label3.Text = Date_expiration
                    End If


                    Acceuil.Button2.Visible = True
                    Acceuil.Button4.Visible = True
                    Acceuil.Button6.Visible = True
                    Acceuil.Button5.Visible = True
                    Acceuil.Button3.Visible = True
                    Acceuil.Panel1.Visible = False
                Catch ex As Exception
                    Dim erreur = " : Dans le module Configuration2_Button_click() ligne 222 " + CStr(ex.Message)
                    DefLog(erreur)
                End Try
                '----------------------------------------------------------------
                'création du fichier de synchro suivant la version du Diatron
                '----------------------------------------------------------------

                '- Diatron 5500 ver1
                'mount.bat = plink 192.168.1.1 -telnet < mount_sdcard.txt
                'mount.txt = mount -t vfat /dev/mmcblk0p1 /sdcard1
                ' Exit
                'unmount.bat =' plink 192.168.1.1 -telnet < mount_sdcard.txt
                If Ver1 = True Then

                    Try 'création du fichier de synchro

                        Dim sync_sw As New StreamWriter("C:\H2observer\configuration\sd_sync.bat")
                        sync_sw.WriteLine("cd c:\H2observer\configuration\")
                        sync_sw.WriteLine("plink " + ip + " -telnet < unmount_sdcard.txt")
                        sync_sw.WriteLine("plink " + ip + " -telnet < mount_sdcard.txt")
                        sync_sw.WriteLine("exit")
                        sync_sw.Close()
                    Catch ex As Exception
                        Dim erreur = " : Dans le module Configuration2_Button_click() ligne 245" + CStr(ex.Message)
                        DefLog(erreur)
                    End Try
                    Try 'création de mount_card

                        Dim mount_sw As New StreamWriter("c:\h2observer\configuration\mount_sdcard.txt")
                        mount_sw.WriteLine("mount -t vfat /dev/mmcblk0p1 /sdcard1")
                        mount_sw.WriteLine("exit")
                        mount_sw.Close()
                    Catch ex As Exception
                        Dim erreur = " : Dans le module Configuration2_Button_click() ligne 255 " + CStr(ex.Message)
                        DefLog(erreur)
                    End Try
                    Try 'création de unmout_card
                        Dim unmount_sw As New StreamWriter("c:\h2observer\configuration\unmount_sdcard.txt")
                        unmount_sw.WriteLine("umount /sdcard1")
                        unmount_sw.WriteLine("exit")
                        unmount_sw.Close()
                    Catch ex As Exception
                        Dim erreur = " : Dans le module Configuration2_Button_click() ligne 264 " + CStr(ex.Message)
                        DefLog(erreur)
                    End Try
                End If
                '- Diatron 5500 sans prétraitement = ver2 Diatron 5500 + prétraitement = ver3
                'plink -ssh -l root -pw root 192.168.1.1 mount -t vfat /dev/disk/by-label/sdcard /media
                'plink -ssh - l root -pw root 192.168.1.1 -batch umount /media
                If Ver2 = True Or Ver3 = True Then
                    Try
                        Dim sync2_sw As New StreamWriter("C:\H2observer\configuration\sd_sync2.bat")
                        sync2_sw.WriteLine("cd c:\H2observer\configuration\")
                        sync2_sw.WriteLine("plink -ssh -l root -pw root " + ip + " -batch umount /sdcard1")
                        sync2_sw.WriteLine("plink -ssh -l root -pw root " + ip + " mount -t vfat /dev/disk/by-label/sdcard /sdcard1")
                        sync2_sw.WriteLine("exit")
                        sync2_sw.Close()
                    Catch ex As Exception
                        Dim erreur = " : Dans le module Configuration2_Button_click() ligne 280" + CStr(ex.Message)
                        DefLog(erreur)
                    End Try
                End If

                Configuration()

                    If Licence_valide = False Then
                        Acceuil.Button6.Visible = False
                        Acceuil.Button4.Visible = False
                        Acceuil.Button2.Visible = False
                        Acceuil.Button1.Visible = False
                        Acceuil.Button9.Visible = False
                    End If
                    Acceuil.TextBox1.Select()

                End If

            End If
        If rep = vbNo Then
                Me.Close()
                If Opt_Analyses = True And Licence_valide = True Then Acceuil.Button1.Visible = True
                If Opt_Alarmes = True And Licence_valide = True Then Acceuil.Button9.Visible = True
                Acceuil.Button2.Visible = True
                Acceuil.Button4.Visible = True
                Acceuil.Button6.Visible = True
                Acceuil.Button5.Visible = True
                Acceuil.Button3.Visible = True
                Acceuil.Panel1.Visible = False
            End If


    End Sub
    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

        If TextBox10.Text = TextBox8.Text Then
            GroupBox1.Visible = True
            GroupBox2.Visible = True
            GroupBox3.Visible = True
            GroupBox4.Visible = True
            GroupBox5.Visible = True
            GroupBox6.Visible = False
            Button1.Visible = True
            Dim ctrl As Control
            For Each ctrl In GroupBox1.Controls
                If TypeOf ctrl Is TextBox Then ctrl.Visible = True
            Next
            For Each ctrl In GroupBox5.Controls
                If TypeOf ctrl Is TextBox Then ctrl.Visible = True
            Next

            For Each ctrl In GroupBox4.Controls
                If TypeOf ctrl Is TextBox Then ctrl.Visible = True
            Next
            For Each ctrl In GroupBox2.Controls
                If TypeOf ctrl Is TextBox Then ctrl.Visible = True
            Next
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        If TextBox10.PasswordChar = "*" Then TextBox10.PasswordChar = "" Else TextBox10.PasswordChar = "*"

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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




    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = TextBox9.Text Then
            TextBox13.ForeColor = Color.Lime
        Else
            TextBox13.ForeColor = Color.Red
        End If


    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

        If TextBox14.Text = TextBox8.Text Then
            TextBox14.ForeColor = Color.Lime
        Else
            TextBox14.ForeColor = Color.Red
        End If

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text = TextBox6.Text Then
            TextBox15.ForeColor = Color.Lime
        Else
            TextBox15.ForeColor = Color.Red
        End If
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        If TextBox16.Text = TextBox5.Text Then
            TextBox16.ForeColor = Color.Lime
        Else
            TextBox16.ForeColor = Color.Red
        End If

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        TextBox13.Text = ""
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox14.Text = ""
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        TextBox15.Text = ""
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox16.Text = ""
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        i_click = i_click + 1
        If i_click > 5 Then
            TextBox6.PasswordChar = ""
            i_click = 0
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        i_click = i_click + 1
        If i_click > 5 Then
            TextBox9.PasswordChar = ""
            i_click = 0
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        i_click = i_click + 1
        If i_click > 5 Then
            TextBox8.PasswordChar = ""
            i_click = 0
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        i_click = i_click + 1
        If i_click > 5 Then
            TextBox5.PasswordChar = ""
            i_click = 0
        End If
    End Sub


End Class