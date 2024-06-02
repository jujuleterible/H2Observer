
Imports System.Drawing
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class Form_Relevés
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Acceuil.une_fois = 66
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim B8 = "Acceuil"
        Dim B1 = "Prétraitement"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Form_Relevés" And lang(1) = Langue Then
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
                    Label1.Text = lang(14)
                    Label13.Text = lang(15)
                    Label15.Text = lang(16)
                    Label16.Text = lang(17)
                    Label17.Text = lang(18)
                    Label18.Text = lang(19)
                    Label19.Text = lang(20)
                    Label20.Text = lang(21)
                    Label21.Text = lang(22)
                    Label22.Text = lang(23)
                    Label23.Text = lang(24)
                    Label24.Text = lang(25)
                    Label34.Text = lang(26)
                    Label2.Text = lang(27)
                    Label3.Text = lang(28)
                    Label6.Text = lang(29)
                    Label5.Text = lang(30)
                    Label4.Text = lang(31)
                    Label12.Text = lang(32)
                    Label11.Text = lang(33)
                    Label10.Text = lang(34)
                    Label9.Text = lang(35)
                    Label8.Text = lang(36)
                    Label7.Text = lang(37)
                    Label33.Text = lang(38)
                    B1 = lang(39)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        If Ver3 Then Button1.Visible = True
        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button8, B8)
        tooltip1.SetToolTip(Button1, B1)
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500
        Releves()

    End Sub
    Private Sub Releves()

        Dim datte
        Dim heure
        Dim id
        Dim info
        Dim mode_de_fonctionnement
        Dim etat_de_base
        Dim programme_desinfection_thermique
        Dim etape
        Dim fl01 'As Single
        Dim fl02 'As Single
        Dim fl01_fl02
        Dim fl03 'As Single
        Dim fl04
        Dim fl05 'As Single
        Dim pr01
        Dim pr05
        Dim pr06
        Dim pr07
        Dim pr08
        Dim pr09
        Dim pr10 'As Single
        Dim pr04 'As Single
        Dim q01 'As Single
        Dim t01 'As Single
        Dim q02 'As Single
        Dim t02 'As Single
        Dim q03 'As Single
        Dim t03 'As Single
        Dim t11
        Dim t12
        Dim t05
        Dim t06
        Dim t07
        Dim t08
        Dim t09
        Dim t04
        Dim datej As New Date 'format yyyymmdd
        Dim datejour
        Dim AFile
        Dim fichierdujour
        Dim Numjour
        Dim datetemp As New Date
        Dim tableau(50)
        Dim semaine
        Dim annee
        Dim prod = 0

        '-------------------------------------------------------------------------
        'initialisation des données du tableau de relevés
        '-------------------------------------------------------------------------
        Dim i = 1
        For i = 1 To 14

            Me.Controls("Lundi" & i).Text = ""
            Me.Controls("Mardi" & i).Text = ""
            Me.Controls("Mercredi" & i).Text = ""
            Me.Controls("Jeudi" & i).Text = ""
            Me.Controls("Vendredi" & i).Text = ""
            Me.Controls("Samedi" & i).Text = ""
            Me.Controls("Dimanche" & i).Text = ""

        Next i
        '-------------------------------------------------------------------------
        '--------------- Limites d'alarmes par défaut
        '-------------------------------------------------------------------------
        Dim q01min = 0.4
        Dim q01max = 1.2
        Dim q02min = 0
        Dim q02max = 20
        Dim q03min = 0
        Dim q03max = 5
        Dim fl01min = 500
        Dim fl01max = 999
        Dim fl02min = 100
        Dim fl02max = 999
        Dim fl03min = 300
        Dim fl03max = 999
        Dim fl05min = 100
        Dim fl05max = 999
        Dim pr10min = 0
        Dim pr10max = 6.5
        Dim pr04min = 1
        Dim pr04max = 99
        Dim t01min = 15
        Dim t01max = 25
        Dim t03min = 15
        Dim t03max = 25
        Dim t04min = 15
        Dim t04max = 25
        Dim tableau_param(24)
        '-------------------------------------------------------------------------
        '----Fichier de configuration de la feuille de relevés des paramètres
        '-------------------------------------------------------------------------
        Dim fil As String = "C:\H2observer\configuration\param.cfg"
        Try
            FileOpen(1, (fil), OpenMode.Input)
            Do
                tableau_param = Split(LineInput(1), ";")
                q01min = Val(Replace(tableau_param(0), ",", "."))
                q01max = Val(Replace(tableau_param(1), ",", "."))
                q02min = Val(Replace(tableau_param(2), ",", "."))
                q02max = Val(Replace(tableau_param(3), ",", "."))
                q03min = Val(Replace(tableau_param(4), ",", "."))
                q03max = Val(Replace(tableau_param(5), ",", "."))
                fl01min = Val(Replace(tableau_param(6), ",", "."))
                fl01max = Val(Replace(tableau_param(7), ",", "."))
                fl02min = Val(Replace(tableau_param(8), ",", "."))
                fl02max = Val(Replace(tableau_param(9), ",", "."))
                fl03min = Val(Replace(tableau_param(10), ",", "."))
                fl03max = Val(Replace(tableau_param(11), ",", "."))
                fl05min = Val(Replace(tableau_param(12), ",", "."))
                fl05max = Val(Replace(tableau_param(13), ",", "."))
                pr10min = Val(Replace(tableau_param(14), ",", "."))
                pr10max = Val(Replace(tableau_param(15), ",", "."))
                pr04min = Val(Replace(tableau_param(16), ",", "."))
                pr04max = Val(Replace(tableau_param(17), ",", "."))
                t01min = Val(Replace(tableau_param(18), ",", "."))
                t01max = Val(Replace(tableau_param(19), ",", "."))
                t03min = Val(Replace(tableau_param(20), ",", "."))
                t03max = Val(Replace(tableau_param(21), ",", "."))
                t04min = Val(Replace(tableau_param(22), ",", "."))
                t04max = Val(Replace(tableau_param(23), ",", "."))
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Form_Relevés.releves()() ligne 210 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-------------------------------------------------------------------------
        '--------------- Limites d'alarmes
        '-------------------------------------------------------------------------
        TextBox3.Text = q01min
        TextBox4.Text = q01max
        TextBox5.Text = q02min
        TextBox6.Text = q02max
        TextBox7.Text = q03min
        TextBox8.Text = q03max
        TextBox9.Text = fl01min
        TextBox10.Text = fl01max
        TextBox11.Text = fl02min
        TextBox12.Text = fl02max
        TextBox13.Text = fl03min
        TextBox14.Text = fl03max
        TextBox15.Text = fl05min
        TextBox16.Text = fl05max
        TextBox17.Text = pr10min
        TextBox18.Text = pr10max
        TextBox19.Text = pr04min
        TextBox20.Text = pr04max
        TextBox21.Text = t01min
        TextBox22.Text = t01max
        TextBox23.Text = t03min
        TextBox24.Text = t03max
        TextBox25.Text = t04min
        TextBox26.Text = t04max
        '--------------------------------------------------------------------
        '--------------- chargment config1 ( nom centre + heure de releves )
        '--------------------------------------------------------------------
        Dim hi = "08" 'heure de relevé par défaut
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Try
            Dim sr3 As StreamReader = New StreamReader(fil1)
            Dim tableau_conf1(24)
            tableau_conf1 = Split(sr3.ReadLine(), ";")
            TextBox1.Text = CStr(Num_série) + " " + tableau_conf1(0)
            hi = tableau_conf1(1)
            If tableau_conf1(23) = "True" Then
                TextBox3.BackColor = Color.Gainsboro
                TextBox4.BackColor = Color.Gainsboro
                TextBox6.BackColor = Color.Gainsboro
                TextBox8.BackColor = Color.Gainsboro
                For i = 9 To 16
                    Me.Controls("TextBox" & i).BackColor = Color.Gainsboro
                Next
                TextBox18.BackColor = Color.Gainsboro
                For i = 19 To 26
                    Me.Controls("TextBox" & i).BackColor = Color.Gainsboro
                Next
            End If
            sr3.Close()
        Catch ex As Exception
            'FileClose(1)
            Dim erreur = " : Dans le module Form_Relevés.releves()() ligne 254 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '--------------------------------------------------------------------
        '--------------- Relevé des paramètres
        '--------------------------------------------------------------------
        datej = Today
        datejour = datej
        semaine = DatePart(DateInterval.WeekOfYear, datej)
        annee = datej.Year

