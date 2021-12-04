Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security
'Imports System.Runtime.InteropServices
'Imports System.Runtime.InteropService.DllImport
''
Public Class Main
    Protected Friend mode As String
    'Public winapi As New WinAPI


    Dim Oledr As OleDbDataReader
    Dim item As New ListViewItem
    Dim itemsearch As New ListViewItem

    'Private Sub SomeSub()
    'Dim Mycollection As Object()
    ' I'm calling the function from the MainClass here.
    'Dim flags = WinAPI.AW_ACTIVATE|WinAPI.AW_HOR_POSITIVE
    'winapi.AnimateWindow(Me.Handle, animationTime, flags)
    'End Sub


    Private Function ListViewRowNaming()
        ListView1.Columns(0).Text = "ID"
        'ListView1.Columns(1).Text = "Username"
        'ListView1.Columns(2).Text = "Password"
        ListView1.Columns(1).Text = "Title"
        ListView1.Columns(2).Text = "Site/App Name"
        ListView1.Columns(3).Text = "URL"
        'ListView1.Columns(4).Text = "Description"
        'ListView1.Columns(5).Text = "Contact Details given"
        'ListView1.Columns(6).Text = "Other Details"
        'ListView1.Columns(7).Text = "Security Question with Ans"
        ListView1.Columns(4).Text = "Created On"
        ListView1.Columns(5).Text = "Modified On"
        Return Nothing
    End Function

    Private Function appearance()
        Dim i As Integer
        For i = 0 To ListView1.Items.Count - 1
            If i Mod 2 = 0 Then
                ListView1.Items(i).BackColor = Color.FromArgb(42, 77, 61)
                ListView1.Items(i).UseItemStyleForSubItems = True
            Else
                ListView1.Items(i).BackColor = Color.FromArgb(31, 35, 56)
                ListView1.Items(i).UseItemStyleForSubItems = True
            End If
        Next
        Dim a As New Drawing.Bitmap(1, 1)
        Dim b As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(a)
        'b.CopyFromScreen(New Drawing.Point(MousePosition.X, MousePosition.Y), New Drawing.Point(0, 0), a.Size)
        b.CopyFromScreen(New Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height), New Drawing.Point(0, 0), a.Size)
        Dim c As Drawing.Color = a.GetPixel(0, 0)
        Panel2.BackColor = c
        Panel3.BackColor = c
        'TextBox2.Text = Panel2.BackColor.Name
        Return Nothing
    End Function

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'HavingInternetConnection()
        'Me.Height = h
        'Me.Width = b

        Call Listpasscolumns(ListView1)
        Call openconnection()
        Call Initialized()
        Call loadlistview()
        Call closeconnection()
        'RadioButton1.Checked = True
        AnimateWindow(Me.Handle.ToInt32, CInt(70), AW_BLEND_INT)
    End Sub

    Private Function HavingInternetConnection() As Boolean
        Return 0
        Dim loop1 As Integer
        loop1 = 1
