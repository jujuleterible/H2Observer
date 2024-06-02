Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Class Graphe
    Dim T04 As New Series
    Dim T03 As New Series '
    Dim T05 As New Series
    Dim Q03 As New Series
    Private lang(22)    '------------------------ remettre private lang()
    Private Sub Graphe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '  Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"        ¤¤¤¤¤¤ a remettre
        '  FileOpen(1, (fil_langue), OpenMode.Input)                                ¤¤¤¤¤¤ a remettre    
        '  Do                                                                       ¤¤¤¤¤¤ a remettre

        ' lang = Split(LineInput(1), ";")                                           ¤¤¤¤¤¤ a remettre                            
        ' If lang(0) = "graphe" And lang(1) = Langue Then Exit Do                   ¤¤¤¤¤¤ a remettre                
        ' Loop Until EOF(1)                                                         ¤¤¤¤¤¤ a remettre            
        ' FileClose(1)                                                              ¤¤¤¤¤¤ a remettre



        '                              probleme avec fichier tampon car il a perdu les A0





        'lang (3) = Heures de Desinfection
        'lang (4) = Temperatures
        'lang (5) = OI + boucle
        'lang (6) = boucle
        'lang (7) = boucle + générateurs
        'lang (8) = Calcul sur la sonde T04  A0 =
        'lang (9) = Calcul sur la sonde T04  A0 =
        'lang (10) = Calcul sur la sonde T03  A0 =
        'lang (11) = Calcul sur la sonde T05  A0 =
        'lang (12) =OI + boucle
        'lang (13) = Le :
        'lang (14) = Désinfection Thermique Osmoseur + Boucle Durée
        'lang (15) = boucle       '
        'lang (16) = Désinfection Thermique Boucle Durée
        'lang (17) = Désinfection Thermique Boucle + Générateurs Durée
        'lang (18) = boucle + générateurs
        lang(3) = "Heures de Desinfection"                                                       '¤¤¤¤¤¤ a enlever
        lang(4) = "Temperatures"                                                                '¤¤¤¤¤¤ a enlever
        lang(5) = "OI + boucle"                                                                 '¤¤¤¤¤¤ a enlever
        lang(6) = "boucle"                                                                     '¤¤¤¤¤¤ a enlever
        lang(7) = "boucle + générateurs"                                                            '¤¤¤¤¤¤ a enlever

        ' Dim Selection_desinf1, Selection_desinf2, Selection_desinf3



        lang(8) = "Calcul sur la sonde T04  A0 ="                                               '¤¤¤¤¤¤ a enlever
        lang(9) = "Calcul sur la sonde T04  A0 ="                                                '¤¤¤¤¤¤ a enlever
        lang(10) = "Calcul sur la sonde T03  A0 ="
        lang(11) = "Calcul sur la sonde T05  A0 ="
        lang(12) = "OI + boucle"
        lang(13) = "Le :"                                                                               '¤¤¤¤¤¤ a enlever
        lang(14) = "Désinfection Thermique Osmoseur + Boucle Durée"                                 '¤¤¤¤¤¤ a enlever
        lang(15) = "boucle"                                                                         '¤¤¤¤¤¤ a enlever       '
        lang(16) = "Désinfection Thermique Boucle Durée"                                                '¤¤¤¤¤¤ a enlever
        lang(17) = "Désinfection Thermique Boucle + Générateurs Durée"                                  '¤¤¤¤¤¤ a enlever
        lang(18) = "boucle + générateurs"                                                           '¤¤¤¤¤¤ a enlever


        Dim tooltip1 As New ToolTip()


        tooltip1.SetToolTip(Button2, lang(2))            ' "Acceuil")
        tooltip1.IsBalloon = True
        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500
        ' On Error Resume Next
        '----------------------------------------------------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------debut --------------------------------------------------------
        '--------------------------------------------------------------------------------------------------------------------------------------------
        On Error GoTo Fin
        Ext_Ver = "_EB"                                                                             '¤¤¤¤¤¤ a enlever
        'foc$ = "C:\H2observer\data\rclog_" + test_date + Ext_Ver + ".csv"

        ' controle si les fichiers existent sinon les decaler
        Dim Nom_Fichier As String
        Dim deux = 0 : Dim trois = 0 : Dim un = 0
        Dim aa
        Dim fou(11)
        For t = 0 To 10
            If File.Exists("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(-t).ToString("yyyyMMdd") + Ext_Ver + ".csv") Then
                aa = aa + 1
                fou(aa) = -t
            End If
        Next t


        ' fusionner plusieurs fichiers pour avoir les 3 dernieres desinfections



        Dim fileA As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(1)).ToString("yyyyMMdd") + Ext_Ver + ".csv") 'le deuxieme
        Dim fileB As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(2)).ToString("yyyyMMdd") + Ext_Ver + ".csv") 'le troisieme
        Dim fileC As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(3)).ToString("yyyyMMdd") + Ext_Ver + ".csv") 'LE PREMIER

        Dim fileE As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(4)).ToString("yyyyMMdd") + Ext_Ver + ".csv") 'LE quatrieme
        Dim fileH As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(5)).ToString("yyyyMMdd") + Ext_Ver + ".csv")
        Dim fileI As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(6)).ToString("yyyyMMdd") + Ext_Ver + ".csv")
        Dim fileJ As String() = System.IO.File.ReadAllLines("C:\H2observer\data\rclog_" + Date.Now.Date.AddDays(fou(7)).ToString("yyyyMMdd") + Ext_Ver + ".csv")

        ' Simple concatenation et appel de la fonction  OutputQueryResults resultat dans "C:\ess\test.txt

        Nom_Fichier = "compile1"
        Dim concatQuery = fileB.Concat(fileA)
        OutputQueryResults(concatQuery, Nom_Fichier)

        Nom_Fichier = "compile2"
        Dim fileF As String() = System.IO.File.ReadAllLines("C:\ess\compile1.txt")
        concatQuery = fileC.Concat(fileF)
        OutputQueryResults(concatQuery, Nom_Fichier)

        Nom_Fichier = "compile3"
        Dim fileG As String() = System.IO.File.ReadAllLines("C:\ess\compile2.txt")
        concatQuery = fileE.Concat(fileG)
        OutputQueryResults(concatQuery, Nom_Fichier)

        Nom_Fichier = "compile4"
        Dim fileK As String() = System.IO.File.ReadAllLines("C:\ess\compile3.txt")
        concatQuery = fileH.Concat(fileK)
        OutputQueryResults(concatQuery, Nom_Fichier)

        Nom_Fichier = "compile5"
        Dim fileL As String() = System.IO.File.ReadAllLines("C:\ess\compile4.txt")
        concatQuery = fileI.Concat(fileL)
        OutputQueryResults(concatQuery, Nom_Fichier)

        Nom_Fichier = "compile6"
        Dim fileM As String() = System.IO.File.ReadAllLines("C:\ess\compile5.txt")
        concatQuery = fileJ.Concat(fileM)
        OutputQueryResults(concatQuery, Nom_Fichier)

        Dim Memorie = 1
        Dim ligne_desf As String
        Dim table_desf()
        Dim foc$

        ' ENLEVER LA LIGNE DATE 

        foc$ = "C:\ess\compile6.txt"
        Dim desinfection As StreamReader = New StreamReader(foc$)
        Dim Tampon As New StreamWriter("C:\ess\tampon_desinf.txt")
        Do
            ligne_desf = desinfection.ReadLine()
            If ligne_desf = "" Then Exit Do
            table_desf = Split(ligne_desf, ";")
            If table_desf(0) <> "date" Then Tampon.WriteLine(ligne_desf)
        Loop Until ligne_desf Is Nothing

        desinfection.Close()
        Tampon.Close()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''' bon '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' 
        foc$ = "C:\ess\tampon_desinf.txt"
        Dim desinfs As StreamReader = New StreamReader(foc$)

        For tt = 1 To 7
            Dim sw As New StreamWriter("C:\ess\" + Str(tt) + ".txt")

            Do
                ligne_desf = desinfs.ReadLine()
                If ligne_desf = "" Then Exit Do
                table_desf = Split(ligne_desf, ";")
                If table_desf(6) <> "--:--" Then
                    sw.WriteLine(ligne_desf)


                    Memorie = 2

                Else

                    If table_desf(6) = "--:--" And Memorie = 2 Then
                        Exit Do
                    End If


                End If




            Loop Until ligne_desf Is Nothing
            Memorie = 0
            sw.Close()
        Next tt
        desinfs.Close()


        '--------------------------------------------------------------------------------------------
        ' controle des desinfections sur une semaine 
        '-----------------------------------------------------------------------------------------------
        Dim selection1 = 0, selection2 = 0, selection3 = 0
        Dim choix2
        foc$ = "C:\ess\tampon_desinf.txt"
        Dim mouton As StreamReader = New StreamReader(foc$)

        Do
            ligne_desf = mouton.ReadLine()
            table_desf = Split(ligne_desf, ";")
            If ligne_desf = "" Then Exit Do
            If table_desf(6) = lang(5) And selection1 = 0 Then selection1 = 1          '"OI + boucle"


            If table_desf(6) = lang(6) And selection2 = 0 Then selection2 = 1              '"boucle"
            If table_desf(6) = lang(7) And selection3 = 0 Then selection3 = 1               '"boucle + générateurs"
        Loop Until ligne_desf Is Nothing

        mouton.Close()

        For tt = 7 To 1 Step -1
            If FileLen("C:\ess\" + Str(tt) + ".txt") > 1000 Then
                choix2 = Str(tt)
                Exit For
            End If
            '          
        Next tt






        Courbe2(choix2, selection1, selection2, selection3)









Fin:
        '-------------------------- a remettre pour info ---------------------------------------------------------------

        If Err.Number = 53 Then TextBox1.Text = "ATTENTION ERREUR DE FICHIERS OU MANQUE DES FICHIERS"



    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Acceuil.Button6.Visible = True
        Acceuil.Button9.Visible = True
        Acceuil.Button4.Visible = True
        Acceuil.Button2.Visible = True
        Acceuil.Button1.Visible = True
        Acceuil.Button5.Visible = True
        Acceuil.Button3.Visible = True
        Acceuil.Panel1.Visible = False
        Acceuil.TextBox1.Select()
        Me.Close()
    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
    Private Sub Courbe2(choix2, selection1, selection2, selection3)
        Dim Testou = choix2

        Dim T04 As New Series
        Dim T03 As New Series '
        Dim T05 As New Series
        Dim Q03 As New Series

        T03.ChartType = SeriesChartType.Spline
        T03.Name = "T03"
        Chart1.Series.Add(T03)
        T03.BorderWidth = 3

        T04.ChartType = SeriesChartType.Spline
        T04.Name = "T04"
        Chart1.Series.Add(T04)
        T04.BorderWidth = 3

        T05.ChartType = SeriesChartType.Spline
        T05.Name = "T05"
        Chart1.Series.Add(T05)
        T05.BorderWidth = 3

        Q03.ChartType = SeriesChartType.Spline
        Q03.Name = "Q03"
        Chart1.Series.Add(Q03)
        Q03.BorderWidth = 3






        Dim datte = "" ', heures
        Dim heures = ""
        Dim table()
        Dim cpt = 0     'nbre enregistrements  total    SeriesChartType.Spline                                                           
        ' Dim cpt1 = 0    'nbre enregistrement sup a 80 pour calcul A0
        ' Dim compteur = 0 'nbre enregistrement sup a 80 pour calcul A0T04.IsValueShownAsLabel = True  If (Not File.Exists(foc$)) Then GoTo saut
        ' Dim cpt2 = 0    'nbre enregistrement sup a 80 pour calcul A0

        Dim heur_debut = ""
        Dim heur_fin = ""
        Dim popo = 0
        Dim heur_debut1 = ""
        Dim nom_titre = ""
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim t5 As Double
        Dim t4 As Double
        Dim t3 As Double
        Dim q3 As Double

        Dim cpt2 As Double
        Dim compteur As Double
        Dim pt_debut As Double
        Dim cpt1 As Double
        Dim pt_fin As Double
        Dim pt_fin1 As Double
        pt_fin1 = 0 : pt_fin = 0 : cpt1 = 0 : pt_debut = 0 : compteur = 0 : cpt2 = 0
        t5 = 0 : t3 = 0 : t4 = 0
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tableau_conf1()
        Dim info

        cpt = 0 : compteur = 0 : cpt1 = 0

        'Dim LOLO = Directory.EnumerateFiles("C:\ess\", "*.*", SearchOption.AllDirectories).Count()

        '  For YY = 1 To 2
        ' If (File.Exists("C:\ess\" + Str(YY) + ".txt")) Then 'Dim GG = FileLen("C:\ess\" + Str(YY) + ".txt")


        ' Next



        '---------------------------------------------------------------------------------------------------- verifier A0 car compteur =0
        Dim A0t3 = 0
        Dim A0t4 = 0
        Dim foc$
        foc$ = "C:\ess\" + choix2 + ".txt" 'tampon_desinf.txt"
        'Dim desinfs As StreamReader = New StreamReader(foc$)

        Dim monStreamReader1 As StreamReader = New StreamReader(foc$)
        Dim ligne1 As String

        Do
            ligne1 = monStreamReader1.ReadLine()
            If ligne1 = "" Then Exit Do

            table = Split(ligne1, ";")
            If table(2) = "A+" And info = "" Then
                info = table(3) + " a " + table(1)
                GoTo saw
            End If
            ' If table(7) = "recirculation" Or table(7) = "temps d'action" Or table(7) = "rinçage désinfectant" Then table(6) = "chimique" 'pour que la condition or fonctionne
            'If table(6) = lang(5) Or table(6) = lang(6) Or table(6) = lang(7) Or table(6) = "chimique" Then

            datte = table(0)
            heures = table(1)
            nom_titre = table(6)

            t3 = Val(Replace(table(27), ",", "."))
            t4 = Val(Replace(table(35), ",", "."))
            t5 = Val(Replace(table(30), ",", "."))

            If IsNumeric(table(26)) = False Then q3 = 100 Else q3 = Val(Replace(table(26), ",", "."))


            If table(6) = lang(6) Then                      'BOUCLE
                T04.Points.AddXY(heures, t4)
                If t4 >= 80 Then
                    pt_fin = (10 ^ ((t4 - 80) / 10)) * 60 '
                    cpt1 = cpt1 + pt_fin
                End If
                If table(56) > 0 Then A0t4 = table(56)
            End If

            If table(6) = lang(5) Then                             '"OI + boucle"
                T03.Points.AddXY(heures, t3)
                T04.Points.AddXY(heures, t4)
                If t4 >= 80 Then
                    pt_fin = (10 ^ ((t4 - 80) / 10)) * 60 ''
                    cpt1 = cpt1 + pt_fin
                End If
                If t3 >= 80 Then
                    pt_debut = (10 ^ ((t3 - 80) / 10)) * 60 ''
                    compteur = compteur + pt_debut
                End If
                If table(55) > 0 Then A0t3 = table(55)
                If table(56) > 0 Then A0t4 = table(56)
            End If

            If table(6) = lang(7) Then                              '"boucle + générateurs"
                T05.Points.AddXY(heures, t5)
                T04.Points.AddXY(heures, t4)
                If t5 >= 80 Then
                    pt_fin1 = (10 ^ ((t5 - 80) / 10)) * 60 '
                    cpt2 = cpt2 + pt_fin1
                End If
                If t4 >= 80 Then
                    pt_fin = (10 ^ ((t4 - 80) / 10)) * 60 '
                    cpt1 = cpt1 + pt_fin
                End If

            End If

            ' If table_desf(6) = "chimique" Then   'DESINF CHIMIQUE"
            'Chart1.ChartAreas(0).AxisY.Title = "Chimique"
            'Q03.Points.AddXY(heures, q3)
            ' If q3 = "_x0018__x0018_,_x0018_" Then q3 = 100
            '            If q3 >= 70 Then
            ' pt_fin = (10 ^ ((q3 - 80) / 10)) * 60 '
            'cpt1 = cpt1 + pt_fin
            'End If

            'End If



            cpt = cpt + 1
            If cpt = 1 Then heur_debut = datte + " " + heures

            '   End If
saw:
        Loop Until ligne1 Is Nothing
        monStreamReader1.Close()
        ''''''' Chart2.Location = New System.Drawing.Point(0, 250)

        ' Dimensionner le Chart
        '''''''' Chart2.Size = New System.Drawing.Size(1200, 250)

        If info = "" Then
            Chart1.ChartAreas(0).AxisX.Title = lang(3)
        Else
            Chart1.ChartAreas(0).AxisX.Title = "Remarque " + info + " pendant la desinfection"

        End If
        If selection1 = 0 Then TextBox1.Text = "il y a pas eu de desinfection OI + boucle depuis une semaine"
        If selection2 = 0 Then TextBox1.Text = "il y a pas eu de desinfection boucle depuis une semaine"
        If selection3 = 0 Then TextBox1.Text = "il y a pas eu de desinfection boucle + générateurs depuis une semaine"




        ' Chart2.ChartAreas(0).AxisX.Title = lang(3) + info             '"Heures de Desinfection"+


        Chart1.ChartAreas(0).AxisY.Title = lang(4)                  '"Temperatures"
        Chart1.Palette = ChartColorPalette.Pastel
        'Me.Controls.Add(Chart1)
        heur_fin = datte + " " + heures
        Dim h1 = CDate(heur_debut)
        Dim h2 = CDate(heur_fin)
        Dim diff2 = (h2 - h1).ToString


        '---------------------------------------------------------------------------------------------------------------
        '---------------------------- annotation sur la courbe
        Chart1.Annotations.Clear()
        Dim MyAnnotation As New CalloutAnnotation()
        Dim MyAnnotation1 As New CalloutAnnotation()
        Dim MyAnnotation2 As New CalloutAnnotation()
        MyAnnotation.Font = New Font("Arial", 12, FontStyle.Bold)
        MyAnnotation1.Font = New Font("Arial", 12, FontStyle.Bold)
        MyAnnotation2.Font = New Font("Arial", 12, FontStyle.Bold)



        If cpt1 > 10 Then
            If A0t4 > 0 Then
                MyAnnotation1.AnchorDataPoint = T04.Points(cpt - 3) '(cpt / 7)) '
                MyAnnotation1.Text = lang(8) + Str(Int(A0t4)) '"Annotation sur un Point du graph"255, 255, 128
                If A0t4 >= 12000 Then MyAnnotation1.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation1.BackColor = Color.FromArgb(255, 0, 0)
                Chart1.Annotations.Add(MyAnnotation1)
            Else

                MyAnnotation1.AnchorDataPoint = T04.Points(cpt - 3) '(cpt / 7)) '
                MyAnnotation1.Text = lang(8) + Str(Int(cpt1)) '"Annotation sur un Point du graph"255, 255, 128
                If cpt1 >= 12000 Then MyAnnotation1.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation1.BackColor = Color.FromArgb(255, 0, 0)
                Chart1.Annotations.Add(MyAnnotation1)
            End If
        End If


        If compteur > 10 Then
            If A0t3 > 0 Then
                MyAnnotation.AnchorDataPoint = T03.Points(3) 'cpt - (cpt / 7))
                MyAnnotation.Text = lang(10) + Str(Int(A0t3)) '"Annotation sur un Point du graph"200
                If A0t3 >= 12000 Then MyAnnotation.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation.BackColor = Color.FromArgb(255, 0, 0)
                Chart1.Annotations.Add(MyAnnotation)
            Else
                MyAnnotation.AnchorDataPoint = T03.Points(3) 'cpt - (cpt / 7))
                MyAnnotation.Text = lang(10) + Str(Int(compteur)) '"Annotation sur un Point du graph"200
                If compteur >= 12000 Then MyAnnotation.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation.BackColor = Color.FromArgb(255, 0, 0)
                Chart1.Annotations.Add(MyAnnotation)
            End If
        End If


        If cpt2 > 10 Then
            MyAnnotation2.AnchorDataPoint = T05.Points(3) '
            MyAnnotation2.Text = lang(11) + Str(Int(cpt2)) '"Annotation sur un Point du graph"255, 255, 128
            If cpt2 >= 12000 Then MyAnnotation2.BackColor = Color.FromArgb(200, 255, 128) Else MyAnnotation2.BackColor = Color.FromArgb(255, 0, 0)
            Chart1.Annotations.Add(MyAnnotation2)
        End If




        diff2 = diff2.Substring(0, 2) & "h" & diff2.Substring(2 + 1)

        If nom_titre = lang(5) Then nom_titre = lang(13) + " " + datte + " " + lang(14) + " " + diff2 'Else nom_titre = tableau_conf1(0) + " : " + datte + " Desinfection Thermique Boucle Durée " + diff2
        If nom_titre = lang(6) Then nom_titre = lang(13) + " " + datte + " " + lang(16) + " " + diff2
        If nom_titre = lang(7) Then nom_titre = lang(13) + " " + datte + " " + lang(17) + " " + diff2 'Else nom_titre = tableau_conf1(0) + " : " + datte + " Desinfection Thermique Boucle Durée " + diff2


        Chart1.Titles.Clear()
        'Dim poloo = tableau_conf1(0)
        'Chart1.Titles.Add(poloo)
        Chart1.Titles.Add(nom_titre)
        Chart1.Titles(0).Font = New Font("Arial", 15, FontStyle.Bold)
        ' Chart2.Titles(1).Font = New Font("Arial", 15, FontStyle.Bold)
        'Chart1.Titles.Add(Num_série)
        '
saut:
        ' Chart1.Series.Clear()
        'T03.Points.Clear()
        'T04.Points.Clear()
        'T05.Points.Clear()
        'cpt2 = 0
        ' = 0
        'compteur = 0
        ' Next Testou
    End Sub
    Shared Sub OutputQueryResults(ByVal query As IEnumerable(Of String), ByVal Nom_Fichier As String)
        Dim sw As New StreamWriter("C:\ess\" + Nom_Fichier + ".txt")

        For Each item As String In query

            sw.WriteLine(item)
        Next

        sw.Close()
    End Sub
End Class