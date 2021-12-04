Imports System.Data.OleDb

Module Module1
    Dim provider As String
    Public OleCn As New OleDbConnection
    Public OleDa As New OleDbDataAdapter

    Private Function OledbConnectionString() As String

        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\Vn#RVypWq1hqX6%R.netcon48;Jet OLEDB:Database Password=tmzS~u%sw<n6&rs3e^9&")
        Return provider

    End Function

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

    Public Sub openconnection()
        'HavingInternetConnection()
        If OleCn.State <> ConnectionState.Open Then
            OleCn.ConnectionString = OledbConnectionString()
            OleCn.Open()
        End If
    End Sub



    Private Function HavingInternetConnection() As Boolean
        Return 0
        Dim loop1 As Integer
        loop1 = 1
a:
        While (loop1 = 1)
            If My.Computer.Network.IsAvailable Then
                Try
                    If My.Computer.Network.Ping("www.google.com") Then

                        Select Case MsgBox("Computer is connected to the internet. Please disconnect to continue using PassVault", MessageBoxButtons.OKCancel, MsgBoxStyle.Critical)
                            Case MsgBoxResult.Ok
                                GoTo a
                            Case MsgBoxResult.Cancel
                                Login.Close()
                                Application.Exit()
                                'Return False
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

    Public Sub Initialized()
        OleDa.SelectCommand = New OleDbCommand
        OleDa.SelectCommand.CommandText = "SELECT * FROM table1"
        OleDa.SelectCommand.Connection = OleCn
    End Sub
    Public Sub closeconnection()
        OleCn.Close()
    End Sub

End Module
'https://forum.uipath.com/t/how-to-convert-a-string-to-security-string-using-visual-basic/28145