a:
        While (loop1 = 1)
            Return 0
            If My.Computer.Network.IsAvailable Then
                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        Me.Hide()
                        Return True
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

    Public Function loadlistview()
        ListView1.Items.Clear()
        Call Initialized()
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            item = ListView1.Items.Add(Oledr("id").ToString)
            'item.SubItems.Add(Oledr("uname").ToString)
            'item.SubItems.Add(Oledr("pass").ToString)
            item.SubItems.Add(Oledr("title").ToString)
            item.SubItems.Add(Oledr("web_app").ToString)
            item.SubItems.Add(Oledr("url").ToString)
            'item.SubItems.Add(Oledr("descrip").ToString)
            'item.SubItems.Add(Oledr("contact").ToString)
            'item.SubItems.Add(Oledr("other_details").ToString)
            'item.SubItems.Add(Oledr("secq").ToString)
            item.SubItems.Add(Oledr("created").ToString)
            item.SubItems.Add(Oledr("modified").ToString)

        Loop
        ListViewRowNaming()
        appearance()
        decrypt_tbdt()

        Oledr.Close()
        Return Nothing
    End Function
    'Dim base64EncryptedString As String = dbtable.Rows(2).ToBase64
    'Public Sub DecryptCard()
    'Dim DES As New System.Security.Cryptography.TripleDESCryptoServiceProvider
    'Dim Hash As New System.Security.Cryptography.MD5CryptoServiceProvider
    'Dim MyKey As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#()+-;<=>@^_`{|}~"
    'Dim MyKey As String = "AB!#(⌐+-`k|g~CD01@^ 648E23;<=>fG"
    'Try
    'dencAES1 = AESDecryptBase64ToString(dbtable.Rows(2)("pass").ToString(), MyKey)
    'dencAES2 = AESDecryptBase64ToString(dbtable.Rows(1)("uname").ToString(), MyKey)

    'DES.Key = Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(My.Settings.SettingsKey))
    'DES.Mode = System.Security.Cryptography.CipherMode.ECB
    ' Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = DES.CreateDecryptor
    ''   Dim Buffer1 As Byte() = Convert.FromBase64String(dencAES1)
    '    Dim Buffer2 As Byte() = Convert.FromBase64String(dencAES2)
    '     Buffer1 = Convert.FromBase64String(dbtable.Rows(2)("pass").ToString())
    '      Buffer2 = Convert.FromBase64String(dbtable.Rows(1)("uname").ToString())
    '       dbtable.Rows(2)("pass") = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer1, 0, Buffer1.Length))
    '        dbtable.Rows(1)("uname") = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer2, 0, Buffer2.Length))
    '     Catch ex As Exception
    '          MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '       End Try
    '    End Sub

    'Dim input_pass, input_uname, encAES1, encAES2, dencAES1, dencAES2 As String


    'Private Sub encryptCard()
    'Dim MyKey As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#()+-;<=>@^_`{|}~"
    '    Dim MyKey As String = "AB!#(⌐+-`k|g~CD01@^ 648E23;<=>fG"



    '    Try
    '         Dim DES As New System.Security.Cryptography.TripleDESCryptoServiceProvider
    '          Dim Hash As New System.Security.Cryptography.MD5CryptoServiceProvider
    '           Dim encryptedCard1 As String
    '            Dim encryptedCard2 As String

    'DES.Key = Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(My.Settings.SettingsKey))
    'DES.Mode = System.Security.Cryptography.CipherMode.ECB
    '
    '       Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = DES.CreateDecryptor
    '        Dim Buffer1 As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input_pass)
    '         Dim Buffer2 As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input_uname)
    '          encryptedCard1 = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer1, 0, Buffer1.Length))
    '           encryptedCard2 = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer2, 0, Buffer2.Length))
    '
    'encAES1 = AESEncryptStringToBase64(encryptedCard1, MyKey)
    'encAES2 = AESEncryptStringToBase64(encryptedCard2, MyKey)
    '
    ' Catch ex As Exception
    '      MessageBox.Show("The following error(s) have occurred: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '   End Try
    'End Sub


    'Dim dbtable As New DataTable


    Private Function update_db() As Boolean
        If ListView1.Items.Count = 0 Then
            MsgBox("No records.", MsgBoxStyle.Information, "No records")
            Return True
            Exit Function

        End If
        If ListView1.SelectedItems.Count > 1 Then
            MsgBox("Double click the record(s)", MsgBoxStyle.Information)
            ListView1.SelectedItems.Clear()
            Return True
            Exit Function
        End If
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Please choose the records you want to check", MsgBoxStyle.Exclamation)
            Return True
            Exit Function
        End If
        Return Nothing
    End Function

    Private Function Delete() As Boolean
        If ListView1.Items.Count = 0 Then
            MsgBox("No records to delete", MsgBoxStyle.Information)
            Return True
            Exit Function
        End If

        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Please select atleast one record to delete.", MsgBoxStyle.Exclamation)
            Return True
            Exit Function
        End If
        Return Nothing
    End Function

    Private Sub form_reset(ByVal form_name As Form)
        form_name.Dispose()
        'form_name.Show()
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeconnection()

        Login.Show()
        Me.Dispose()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'TextBox2.Clear()

        'OleDa.SelectCommand = New OleDbCommand()
        'OleDa.SelectCommand.CommandText = "SELECT * FROM table1 WHERE id Like '&&'"
        'OleDa.SelectCommand.Connection = OleCn
        'Call openconnection()
        'OleDa.SelectCommand.ExecuteNonQuery()
        'Call search1()
        'Call closeconnection()
        search2()


    End Sub


    '========================================================================================================================================================='
    '========================================================================================================================================================='


    ''THE BEST AES ECC''
    ''
    ''CAUTION'' DO NOT MODIFY THIS SECTION''



    'Private Function AESEncryptStringToBase64(strPlainText As String, strKey As String) As String
    'Dim Algo As RijndaelManaged = RijndaelManaged.Create()

    'With Algo
    '.BlockSize = 128
    '.FeedbackSize = 128
    '.KeySize = 256
    '.Mode = CipherMode.CBC
    '.IV = Guid.NewGuid().ToByteArray()
    '.Key = Encoding.ASCII.GetBytes(strKey)
    'End With
    '
    '
    'Using Encryptor As ICryptoTransform = Algo.CreateEncryptor()
    'Using MemStream As New MemoryStream
    'Using CryptStream As New CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write)
    'Using Writer As New StreamWriter(CryptStream)
    '                   Writer.Write(strPlainText)
    'End Using
    '
    '               AESEncryptStringToBase64 = Convert.ToBase64String(Algo.IV.Concat(MemStream.ToArray()).ToArray())
    'End Using
    'End Using
    'End Using
    'End Function

    Private Function AESDecryptBase64ToString(strCipherText As String, strKey As String) As String
        Dim arrSaltAndCipherText As Byte() = Convert.FromBase64String(strCipherText)

        Dim Algo As RijndaelManaged = RijndaelManaged.Create()

        With Algo
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 256
            .Mode = CipherMode.CBC
            .IV = arrSaltAndCipherText.Take(16).ToArray()
            .Key = Encoding.ASCII.GetBytes(strKey)
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
        Dispose(strCipherText)
    End Function






    'Private Function AESD(ByVal ciphertext As String, ByVal key As String) As String
    'Dim AES As New System.Security.Cryptography.RijndaelManaged
    'Dim SHA256 As New System.Security.Cryptography.SHA256Cng
    'Dim plaintext As String = ""
    'Dim iv As String = ""
    'Try
    'Dim ivct = ciphertext.Split({"=="}, StringSplitOptions.None)
    '       iv = ivct(0) & "=="
    '      ciphertext = If(ivct.Length = 3, ivct(1) & "==", ivct(1))
    '
    '       AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))
    '      AES.IV = Convert.FromBase64String(iv)
    '     AES.Mode = Security.Cryptography.CipherMode.CBC
    'Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
    'Dim Buffer As Byte() = Convert.FromBase64String(ciphertext)
    '       plaintext = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
    'Return plaintext
    'Catch ex As Exception
    'Return ex.Message
    'End Try
    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mode = "+"
        Main_add.ShowDialog()
        ListView1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If update_db() = True Then
            ListView1.Focus()
            Return
        End If
        mode = "/"
        Main_Edit.ShowDialog()
        ListView1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Delete() = True Then
            ListView1.Focus()
            Return
        End If
        perform_delete_action()
        ListView1.Focus()
    End Sub

    Private Function perform_delete_action()
        If MsgBox("Do you really want to delete this record(s)?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Delete?") = MsgBoxResult.No Then
            MsgBox("Delete Cancelled.", MsgBoxStyle.Critical)
            ListView1.SelectedItems.Clear()
            Return Nothing
            Exit Function
        End If
        For Each item As ListViewItem In ListView1.SelectedItems
            item.Remove()
            OleDa.DeleteCommand = New OleDbCommand
            Call openconnection()
            OleDa.DeleteCommand.CommandText = "DELETE FROM table1 where id=@id"
            OleDa.DeleteCommand.Connection = OleCn
            OleDa.DeleteCommand.Parameters.Add("@id", OleDbType.VarChar, 50, "id").Value = item.Text.ToString()
            OleDa.DeleteCommand.ExecuteNonQuery()
            Call loadlistview()
            Call closeconnection()
        Next
        MsgBox("Selected Record(s) Deleted", MsgBoxStyle.Exclamation)
        ListView1.SelectedItems.Clear()
        Return Nothing
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call openconnection()
        Call Initialized()
        Call loadlistview()
        Call closeconnection()
        TextBox1.Clear()
        MsgBox("Total Records =  " & ListView1.Items.Count, MsgBoxStyle.Information)
        ListView1.Focus()
    End Sub



    Private Function search1()
        ListView1.Items.Clear()
        Call Initialized()
        OleDa.SelectCommand.CommandText = "Select * FROM table1 WHERE id Like '%%" & TextBox1.Text.Trim.ToString() & "%%'"

        OleDa.SelectCommand.Connection = OleCn
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            itemsearch = ListView1.Items.Add(Oledr("id").ToString())
            'itemsearch.SubItems.Add(Oledr("uname").ToString())
            'itemsearch.SubItems.Add(Oledr("pass").ToString())
            itemsearch.SubItems.Add(Oledr("title").ToString())
            itemsearch.SubItems.Add(Oledr("web_app").ToString())
            itemsearch.SubItems.Add(Oledr("url").ToString())
            'itemsearch.SubItems.Add(Oledr("descrip").ToString())
            'itemsearch.SubItems.Add(Oledr("contact").ToString())
            'itemsearch.SubItems.Add(Oledr("other_details").ToString())
            'itemsearch.SubItems.Add(Oledr("secq").ToString())
            itemsearch.SubItems.Add(Oledr("created").ToString())
            itemsearch.SubItems.Add(Oledr("modified").ToString())
        Loop
        decrypt_tbdt()
        Oledr.Close()
        Return Nothing
    End Function

    Private Function search2()
        'Dim lv As New ListView
        'For i = 0 To ListView1.Items.Count - 1
        'lv.Items.Add(ListView1.Items(i))

        'Next
        'ListView1.Items.Clear()

        'Call Initialized()
        'OleDa.SelectCommand.CommandText = "SELECT * FROM table1 WHERE title Like '%%" & TextBox1.Text.Trim.ToString() & "%%'"

        'OleDa.SelectCommand.Connection = OleCn
        'Oledr = OleDa.SelectCommand.ExecuteReader()
        'Do While Oledr.Read()
        'itemsearch = ListView1.Items.Add(Oledr("id").ToString())
        'itemsearch.SubItems.Add(Oledr("uname").ToString())
        'itemsearch.SubItems.Add(Oledr("pass").ToString())
        'itemsearch.SubItems.Add(Oledr("title").ToString())
        'itemsearch.SubItems.Add(Oledr("web_app").ToString())
        'itemsearch.SubItems.Add(Oledr("url").ToString())
        'itemsearch.SubItems.Add(Oledr("descrip").ToString())
        'itemsearch.SubItems.Add(Oledr("contact").ToString())
        'itemsearch.SubItems.Add(Oledr("other_details").ToString())
        'itemsearch.SubItems.Add(Oledr("secq").ToString())
        'itemsearch.SubItems.Add(Oledr("created").ToString())
        'itemsearch.SubItems.Add(Oledr("modified").ToString())
        'Loop
        'decrypt_tbdt()


        Dim searchText = TextBox1.Text

        If searchText = String.Empty Then
            'Don't bother searching if there's no text to search for.
            Return Nothing
            Exit Function
        Else
            Dim startIndex = 0
            Dim item As ListViewItem = Nothing

            'If one item is selected and it already matches the search text, start searching from the next item.
            'Otherwise, start searching from the beginning.
            If Me.ListView1.SelectedItems.Count = 1 AndAlso Me.ListView1.SelectedItems(0).Text = searchText Then
                startIndex = Me.ListView1.SelectedIndices(0) + 1
            End If

            'Don't search if we're already at the end of the items.
            If startIndex < Me.ListView1.Items.Count Then
                Do
                    'Find the first partial match.
                    item = Me.ListView1.FindItemWithText(searchText, True, startIndex)

                    If item Is Nothing OrElse item.Text = searchText Then
                        'There is no partial match or we have already found a full match.
                        Exit Do
                    End If

                    'Search again from the item after the last partial match.
                    startIndex = item.Index + 1

                    'Stop searching if we're at the end of the items.
                    If startIndex >= Me.ListView1.Items.Count Then
                        Exit Do
                    End If
                Loop
            End If

            'Clear the current selection.
            Me.ListView1.SelectedItems.Clear()
            'item.BackColor = Color.FromArgb(000000F)
            If item Is Nothing Then
                'MessageBox.Show("No match found.")
            Else
                'Select the matching item.
                item.Selected = True
                item.EnsureVisible()
                'item.BackColor = Color.FromArgb(22, 103, 181)
                Me.ListView1.Select()
            End If
        End If

        'Dim arr()
        ' ListView1.Clear()

        'ListView1.Focus()
        'Oledr.Close()

        Return Nothing
    End Function

    Private Function search3()
        ListView1.Items.Clear()
        Call Initialized()
        OleDa.SelectCommand.CommandText = "SELECT * FROM table1 WHERE web_app Like '%%" & TextBox1.Text.Trim.ToString() & "%%'"

        OleDa.SelectCommand.Connection = OleCn
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            itemsearch = ListView1.Items.Add(Oledr("id").ToString())
            'itemsearch.SubItems.Add(Oledr("uname").ToString())
            'itemsearch.SubItems.Add(Oledr("pass").ToString())
            itemsearch.SubItems.Add(Oledr("title").ToString())
            itemsearch.SubItems.Add(Oledr("web_app").ToString())
            itemsearch.SubItems.Add(Oledr("url").ToString())
            'itemsearch.SubItems.Add(Oledr("descrip").ToString())
            'itemsearch.SubItems.Add(Oledr("contact").ToString())
            'itemsearch.SubItems.Add(Oledr("other_details").ToString())
            'itemsearch.SubItems.Add(Oledr("secq").ToString())
            itemsearch.SubItems.Add(Oledr("created").ToString())
            itemsearch.SubItems.Add(Oledr("modified").ToString())
        Loop
        decrypt_tbdt()
        Oledr.Close()
        Return Nothing
    End Function

    Private Function search4()
        ListView1.Items.Clear()
        Call Initialized()
        OleDa.SelectCommand.CommandText = "SELECT * FROM table1 WHERE url Like '%%" & TextBox1.Text.Trim.ToString() & "%%'"

        OleDa.SelectCommand.Connection = OleCn
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            itemsearch = ListView1.Items.Add(Oledr("id").ToString())
            'itemsearch.SubItems.Add(Oledr("uname").ToString())
            'itemsearch.SubItems.Add(Oledr("pass").ToString())
            itemsearch.SubItems.Add(Oledr("title").ToString())
            itemsearch.SubItems.Add(Oledr("web_app").ToString())
            itemsearch.SubItems.Add(Oledr("url").ToString())
            'itemsearch.SubItems.Add(Oledr("descrip").ToString())
            'itemsearch.SubItems.Add(Oledr("contact").ToString())
            'itemsearch.SubItems.Add(Oledr("other_details").ToString())
            'itemsearch.SubItems.Add(Oledr("secq").ToString())
            itemsearch.SubItems.Add(Oledr("created").ToString())
            itemsearch.SubItems.Add(Oledr("modified").ToString())
        Loop
        decrypt_tbdt()
        Oledr.Close()
        Return Nothing
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If update_db() = True Then
            ListView1.Focus()
            Return
        End If
        mode = "#"
        Main_View.ShowDialog()
        ListView1.Focus()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
        TextBox1.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Are you sure you want to Log out from PassVault ?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Sign Out") = MsgBoxResult.Yes Then
            'shrink_grow_animate()
            AnimateWindow(Me.Handle.ToInt32, CInt(200), AW_BLEND_INT Or AW_HIDE_INT)
            Me.Close()
        Else
            ListView1.Focus()
        End If
    End Sub

    'Public Function AES_Encrypt(ByVal value As Byte(), ByVal key As String) As Byte()
    'Dim AES As New RijndaelManaged
    'Dim SHA256 As New SHA256Cng
    'Dim output() As Byte
    '
    '    AES.GenerateIV()
    'Dim iv() As Byte = AES.IV
    '   AES.Key = SHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key))

    '  AES.Mode = CipherMode.CBC
    'Dim AESEncrypter As ICryptoTransform = AES.CreateEncryptor
    'Dim Buffer As Byte() = value
    '   output = AESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
    '
    ''Copy the IV as the first 16 bytes of the output then copy encrypted bytes
    'Dim ivAndOutput(output.Length - 1 + 16) As Byte
    '   Array.Copy(iv, ivAndOutput, 16)
    '  Array.Copy(output, 0, ivAndOutput, 16, output.Length)

    'Return ivAndOutput

    'End Function

    'Public Function AES_Decrypt(ByVal value As Byte(), ByVal key As String) As Byte()
    'Dim AES As New RijndaelManaged
    'Dim SHA256 As New SHA256Cng
    'Dim output() As Byte
    'Dim iv(15) As Byte
    'Dim Buffer(value.Length - 1 - 16) As Byte

    '   'Extract first 16 bytes of input stream as IV.  Copy remaining bytes into encrypted buffer
    '  Array.Copy(value, iv, 16)
    ' Array.Copy(value, 16, Buffer, 0, value.Length - 16)

    'AES.Key = SHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key))
    'AES.IV = iv
    'AES.Mode = CipherMode.CBC
    'Dim AESDecrypter As ICryptoTransform = AES.CreateDecryptor
    '  output = AESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
    'Return output

    'End Function


    'Public Class C3Des

    '************************************************************************************************
    'Functions for 3DES Encryption
    '************************************************************************************************
    'Public Function DES_Encrypt(ByVal value As Byte(), ByVal key As String) As Byte()
    'Dim m As MD5 = New MD5CryptoServiceProvider
    'Dim d As TripleDES = New TripleDESCryptoServiceProvider
    'Dim encryptBytes() As Byte
    'd.Key = m.ComputeHash(Encoding.Unicode.GetBytes(key))
    'd.GenerateIV()
    'Dim c As ICryptoTransform = d.CreateEncryptor
    'Dim input() As Byte = value
    'encryptBytes = c.TransformFinalBlock(input, 0, input.Length)
    'Dim outBytes(encryptBytes.Length + d.IV.Length - 1) As Byte
    'Array.Copy(d.IV, outBytes, d.IV.Length)
    'Array.Copy(encryptBytes, 0, outBytes, 8, encryptBytes.Length)
    'Return outBytes
    'End Function
    '
    'Public Function DES_Decrypt(ByVal value As Byte(), ByVal key As String) As Byte()
    'Dim m As MD5 = New MD5CryptoServiceProvider
    'Dim d As TripleDES = New TripleDESCryptoServiceProvider
    'Dim encryptBytes(value.Length - 9), iv(7) As Byte
    'Array.Copy(value, 0, iv, 0, 8)
    'Array.Copy(value, 8, encryptBytes, 0, value.Length - 8)
    'd.Key = m.ComputeHash(Encoding.Unicode.GetBytes(key))
    'd.IV = iv
    'Dim b As Byte() = encryptBytes
    'Dim c As ICryptoTransform = d.CreateDecryptor
    'Dim output() As Byte = c.TransformFinalBlock(b, 0, b.Length)
    'Return output
    'End Function




    'Private Function AESE(ByVal plaintext As String, ByVal key As String) As String
    'Dim AES As New System.Security.Cryptography.RijndaelManaged
    'Dim SHA256 As New System.Security.Cryptography.SHA256Cng
    'Dim ciphertext As String = ""
    'Try
    '       AES.GenerateIV()
    '      AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))
    '
    '       AES.Mode = Security.Cryptography.CipherMode.CBC
    'Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
    'Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext)
    '       ciphertext = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
    '
    'Return Convert.ToBase64String(AES.IV) & Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
    '
    'Catch ex As Exception
    '        Return ex.Message
    'End Try
    'End Function


    Private Function decrypt_tbdt()
        Dim i As Integer
        Dim denc As String
        For i = 0 To ListView1.Items.Count - 1
            denc = AESDecrypt4(ListView1.Items(i).SubItems(1).Text)
            ListView1.Items(i).SubItems(1).Text = AESDecryptBase64ToString(denc)
            denc = ""
        Next
        For i = 0 To ListView1.Items.Count - 1
            denc = AESDecrypt4(ListView1.Items(i).SubItems(2).Text)
            ListView1.Items(i).SubItems(2).Text = AESDecryptBase64ToString(denc)
            denc = ""
        Next
        For i = 0 To ListView1.Items.Count - 1
            denc = AESDecrypt4(ListView1.Items(i).SubItems(3).Text)
            ListView1.Items(i).SubItems(3).Text = AESDecryptBase64ToString(denc)
            denc = ""
        Next
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
            Dispose(ciphertext)
            Dispose(plaintext)
        Catch ex As Exception
            Dispose(ciphertext)
            Dispose(plaintext)
            Return ex.Message
        End Try
        Dispose(ciphertext)
        Dispose(plaintext)
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

    Private Sub Main_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged
        Dim horizontal = Val(CStr(My.Computer.Screen.WorkingArea.Right)), vertical = Val(CStr(My.Computer.Screen.WorkingArea.Bottom))
        px1 = ((ListView1.Width) / (Me.Size.Width))
        px2 = ((ListView1.Height) / (Me.Size.Height))
        ListView1.Width = px1 * Me.Size.Width
        ListView1.Height = px2 * Me.Size.Height
    End Sub


    Dim px1, px2


    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            Button3.PerformClick()
        End If

        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            Button4.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Button6.PerformClick()
        End If
        If e.Alt = True Then
            If e.KeyCode = Keys.F4 Then
                e.Handled = True
                e = Nothing
                Button6.PerformClick()
            End If
        End If
    End Sub

    Dim drag As Boolean
    Dim mouseX, mouseY As Integer

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub




    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp
        drag = False
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub





    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Panel3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Label2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Label2.MouseDoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        drag = False
    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mouseX
            Me.Top = Cursor.Position.Y - mouseY
        End If
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'AnimateWindow(Me.Handle.ToInt32, CInt(200), winHide Or winBlend)

        e.Cancel = False
    End Sub


    ' Private Const AW_BLEND = &H80000  'Uses a fade effect. This flag can be used only if hwnd is a top-level window.
    'Private Declare Function AnimateWindow Lib "user32" (ByVal hwnd As Int32, ByVal dwTime As Int32, ByVal dwFlags As Int32) As Boolean
    ' Dim winHide As Integer = &H10000
    'Dim winBlend As Integer = &H10
    'Private Function shrink_grow_animate()

    'MyBase.Left = (Screen.PrimaryScreen.WorkingArea.Width - MyBase.Width)
    'MyBase.Top = (Screen.PrimaryScreen.WorkingArea.Height - MyBase.Height)


    'Main.MoveWindow(MyBase.Handle, (MyBase.Left + i / 3500), (MyBase.Top + i / 3500), (MyBase.Width - i / 100), (MyBase.Height - i / 100), True)

    'AnimateWindow2(Me.Handle.ToInt32, CInt(1000), winHide Or winBlend)


    'Return Nothing
    'End Function

    'Private button1a As Button
    'Private components As IContainer = Nothing
    'Private tm As Timer = New Timer

    '<DllImport("user32.dll", SetLastError:=True)>
    'Private Declare Function MoveWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
    'End Function

End Class

'Class AES
'Public Shared Sub Execute()
'Dim aes As New AES()

' 16 bytes long key for AES-128 bit encryption
' Dim key As Byte() = {50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230}

'Dim message As String = "Hello World"

'Dim encryptedMessage As String = aes.EncryptString(message, key)
'Dim encryptedMessageWithIV As String = aes.EncryptString(message, key, IV)
'Dim encryptedMessageWithPassword As String = aes.EncryptString(message, "my password")
'Dim encryptedMessageWithPasswordAndIV As String = aes.EncryptString(message, "my password", IV)

'message = aes.DecryptString(encryptedMessage, key)
' message = aes.DecryptString(encryptedMessageWithIV, key, IV)
'message = aes.DecryptString(encryptedMessageWithPassword, "my password")
'message = aes.DecryptString(encryptedMessageWithPasswordAndIV, "my password", IV)

'End Sub
'End Class

