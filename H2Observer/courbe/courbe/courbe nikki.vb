Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Public Class courbe1
    Private T01 As New Series : Dim T02 As New Series : Dim T03 As New Series : Dim T04 As New Series : Dim T05 As New Series : Dim T06 As New Series
    Private T07 As New Series : Dim T08 As New Series : Dim T09 As New Series : Dim T11 As New Series : Dim T12 As New Series
    Private chaine1





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t011, t012
        Dim datte, fonctionnement, desinfection_thermique, heures, etape
        Dim foc$ 'chemin fichier
        Dim table() : Dim table_serie()
        Dim cpt As Integer      'nbre enregistrements  total                                                               
        Dim cpt1 As Integer     'nbre enregistrement sup a 80 pour calcul A0
        Dim compteur As Integer 'nbre enregistrement sup a 80 pour calcul A0
        Dim pt_debut, pt_fin
        Dim heur_debut, heur_fin, cp_debut, cp_fin
        Dim popo
        Dim nom_titre As String

        cpt = 0 : compteur = 0 : cpt1 = 0
        'foc$ = "C:/Users/juju/Downloads/dossier sans titre/AF16-008791-181006-0600.csv"
        foc$ = "C:/Users/juju/Downloads/HERCO/HERCO/Le Soler/rclog_20180228.csv"
        On Error Resume Next
        table_serie = Split(chaine1, ";")
        Dim monStreamReader As StreamReader = New StreamReader(foc$)
        Dim ligne As String

        'Lecture de toutes les lignes 
        Do
            ligne = monStreamReader.ReadLine()
            table = Split(ligne, ";")
            If table(6) = "OI + boucle" Or table(6) = "boucle" Then
                datte = table(0)
                heures = table(1)
                nom_titre = table(6)

                t1 = Val(table(23)) : t2 = Val(table(25)) : t3 = Val(table(27)) : t011 = Val(table(28)) : t012 = Val(table(29)) : t5 = Val(table(30))
                t6 = Val(table(31)) : t7 = Val(table(32)) : t8 = Val(table(33)) : t9 = Val(table(34)) : t4 = Val(table(35))

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
                cpt = cpt + 1
                If cpt = 1 Then heur_debut = heures
                '
                ' calcul A0
                '

                If t3 >= 80 Then
                    pt_debut = 10 ^ ((t3 - 80) / 10) * 60
                    compteur = compteur + pt_debut
                End If
                If t4 >= 80 Then
                    pt_fin = 10 ^ ((t4 - 80) / 10) * 60
                    cpt1 = cpt1 + pt_fin
                End If


            End If



        Loop Until ligne Is Nothing
        monStreamReader.Close()
        heur_fin = heures
        popo = heur_fin - heur_debut
        '--------------------------------------------------------------------- annotation sur la courbet = t2.Subtract(t1)
        Dim MyAnnotation As New CalloutAnnotation()
        Dim MyAnnotation1 As New CalloutAnnotation()
        MyAnnotation.Font = New Font("Arial", 12, FontStyle.Bold)
        MyAnnotation1.Font = New Font("Arial", 12, FontStyle.Bold)


        If table_serie(3) = True Then
            MyAnnotation1.AnchorDataPoint = T04.Points(cpt - (cpt / 7)) '
            MyAnnotation1.Text = "Calcul sur T04 A0 : " + Str(cpt1) '"Annotation sur un Point du graph"255, 255, 128
            If cpt1 >= 12000 Then MyAnnotation1.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation1.BackColor = Color.FromArgb(255, 0, 0)

        End If


        If table_serie(2) = True Then
            MyAnnotation.AnchorDataPoint = T03.Points(cpt - (cpt / 7))
            MyAnnotation.Text = "Calcul sur T03 A0 : " + Str(compteur) '"Annotation sur un Point du graph"200
            If compteur >= 12000 Then MyAnnotation.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation.BackColor = Color.FromArgb(255, 0, 0)
            ' cp_fin = DateDiff(DateInterval.Hour, heur_fin, heur_debut)

        End If


        If nom_titre = "OI + boucle" Then nom_titre = "Desinfection Thermique Osmoseur + Boucle" Else nom_titre = "Desinfection Thermique Boucle"
        Chart1.Annotations.Add(MyAnnotation)
        Chart1.Annotations.Add(MyAnnotation1)
        Chart1.Titles.Add(nom_titre)
        Chart1.Titles(0).Font = New Font("Arial", 18, FontStyle.Bold)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                                                              
        '                                                                                                           ouverture fichier parametre pour choix temperature     
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                                                              
        Dim monStreamReader As StreamReader = New StreamReader("C:/HERCO/parametre.txt")
        Dim ligne As String
        Dim table_serie()

        Chart1.Series.Clear()

        Do
            ligne = monStreamReader.ReadLine()
            If ligne = "" Then GoTo saut
            chaine1 = ligne
            table_serie = Split(ligne, ";")
