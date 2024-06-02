Imports System.Windows.Forms.DataVisualization.Charting

Imports System.Windows.Forms.DataVisualization.Charting.ChartElement

Imports System.IO
Public Class Recherche

    Public Shared ReadOnly Property WaitCursor As Cursor
    Private T01 As New Series : Dim T02 As New Series : Dim T03 As New Series : Dim T04 As New Series : Dim T05 As New Series : Dim T06 As New Series
    Private T07 As New Series : Dim T08 As New Series : Dim T09 As New Series : Dim T11 As New Series : Dim T12 As New Series
    Private Q01 As New Series : Dim Q02 As New Series : Dim Q03 As New Series : Dim FL01 As New Series : Dim FL02 As New Series : Dim FL03 As New Series
    Private FL04 As New Series : Dim FL05 As New Series : Dim PR01 As New Series : Dim PR04 As New Series : Dim PR05 As New Series
    Private PR06 As New Series : Dim PR07 As New Series : Dim PR08 As New Series : Dim PR09 As New Series : Dim PR010 As New Series
    Private T030 As New Series : Dim Q030 As New Series : Dim COL01 As New Series : Dim COL02 As New Series : Dim COL03 As New Series
    Private V09 As New Series

    Private lang() : Private eco_vanne







    Private Sub Recherche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Ver3 = True Then RadioButton5.Enabled = True Else RadioButton5.Enabled = False
        RadioButton6.Visible = False
        ' Dim lang()
        ' Dim B2 = "Acceuil"
        'Dim B3 = "Envoyer par email"
        'Dim B4 = "Recherche"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do

                lang = Split(LineInput(1), ";")
                If lang(0) = "Recherche" And lang(1) = Langue Then
                    ' Dim B2 = lang(2)
                    'Dim B3 = lang(3)
                    'Dim B4 = lang(4)

                    GroupBox7.Text = lang(5)
                    RadioButton1.Text = lang(6)
                    RadioButton2.Text = lang(7)
                    RadioButton3.Text = lang(8)
                    RadioButton4.Text = lang(9)
                    RadioButton5.Text = lang(10)

                    critere_recherche.Text = lang(11)
                    CheckBox28.Text = lang(12)
                    CheckBox29.Text = lang(13)
                    Label2.Text = lang(14)
                    Label3.Text = lang(15)
                    Label1.Text = lang(16)
                    Label4.Text = lang(17)

                    sonde_temperature.Text = lang(7)
                    capteur_pression.Text = lang(9)
                    capteur_pretraitement.Text = lang(10)
                    sonde_conductivite.Text = lang(6)
                    capteur_debit.Text = lang(8)

                    GroupBox2.Text = lang(18) ' envoie mail
                    Label5.Text = lang(19)     ' selection email

                    ' Dim titre_x_Dates = lang(20)            '"Dates "
                    '  Dim titre__y_temp = lang(21)               '"Températures  °c "


                    ' Dim date_excel = lang(22)
                    ' Dim heure_excel = lang(23)
                    ' Dim mode_production = lang(24)

                    ' Dim titre_axe_y_cond = lang(25)            '"Conductivités  µs / cm"
                    ' Dim titre_axe_y_pres = lang(26)            '"Pressions  bars"
                    '  Dim titre_axe_y_deb = lang(27)             '"Débits   l / h"
                    ' Dim HEURE_DEBUT = lang(28)
                    ' Dim HEURE_DU_JOUR = lang(29)
                    '  Dim DATE_DEBUT = lang(30)
                    ' Dim Photo_Courbe = lang(31)
                    ' heure de desinfection=lang(32)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        CheckBox35.Text = lang(34)
        CheckBox37.Text = lang(35)
        CheckBox36.Text = lang(36)

        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button2, lang(2))
        tooltip1.SetToolTip(Button3, lang(3))
        tooltip1.SetToolTip(Button4, lang(4))
        tooltip1.SetToolTip(Button1, "Envoyer")
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500


        critere_recherche.Visible = False
        sonde_temperature.Visible = False
        capteur_pression.Visible = False
        sonde_conductivite.Visible = False '
        capteur_debit.Visible = False
        Label4.Visible = False
        MaskedTextBox4.Visible = False
        GroupBox2.Visible = False


        ' Dim ctrle As Control
        ' Dim cpter = 3


        ' For Each ctrle In critere_recherche.Controls

        'If TypeOf ctrle Is RadioButton Then
        'ctrle.Text = lang(cpter)
        'cpter = cpter + 1

        'End If
        'Next


    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub
    Private Sub Courbe_Temp_Date(recherche_date_debut, recherche_date_fin, saut)
        Chart1.ChartAreas(0).AxisX.Title = lang(20)                   '"Dates "
        Chart1.ChartAreas(0).AxisY.Title = lang(21) + "  °c"          '"Températures  °c "
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$                'chemin fichier

        Dim chaines              ' fichier excel creation
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; T01; T02; T03; T04; T05; T06; T07; T08; T09; T011; T012"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)     'option excel activer

        Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t011, t012
            Dim test_date1
            Dim temps
            Dim datte, fonctionnement, desinfection_thermique, heures, etape
            Dim table()
            Dim compteur
            Dim nom_titre As String

            If recherche_date_debut >= recherche_date_fin Then recherche_date_debut = recherche_date_fin - 2
            temps = DateTimePicker1.Value
            Do While recherche_date_debut < recherche_date_fin

            foc$ = "C:\H2observer\data\rclog_" + recherche_date_debut + Ext_Ver + ".csv"
            compteur = 0
                Dim monStreamReader As StreamReader = New StreamReader(foc$)
                Dim ligne As String

                Do
                    ligne = monStreamReader.ReadLine()
                    If ligne = "" Then Exit Do
                    table = Split(ligne, ";")
                    compteur = compteur + 1
                    heures = table(1)

                If (compteur >= 2) And (MaskedTextBox3.Text >= Mid(heures, 1, 5)) And (table(7) = lang(24)) Then
                    datte = table(0)
                    nom_titre = table(6)
                    t1 = Val(Replace(table(23), ",", "."))
                    t2 = Val(Replace(table(25), ",", "."))
                    t3 = Val(Replace(table(27), ",", "."))
                    t4 = Val(Replace(table(35), ",", "."))
                    t5 = Val(Replace(table(30), ",", "."))
                    t6 = Val(Replace(table(31), ",", "."))
                    t7 = Val(Replace(table(32), ",", "."))
                    t8 = Val(Replace(table(33), ",", "."))
                    t9 = Val(Replace(table(34), ",", "."))
                    t011 = Val(Replace(table(28), ",", "."))
                    t012 = Val(Replace(table(29), ",", "."))

                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(23) + ";" + table(25) + ";" + table(27) + ";" + table(28) + ";" + table(29) + ";" + table(30) + ";" + table(31) + ";" + table(32) + ";" + table(33) + ";" + table(34) + ";" + table(35)
                        sw.WriteLine(chaines)
                    End If

                    T01.Points.AddXY(table(0), t1)
                    T02.Points.AddXY(table(0), t2)
                    T03.Points.AddXY(table(0), t3)
                    T04.Points.AddXY(table(0), t4)
                    T05.Points.AddXY(table(0), t5)
                    T06.Points.AddXY(table(0), t6)
                    T07.Points.AddXY(table(0), t7)
                    T08.Points.AddXY(table(0), t8)
                    T09.Points.AddXY(table(0), t9)
                    T11.Points.AddXY(table(0), t011)
                    T12.Points.AddXY(table(0), t012)
                    Exit Do
                End If

            Loop Until ligne Is Nothing
                monStreamReader.Close()
                Dim depart = DateAdd("d", saut, DateTimePicker1.Value)
                DateTimePicker1.Value = depart
                recherche_date_debut = Format(CDate(DateTimePicker1.Value), "yyyyMMdd")
            Loop

            DateTimePicker1.Value = temps




        sw.Close()
    End Sub

    Private Sub Courbe_Conduc_Date(recherche_date_debut, recherche_date_fin, saut)
        Chart1.ChartAreas(0).AxisX.Title = lang(20)                  ' "Dates "
        Chart1.ChartAreas(0).AxisY.Title = lang(25) + " µs / cm"                          '"Conductivités  µs / cm"
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier

        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; Q01; Q02; Q03"

        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)

        If CheckBox29.Checked = True Then sw.WriteLine(chaines)

        Dim q1
        Dim q2, q3

        Dim test_date1
        Dim temps
        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim table()
        Dim compteur
        Dim nom_titre As String
        If recherche_date_debut >= recherche_date_fin Then recherche_date_debut = recherche_date_fin - 2
        temps = DateTimePicker1.Value

        Do While recherche_date_debut < recherche_date_fin

            foc$ = "C:\H2observer\data\rclog_" + recherche_date_debut + Ext_Ver + ".csv"
            compteur = 0

            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes 
            Do
                ligne = monStreamReader.ReadLine()
                If ligne = "" Then Exit Do
                table = Split(ligne, ";")
                compteur = compteur + 1
                heures = table(1)

                If (compteur >= 2) And (MaskedTextBox3.Text >= Mid(heures, 1, 5)) And (table(7) = lang(24)) Then

                    datte = table(0)
                    nom_titre = table(6)
                    q1 = Val(Replace(table(22), ",", ".")) * 1000
                    q2 = Val(Replace(table(24), ",", "."))
                    q3 = Val(Replace(table(26), ",", "."))

                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(22) + ";" + table(24) + ";" + table(26)
                        sw.WriteLine(chaines)
                    End If

                    Q01.Points.AddXY(table(0), q1)
                    Q02.Points.AddXY(table(0), q2)
                    Q03.Points.AddXY(table(0), q3)
                    Exit Do
                End If

            Loop Until ligne Is Nothing
            monStreamReader.Close()

            Dim depart = DateAdd("d", saut, DateTimePicker1.Value)
            DateTimePicker1.Value = depart
            recherche_date_debut = Format(CDate(DateTimePicker1.Value), "yyyyMMdd")
        Loop

        DateTimePicker1.Value = temps
        sw.Close()
    End Sub
    Private Sub Courbe_Consommation(Test_date)
        ' Chart1.ChartAreas(0).AxisX.Title = lang(23)             '"Heures "
        ' Chart1.ChartAreas(0).AxisY.Title = lang(26) + "  bars"                    '"Pressions  bars"
        ' Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"


        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Dim V09_0N, V09_OFF, VALEUR
        Dim CALO = 0
        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim table()
        Dim compteur
        Dim nom_titre As String
        V09_0N = 0
        V09_OFF = 0
        compteur = 0

        Dim monStreamReader As StreamReader = New StreamReader(foc$)
        Dim ligne As String

        'Lecture de toutes les lignes 
        Do
            ligne = monStreamReader.ReadLine()
            table = Split(ligne, ";")
            compteur += 1
            heures = table(1)

            If compteur >= 2 And (heures >= MaskedTextBox3.Text And heures <= MaskedTextBox4.Text) And (table(7) = lang(24)) Then
                datte = table(0)
                nom_titre = table(6)
                '  VALEUR = Val(Replace(table(38), ",", "."))"V09_ON" Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
                If table(38) = "ON" Then V09_0N = V09_0N + 1 Else V09_OFF = V09_OFF + 1
                '  CALO = CALO + table(42)
                ' If table(42) > 0 Then
                '  Dim polo = 3
                'End If
            End If

        Loop Until ligne Is Nothing
        monStreamReader.Close()
        'Dim calo1 = (CALO / 60) * Int(V09_0N / (V09_0N + V09_OFF) * 100)
        'Dim calo2 = (CALO / 60) * (100 - Int(V09_0N / (V09_0N + V09_OFF) * 100))
        V09.Points.AddXY("Mode standard" + Str(Int(V09_0N / (V09_0N + V09_OFF) * 100)) + "%", V09_0N) 'Str(calo1), V09_0N)
        V09.Points.AddXY("Mode economique" + Str(100 - Int(V09_0N / (V09_0N + V09_OFF) * 100)) + "%", V09_OFF) 'Str(calo2), V09_OFF)

        Chart1.Titles.Clear()
        ' Chart1.Titles.Add("FONCTIONNEMENT ECO VANNE")
        '  Chart1.Titles.Add(Str(Int(CALO / 60)) + " Litres")
        Chart1.Titles(0).Font = New Font("Arial", 15, FontStyle.Bold)
        Chart1.Titles(1).Font = New Font("Arial", 15, FontStyle.Bold)
        Chart1.Titles.Add(Num_série)


    End Sub
    Private Sub Courbe_Pression(Test_date)
        Chart1.ChartAreas(0).AxisX.Title = lang(23)             '"Heures "
        Chart1.ChartAreas(0).AxisY.Title = lang(26) + "  bars"                    '"Pressions  bars"
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"

        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; PR01;PR04;PR05;PR06; PR07; PR08; PR09; PR010"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            Dim pr1, pr4, pr5, pr6, pr7, pr8, pr9, pr10

            Dim datte, fonctionnement, desinfection_thermique, heures, etape
            Dim table()
            Dim compteur
            Dim nom_titre As String

            compteur = 0

            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes 
            Do
                ligne = monStreamReader.ReadLine()
                table = Split(ligne, ";")
                compteur = compteur + 1
                heures = table(1)

            If compteur >= 2 And (heures >= MaskedTextBox3.Text And heures <= MaskedTextBox4.Text) Then
                datte = table(0)
                nom_titre = table(6)
                pr1 = Val(Replace(table(14), ",", "."))
                pr4 = Val(Replace(table(21), ",", "."))
                pr5 = Val(Replace(table(15), ",", "."))
                pr6 = Val(Replace(table(16), ",", "."))
                pr7 = Val(Replace(table(17), ",", "."))
                pr8 = Val(Replace(table(18), ",", "."))
                pr9 = Val(Replace(table(19), ",", "."))
                pr10 = Val(Replace(table(20), ",", "."))

                PR01.Points.AddXY(heures, pr1)
                PR04.Points.AddXY(heures, pr4)
                PR05.Points.AddXY(heures, pr5)
                PR06.Points.AddXY(heures, pr6)
                PR07.Points.AddXY(heures, pr7)
                PR08.Points.AddXY(heures, pr8)
                PR09.Points.AddXY(heures, pr9)
                PR010.Points.AddXY(heures, pr10)
                If CheckBox29.Checked = True Then
                    chaines = table(0) + ";" + table(1) + ";" + table(14) + ";" + table(21) + ";" + table(15) + ";" + table(16) + ";" + table(17) + ";" + table(18) + ";" + table(19) + ";" + table(20)

                    sw.WriteLine(chaines)

                    ' pr1 = Val(table(14)) : pr4 = Val(table(21)) : pr5 = Val(table(15)) : pr6 = Val(table(16)) : pr7 = Val(table(17)) : pr8 = Val(table(18))
                    ' pr9 = Val(table(19)) : pr10 = Val(table(20))
                End If
                ' If InStr(1, table(3), "F") > 0 And InStr(1, table(3), "avert") <= 0 Then 'ALARM.Points.AddXY(heures, pr7) Else ALARM.Points.AddXY(heures, 0) ' visualisation pont sur courbe
                ' If CheckBox6.Checked = True Then ALARM.Points.AddXY(heures, pr1)
                ' If CheckBox7.Checked = True Then ALARM.Points.AddXY(heures, pr4)
                'If CheckBox8.Checked = True Then ALARM.Points.AddXY(heures, pr5)
                'If CheckBox9.Checked = True Then ALARM.Points.AddXY(heures, pr6)
                'If CheckBox10.Checked = True Then ALARM.Points.AddXY(heures, pr7)
                'If CheckBox11.Checked = True Then ALARM.Points.AddXY(heures, pr8)
                'If CheckBox12.Checked = True Then ALARM.Points.AddXY(heures, pr9)
                'If CheckBox13.Checked = True Then ALARM.Points.AddXY(heures, pr10)
                'Else
                'ALARM.Points.AddXY(heures, 0)
                'End If

            End If

        Loop Until ligne Is Nothing
            monStreamReader.Close()




        'Dim zoe
        'zoe = oki
        'Dim stripline As New StripLine
        'StripLine.BackColor = Color.FromArgb(120, Color.Red)
        'StripLine.Interval = 0
        'StripLine.StripWidth = 3
        'StripLine.BorderWidth = 2
        'StripLine.IntervalOffset = zoe
        ' stripline.StripWidthType = 3
        'Chart1.ChartAreas(0).AxisX.StripLines.Add(stripline)
        'ALARM..AddXY.striplines.add(stripline)
        sw.Close()
    End Sub
    Private Sub Courbe_Pretraitement(Test_date)
        Chart1.ChartAreas(0).AxisX.Title = lang(23)                 '"Heures "
        'Chart1.ChartAreas(0).AxisY.Title = lang(27) + " l / h"                     '"Débits   l / h"
        If CheckBox30.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(21) + "  °c"
        If CheckBox31.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(25) + " µs / cm"
        If CheckBox35.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(26) + " bars"
        If CheckBox36.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(26) + " bars"
        If CheckBox37.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(26) + " bars"

        If CheckBox30.Checked = True And CheckBox31.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox30.Checked = True And CheckBox35.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox30.Checked = True And CheckBox36.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox30.Checked = True And CheckBox37.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox31.Checked = True And CheckBox35.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox31.Checked = True And CheckBox36.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox31.Checked = True And CheckBox37.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""

        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"

        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; T30; Q30; PE1; PS1; PE2; PS2; PE3; PS3"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
        Dim t30, q30, col1, col2, col3

        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim table()
        Dim compteur
        Dim nom_titre As String

        compteur = 0

        Dim monStreamReader As StreamReader = New StreamReader(foc$)
        Dim ligne As String

        'Lecture de toutes les lignes 
        Do
            ligne = monStreamReader.ReadLine()
            table = Split(ligne, ";")
            compteur = compteur + 1
            heures = table(1)
            If compteur >= 2 And (heures >= MaskedTextBox3.Text And heures <= MaskedTextBox4.Text) Then
                datte = table(0)
                nom_titre = table(6)
                t30 = Val(Replace(table(44), ",", "."))
                q30 = Val(Replace(table(43), ",", "."))
                col1 = Math.Abs(Val(Replace(table(49), ",", ".")) - Val(Replace(table(50), ",", ".")))
                col2 = Math.Abs(Val(Replace(table(51), ",", ".")) - Val(Replace(table(52), ",", ".")))
                col3 = Math.Abs(Val(Replace(table(53), ",", ".")) - Val(Replace(table(54), ",", ".")))



                If CheckBox29.Checked = True Then
                    chaines = table(0) + ";" + table(1) + ";" + table(44) + ";" + table(43) + ";" + table(49) + ";" + +table(50) + ";" + table(51) + ";" + table(52) + ";" + table(53) + ";" + table(54)
                    sw.WriteLine(chaines)
                End If
                'fl1 = Val(table(8)) : fl2 = Val(table(9)) : fl3 = Val(table(11))
                'fl4 = Val(table(12)) : fl5 = Val(table(13))



                T030.Points.AddXY(heures, t30)
                Q030.Points.AddXY(heures, q30)
                COL01.Points.AddXY(heures, col1)
                COL02.Points.AddXY(heures, col2)
                COL03.Points.AddXY(heures, col3)
            End If

        Loop Until ligne Is Nothing
        monStreamReader.Close()
        sw.Close()



    End Sub

    Private Sub Courbe_Debit(Test_date)
        Chart1.ChartAreas(0).AxisX.Title = lang(23)                '"Heures "
        Chart1.ChartAreas(0).AxisY.Title = lang(27) + " l / h"          '"Débits   l / h"
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; FL01; FL02; FL03; FL04; FL05"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
        Dim fl1, fl2, fl3, fl4, fl5

        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim table()
        Dim compteur
        Dim nom_titre As String

        compteur = 0

        Dim monStreamReader As StreamReader = New StreamReader(foc$)
        Dim ligne As String

        'Lecture de toutes les lignes 
        Do
            ligne = monStreamReader.ReadLine()
            table = Split(ligne, ";")
            compteur = compteur + 1
            heures = table(1)
            If compteur >= 2 And (heures >= MaskedTextBox3.Text And heures <= MaskedTextBox4.Text) Then
                datte = table(0)
                nom_titre = table(6)
                fl1 = Val(Replace(table(8), ",", "."))
                fl2 = Val(Replace(table(9), ",", "."))
                fl3 = Val(Replace(table(11), ",", "."))
                fl4 = Val(Replace(table(12), ",", "."))
                fl5 = Val(Replace(table(13), ",", "."))

                If CheckBox29.Checked = True Then
                    chaines = table(0) + ";" + table(1) + ";" + table(8) + ";" + table(9) + ";" + table(11) + ";" + table(12) + ";" + table(13)
                    sw.WriteLine(chaines)
                End If
                'fl1 = Val(table(8)) : fl2 = Val(table(9)) : fl3 = Val(table(11))
                'fl4 = Val(table(12)) : fl5 = Val(table(13))

                FL01.Points.AddXY(heures, fl1)
                FL02.Points.AddXY(heures, fl2)
                FL03.Points.AddXY(heures, fl3)
                FL04.Points.AddXY(heures, fl4)
                FL05.Points.AddXY(heures, fl5)

            End If

        Loop Until ligne Is Nothing
        monStreamReader.Close()
        sw.Close()
    End Sub
    Private Sub Courbe_Temperature(Test_date)
        Chart1.ChartAreas(0).AxisX.Title = lang(23)             '"Heures "
        Chart1.ChartAreas(0).AxisY.Title = lang(21) + "  °c"    '"Températures  °c"
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; T01; T02; T03; T04; T05; T06; T07; T08; T09; T011; T012" ' "t1; t2; t3; t4; t5; t6; t7; t8; t9; t011; t012"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
            Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t011, t012

            Dim datte, fonctionnement, desinfection_thermique, heures, etape
            Dim table()
            Dim compteur
            Dim nom_titre As String

            compteur = 0

            Dim monStreamReader As StreamReader = New StreamReader(foc$)
        Dim ligne As String = ""

        'Lecture de toutes les lignes 
        Do
                ligne = monStreamReader.ReadLine()
                table = Split(ligne, ";")
                compteur = compteur + 1
                heures = table(1)
                If compteur >= 2 And (heures >= MaskedTextBox3.Text And heures <= MaskedTextBox4.Text) Then
                    datte = table(0)
                    nom_titre = table(6)
                    t1 = Val(Replace(table(23), ",", "."))
                    t2 = Val(Replace(table(25), ",", "."))
                    t3 = Val(Replace(table(27), ",", "."))
                    t4 = Val(Replace(table(35), ",", "."))
                    t5 = Val(Replace(table(30), ",", "."))
                    t6 = Val(Replace(table(31), ",", "."))
                    t7 = Val(Replace(table(32), ",", "."))
                    t8 = Val(Replace(table(33), ",", "."))
                    t9 = Val(Replace(table(34), ",", "."))
                    t011 = Val(Replace(table(28), ",", "."))
                    t012 = Val(Replace(table(29), ",", "."))

                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(23) + ";" + table(25) + ";" + table(27) + ";" + table(28) + ";" + table(29) + ";" + table(30) + ";" + table(31) + ";" + table(32) + ";" + table(33) + ";" + table(34) + ";" + table(35)
                        sw.WriteLine(chaines)
                    End If
                    ' t1 = Val(table(23)) : t2 = Val(table(25)) : t3 = Val(table(27)) : t011 = Val(table(28)) : t012 = Val(table(29)) : t5 = Val(table(30))
                    't6 = Val(table(31)) : t7 = Val(table(32)) : t8 = Val(table(33)) : t9 = Val(table(34)) : t4 = Val(table(35))

                    T01.Points.AddXY(heures, t1)
                    T02.Points.AddXY(heures, t2)
                    T03.Points.AddXY(heures, t3)
                    T04.Points.AddXY(heures, t4)
                    T05.Points.AddXY(heures, t5)
                    T06.Points.AddXY(heures, t6)
                    T07.Points.AddXY(heures, t7)
                    T08.Points.AddXY(heures, t8)
                    T09.Points.AddXY(heures, t9)
                    T11.Points.AddXY(heures, t011)
                    T12.Points.AddXY(heures, t012)

                End If

            Loop Until ligne Is Nothing
            monStreamReader.Close()
        sw.Close()
    End Sub
    Private Sub CheckBox28_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox28.CheckedChanged
        If CheckBox28.Checked = True Then
            Label1.Text = lang(28)                          '"HEURE  DEBUT"
            Label4.Visible = True
            MaskedTextBox4.Visible = True
            Label2.Text = lang(22)                                       '"DATE"
            DateTimePicker2.Visible = False
            Label3.Visible = False
            MaskedTextBox3.Text = "00:00"

        Else
            Label1.Text = lang(29)                                       '"HEURE DU JOUR"
            Label2.Text = lang(30)                                                   '"DATE DEBUT"
            Label3.Visible = True
            MaskedTextBox3.Text = "09:00"
            DateTimePicker2.Visible = True
            Label4.Visible = False
            MaskedTextBox4.Visible = False
        End If
    End Sub
    Private Sub Courbe_Conductivite(Test_date)

        Chart1.ChartAreas(0).AxisX.Title = lang(23)                                              '"Heures "
        Chart1.ChartAreas(0).AxisY.Title = lang(25) + " µs / cm"                             ' "Conductivités   µs / cm"
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; Q01; Q02; Q03"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
            Dim q1, q2, q3



            Dim datte, fonctionnement, desinfection_thermique, heures, etape
            Dim table()
            Dim compteur
            Dim nom_titre As String

            compteur = 0

            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes 
            Do
                ligne = monStreamReader.ReadLine()
                table = Split(ligne, ";")
                compteur = compteur + 1
                heures = table(1)
                If compteur >= 2 And (heures >= MaskedTextBox3.Text And heures <= MaskedTextBox4.Text) Then
                    datte = table(0)
                    nom_titre = table(6)
                q1 = Val(Replace(table(22), ",", ".")) * 1000
                q2 = Val(Replace(table(24), ",", "."))
                    q3 = Val(Replace(table(26), ",", "."))

                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(22) + ";" + table(24) + ";" + table(26)
                        sw.WriteLine(chaines)
                    End If
                    'q1 = Val(table(22)) : q2 = Val(table(24)) : q3 = Val(table(26))

                    Q01.Points.AddXY(heures, q1)
                    Q02.Points.AddXY(heures, q2)
                    Q03.Points.AddXY(heures, q3)

                End If

            Loop Until ligne Is Nothing
            monStreamReader.Close()
        sw.Close()
    End Sub
    Private Sub Recherche_Jour(Test_date)
        Chart1.ChartAreas(0).AxisX.Title = lang(32)                     '"Heures de Desinfection"
        Chart1.ChartAreas(0).AxisY.Title = lang(21) + "  °c"            '"Temperatures   °c"

        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next

        Dim foc$ 'chemin fichier

        If CheckBox28.Checked = True Then Test_date = Format(CDate(DateTimePicker1.Value), "yyyyMMdd")
        foc$ = "C:\H2observer\data\rclog_" + Test_date + Ext_Ver + ".csv"
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; T01; T02; T03; T04; T05; T06; T07; T08; T09; T011; T012; Q01; Q02; Q03; FL01; FL02; FL03; FL04;FL05;PR01; PR04; PR05; PR06;PR07;PR08; PR09; PR010"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
            Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t011, t012
            Dim q1, q2, q3
            Dim fl1, fl2, fl3, fl4, fl5
            Dim pr1, pr4, pr5, pr6, pr7, pr8, pr9, pr10



            Dim datte, fonctionnement, desinfection_thermique, heures, etape

            Dim table() : Dim table_serie()
            Dim cpt As Integer      'nbre enregistrements  total                                                               
            Dim cpt1 As Integer     'nbre enregistrement sup a 80 pour calcul A0
            Dim compteur As Integer 'nbre enregistrement sup a 80 pour calcul A0Jj
            Dim pt_debut, pt_fin
            Dim heur_debut, heur_fin, cp_debut, cp_fin
            Dim popo
            Dim nom_titre As String

            cpt = 0 : compteur = 0 : cpt1 = 0




            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes 
            Do
                ligne = monStreamReader.ReadLine()
                table = Split(ligne, ";")
                compteur = compteur + 1

                If compteur >= 2 Then
                    datte = table(0)
                    heures = table(1)
                    nom_titre = table(6)
                q1 = Val(Replace(table(22), ",", ".")) * 1000
                q2 = Val(Replace(table(24), ",", "."))
                    q3 = Val(Replace(table(26), ",", "."))

                    t1 = Val(Replace(table(23), ",", "."))
                    t2 = Val(Replace(table(25), ",", "."))
                    t3 = Val(Replace(table(27), ",", "."))
                    t4 = Val(Replace(table(35), ",", "."))
                    t5 = Val(Replace(table(30), ",", "."))
                    t6 = Val(Replace(table(31), ",", "."))
                    t7 = Val(Replace(table(32), ",", "."))
                    t8 = Val(Replace(table(33), ",", "."))
                    t9 = Val(Replace(table(34), ",", "."))
                    t011 = Val(Replace(table(28), ",", "."))
                    t012 = Val(Replace(table(29), ",", "."))

                    pr1 = Val(Replace(table(14), ",", "."))
                    pr4 = Val(Replace(table(21), ",", "."))
                    pr5 = Val(Replace(table(15), ",", "."))
                    pr6 = Val(Replace(table(16), ",", "."))
                    pr7 = Val(Replace(table(17), ",", "."))
                    pr8 = Val(Replace(table(18), ",", "."))
                    pr9 = Val(Replace(table(19), ",", "."))
                    pr10 = Val(Replace(table(20), ",", "."))

                    fl1 = Val(Replace(table(8), ",", "."))
                    fl2 = Val(Replace(table(9), ",", "."))
                    fl3 = Val(Replace(table(11), ",", "."))
                    fl4 = Val(Replace(table(12), ",", "."))
                    fl5 = Val(Replace(table(13), ",", "."))


                    If CheckBox29.Checked = True Then
                        Dim chaines1 = table(0) + ";" + table(1) + ";" + table(23) + ";" + table(25) + ";" + table(27) + ";" + table(28) + ";" + table(29) + ";" + table(30) + ";" + table(31) + ";" + table(32) + ";" + table(33) + ";" + table(34) + ";" + table(35) + ";"
                        Dim chaines2 = table(22) + ";" + table(24) + ";" + table(26) + ";"
                        Dim chaines3 = table(8) + ";" + table(9) + ";" + table(11) + ";" + table(12) + ";" + table(13) + ";"
                        Dim chaines4 = table(14) + ";" + table(21) + ";" + table(15) + ";" + table(16) + ";" + table(17) + ";" + table(18) + ";" + table(19) + ";" + table(20)
                        chaines = chaines1 + chaines2 + chaines3 + chaines4
                        sw.WriteLine(chaines)
                    End If
                    ' t1 = Val(table(23)) : t2 = Val(table(25)) : t3 = Val(table(27)) : t011 = Val(table(28)) : t012 = Val(table(29)) : t5 = Val(table(30))
                    ' t6 = Val(table(31)) : t7 = Val(table(32)) : t8 = Val(table(33)) : t9 = Val(table(34)) : t4 = Val(table(35))

                    'q1 = Val(table(22)) : q2 = Val(table(24)) : q3 = Val(table(26))

                    'fl1 = Val(table(8)) : fl2 = Val(table(9)) : fl3 = Val(table(11))
                    'fl4 = Val(table(12)) : fl5 = Val(table(13))


                    'pr1 = Val(table(14)) : pr4 = Val(table(21)) : pr5 = Val(table(15)) : pr6 = Val(table(16)) : pr7 = Val(table(17)) : pr8 = Val(table(18))
                    'pr9 = Val(table(19)) : pr10 = Val(table(20))




                    T01.Points.AddXY(heures, t1)
                    T02.Points.AddXY(heures, t2)
                    T03.Points.AddXY(heures, t3)
                    T04.Points.AddXY(heures, t4)
                    T05.Points.AddXY(heures, t5)
                    T06.Points.AddXY(heures, t6)
                    T07.Points.AddXY(heures, t7)
                    T08.Points.AddXY(heures, t8)
                    T09.Points.AddXY(heures, t9)
                    T11.Points.AddXY(heures, t011)
                    T12.Points.AddXY(heures, t012)


                    Q01.Points.AddXY(heures, q1)
                    Q02.Points.AddXY(heures, q2)
                    Q03.Points.AddXY(heures, q3)

                    FL01.Points.AddXY(heures, fl1)
                    FL02.Points.AddXY(heures, fl2)
                    FL03.Points.AddXY(heures, fl3)
                    FL04.Points.AddXY(heures, fl4)
                    FL05.Points.AddXY(heures, fl5)


                    PR01.Points.AddXY(heures, pr1)
                    PR04.Points.AddXY(heures, pr4)
                    PR05.Points.AddXY(heures, pr5)
                    PR06.Points.AddXY(heures, pr6)
                    PR07.Points.AddXY(heures, pr7)
                    PR08.Points.AddXY(heures, pr8)
                    PR09.Points.AddXY(heures, pr9)
                    PR010.Points.AddXY(heures, pr10)


                    cpt = cpt + 1



                End If



            Loop Until ligne Is Nothing
            monStreamReader.Close()
        sw.Close()
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles sonde_conductivite.Enter

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        critere_recherche.Visible = True
        sonde_conductivite.Location = New Point(111, 369)
        sonde_conductivite.Visible = True

        sonde_temperature.Location = New Point(588, 513)
        sonde_temperature.Visible = False

        capteur_pression.Location = New Point(842, 552)
        capteur_pression.Visible = False

        capteur_debit.Location = New Point(1006, 545)
        capteur_debit.Visible = False

        capteur_pretraitement.Location = New Point(998, 571)
        capteur_pretraitement.Visible = False

        CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False : CheckBox5.Checked = False : CheckBox6.Checked = False
        CheckBox7.Checked = False : CheckBox8.Checked = False : CheckBox9.Checked = False : CheckBox10.Checked = False : CheckBox11.Checked = False : CheckBox12.Checked = False
        CheckBox13.Checked = False : CheckBox17.Checked = False : CheckBox18.Checked = False : CheckBox19.Checked = False : CheckBox20.Checked = False : CheckBox21.Checked = False
        CheckBox22.Checked = False : CheckBox23.Checked = False : CheckBox24.Checked = False : CheckBox25.Checked = False : CheckBox26.Checked = False : CheckBox27.Checked = False
        CheckBox35.Checked = False : CheckBox36.Checked = False : CheckBox37.Checked = False : CheckBox30.Checked = False : CheckBox31.Checked = False


        MaskedTextBox3.Text = "09:00"

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        critere_recherche.Visible = True
        sonde_temperature.Location = New Point(111, 369)
        sonde_temperature.Visible = True

        sonde_conductivite.Location = New Point(1152, 565)
        sonde_conductivite.Visible = False

        capteur_pression.Location = New Point(842, 552)
        capteur_pression.Visible = False

        capteur_debit.Location = New Point(1006, 545)
        capteur_debit.Visible = False

        capteur_pretraitement.Location = New Point(998, 571)
        capteur_pretraitement.Visible = False

        CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False : CheckBox5.Checked = False : CheckBox6.Checked = False
        CheckBox7.Checked = False : CheckBox8.Checked = False : CheckBox9.Checked = False : CheckBox10.Checked = False : CheckBox11.Checked = False : CheckBox12.Checked = False
        CheckBox13.Checked = False : CheckBox14.Checked = False : CheckBox15.Checked = False : CheckBox16.Checked = False
        CheckBox35.Checked = False : CheckBox36.Checked = False : CheckBox37.Checked = False : CheckBox30.Checked = False : CheckBox31.Checked = False

        MaskedTextBox3.Text = "09:00"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        critere_recherche.Visible = True
        capteur_debit.Location = New Point(111, 369)
        capteur_debit.Visible = True

        sonde_temperature.Location = New Point(588, 513)
        sonde_temperature.Visible = False

        sonde_conductivite.Location = New Point(1152, 565)
        sonde_conductivite.Visible = False

        capteur_pression.Location = New Point(842, 552)
        capteur_pression.Visible = False

        capteur_pretraitement.Location = New Point(998, 571)
        capteur_pretraitement.Visible = False

        CheckBox14.Checked = False : CheckBox15.Checked = False : CheckBox16.Checked = False : CheckBox6.Checked = False
        CheckBox7.Checked = False : CheckBox8.Checked = False : CheckBox9.Checked = False : CheckBox10.Checked = False : CheckBox11.Checked = False : CheckBox12.Checked = False
        CheckBox13.Checked = False : CheckBox17.Checked = False : CheckBox18.Checked = False : CheckBox19.Checked = False : CheckBox20.Checked = False : CheckBox21.Checked = False
        CheckBox22.Checked = False : CheckBox23.Checked = False : CheckBox24.Checked = False : CheckBox25.Checked = False : CheckBox26.Checked = False : CheckBox27.Checked = False
        CheckBox35.Checked = False : CheckBox36.Checked = False : CheckBox37.Checked = False : CheckBox30.Checked = False : CheckBox31.Checked = False

        MaskedTextBox3.Text = "09:00"
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        critere_recherche.Visible = True
        capteur_pression.Location = New Point(111, 369)
        capteur_pression.Visible = True

        capteur_debit.Location = New Point(1006, 552)
        capteur_debit.Visible = False

        sonde_temperature.Location = New Point(588, 513)
        sonde_temperature.Visible = False

        sonde_conductivite.Location = New Point(1152, 565)
        sonde_conductivite.Visible = False

        capteur_pretraitement.Location = New Point(998, 571)
        capteur_pretraitement.Visible = False

        CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False : CheckBox5.Checked = False : CheckBox14.Checked = False
        CheckBox15.Checked = False : CheckBox16.Checked = False
        CheckBox17.Checked = False : CheckBox18.Checked = False : CheckBox19.Checked = False : CheckBox20.Checked = False : CheckBox21.Checked = False
        CheckBox22.Checked = False : CheckBox23.Checked = False : CheckBox24.Checked = False : CheckBox25.Checked = False : CheckBox26.Checked = False : CheckBox27.Checked = False
        CheckBox35.Checked = False : CheckBox36.Checked = False : CheckBox37.Checked = False : CheckBox30.Checked = False : CheckBox31.Checked = False

        MaskedTextBox3.Text = "09:00"
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged


        critere_recherche.Visible = True
        capteur_pretraitement.Location = New Point(111, 369)
        capteur_pretraitement.Visible = True

        capteur_debit.Location = New Point(1006, 552)
        capteur_debit.Visible = False

        sonde_temperature.Location = New Point(588, 513)
        sonde_temperature.Visible = False

        sonde_conductivite.Location = New Point(1152, 565)
        sonde_conductivite.Visible = False

        capteur_pression.Location = New Point(842, 552)
        capteur_pression.Visible = False

        CheckBox14.Checked = False
        CheckBox15.Checked = False : CheckBox16.Checked = False

        CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False : CheckBox5.Checked = False : CheckBox6.Checked = False
        CheckBox7.Checked = False : CheckBox8.Checked = False : CheckBox9.Checked = False : CheckBox10.Checked = False : CheckBox11.Checked = False : CheckBox12.Checked = False
        CheckBox13.Checked = False : CheckBox17.Checked = False : CheckBox18.Checked = False : CheckBox19.Checked = False : CheckBox20.Checked = False : CheckBox21.Checked = False
        CheckBox22.Checked = False : CheckBox23.Checked = False : CheckBox24.Checked = False : CheckBox25.Checked = False : CheckBox26.Checked = False : CheckBox27.Checked = False
        MaskedTextBox3.Text = "09:00"
    End Sub







    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RadioButton6.Visible = False
        eco_vanne = 0

        Chart1.ChartAreas(0).Area3DStyle.Enable3D = False

        Q01.IsValueShownAsLabel = False
        Q02.IsValueShownAsLabel = False
        Q03.IsValueShownAsLabel = False

        PR01.IsValueShownAsLabel = False
        PR04.IsValueShownAsLabel = False
        PR05.IsValueShownAsLabel = False
        PR06.IsValueShownAsLabel = False
        PR07.IsValueShownAsLabel = False
        PR09.IsValueShownAsLabel = False
        PR010.IsValueShownAsLabel = False


        T01.IsValueShownAsLabel = False
        T04.IsValueShownAsLabel = False
        T05.IsValueShownAsLabel = False
        T06.IsValueShownAsLabel = False
        T07.IsValueShownAsLabel = False
        T09.IsValueShownAsLabel = False
        T02.IsValueShownAsLabel = False
        T03.IsValueShownAsLabel = False
        T08.IsValueShownAsLabel = False
        T11.IsValueShownAsLabel = False

        T12.IsValueShownAsLabel = False


        FL01.IsValueShownAsLabel = False
        FL02.IsValueShownAsLabel = False
        FL03.IsValueShownAsLabel = False
        FL05.IsValueShownAsLabel = False

        T030.IsValueShownAsLabel = False
        Q030.IsValueShownAsLabel = False
        COL01.IsValueShownAsLabel = False
        COL02.IsValueShownAsLabel = False
        COL03.IsValueShownAsLabel = False

        V09.IsValueShownAsLabel = False


        GroupBox2.Visible = False
        Me.Cursor = Cursors.WaitCursor
        Button4.Visible = False
        Chart1.Series.Clear()
        Q01.Points.Clear()
        Q02.Points.Clear()
        Q03.Points.Clear()

        PR01.Points.Clear()
        PR04.Points.Clear()
        PR05.Points.Clear()
        PR06.Points.Clear()
        PR07.Points.Clear()
        PR08.Points.Clear()
        PR09.Points.Clear()
        PR010.Points.Clear()

        T01.Points.Clear()
        T04.Points.Clear()
        T05.Points.Clear()
        T06.Points.Clear()
        T07.Points.Clear()
        T08.Points.Clear()
        T09.Points.Clear()
        T02.Points.Clear()
        T03.Points.Clear()
        T11.Points.Clear()
        T12.Points.Clear()

        FL01.Points.Clear()
        FL02.Points.Clear()
        FL03.Points.Clear()
        FL04.Points.Clear()
        FL05.Points.Clear()

        T030.Points.Clear()
        Q030.Points.Clear()
        COL01.Points.Clear()
        COL02.Points.Clear()
        COL03.Points.Clear()

        V09.Points.Clear()





        ' Chart1.ChartAreas.Clear()
        On Error Resume Next
        If RadioButton6.Checked = True Then
            CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False : CheckBox5.Checked = False : CheckBox6.Checked = False
            CheckBox7.Checked = False : CheckBox8.Checked = False : CheckBox9.Checked = False : CheckBox10.Checked = False : CheckBox11.Checked = False : CheckBox12.Checked = False
            CheckBox13.Checked = False : CheckBox14.Checked = False : CheckBox15.Checked = False : CheckBox16.Checked = False
            CheckBox17.Checked = False : CheckBox18.Checked = False : CheckBox19.Checked = False : CheckBox20.Checked = False : CheckBox21.Checked = False
            CheckBox22.Checked = False : CheckBox23.Checked = False : CheckBox24.Checked = False : CheckBox25.Checked = False : CheckBox26.Checked = False : CheckBox27.Checked = False
            CheckBox30.Checked = False : CheckBox31.Checked = False : CheckBox35.Checked = False : CheckBox36.Checked = False
            CheckBox37.Checked = False


            V09.ChartType = SeriesChartType.Pie ' Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
            V09.Name = "V09"
            Chart1.Series.Add(V09)

            V09.BorderWidth = 2
        End If


        If CheckBox17.Checked = True Then
            T01.ChartType = SeriesChartType.Spline
            T01.Name = "T01"
            Chart1.Series.Add(T01)
            T01.BorderWidth = 2
        End If
        If CheckBox18.Checked = True Then
            T02.ChartType = SeriesChartType.Spline
            T02.Name = "T02"
            Chart1.Series.Add(T02)
            T02.BorderWidth = 2
        End If
        If CheckBox19.Checked = True Then
            T03.ChartType = SeriesChartType.Spline
            T03.Name = "T03"
            Chart1.Series.Add(T03)
            T03.BorderWidth = 2
        End If
        If CheckBox20.Checked = True Then
            T04.ChartType = SeriesChartType.Spline
            T04.Name = "T04"
            Chart1.Series.Add(T04)
            T04.BorderWidth = 2
        End If
        If CheckBox21.Checked = True Then
            T05.ChartType = SeriesChartType.Spline
            T05.Name = "T05"
            Chart1.Series.Add(T05)
            T05.BorderWidth = 2
        End If
        If CheckBox22.Checked = True Then
            T06.ChartType = SeriesChartType.Spline
            T06.Name = "T06"
            Chart1.Series.Add(T06)
            T06.BorderWidth = 2
        End If
        If CheckBox23.Checked = True Then
            T07.ChartType = SeriesChartType.Spline
            T07.Name = "T07"
            Chart1.Series.Add(T07)
            T07.BorderWidth = 2
        End If
        If CheckBox24.Checked = True Then
            T08.ChartType = SeriesChartType.Spline
            T08.Name = "T08"
            Chart1.Series.Add(T08)
            T08.BorderWidth = 2
        End If
        If CheckBox25.Checked = True Then
            T09.ChartType = SeriesChartType.Spline
            T09.Name = "T09"
            Chart1.Series.Add(T09)
            T09.BorderWidth = 2
        End If
        If CheckBox26.Checked = True Then
            T11.ChartType = SeriesChartType.Spline
            T11.Name = "T11"
            Chart1.Series.Add(T11)
            T11.BorderWidth = 2
        End If
        If CheckBox27.Checked = True Then
            T12.ChartType = SeriesChartType.Spline
            T12.Name = "T12"
            Chart1.Series.Add(T12)
            T12.BorderWidth = 2
        End If



        If CheckBox14.Checked = True Then
            Q01.ChartType = SeriesChartType.Spline
            Q01.Name = "Q01"
            Chart1.Series.Add(Q01)
            Q01.BorderWidth = 2
        End If
        If CheckBox15.Checked = True Then
            Q02.ChartType = SeriesChartType.Spline
            Q02.Name = "Q02"

            Chart1.Series.Add(Q02)
            Q02.BorderWidth = 2
        End If
        If CheckBox16.Checked = True Then
            Q03.ChartType = SeriesChartType.Spline
            Q03.Name = "Q03"
            Chart1.Series.Add(Q03)
            Q03.BorderWidth = 2
        End If






        If CheckBox1.Checked = True Then
            FL01.ChartType = SeriesChartType.Spline
            FL01.Name = "FL01"
            Chart1.Series.Add(FL01)
            FL01.BorderWidth = 2
        End If
        If CheckBox2.Checked = True Then
            FL02.ChartType = SeriesChartType.Spline
            FL02.Name = "FL02"
            Chart1.Series.Add(FL02)
            FL02.BorderWidth = 2
        End If
        If CheckBox3.Checked = True Then
            FL03.ChartType = SeriesChartType.Spline
            FL03.Name = "FL03"
            Chart1.Series.Add(FL03)
            FL03.BorderWidth = 2
        End If
        If CheckBox4.Checked = True Then
            FL04.ChartType = SeriesChartType.Spline
            FL04.Name = "FL04"
            Chart1.Series.Add(FL04)
            FL04.BorderWidth = 2
        End If
        If CheckBox5.Checked = True Then
            FL05.ChartType = SeriesChartType.Spline
            FL05.Name = "FL05"
            Chart1.Series.Add(FL05)
            FL05.BorderWidth = 2
        End If



        If CheckBox6.Checked = True Then
            PR01.ChartType = SeriesChartType.Spline
            PR01.Name = "PR01"
            Chart1.Series.Add(PR01)
            PR01.BorderWidth = 2
        End If
        If CheckBox7.Checked = True Then
            PR04.ChartType = SeriesChartType.Spline
            PR04.Name = "PR04"
            Chart1.Series.Add(PR04)
            PR04.BorderWidth = 2
        End If
        If CheckBox8.Checked = True Then
            PR05.ChartType = SeriesChartType.Spline
            PR05.Name = "PR05"
            Chart1.Series.Add(PR05)
            PR05.BorderWidth = 2
        End If
        If CheckBox9.Checked = True Then
            PR06.ChartType = SeriesChartType.Spline
            PR06.Name = "PR06"
            Chart1.Series.Add(PR06)
            PR06.BorderWidth = 2
        End If
        If CheckBox10.Checked = True Then
            PR07.ChartType = SeriesChartType.Spline
            PR07.Name = "PR07"
            Chart1.Series.Add(PR07)
            PR07.BorderWidth = 2
        End If
        If CheckBox11.Checked = True Then
            PR08.ChartType = SeriesChartType.Spline
            PR08.Name = "PR08"
            Chart1.Series.Add(PR08)
            PR08.BorderWidth = 2
        End If
        If CheckBox12.Checked = True Then
            PR09.ChartType = SeriesChartType.Spline
            PR09.Name = "PR09"
            Chart1.Series.Add(PR09)
            PR09.BorderWidth = 2
        End If
        If CheckBox13.Checked = True Then
            PR010.ChartType = SeriesChartType.Spline
            PR010.Name = "PR10"
            Chart1.Series.Add(PR010)
            PR010.BorderWidth = 2
        End If


        If CheckBox30.Checked = True Then
            T030.ChartType = SeriesChartType.Spline
            T030.Name = "T30"
            Chart1.Series.Add(T030)
            T030.BorderWidth = 2
        End If
        If CheckBox31.Checked = True Then
            Q030.ChartType = SeriesChartType.Spline
            Q030.Name = "Q30"
            Chart1.Series.Add(Q030)
            Q030.BorderWidth = 2
        End If
        If CheckBox35.Checked = True Then

            COL01.ChartType = SeriesChartType.Spline
            COL01.Name = lang(34)    '"Indice colmatage 1er étage" ' COLMATAGE 1ER ETAGE"
            Chart1.Series.Add(COL01)
            COL01.BorderWidth = 2

        End If
        If CheckBox37.Checked = True Then
            COL02.ChartType = SeriesChartType.Spline
            COL02.Name = lang(35)             '"Indice colmatage 2eme étage"
            Chart1.Series.Add(COL02)
            COL02.BorderWidth = 2

        End If
        If CheckBox36.Checked = True Then
            COL03.ChartType = SeriesChartType.Spline
            COL03.Name = lang(36)             '"Indice colmatage 3eme étage"
            Chart1.Series.Add(COL03)
            COL03.BorderWidth = 2


        End If



        Dim saut = 0
        Dim Test_date
        '------------------------------------------------------------------------------------------------------
        '                                        recherche sur un jour
        '------------------------------------------------------------------------------------------------------
        Dim t
        If CheckBox28.Checked = True Then
            If Format(CDate(Today), "yyyyMMdd") = Format(CDate(DateTimePicker1.Value), "yyyyMMdd") And (MaskedTextBox4.Text > Format(Now, "HH:mm")) Then MaskedTextBox4.Text = Format(Now, "HH:mm")


            Test_date = Format(CDate(DateTimePicker1.Value), "yyyyMMdd") 'Format(CDate(MaskedTextBox1.Text), "yyyyMMdd")
            If RadioButton1.Checked = True Then Courbe_Conductivite(Test_date)
            If RadioButton2.Checked = True Then Courbe_Temperature(Test_date)
            If RadioButton3.Checked = True Then Courbe_Debit(Test_date)
            If RadioButton4.Checked = True Then Courbe_Pression(Test_date)
            If RadioButton5.Checked = True Then Courbe_Pretraitement(Test_date)
            If RadioButton6.Checked = True Then Courbe_Consommation(Test_date)
        Else
            '------------------------------------------------------------------------------------------------------
            '                                        recherche sur plusieurs jours
            '------------------------------------------------------------------------------------------------------


            Dim recherche_date_debut = Format(CDate(DateTimePicker1.Value), "yyyyMMdd") 'Format(CDate(MaskedTextBox1.Text), "yyyyMMdd")
            Dim recherche_date_fin = Format(CDate(DateTimePicker2.Value), "yyyyMMdd") 'Format(CDate(MaskedTextBox2.Text), "yyyyMMdd")
            If recherche_date_debut >= recherche_date_fin Then recherche_date_debut = recherche_date_fin - 2
            If (recherche_date_fin - recherche_date_debut) < 10000 Then saut = 1
            If (recherche_date_fin - recherche_date_debut) > 10000 Then saut = 10


            If RadioButton1.Checked = True Then Courbe_Conduc_Date(recherche_date_debut, recherche_date_fin, saut)
            If RadioButton2.Checked = True Then Courbe_Temp_Date(recherche_date_debut, recherche_date_fin, saut)
            If RadioButton3.Checked = True Then Courbe_Debit_Date(recherche_date_debut, recherche_date_fin, saut)
            If RadioButton4.Checked = True Then Courbe_Press_Date(recherche_date_debut, recherche_date_fin, saut)
            If RadioButton5.Checked = True Then Courbe_Pretraitement(recherche_date_debut, recherche_date_fin, saut)
        End If

        Me.Cursor = Cursors.Default
        Button4.Visible = True
    End Sub
    Private Sub Courbe_Pretraitement(recherche_date_debut, recherche_date_fin, saut)
        ' Chart1.Series.Remove(TrendLine)
        ' Chart1.Series.Remove(TrendLine1)
        Dim TrendLine As New System.Windows.Forms.DataVisualization.Charting.Series("TrendLine")
        Dim TrendLine1 As New System.Windows.Forms.DataVisualization.Charting.Series("TrendLine1")
        Dim TrendLine2 As New System.Windows.Forms.DataVisualization.Charting.Series("TrendLine2")

        TrendLine.Points.Clear()
        TrendLine1.Points.Clear()
        TrendLine2.Points.Clear()

        Chart1.ChartAreas(0).AxisX.Title = lang(20)                                 ' "Dates "
        Chart1.ChartAreas(0).AxisY.Title = lang(26) + "  bars"                 '"Pressions   bars"
        If CheckBox30.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(21) + "  °c"
        If CheckBox31.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(25) + " µs / cm"
        If CheckBox35.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(26) + " bars"
        If CheckBox36.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(26) + " bars"
        If CheckBox37.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = lang(26) + " bars"

        If CheckBox30.Checked = True And CheckBox31.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox30.Checked = True And CheckBox35.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox30.Checked = True And CheckBox36.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox30.Checked = True And CheckBox37.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox31.Checked = True And CheckBox35.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox31.Checked = True And CheckBox36.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""
        If CheckBox31.Checked = True And CheckBox37.Checked = True Then Chart1.ChartAreas(0).AxisY.Title = ""


        If CheckBox30.Checked = True Or CheckBox31.Checked = True Then
            CheckBox35.Checked = False
            CheckBox36.Checked = False
            CheckBox37.Checked = False
        End If

        If CheckBox35.Checked = True Or CheckBox36.Checked = True Or CheckBox37.Checked = True Then
            CheckBox30.Checked = False
            CheckBox31.Checked = False
        End If


        Chart1.Palette = ChartColorPalette.Pastel






        '  Dim typeRegression As String = "Linear"
        ' Dim forecasting As String = "1"
        '  Dim ErrorBoolean As String = "false"
        '  Dim forecastingError As String = "false"
        '  Dim parameters As String = Convert.ToString((Convert.ToString((Convert.ToString(typeRegression & Convert.ToString(","c)) & forecasting) & ","c) & ErrorBoolean) & ","c) & forecastingError


        On Error Resume Next
        Dim foc$ 'chemin fichier
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; T30; Q30; PE1; PS1; PE2; PS2; PE3; PS3"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)

        'Dim P1 As New DataPoint
        'Dim P2 As New DataPoint
        'Dim P3 As New DataPoint
        'Dim P4 As New DataPoint
        'Dim P5 As New DataPoint
        ' Dim P6 As New DataPoint




        Dim t30, q30, col1, col2, col3

        Dim test_date1
        Dim temps
        Dim PRESSION01
        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim table()
        Dim compteur
        Dim nom_titre As String
        If recherche_date_debut >= recherche_date_fin Then recherche_date_debut = recherche_date_fin - 2
        temps = DateTimePicker1.Value

        Do While recherche_date_debut < recherche_date_fin

            foc$ = "C:\H2observer\data\rclog_" + recherche_date_debut + Ext_Ver + ".csv"
            compteur = 0


            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes  And (fl > 500)
            Do
                ligne = monStreamReader.ReadLine()
                If ligne = "" Then Exit Do
                table = Split(ligne, ";")
                compteur = compteur + 1
                heures = table(1)
                'flow = Val(table(42))
                PRESSION01 = Val(Replace(table(14), ",", "."))
                If (compteur >= 2) And (MaskedTextBox3.Text >= Mid(heures, 1, 5)) And (table(7) = lang(24)) And (PRESSION01 <= SeuilPR01) Then

                    datte = table(0)
                    nom_titre = table(6)
                    t30 = Val(Replace(table(44), ",", "."))
                    q30 = Val(Replace(table(43), ",", "."))
                    col1 = Math.Abs(Val(Replace(table(49), ",", ".")) - Val(Replace(table(50), ",", ".")))
                    col2 = Math.Abs(Val(Replace(table(51), ",", ".")) - Val(Replace(table(52), ",", ".")))
                    col3 = Math.Abs(Val(Replace(table(53), ",", ".")) - Val(Replace(table(54), ",", ".")))


                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(44) + ";" + table(43) + ";" + table(49) + ";" + +table(50) + ";" + table(51) + ";" + table(52) + ";" + table(53) + ";" + table(54)
                        sw.WriteLine(chaines)
                    End If
                    'pr1 = Val(table(14)) : pr4 = Val(table(21)) : pr5 = Val(table(15)) : pr6 = Val(table(16)) : pr7 = Val(table(17)) : pr8 = Val(table(18))
                    ' pr9 = Val(table(19)) : pr10 = Val(table(20))

                    T030.Points.AddXY(table(0), t30)
                    Q030.Points.AddXY(table(0), q30)

                    COL01.Points.AddXY(CDate(table(0)), col1)
                    COL02.Points.AddXY(CDate(table(0)), col2)
                    COL03.Points.AddXY(CDate(table(0)), col3)

                    Exit Do
                End If

            Loop Until ligne Is Nothing
            monStreamReader.Close()

            Dim depart = DateAdd("d", saut, DateTimePicker1.Value)
            DateTimePicker1.Value = depart
            recherche_date_debut = Format(CDate(DateTimePicker1.Value), "yyyyMMdd")
        Loop
        If CheckBox35.Checked = True Then
            Chart1.Series.Add(TrendLine)
            Chart1.Series("TrendLine").ChartType = SeriesChartType.Line
            Chart1.Series("TrendLine").BorderWidth = 3
            Chart1.Series("TrendLine").Color = Color.Red
            Chart1.Series("TrendLine").IsVisibleInLegend = False
            Chart1.Series(lang(34)).Sort(PointSortOrder.Ascending, "X")
            Chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", Chart1.Series(lang(34)), Chart1.Series("TrendLine"))

        End If
        If CheckBox37.Checked = True Then

            Chart1.Series.Add(TrendLine1)
            Chart1.Series("TrendLine1").ChartType = SeriesChartType.Line
            Chart1.Series("TrendLine1").BorderWidth = 3
            Chart1.Series("TrendLine1").Color = Color.OrangeRed
            Chart1.Series("TrendLine1").IsVisibleInLegend = False
            Chart1.Series("Indice colmatage 2eme étage").Sort(PointSortOrder.Ascending, "X")
            Chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", Chart1.Series(lang(35)), Chart1.Series("TrendLine1"))

        End If
        If CheckBox36.Checked = True Then
            Chart1.Series.Add(TrendLine2)
            Chart1.Series("TrendLine2").ChartType = SeriesChartType.Line
            Chart1.Series("TrendLine2").BorderWidth = 3
            Chart1.Series("TrendLine2").Color = Color.Orange
            Chart1.Series("TrendLine2").IsVisibleInLegend = False

            Chart1.Series("Indice colmatage 3eme étage").Sort(PointSortOrder.Ascending, "X")
            Chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", Chart1.Series(lang(36)), Chart1.Series("TrendLine2"))
        End If
        DateTimePicker1.Value = temps
        sw.Close()


    End Sub
    Private Sub Courbe_Press_Date(recherche_date_debut, recherche_date_fin, saut)
        Chart1.ChartAreas(0).AxisX.Title = lang(23)                                     '"Dates "
        Chart1.ChartAreas(0).AxisY.Title = lang(26) + "  bars"                  ' "Pressions   bars"
        Chart1.Palette = ChartColorPalette.Pastel

        Dim foc$ 'chemin fichier
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; PR01; PR04; PR05; PR06; PR07; PR08; PR09; PR010"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
        Dim pr1, pr4, pr5, pr6, pr7, pr8, pr9, pr10

        Dim test_date1
        Dim temps

        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim table()
        Dim compteur
        Dim nom_titre As String
        If recherche_date_debut >= recherche_date_fin Then recherche_date_debut = recherche_date_fin - 2
        temps = DateTimePicker1.Value

        Do While recherche_date_debut < recherche_date_fin
            On Error Resume Next
            foc$ = "C:\H2observer\data\rclog_" + recherche_date_debut + Ext_Ver + ".csv"
            compteur = 0

            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes 
            Do
                ligne = monStreamReader.ReadLine()
                If ligne = "" Then Exit Do
                table = Split(ligne, ";")
                compteur = compteur + 1
                heures = table(1)

                If (compteur >= 2) And (MaskedTextBox3.Text >= Mid(heures, 1, 5)) And (table(7) = lang(24)) Then

                    datte = table(0)
                    nom_titre = table(6)
                    pr1 = Val(Replace(table(14), ",", "."))
                    pr4 = Val(Replace(table(21), ",", "."))
                    pr5 = Val(Replace(table(15), ",", "."))
                    pr6 = Val(Replace(table(16), ",", "."))
                    pr7 = Val(Replace(table(17), ",", "."))
                    pr8 = Val(Replace(table(18), ",", "."))
                    pr9 = Val(Replace(table(19), ",", "."))
                    pr10 = Val(Replace(table(20), ",", "."))


                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(14) + ";" + table(21) + ";" + table(15) + ";" + table(16) + ";" + table(17) + ";" + table(18) + ";" + table(19) + ";" + table(20)
                        sw.WriteLine(chaines)
                    End If
                    'pr1 = Val(table(14)) : pr4 = Val(table(21)) : pr5 = Val(table(15)) : pr6 = Val(table(16)) : pr7 = Val(table(17)) : pr8 = Val(table(18))
                    ' pr9 = Val(table(19)) : pr10 = Val(table(20))

                    PR01.Points.AddXY(table(0), pr1)
                    PR04.Points.AddXY(table(0), pr4)
                    PR05.Points.AddXY(table(0), pr5)
                    PR06.Points.AddXY(table(0), pr6)
                    PR07.Points.AddXY(table(0), pr7)
                    PR08.Points.AddXY(table(0), pr8)
                    PR09.Points.AddXY(table(0), pr9)
                    PR010.Points.AddXY(table(0), pr10)
                    Exit Do
                End If

            Loop Until ligne Is Nothing
            monStreamReader.Close()
            Dim depart = DateAdd("d", saut, DateTimePicker1.Value)
            DateTimePicker1.Value = depart
            recherche_date_debut = Format(CDate(DateTimePicker1.Value), "yyyyMMdd")
        Loop

        DateTimePicker1.Value = temps
        sw.Close()

    End Sub
    Private Sub Courbe_Debit_Date(recherche_date_debut, recherche_date_fin, saut)
        Chart1.ChartAreas(0).AxisX.Title = lang(20)                                          ' "Dates"
        Chart1.ChartAreas(0).AxisY.Title = lang(27) + " l / h"                              '"Débits   l / h"
        Chart1.Palette = ChartColorPalette.Pastel
        On Error Resume Next
        Dim foc$ 'chemin fichier
        Dim chaines
        If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
        chaines = lang(22) + ";" + lang(23) + "; FL01; FL02; FL03; FL04; FL05"
        Dim sw As System.IO.StreamWriter
        sw = My.Computer.FileSystem.OpenTextFileWriter("C:\H2observer\Photo\data.csv", True)
        If CheckBox29.Checked = True Then sw.WriteLine(chaines)
        Dim fl1, fl2, fl3, fl4, fl5

            Dim test_date1

            Dim temps

            Dim datte, fonctionnement, desinfection_thermique, heures, etape
            Dim table()
            Dim compteur
            Dim nom_titre As String
            If recherche_date_debut >= recherche_date_fin Then recherche_date_debut = recherche_date_fin - 2

            temps = DateTimePicker1.Value

            Do While recherche_date_debut < recherche_date_fin

            foc$ = "C:\H2observer\data\rclog_" + recherche_date_debut + Ext_Ver + ".csv"
            compteur = 0

                Dim monStreamReader As StreamReader = New StreamReader(foc$)
                Dim ligne As String

                'Lecture de toutes les lignes 
                Do
                    ligne = monStreamReader.ReadLine()
                    If ligne = "" Then Exit Do
                    table = Split(ligne, ";")
                    compteur = compteur + 1
                    heures = table(1)

                If (compteur >= 2) And (MaskedTextBox3.Text >= Mid(heures, 1, 5)) And (table(7) = lang(24)) Then

                    datte = table(0)
                    nom_titre = table(6)
                    fl1 = Val(Replace(table(8), ",", "."))
                    fl2 = Val(Replace(table(9), ",", "."))
                    fl3 = Val(Replace(table(11), ",", "."))
                    fl4 = Val(Replace(table(12), ",", "."))
                    fl5 = Val(Replace(table(13), ",", "."))

                    If CheckBox29.Checked = True Then
                        chaines = table(0) + ";" + table(1) + ";" + table(8) + ";" + table(9) + ";" + table(11) + ";" + table(12) + ";" + table(13)
                        sw.WriteLine(chaines)
                    End If
                    'fl1 = Val(table(8)) : fl2 = Val(table(9)) : fl3 = Val(table(11))
                    ' fl4 = Val(table(12)) : fl5 = Val(table(13))

                    FL01.Points.AddXY(table(0), fl1)
                    FL02.Points.AddXY(table(0), fl2)
                    FL03.Points.AddXY(table(0), fl3)
                    FL04.Points.AddXY(table(0), fl4)
                    FL05.Points.AddXY(table(0), fl5)
                    Exit Do
                End If

            Loop Until ligne Is Nothing
                monStreamReader.Close()
                Dim depart = DateAdd("d", saut, DateTimePicker1.Value)
                DateTimePicker1.Value = depart
                recherche_date_debut = Format(CDate(DateTimePicker1.Value), "yyyyMMdd")
            Loop

            DateTimePicker1.Value = temps

        sw.Close()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' capteur_pretraitement.SendToBack()


        If GroupBox2.Visible = True Then GroupBox2.Visible = False Else GroupBox2.Visible = True



        ComboBox2.Items.Clear()
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim i As Integer
        Dim tableau_conf1()

        i = 13
        '-----------------------------------------------------------------------
        '------------- chargement config 1 pour récupérer destinataire et centre
        '-----------------------------------------------------------------------

        Try
            Dim sr3 As StreamReader = New StreamReader(fil1) 'FileOpen(1, (fil1), OpenMode.Input)


            tableau_conf1 = Split(sr3.ReadLine(), ";")


            For i = 13 To 22
                If tableau_conf1(i) <> "" Then
                    ComboBox2.Items.Add(tableau_conf1(i))
                    ComboBox2.SelectedIndex = 0
                End If
            Next
            sr3.Close()

        Catch ex As Exception

            Dim erreur = " : Dans le module Recherche.button3_click() ligne 1254 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
        Chart1.Titles.Clear()
        ' If titres_graph = True Then
        Chart1.Titles.Add(tableau_conf1(0) + "        " + Num_série)
        'titres_graph = False
        ' End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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



    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

        Dim nbre_point

        '
        '    viosualisation des points sur la courbe
        '
        nbre_point = Q01.Points.Count
        If nbre_point < 60 Then Q01.IsValueShownAsLabel = True Else Q01.IsValueShownAsLabel = False
        nbre_point = Q02.Points.Count
        If nbre_point < 60 Then Q02.IsValueShownAsLabel = True Else Q02.IsValueShownAsLabel = False
        nbre_point = Q03.Points.Count
        If nbre_point < 60 Then Q03.IsValueShownAsLabel = True Else Q03.IsValueShownAsLabel = False

        nbre_point = PR01.Points.Count
        If nbre_point < 60 Then PR01.IsValueShownAsLabel = True Else PR01.IsValueShownAsLabel = False
        nbre_point = PR04.Points.Count
        If nbre_point < 60 Then PR04.IsValueShownAsLabel = True Else PR04.IsValueShownAsLabel = False
        nbre_point = PR05.Points.Count
        If nbre_point < 60 Then PR05.IsValueShownAsLabel = True Else PR05.IsValueShownAsLabel = False
        nbre_point = PR06.Points.Count
        If nbre_point < 60 Then PR06.IsValueShownAsLabel = True Else PR06.IsValueShownAsLabel = False
        nbre_point = PR07.Points.Count
        If nbre_point < 60 Then PR07.IsValueShownAsLabel = True Else PR07.IsValueShownAsLabel = False
        nbre_point = PR09.Points.Count
        If nbre_point < 60 Then PR09.IsValueShownAsLabel = True Else PR09.IsValueShownAsLabel = False
        nbre_point = PR010.Points.Count
        If nbre_point < 60 Then PR010.IsValueShownAsLabel = True Else PR010.IsValueShownAsLabel = False


        nbre_point = T01.Points.Count
        If nbre_point < 60 Then T01.IsValueShownAsLabel = True Else T01.IsValueShownAsLabel = False
        nbre_point = T04.Points.Count
        If nbre_point < 60 Then T04.IsValueShownAsLabel = True Else T04.IsValueShownAsLabel = False
        nbre_point = T05.Points.Count
        If nbre_point < 60 Then T05.IsValueShownAsLabel = True Else T05.IsValueShownAsLabel = False
        nbre_point = T06.Points.Count
        If nbre_point < 60 Then T06.IsValueShownAsLabel = True Else T06.IsValueShownAsLabel = False
        nbre_point = T07.Points.Count
        If nbre_point < 60 Then T07.IsValueShownAsLabel = True Else T07.IsValueShownAsLabel = False
        nbre_point = T09.Points.Count
        If nbre_point < 60 Then T09.IsValueShownAsLabel = True Else T09.IsValueShownAsLabel = False
        nbre_point = T02.Points.Count
        If nbre_point < 60 Then T02.IsValueShownAsLabel = True Else T02.IsValueShownAsLabel = False
        nbre_point = T03.Points.Count
        If nbre_point < 60 Then T03.IsValueShownAsLabel = True Else T03.IsValueShownAsLabel = False
        nbre_point = T08.Points.Count
        If nbre_point < 60 Then T08.IsValueShownAsLabel = True Else T08.IsValueShownAsLabel = False
        nbre_point = T11.Points.Count
        If nbre_point < 60 Then T11.IsValueShownAsLabel = True Else T11.IsValueShownAsLabel = False
        nbre_point = T12.Points.Count
        If nbre_point < 60 Then T12.IsValueShownAsLabel = True Else T12.IsValueShownAsLabel = False


        nbre_point = FL01.Points.Count
        If nbre_point < 60 Then FL01.IsValueShownAsLabel = True Else FL01.IsValueShownAsLabel = False
        nbre_point = FL02.Points.Count
        If nbre_point < 60 Then FL02.IsValueShownAsLabel = True Else FL02.IsValueShownAsLabel = False
        nbre_point = FL03.Points.Count
        If nbre_point < 60 Then FL03.IsValueShownAsLabel = True Else FL03.IsValueShownAsLabel = False
        nbre_point = FL04.Points.Count
        If nbre_point < 60 Then FL04.IsValueShownAsLabel = True Else FL04.IsValueShownAsLabel = False
        nbre_point = FL05.Points.Count
        If nbre_point < 60 Then FL05.IsValueShownAsLabel = True Else FL05.IsValueShownAsLabel = False



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
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover

        Button1.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave

        Button1.FlatStyle = FlatStyle.Flat

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' On Error Resume Next
        Dim titre1 = lang(31)                                   '"Photo Courbe " '& nom_centre
        Dim Myemail = ComboBox2.SelectedItem

        GroupBox2.Visible = False

        Dim b As New Bitmap(Me.Width, Me.Height)
        Me.DrawToBitmap(b, New Rectangle(0, 0, Me.Width, Me.Height))

        b.Save("C:\H2observer\Photo\" + titre1 + ".png", Imaging.ImageFormat.Png)
        Envoie_courbe_email(Myemail, titre1)
        ' If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")


    End Sub

    Private Sub CheckBox29_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox29.CheckedChanged
        ' On Error Resume Next
        ' If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then My.Computer.FileSystem.DeleteFile("C:\H2observer\Photo\data.csv")
    End Sub

    Private Sub Chart1_DoubleClick(sender As Object, e As EventArgs) Handles Chart1.DoubleClick
        Q01.IsValueShownAsLabel = False
        Q02.IsValueShownAsLabel = False
        Q03.IsValueShownAsLabel = False

        PR01.IsValueShownAsLabel = False
        PR04.IsValueShownAsLabel = False
        PR05.IsValueShownAsLabel = False
        PR06.IsValueShownAsLabel = False
        PR07.IsValueShownAsLabel = False
        PR09.IsValueShownAsLabel = False
        PR010.IsValueShownAsLabel = False


        T01.IsValueShownAsLabel = False
        T04.IsValueShownAsLabel = False
        T05.IsValueShownAsLabel = False
        T06.IsValueShownAsLabel = False
        T07.IsValueShownAsLabel = False
        T09.IsValueShownAsLabel = False
        T02.IsValueShownAsLabel = False
        T03.IsValueShownAsLabel = False
        T08.IsValueShownAsLabel = False
        T11.IsValueShownAsLabel = False

        T12.IsValueShownAsLabel = False


        FL01.IsValueShownAsLabel = False
        FL02.IsValueShownAsLabel = False
        FL03.IsValueShownAsLabel = False
        FL05.IsValueShownAsLabel = False

    End Sub

    Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart1.MouseMove


    End Sub

    Private Sub Capteur_pression_Enter(sender As Object, e As EventArgs) Handles capteur_pression.Enter

    End Sub

    Private Sub MaskedTextBox3_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox3.MaskInputRejected

    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        CheckBox28.Checked = True
        critere_recherche.Visible = True

        capteur_pretraitement.Location = New Point(998, 571)
        capteur_pretraitement.Visible = False


        capteur_debit.Location = New Point(1006, 552)
        capteur_debit.Visible = False

        sonde_temperature.Location = New Point(588, 513)
        sonde_temperature.Visible = False

        sonde_conductivite.Location = New Point(1152, 565)
        sonde_conductivite.Visible = False

        capteur_pression.Location = New Point(842, 552)
        capteur_pression.Visible = False

        CheckBox14.Checked = False
        CheckBox15.Checked = False : CheckBox16.Checked = False

        CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False : CheckBox5.Checked = False : CheckBox6.Checked = False
        CheckBox7.Checked = False : CheckBox8.Checked = False : CheckBox9.Checked = False : CheckBox10.Checked = False : CheckBox11.Checked = False : CheckBox12.Checked = False
        CheckBox13.Checked = False : CheckBox17.Checked = False : CheckBox18.Checked = False : CheckBox19.Checked = False : CheckBox20.Checked = False : CheckBox21.Checked = False
        CheckBox22.Checked = False : CheckBox23.Checked = False : CheckBox24.Checked = False : CheckBox25.Checked = False : CheckBox26.Checked = False : CheckBox27.Checked = False
        MaskedTextBox3.Text = "09:00"
    End Sub

    Private Sub CheckBox35_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox35.CheckedChanged

        If CheckBox35.Checked = True Then
            CheckBox30.Checked = False
            CheckBox31.Checked = False
        End If

    End Sub
    Private Sub CheckBox36_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox36.CheckedChanged

        If CheckBox36.Checked = True Then
            CheckBox30.Checked = False
            CheckBox31.Checked = False
        End If

    End Sub
    Private Sub CheckBox37_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox37.CheckedChanged

        If CheckBox37.Checked = True Then
            CheckBox30.Checked = False
            CheckBox31.Checked = False
        End If

    End Sub
    Private Sub CheckBox30_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox30.CheckedChanged
        If CheckBox30.Checked = True Then
            CheckBox35.Checked = False
            CheckBox36.Checked = False
            CheckBox37.Checked = False
        End If

    End Sub
    Private Sub CheckBox31_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox31.CheckedChanged
        If CheckBox31.Checked = True Then
            CheckBox35.Checked = False
            CheckBox36.Checked = False
            CheckBox37.Checked = False
        End If

    End Sub

    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles RadioButton6.Click

    End Sub

    Private Sub GroupBox7_Click(sender As Object, e As EventArgs) Handles GroupBox7.Click
        eco_vanne = eco_vanne + 1
        If eco_vanne >= 10 Then RadioButton6.Visible = True
    End Sub
End Class