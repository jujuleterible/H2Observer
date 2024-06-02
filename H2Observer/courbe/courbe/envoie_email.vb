Imports System.Net
Imports System.Net.Mail
Imports System.IO
Module envoie_email
    Sub envoie_emaile()
        Dim monStreamReader As StreamReader = New StreamReader("C:/HERCO/parametre.txt")
        Dim ligne As String
        Dim table2()
        Dim email_principale As String : Dim pass As String
        Dim ex1 As String : Dim ex2 As String : Dim ex3 As String
        Dim intitule As String
        Dim smtp1 : Dim port As Integer : Dim secue
        Do
            ligne = monStreamReader.ReadLine()
            If ligne = "" Then GoTo saut

            table2 = Split(ligne, ";")
saut:
        Loop Until ligne Is Nothing
        monStreamReader.Close()



        email_principale = table2(18) '"cabanes.jeanluc@gmail.com"
        pass = table2(19) '"2612lechien2707"
        ex1 = table2(11)
        ex2 = table2(12)
        ex3 = table2(13)
        intitule = table2(14)
        smtp1 = table2(15)
        port = table2(16)
        secue = table2(17)


        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()

            SmtpServer.Credentials = New Net.NetworkCredential(email_principale, pass)
            SmtpServer.Port = port '587
            SmtpServer.Host = smtp1 '"smtp.gmail.com" 'l'host c'est google.
            SmtpServer.EnableSsl = secue 'True

            mail = New MailMessage()
            mail.From = New MailAddress(email_principale) '("cabanes.jeanluc@gmail.com")
            'mail.To.Add("leflanbi@aol.com")
            ' autre destinataire
            If ex1 <> "" Then mail.To.Add(ex1) '("leflanbi@aol.com")
            If ex2 <> "" Then mail.To.Add(ex2)
            If ex3 <> "" Then mail.To.Add(ex3)
            'mail to add (destinataire)
            mail.Subject = "TextBox2.Textuuuuuuuuuuuuuuuuuuuuuuuuuuuuu"
            mail.Body = "TextBox1.Text"
            mail.Attachments.Add(New Attachment("C:/HERCO/testou.png"))
            'mail.Attachments.Add(new Attachment("c:\\temp\\example2.txt"));
            SmtpServer.Send(mail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Module
