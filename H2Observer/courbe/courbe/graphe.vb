Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Public Class graphe


    Private Sub graphe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim foc$ 'chemin fichier
        Dim Test_date = Format(Today, "yyyyMMdd")
        foc$ = "C:/Users/juju/Downloads/HERCO/HERCO/Le Soler/rclog_" + Test_date + ".csv"


        Dim T04 As New Series
        Dim T03 As New Series
        T03.ChartType = SeriesChartType.Line
            T03.Name = "T03"
            Chart1.Series.Add(T03)
        T03.BorderWidth = 3

        T04.ChartType = SeriesChartType.Line
            T04.Name = "T04"
            Chart1.Series.Add(T04)
        T04.BorderWidth = 3
        Chart1.ChartAreas(0).AxisX.Title = "Heures de Desinfection"
        Chart1.ChartAreas(0).AxisY.Title = "Temperatures"
        Chart1.Palette = ChartColorPalette.Pastel

        Dim t3 = 0
        Dim t4 = 0
        Dim datte = ""
        Dim heures = ""

        Dim table() ': Dim table_serie()
        Dim cpt As Integer      'nbre enregistrements  total                                                               
        Dim cpt1 As Integer     'nbre enregistrement sup a 80 pour calcul A0
        Dim compteur As Integer 'nbre enregistrement sup a 80 pour calcul A0
        Dim pt_debut As Integer
        Dim pt_fin As Integer
        Dim heur_debut = ""
        Dim heur_fin = "" ', cp_debut, cp_fin

        Dim nom_titre = ""
debut:
        Try
            cpt = 0 : compteur = 0 : cpt1 = 0
            'foc$ = "C:/Users/juju/Downloads/dossier sans titre/AF16-008791-181006-0600.csv"
            'foc$ = "C:/Users/juju/Downloads/HERCO/HERCO/Le Soler/rclog_20180308.csv"
            'On Error Resume Next
            ' table_serie = Split(chaine1, ";")
            Dim monStreamReader As StreamReader = New StreamReader(foc$)
            Dim ligne As String

            'Lecture de toutes les lignes 
            Do
                ligne = monStreamReader.ReadLine()
                If ligne = "" Then GoTo sot
                table = Split(ligne, ";")
                If table(6) = "OI + boucle" Or table(6) = "boucle" Then
                    datte = table(0)
                    heures = table(1)
                    nom_titre = table(6)

                    t3 = Val(table(27))
                    t4 = Val(table(35))

                    If table(6) = "boucle" Then
                        T04.Points.AddXY(heures, t4)
                    Else
                        T03.Points.AddXY(heures, t3)
                        T04.Points.AddXY(heures, t4)
                    End If


                    cpt = cpt + 1
                    If cpt = 1 Then heur_debut = heures
                    '----------------------------------------------------------------------------------------------- calcul A0

                    If t3 >= 80 Then
                        pt_debut = 10 ^ ((t3 - 80) / 10) * 60
                        compteur = compteur + pt_debut
                    End If
                    If t4 >= 80 Then
                        pt_fin = 10 ^ ((t4 - 80) / 10) * 60
                        cpt1 = cpt1 + pt_fin
                    End If
                End If


sot:
            Loop Until ligne Is Nothing
            monStreamReader.Close()

        Catch ex As Exception

            Test_date = Val(Test_date) - 1
            Dim subString As String = Test_date.Substring(4)

            If Val(subString) < 101 Then Test_date = Test_date - 8869
            foc$ ="C:/Users/juju/Downloads/HERCO/HERCO/Le Soler/rclog_" + Test_date + ".csv"
            If Val(Test_date) < 20160101 Then
                MsgBox(ex.ToString)
                Exit Sub
            End If


            GoTo debut



        End Try

        heur_fin = heures
            Dim h1 = CDate(heur_debut)
        Dim h2 = CDate(heur_fin)
        Dim diff2 As String = (h2 - h1).ToString
        'Label1.Text = Format(diff2, "hh/mm/ss")
        '--------------------------------------------------------------------- annotation sur la courbe
        Dim MyAnnotation As New CalloutAnnotation()
        Dim MyAnnotation1 As New CalloutAnnotation()
        MyAnnotation.Font = New Font("Arial", 12, FontStyle.Bold)
        MyAnnotation1.Font = New Font("Arial", 12, FontStyle.Bold)
        Try

            If cpt1 > 10 Then
                MyAnnotation1.AnchorDataPoint = T04.Points(cpt - (cpt / 7)) '
                MyAnnotation1.Text = "Calcul sur la sonde T04  A0 = " + Str(cpt1) '"Annotation sur un Point du graph"255, 255, 128
                If cpt1 >= 12000 Then MyAnnotation1.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation1.BackColor = Color.FromArgb(255, 0, 0)

            End If


            If compteur > 10 Then
                MyAnnotation.AnchorDataPoint = T03.Points(cpt - (cpt / 7))
                MyAnnotation.Text = "Calcul sur la sonde T03  A0 = " + Str(compteur) '"Annotation sur un Point du graph"200
                If compteur >= 12000 Then MyAnnotation.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation.BackColor = Color.FromArgb(255, 0, 0)
                ' cp_fin = DateDiff(DateInterval.Hour, heur_fin, heur_debut)

            End If
            If (cpt1 < 10) And (compteur < 10) Then
                Test_date = Test_date - 1
                foc$ = "C:/Users/juju/Downloads/HERCO/HERCO/Le Soler/rclog_" + Test_date + ".csv"
                GoTo debut
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

        diff2 = diff2.Substring(0, 2) & "h" & diff2.Substring(2 + 1)

        If nom_titre = "OI + boucle" Then nom_titre = "Le " + datte + " Desinfection Thermique Osmoseur + Boucle Durée " + diff2 Else nom_titre = "Le " + datte + " Desinfection Thermique Boucle Durée " + diff2
        Chart1.Annotations.Add(MyAnnotation)
        Chart1.Annotations.Add(MyAnnotation1)
        Chart1.Titles.Add(nom_titre)
        Chart1.Titles(0).Font = New Font("Arial", 18, FontStyle.Bold)

        Dim b As New Bitmap(Me.Width, Me.Height)
        Me.DrawToBitmap(b, New Rectangle(0, 0, Me.Width, Me.Height))
        b.Save("C:/HERCO/testou.png", Imaging.ImageFormat.Png)
        courbe.envoie_emaile()
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class