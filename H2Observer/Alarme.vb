Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting


Public Class Alarme
    Dim file_to_mail
    Dim destinataire
    Private Sub Alarme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim B1 = "Recherche"
        Dim B2 = "Acceuil"
        Dim B3 = "Envoyer par email"
        Dim B4 = "Envoyer email"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Alarme" And lang(1) = Langue Then
                    B1 = lang(2)
                    B2 = lang(3)
                    B3 = lang(4)
                    B4 = lang(5)
                    GroupBox2.Text = lang(7)
                    Label2.Text = lang(8)
                    Label3.Text = lang(9)
                    RadioButton1.Text = lang(10)
                    RadioButton2.Text = lang(11)
                    RadioButton3.Text = lang(12)
                    GroupBox1.Text = lang(13)
                    Label1.Text = lang(14)
                    Label4.Text = lang(15)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
        End Try
        '-------------------------------------------------------------------------
        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button1, B1)
        tooltip1.SetToolTip(Button2, B2)
        tooltip1.SetToolTip(Button3, B3)
        tooltip1.SetToolTip(Button4, b4)
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
    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover

        Button4.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave

        Button4.FlatStyle = FlatStyle.Flat

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim date_début_recherche
        Dim date_fin_recherche
        Dim datemp As New Date
        Dim tabsrch(37)
        Dim filesearch As String
        Dim info
        Dim datte
        Dim hour
        Dim date_recherche As String
        Dim affiche
        Dim acq
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim LeMessageBox = "Recherche impossible, veuillez entrer une date de fin supérieure à la date de début"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim StrInfo = "Info"
        Dim Rb1Text = "Recherche d'avertissements du "
        Dim Rb2Text = "Recherche de défauts du "
        Dim Rb3Text = "Recherche d'avertissements et de défauts du "
        Dim Au = " au "
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Alarme" And lang(1) = Langue Then
                    LeMessageBox = lang(6)
                    StrInfo = lang(17)
                    Rb1Text = lang(18)
                    Rb2Text = lang(19)
                    Rb3Text = lang(20)
                    Au = lang(21)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
        End Try
        '-------------------------------------------------------------------------
        GroupBox1.Visible = False
        Me.Cursor = Cursors.WaitCursor 'roue qui tourne ou sablier le fichier est en train d'etre recherché
        Button1.Visible = False
        Dim itemlist As New List(Of String) 'sert à calculer le nombre d'occurence des av 
        ListBox1.Items.Clear()
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
            Dim erreur = "Dans le module Alarme.vb() ligne 158 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-----------------------------------------------------------------------
        date_début_recherche = DateTimePicker1.Value.Date.ToString("yyyyMMdd")
        date_fin_recherche = DateTimePicker2.Value.Date.ToString("yyyyMMdd")
        datemp = DateTimePicker1.Value
        Dim dfich = date_début_recherche + "_" + date_fin_recherche
        Dim filename = "C:\H2observer\alarm\temp.csv"
        If RadioButton1.Checked Then filename = "C:\H2observer\alarm\" + "Warnings_" + dfich + ".csv"
        If RadioButton2.Checked Then filename = "C:\H2observer\alarm\" + "Faults_" + dfich + ".csv"
        If RadioButton3.Checked Then filename = "C:\H2observer\alarm\" + "All_" + dfich + ".csv"
        Dim fi As New IO.FileInfo(filename)
        Using sw As StreamWriter = fi.AppendText()
            If date_fin_recherche < date_début_recherche Then
                MsgBox(LeMessageBox)
            End If

            If date_fin_recherche <> date_début_recherche Then 'recherche sur plusieurs jours
                While date_fin_recherche <> date_début_recherche

                    date_recherche = date_début_recherche
                    filesearch = "C:\H2observer\data\" + "rcLog_" + date_recherche + Ext_Ver + ".csv"
                    Try
                        FileOpen(3, (filesearch), OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
                        Do
                            tabsrch = Split(LineInput(3), ";")
                            info = tabsrch(3)
                            datte = tabsrch(0)
                            hour = tabsrch(1)
                            acq = tabsrch(2)
                            If RadioButton1.Checked Then
                                If (info <> " ") And (info <> StrInfo) Then
                                    If (info.substring(0, 2) = "FC") Then
                                        If Not alarmlist.Contains(info.Substring(0, 5)) Then 'si ne contient pas FC de niveau II&III c'esrt un warning
                                            affiche = datte + "   " + hour + "   " + info + "   " + acq
                                            ListBox1.Items.Add(affiche)
                                            If acq = "A+" Then itemlist.Add(info)
                                            sw.WriteLine((datte + ";" + hour + ";" + info + ";" + acq))
                                        End If
                                    End If
                                End If
                            End If

                            If RadioButton2.Checked Then
                                If (info <> " ") And (info <> StrInfo) Then
                                    If (info.substring(0, 2) = "FC") Then
                                        If alarmlist.Contains(info.Substring(0, 5)) Then 'si contient Fc de niveau II&III c'est un défaut
                                            affiche = datte + "   " + hour + "   " + info + "   " + acq
                                            ListBox1.Items.Add(affiche)
                                            If acq = "A+" Then itemlist.Add(info)
                                            sw.WriteLine((datte + ";" + hour + ";" + info + ";" + acq))
                                        End If
                                    End If
                                End If
                            End If

                            If RadioButton3.Checked Then
                                If (info <> " ") And (info <> StrInfo) Then
                                    If (info.substring(0, 2) = "FC") Then
                                        affiche = datte + "   " + hour + "   " + info + "   " + acq
                                        ListBox1.Items.Add(affiche)
                                        If acq = "A+" Then itemlist.Add(info)
                                        sw.WriteLine((datte + ";" + hour + ";" + info + ";" + acq))
                                    End If
                                End If
                            End If
                        Loop Until EOF(3)
                        datemp = datemp.AddDays(1)
                        date_début_recherche = datemp.Date.ToString("yyyyMMdd")
                        FileClose(3)
                    Catch ex As Exception
                        datemp = datemp.AddDays(1)
                        date_début_recherche = datemp.Date.ToString("yyyyMMdd")
                        FileClose(3)
                    End Try

                End While
            End If

            If date_fin_recherche = date_début_recherche Then 'recherche sur un jour
                date_recherche = date_début_recherche
                filesearch = "C:\H2observer\data\" + "rcLog_" + date_recherche + Ext_Ver + ".csv"
                Try
                    FileOpen(3, (filesearch), OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
                    Do
                        tabsrch = Split(LineInput(3), ";")
                        info = tabsrch(3)
                        datte = tabsrch(0)
                        hour = tabsrch(1)
                        acq = tabsrch(2)
                        If RadioButton1.Checked Then
                            If (info <> " ") And (info <> StrInfo) Then
                                If (info.substring(0, 2) = "FC") Then
                                    If Not alarmlist.Contains(info.Substring(0, 5)) Then 'si ne contient pas FC de niveau II&III c'esrt un warning
                                        affiche = datte + "   " + hour + "   " + info
                                        ListBox1.Items.Add(affiche)
                                        If acq = "A+" Then itemlist.Add(info)
                                        sw.WriteLine((datte + ";" + hour + ";" + info + ";" + acq))
                                    End If
                                End If
                            End If
                        End If

                        If RadioButton2.Checked Then
                            If (info <> " ") And (info <> StrInfo) Then
                                If (info.substring(0, 2) = "FC") Then
                                    If alarmlist.Contains(info.Substring(0, 5)) Then 'si contient Fc de niveau II&III c'est un défaut
                                        affiche = datte + "   " + hour + "   " + info + "   " + acq
                                        ListBox1.Items.Add(affiche)
                                        If acq = "A+" Then itemlist.Add(info)
                                        sw.WriteLine((datte + ";" + hour + ";" + info + ";" + acq))
                                    End If
                                End If
                            End If
                        End If

                        If RadioButton3.Checked Then
                            If (info <> " ") And (info <> StrInfo) Then
                                If (info.substring(0, 2) = "FC") Then
                                    affiche = datte + "   " + hour + "   " + info + "   " + acq
                                    ListBox1.Items.Add(affiche)
                                    If acq = "A+" Then itemlist.Add(info)
                                    sw.WriteLine((datte + ";" + hour + ";" + info + ";" + acq))
                                End If
                            End If
                        End If
                    Loop Until EOF(3)
                    FileClose(3)
                Catch ex As Exception
                    FileClose(3)
                End Try
            End If
        End Using
        '-----------------------------------------------------------------------
        '----------------- occurence des alarmes
        '----------------- groupe les itemlist ajouteé (alarme ou avertissmeent)
        '----------------- puis les classes par occurences décroissantes
        '-----------------------------------------------------------------------

        Dim groups = itemlist.GroupBy(Function(value) value)
        groups = groups.OrderByDescending(Function(x) x.Count).ToList()

        '-----------------------------------------------------------------------
        '----------------- camenbert
        '-----------------------------------------------------------------------

        Chart1.ChartAreas.Clear()
        Chart1.Series.Clear()
        Dim chartArea1 As New ChartArea()
        Chart1.ChartAreas.Add(chartArea1)
        Dim series1 As New Series("Alarme")
        Dim i = 0
        For Each grp In groups
            ' (grp.Count & " = " & grp(0)) 'pour avoir toutes les occurences 
            If i < 6 Then      'affiche les i alarmes les plus fréquentes
                series1.Points.AddXY(grp(0), grp.Count)
                i = i + 1
            End If
        Next
        Chart1.Series.Add(series1)
        Chart1.Series(0).ChartType = SeriesChartType.Pie
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Chart1.Series(0).IsValueShownAsLabel = True
        '-----------------------------------------------------------------------
        '----------------- titre du camenbert
        '-----------------------------------------------------------------------
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim tableau_conf1(25)
        Dim titr1 As String = ""
        Dim titr2 As String = ""
        Dim rech As String = ""
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Form_Alarme_Button1.click()()() ligne 336 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
        If RadioButton1.Checked Then rech = Rb1Text
        If RadioButton2.Checked Then rech = Rb2Text
        If RadioButton3.Checked Then rech = Rb3Text
        titr2 = rech + DateTimePicker1.Value.Date + Au + DateTimePicker2.Value.Date
        titr1 = CStr(Num_série) + " " + tableau_conf1(0)
        '-----------------------------------------------------------------------
        Dim str() As String = filename.Split(".")
        filename = str(0)
        If filename <> "" Then
            Chart1.Legends(0).Title = filename.Substring(20)
            Chart1.Legends(0).TitleForeColor = Color.White
        End If
        Chart1.Titles(0).Text = titr1
        Chart1.Titles(1).Text = titr2
        '-----------------------------------------------------------------------
        '----------------- photo camenbert
        '-----------------------------------------------------------------------
        Dim b As New Bitmap(Chart1.Width, Chart1.Height)
        Dim ff
        If Chart1.Legends(0).Title <> "" Then
            ff = "C:\H2observer\alarm\" + Chart1.Legends(0).Title + ".png"
            Chart1.DrawToBitmap(b, New Rectangle(0, 0, Chart1.Width, Chart1.Height))
            b.Save(ff, Imaging.ImageFormat.Png)
        End If
        Me.Cursor = Cursors.Default
        Button1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()

        '-----------------------------------------------------------------------
        '----------------- effacer fichiers de recherche
        '-----------------------------------------------------------------------
        Dim directoryName As String = "C:\H2observer\alarm"
        For Each deleteFile In Directory.GetFiles(directoryName, "*.csv", SearchOption.TopDirectoryOnly)
            Try
                If deleteFile <> "C:\H2observer\alarm\historique_defaut.csv" Then File.Delete(deleteFile)
            Catch ex As Exception
                Dim erreur = " : Dans le module Alarme.button2_click() ligne 379 " + CStr(ex.Message)
                DefLog(erreur)
            End Try
        Next

        For Each deleteFile In Directory.GetFiles(directoryName, "*.png", SearchOption.TopDirectoryOnly)
            Try
                File.Delete(deleteFile)
            Catch ex As Exception
                Dim erreur = " : Dans le module Alarme.button2_click() ligne 388 " + CStr(ex.Message)
                DefLog(erreur)
            End Try
        Next

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If GroupBox1.Visible = True Then GroupBox1.Visible = False Else GroupBox1.Visible = True
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim i As Integer
        Dim tableau_conf1(24)
        '-----------------------------------------------------------------------
        '------------- chargement config 1 pour récupérer destinataires
        '-----------------------------------------------------------------------
        Try
            FileOpen(1, (fil1), OpenMode.Input)
            Do
                tableau_conf1 = Split(LineInput(1), ";")
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Alarme.button3_click() ligne 422 " + CStr(ex.Message)
            DefLog(erreur)
        End Try

        For i = 13 To 22
            If tableau_conf1(i) <> "" Then ComboBox2.Items.Add(tableau_conf1(i))
        Next
        If tableau_conf1(13) <> "" Then ComboBox2.SelectedIndex = 0
        '-----------------------------------------------------------------------
        '------------- chargement des fichiers du répertoire alarm dans combobox
        '-----------------------------------------------------------------------
        For Each foundFile As String In Directory.GetFiles("C:\H2observer\alarm\", "*.csv")
            Dim NomFichier As String = foundFile.Remove(0, InStrRev(foundFile, "\", -1, 1))
            Dim str() As String = NomFichier.Split(".")
            NomFichier = str(0)
            ComboBox1.Items.Add(NomFichier)
        Next

    End Sub
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim LeMessage1 = "Veuillez entrer un destinataire"
        Dim LeMessage2 = "Message envoyé"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Alarme" And lang(1) = Langue Then
                    LeMessage2 = lang(16)
                    LeMessage1 = lang(22)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
        End Try
        '-------------------------------------------------------------------------
        Dim file1 = "C:\H2observer\alarm\" + ComboBox1.Text
        Dim file2 = ""
        destinataire = ComboBox2.SelectedItem

        If destinataire = "" Then
            MsgBox(LeMessage1)
        Else
            If file1 = "C:\H2observer\alarm\historique_defaut" Then
                file1 = file1 + ".csv"
                file2 = ""
            Else
                Dim str() As String = file1.Split(".")
                file1 = str(0)
                file2 = file1 + ".csv"
                file1 = file1 + ".png"
            End If
            Me.Cursor = Cursors.WaitCursor
            Envoie_def_mail(destinataire, file1, file2)
            Me.Cursor = Cursors.Default
            MsgBox(LeMessage2)
            GroupBox1.Visible = False
        End If

    End Sub
    Private Sub Chart1_DoubleClick(sender As Object, e As EventArgs) Handles Chart1.DoubleClick

        Chart1.Visible = False

    End Sub
    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick

        Chart1.Visible = True

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

        Dim datedatepick = DateTimePicker1.Value.Date.ToString("yyyyMMdd")
        Dim edate = Date_service

        Try
            Dim datediatron = Convert.ToDateTime(edate).Date.ToString("yyyyMMdd")
            If datedatepick < datediatron Then DateTimePicker1.Value = Convert.ToDateTime(Date_service)
        Catch ex As Exception
            'Dim erreur = " : Dans le module Alarme.DateTimePicker1_ValueChanged() ligne 507 " + CStr(ex.Message)
            ' DefLog(erreur)
        End Try

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class