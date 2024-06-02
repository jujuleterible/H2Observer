
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Math


Public Class Form_Prétraitement

    Private P1min : Dim P2min : Dim P3min
    Private P1max : Dim P2max : Dim P3max

    Private Sub Form_Prétraitement_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Acceuil.une_fois = 66

        Dim Tbrutmin = 8
        Dim Tbrutmax = 30
        Dim Pbrutmin = 1
        Dim Pbrutmax = 6
        Dim Psurmin = 2.5
        Dim Psurmax = 6
        Dim Qadoumax = 1400
        'Dim P1min = 2.5
        'Dim P1max = 6
        Dim D1max = 1.5
        Dim THmax = 0.45
        'Dim P2min = 2.5
        'Dim P2max = 6
        Dim D2max = 1.5
        Dim Clmax = 0.1
        'Dim P3min = 2.5
        'Dim P3max = 6
        Dim D3max = 1.5

        Label12.Visible = True
        Label13.Visible = True
        Label14.Visible = True
        Label6.Visible = True
        Label3.Visible = True
        Label34.Visible = True
        TextBox28.Visible = False
        TextBox29.Visible = False
        TextBox30.Visible = False
        TextBox31.Visible = False
        TextBox34.Visible = False
        TextBox35.Visible = False
        '-------------------------------------------------------------------------------------------------
        '----Fichier de configuration de la feuille de relevés des paramètres limites alarme 
        ' --- + textes modifiables + selection des lignes à afficher
        '-------------------------------------------------------------------------------------------------
        Dim fil As String = "C:\H2observer\configuration\préparam.cfg"

        Try
            Dim sr1 As StreamReader = New StreamReader(fil)
            Dim tableau_pré()
            tableau_pré = Split(sr1.ReadLine(), ";")
            Tbrutmin = Val(Replace(tableau_pré(0), ",", "."))
            Tbrutmax = Val(Replace(tableau_pré(1), ",", "."))
            Pbrutmin = Val(Replace(tableau_pré(2), ",", "."))
            Pbrutmax = Val(Replace(tableau_pré(3), ",", "."))
            Psurmin = Val(Replace(tableau_pré(4), ",", "."))
            Psurmax = Val(Replace(tableau_pré(5), ",", "."))
            Qadoumax = Val(Replace(tableau_pré(6), ",", "."))
            P1min = Val(Replace(tableau_pré(7), ",", "."))
            P1max = Val(Replace(tableau_pré(8), ",", "."))
            D1max = Val(Replace(tableau_pré(9), ",", "."))
            THmax = Val(Replace(tableau_pré(10), ",", "."))
            P2min = Val(Replace(tableau_pré(11), ",", "."))
            P2max = Val(Replace(tableau_pré(12), ",", "."))
            D2max = Val(Replace(tableau_pré(13), ",", "."))
            Clmax = Val(Replace(tableau_pré(14), ",", "."))
            P3min = Val(Replace(tableau_pré(15), ",", "."))
            P3max = Val(Replace(tableau_pré(16), ",", "."))
            D3max = Val(Replace(tableau_pré(17), ",", "."))
            Label12.Text = tableau_pré(18) 'entrer par textbox28
            TextBox28.Text = tableau_pré(18)
            Label13.Text = tableau_pré(19) 'entrer par textbox29
            TextBox29.Text = tableau_pré(19)
            Label14.Text = tableau_pré(20) 'entrer par textbox30
            TextBox30.Text = tableau_pré(20)
            Label6.Text = tableau_pré(21) 'entrer par textbox31
            TextBox31.Text = tableau_pré(21)
            Label3.Text = tableau_pré(22) 'entrer par textbox34
            TextBox34.Text = tableau_pré(22)
            Label34.Text = tableau_pré(23) 'entrer par textbox35
            TextBox35.Text = tableau_pré(23)
            CheckBox3.Checked = tableau_pré(24) 'checkbox : sélection des lignes à afficher
            CheckBox4.Checked = tableau_pré(25)
            CheckBox5.Checked = tableau_pré(26)
            CheckBox6.Checked = tableau_pré(27)
            CheckBox7.Checked = tableau_pré(28)
            CheckBox8.Checked = tableau_pré(29)
            CheckBox9.Checked = tableau_pré(30)
            CheckBox10.Checked = tableau_pré(31)
            CheckBox11.Checked = tableau_pré(32)
            CheckBox12.Checked = tableau_pré(33)
            CheckBox13.Checked = tableau_pré(34)
            CheckBox14.Checked = tableau_pré(35)
            CheckBox15.Checked = tableau_pré(36)
            sr1.Close()
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Form_Prétraitement()() ligne 96" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        '-------------------------------------------------------------------------
        '--------------- Limites d'alarmes
        '-------------------------------------------------------------------------
        TextBox3.Text = Tbrutmin
        TextBox4.Text = Tbrutmax
        TextBox5.Text = Pbrutmin
        TextBox6.Text = Pbrutmax
        TextBox7.Text = Psurmin
        TextBox8.Text = Psurmax
        TextBox10.Text = Qadoumax
        TextBox13.Text = P1min
        TextBox14.Text = P1max
        TextBox16.Text = D1max
        TextBox18.Text = THmax
        TextBox19.Text = P2min
        TextBox20.Text = P2max
        TextBox22.Text = D2max
        TextBox24.Text = Clmax
        TextBox25.Text = P3min
        TextBox26.Text = P3max
        TextBox33.Text = D3max
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim B8 = "Acceuil"
        Dim B1 = "Relevés des paramètres de l'osmoseur"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Form_Prétraitement" And lang(1) = Langue Then
                    B8 = lang(2)
                    Label143.Text = lang(3)
                    Label119.Text = lang(4)
                    Label120.Text = lang(5)
                    Label121.Text = lang(6)
                    Label122.Text = lang(7)
                    Label123.Text = lang(8)
                    Label126.Text = lang(9)
                    Label36.Text = lang(10)
                    Label141.Text = lang(11)
                    Label125.Text = lang(12)
                    Label124.Text = lang(13)
                    Label11.Text = lang(14)
                    Label40.Text = lang(15)
                    Label35.Text = lang(16)
                    Label32.Text = lang(17)
                    Label8.Text = lang(18)
                    Label5.Text = lang(19)
                    Label4.Text = lang(20)
                    Label2.Text = lang(21)
                    Label1.Text = lang(22)
                    Label66.Text = lang(23)
                    Label55.Text = lang(24)
                    Label52.Text = lang(25)
                    B1 = lang(26)
                    Label7.Text = lang(30)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button8, B8)
        tooltip1.SetToolTip(Button1, B1)
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500
        Pré_1()

    End Sub
    Private Sub Pré_1()
        '-------------------------------------------------------------------------
        'définition des variables
        '-------------------------------------------------------------------------
        Dim datej As New Date 'format yyyymmdd
        Dim datejour
        Dim AFile
        Dim fichierdujour
        Dim Numjour
        Dim datetemp As New Date
        Dim tableau(55)
        Dim semaine
        Dim annee
        Dim datte
        Dim heure
        Dim Tbrut
        Dim Pbrut
        Dim Psur
        Dim Qadou
        Dim FIadou
        Dim PE1
        Dim PS1
        Dim Delta1
        Dim TH
        Dim PE2
        Dim PS2
        Dim Delta2
        Dim Cl
        Dim PE3
        Dim PS3
        Dim Delta3
        Dim Pr01
        '-------------------------------------------------------------------------
        '--------------- initialisation des données du tableau de relevés
        '-------------------------------------------------------------------------
        Dim i = 1

        For i = 1 To 11
            Me.Controls("Lundi" & i).Text = ""
            Me.Controls("Mardi" & i).Text = ""
            Me.Controls("Mercredi" & i).Text = ""
            Me.Controls("Jeudi" & i).Text = ""
            Me.Controls("Vendredi" & i).Text = ""
            Me.Controls("Samedi" & i).Text = ""
            Me.Controls("Dimanche" & i).Text = ""
        Next i

        '--------------------------------------------------------------------
        '--------------- chargment config1 ( nom centre + heure de releves )
        '--------------------------------------------------------------------
        Dim hi = "08" 'heure de relevé par défaut
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"

        Try
            Dim sr3 As StreamReader = New StreamReader(fil1)
            Dim tableau_conf1()
            tableau_conf1 = Split(sr3.ReadLine(), ";")
            TextBox1.Text = CStr(Num_série) + " " + tableau_conf1(0)
            hi = tableau_conf1(1)
            If tableau_conf1(23) = "True" Then 'autorisation de changement des valeur des labels panoplies et des limites d'alarmes
                Label12.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                Label6.Visible = False
                Label3.Visible = False
                Label34.Visible = False
                TextBox28.Visible = True
                TextBox28.BackColor = Color.Gainsboro
                TextBox29.Visible = True
                TextBox29.BackColor = Color.Gainsboro
                TextBox30.Visible = True
                TextBox30.BackColor = Color.Gainsboro
                TextBox31.Visible = True
                TextBox31.BackColor = Color.Gainsboro
                TextBox34.Visible = True
                TextBox34.BackColor = Color.Gainsboro
                TextBox35.Visible = True
                TextBox35.BackColor = Color.Gainsboro
                CheckBox3.Visible = True
                CheckBox4.Visible = True
                CheckBox5.Visible = True
                CheckBox6.Visible = True
                CheckBox7.Visible = True
                CheckBox8.Visible = True
                CheckBox9.Visible = True
                CheckBox10.Visible = True
                CheckBox11.Visible = True
                CheckBox12.Visible = True
                CheckBox13.Visible = True
                CheckBox14.Visible = True
                CheckBox15.Visible = True
                For i = 3 To 8
                    Me.Controls("TextBox" & i).BackColor = Color.Gainsboro
                Next
                TextBox10.BackColor = Color.Gainsboro
                For i = 13 To 14
                    Me.Controls("TextBox" & i).BackColor = Color.Gainsboro
                Next
                TextBox16.BackColor = Color.Gainsboro
                For i = 18 To 20
                    Me.Controls("TextBox" & i).BackColor = Color.Gainsboro
                Next
                TextBox22.BackColor = Color.Gainsboro
                For i = 24 To 26
                    Me.Controls("TextBox" & i).BackColor = Color.Gainsboro
                Next
                TextBox33.BackColor = Color.Gainsboro
            End If
            sr3.Close()
        Catch ex As Exception
            'FileClose(1)
            Dim erreur = " : Dans le module Form_Prétraitement()() ligne 266 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '--------------------------------------------------------------------
        '--------------- Relevé des paramètres
        '--------------------------------------------------------------------
        Dim mod_prod = "mode production"
        Dim du = "du"
        Dim au = "au"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Form_Prétraitement" And lang(1) = Langue Then
                    mod_prod = lang(27)
                    du = lang(28)
                    au = lang(29)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        datej = Today
        datejour = datej
        semaine = DatePart(DateInterval.WeekOfYear, datej)
        annee = datej.Year

