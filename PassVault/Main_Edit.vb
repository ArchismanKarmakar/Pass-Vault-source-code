Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security
Imports System.Security.Principal

Public Class Main_Edit

    Protected Friend file2 As Integer

    Private Sub Main_Edit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call cleartext()
        Button1.Enabled = False
        TextBox1.Focus()
        Main.ListView1.SelectedItems.Clear()
        'Me.Dispose()
    End Sub

    Private Sub Main_Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        file2 = 0

        Call openconnection()
        Call Initialized()
        TextBox1.Text = CStr(Main.ListView1.SelectedItems(0).Text)
        Call Fill()
        Call closeconnection()
        decryptCard()
        decryp_bigdata_details()
        Button1.Enabled = False
        Label26.Text = "Show"
        TextBox4.PasswordChar = "X"

        Me.Focus()
        'PreVentFlicker()
        AnimateWindow(Me.Handle.ToInt32, CInt(70), AW_BLEND_INT)
    End Sub

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

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
        Me.TextBox11.Clear()
        Label11.ResetText()
        Label12.ResetText()
        Label13.ResetText()
        'Label21.ResetText()
        'Label22.ResetText()
        'Label23.ResetText()
        'Label24.ResetText()
        'Label25.ResetText()
        'Label26.ResetText()
        Me.Focus()
        Return Nothing
    End Function


    Private Function Fill()
        Dim OleDr As OleDbDataReader
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "SELECT * From table1 WHERE id = @id"
        OleDa.SelectCommand.Parameters.Add("@id", OleDbType.VarWChar, 500, "id").Value = TextBox1.Text
        OleDa.SelectCommand.Connection = OleCn
        OleDr = OleDa.SelectCommand.ExecuteReader()

        If OleDr.HasRows() Then
            OleDr.Read()
            TextBox1.Text = OleDr("id").ToString()
            TextBox2.Text = OleDr("title").ToString()
            TextBox3.Text = OleDr("uname").ToString()
            TextBox4.Text = OleDr("pass").ToString()
            TextBox5.Text = OleDr("web_app").ToString()
            TextBox6.Text = OleDr("url").ToString()
            TextBox7.Text = OleDr("email").ToString()
            TextBox8.Text = OleDr("contact").ToString()
            TextBox9.Text = OleDr("descrip").ToString()
            TextBox10.Text = OleDr("other_details").ToString()
            TextBox11.Text = OleDr("secq").ToString()
            Label12.Text = OleDr("created").ToString()
            Label13.Text = OleDr("modified").ToString()
            'If Not OleDr("file1").ToString() = "" Then
            'Label21.Text = "View"
            'Label21.ForeColor = Color.FromArgb(0, 148, 50)
            'End If
            'If Not OleDr("file2").ToString() = "" Then
            'Label22.Text = "View"
            'Label22.ForeColor = Color.FromArgb(0, 148, 50)
            'End If
            'If Not OleDr("file3").ToString() = "" Then
            'Label23.Text = "View"
            'Label23.ForeColor = Color.FromArgb(0, 148, 50)
            'End If
            'If Not OleDr("file4").ToString() = "" Then
            'Label24.Text = "View"
            'Label24.ForeColor = Color.FromArgb(0, 148, 50)
            'End If
            'If Not OleDr("file5").ToString() = "" Then
            'Label25.Text = "View"
            'Label25.ForeColor = Color.FromArgb(0, 148, 50)
            'End If
            'TextBox11.Text = Label11.Text
        End If
        OleDr.Close()
        Return Nothing
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button1.Enabled = True Then
            If MsgBox("Are you sure you want to discard.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Discard") = MsgBoxResult.Yes Then
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want to update.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Update") = MsgBoxResult.Yes Then
            Label13.Text = DateTime.Now

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox8.Text = "" Or TextBox11.Text = "" Then
                MsgBox("Please Fill in the required fields. NOTE: You can only keep Other Details, Contacts Given & Security Question section empty.", MsgBoxStyle.Information, "Form Not Filled Fully!")
                Exit Sub
            End If
            add_sav()
        End If
    End Sub


    Private Function add_sav()
        Try
            Call openconnection()
            encryptCard()
            encrypt_bigdata_details()


            OleDa.UpdateCommand = New OleDbCommand()
            OleDa.UpdateCommand.CommandText = "UPDATE table1 SET id = @id, title=@title, uname = @uname, pass = @pass, web_app = @web_app, url=@url, email=@email, contact=@contact, descrip = @descrip, other_details = @other_details, secq=@secq, created = @created, modified = @modified WHERE id = ?"
            OleDa.UpdateCommand.Connection = OleCn
            OleDa.UpdateCommand.Parameters.Add("@id", OleDbType.VarWChar, 500, "id").Value = TextBox1.Text
            OleDa.UpdateCommand.Parameters.Add("@title", OleDbType.VarWChar, 500, "title").Value = TextBox2.Text
            OleDa.UpdateCommand.Parameters.Add("@uname", OleDbType.VarWChar, 500, "uname").Value = TextBox3.Text
            OleDa.UpdateCommand.Parameters.Add("@pass", OleDbType.VarWChar, 500, "pass").Value = TextBox4.Text
            OleDa.UpdateCommand.Parameters.Add("@web_app", OleDbType.VarWChar, 500, "web_app").Value = TextBox5.Text
            OleDa.UpdateCommand.Parameters.Add("@url", OleDbType.VarWChar, 500, "url").Value = TextBox6.Text
            OleDa.UpdateCommand.Parameters.Add("@email", OleDbType.VarWChar, 500, "email").Value = TextBox7.Text
            OleDa.UpdateCommand.Parameters.Add("@contact", OleDbType.VarWChar, 500, "contact").Value = TextBox8.Text
            OleDa.UpdateCommand.Parameters.Add("@descrip", OleDbType.VarWChar, 5000, "descrip").Value = TextBox9.Text

            OleDa.UpdateCommand.Parameters.Add("@other_details", OleDbType.VarWChar, 5000, "other_details").Value = TextBox10.Text

            OleDa.UpdateCommand.Parameters.Add("@secq", OleDbType.VarWChar, 5000, "secq").Value = TextBox11.Text
            OleDa.UpdateCommand.Parameters.Add("@created", OleDbType.VarWChar, 500, "created").Value = Label12.Text
            OleDa.UpdateCommand.Parameters.Add("@modified", OleDbType.VarWChar, 500, "modified").Value = Label13.Text

            OleDa.UpdateCommand.Parameters.Add(New System.Data.OleDb.OleDbParameter("EmpID", System.Data.OleDb.OleDbType.VarWChar, 500,
                                                System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "id",
                                                System.Data.DataRowVersion.Original, Nothing)).Value = Main.ListView1.SelectedItems(0).Text


            OleDa.UpdateCommand.ExecuteNonQuery()
            Call Main.loadlistview()
            Call closeconnection()
            MsgBox("Records Updated")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call closeconnection()
            TextBox1.Focus()
            TextBox1.SelectAll()
        End Try
        Return Nothing
    End Function

    Private Function decryptCard()
        Dim encAES1, encAES2, encAES_1, encAES_2 As String
        Try
            Try
                encAES1 = AESDecrypt4(TextBox3.Text)
                encAES1 = AESDecrypt2(encAES1)
                TextBox3.Text = AESDecryptBase64ToString(encAES1)
                encAES1 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                encAES2 = AESDecrypt4(TextBox4.Text)
                encAES2 = AESDecrypt2(encAES2)
                TextBox4.Text = AESDecryptBase64ToString(encAES2)
                encAES2 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                encAES_1 = AESDecrypt4(TextBox7.Text)
                encAES_1 = AESDecrypt2(encAES_1)
                TextBox7.Text = AESDecryptBase64ToString(encAES_1)
                encAES_1 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                encAES_2 = AESDecrypt4(TextBox8.Text)
                encAES_2 = AESDecrypt2(encAES_2)
                TextBox8.Text = AESDecryptBase64ToString(encAES_2)
                encAES_2 = ""
            Catch ex As Exception
                MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Private Function decryp_bigdata_details()
        Dim encAES4, encAES5, encAES6, encAES7, encAES8 As String
        Try
            encAES4 = AESDecrypt4(TextBox2.Text)
            TextBox2.Text = AESDecryptBase64ToString(encAES4)
            encAES4 = ""
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            encAES5 = AESDecrypt4(TextBox5.Text)
            TextBox5.Text = AESDecryptBase64ToString(encAES5)
            encAES5 = ""
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            encAES6 = AESDecrypt4(TextBox6.Text)
            TextBox6.Text = AESDecryptBase64ToString(encAES6)
            encAES6 = ""
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            encAES7 = AESDecrypt4(TextBox9.Text)
            TextBox9.Text = AESDecryptBase64ToString(encAES7)
            encAES7 = ""
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            encAES7 = AESDecrypt4(TextBox10.Text)
            TextBox10.Text = AESDecryptBase64ToString(encAES7)
            encAES7 = ""
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            encAES8 = AESDecrypt4(TextBox11.Text)
            TextBox11.Text = AESDecryptBase64ToString(encAES8)
            encAES8 = ""
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Try
        'encAES8 = AESDecrypt4(TextBox10.Text)
        'TextBox10.Text = AESDecryptBase64ToString(encAES8)
        'encAES8 = ""
        'Catch ex As Exception
        'MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '    Try
        '   encAES8 = AESDecrypt4(TextBox11.Text)
        '  TextBox11.Text = AESDecryptBase64ToString(encAES8)
        ' Label11.Text = TextBox11.Text
        'encAES8 = ""
        'Catch ex As Exception
        'MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'Try

        'TextBox4.Text = AESDecrypt4(encAES4)
        'TextBox5.Text = AESDecrypt4(encAES5)
        'TextBox6.Text = AESDecrypt4(encAES6)
        'TextBox7.Text = AESDecrypt4(encAES7)
        'TextBox8.Text = AESDecrypt4(encAES8)

        'encAES3 = AESDecrypt2(encAES3)
        'encAES4 = AESDecrypt2(encAES4)
        'encAES5 = AESDecrypt2(encAES5)

        'TextBox4.Text = AESDecryptBase64ToString(encAES4)
        'TextBox5.Text = AESDecryptBase64ToString(encAES5)
        'TextBox6.Text = AESDecryptBase64ToString(encAES6)
        'TextBox7.Text = AESDecryptBase64ToString(encAES7)
        'TextBox8.Text = AESDecryptBase64ToString(encAES8)
        'Catch ex As Exception
        '  MsgBox("Error")
        'End Try
        Return Nothing
    End Function

    Private Function encrypt_bigdata_details()
        'Dim encAES4, encAES5, encAES6, encAES7, encAES8 As String
        'Try

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
        'TextBox4.Text = ASEEncrypt4(encAES4)
        'TextBox5.Text = ASEEncrypt4(encAES5)
        'TextBox6.Text = ASEEncrypt4(encAES6)
        'TextBox7.Text = ASEEncrypt4(encAES7)
        'TextBox8.Text = ASEEncrypt4(encAES8)

        'encAES3 = ASEEncrypt2(encAES3)
        'encAES4 = ASEEncrypt2(encAES4)
        'encAES5 = ASEEncrypt2(encAES5)


        'Catch
        'MsgBox("Error")
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



    Private Function AESDecrypt4(ByVal ciphertext As String) As String
        Dim key As String = "H+£WbτQ3eσµΣtNc$wRfThzF)J@69C&jq" '"H+MbQ$C&jq3t69zNcRfThWmwF)J@eZUX" '"H+M£óWmπΓbτQα3eZUX µΘtNc≥$╢╩w±⌐ßRfThzσF)J@Φ69C&jqΣ"
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim SHA256 As New System.Security.Cryptography.SHA256Cng
        Dim plaintext As String = ""
        Dim iv As String = ""
        Try
            Dim ivct = ciphertext.Split({"=="}, StringSplitOptions.None)
            iv = ivct(0) & "=="
            ciphertext = If(ivct.Length = 3, ivct(1) & "==", ivct(1))

            AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))
            AES.IV = Convert.FromBase64String(iv)
            AES.Mode = Security.Cryptography.CipherMode.CBC
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(ciphertext)
            plaintext = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return plaintext
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

    Private Function AESDecrypt2(cipherText As String) As String
        Dim EncryptionKey As String = "ABC/\|╬╧╨▲GHIUfgh◘╩╦╠2~!@#$%^&*1Jræsτ¶LM║45e§═ijktu◄KvqNX3╤∟«wxyz" '"0DabcdOPQRST789lmnop6EFYZÄ"
        Dim cipherBytes As Byte()
        cipherBytes = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H36, &H81, &H65, &H6F, &H25, &H4E,
         &H68, &H61, &H76, &H65, &H64, &H62,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
        cipherText = ""
    End Function

    Private Function AESDecrypt3(ByVal input As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Dim pass As String = "Rc!7(01@^⌐`k|g~;<l>t┼- i_m~CD+wX"
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            input = ""
            decrypted = ""
        Catch ex As Exception
            MsgBox("Error")
            input = ""
            decrypted = ""
            Return Nothing
        End Try
        Return decrypted
        input = ""
        decrypted = ""
    End Function


    Private Function ASEEncrypt3(ByVal input As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Dim pass As String = "Rc!7(01@^⌐`k|g~;<l>t┼- i_m~CD+wX"
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            input = ""
            decrypted = ""
        Catch ex As Exception
            input = ""
            decrypted = ""
            MsgBox("Error")
        End Try
        Return decrypted
        input = ""
        decrypted = ""
    End Function


    Private Function AESEncryptStringToBase64(strPlainText As String) As String
        Dim Algo As RijndaelManaged = RijndaelManaged.Create()
        Dim strKey As String = "AB!#(⌐+-`k|g~CD01@^ 648E23;<l>fG"
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

    Private Function AESDecryptBase64ToString(strCipherText As String) As String
        Dim arrSaltAndCipherText As Byte() = Convert.FromBase64String(strCipherText)
        Dim strKey As String = "AB!#(⌐+-`k|g~CD01@^ 648E23;<l>fG"

        Dim Algo As RijndaelManaged = RijndaelManaged.Create()

        With Algo
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 256
            .Mode = CipherMode.CBC
            .IV = arrSaltAndCipherText.Take(16).ToArray()
            .Key = Encoding.ASCII.GetBytes(strKey)
            '.Padding = PaddingMode.None
        End With


        Using Decryptor As ICryptoTransform = Algo.CreateDecryptor()
            Using MemStream As New MemoryStream(arrSaltAndCipherText.Skip(16).ToArray())
                Using CryptStream As New CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read)
                    Using Reader As New StreamReader(CryptStream)
                        AESDecryptBase64ToString = Reader.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
        strCipherText = ""
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

    'Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
    'If CheckBox1.Checked = True Then
    'TextBox10.Enabled = False
    'Else
    'TextBox10.Enabled = True
    'End If
    'End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        If Label26.Text = "Show" Then
            Label26.Text = "Hide"
            TextBox4.PasswordChar = ""
        Else
            Label26.Text = "Show"
            TextBox4.PasswordChar = "X"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Enabled = True
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Main_Edit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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


    Private Sub Label11_MouseUp(sender As Object, e As MouseEventArgs) Handles Label11.MouseUp
        drag = False
    End Sub

    Private Sub Main_Edit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AnimateWindow(Me.Handle.ToInt32, CInt(200), AW_HIDE_INT Or AW_BLEND_INT)
    End Sub
End Class