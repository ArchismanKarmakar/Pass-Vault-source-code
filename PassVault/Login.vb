Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.IO
Imports System.Environment
Imports System.Diagnostics
Imports System.Reflection
Imports System.Security.Principal
Imports System.Security.AccessControl
Imports System.Runtime.CompilerServices
Imports System.Byte
Imports System.Speech.Synthesis
Imports System.Web.UI

Public Class Login
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Dim timerlog1 As Integer
        'For timerlog1 = 0 To 100
        If UsernameTextBox.Text = "" And PasswordTextBox.Text = "" Then
            'Next
            Me.Hide()
            UsernameTextBox.Clear()
            PasswordTextBox.Clear()
            HaveInternetConnection()
            Main.Show()
        Else
            MsgBox("Wrong Credentials")
        End If
    End Sub


    Protected Function HaveInternetConnection() As Boolean
        Return 0
        Dim loop1 As Integer
        loop1 = 1
a:
        While (loop1 = 1)
            If My.Computer.Network.IsAvailable Then
                Try
                    If My.Computer.Network.Ping("www.google.com") Then

                        Select Case MsgBox("Computer is connected to the internet. Please disconnect internet to continue using PassVault", MsgBoxStyle.OkCancel)
                            Case MsgBoxResult.Ok
                                GoTo a
                            Case MsgBoxResult.Cancel
                                Me.Close()
                                Application.Exit()
                                Return False
                        End Select
                    End If
                Catch
                    loop1 = 0
                    Return False
                End Try
            Else
                loop1 = 0
                Return False
            End If
        End While
        Return False
    End Function

    Private Sub Forgot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Forgot.Click
        'quit_bak_save()
        Application.Exit()
        Me.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'HaveInternetConnection()
        run_as_admin()
        AnimateWindow(Me.Handle.ToInt32, CInt(100), AW_BLEND_INT)
        Dim loop1 As Integer
        loop1 = 1
        Shell("attrib ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48 -s -r -a -h")
        Shell("attrib ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48 -s -r -a -h")
        first_run()
        'Shell("attrib ..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48 -r -s -a")
        'speechsynth.Speak("Hello Aritra!")

        'Shell("attrib ..\Vn#RVypWq1hqX6%R.netsdk48 +h")
        Button1.Enabled = False
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged

        Dim loop1 As Integer
        loop1 = 1
        HaveInternetConnection()
    End Sub

    Private Function EncryptFile() As String
        Dim SaltValue As String = "E5FCA791CDF72C86"
        Dim EncryptionKey As String = "FBEA05D036B03D13B1CFDFBD961DF9753BB77589840D7DE7"
        Dim plainFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\Vn#RVypWq1hqX6%R.netcon48"
        Dim encryptedFilePath As String = "ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48"
        Dim passwordIterations As Integer = 1000
        Dim initVector As String = "CE4EB972A9530σF3" '"C359AF7295506C57"
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(SaltValue)
        Dim k1 As New Rfc2898DeriveBytes(EncryptionKey, saltValueBytes, passwordIterations)
        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(k1.GetBytes(16), initVectorBytes)

        Using plain As FileStream = File.Open(plainFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
            Using encrypted As FileStream = File.Open(encryptedFilePath, FileMode.Create, FileAccess.Write, FileShare.None)
                Using cs As CryptoStream = New CryptoStream(encrypted, encryptor, CryptoStreamMode.Write)
                    plain.CopyTo(cs)
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Private Function DecryptFile() As String
        Dim SaltValue As String = "E5FCA791CDF72C86"
        Dim DecryptionKey As String = "FBEA05D036B03D13B1CFDFBD961DF9753BB77589840D7DE7" '"6D0D40D7FFBD961753BEA08CDF9375BB98FDD13B1B357E7"
        Dim plainFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\Vn#RVypWq1hqX6%R.netcon48"
        Dim encryptedFilePath As String = "ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48"
        Dim passwordIterations As Integer = 1000

        Dim initVector As String = "CE4EB972A9530σF3" '"79F3CA230706AC32F59C95955E4EB957"
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(SaltValue)
        Dim k1 As New Rfc2898DeriveBytes(DecryptionKey, saltValueBytes, passwordIterations)
        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(k1.GetBytes(16), initVectorBytes)

        Using plain As FileStream = File.Open(plainFilePath, FileMode.Create, FileAccess.Write, FileShare.None)
            Using encrypted As FileStream = File.Open(encryptedFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                Using cs As CryptoStream = New CryptoStream(plain, decryptor, CryptoStreamMode.Write)
                    encrypted.CopyTo(cs)
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'quit_bak_save()
        Try

            EncryptFile()
            quit_bak_save()


        Catch

        End Try

    End Sub

    Private Function shell_dec()
        Dim myProcessStartInfo As New ProcessStartInfo()

        With myProcessStartInfo
            .FileName = "cmd.exe"
            .Arguments = "/k bcdedit.exe /set {current} nx AlwaysOn"
            .Verb = "runas"
            .UseShellExecute = True
        End With

        Process.Start(myProcessStartInfo)
        Return Nothing
    End Function

    Private Function first_run()

        Dim user_appdpath1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live"
        Dim user_appdpath1_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\s3eq6%Rqn1hVr#RVypWn6&X.netf48"

        'Dim user_appdpath2 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live"
        'Dim user_appdpath2_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netf48"

        Dim opt As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\s3eq6%Rqn1hVr#RVypWn6&X.netf48"

        If Not File.Exists("ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48") Then

            If Directory.Exists(user_appdpath1) And File.Exists(user_appdpath1_db1) Then
                opt = user_appdpath1_db1

            Else
                If Not Directory.Exists(user_appdpath1) Then
                    IO.Directory.CreateDirectory(user_appdpath1)
                    bak_chk()
                    Return Nothing
                    Exit Function
                End If
            End If
        End If
        If Not Directory.Exists(user_appdpath1) Then
            System.IO.Directory.CreateDirectory(user_appdpath1)
        End If

        If File.Exists("ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48") Then
            Shell("attrib ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48 -s -r -h -a")
            'ile.SetAttributes("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", IO.FileAttributes.Normal)
            Call DecryptFile()
            Return Nothing
            Exit Function
        Else

            'If MsgBox("Data not found, it might have been deleted. Restore form backup?", MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel, "Critical") = MsgBoxResult.Yes Then

            'My.Computer.FileSystem.CopyFile(user_appdpath1_db1, "..\netfx")
            Try
                'Dim writeRes0 As New FileStream("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", FileMode.Create)
                'Dim binWrite0 As New BinaryWriter(writeRes0)
                'binWrite0.Write(opt)
                'binWrite0.Close()
                binreadwrite_create(opt, "ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48")
            Catch
                Application.Exit()
            End Try
            Call DecryptFile()
            'ElseIf MsgBoxResult.Cancel Then
            'Me.Dispose()
            'Application.Exit()
            'End If
            'ElseIf MsgBoxResult.No Then
            'Dim writeRes1 As New FileStream("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", FileMode.Create)
            'Dim binWrite1 As New BinaryWriter(writeRes1)
            'binWrite1.Write(My.Resources.data_pro_bak)
            '    binWrite1.Close()
            'DecryptFile()
            'End If

            'End If
        End If
        Return Nothing
    End Function

    Dim speechsynth = New SpeechSynthesizer

    Private Function bak_chk()
        speechsynth.Speak("Looks like you are new!. Let us configure PassVault for you...")
        Dim user_appdpath1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live"
        Dim user_appdpath1_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\s3eq6%Rqn1hVr#RVypWn6&X.netf48"

        'Dim user_appdpath2 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live"
        'Dim user_appdpath2_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netf48"

        If Not Directory.Exists(user_appdpath1) Then
            Directory.CreateDirectory(user_appdpath1)
        End If
        'If Not Directory.Exists(user_appdpath2) Then
        'System.IO.Directory.CreateDirectory(user_appdpath2)

        'End If

        'Dim writeRes0 As New FileStream("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", FileMode.Create)
        'Dim binWrite0 As New BinaryWriter(writeRes0)
        'binWrite0.Write(My.Resources.data_pro_bak)
        'binWrite0.Close()
        Call binreadwrite_create(My.Resources.data_pro_bak, "ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48")
        Shell("ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48 -r -s -h -a")
        'File.SetAttributes("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", IO.FileAttributes.Normal)
        'Dim writeRes1 As New FileStream(user_appdpath1_db1, FileMode.Create)
        'Dim binWrite1 As New BinaryWriter(writeRes1)
        'binWrite1.Write(My.Resources.data_pro_bak)
        'binWrite1.Close()
        Call binreadwrite_create(My.Resources.data_pro_bak, user_appdpath1_db1)
        Call DecryptFile()
        'Dim writeRes2 As New FileStream(user_appdpath2_db1, FileMode.Create)
        'Dim binWrite2 As New BinaryWriter(writeRes2)
        'binWrite2.Write(My.Resources.data_pro_bak)
        'binWrite2.Close()
        Return Nothing
    End Function

    Private Function run_as_admin2()
        If (WindowsIdentity.GetCurrent().Owner = WindowsIdentity.GetCurrent().User) Then ' Check Then For Admin privileges   

            Try

                Me.Visible = False
                Dim info As New ProcessStartInfo(Application.ExecutablePath) ' my own .exe
                info.UseShellExecute = True
                info.Verb = "runas"  ' invoke UAC prompt
                Process.Start(info)

            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Dispose()
                Application.Exit()

            End Try
        Else
            Return Nothing
            Exit Function
            '    MessageBox.Show("I have admin privileges :-)")
        End If
        Return Nothing
    End Function

    Private Sub run_as_admin()

        Dim wi = WindowsIdentity.GetCurrent()
        Dim wp = New WindowsPrincipal(wi)

        Dim runAsAdmin As Boolean = wp.IsInRole(WindowsBuiltInRole.Administrator)

        If runAsAdmin = 0 Then

            ' It Is Not possible to launch a ClickOnce app as administrator directly,
            ' so instead we launch the app as administrator in a New process.
            Dim processInfo = New ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase)

            ' The following properties run the New process as administrator
            processInfo.UseShellExecute = True
            processInfo.Verb = "runas"

            ' Start the New process
            Try
                'Application.CompanyName.Equals("BLASTEOROID CORPORATION")
                Process.Start(processInfo)

            Catch ex As Exception
                ' The user did Not allow the application to run as administrator
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Shut down the current process
                'Application.Current.Shutdown()

                Me.Dispose()
                Application.Exit()
            End Try

        Else

            'this is edited' We are running as administrator
            Application.SetCompatibleTextRenderingDefault(True)
            Application.EnableVisualStyles()
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic)
            Application.Run(New Login())
        End If
    End Sub

    Private Function quit_bak_save()
        Dim user_appdpath1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live"
        Dim user_appdpath1_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netf48"
        Dim work_dir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\s3eq6%Rqn1hVr#RVypWn6&X.netcon48"
        'Dim user_appdpath2 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live"
        'Dim user_appdpath2_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\ECq95#G4EB9WqVyX1h730σF3Vn2ApR6%R.netf48"
        'Dim user_appdpath2_db2 As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_lcc\ECq95#G4EB9WqVyX1h730σF3Vn2ApR6%R.netf48"

        Try
            'Dim user_appdpath1_db1 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\NET_FA\.com_microsoftVS_cred_live\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netf48"
            'Dim writeStream = New FileStream(user_appdpath1_db1, FileMode.Create)
            'Dim writeBinay As New BinaryWriter(writeStream)
            'writeBinay.Write("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48")
            'writeBinay.Close()
            'System.IO.File.SetLastAccessTime(user_appdpath1_db1, Date.Now)
            'Dim byts = File.ReadAllBytes("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48")
            'File.WriteAllBytes(user_appdpath1_db1, byts)
            binreadwrite_create("ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", user_appdpath1_db1)
            'Dim fs1 As FileStream = New FileStream("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.accdb", FileMode.Open, FileAccess.Read)
            'Dim fs2 As FileStream = New FileStream(user_appdpath1_db1, FileMode.Create, FileAccess.Write)
            'Dim brr As BinaryReader = New BinaryReader(fs1)
            'Dim brw As BinaryWriter = New BinaryWriter(fs2)
            'Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            'br.Close()
            'fs1.Close()
            'fs2.Close()
        Catch ex As Exception
            MsgBox("Cannot save backup", MsgBoxStyle.Critical)
        End Try
        'Try
        'Dim writeRes2 As New FileStream(user_appdpath2_db1, FileMode.Create)
        'Dim binWrite2 As New BinaryWriter(writeRes2)
        'binWrite2.Write("..\ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48")
        'binWrite2.Close()
        'System.IO.File.SetLastAccessTime(user_appdpath2_db1, Date.Now)

        'Catch ex As Exception
        'MsgBox("Cannot save backup", MsgBoxStyle.Critical)
        'End Try



        'File.Delete(work_dir)
        'Dim writeRes_3 As New FileStream(work_dir, FileMode.Append)
        'Dim binWrite_3 As New BinaryWriter(writeRes_3)
        'binWrite_3.Write(My.Resources.data_pro_bak)
        'binWrite_3.Close()
        binreadwrite_append(My.Resources.data_pro_bak, work_dir)


        File.Delete(work_dir)

        Shell("attrib ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48 +r +s +h +a")
        System.IO.File.SetLastWriteTime("ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", Date.Now)
        System.IO.File.SetLastAccessTime("ECVyXE4EB972ApWq1hq9530sF3Vn#R6%R.netsdk48", Date.Now)
        Return Nothing
    End Function

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AnimateWindow(Me.Handle.ToInt32, CInt(200), AW_BLEND_INT Or AW_HIDE_INT)
    End Sub

    Public Shared Function binreadwrite_create(dataPath, outpath)
        Dim fInfo As New FileInfo(dataPath)
        Dim numBytes As Long = fInfo.Length
        Dim fs As New FileStream(dataPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(CInt(numBytes))
        br.Close()
        fs.Close()
        Dim fs1 As System.IO.FileStream
        fs1 = New System.IO.FileStream(outpath, System.IO.FileMode.Create)
        fs1.Write(bytes, 0, bytes.Length)
        fs1.Close()
        Return Nothing
    End Function

    Private Shared Function binreadwrite_append(dataPath, outpath)
        Dim fInfo As New FileInfo(dataPath)
        Dim numBytes As Long = fInfo.Length
        Dim fs As New FileStream(dataPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(CInt(numBytes))
        br.Close()
        fs.Close()
        Dim fs1 As System.IO.FileStream
        fs1 = New System.IO.FileStream(outpath, System.IO.FileMode.Append)
        fs1.Write(bytes, 0, bytes.Length)
        fs1.Close()
        Return Nothing
    End Function

    Private Function filenaming()


        Return Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cnew.Show()
        Me.Hide()
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim path = System.AppDomain.CurrentDomain.BaseDirectory.ToString
        System.Diagnostics.Process.Start(path & "Pass Vault 21H2.html")
    End Sub
End Class



'http://vbcity.com/blogs/xtab/archive/2016/02/22/adding-files-to-the-appdata-folder.aspx