relevés:
        Dim mod_prod = "mode production"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Dim du = "du"
        Dim au = "au"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Form_Relevés" And lang(1) = Langue Then
                    mod_prod = lang(40)
                    du = lang(41)
                    au = lang(42)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        Numjour = datej.DayOfWeek
        datejour = datej.ToString("yyyyMMdd")
        fichierdujour = "rcLog_" + datejour + Ext_Ver + ".csv"
        AFile = "C:\H2observer\data\" + fichierdujour
        Try
            FileOpen(1, (AFile), OpenMode.Input, OpenAccess.Read, OpenShare.Shared) 'ouvre en lecture partagée
            Do
                tableau = Split(LineInput(1), ";")
                Dim TestString As String = tableau(1)
                pr01 = Val(Replace(tableau(14), ",", "."))
                Dim h = TestString.Substring(0, 2)

                If (tableau(7) = mod_prod And h = hi And pr01 <= SeuilPR01) Then ' relevé en mode production eth =heure  et pr01<- seuilpro01
                    datte = tableau(0)
                    heure = tableau(1)
                    id = tableau(2)
                    info = tableau(3)
                    mode_de_fonctionnement = tableau(4)
                    etat_de_base = tableau(5)
                    programme_desinfection_thermique = tableau(6)
                    etape = tableau(7)
                    fl01 = Val(Replace(tableau(8), ",", "."))
                    fl02 = Val(Replace(tableau(9), ",", "."))
                    fl01_fl02 = tableau(10)
                    fl03 = Val(Replace(tableau(11), ",", "."))
                    fl04 = tableau(12)
                    fl05 = Val(Replace(tableau(13), ",", "."))
                    pr01 = tableau(14)
                    pr05 = tableau(15)
                    pr06 = tableau(16)
                    pr07 = tableau(17)
                    pr08 = tableau(18)
                    pr09 = tableau(19)
                    pr10 = Val(Replace(tableau(20), ",", "."))
                    pr04 = Val(Replace(tableau(21), ",", "."))
                    q01 = Val(Replace(tableau(22), ",", "."))
                    t01 = Val(Replace(tableau(23), ",", "."))
                    q02 = Val(Replace(tableau(24), ",", "."))
                    t02 = tableau(25)
                    q03 = Val(Replace(tableau(26), ",", "."))
                    t03 = Val(Replace(tableau(27), ",", "."))
                    t11 = tableau(28)
                    t12 = tableau(29)
                    t05 = tableau(30)
                    t06 = tableau(31)
                    t07 = tableau(32)
                    t08 = tableau(33)
                    t09 = tableau(34)
                    t04 = Val(Replace(tableau(35), ",", "."))

                    Select Case Numjour
                        Case 1
                            Lundi1.Text = datte
                            Lundi2.Text = heure
                            TextBox2.Text = du + " " + CDate(Lundi1.Text) + " " + au + " " + CDate(Lundi1.Text).AddDays(6)
                            '-------------------------------------------------
                            If TextBox3.Text <= q01 And q01 <= TextBox4.Text Then
                                Lundi3.ForeColor = Color.Black
                            Else
                                Lundi3.ForeColor = Color.Red
                            End If
                            Lundi3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Lundi4.ForeColor = Color.Black
                            Else
                                Lundi4.ForeColor = Color.Red
                            End If
                            Lundi4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Lundi5.ForeColor = Color.Black
                            Else
                                Lundi5.ForeColor = Color.Red
                            End If
                            Lundi5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Lundi6.ForeColor = Color.Black
                            Else
                                Lundi6.ForeColor = Color.Red
                            End If
                            Lundi6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Lundi7.ForeColor = Color.Black
                            Else
                                Lundi7.ForeColor = Color.Red
                            End If
                            Lundi7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                lundi8.ForeColor = Color.Black
                            Else
                                lundi8.ForeColor = Color.Red
                            End If
                            lundi8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Lundi9.ForeColor = Color.Black
                            Else
                                Lundi9.ForeColor = Color.Red
                            End If
                            Lundi9.Text = fl05
                            '-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Lundi10.ForeColor = Color.Black
                            Else
                                Lundi10.ForeColor = Color.Red
                            End If
                            Lundi10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Lundi11.ForeColor = Color.Black
                            Else
                                Lundi11.ForeColor = Color.Red
                            End If
                            Lundi11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Lundi12.ForeColor = Color.Black
                            Else
                                Lundi12.ForeColor = Color.Red
                            End If
                            Lundi12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Lundi13.ForeColor = Color.Black
                            Else
                                Lundi13.ForeColor = Color.Red
                            End If
                            Lundi13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Lundi14.ForeColor = Color.Black
                            Else
                                Lundi14.ForeColor = Color.Red
                            End If
                            Lundi14.Text = t04

                        Case 2
                            Mardi1.Text = datte
                            Mardi2.Text = heure
                            TextBox2.Text = du + " " + CDate(Mardi1.Text).AddDays(-1) + " " + au + " " + CDate(Mardi1.Text).AddDays(5)
                            '-------------------------------------------------
                            If TextBox3.Text <= q01 And q01 <= TextBox4.Text Then
                                Mardi3.ForeColor = Color.Black
                            Else
                                Mardi3.ForeColor = Color.Red
                            End If
                            Mardi3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Mardi4.ForeColor = Color.Black
                            Else
                                Mardi4.ForeColor = Color.Red
                            End If
                            Mardi4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Mardi5.ForeColor = Color.Black
                            Else
                                Mardi5.ForeColor = Color.Red
                            End If
                            Mardi5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Mardi6.ForeColor = Color.Black
                            Else
                                Mardi6.ForeColor = Color.Red
                            End If
                            Mardi6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Mardi7.ForeColor = Color.Black
                            Else
                                Mardi7.ForeColor = Color.Red
                            End If
                            Mardi7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                Mardi8.ForeColor = Color.Black
                            Else
                                Mardi8.ForeColor = Color.Red
                            End If
                            Mardi8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Mardi9.ForeColor = Color.Black
                            Else
                                Mardi9.ForeColor = Color.Red
                            End If
                            Mardi9.Text = fl05
                            '-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Mardi10.ForeColor = Color.Black
                            Else
                                Mardi10.ForeColor = Color.Red
                            End If
                            Mardi10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Mardi11.ForeColor = Color.Black
                            Else
                                Mardi11.ForeColor = Color.Red
                            End If
                            Mardi11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Mardi12.ForeColor = Color.Black
                            Else
                                Mardi12.ForeColor = Color.Red
                            End If
                            Mardi12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Mardi13.ForeColor = Color.Black
                            Else
                                Mardi13.ForeColor = Color.Red
                            End If
                            Mardi13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Mardi14.ForeColor = Color.Black
                            Else
                                Mardi14.ForeColor = Color.Red
                            End If
                            Mardi14.Text = t04

                        Case 3
                            Mercredi1.Text = datte
                            Mercredi2.Text = heure
                            TextBox2.Text = du + " " + CDate(Mercredi1.Text).AddDays(-2) + " " + au + " " + CDate(Mercredi1.Text).AddDays(4)
                            '-------------------------------------------------
                            If TextBox3.Text <= q01 And q01 <= TextBox4.Text Then
                                Mercredi3.ForeColor = Color.Black
                            Else
                                Mercredi3.ForeColor = Color.Red
                            End If
                            Mercredi3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Mercredi4.ForeColor = Color.Black
                            Else
                                Mercredi4.ForeColor = Color.Red
                            End If
                            Mercredi4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Mercredi5.ForeColor = Color.Black
                            Else
                                Mercredi5.ForeColor = Color.Red
                            End If
                            Mercredi5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Mercredi6.ForeColor = Color.Black
                            Else
                                Mercredi6.ForeColor = Color.Red
                            End If
                            Mercredi6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Mercredi7.ForeColor = Color.Black
                            Else
                                Mercredi7.ForeColor = Color.Red
                            End If
                            Mercredi7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                Mercredi8.ForeColor = Color.Black
                            Else
                                Mercredi8.ForeColor = Color.Red
                            End If
                            Mercredi8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Mercredi9.ForeColor = Color.Black
                            Else
                                Mercredi9.ForeColor = Color.Red
                            End If
                            Mercredi9.Text = fl05
                            '-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Mercredi10.ForeColor = Color.Black
                            Else
                                Mercredi10.ForeColor = Color.Red
                            End If
                            Mercredi10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Mercredi11.ForeColor = Color.Black
                            Else
                                Mercredi11.ForeColor = Color.Red
                            End If
                            Mercredi11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Mercredi12.ForeColor = Color.Black
                            Else
                                Mercredi12.ForeColor = Color.Red
                            End If
                            Mercredi12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Mercredi13.ForeColor = Color.Black
                            Else
                                Mercredi13.ForeColor = Color.Red
                            End If
                            Mercredi13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Mercredi14.ForeColor = Color.Black
                            Else
                                Mercredi14.ForeColor = Color.Red
                            End If
                            Mercredi14.Text = t04

                        Case 4
                            Jeudi1.Text = datte
                            Jeudi2.Text = heure
                            TextBox2.Text = du + " " + CDate(Jeudi1.Text).AddDays(-3) + " " + au + " " + CDate(Jeudi1.Text).AddDays(3)
                            '-------------------------------------------------
                            If TextBox3.Text <= q01 And q01 <= TextBox4.Text Then
                                Jeudi3.ForeColor = Color.Black
                            Else
                                Jeudi3.ForeColor = Color.Red
                            End If
                            Jeudi3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Jeudi4.ForeColor = Color.Black
                            Else
                                Jeudi4.ForeColor = Color.Red
                            End If
                            Jeudi4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Jeudi5.ForeColor = Color.Black
                            Else
                                Jeudi5.ForeColor = Color.Red
                            End If
                            Jeudi5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Jeudi6.ForeColor = Color.Black
                            Else
                                Jeudi6.ForeColor = Color.Red
                            End If
                            Jeudi6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Jeudi7.ForeColor = Color.Black
                            Else
                                Jeudi7.ForeColor = Color.Red
                            End If
                            Jeudi7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                Jeudi8.ForeColor = Color.Black
                            Else
                                Jeudi8.ForeColor = Color.Red
                            End If
                            Jeudi8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Jeudi9.ForeColor = Color.Black
                            Else
                                Jeudi9.ForeColor = Color.Red
                            End If
                            Jeudi9.Text = fl05
                            '-------------------------------------------------'-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Jeudi10.ForeColor = Color.Black
                            Else
                                Jeudi10.ForeColor = Color.Red
                            End If
                            Jeudi10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Jeudi11.ForeColor = Color.Black
                            Else
                                Jeudi11.ForeColor = Color.Red
                            End If
                            Jeudi11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Jeudi12.ForeColor = Color.Black
                            Else
                                Jeudi12.ForeColor = Color.Red
                            End If
                            Jeudi12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Jeudi13.ForeColor = Color.Black
                            Else
                                Jeudi13.ForeColor = Color.Red
                            End If
                            Jeudi13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Jeudi14.ForeColor = Color.Black
                            Else
                                Jeudi14.ForeColor = Color.Red
                            End If
                            Jeudi14.Text = t04

                        Case 5
                            Vendredi1.Text = datte
                            Vendredi2.Text = heure
                            TextBox2.Text = du + " " + CDate(Vendredi1.Text).AddDays(-4) + " " + au + " " + CDate(Vendredi1.Text).AddDays(2)
                            '-------------------------------------------------
                            If q01min <= q01 And q01 <= q01max Then
                                Vendredi3.ForeColor = Color.Black
                            Else
                                Vendredi3.ForeColor = Color.Red
                            End If
                            Vendredi3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Vendredi4.ForeColor = Color.Black
                            Else
                                Vendredi4.ForeColor = Color.Red
                            End If
                            Vendredi4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Vendredi5.ForeColor = Color.Black
                            Else
                                Vendredi5.ForeColor = Color.Red
                            End If
                            Vendredi5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Vendredi6.ForeColor = Color.Black
                            Else
                                Vendredi6.ForeColor = Color.Red
                            End If
                            Vendredi6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Vendredi7.ForeColor = Color.Black
                            Else
                                Vendredi7.ForeColor = Color.Red
                            End If
                            Vendredi7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                Vendredi8.ForeColor = Color.Black
                            Else
                                Vendredi8.ForeColor = Color.Red
                            End If
                            Vendredi8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Vendredi9.ForeColor = Color.Black
                            Else
                                Vendredi9.ForeColor = Color.Red
                            End If
                            Vendredi9.Text = fl05
                            '-------------------------------------------------'-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Vendredi10.ForeColor = Color.Black
                            Else
                                Vendredi10.ForeColor = Color.Red
                            End If
                            Vendredi10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Vendredi11.ForeColor = Color.Black
                            Else
                                Vendredi11.ForeColor = Color.Red
                            End If
                            Vendredi11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Vendredi12.ForeColor = Color.Black
                            Else
                                Vendredi12.ForeColor = Color.Red
                            End If
                            Vendredi12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Vendredi13.ForeColor = Color.Black
                            Else
                                Vendredi13.ForeColor = Color.Red
                            End If
                            Vendredi13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Vendredi14.ForeColor = Color.Black
                            Else
                                Vendredi14.ForeColor = Color.Red
                            End If
                            Vendredi14.Text = t04

                        Case 6
                            Samedi1.Text = datte
                            Samedi2.Text = heure
                            TextBox2.Text = du + " " + CDate(Samedi1.Text).AddDays(-5) + " " + au + " " + CDate(Samedi1.Text).AddDays(1)
                            '-------------------------------------------------
                            If TextBox3.Text <= q01 And q01 <= TextBox4.Text Then
                                Samedi3.ForeColor = Color.Black
                            Else
                                Samedi3.ForeColor = Color.Red
                            End If
                            Samedi3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Samedi4.ForeColor = Color.Black
                            Else
                                Samedi4.ForeColor = Color.Red
                            End If
                            Samedi4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Samedi5.ForeColor = Color.Black
                            Else
                                Samedi5.ForeColor = Color.Red
                            End If
                            Samedi5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Samedi6.ForeColor = Color.Black
                            Else
                                Samedi6.ForeColor = Color.Red
                            End If
                            Samedi6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Samedi7.ForeColor = Color.Black
                            Else
                                Samedi7.ForeColor = Color.Red
                            End If
                            Samedi7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                Samedi8.ForeColor = Color.Black
                            Else
                                Samedi8.ForeColor = Color.Red
                            End If
                            Samedi8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Samedi9.ForeColor = Color.Black
                            Else
                                Samedi9.ForeColor = Color.Red
                            End If
                            Samedi9.Text = fl05
                            '-------------------------------------------------'-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Samedi10.ForeColor = Color.Black
                            Else
                                Samedi10.ForeColor = Color.Red
                            End If
                            Samedi10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Samedi11.ForeColor = Color.Black
                            Else
                                Samedi11.ForeColor = Color.Red
                            End If
                            Samedi11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Samedi12.ForeColor = Color.Black
                            Else
                                Samedi12.ForeColor = Color.Red
                            End If
                            Samedi12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Samedi13.ForeColor = Color.Black
                            Else
                                Samedi13.ForeColor = Color.Red
                            End If
                            Samedi13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Samedi14.ForeColor = Color.Black
                            Else
                                Samedi14.ForeColor = Color.Red

                            End If
                            Samedi14.Text = t04

                        Case 7
                            Dimanche1.Text = datte
                            Dimanche2.Text = heure
                            TextBox2.Text = du + " " + CDate(Dimanche1.Text).AddDays(-6) + " " + au + " " + CDate(Dimanche1.Text)
                            '-------------------------------------------------
                            If TextBox3.Text <= q01 And q01 <= TextBox4.Text Then
                                Dimanche3.ForeColor = Color.Black
                            Else
                                Dimanche3.ForeColor = Color.Red
                            End If
                            Dimanche3.Text = q01
                            '-------------------------------------------------
                            If TextBox5.Text <= q02 And q02 <= TextBox6.Text Then
                                Dimanche4.ForeColor = Color.Black
                            Else
                                Dimanche4.ForeColor = Color.Red
                            End If
                            Dimanche4.Text = q02
                            '-------------------------------------------------
                            If TextBox7.Text <= q03 And q03 <= TextBox8.Text Then
                                Dimanche5.ForeColor = Color.Black
                            Else
                                Dimanche5.ForeColor = Color.Red
                            End If
                            Dimanche5.Text = q03
                            '-------------------------------------------------
                            If TextBox9.Text <= fl01 And fl01 <= TextBox10.Text Then
                                Dimanche6.ForeColor = Color.Black
                            Else
                                Dimanche6.ForeColor = Color.Red
                            End If
                            Dimanche6.Text = fl01
                            '-------------------------------------------------
                            If TextBox11.Text <= fl02 And fl02 <= TextBox12.Text Then
                                Dimanche7.ForeColor = Color.Black
                            Else
                                Dimanche7.ForeColor = Color.Red
                            End If
                            Dimanche7.Text = fl02
                            '-------------------------------------------------
                            If TextBox13.Text <= fl03 And fl03 <= TextBox14.Text Then
                                Dimanche8.ForeColor = Color.Black
                            Else
                                Dimanche8.ForeColor = Color.Red
                            End If
                            Dimanche8.Text = fl03
                            '-------------------------------------------------
                            If TextBox15.Text <= fl05 And fl05 <= TextBox16.Text Then
                                Dimanche9.ForeColor = Color.Black
                            Else
                                Dimanche9.ForeColor = Color.Red
                            End If
                            Dimanche9.Text = fl05
                            '-------------------------------------------------'-------------------------------------------------
                            If TextBox17.Text <= pr10 And pr10 <= TextBox18.Text Then
                                Dimanche10.ForeColor = Color.Black
                            Else
                                Dimanche10.ForeColor = Color.Red
                            End If
                            Dimanche10.Text = pr10
                            '-------------------------------------------------
                            If TextBox19.Text <= pr04 And pr04 <= TextBox20.Text Then
                                Dimanche11.ForeColor = Color.Black
                            Else
                                Dimanche11.ForeColor = Color.Red
                            End If
                            Dimanche11.Text = pr04
                            '-------------------------------------------------
                            If TextBox21.Text <= t01 And t01 <= TextBox22.Text Then
                                Dimanche12.ForeColor = Color.Black
                            Else
                                Dimanche12.ForeColor = Color.Red
                            End If
                            Dimanche12.Text = t01
                            '-------------------------------------------------
                            If TextBox23.Text <= t03 And t03 <= TextBox24.Text Then
                                Dimanche13.ForeColor = Color.Black
                            Else
                                Dimanche13.ForeColor = Color.Red
                            End If
                            Dimanche13.Text = t03
                            '-------------------------------------------------
                            If TextBox25.Text <= t04 And t04 <= TextBox26.Text Then
                                Dimanche14.ForeColor = Color.Black
                            Else
                                Dimanche14.ForeColor = Color.Red

                            End If
                            Dimanche14.Text = t04
                    End Select
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Form_Relevés.releves()() ligne 964 " + CStr(ex.Message)
            DefLog(erreur)
        End Try

        If Numjour <> 1 Then
            datej = datej.AddDays(-1)
            GoTo relevés
        End If
        '-------------------------------------------------------------
        'enregister le relevé des paramètres en png avant envoie
        '-------------------------------------------------------------
        Me.Show()
        Threading.Thread.Sleep(1000)
        Button8.Visible = False
        Button1.Visible = False
        Button3.Focus()
        Dim b As New Bitmap(Me.Width, Me.Height)
        Dim ff
        ff = "C:\H2observer\releves\" + "releves" + semaine.ToString + annee.ToString + ".png"
        Me.DrawToBitmap(b, New Rectangle(0, 0, Me.Width, Me.Height))
        b.Save(ff, Imaging.ImageFormat.Png)
        Button8.Visible = True
        If Ver3 Then Button1.Visible = True
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
            Dim erreur = " : Dans le module Form_releves() ligne 998" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        If tableau_conf1(23) = "True" Then
            Try
                TextBox3.Text = TextBox3.Text.Replace(".", ",") 'force la virguel comme séparateur décimal
                TextBox4.Text = TextBox4.Text.Replace(".", ",")
                Dim sw As New StreamWriter("C:\H2observer\configuration\param.cfg")
                sw.WriteLine(TextBox3.Text + ";" + TextBox4.Text _
                      + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text _
                      + ";" + TextBox8.Text + ";" + TextBox9.Text + ";" + TextBox10.Text _
                      + ";" + TextBox11.Text + ";" + TextBox12.Text + ";" + TextBox13.Text _
                      + ";" + TextBox14.Text + ";" + TextBox15.Text + ";" + TextBox16.Text _
                      + ";" + TextBox17.Text + ";" + TextBox18.Text + ";" + TextBox19.Text _
                      + ";" + TextBox20.Text + ";" + TextBox21.Text + ";" + TextBox22.Text _
                      + ";" + TextBox23.Text + ";" + TextBox24.Text + ";" + TextBox25.Text _
                      + ";" + TextBox26.Text)
                sw.Close()
            Catch ex As Exception
                Dim erreur = " : Dans le module Form_Relevés.Button8_Click() ligne 1018 " + CStr(ex.Message)
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
                Dim erreur = "Dans le module Form_Relevés.Button8_Click() ligne 1036 " + CStr(ex.Message)
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
    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover

        Button8.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave

        Button8.FlatStyle = FlatStyle.Flat

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim tableau_conf1()
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module Form_releves() ligne 1074" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        If tableau_conf1(23) = "True" Then
            Try
                TextBox3.Text = TextBox3.Text.Replace(".", ",") 'force la virguel comme séparateur décimal
                TextBox4.Text = TextBox4.Text.Replace(".", ",")
                Dim sw As New StreamWriter("C:\H2observer\configuration\param.cfg")
                sw.WriteLine(TextBox3.Text + ";" + TextBox4.Text _
                      + ";" + TextBox5.Text + ";" + TextBox6.Text + ";" + TextBox7.Text _
                      + ";" + TextBox8.Text + ";" + TextBox9.Text + ";" + TextBox10.Text _
                      + ";" + TextBox11.Text + ";" + TextBox12.Text + ";" + TextBox13.Text _
                      + ";" + TextBox14.Text + ";" + TextBox15.Text + ";" + TextBox16.Text _
                      + ";" + TextBox17.Text + ";" + TextBox18.Text + ";" + TextBox19.Text _
                      + ";" + TextBox20.Text + ";" + TextBox21.Text + ";" + TextBox22.Text _
                      + ";" + TextBox23.Text + ";" + TextBox24.Text + ";" + TextBox25.Text _
                      + ";" + TextBox26.Text)
                sw.Close()
            Catch ex As Exception
                Dim erreur = " : Dans le module Form_Relevés.Button8_Click() ligne 1022 " + CStr(ex.Message)
                DefLog(erreur)
            End Try
        End If
        Me.Close()

        Form_Prétraitement.TopLevel = False
        Form_Prétraitement.Visible = True
        Acceuil.Panel1.Controls.Add(Form_Prétraitement)
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
End Class
