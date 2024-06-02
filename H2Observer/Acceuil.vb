Imports System.IO
Imports System.IO.File
Imports System.Text
Imports IWshRuntimeLibrary
Imports System.Deployment.Application
Imports System.com
Public Class Acceuil

    Public une_fois ' sert pour timer le lancer une fois / a l heure
    Public courbe_impression 'sert envoie email  une fois / enregistrement
    Public courbe_date ' sert pour tester date
    Public envoyermailalarm = True 'sert a n'envoyer qu'un seul mail quand le defaut dure
    Public jour_de_dialyse = False  'sert à savoir si la centrale est en jour de dialyse pour l'envoie de mail
    Public Product_key

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Licence_valide = False
        '-----------------------------------------------------------------------
        '----------------- version logiciel
        '-----------------------------------------------------------------------
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            Label2.Text = "Version : " & AD.CurrentVersion.ToString
        Else
            Label2.Text = "Version : " & My.Application.Info.Version.ToString
        End If
        '-----------------------------------------------------------------------
        '----------------- création raccourci h2Observer au démarrage windows
        '-----------------------------------------------------------------------
        Dim WshShell As WshShell = New WshShell
        Dim SRT As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim ShortcutPath As String = SRT & "\H2Oberver.lnk"
        Dim Shortcut As IWshRuntimeLibrary.IWshShortcut
        If Not Exists(ShortcutPath) Then
            Shortcut = CType(WshShell.CreateShortcut(ShortcutPath), IWshRuntimeLibrary.IWshShortcut)
            Shortcut.TargetPath = Application.ExecutablePath
            Shortcut.WorkingDirectory = Application.StartupPath
            Shortcut.Save()

        End If
        '-----------------------------------------------------------------------
        '----------------- création raccourci sur bureau
        '-----------------------------------------------------------------------
        Dim SRT1 As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        Dim ShortcutPath1 As String = SRT1 & "\h2observer.lnk"
        If Not Exists(ShortcutPath1) Then
            Shortcut = CType(WshShell.CreateShortcut(ShortcutPath1), IWshShortcut)
            Shortcut.TargetPath = Application.ExecutablePath
            Shortcut.WorkingDirectory = Application.StartupPath
            Shortcut.Save()

        End If
        '-----------------------------------------------------------------------
        '----------------- création des répertoires cibles s'ils n'existent pas
        '-----------------------------------------------------------------------

        If Not Directory.Exists("C:\H2observer\configuation") Then
            Directory.CreateDirectory("C:\H2observer\configuration")
        End If
        If Not Directory.Exists("C:\H2observer\alarm") Then
            Directory.CreateDirectory("C:\H2observer\alarm")
        End If
        If Not Directory.Exists("C:\H2observer\releves") Then
            Directory.CreateDirectory("C:\H2observer\releves")
        End If
        If Not Directory.Exists("C:\H2observer\courbes") Then
            Directory.CreateDirectory("C:\H2observer\courbes")
        End If
        If Not Directory.Exists("C:\H2observer\photo") Then
            Directory.CreateDirectory("C:\H2observer\photo")
        End If
        If Not Directory.Exists("C:\H2observer\data") Then
            Directory.CreateDirectory("C:\H2observer\data")
        End If
        Configuration()
        'Licence()
        Panel1.Visible = False
        Label1.Visible = False
        Label3.Visible = False
        If Licence_valide = False Then
            Button6.Visible = False
            Button9.Visible = False
            Button4.Visible = False
            Button2.Visible = False
            Button1.Visible = False
            Button5.Visible = False
            Button3.Visible = False
            Panel1.Controls.Clear()
            Panel1.Size = New Size(1244, 500)
            Panel1.Location = New Point(100, 180)
            Panel1.Visible = True
            Control_licence.FormBorderStyle = FormBorderStyle.None
            Control_licence.TopLevel = False
            Control_licence.TopMost = False
            Control_licence.Location = New Point(0, 0)
            Control_licence.Dock = DockStyle.Fill
            Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
            Control_licence.AutoSize = True
            Panel1.Controls.Add(Control_licence)
            Control_licence.Visible = True

        End If

        '-----------------------------------------------------------------------
        '-- Configuration du logiciel
        '-----------------------------------------------------------------------
        Configuration()

        '-----------------------------------------------------------------------
        '----------------- initialisation langue
        '-----------------------------------------------------------------------
        Dim B1 = "Analyses"
        Dim B2 = "Configuration 1"
        Dim B3 = "Informations"
        Dim B4 = "Historique des désinfections"
        Dim B5 = "Configuration 2"
        Dim B6 = "Relevé des paramètres"
        Dim B9 = "Alarmes"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"

        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            'Dim sr1 As StreamReader = New StreamReader(fil_langue)
            Do
                'Dim lang() = Split(sr1.ReadLine(), ";")
                Dim lang() = Split(LineInput(1), ";")

                If lang(0) = "Acceuil" And lang(1) = Langue Then
                    B1 = lang(2)
                    B2 = lang(3)
                    B3 = lang(4)
                    B4 = lang(5)
                    B5 = lang(6)
                    B6 = lang(7)
                    B9 = lang(8)
                    Exit Do
                End If

                ' Loop Until sr1 Is Nothing
            Loop Until EOF(1)
            FileClose(1)
            ' sr1.Close()
        Catch ex As Exception
            FileClose(1)
        End Try
        '-----------------------------------------------------------------------
        '----------------- initialisation des bulles informations
        '-----------------------------------------------------------------------
        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button1, B1)
        tooltip1.SetToolTip(Button2, B2)
        tooltip1.SetToolTip(Button3, B3)
        tooltip1.SetToolTip(Button4, B4)
        tooltip1.SetToolTip(Button5, B5)
        tooltip1.SetToolTip(Button6, B6)
        tooltip1.SetToolTip(Button9, B9)
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500

        Label1.Visible = True
        Label3.Visible = True
        Label3.Text = Date_expiration

        If Licence_valide = False Then
            Button6.Visible = False
            Button4.Visible = False
            Button2.Visible = False
            GoTo fin
        End If
        'If Opt_Analyses = True Then Button1.Visible = True
        'If Opt_Alarmes = True Then Button9.Visible = True
        '-----------------------------------------------------------------------
        '-- synchronisation des fichiers de l'automate sur le disque dur
        '-----------------------------------------------------------------------

        Timer1.Stop()

        Winscp_class.Synchro_ftp.Main()


        '-------------------------------------------------------------------------------------------------------------
        '                                        recherche fichier du jour pour relever
        '-----------------------------------------------------------------------------------------------------------------------

        une_fois = 0
        Timer1.Interval = 60000
        Timer1.Start()
        courbe_impression = False
