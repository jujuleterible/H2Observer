Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
'Imports System.IO.File
Imports System
'Public Event System()
Public Class visualisation_courbe
    Private Sub Visualisation_Courbe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim B2 = "Acceuil"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")
                If lang(0) = "Visualisation_courbe" And lang(1) = Langue Then
                    B2 = lang(2)
                    Label1.Text = lang(3)
                    Label2.Text = lang(4)
                    Exit Do
                End If
            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try

        Dim tooltip1 As New ToolTip()
        tooltip1.SetToolTip(Button2, B2)

        tooltip1.UseFading = True
        tooltip1.UseAnimation = True
        tooltip1.AutoPopDelay = 2000
        tooltip1.InitialDelay = 1000
        tooltip1.ReshowDelay = 500

        ListView1.View = View.Details
        Dim i As Integer
        Dim filename
        Dim sotr
        Dim png
        Dim position, reste
        '---------------------------------------TRIE DATE ---------------------------------------------------------------------------------------
        ListView1.View = View.Details
        ListView1.Columns.Add("Date Desinfection", 170, HorizontalAlignment.Left)
        'ListView1.Columns.Add("type desinfection", 100, HorizontalAlignment.Left)

        Dim trie(My.Computer.FileSystem.GetFiles("C:\H2observer\courbes\").Count - 1)

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\H2observer\courbes\").Count - 1
            filename = (My.Computer.FileSystem.GetFiles("C:\H2observer\courbes\").Item(i))
            sotr = Split(filename, "\")(3)
            png = CDate(sotr.Substring(0, 10))
            trie(i) = png
        Next i
        Array.Sort(trie)
        Array.Reverse(trie)
        '---------------------------------------AFFICHAGE DATE ----------------------------------------------------------------------------------------------
        For i = 0 To My.Computer.FileSystem.GetFiles("C:\H2observer\courbes\").Count - 1
            For j = 0 To My.Computer.FileSystem.GetFiles("C:\H2observer\courbes\").Count - 1

                Dim LVI As New ListViewItem

                filename = (My.Computer.FileSystem.GetFiles("C:\H2observer\courbes\").Item(j))
                sotr = Split(filename, "\")(3)
                png = CDate(sotr.Substring(0, 10))
                If trie(i) = png Then
                    position = sotr.indexof(".")
                    reste = sotr.Substring(0, position)
                    LVI.Text = reste
                    ListView1.Items.Add(LVI)
                End If
            Next j
        Next i
        For j = 0 To ListView1.Items.Count - 1

            filename = ListView1.Items(j).ToString
            If InStr(1, filename, "_") > 1 Then
                ListView1.Items(j).ForeColor = Color.Red
            End If
        Next j
        Dim forme = ListView1.Items(0).Text.ToString

        Dim Imagep = "C:\H2observer\courbes\" & Replace(forme, "/", "-") & ".png"
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.ImageLocation = Imagep
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
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover

        Button2.FlatStyle = FlatStyle.Standard

    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave

        Button2.FlatStyle = FlatStyle.Flat

    End Sub




    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        '  Dim po = ListView1.SelectedIndices(0)
        '  Dim forme = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text.ToString

        ' Dim Imagep = "C:\H2observer\courbes\" & Replace(forme, "/", "-") & ".png"
        ' PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        'PictureBox1.ImageLocation = Imagep
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Dim forme = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text.ToString

        Dim Imagep = "C:\H2observer\courbes\" & Replace(forme, "/", "-") & ".png"
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.ImageLocation = Imagep
    End Sub
End Class