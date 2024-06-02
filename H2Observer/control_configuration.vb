Imports System.IO

Public Class control_configuration
    Private Sub Control_configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Reload()
        Label2.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = My.Settings.passe_config2 Then
            Button2.Visible = True
            Button1.Visible = True
        End If
        If TextBox1.Text = My.Settings.passe_config1 Then
            Button2.Visible = True
            Button1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Configuration2.Show()
    End Sub
End Class