relevés:
        Numjour = datej.DayOfWeek
        datejour = datej.ToString("yyyyMMdd")
        fichierdujour = "rcLog_" + datejour + Ext_Ver + ".csv"
        AFile = "C:\H2observer\data\" + fichierdujour
        Try
            FileOpen(1, (AFile), OpenMode.Input, OpenAccess.Read, OpenShare.Shared) 'ouvre en lecture partagée
            Do
                tableau = Split(LineInput(1), ";")
                Pr01 = Val(Replace(tableau(14), ",", "."))
                Dim TestString As String = tableau(1)
                Dim h = TestString.Substring(0, 2)

                If tableau(7) = mod_prod And h = hi And Pr01 <= SeuilPR01 Then 'relevé en mode production h = heure du relevé et Pr01 < seuil PR01)
                    datte = tableau(0)
                    heure = tableau(1)
                    Tbrut = Val(Replace(tableau(44), ",", "."))
                    Pbrut = Val(Replace(tableau(47), ",", "."))
                    Psur = Val(Replace(tableau(48), ",", "."))
                    Qadou = Val(Replace(tableau(43), ",", "."))
                    FIadou = Val(Replace(tableau(42), ",", "."))
                    PE1 = Val(Replace(tableau(49), ",", "."))
                    PS1 = Val(Replace(tableau(50), ",", "."))
                    TH = Val(Replace(tableau(45), ",", "."))
                    PE2 = Val(Replace(tableau(51), ",", "."))
                    PS2 = Val(Replace(tableau(52), ",", "."))
                    Cl = Val(Replace(tableau(46), ",", "."))
                    PE3 = Val(Replace(tableau(53), ",", "."))
                    PS3 = Val(Replace(tableau(54), ",", "."))

                    Dim jour = "jour"
                    Select Case Numjour
                        Case 1
                            jour = "Lundi"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Lundi1.Text) + " " + au + " " + CDate(Lundi1.Text).AddDays(6)
                        Case 2
                            jour = "Mardi"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Mardi1.Text).AddDays(-1) + " " + au + " " + CDate(Mardi1.Text).AddDays(5)
                        Case 3
                            jour = "Mercredi"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Mercredi1.Text).AddDays(-2) + " " + au + " " + CDate(Mercredi1.Text).AddDays(4)
                        Case 4
                            jour = "Jeudi"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Jeudi1.Text).AddDays(-3) + " " + au + " " + CDate(Jeudi1.Text).AddDays(3)
                        Case 5
                            jour = "Vendredi"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Vendredi1.Text).AddDays(-4) + " " + au + " " + CDate(Vendredi1.Text).AddDays(2)
                        Case 6
                            jour = "Samedi"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Samedi1.Text).AddDays(-5) + " " + au + " " + CDate(Samedi1.Text).AddDays(1)
                        Case 7
                            jour = "Dimanche"
                            Me.Controls(jour & "1").Text = datte
                            Me.Controls(jour & "2").Text = heure
                            TextBox2.Text = du + " " + CDate(Dimanche1.Text).AddDays(-6) + " " + au + " " + CDate(Dimanche1.Text)
                    End Select

                    '-------------------------------------------------
                    If CheckBox3.Checked = True Then
                        If TextBox3.Text <= Tbrut And Tbrut <= TextBox4.Text Then
                            Me.Controls(jour & "3").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "3").ForeColor = Color.Orange
                        End If
                        Me.Controls(jour & "3").Text = Tbrut
                    Else
                        Label40.ForeColor = Color.Transparent
                        TextBox3.ForeColor = Color.Transparent
                        TextBox4.ForeColor = Color.Transparent
                        Label37.ForeColor = Color.Transparent
                    End If
                    '-------------------------------------------------
                    If CheckBox4.Checked = True Then
                        If TextBox5.Text <= Pbrut And Pbrut <= TextBox6.Text Then
                            Me.Controls(jour & "4").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "4").ForeColor = Color.Red
                        End If
                        Me.Controls(jour & "4").Text = Pbrut
                    Else
                        Label35.ForeColor = Color.Transparent
                        TextBox5.ForeColor = Color.Transparent
                        TextBox6.ForeColor = Color.Transparent
                        Label44.ForeColor = Color.Transparent
                    End If
                    '-------------------------------------------------
                    If CheckBox5.Checked = True Then
                        If TextBox7.Text <= Psur And Psur <= TextBox8.Text Then
                            Me.Controls(jour & "5").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "5").ForeColor = Color.Orange
                        End If
                        Me.Controls(jour & "5").Text = Psur
                    Else
                        Label32.ForeColor = Color.Transparent
                        TextBox7.ForeColor = Color.Transparent
                        TextBox8.ForeColor = Color.Transparent
                        Label43.ForeColor = Color.Transparent
                    End If
                    '-------------------------------------------------
                    If CheckBox6.Checked = True Then
                        If Qadou <= TextBox10.Text Then
                            Me.Controls(jour & "6").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "6").ForeColor = Color.Orange
                        End If
                        Me.Controls(jour & "6").Text = Qadou
                    Else
                        Label8.ForeColor = Color.Transparent
                        TextBox9.ForeColor = Color.Transparent
                        TextBox10.ForeColor = Color.Transparent
                        Label42.ForeColor = Color.Transparent
                    End If
                    '-------------------------------------------------
                    If CheckBox7.Checked = True Then
                        Me.Controls(jour & "7").Text = FIadou
                    Else
                        Label7.ForeColor = Color.Transparent
                        Label41.ForeColor = Color.Transparent
                    End If
                    '-------------------------------------------------
                    If CheckBox8.Checked = True Then
                        If (P1min <= PE1 And PE1 <= P1max) Then
                            If (P1min <= PS1 And PS1 <= P1max) Then
                                Me.Controls(jour & "8").ForeColor = Color.Black
                            Else
                                Me.Controls(jour & "8").ForeColor = Color.Red
                            End If
                        Else
                            Me.Controls(jour & "8").ForeColor = Color.Red
                        End If
                        Me.Controls(jour & "8").Text = Str(PE1) + " / " + Str(PS1)
                    Else
                        Label12.ForeColor = Color.Transparent
                        Label6.ForeColor = Color.Transparent
                        TextBox13.ForeColor = Color.Transparent
                        TextBox14.ForeColor = Color.Transparent
                        Label9.ForeColor = Color.Transparent
                    End If
                    '-------------------------------------------------
                    If CheckBox9.Checked = True Then
                        Delta1 = Math.Abs(PE1 - PS1)
                        If Delta1 <= TextBox16.Text Then
                            Me.Controls(jour & "9").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "9").ForeColor = Color.Orange
                        End If
                        Me.Controls(jour & "9").Text = Math.Round(Delta1, 1)
                    Else
                        Label5.ForeColor = Color.Transparent
                        TextBox15.ForeColor = Color.Transparent
                        TextBox16.ForeColor = Color.Transparent
                        Label47.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    If CheckBox10.Checked = True Then
                        If TH <= TextBox18.Text Then
                            Me.Controls(jour & "10").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "10").ForeColor = Color.Red
                        End If
                        Me.Controls(jour & "10").Text = TH
                    Else
                        Label55.ForeColor = Color.Transparent
                        Label4.ForeColor = Color.Transparent
                        TextBox17.ForeColor = Color.Transparent
                        TextBox18.ForeColor = Color.Transparent
                        Label46.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    If CheckBox11.Checked = True Then
                        If (P2min <= PE2 And PE2 <= P2max) Then
                            If (P2min <= PS2 And PS2 <= P2max) Then
                                Me.Controls(jour & "11").ForeColor = Color.Black
                            Else
                                Me.Controls(jour & "11").ForeColor = Color.Red
                            End If
                        Else
                            Me.Controls(jour & "11").ForeColor = Color.Red
                        End If
                        Me.Controls(jour & "11").Text = Str(PE2) + " / " + Str(PS2)
                    Else
                        Label13.ForeColor = Color.Transparent
                        Label3.ForeColor = Color.Transparent
                        TextBox19.ForeColor = Color.Transparent
                        TextBox20.ForeColor = Color.Transparent
                        Label45.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    If CheckBox12.Checked = True Then
                        Delta2 = Math.Round(Math.Abs(PE2 - PS2), 1)
                        If Delta2 <= TextBox22.Text Then
                            Me.Controls(jour & "12").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "12").ForeColor = Color.Orange
                        End If
                        Me.Controls(jour & "12").Text = Math.Round(Delta2, 1)
                    Else
                        Label2.ForeColor = Color.Transparent
                        TextBox21.ForeColor = Color.Transparent
                        TextBox22.ForeColor = Color.Transparent
                        Label10.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    If CheckBox13.Checked = True Then
                        If (Cl / 1000) <= TextBox24.Text Then
                            Me.Controls(jour & "13").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "13").ForeColor = Color.Red
                        End If
                        Me.Controls(jour & "13").Text = Math.Round(Cl / 1000, 2)
                    Else
                        Label52.ForeColor = Color.Transparent
                        Label1.ForeColor = Color.Transparent
                        TextBox23.ForeColor = Color.Transparent
                        TextBox24.ForeColor = Color.Transparent
                        Label50.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    If CheckBox14.Checked = True Then
                        If (P3min <= PE3 And PE3 <= P3max) Then
                            If (P3min <= PS3 And PS3 <= P3max) Then
                                Me.Controls(jour & "14").ForeColor = Color.Black
                            Else
                                Me.Controls(jour & "14").ForeColor = Color.Red
                            End If
                        Else
                            Me.Controls(jour & "14").ForeColor = Color.Red
                        End If
                        Me.Controls(jour & "14").Text = Str(PE3) + " / " + Str(PS3)
                    Else
                        Label14.ForeColor = Color.Transparent
                        Label34.ForeColor = Color.Transparent
                        TextBox25.ForeColor = Color.Transparent
                        TextBox26.ForeColor = Color.Transparent
                        Label64.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    If CheckBox15.Checked = True Then
                        Delta3 = Math.Abs(PE3 - PS3)
                        If Delta3 <= TextBox33.Text Then
                            Me.Controls(jour & "15").ForeColor = Color.Black
                        Else
                            Me.Controls(jour & "15").ForeColor = Color.Orange
                        End If
                        Me.Controls(jour & "15").Text = Math.Round(Delta3, 1)
                    Else
                        Label66.ForeColor = Color.Transparent
                        TextBox32.ForeColor = Color.Transparent
                        TextBox33.ForeColor = Color.Transparent
                        Label65.ForeColor = Color.Transparent
                    End If
                    '--------------------------------------------
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Form_Prétraitement_1()() ligne 553 " + CStr(ex.Message)
            DefLog(erreur)
        End Try

        If Numjour <> 1 Then
            datej = datej.AddDays(-1)
            GoTo relevés
        End If
        '-------------------------------------------------------------
        'enregister le relevé des paramètres prétraitement en png avant envoi
        '-------------------------------------------------------------
        Me.Show()
        Threading.Thread.Sleep(1000)
        Button8.Visible = False
        Button1.Visible = False
        Button3.Focus()
        Dim b As New Bitmap(Me.Width, Me.Height)
        Dim ff
        ff = "C:\H2observer\releves\" + "releves_pre" + semaine.ToString + annee.ToString + ".png"
        Me.DrawToBitmap(b, New Rectangle(0, 0, Me.Width, Me.Height))
        b.Save(ff, Imaging.ImageFormat.Png)
        Button8.Visible = True
        Button1.Visible = True
        Acceuil.une_fois = 66

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim tableau_conf1()
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module Form_Prétraitement() ligne 588" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        If tableau_conf1(23) = "True" Then
            Try
                Dim sw As New StreamWriter("C:\H2observer\configuration\préparam.cfg")
                sw.WriteLine(TextBox3.Text + ";" + TextBox4.Text _
                          + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text _
                          + ";" + TextBox8.Text + ";" + TextBox10.Text + ";" + TextBox13.Text _
                          + ";" + TextBox14.Text + ";" + TextBox16.Text + ";" + TextBox18.Text _
                          + ";" + TextBox19.Text + ";" + TextBox20.Text + ";" + TextBox22.Text _
                          + ";" + TextBox24.Text + ";" + TextBox25.Text + ";" + TextBox26.Text _
                          + ";" + TextBox33.Text + ";" + TextBox28.Text + ";" + TextBox29.Text _
                          + ";" + TextBox30.Text + ";" + TextBox31.Text + ";" + TextBox34.Text _
                          + ";" + TextBox35.Text + ";" + CheckBox3.Checked.ToString + ";" + CheckBox4.Checked.ToString _
                          + ";" + CheckBox5.Checked.ToString + ";" + CheckBox6.Checked.ToString _
                          + ";" + CheckBox7.Checked.ToString + ";" + CheckBox8.Checked.ToString _
                          + ";" + CheckBox9.Checked.ToString + ";" + CheckBox10.Checked.ToString _
                          + ";" + CheckBox11.Checked.ToString + ";" + CheckBox12.Checked.ToString _
                          + ";" + CheckBox13.Checked.ToString + ";" + CheckBox14.Checked.ToString _
                          + ";" + CheckBox15.Checked.ToString)
                sw.Close()
            Catch ex As Exception
                Dim erreur = " : Dans le module Form_Relevés.Button8_Click() ligne 612 " + CStr(ex.Message)
                DefLog(erreur)
            End Try

            Try
                Dim conf1_sw As New StreamWriter("C:\H2observer\configuration\config1.cfg")

                conf1_sw.WriteLine(tableau_conf1(0) + ";" + tableau_conf1(1) + ";" + tableau_conf1(2) _
                      + ";" + tableau_conf1(3) + ";" + tableau_conf1(4) + ";" + tableau_conf1(5) _
                      + ";" + tableau_conf1(6) + ";" + tableau_conf1(7) + ";" + tableau_conf1(8) _
                      + ";" + tableau_conf1(9) + ";" + tableau_conf1(10) + ";" + tableau_conf1(11) _
                      + ";" + tableau_conf1(12) _
                      + ";" + tableau_conf1(13) + ";" + tableau_conf1(14) + ";" + tableau_conf1(15) _
                      + ";" + tableau_conf1(16) + ";" + tableau_conf1(17) + ";" + tableau_conf1(18) _
                      + ";" + tableau_conf1(19) + ";" + tableau_conf1(20) + ";" + tableau_conf1(21) _
                      + ";" + tableau_conf1(22) + ";" + "False" + ";" + tableau_conf1(24) + ";" + tableau_conf1(25))
                conf1_sw.Close()
                Me.Close()
            Catch ex As Exception
                Dim erreur = "Dans le module Form_Relevés.Button8_Click() ligne 631 " + CStr(ex.Message)
                DefLog(erreur)
            End Try
        End If

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim tableau_conf1(24)
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"

        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Form_Prétraitemen.Button1_Click() ligne 660 " + CStr(ex.Message)
            DefLog(erreur)
        End Try

        If tableau_conf1(23) = "True" Then
            Try
                Dim sw As New StreamWriter("C:\H2observer\configuration\préparam.cfg")
                sw.WriteLine(TextBox3.Text + ";" + TextBox4.Text _
                          + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text _
                          + ";" + TextBox8.Text + ";" + TextBox10.Text + ";" + TextBox13.Text _
                          + ";" + TextBox14.Text + ";" + TextBox16.Text + ";" + TextBox18.Text _
                          + ";" + TextBox19.Text + ";" + TextBox20.Text + ";" + TextBox22.Text _
                          + ";" + TextBox24.Text + ";" + TextBox25.Text + ";" + TextBox26.Text _
                          + ";" + TextBox33.Text + ";" + TextBox28.Text + ";" + TextBox29.Text _
                          + ";" + TextBox30.Text + ";" + TextBox31.Text + ";" + TextBox34.Text _
                          + ";" + TextBox35.Text + ";" + CheckBox3.Checked.ToString + ";" + CheckBox4.Checked.ToString _
                          + ";" + CheckBox5.Checked.ToString + ";" + CheckBox6.Checked.ToString _
                          + ";" + CheckBox7.Checked.ToString + ";" + CheckBox8.Checked.ToString _
                          + ";" + CheckBox9.Checked.ToString + ";" + CheckBox10.Checked.ToString _
                          + ";" + CheckBox11.Checked.ToString + ";" + CheckBox12.Checked.ToString _
                          + ";" + CheckBox13.Checked.ToString + ";" + CheckBox14.Checked.ToString _
                          + ";" + CheckBox15.Checked.ToString)
                sw.Close()
            Catch ex As Exception
                Dim erreur = " : Dans le module Form_Relevés.Button8_Click() ligne 684 " + CStr(ex.Message)
                DefLog(erreur)
            End Try
        End If

        Me.Close()
        Form_Relevés.TopLevel = False
        Form_Relevés.Visible = True
        Acceuil.Panel1.Controls.Add(Form_Relevés)
        Acceuil.Panel1.Size = New Size(1244, 500)
        Acceuil.Panel1.Location = New Point(100, 180)
        Acceuil.Panel1.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
        Acceuil.Panel1.Visible = True
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover

        Button1.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave

        Button1.FlatStyle = FlatStyle.Flat

    End Sub
    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover

        Button8.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave

        Button8.FlatStyle = FlatStyle.Flat

    End Sub
    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles TextBox31.TextChanged

    End Sub
End Class