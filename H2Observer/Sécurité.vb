Imports System.IO
Imports System.Text

Module Sécurité
    Public Date_expiration
    Public Num_série = "AF16-000000" ' Numéro de série du Diatron ---> sert à la fuille relevés, désinfection, et de licence 
    Public Mdp_config1
    Public Opt_Analyses = False ' sert à autoriser option Analyses
    Public Opt_Alarmes = False ' sert à autoriser option Analyses
    Public Exp_email ' email de l'expéditeur : actuellement dialyse.eau@gmail.com
    Public Mdp_exp_email ' mot de passe email de l'expéditeur : actuellement HemOtecH
    Public Port_exp_email ' port du serveur SMTP de l'expéditeur : actuellement 587
    Public Smtp_exp_email ' smtp du serveur SMTP de l'expéditeur : actuellement smtp.gmail.com
    Public Date_service ' Date de mise en service ---> sert à bloquer la date minimale pour les recherches
    Public IP_Diatron ' IP de la Sdcard du Diatron ----> sert à ouvrir session Winscp
    Public Nom_session ' Nom d'ouverture de la session winscp
    Public Mdp_session ' Mot de passe de la session Winscp : actuellement Vide
    Public Port
    Dim Mdp_config2 ' Mot de passe écran configuration 2 
    Public Ver1 'version diatron 1
    Public Ver2 'version Diatron 2
    Public Ver3 'version diatron 2 avec prétraitement
    Public Ext_Ver 'extension fichier suivant diatron 1 ou diatron 2
    Public Licence_valide = False
    Public Langue
    Public SeuilPR01
    Public SSL
    Public Certif

    Sub Configuration()

        '-----------------------------------------------------------------------
        '----------------- chargement configuration 2
        '-----------------------------------------------------------------------
        Dim fil2 As String = "C:\H2observer\configuration\config2.cfg"
        Dim tableau_conf2()
        Dim crypt
        Try
            FileOpen(1, (fil2), OpenMode.Input)
            Do
                crypt = LineInput(1)
            Loop Until EOF(1)
            FileClose(1)

            ' decodage
            Dim mesbytes() As Byte = Convert.FromBase64String(crypt)
            Dim new_chaines = Encoding.UTF8.GetString(mesbytes)
            tableau_conf2 = Split(new_chaines, ";")
            Num_série = tableau_conf2(0)
            Date_service = tableau_conf2(1)
            IP_Diatron = tableau_conf2(2)
            Nom_session = tableau_conf2(3)
            Mdp_session = tableau_conf2(4)
            Mdp_config1 = tableau_conf2(5)
            Mdp_config2 = tableau_conf2(6)
            Exp_email = tableau_conf2(7)
            Mdp_exp_email = tableau_conf2(8)
            Port_exp_email = tableau_conf2(9)
            Smtp_exp_email = tableau_conf2(10)
            Opt_Analyses = tableau_conf2(11)
            Opt_Alarmes = tableau_conf2(12)
            Ver1 = tableau_conf2(13)
            Ver2 = tableau_conf2(14)
            Port = tableau_conf2(15)
            Ver3 = tableau_conf2(16)
            Date_expiration = tableau_conf2(17)
            SSL = tableau_conf2(18)
            Certif = tableau_conf2(19)
            'fin decodage

        Catch ex As FileNotFoundException
            FileClose(1)
            Acceuil.Button5.PerformClick()
            Dim erreur = " : Dans le module Sécurité_Configuration()() ligne 74" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        Dim fil1 As String = "C:\H2observer\configuration\config1.cfg"

        Try
            Dim sr1 As StreamReader = New StreamReader(fil1)
            Dim tableau_conf1()
            tableau_conf1 = Split(sr1.ReadLine(), ";")
            Langue = tableau_conf1(24)
            SeuilPR01 = Val(Replace(tableau_conf1(25), ",", "."))
            sr1.Close()

        Catch ex As Exception
            Dim erreur = " : Dans le module Configuration1_load() ligne 88" + CStr(ex.Message)
            DefLog(erreur)
        End Try
        Licence()
        If Opt_Analyses = True And Licence_valide = True Then
            Acceuil.Button1.Visible = True
            'Acceuil.Button1.FlatAppearance.BorderColor = Color.White
        End If
        If Opt_Alarmes = True And Licence_valide = True Then
            Acceuil.Button9.Visible = True
            'Acceuil.Button9.FlatAppearance.BorderColor = Color.White
        End If
        If Ver1 = True Then Ext_Ver = ""
        If Ver2 = True Then Ext_Ver = "_eB"
        If Ver3 = True Then Ext_Ver = "_eB"
    End Sub
    Sub DefLog(erreur As String)

        '-----------------------------------------------------------------------
        '-- fichier log repertoriant les erreurs des Try
        '-----------------------------------------------------------------------
        Dim dat = Today
        Dim tim = TimeOfDay
        erreur = dat + " " + tim + " : " + erreur
        Dim logfile As String = "C:\H2observer\alarm\erreur.log"
        If (Not File.Exists(logfile)) Then
            Try
                Dim logsw As New StreamWriter(logfile)
                logsw.WriteLine(erreur)
                logsw.Close()
            Catch ex As Exception
            End Try
        Else
            Dim logsw As New StreamWriter(logfile, True)
            logsw.WriteLine(erreur)
            logsw.Close()
        End If

    End Sub
    Sub Licence()

        '-----------------------------------------------------------------------
        '-- recherche du numéro de série dans le répertoire
        '-- afin de pouvoir le comparer avec celui entré dans conf2
        '-----------------------------------------------------------------------
        Dim Fichiers As String() = Nothing
        Dim mot = ""
        Fichiers = Directory.GetFiles("C:\Herco\Daten_données", "*.csv")

        For Each s As String In Fichiers
            Try
                Dim rech As String() = s.Split("\")
                mot = rech.ElementAt(rech.Length - 1)
                mot = mot.Substring(0, 11)
                ' mot = mot.Substring(0, mot.Count - 4)
                If mot <> "" Then Exit For
            Catch ex As Exception
                Dim erreur = " : Dans le module Sécurité_Licence()() ligne 145" + CStr(ex.Message)
                DefLog(erreur)
            End Try
        Next
        If mot = Num_série Then Licence_valide = True Else Licence_valide = False

    End Sub

End Module