saut:
        Loop Until ligne Is Nothing
        monStreamReader.Close()


        If table_serie(0) = True Then
            T01.ChartType = SeriesChartType.Line
            T01.Name = "T01"
            Chart1.Series.Add(T01)
            T01.BorderWidth = 1
        End If
        If table_serie(1) = True Then
            T02.ChartType = SeriesChartType.Line
            T02.Name = "T02"
            Chart1.Series.Add(T02)
            T02.BorderWidth = 1
        End If
        If table_serie(2) = True Then
            T03.ChartType = SeriesChartType.Line
            T03.Name = "T03"
            Chart1.Series.Add(T03)
            T03.BorderWidth = 2
        End If
        If table_serie(3) = True Then
            T04.ChartType = SeriesChartType.Line
            T04.Name = "T04"
            Chart1.Series.Add(T04)
            T04.BorderWidth = 3
        End If
        If table_serie(4) = True Then
            T05.ChartType = SeriesChartType.Line
            T05.Name = "T05"
            Chart1.Series.Add(T05)
            T05.BorderWidth = 1
        End If
        If table_serie(5) = True Then
            T06.ChartType = SeriesChartType.Line
            T06.Name = "T06"
            Chart1.Series.Add(T06)
            T06.BorderWidth = 1
        End If
        If table_serie(6) = True Then
            T07.ChartType = SeriesChartType.Line
            T07.Name = "T07"
            Chart1.Series.Add(T07)
            T07.BorderWidth = 1
        End If
        If table_serie(7) = True Then
            T08.ChartType = SeriesChartType.Line
            T08.Name = "T08"
            Chart1.Series.Add(T08)
            T08.BorderWidth = 1
        End If
        If table_serie(8) = True Then
            T09.ChartType = SeriesChartType.Line
            T09.Name = "T09"
            Chart1.Series.Add(T09)
            T09.BorderWidth = 1
        End If
        If table_serie(9) = True Then
            T11.ChartType = SeriesChartType.Line
            T11.Name = "T11"
            Chart1.Series.Add(T11)
            T11.BorderWidth = 1
        End If
        If table_serie(10) = True Then
            T12.ChartType = SeriesChartType.Line
            T12.Name = "T12"
            Chart1.Series.Add(T12)
            T12.BorderWidth = 1
        End If



        Chart1.ChartAreas(0).AxisX.Title = "Heures de Desinfection"
        Chart1.ChartAreas(0).AxisY.Title = "Temperatures"

        Chart1.Palette = ChartColorPalette.Pastel

        Dim legend1 As New Legend
        'Titre du rectangle des légendes.

        legend1.Title = "Sonde" 'de Tempereture"
        legend1.LegendStyle = LegendStyle.Column
        Chart1.Legends(0).Font = New Font("Arial", 18, FontStyle.Bold)
        Chart1.Legends.Add(legend1)

        ' On modifie l'aspect du rectangle
        Chart1.Legends(0).BackColor = Color.Black
        Chart1.Legends(0).BackSecondaryColor = Color.White
        Chart1.Legends(0).BackGradientStyle = GradientStyle.DiagonalLeft

        Chart1.Legends(0).BorderColor = Color.Black
        Chart1.Legends(0).BorderWidth = 2
        Chart1.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        Chart1.Legends(0).ShadowOffset = 2
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '----------------------------------------------------------------------------- sauvgarde form -------------------------------------
        Dim b As New Bitmap(Me.Width, Me.Height)
        Me.DrawToBitmap(b, New Rectangle(0, 0, Me.Width, Me.Height))
        b.Save("C:/HERCO/testou.png", Imaging.ImageFormat.Png)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        parametres.Show()

    End Sub
End Class
