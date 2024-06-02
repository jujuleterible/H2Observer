Imports System.IO
Public Class parametres
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim par_temperature As String
        Dim par_email As String
        Try

            'Instanciation du StreamWriter avec passage du nom du fichier 
            Dim monStreamWriter As StreamWriter = New StreamWriter("C:/HERCO/parametre.txt")
            ' par_temperature = CheckBox1.Checked & ";" & CheckBox2.Checked & ";" & CheckBox3.Checked & ";" & CheckBox4.Checked & ";" & CheckBox5.Checked & ";" & CheckBox6.Checked & ";" & CheckBox7.Checked & ";" & CheckBox8.Checked & ";" & CheckBox9.Checked & ";" & CheckBox10.Checked & ";" & CheckBox11.Checked
            par_email = TextBox1.Text & ";" & TextBox2.Text & ";" & TextBox3.Text & ";" & TextBox4.Text & ";" & TextBox8.Text & ";" & TextBox7.Text & ";" & TextBox6.Text & ";" & TextBox5.Text & ";" & TextBox9.Text


            'Ecriture du texte dans votre fichier

            monStreamWriter.WriteLine(par_temperature & ";" & par_email)                                                        '(CheckBox1.Checked & ";" & CheckBox2.Checked & ";" & CheckBox3.Checked & ";" & CheckBox4.Checked & ";" & CheckBox5.Checked & ";" & CheckBox6.Checked & ";" & CheckBox7.Checked & ";" & CheckBox8.Checked & ";" & CheckBox9.Checked & ";" & CheckBox10.Checked & ";" & CheckBox11.Checked)

            monStreamWriter.Close()

        Catch ex As Exception

            'Code exécuté en cas d'exception
            'Response.Write(ex.Message)

        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim monStreamReader As StreamReader = New StreamReader("C:/HERCO/parametre.txt")
        Dim ligne As String
        Dim table1()

        Do
            ligne = monStreamReader.ReadLine()
            If ligne = "" Then GoTo saut

            table1 = Split(ligne, ";")
saut:
        Loop Until ligne Is Nothing
        monStreamReader.Close()
        '
        ' temperature affichage
        '
        '  CheckBox1.Checked = table1(0)
        '  CheckBox2.Checked = table1(1)
        ' CheckBox3.Checked = table1(2)
        ' CheckBox4.Checked = table1(3)
        '  CheckBox5.Checked = table1(4)
        ' CheckBox6.Checked = table1(5)
        '  CheckBox7.Checked = table1(6)
        ' CheckBox8.Checked = table1(7)
        '  CheckBox9.Checked = table1(8)
        ' CheckBox10.Checked = table1(9)
        ' CheckBox11.Checked = table1(10)
        '
        ' email
        '
        TextBox1.Text = table1(11)
        TextBox2.Text = table1(12)
        TextBox3.Text = table1(13)
        TextBox4.Text = table1(14)
        TextBox8.Text = table1(15)
        TextBox7.Text = table1(16)
        TextBox6.Text = table1(17)
        TextBox5.Text = table1(18)
        TextBox9.Text = table1(19)

        ' envoie_email.envoie_email()
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class