Imports System.IO

Imports System.Text

Public Class Control_licence


    Private Sub Control_licence_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub decryptage()
        On Error Resume Next
        Acceuil.Label1.Visible = False



        Dim tableau()

        Dim mesbytes() As Byte = Convert.FromBase64String(TextBox2.Text)
        Dim new_chaines1 = Encoding.UTF8.GetString(mesbytes)
        Dim mesbytes1() As Byte = Convert.FromBase64String(new_chaines1)
        Dim new_chaines = Encoding.UTF8.GetString(mesbytes1)
        tableau = Split(new_chaines, ";")
        Num_série = tableau(0)
        Date_expiration = tableau(1)
        '   Label3.Text = tableau(1).Substring(0, 4)
        '  Label4.Text = Label3.Text.Substring(0, 2) ' Format(Label3.Text, "dd/MM/yyyy")UVVZeE5pMHdNRGczT1RFN01UZ3ZNRE12TWpBeU1RPT0=
        Licence()

        If Licence_valide = True Then 'Else Licence_valide = False 'UVVZeE5pMHdNRGczT1RFN01ESXZNVEl2TWpBeU1BPT0=
            Enreg_cle()
            Configuration2.Label20.Text = Num_série
            Configuration2.Label19.Text = Date_expiration
            Acceuil.Label3.Text = Date_expiration
            Acceuil.Label1.Visible = True
            Me.Close()
            Acceuil.Button5.Visible = True
            Acceuil.Panel1.Visible = False
            Acceuil.TextBox1.Select()
        Else
            Label2.Text = "KEY Not VALIDE"

        End If
    End Sub

    Private Sub Enreg_cle()
        Dim map = "" : Dim map1 = "" : Dim map2 = "" : Dim map3 = "" : Dim map4 = "" : Dim map5 = "" : Dim map6 = "" : Dim map7 = ""
        Dim map8 = "" : Dim map9 = "" : Dim map10 = "" : Dim map11 = "" : Dim map12 = "" : Dim map13 = "" : Dim map14 = "" : Dim map15 = ""
        Dim map16 = ""
        ' map = ""
        ' map1 = ""
        'map2 = map3 = map4 = map5 = map6 = map7 = ""

        If Not File.Exists("C:\H2observer\configuration\config2.cfg") Then
            ' cryptage en 64 bit
            map16 = Date_expiration
            map10 = False
            map11 = False
            map12 = False
            map13 = False
            map15 = False

            Dim chaines66 = (Num_série + ";" + map + ";" + map1 _
                              + ";" + map2 + ";" + map3 + ";" + map4 _
                              + ";" + map5 + ";" + map6 + ";" + map7 _
                              + ";" + map8 + ";" + map9 + ";" + map10 _
                              + ";" + map11 + ";" + map12 _
                              + ";" + map13 + ";" + map14 + ";" + map15 + ";" + map16)
            Dim mesbytes66() As Byte = Encoding.UTF8.GetBytes(chaines66)
            Dim new_chaines66 = Convert.ToBase64String(mesbytes66)
            Dim conf2_sw As New StreamWriter("C:\H2observer\configuration\config2.cfg")
            conf2_sw.WriteLine(new_chaines66)
            conf2_sw.Close()
            ' fin cryptage
        Else
            Dim crypt
            Dim fil2 As String = "C:\H2observer\configuration\config2.cfg"
            Dim tableau_conf2()
            FileOpen(1, (fil2), OpenMode.Input)
                Do
                    crypt = LineInput(1)
                Loop Until EOF(1)
            FileClose(1)
            ' decodage
            Dim mesbytes67() As Byte = Convert.FromBase64String(crypt)
            Dim new_chaines67 = Encoding.UTF8.GetString(mesbytes67)
            tableau_conf2 = Split(new_chaines67, ";")
            'Label20.Text = tableau_conf2(0)  'NUM SERIE
            ' Label20.Text = tableau_conf2(0)  'NUM SERIE
            'TextBox12.Text = tableau_conf2(0)
            map = tableau_conf2(1)
            map1 = tableau_conf2(2)
            map2 = tableau_conf2(3)
            map3 = tableau_conf2(4)
            map4 = tableau_conf2(5)
            map5 = tableau_conf2(6)
            map6 = tableau_conf2(7)
            map7 = tableau_conf2(8)
            map8 = tableau_conf2(9)
            map9 = tableau_conf2(10)
            map10 = tableau_conf2(11)
            map11 = tableau_conf2(12)
            map12 = tableau_conf2(13)
            map13 = tableau_conf2(14)
            map14 = tableau_conf2(15)
            map15 = tableau_conf2(16)
            map16 = tableau_conf2(17)
            Dim chaines66 = (Num_série + ";" + map + ";" + map1 _
                              + ";" + map2 + ";" + map3 + ";" + map4 _
                              + ";" + map5 + ";" + map6 + ";" + map7 _
                              + ";" + map8 + ";" + map9 + ";" + map10 _
                              + ";" + map11 + ";" + map12 _
                              + ";" + map13 + ";" + map14 + ";" + map15 + ";" + Date_expiration)
            Dim mesbytes66() As Byte = Encoding.UTF8.GetBytes(chaines66)
            Dim new_chaines66 = Convert.ToBase64String(mesbytes66)
            Dim conf2_sw As New StreamWriter("C:\H2observer\configuration\config2.cfg")
            conf2_sw.WriteLine(new_chaines66)
            conf2_sw.Close()

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
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = CType(ChrW(Keys.Return), Char) Then decryptage()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class