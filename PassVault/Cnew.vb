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


Public Class Cnew

    Dim provider
    Private OleCnusfn As New OleDbConnection
    Private OleDausfn As New OleDbDataAdapter

    Private Sub Cnew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call openconnection()
        'Call Initialized()
        'TextBox1.Text = CStr(Main.ListView1.SelectedItems(0).Text)
        'Call fillusf()
        'Call closeconnection()
    End Sub

    Private Function filecon1() As String
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=..\netfx\s3eq6%Rqn1hVr#RVypWn6&X.netsdk48db;Jet OLEDB:Database Password=tmzS~u%sw<n6&rs3e^9&"
        Return provider
        'Return Nothing
    End Function

    Private Sub Initialized()
        OleDausfn.SelectCommand = New OleDbCommand
        OleDausfn.SelectCommand.CommandText = "SELECT * FROM table1"
        OleDausfn.SelectCommand.Connection = OleCn
    End Sub
    Private Sub closeconnection()
        OleCnusfn.Close()
    End Sub

    Public Sub Listpasscolumns(ByVal Lv As ListView)
        With Lv
            .Columns.Add("id", 60)
            '.Columns.Add("uname", 250)
            '.Columns.Add("pass", 250)
            .Columns.Add("title", 350)
            .Columns.Add("web_app", 500)
            .Columns.Add("url", 200)
            '.Columns.Add("descrip", 500)
            '.Columns.Add("contact", 120)
            '.Columns.Add("other_details", 500)
            '.Columns.Add("secq", 120)
            .Columns.Add("created", 150)
            .Columns.Add("modified", 150)
            .FullRowSelect = True
            .MultiSelect = True
            .GridLines = True
            .HideSelection = False
            .View = View.Details
        End With
    End Sub

    Private Sub openconnection()
        'HavingInternetConnection()
        If OleCnusfn.State <> ConnectionState.Open Then
            OleCnusfn.ConnectionString = filecon1()
            OleCnusfn.Open()
        End If
    End Sub


    Protected Friend uname, up, fp, fn As String

    Private Function fillusf()


        Dim OleDr As OleDbDataReader
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "SELECT * From table1 WHERE id = @id"
        'OleDa.SelectCommand.Parameters.Add("@id", OleDbType.VarWChar, 500, "id").Value = TextBox1.Text
        OleDa.SelectCommand.Connection = OleCn
        OleDr = OleDa.SelectCommand.ExecuteReader()

        If OleDr.HasRows() Then
            OleDr.Read()
            uname = OleDr("id").ToString()
            up = OleDr("up").ToString()
            fn = OleDr("fn").ToString
            fp = OleDr("fp").ToString()

        End If
        OleDr.Close()
        Return Nothing
    End Function

    Private Function randomgen()
        Dim rand As New Random
        Dim key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_&#@-"
        Dim flen, flenp As Integer
        flen = 30
        flenp = 25
        For i = 0 To flen
            fn &= key(rand.Next(0, key.Length))
        Next
        For i = 0 To flen
            fp &= key(rand.Next(0, key.Length))
        Next
        Return Nothing
    End Function

    Private Function encrypt()
        Dim fn1, fp1 As String
        Try
            fn1 = AESEncryptStringToBase64(fn)
            fn1 = ASEEncrypt2(fn1)
            fn = ASEEncrypt4(fn1)
            fn1 = ""
            fp1 = AESEncryptStringToBase64(fp)
            fp1 = ASEEncrypt2(fp1)
            fp = ASEEncrypt4(fp1)
            fp1 = ""
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Function newuser()
        Call randomgen()
        Call encrypt()
        Label1.Text = DateTime.Now
        Label2.Text = DateTime.Now
        Try
            Call openconnection()
            'encryptCard()
            'encrypt_bigdata_details()

            OleDa.InsertCommand = New OleDbCommand()
            OleDa.InsertCommand.CommandText = "INSERT INTO table1 (id, up, fn, fp, uem, uc, uvdn created, modified)" &
                "VALUES (@id, @up, @fn, @fp, @uem, @uc, @uvdn, @created, @modified)"

            OleDa.InsertCommand.Connection = OleCn
            OleDa.InsertCommand.Parameters.Add("@id", OleDbType.VarWChar, 500, "id").Value = TextBox1.Text
            OleDa.InsertCommand.Parameters.Add("@up", OleDbType.VarWChar, 500, "up").Value = TextBox2.Text
            OleDa.InsertCommand.Parameters.Add("@fn", OleDbType.VarWChar, 500, "fn").Value = fn
            OleDa.InsertCommand.Parameters.Add("@fp", OleDbType.VarWChar, 500, "fp").Value = fp
            OleDa.InsertCommand.Parameters.Add("@uem", OleDbType.VarWChar, 500, "uem").Value = TextBox3.Text
            OleDa.InsertCommand.Parameters.Add("@uc", OleDbType.VarWChar, 500, "uc").Value = TextBox4.Text
            OleDa.InsertCommand.Parameters.Add("@uvdn", OleDbType.VarWChar, 500, "uvdn").Value = TextBox5.Text

            OleDa.InsertCommand.Parameters.Add("@created", OleDbType.VarWChar, 500, "created").Value = Label1.Text
            OleDa.InsertCommand.Parameters.Add("@modified", OleDbType.VarWChar, 500, "modified").Value = Label2.Text

            OleDa.InsertCommand.ExecuteNonQuery()
            Call Main.loadlistview()
            Call closeconnection()
            MsgBox("Records Saved", MsgBoxStyle.Information, "Information")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            'TextBox1.Focus()
            'TextBox1.SelectAll()
        End Try
        Return Nothing
    End Function


    Private Function AESEncryptStringToBase64(strPlainText As String) As String
        Dim Algo As RijndaelManaged = RijndaelManaged.Create()
        Dim strKey As String = "AB!#(CDl>⌐+-`01@^ 648E~f23;<k|gG"
        With Algo
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 256
            .Mode = CipherMode.CBC
            .IV = Guid.NewGuid().ToByteArray()
            .Key = Encoding.ASCII.GetBytes(strKey)
            '.Padding = PaddingMode.None
        End With


        Using Encryptor As ICryptoTransform = Algo.CreateEncryptor()
            Using MemStream As New MemoryStream
                Using CryptStream As New CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write)
                    Using Writer As New StreamWriter(CryptStream)
                        Writer.Write(strPlainText)
                    End Using

                    AESEncryptStringToBase64 = Convert.ToBase64String(Algo.IV.Concat(MemStream.ToArray()).ToArray())
                End Using
            End Using
        End Using
        strPlainText = ""
    End Function

    Private Function ASEEncrypt2(clearText As String) As String
        Dim EncryptionKey As String = "ABC/%^&*1╧τ¶LM║45╠2~!@#$ye§═ijIUfgh◘ktx\|╬X3╤∟«wGH╨▲u◄KvqNJræs╩╦z" '"0DabcdOPQRST789lmnop6EFYZÄ"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H36, &H81, &H65, &H6F, &H25, &H4E,
         &H68, &H61, &H76, &H65, &H64, &H62,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
        clearText = ""
    End Function


    Private Function ASEEncrypt4(ByVal plaintext As String) As String
        Dim key As String = "H+£WeσtNT$bτQ9Cf3wR&jc)J@6hzFµΣq"
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim SHA256 As New System.Security.Cryptography.SHA256Cng
        Dim ciphertext As String = ""
        Try
            AES.GenerateIV()
            AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))

            AES.Mode = Security.Cryptography.CipherMode.CBC
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext)
            ciphertext = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

            Return Convert.ToBase64String(AES.IV) & Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            ciphertext = ""
            plaintext = ""
        Catch ex As Exception
            ciphertext = ""
            plaintext = ""
            Return ex.Message
        End Try
        ciphertext = ""
        plaintext = ""
    End Function

End Class