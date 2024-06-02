Imports System.IO
Public Class PASSWORD
    Dim cpt = 0
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PASSWORD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        My.Settings.Reload()
        TextBox2.Visible = False
        Label1.Visible = False
        Button2.Visible = False
        Button1.Visible = False
    End Sub


    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        Button2.Visible = False
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = My.Settings.password Then
            Button2.Visible = True
            Button1.Visible = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.password = (TextBox2.Text)
        My.Settings.Save()
        paramettre_nikki.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox3.Visible = False
        Label2.Visible = False

        TextBox2.Visible = True
        Label1.Visible = True
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Button2.Visible = False
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        cpt = cpt + 1
        If cpt > 20 Then
            My.Settings.Reload()
            TextBox2.Visible = True
        End If
    End Sub
End Class