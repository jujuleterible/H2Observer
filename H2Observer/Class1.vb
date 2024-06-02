Imports WinSCP
Public Class Winscp_class
    Friend Class Synchro_ftp
        Public Shared Function Main() As Integer

            ' IP_Diatron ' IP de la Sdcard du Diatron ----> sert à ouvrir session Winscp
            ' Nom_session ' Nom d'ouverture de la session winscp
            ' Mdp_session ' Mot d

            If Ver1 = True Then
                Try
                    ' initialisation des options de la session winscp
                    Dim sessionOptions As New SessionOptions
                    With sessionOptions
                        .Protocol = Protocol.Ftp
                        .HostName = IP_Diatron '"192.168.1.1"
                        .UserName = Nom_session '"root"
                        .Password = Mdp_session ' ""
                    End With

                    Using session As New Session
                        'permet de signaler la progression du transfert
                        AddHandler session.FileTransferred, AddressOf FileTransferred
                        ' ouvrir la session winscp
                        session.Open(sessionOptions)
                        ' Synchroniser les fichiers du ftp vers le répertoire local
                        Dim synchronizationResult As SynchronizationResult
                        synchronizationResult =
                            session.SynchronizeDirectories(
                               SynchronizationMode.Local, "C:\H2observer\data", "/sdcard1/Prot", False)
                        ' verification d'erreur
                        synchronizationResult.Check()
                    End Using
                    Return 0
                Catch e As Exception
                    Process.Start("C:\H2observer\configuration\sd_sync.bat")
                    Dim erreur = " : Dans le module Winscp_class.Synchro_ftp.Main() ligne 37" + CStr(e.Message)
                    DefLog(erreur)
                    Return 1
                End Try
            End If

            If Ver2 = True Or Ver3 = True Then
                Try
                    ' ' initialisation des options de la session winscp
                    Dim sessionOptions As New SessionOptions
                    With sessionOptions
                        .Protocol = Protocol.Sftp
                        .HostName = IP_Diatron '"192.168.1.1"
                        .UserName = Nom_session '"root"
                        .Password = Mdp_session ' "root"
                        .PortNumber = Port
                        .GiveUpSecurityAndAcceptAnySshHostKey = True
                    End With

                    Using Session As New Session
                        'permet de signaler la progression du transfert
                        AddHandler Session.FileTransferred, AddressOf FileTransferred
                        ' ouvrir la session winscp
                        Session.Open(sessionOptions)
                        ' Synchroniser les fichiers du ftp vers le répertoire local
                        Dim synchronizationResult As SynchronizationResult
                        synchronizationResult =
            Session.SynchronizeDirectories(
            SynchronizationMode.Local, "C:\H2observer\data", "/sdcard1/Prot", False)
                        ' verification d'erreur
                        synchronizationResult.Check()
                    End Using
                    Return 0
                Catch e As Exception
                    Process.Start("C:\H2observer\configuration\sd_sync2.bat")
                    Dim erreur = " : Dans le module Winscp_class.Synchro_ftp.Main() ligne 76" + CStr(e.Message)
                    DefLog(erreur)
                    Return 1
                End Try

            End If
            '  Return 0
        End Function

        Private Shared Sub FileTransferred(sender As Object, e As TransferEventArgs)

            If e.Error Is Nothing Then
                Console.WriteLine("synchronisation {0} réussie", e.FileName)
            Else
                Console.WriteLine("synchronisation {0} échouée: {1}", e.FileName, e.Error)
                ' Dim erreur = " : Dans le module Winscp_class.fileTransferred() ligne 49" + CStr(e.FileName)
                ' DefLog(erreur)
            End If

            If e.Chmod IsNot Nothing Then
                If e.Chmod.Error Is Nothing Then
                    Console.WriteLine(
                        "Permissions of {0} set to {1}", e.Chmod.FileName, e.Chmod.FilePermissions)
                Else
                    Console.WriteLine(
                        "Setting permissions of {0} failed: {1}", e.Chmod.FileName, e.Chmod.Error)
                    '  Dim erreur = " : Dans le module Winscp_class.fileTransferred() ligne 61" + CStr(e.Chmod.FileName)
                    '  DefLog(erreur)
                End If
            Else
                Console.WriteLine("Permissions of {0} kept with their defaults", e.Destination)
                ' Dim erreur = " : Dans le module Winscp_class.fileTransferred() ligne 49" + CStr(e.FileName)
                'DefLog(erreur)
            End If

            If e.Touch IsNot Nothing Then
                If e.Touch.Error Is Nothing Then
                    Console.WriteLine(
                        "Timestamp of {0} set to {1}", e.Touch.FileName, e.Touch.LastWriteTime)
                Else
                    Console.WriteLine(
                        "Setting timestamp of {0} failed: {1}", e.Touch.FileName, e.Touch.Error)
                End If
            Else
                ' This should never happen during "local to remote" synchronization
                Console.WriteLine(
                    "Timestamp of {0} kept with its default (current time)", e.Destination)
            End If

        End Sub

    End Class
End Class
