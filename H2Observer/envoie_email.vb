Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates


Module envoies_email
    Private Function customCertValidation(ByVal sender As Object,
                                            ByVal cert As X509Certificate,
                                            ByVal chain As X509Chain,
                                            ByVal errors As SslPolicyErrors) As Boolean

        Return True

    End Function
    Sub Envoies_mail()

        Dim ff
        Dim semaine
        Dim annee
        semaine = DatePart(DateInterval.WeekOfYear, Today)
        annee = Today.Year
        Dim exp As String = Exp_email
        Dim mdp As String = Mdp_exp_email
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim centre As String = "centre"
        Dim tableau_conf1()

        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim centr = "Centrale"
        Dim joint = "Ci-joint les relevés du jour"
        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")

                If lang(0) = "Envoie_email" And lang(1) = Langue Then
                    centr = lang(2)
                    joint = lang(3)
                    Exit Do
                End If

            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Envoie_email() ligne 52" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        '-----------------------------------------------------------------------
        '-------- chargement config 1 pour récupérer destinataire et centre
        '-----------------------------------------------------------------------

        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoies_mail() ligne 65" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '---------------------------------------------------------------------
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(exp, mdp) '("dialyse.eau@gmail.com", "HemOtecH")
            SmtpServer.Port = Port_exp_email '"587"
            SmtpServer.Host = Smtp_exp_email '"smtp.gmail.com" 'l'host c'est google.

            If Certif = True Then
                ServicePointManager.ServerCertificateValidationCallback =
           New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            End If
            If SSL = True Then
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.EnableSsl = False
            End If

            mail = New MailMessage()
            mail.From = New MailAddress(Exp_email) '("dialyse.eau@gmail.com")
            For i = 3 To 12 'ajout destinataire des mail relevés de config 1
                If tableau_conf1(i) <> "" Then mail.To.Add(tableau_conf1(i))
            Next
            centre = tableau_conf1(0)
            mail.Subject = centr + " " + Num_série + " " + centre
            mail.Body = joint
            ff = "C:\H2observer\releves\" + "releves" + semaine.ToString + annee.ToString + ".png"
            mail.Attachments.Add(New Attachment(ff))
            If Ver3 Then
                Dim gg = "C:\H2observer\releves\" + "releves_pre" + semaine.ToString + annee.ToString + ".png"
                mail.Attachments.Add(New Attachment(gg))
            End If
            If Acceuil.courbe_impression = True Then
                mail.Attachments.Add(New Attachment("C:\H2observer\courbes\" + Acceuil.courbe_date + ".png"))
                Acceuil.courbe_impression = False
            End If

            SmtpServer.Send(mail)
            mail.Dispose()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoies_mail() ligne 108" + CStr(ex.Message)
            DefLog(erreur)
        End Try

    End Sub
    Sub Envoie_courbe_email(Myemail, titre1)

        Dim ff
        Dim exp As String = Exp_email
        Dim mdp As String = Mdp_exp_email
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim captur = "Capture d'écran"

        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")

                If lang(0) = "Envoie_email" And lang(1) = Langue Then
                    captur = lang(4)
                    Exit Do
                End If

            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Envoie_courbe_email() ligne 139" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '---------------------------------------------------------------------
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(exp, mdp) '("dialyse.eau@gmail.com", "HemOtecH")
            SmtpServer.Port = Port_exp_email '"587"
            SmtpServer.Host = Smtp_exp_email '"smtp.gmail.com" 'l'host c'est google.

            If Certif = True Then
                ServicePointManager.ServerCertificateValidationCallback =
           New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            End If
            If SSL = True Then
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.EnableSsl = False
            End If

            mail = New MailMessage()
            mail.From = New MailAddress(Exp_email) '("dialyse.eau@gmail.com")
            mail.To.Add(Myemail)
            mail.Subject = captur
            mail.Body = ""
            ff = "C:\H2observer\Photo\" + titre1 + ".png"
            mail.Attachments.Add(New Attachment(ff))
            If System.IO.File.Exists("C:\H2observer\Photo\data.csv") = True Then mail.Attachments.Add(New Attachment("C:\H2observer\Photo\data.csv"))
            SmtpServer.Send(mail)
            mail.Dispose()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_courbe_email() ligne 171" + CStr(ex.Message)
            DefLog(erreur)
        End Try


    End Sub
    Sub Envoie_alarmmail(j As String, h As String, def As String)

        Dim exp As String = Exp_email
        Dim mdp As String = Mdp_exp_email
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim centre As String = "centre"
        Dim tableau_conf1()
        '-----------------------------------------------------------------------
        '------ chargement config 1 pour récupérer destinataire et centre
        '-----------------------------------------------------------------------
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_alarmmail() ligne 192" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim alr = "Alarme centrale d'eau"

        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")

                If lang(0) = "Envoie_email" And lang(1) = Langue Then
                    alr = lang(5)
                    Exit Do
                End If

            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Envoie_email() ligne 219" + CStr(ex.Message)
            DefLog(erreur)
        End Try

        '-----------------------------------------------------------------------
        '----------------- envoie du mail
        '-----------------------------------------------------------------------
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(exp, mdp) '("dialyse.eau@gmail.com", "HemOtecH")
            SmtpServer.Port = Port_exp_email '"587"
            SmtpServer.Host = Smtp_exp_email '"smtp.gmail.com" 'l'host c'est google.

            If Certif = True Then
                ServicePointManager.ServerCertificateValidationCallback =
           New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            End If
            If SSL = True Then
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.EnableSsl = False
            End If

            mail = New MailMessage()
            mail.From = New MailAddress(Exp_email) '("dialyse.eau@gmail.com")
            For i = 13 To 22 'ajout destinataire des mail alarm de config 1
                If tableau_conf1(i) <> "" Then mail.To.Add(tableau_conf1(i))
            Next
            centre = tableau_conf1(0)
            Dim sujetmail = alr + " " + Num_série + " " + centre
            mail.Subject = sujetmail
            mail.Body = j + "    " + h + "    " + def
            SmtpServer.Send(mail)
            mail.Dispose()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_alarmmail() ligne 255 " + CStr(ex.Message)
            DefLog(erreur)
        End Try

    End Sub
    Sub EMAIL_FIN_LICENCE()
        Dim exp As String = Exp_email
        Dim mdp As String = Mdp_exp_email
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim centre As String = "centre"
        Dim tableau_conf1()
        '-----------------------------------------------------------------------
        '------ chargement config 1 pour récupérer destinataire et centre
        '-----------------------------------------------------------------------
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module  EMAIL_FIN_LICENCE() ligne 271" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-----------------------------------------------------------------------
        '----------------- envoie du mail
        '-----------------------------------------------------------------------
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(exp, mdp) '("dialyse.eau@gmail.com", "HemOtecH") "KEY NOT VALIDATE"
            'Date_expiration = "DATE NOT VALIDATE"
            SmtpServer.Port = Port_exp_email '"587"
            SmtpServer.Host = Smtp_exp_email '"smtp.gmail.com" 'l'host c'est google.

            If Certif = True Then
                ServicePointManager.ServerCertificateValidationCallback =
           New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            End If
            If SSL = True Then
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.EnableSsl = False
            End If

            mail = New MailMessage()
            mail.From = New MailAddress(Exp_email) '("dialyse.eau@gmail.com")
            For i = 13 To 22 'ajout destinataire des mail alarm de config 1
                If tableau_conf1(i) <> "" Then mail.To.Add(tableau_conf1(i))
            Next
            centre = tableau_conf1(0)
            Dim sujetmail = "THE KEY TO THE H2OBSERVER SOFTWARE WILL EXPIRE" '+ " " + Num_série + " " + centre
            mail.Subject = sujetmail
            mail.Body = centre + "  (" + Num_série + ")  " + " THE KEY TO THE H2OBSERVER SOFTWARE WILL EXPIRE " + Date_expiration
            SmtpServer.Send(mail)
            mail.Dispose()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_alarmmail() ligne 313 " + CStr(ex.Message)
            DefLog(erreur)
        End Try
    End Sub
    Sub Envoie_contact_mail(mes As String)

        Dim exp As String = Exp_email
        Dim mdp As String = Mdp_exp_email
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim centre As String = "centre"
        Dim tableau_conf1()
        '-----------------------------------------------------------------------
        '------ chargement config 1 pour récupérer destinataire et centre
        '-----------------------------------------------------------------------
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            centre = tableau_conf1(0)
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_contact_mail() ligne 327" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-----------------------------------------------------------------------
        '----------------- envoie du mail
        '-----------------------------------------------------------------------
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(exp, mdp) '("dialyse.eau@gmail.com", "HemOtecH")
            SmtpServer.Port = Port_exp_email '"587"
            SmtpServer.Host = Smtp_exp_email '"smtp.gmail.com" 'l'host c'est google.

            If Certif = True Then
                ServicePointManager.ServerCertificateValidationCallback =
           New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            End If
            If SSL = True Then
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.EnableSsl = False
            End If

            mail = New MailMessage()
            mail.From = New MailAddress(Exp_email) '("dialyse.eau@gmail.com")
            mail.To.Add("leflanbi@gmail.com")
            mail.To.Add("nicofromperpinya@free.fr")
            mail.Subject = "Contact H2Observer" + " " + Num_série + " " + centre
            mail.Body = mes
            mail.Attachments.Add(New Attachment("C:\H2observer\alarm\erreur.log"))
            SmtpServer.Send(mail)
            mail.Dispose()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_contact_mail() ligne 365" + CStr(ex.Message)
            DefLog(erreur)
        End Try

    End Sub
    Sub Envoie_def_mail(m As String, f1 As String, f2 As String)
        '  Dim err = False
        Dim exp As String = Exp_email
        Dim mdp As String = Mdp_exp_email
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"
        Dim tableau_conf1()
        Dim centre As String = "centre"
        '-----------------------------------------------------------------------
        '------ chargement config 1 pour récupérer destinataire et centre
        '-----------------------------------------------------------------------
        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            centre = tableau_conf1(0)
            sr1.Close()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_def_mail() ligne 381" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-------------------------------------------------------------------------
        'chargement langue 
        '-------------------------------------------------------------------------
        Dim fichdef = "Fichier de défaut"
        Dim veuil = "Veuillez trouver ci-joint une recherche de défaut"

        Dim fil_langue As String = "C:\H2observer\configuration\lang.h2o"
        Try
            FileOpen(1, (fil_langue), OpenMode.Input)
            Do
                Dim lang()
                lang = Split(LineInput(1), ";")

                If lang(0) = "Envoie_email" And lang(1) = Langue Then
                    fichdef = lang(6)
                    veuil = lang(7)
                    Exit Do
                End If

            Loop Until EOF(1)
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            Dim erreur = " : Dans le module Envoie_email() ligne 411" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        '-----------------------------------------------------------------------------------
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(exp, mdp) '("dialyse.eau@gmail.com", "HemOtecH")
            SmtpServer.Port = Port_exp_email '"587"
            SmtpServer.Host = Smtp_exp_email '"smtp.gmail.com" 'l'host c'est google.

            If Certif = True Then
                ServicePointManager.ServerCertificateValidationCallback =
           New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            End If
            If SSL = True Then
                SmtpServer.EnableSsl = True
            Else
                SmtpServer.EnableSsl = False
            End If

            mail = New MailMessage()
            mail.From = New MailAddress(Exp_email) '("dialyse.eau@gmail.com")
            mail.To.Add(m)
            mail.Subject = fichdef + " " + Num_série + " " + centre
            mail.Body = veuil
            mail.Attachments.Add(New Attachment(f1))
            If f2 <> "" Then mail.Attachments.Add(New Attachment(f2))
            SmtpServer.Send(mail)
            mail.Dispose()
        Catch ex As Exception
            Dim erreur = " : Dans le module Envoie_def_mail() ligne 442" + CStr(ex.Message)
            DefLog(erreur)
        End Try
    End Sub

End Module