fin:
        TextBox1.Select()
        '-----------------------------------------------------------------------------------------
        '_______________________________________________ essai
        '-----------------------------------------------------------------------------------------
        '-----------------------------------------------------------------------------------------






    End Sub
    Private Sub Button6_MouseHover(sender As Object, e As EventArgs) Handles Button6.MouseHover
        Button6.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub Button5_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Button5.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.FlatStyle = FlatStyle.Flat
    End Sub
    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.FlatStyle = FlatStyle.Flat
    End Sub
    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.FlatStyle = FlatStyle.Flat
    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.FlatStyle = FlatStyle.Flat
    End Sub


    Private Sub Button9_MouseHover(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Button9.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.FlatStyle = FlatStyle.Flat
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Form_Relevés.TopLevel = False
        Form_Relevés.Visible = True
        Panel1.Controls.Add(Form_Relevés)
        Panel1.Size = New Size(1244, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Panel1.Visible = True



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Panel1.Controls.Clear()
        Panel1.Size = New Size(1244, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Visible = True
        visualisation_courbe.FormBorderStyle = FormBorderStyle.None
        visualisation_courbe.TopLevel = False
        visualisation_courbe.TopMost = False
        visualisation_courbe.Dock = DockStyle.Fill
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        visualisation_courbe.AutoSize = True
        Panel1.Controls.Add(visualisation_courbe)
        visualisation_courbe.Visible = True

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Winscp_class.Synchro_ftp.Main()

        '-----------------------------------------------------------------------
        '----------------- chargement config1 pour hjeure d'envoi
        '-----------------------------------------------------------------------
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim tableau_conf1()
        Dim hh = "10" 'heure 'envoi par défaut
        Try

            FileOpen(1, (fil1), OpenMode.Input)
            Do
                tableau_conf1 = Split(LineInput(1), ";")

                hh = tableau_conf1(2)

            Loop Until EOF(1)
            FileClose(1)

        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module acceuil.Timer1.tick() ligne 321" + CStr(ex.Message)
            DefLog(erreur)

        End Try

        '-----------------------------------------------------------------------
        '----------------- envoi relevés + courbe
        '-----------------------------------------------------------------------
        If DateTime.Now.ToString("HH") = CStr(hh) And une_fois = 0 Then
            Graphe.Show()
            Form_Relevés.Show()

            Dim jourdialyse = Today.DayOfWeek
            Select Case jourdialyse
                Case 0
                    If Form_Relevés.Dimanche1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If
                Case 1
                    If Form_Relevés.Lundi1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If
                Case 2
                    If Form_Relevés.Mardi1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If
                Case 3
                    If Form_Relevés.Mercredi1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If
                Case 4
                    If Form_Relevés.Jeudi1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If
                Case 5
                    If Form_Relevés.Vendredi1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If
                Case 6
                    If Form_Relevés.Samedi1.Text <> "" Then
                        jour_de_dialyse = True
                    Else
                        jour_de_dialyse = False
                    End If

            End Select

            Form_Relevés.Close()

            If Ver3 Then
                Form_Prétraitement.Show()
                Form_Prétraitement.Close()
            End If

            'si il n'y a pas de dialyse aujourdhui pas d'envoie de relevés
            If jour_de_dialyse = True Then
                    Envoies_mail()
                End If

            End If
            If DateTime.Now.ToString("HH") <> CStr(hh) Then une_fois = 0

        If Opt_Alarmes = True Then Défaut()

        '--------------------------------------------------------------------------------------------------------------------
        ' Control_mois_licence()
        '---------------------------------------------------------------------------------------------------------------

        Dim date_expi = Format(CDate(Date_expiration), "yyyyMM")
        Dim thisDate As Date
        thisDate = Today
        Dim Prevision_date = Format(CDate(Today.AddMonths(7)), "yyyyMM")
        Dim somejour = DateTime.Now.ToString("dd")
        Dim someHour = DateTime.Now.ToString("HHmm")
        If Prevision_date >= date_expi And someHour = "1315" And somejour = "05" Then EMAIL_FIN_LICENCE() 'envoie email
        If date_expi <= Format(CDate(Today), "yyyyMM") Then 'detuit licence
            Num_série = "KEY NOT VALIDATE"
            Date_expiration = "DATE NOT VALIDATE"
            Efface_Cle_Licence()

        End If

    End Sub
    Private Sub Efface_Cle_Licence()
        Dim map = "" : Dim map1 = "" : Dim map2 = "" : Dim map3 = "" : Dim map4 = "" : Dim map5 = "" : Dim map6 = "" : Dim map7 = ""
        Dim map8 = "" : Dim map9 = "" : Dim map10 = "" : Dim map11 = "" : Dim map12 = "" : Dim map13 = "" : Dim map14 = "" : Dim map15 = ""
        Dim map16 = "" : Dim map17 = "" : Dim map18 = ""
        ' map = ""
        ' map1 = ""
        'map2 = map3 = map4 = map5 = map6 = map7 = ""


        Dim crypt
            Dim fil2 As String = "C:\H2observer\configuration\config2.cfg"
            Dim tableau_conf2()
            FileOpen(1, (fil2), OpenMode.Input)
            Do
                crypt = LineInput(1)
            Loop Until EOF(1)
            FileClose(1)
            ' decodage
            Dim mesbytes67() As Byte = Convert.FromBase64String(crypt)
            Dim new_chaines67 = Encoding.UTF8.GetString(mesbytes67)
            tableau_conf2 = Split(new_chaines67, ";")

        map = tableau_conf2(1)
            map1 = tableau_conf2(2)
            map2 = tableau_conf2(3)
            map3 = tableau_conf2(4)
            map4 = tableau_conf2(5)
            map5 = tableau_conf2(6)
            map6 = tableau_conf2(7)
            map7 = tableau_conf2(8)
            map8 = tableau_conf2(9)
            map9 = tableau_conf2(10)
            map10 = tableau_conf2(11)
            map11 = tableau_conf2(12)
            map12 = tableau_conf2(13)
            map13 = tableau_conf2(14)
            map14 = tableau_conf2(15)
            map15 = tableau_conf2(16)
        map16 = tableau_conf2(17)
        map17 = tableau_conf2(18)
        map18 = tableau_conf2(19)

        Dim chaines66 = (Num_série + ";" + map + ";" + map1 _
                              + ";" + map2 + ";" + map3 + ";" + map4 _
                              + ";" + map5 + ";" + map6 + ";" + map7 _
                              + ";" + map8 + ";" + map9 + ";" + map10 _
                              + ";" + map11 + ";" + map12 _
                              + ";" + map13 + ";" + map14 + ";" + map15 + ";" + Date_expiration _
                              + ";" + map17 + ";" + map18)
        Dim mesbytes66() As Byte = Encoding.UTF8.GetBytes(chaines66)
            Dim new_chaines66 = Convert.ToBase64String(mesbytes66)
            Dim conf2_sw As New StreamWriter("C:\H2observer\configuration\config2.cfg")
            conf2_sw.WriteLine(new_chaines66)
            conf2_sw.Close()

    End Sub
    Private Sub Défaut()
        '-----------------------------------------------------------------------
        '------------ chargement du fichier contenant la liste des défaut II&III
        '-----------------------------------------------------------------------
        Dim fildefalarm As String = "C:\H2observer\configuration\FC.h2o"
        Dim alarmlist = "fcxxx"
        Try
            FileOpen(1, (fildefalarm), OpenMode.Input)
            alarmlist = LineInput(1)
            FileClose(1)
        Catch ex As Exception
        End Try
        '-----------------------------------------------------------------------
        Dim StrInfo = "Info"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang() = Split(LineInput(1), ";")
                If lang(0) = "Acceuil" And lang(1) = Langue Then
                    StrInfo = lang(9)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        Dim alarmline
        Dim CSVFile As String
        Dim info = ""
        Dim alarmj = ""
        Dim alarmh = ""
        Dim alarminfo = ""
        Dim datejour = Today.ToString("yyyyMMdd")

        CSVFile = "C:\H2observer\data\" + "rcLog_" + datejour + Ext_Ver + ".csv"

        Dim logfile As String = "C:\H2observer\alarm\historique_defaut.csv"

        Try
            FileOpen(2, (CSVFile), OpenMode.Input, OpenAccess.Read, OpenShare.Shared)

            Do
                Dim tabcsv(37)
                tabcsv = Split(LineInput(2), ";")
                info = tabcsv(3)
                Dim csvdate = tabcsv(0)
                Dim csvhour = tabcsv(1)

                If (info <> " ") And (info <> StrInfo) Then
                    If (tabcsv(2) = "A+") And (info.Substring(0, 2) = "FC") Then 'si A+ apparition Fc et que info commence par FC il y a peut être un défaut
                        If alarmlist.Contains(info.Substring(0, 5)) Then 'alarmlist contient les FCxxx de niveau II&III
                            Try 'lit le fichier alarm s'il existe et place les valeurs dans un tableau
                                If (Not Exists(logfile)) Then '(Not File.Exists(logfile))
                                    Try

                                        Dim alarmsw As New StreamWriter(logfile)
                                        alarmsw.WriteLine(tabcsv(0) + ";" + tabcsv(1) + ";" + tabcsv(3))
                                        alarmsw.Close()
                                        alarmj = tabcsv(0)
                                        alarmh = tabcsv(1)
                                        alarminfo = tabcsv(3)
                                        Envoie_alarmmail(alarmj, alarmh, alarminfo)
                                        envoyermailalarm = False
                                    Catch ex As Exception
                                        Dim erreur = " : Dans le module acceuil.défaut() ligne 539 " + CStr(ex.Message)
                                        DefLog(erreur)
                                    End Try

                                Else
                                    Dim alarmsr As New StreamReader("C:\H2observer\alarm\historique_defaut.csv")
                                    Do
                                        alarmline = alarmsr.ReadLine()
                                        If alarmline <> "" Then
                                            Dim tabalarm(3)
                                            tabalarm = Split(alarmline, ";")
                                            alarmj = tabalarm(0)
                                            alarmh = tabalarm(1)
                                            alarminfo = tabalarm(2)
                                        End If

                                    Loop Until alarmline Is Nothing
                                    alarmsr.Close()
                                    alarmsr.Dispose()

                                    If CDate(csvdate) = CDate(alarmj) Then
                                        If CDate(csvhour) > CDate(alarmh) Then 'nouvelle alarme
                                            Dim alarmsw As New StreamWriter(logfile, True)
                                            alarmsw.WriteLine(tabcsv(0) + ";" + tabcsv(1) + ";" + tabcsv(3))
                                            alarmsw.Close()
                                            If envoyermailalarm = True Then
                                                Envoie_alarmmail(tabcsv(0), tabcsv(1), tabcsv(3))
                                                envoyermailalarm = False
                                            End If
                                        End If
                                    End If
                                    If CDate(csvdate) > CDate(alarmj) Then
                                        Dim alarmsw As New StreamWriter(logfile, True)
                                        alarmsw.WriteLine(tabcsv(0) + ";" + tabcsv(1) + ";" + tabcsv(3))
                                        alarmsw.Close()
                                        If envoyermailalarm = True Then
                                            Envoie_alarmmail(tabcsv(0), tabcsv(1), tabcsv(3))
                                            envoyermailalarm = False
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                Dim erreur = " : Dans le module acceuil.défaut() ligne 581 " + CStr(ex.Message)
                                DefLog(erreur)
                            End Try
                        End If
                    End If
                End If

            Loop Until EOF(2)
        Catch ex As Exception
            FileClose(2)
        End Try

        If info = " " Then
            envoyermailalarm = True
        End If

        FileClose(2)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Infos.TopLevel = False
        Infos.Visible = True
        Panel1.Controls.Add(Infos)
        Panel1.Size = New Size(1244, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Panel1.Visible = True

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Panel1.Controls.Clear()
        Panel1.Size = New Size(1243, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Visible = True
        Recherche.FormBorderStyle = FormBorderStyle.None
        Recherche.TopLevel = False
        Recherche.TopMost = False
        Recherche.Location = New Point(0, 0)
        Recherche.Dock = DockStyle.Fill
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Recherche.AutoSize = True
        Panel1.Controls.Add(Recherche)
        Recherche.Visible = True
        Recherche.Show()

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Panel1.Controls.Clear()
        Panel1.Size = New Size(1244, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Visible = True
        Alarme.FormBorderStyle = FormBorderStyle.None
        Alarme.TopLevel = False
        Alarme.TopMost = False
        Alarme.Location = New Point(0, 0)
        Alarme.Dock = DockStyle.Fill
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Alarme.AutoSize = True
        Panel1.Controls.Add(Alarme)
        Alarme.Visible = True

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Panel1.Controls.Clear()
        Panel1.Size = New Size(1244, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Visible = True
        Configuration1.FormBorderStyle = FormBorderStyle.None
        Configuration1.TopLevel = False
        Configuration1.TopMost = False
        Configuration1.Location = New Point(0, 0)
        Configuration1.Dock = DockStyle.Fill
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Configuration1.AutoSize = True
        Panel1.Controls.Add(Configuration1)
        Configuration1.Visible = True

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Button6.Visible = False
        Button9.Visible = False
        Button4.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Button3.Visible = False
        Panel1.Controls.Clear()
        Panel1.Size = New Size(1244, 500)
        Panel1.Location = New Point(100, 180)
        Panel1.Visible = True
        Configuration2.FormBorderStyle = FormBorderStyle.None
        Configuration2.TopLevel = False
        Configuration2.TopMost = False
        Configuration2.Location = New Point(0, 0)
        Configuration2.Dock = DockStyle.Fill
        Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Configuration2.AutoSize = True
        Panel1.Controls.Add(Configuration2)
        Configuration2.Visible = True

    End Sub

End Class