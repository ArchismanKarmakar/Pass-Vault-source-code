Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security

Public Class Main_add

    Private Sub Main_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Call cleartext()
        TextBox1.Focus()
        Main.ListView1.SelectedItems.Clear()
        TextBox4.PasswordChar = "X"
        AnimateWindow(Me.Handle.ToInt32, CInt(60), AW_BLEND_INT)
        Me.Focus()
    End Sub

    Private Function cleartext()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        Me.TextBox4.Clear()
        Me.TextBox5.Clear()
        Me.TextBox6.Clear()
        Me.TextBox7.Clear()
        Me.TextBox8.Clear()
        Me.TextBox9.Clear()
        Me.TextBox10.Clear()
        Label11.ResetText()
        Label12.ResetText()
        Label13.ResetText()
        'Label21.ResetText()
        'Label22.ResetText()
        'Label23.ResetText()
        'Label24.ResetText()
        'Label25.ResetText()
        Me.Focus()
        Return Nothing
    End Function

    Private Function add_sav()
        Try
            Call openconnection()
            encryptCard()
            encrypt_bigdata_details()


            OleDa.InsertCommand = New OleDbCommand()
            OleDa.InsertCommand.CommandText = "INSERT INTO table1 (id, title, uname, pass, web_app, url, email, contact, descrip, other_details, secq, created, modified)" &
                "VALUES (@id, @title, @uname, @pass, @web_app, @url, @email, @contact, @descrip, @other_details, @secq, @created, @modified)"

            OleDa.InsertCommand.Connection = OleCn
            OleDa.InsertCommand.Parameters.Add("@id", OleDbType.VarWChar, 500, "id").Value = TextBox1.Text
            OleDa.InsertCommand.Parameters.Add("@title", OleDbType.VarWChar, 500, "title").Value = TextBox2.Text
            OleDa.InsertCommand.Parameters.Add("@uname", OleDbType.VarWChar, 500, "uname").Value = TextBox3.Text
            OleDa.InsertCommand.Parameters.Add("@pass", OleDbType.VarWChar, 500, "pass").Value = TextBox4.Text
            OleDa.InsertCommand.Parameters.Add("@web_app", OleDbType.VarWChar, 500, "web_app").Value = TextBox5.Text
            OleDa.InsertCommand.Parameters.Add("@url", OleDbType.VarWChar, 500, "url").Value = TextBox6.Text
            OleDa.InsertCommand.Parameters.Add("@email", OleDbType.VarWChar, 500, "email").Value = TextBox7.Text
            OleDa.InsertCommand.Parameters.Add("@contact", OleDbType.VarWChar, 500, "contact").Value = TextBox8.Text
            OleDa.InsertCommand.Parameters.Add("@descrip", OleDbType.VarWChar, 5000, "descrip").Value = TextBox9.Text

            OleDa.InsertCommand.Parameters.Add("@other_details", OleDbType.VarWChar, 5000, "other_details").Value = TextBox10.Text

            OleDa.InsertCommand.Parameters.Add("@secq", OleDbType.VarWChar, 5000, "secq").Value = TextBox11.Text
            OleDa.InsertCommand.Parameters.Add("@created", OleDbType.VarWChar, 500, "created").Value = Label12.Text
            OleDa.InsertCommand.Parameters.Add("@modified", OleDbType.VarWChar, 500, "modified").Value = Label13.Text

            OleDa.InsertCommand.ExecuteNonQuery()
            Call Main.loadlistview()
            Call closeconnection()
            MsgBox("Records Saved", MsgBoxStyle.Information, "Information")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
            TextBox1.Focus()
        End Try
        Return Nothing
    End Function


    Private Function encrypt_bigdata_details()
        Dim encAES4, encAES5, encAES6, encAES7, encAES8 As String
        Try
            encAES4 = AESEncryptStringToBase64(TextBox2.Text)
            TextBox2.Text = ASEEncrypt4(encAES4)
            encAES4 = ""
            'TextBox4.Text = AESEncryptStringToBase64(encAES4)
            'encAES4 = ASEEncrypt4(TextBox4.Text)
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
        End Try
        Try
            encAES5 = AESEncryptStringToBase64(TextBox5.Text)
            TextBox5.Text = ASEEncrypt4(encAES5)
            encAES5 = ""
            'TextBox5.Text = AESEncryptStringToBase64(encAES5)
            'encAES5 = ASEEncrypt4(TextBox5.Text)
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
        End Try
        Try
            encAES6 = AESEncryptStringToBase64(TextBox6.Text)
            TextBox6.Text = ASEEncrypt4(encAES6)
            encAES6 = ""
            'TextBox6.Text = AESEncryptStringToBase64(encAES6)
            'encAES6 = ASEEncrypt4(TextBox6.Text)
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
        End Try
        Try
            encAES7 = AESEncryptStringToBase64(TextBox9.Text)
            TextBox9.Text = ASEEncrypt4(encAES7)
            encAES7 = ""
            'TextBox7.Text = AESEncryptStringToBase64(encAES7)
            'encAES7 = ASEEncrypt4(TextBox7.Text)
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
        End Try
        Try
            encAES8 = AESEncryptStringToBase64(TextBox10.Text)
            TextBox10.Text = ASEEncrypt4(encAES8)
            encAES8 = ""
            'TextBox8.Text = AESEncryptStringToBase64(encAES8)
            'encAES8 = ASEEncrypt4(TextBox8.Text)
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
        End Try
        Try
            encAES8 = AESEncryptStringToBase64(TextBox11.Text)
            TextBox11.Text = ASEEncrypt4(encAES8)
            encAES8 = ""
            'TextBox8.Text = AESEncryptStringToBase64(encAES8)
            'encAES8 = ASEEncrypt4(TextBox8.Text)
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            Call cleartext()
        End Try
        'Dim encAES4, encAES5, encAES6, encAES7, encAES8 As String
        'Try
        'encAES4 = AESEncryptStringToBase64(TextBox4.Text)
        'encAES5 = AESEncryptStringToBase64(TextBox5.Text)
        'encAES6 = AESEncryptStringToBase64(TextBox6.Text)
        'encAES7 = AESEncryptStringToBase64(TextBox7.Text)
        'encAES8 = AESEncryptStringToBase64(TextBox8.Text)
        'Catch
        '       MsgBox("Error")
        'End Try
        Return Nothing
    End Function


    Private Function encryptCard()

        Dim encAES1, encAES2 As String
        Try
            Try
                encAES1 = AESEncryptStringToBase64(TextBox3.Text)
                encAES1 = ASEEncrypt2(encAES1)
                TextBox3.Text = ASEEncrypt4(encAES1)
                encAES1 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                encAES2 = AESEncryptStringToBase64(TextBox4.Text)
                encAES2 = ASEEncrypt2(encAES2)
                TextBox4.Text = ASEEncrypt4(encAES2)
                encAES2 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                encAES1 = AESEncryptStringToBase64(TextBox7.Text)
                encAES1 = ASEEncrypt2(encAES1)
                TextBox7.Text = ASEEncrypt4(encAES1)
                encAES1 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                encAES2 = AESEncryptStringToBase64(TextBox8.Text)
                encAES2 = ASEEncrypt2(encAES2)
                TextBox8.Text = ASEEncrypt4(encAES2)
                encAES2 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function



    Private Function AESEncryptStringToBase64(strPlainText As String) As String
        Dim Algo As RijndaelManaged = RijndaelManaged.Create()
        Dim strKey As String = "AB!#(⌐+-`k|g~CD01@^ 648E23;<l>fG" '"YZlmnopq5rstuOPxyz79STU"

        With Algo
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 256
            .Mode = CipherMode.CBC
            .IV = Guid.NewGuid().ToByteArray()
            .Key = Encoding.ASCII.GetBytes(strKey)
            '.Padding = PaddingMode.PKCS7
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

    Private Function ASEEncrypt4(ByVal plaintext As String) As String
        Dim key As String = "H+£WbτQ3eσµΣtNc$wRfThzF)J@69C&jq"
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


    'Private Function ASEEncrypt3(ByVal input As String) As String
    'Dim AES As New System.Security.Cryptography.RijndaelManaged
    'Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
    'Dim encrypted As String = ""
    'Dim pass As String = "Rc!7(01@^⌐`k|g~;<l>t┼- i_m~CD+wX"
    'Try
    'Dim hash(31) As Byte
    'Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
    '       Array.Copy(temp, 0, hash, 0, 16)
    '      Array.Copy(temp, 0, hash, 15, 16)
    '     AES.Key = hash
    '    AES.Mode = Security.Cryptography.CipherMode.ECB
    'Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
    'Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
    '       encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
    '
    'Catch ex As Exception
    '       MsgBox("Error")
    'End Try
    'Return encrypted
    'End Function


    Private Function ASEEncrypt2(clearText As String) As String
        Dim EncryptionKey As String = "ABC/\|╬╧╨▲GHIUfgh◘╩╦╠2~!@#$%^&*1Jræsτ¶LM║45e§═ijktu◄KvqNX3╤∟«wxyz" '"0DabcdOPQRST789lmnop6EFYZÄ"
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label12.Text = DateTime.Now
        Label13.Text = DateTime.Now

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
            MsgBox("Please Fill in the required fields. NOTE: You can only keep Other Details, Contacts Given & Security Question section empty.", MsgBoxStyle.Information, "Form Not Filled Fully!")
            Exit Sub
        End If
        add_sav()

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button1.Enabled = True Then
            If MsgBox("Are you sure you want to end saving this?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Cancel") = MsgBoxResult.Yes Then

                cleartext()
                Me.Close()
                Main.ListView1.Focus()
            End If
        Else
            cleartext()
            Me.Close()
            Main.ListView1.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Button1.Enabled = True
        Label11.Text = TextBox2.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Main_Add_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                e.Handled = True
                e = Nothing
                Button3.PerformClick()
            End If
        End If
        If Button3.Enabled = True Then
            If e.Control = True Then
                If e.KeyCode = Keys.S Then
                    e.Handled = True
                    e = Nothing
                    Button1.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub Label26_Click_1(sender As Object, e As EventArgs) Handles Label26.Click
        If Label26.Text = "Show" Then
            Label26.Text = "Hide"
            TextBox4.PasswordChar = ""
        Else
            Label26.Text = "Show"
            TextBox4.PasswordChar = "X"
        End If
    End Sub


    Dim drag As Boolean
    Dim mouseX, mouseY As Integer


    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub


    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub heading_label_MouseDown(sender As Object, e As MouseEventArgs) Handles heading_label.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub


    Private Sub heading_label_MouseMove(sender As Object, e As MouseEventArgs) Handles heading_label.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub heading_label_MouseUp(sender As Object, e As MouseEventArgs) Handles heading_label.MouseUp
        drag = False
    End Sub

    Private Sub Label11_MouseDown(sender As Object, e As MouseEventArgs) Handles Label11.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Label11_MouseMove(sender As Object, e As MouseEventArgs) Handles Label11.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label11_MouseUp(sender As Object, e As MouseEventArgs) Handles Label11.MouseUp
        drag = False
    End Sub



    Private Sub heading_label_TextChanged(sender As Object, e As EventArgs) Handles heading_label.TextChanged
        'Label11.Text.Length = 628
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If Button3.Enabled = True Then

        End If
    End Sub

    Private Sub Main_add_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Main_add_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AnimateWindow(Me.Handle.ToInt32, CInt(200), AW_BLEND_INT Or AW_HIDE_INT)
    End Sub


    'Protected Sub Encrypt(sender As Object, e As EventArgs)
    '   lblEncryptedText.Text = Me.Encrypt(txtOriginalText.Text.Trim())
    'End Sub

    'Private Function Encrypt(clearText As String) As String
    '    Dim EncryptionKey As String = "MAKV2SPBNI99212"
    '   Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
    '  Using encryptor As Aes = Aes.Create()
    ' Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
    '&H65, &H64, &H76, &H65, &H64, &H65,
    '&H76})
    '       encryptor.Key = pdb.GetBytes(32)
    '      encryptor.IV = pdb.GetBytes(16)
    '     Using ms As New MemoryStream()
    '    Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
    '   cs.Write(clearBytes, 0, clearBytes.Length)
    '  cs.Close()
    ' End Using
    'clearText = Convert.ToBase64String(ms.ToArray())
    'End Using
    'E nd Using
    'Re turn clearText
    'End Function
    'Protected Sub Decrypt(sender As Object, e As EventArgs)
    '   lblDecryptedText.Text = Me.Decrypt(txtEncryptedText.Text.Trim())
    'End Sub

    'Private Function Decrypt(cipherText As String) As String
    'Dim EncryptionKey As String = "MAKV2SPBNI99212"
    'Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
    'Using encryptor As Aes = Aes.Create()
    'Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
    '&H65, &H64, &H76, &H65, &H64, &H65,
    '&H76})
    '           encryptor.Key = pdb.GetBytes(32)
    '          encryptor.IV = pdb.GetBytes(16)
    ' Using ms As New MemoryStream()
    'Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
    '               cs.Write(cipherBytes, 0, cipherBytes.Length)
    '              cs.Close()
    'End Using
    '           cipherText = Encoding.Unicode.GetString(ms.ToArray())
    'End Using
    'End Using
    'Return cipherText
    'End Function

End Class