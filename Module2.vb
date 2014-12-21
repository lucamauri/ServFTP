Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Environment

Public Module Module2
    Public CrLf As String = (Convert.ToChar(10) & Convert.ToChar(13)).ToString
    Public Class FTPSession

        'Const Root As String = "c:\ftproot"
        Public Shared Root As String

        Const BufferDim As Integer = 1024

        Private MD5Pass As String

        Private mClientIP As EndPoint
        Private mClientSOCK As Socket
        Private mActive As Boolean
        Private mIDSession As Integer
        Private CMDBuffer(BufferDim) As Byte
        Private LoclRep As Repository

        Dim WithEvents Alive As Timer

        Dim PASVSock As Socket
        Dim Rename As String

        Private mSckData As Socket
        Private FS As FileStream
        Dim Data(BufferDim) As Byte

        Private mUser As UserData

        ReadOnly Property ClientIP() As EndPoint
            Get
                Return mClientIP
            End Get
        End Property

        'ReadOnly Property ClientSOCK() As Socket
        '    Get
        '        Return mClientSOCK
        '    End Get
        'End Property

        ReadOnly Property Active() As Boolean
            Get
                Return mActive
            End Get
        End Property

        ReadOnly Property IDSession() As Integer
            Get
                Return mIDSession
            End Get
        End Property

        ReadOnly Property User() As UserData
            Get
                Return mUser
            End Get
        End Property

        Public Sub New(ByVal PassedSOCK As Socket, ByVal ID As Integer, ByRef PassedRep As Repository)

            mClientSOCK = PassedSOCK
            mIDSession = ID
            mClientIP = PassedSOCK.RemoteEndPoint
            LoclRep = PassedRep
            mActive = True
            Root = PassedRep.FTPRoot

            Call BesideNEW()

        End Sub

        Private Sub BesideNEW()

            Try
                Alive = New Timer()

                Alive.Interval = 1000
                Alive.Start()

                With mClientSOCK
                    .Send(SendText("220-ServFTP ready".ToCharArray))
                    .Send(SendText("    This server is for test purpose only".ToCharArray))
                    .Send(SendText("220 ServFTP v." & Application.ProductName & Application.ProductVersion))

                    'Console.WriteLine("inizio RECEIVE")

                    .BeginReceive(CMDBuffer, 0, CMDBuffer.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveCMD), mClientSOCK)
                    'Console.WriteLine("RECEIVE fatto")
                End With

                'mClientSOCK.BeginReceive(CMDBuffer, 0, CMDBuffer.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveCMD), mClientSOCK)
            Catch e As Exception

                MessageBox.Show(e.ToString)

                mActive = False

                Console.WriteLine("Ho impostato mActive a FALSO")

                'mClientSOCK.Shutdown(SocketShutdown.Both)
                mClientSOCK.Close()
            End Try

        End Sub

        Sub AliveTick(ByVal ThisObject As Object, ByVal ThisEvent As EventArgs) Handles Alive.Tick
            If Not mClientSOCK.Connected Then
                Alive.Stop()

                'mClientSOCK.Send(SendText("221 Goodbye sir, ServFTP out"))
                mActive = False

                'Console.WriteLine("Ho impostato mActive a FALSO")
                'mClientSOCK.Shutdown(SocketShutdown.Both)
                Console.WriteLine("L'orologio sta chiudendo la Socket")
                mClientSOCK.Close()

            End If
        End Sub

        Private Sub ReceiveCMD(ByVal AR As IAsyncResult)

            'Console.WriteLine("Sto creando la classe dall'interno")

            Dim sb As New StringBuilder()

            Dim ReadSock As Socket
            Dim BytesRead As Integer

            ReadSock = AR.AsyncState
            BytesRead = ReadSock.EndReceive(AR)

            If BytesRead > 0 Then
                sb.Append(Encoding.ASCII.GetString(CMDBuffer, 0, BytesRead))
                Console.WriteLine(sb)
                'Accorciato per eliminare CR e LF dalla risposta
                ProcessCMD(sb.ToString.Substring(0, sb.ToString.Length - 2))
            Else

                Try
                    mClientSOCK.BeginReceive(CMDBuffer, 0, CMDBuffer.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveCMD), mClientSOCK)
                Catch e As Exception

                    MessageBox.Show(e.ToString)

                    mActive = False

                    Console.WriteLine("Ho impostato mActive a FALSO")

                    mClientSOCK.Shutdown(SocketShutdown.Both)
                    mClientSOCK.Close()
                End Try

            End If
        End Sub

        Private Sub ProcessCMD(ByVal CMDString As String)
            Dim Space As Integer
            Dim CMD As String
            Dim Arg As String

            Space = CMDString.ToLower.IndexOf(" ".ToLower)

            If Space < 0 Then
                CMD = CMDString
                Arg = ""
            Else
                CMD = CMDString.Substring(0, Space)
                Arg = CMDString.Substring(Space + 1, CMDString.Length - (CMD.Length + 1))
            End If

            'Console.WriteLine("Command is: >{0}<", CMD)
            'Console.WriteLine("Command's argument is: >{0}<", Arg)

            Select Case CMD.ToLower
                Case "appe"
                    Try
                        FS = New FileStream(User.CurrDir & "\" & Arg, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
                        mClientSOCK.Send(SendText("150 connection accepted, ready to receive, sir"))
                        mSckData.BeginReceive(Data, 0, Data.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveFile), mSckData)
                    Catch e As Exception
                        mClientSOCK.Send(SendText("ERROR"))
                    End Try

                Case "cdup", "xcup"
                    Dim Pos As Integer

                    Pos = User.CurrDir.LastIndexOf("\")
                    Console.WriteLine(User.CurrDir)
                    Console.WriteLine(Pos)


                    User.CurrDir = User.CurrDir.Substring(0, Pos + 1)

                    mClientSOCK.Send(SendText("257 " & Convert.ToChar(34) & User.RelativeDir.ToString & Convert.ToChar(34) & " is current directory"))

                Case "cwd", "xcwd"
                    Dim NewDir As String
                    Dim FinDir As String

                    If Arg.Substring(0, 1) = "." Then

                        mClientSOCK.Send(SendText("550 Action not taken sir, directory unrecognized"))

                    Else
                        Select Case Arg.Substring(0, 1)
                            Case "\", "/"
                                NewDir = FixPath(Arg)
                                FinDir = User.HomeDir & NewDir
                            Case Else
                                NewDir = FixPath(Arg)
                                FinDir = User.CurrDir.ToString & NewDir
                        End Select

                        FinDir = FinDir.Replace("\\", "\")

                        If Directory.Exists(FinDir) Then
                            User.CurrDir = FinDir
                            'Console.WriteLine(User.CurrDir)
                            mClientSOCK.Send(SendText("250 current working directory is now " & User.RelativeDir))
                        Else
                            mClientSOCK.Send(SendText("550 Action not taken sir, directory unrecognized"))
                        End If
                    End If
                Case "dele"
                    Try
                        If User.CanUP Then

                        End If
                    Catch exc As Exception
                        MessageBox.Show(exc.ToString, "Dele")
                    End Try

                Case "old dele"
                    Dim FileName As String
                    Dim TempDir As String
                    Dim FinDir As String

                    Try
                        If User.CanUP Then
                            Arg = Arg.Replace("/", "\")

                            TempDir = Arg.Substring(0, Arg.LastIndexOf("\"))
                            If Not (TempDir.Length = 0) Then
                                FinDir = FixPath(TempDir)
                            End If

                            If FinDir.IndexOf(".") > 0 Then
                                mClientSOCK.Send(SendText("550 Action not taken sir, directory not valid"))
                            Else
                                Select Case findir.Substring(0, 1)
                                    Case "\", "/"
                                        FinDir = User.HomeDir & findir
                                    Case Else
                                        FinDir = User.CurrDir.ToString & finDir
                                End Select

                                FileName = "\" & Arg.Substring(Arg.LastIndexOf("\") + 1)

                                If File.Exists(FinDir & FileName) Then
                                    Try
                                        File.Delete(FinDir & FileName)
                                        mClientSOCK.Send(SendText("250 File deleted"))
                                    Catch
                                        mClientSOCK.Send(SendText("450 Unable to delete file"))
                                    End Try
                                Else
                                    mClientSOCK.Send(SendText("550 Action not taken sir, file unrecognized"))
                                End If
                            End If
                        Else
                            mClientSOCK.Send(SendText("550 Sorry sir, you are not allowed to delete files"))
                        End If
                    Catch exc As Exception
                        MessageBox.Show(exc.ToString, "DELE")
                    End Try

                Case "list"

                    mClientSOCK.Send(SendText("150 Opening ASCII connection, folder " & User.RelativeDir))

                    If SendOnDataSock(mSckData, ListFile(User.CurrDir.ToString)) Then
                        mClientSOCK.Send(SendText("226 transfer complete"))
                    Else
                        mClientSOCK.Send(SendText("425 Can't open data connection"))
                    End If

                Case "md5"
                    Dim FileName As String
                    Dim TempDir As String
                    Dim FinDir As String

                    Arg = Arg.Replace("/", "\")

                    TempDir = Arg.Substring(0, Arg.LastIndexOf("\"))
                    If Not (TempDir.Length = 0) Then
                        FinDir = FixPath(TempDir)
                    End If

                    If FinDir.IndexOf(".") > 0 Then
                        mClientSOCK.Send(SendText("550 Action not taken sir, directory not valid"))
                    Else
                        Select Case findir.Substring(0, 1)
                            Case "\", "/"
                                FinDir = User.HomeDir & findir
                            Case Else
                                FinDir = User.CurrDir.ToString & finDir
                        End Select

                        FileName = "\" & Arg.Substring(Arg.LastIndexOf("\") + 1)

                        If File.Exists(FinDir & FileName) Then
                            Try
                                mClientSOCK.Send(SendText("251-File found, generating MD5 hash"))
                                mClientSOCK.Send(SendText("    Please note this could take time dependig on the size of the file and the server processor load"))
                                Dim Digest As String

                                Digest = FileToMD5(File.OpenRead(findir & filename))

                                mClientSOCK.Send(SendText("251 " & Arg & " " & Digest.ToUpper))
                            Catch
                                mClientSOCK.Send(SendText("450 Unable to compute hash"))
                            End Try
                        Else
                            mClientSOCK.Send(SendText("550 Action not taken sir, file unrecognized"))
                        End If
                    End If

                Case "mkd", "xmkd"
                    Dim NewDir As String
                    Dim FinDir As String

                    If User.CanUP And Arg.IndexOf(".") > 0 Then
                        Select Case Arg.Substring(0, 1)
                            Case "\", "/"
                                NewDir = FixPath(Arg)
                                FinDir = User.HomeDir & NewDir
                            Case Else
                                NewDir = FixPath(Arg)
                                FinDir = User.CurrDir.ToString & NewDir
                        End Select

                        FinDir = FinDir.Replace("\\", "\")

                        Try
                            Directory.CreateDirectory("findir")
                            mClientSOCK.Send(SendText("257 " & Convert.ToChar(34) & User.RelativeDir.ToString & Convert.ToChar(34) & " created"))
                        Catch
                            mClientSOCK.Send(SendText("550 Unable to crete directory"))
                        End Try
                    Else
                        mClientSOCK.Send(SendText("550 Sorry sir, you are not allowed to create direcories"))
                    End If

                    'Case "mmd5"

                Case "mode"
                    Select Case Arg
                        Case "s", "S"
                            mClientSOCK.Send(SendText("200 Mode OK"))
                        Case Else
                            mClientSOCK.Send(SendText("504 Mode not valid"))
                    End Select

                Case "noop"
                    mClientSOCK.Send(SendText("211 ServFTP here, sir, go ahead"))

                Case "pass"
                    If MD5Pass = StringToMD5(Arg) Or mUser.UserID = "anonymous" Then
                        mClientSOCK.Send(SendText("230-password OK, user logged in"))
                        LoclRep.ModifyAccess(mUser.UserID)

                        Try
                            mUser.CanUP = CBool(LoclRep.REPUsers.SelectSingleNode("//Users/User[@ID='" & User.UserID & "']/UPload").InnerText())
                            mUser.CanDOWN = CBool(LoclRep.REPUsers.SelectSingleNode("//Users/User[@ID='" & User.UserID & "']/DOWNload").InnerText())

                            mClientSOCK.Send(SendText(""))
                            mClientSOCK.Send(SendText("    Permission to UPload:   " & User.CanUP.ToString))
                            mClientSOCK.Send(SendText("    Permission to DOWNload: " & User.CanDOWN.ToString))
                            mClientSOCK.Send(SendText(""))
                            mClientSOCK.Send(SendText("    Local Time: " & DateTime.Now.ToString))
                            mClientSOCK.Send(SendText("    UTC Time:   " & DateTime.Now.ToUniversalTime.ToString))
                            mClientSOCK.Send(SendText(""))
                            mClientSOCK.Send(SendText("230 Enjoy the transfer!"))
                        Catch e As Exception
                            MessageBox.Show(e.ToString)
                        End Try

                    Else
                        mClientSOCK.Send(SendText("530 Wrong password, disconnecting"))
                        mClientSOCK.Send(SendText("221 Goodbye sir, ServFTP out"))
                        mActive = False

                        'Console.WriteLine("Ho impostato mActive a FALSO")

                        mClientSOCK.Shutdown(SocketShutdown.Both)
                        mClientSOCK.Close()
                        Exit Sub
                    End If

                Case "pasv"

                    If False Then
                        mClientSOCK.Send(SendText("500 PASV command is disabled. Use PORT command."))
                    Else

                        'ToDo Il meccanismo del controllo dell'IP in PASV e' tutta da rivedere


                        Try
                            If Not (mSckData Is Nothing) Then
                                mClientSOCK.Send(SendText("227 conncetion already established (" & IPtoComma(PASVSock.LocalEndPoint) & ")"))

                            Else
                                User.PasvEP = New IPEndPoint(LoclRep.MachineIP, 0)

                                PASVSock = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

                                With PASVSock
                                    .Bind(User.PasvEP)
                                    .Listen(1)
                                    '.BeginAccept(New AsyncCallback(AddressOf ConnPASV), PASVSock)
                                End With

                                If CBool(LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/PasvIPPro").InnerText) Then

                                    'Dim RemoteEP As IPEndPoint
                                    'Dim RemoteIP As IPAddress

                                    'If remoteip.ToString <> User.HisIP.ToString Then
                                    'mClientSOCK.Send(SendText("500 unable to open connection: IP does not match"))
                                    'PASVSock.Close()
                                    'Else
                                    PASVSock.BeginAccept(New AsyncCallback(AddressOf ConnPASV), PASVSock)

                                    mClientSOCK.Send(SendText("227 entering passive mode (" & IPtoComma(PASVSock.LocalEndPoint) & ")"))
                                    'End If

                                    'remoteep = PASVSock.RemoteEndPoint



                                    'remoteip = remoteep.Address

                                Else
                                    PASVSock.BeginAccept(New AsyncCallback(AddressOf ConnPASV), PASVSock)

                                    mClientSOCK.Send(SendText("227 entering passive mode (" & IPtoComma(PASVSock.LocalEndPoint) & ")"))
                                End If
                            End If
                        Catch exc As Exception
                            'MessageBox.Show("PASV " & exc.Message.ToString)
                            mClientSOCK.Send(SendText("500 " & exc.ToString))
                        End Try
                    End If

                Case "port"

                    If CBool(LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/AllowPort").InnerText) Then
                        User.PortEP = CommaTOIP(Arg)
                        If (CBool(LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/AntiBounce").InnerText)) And (User.PortEP.Port < 1024) Then
                            mClientSOCK.Send(SendText("425 Can't open data connection. Anti BOUNCE-attack feature is enabled: no connection over port less than 1024 is accepted"))
                        Else
                            mClientSOCK.Send(SendText("200 PORT command successful, IP is " & User.PortEP.Address.ToString & " port " & User.PortEP.Port.ToString))

                            Try
                                mSckData = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                                mSckData.Connect(User.PortEP)
                            Catch exc As Exception
                                mClientSOCK.Send(SendText("425 Can't open data connection. Remote socket is not ready"))
                            End Try

                        End If
                    Else
                        mClientSOCK.Send(SendText("425 Can't open data connection. PORT is not allowed on this site"))
                    End If

                Case "pwd", "xpwd"
                    mClientSOCK.Send(SendText("257 " & Convert.ToChar(34) & User.RelativeDir.ToString & Convert.ToChar(34) & " is current directory"))

                Case "quit"
                    Try
                        'Alive.Stop()

                        mClientSOCK.Send(SendText("221 Goodbye sir, ServFTP out"))
                        mActive = False

                        If Not (PASVSock Is Nothing) Then
                            PASVSock.Close()
                        End If

                        mClientSOCK.Close()
                        Exit Sub
                    Catch exc As Exception
                        MessageBox.Show(exc.ToString)
                    End Try

                Case "rest"
                    User.RestByte = Arg

                    mClientSOCK.Send(SendText("350 Requested file action pending further information"))

                Case "retr"
                    If Not User.CanUP Then
                        mClientSOCK.Send(SendText("532 Sorry sir, you are not allowed to UPload"))
                    Else
                        If File.Exists(User.CurrDir & Arg) Then
                            Dim BytesRead As Integer

                            User.FileName = "\" & Arg
                            mClientSOCK.Send(SendText("150 Opening data connection, sir"))
                            'mSckData = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                            'mSckData.Connect(User.PortEP)

                            Try
                                FS = New FileStream(User.CurrDir & User.FileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                                BytesRead = FS.Read(Data, 0, Data.Length)
                                mSckData.BeginSend(Data, 0, BytesRead, SocketFlags.None, New AsyncCallback(AddressOf SendFile), mSckData)
                            Catch e As Exception
                                MessageBox.Show(e.ToString)
                                mClientSOCK.Send(SendText("550 File not transferred, no access to this resource"))
                                mSckData.Close()
                            End Try

                        Else
                            mClientSOCK.Send(SendText("550 Sorry sir, no such file - " & User.CurrDir & Arg))
                        End If
                    End If

                Case "rmd", "xrmd"
                    Dim NewDir As String
                    Dim FinDir As String

                    If User.CanUP And Arg.IndexOf(".") > 0 Then

                        Select Case Arg.Substring(0, 1)
                            Case "\", "/"
                                NewDir = FixPath(Arg)
                                FinDir = User.HomeDir & NewDir
                            Case Else
                                NewDir = FixPath(Arg)
                                FinDir = User.CurrDir.ToString & NewDir
                        End Select

                        FinDir = FinDir.Replace("\\", "\")

                        If findir = User.HomeDir Then

                            mClientSOCK.Send(SendText("550 You cannot delete your root directory"))
                        Else

                            Try
                                Directory.Delete(findir, True)

                                If findir = User.CurrDir Then
                                    User.CurrDir = User.HomeDir
                                End If

                                mClientSOCK.Send(SendText("250 Directory deleted"))
                            Catch
                                mClientSOCK.Send(SendText("550 - Unable to delete directory"))
                            End Try
                        End If
                    Else
                        mClientSOCK.Send(SendText("550 - Sorry sir, you are not allowed to create direcories"))
                    End If

                Case "rnfr"
                    Dim FileName As String
                    Dim TempDir As String
                    Dim FinDir As String

                    If User.CanUP Then
                        Arg = Arg.Replace("/", "\")

                        TempDir = Arg.Substring(0, Arg.LastIndexOf("\"))
                        If Not (TempDir.Length = 0) Then
                            FinDir = FixPath(TempDir)
                        End If

                        If FinDir.IndexOf(".") > 0 Then
                            mClientSOCK.Send(SendText("550 Action not taken sir, directory not valid"))
                        Else
                            Select Case findir.Substring(0, 1)
                                Case "\", "/"
                                    FinDir = User.HomeDir & findir
                                Case Else
                                    FinDir = User.CurrDir.ToString & finDir
                            End Select

                            FileName = "\" & Arg.Substring(Arg.LastIndexOf("\") + 1)

                            If File.Exists(FinDir & FileName) Then
                                Try
                                    Rename = findir & filename
                                    mClientSOCK.Send(SendText("350 File found, ready to change it, please state new name with RNTO"))
                                Catch
                                    mClientSOCK.Send(SendText("550 Unable to find file"))
                                End Try
                            Else
                                mClientSOCK.Send(SendText("550 Action not taken sir, file unrecognized"))
                            End If
                        End If
                    Else
                        mClientSOCK.Send(SendText("550 Sorry sir, you are not allowed to change files"))
                    End If

                Case "rnto"
                    If Rename = "" Then
                        mClientSOCK.Send(SendText("503 Action not taken sir, send RNFR first"))
                        Exit Select
                    End If

                    Dim FileName As String
                    Dim TempDir As String
                    Dim FinDir As String

                    If User.CanUP Then
                        Arg = Arg.Replace("/", "\")

                        TempDir = Arg.Substring(0, Arg.LastIndexOf("\"))
                        If Not (TempDir.Length = 0) Then
                            FinDir = FixPath(TempDir)
                        End If

                        If FinDir.IndexOf(".") > 0 Then
                            mClientSOCK.Send(SendText("550 Action not taken sir, directory not valid"))
                        Else
                            Select Case findir.Substring(0, 1)
                                Case "\", "/"
                                    FinDir = User.HomeDir & findir
                                Case Else
                                    FinDir = User.CurrDir.ToString & finDir
                            End Select

                            FileName = "\" & Arg.Substring(Arg.LastIndexOf("\") + 1)

                            If File.Exists(FinDir & FileName) Then
                                mClientSOCK.Send(SendText("553 Action not taken sir, file exists already"))
                            Else
                                Try
                                    File.Move(Rename, findir & filename)
                                    Rename = ""
                                    mClientSOCK.Send(SendText("250 File renamed"))
                                Catch
                                    mClientSOCK.Send(SendText("550 Unable to rename file"))
                                End Try
                            End If
                        End If
                    Else
                        mClientSOCK.Send(SendText("550 Sorry sir, you are not allowed to change files"))
                    End If

                Case "stor"
                    'Path = User.CurrDir & "\" & Arg
                    'mSckData = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    'mSckData.Connect(User.PortEP)

                    'todo Bisogna inseriree un controllo per verificare che la socket dei dati si aperta

                    Try
                        FS = New FileStream(User.CurrDir & "\" & Arg, FileMode.Create, FileAccess.Write, FileShare.Write)
                        mClientSOCK.Send(SendText("150 connection accepted, ready to receive, sir"))
                        mSckData.BeginReceive(Data, 0, Data.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveFile), mSckData)
                    Catch e As Exception
                        mClientSOCK.Send(SendText("ERROR"))
                    End Try

                    'MessageBox.Show("sto chiudendo")

                    'FS.Close()

                    'ClientSock.Send(SendText("226 Transfer completed, sir"))
                Case "stru"
                    Select Case Arg
                        Case "f", "F"
                            mClientSOCK.Send(SendText("200 Structure set"))
                        Case Else
                            mClientSOCK.Send(SendText("504 Structure not valid"))
                    End Select

                Case "syst"
                    Dim Assigned As String
                    Dim System As String

                    Select Case OSVersion.Version.Major.ToString
                        Case "4"
                            Assigned = "WINDOWS-NT-4"
                            System = "Windows NT 4.0"
                        Case "5"
                            Assigned = "WINDOWS-NT-5"
                            Select Case OSVersion.Version.Minor.ToString
                                Case "0"
                                    System = "Windows 2000"
                                Case "1"
                                    System = "Windows XP"
                                Case "2"
                                    System = "Windows NT 5.2 (Possible LongHorn)"
                                Case Else
                                    System = "Windows NT-based Post-XP OS"
                            End Select
                        Case "6"
                            Assigned = "WINDOWS-NT-6"
                            System = "Windows-NT based, post XP, possible LongHorn"
                        Case Else
                            Assigned = "WINDWOS-NT"
                            System = "Unrecognized Windows NT-based OS"
                    End Select

                    If CBool(LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/FullSYST").InnerText) Then
                        mClientSOCK.Send(SendText("215-" & Assigned))
                        mClientSOCK.Send(SendText("    System Version " & System & " Build " & OSVersion.Version.Build.ToString))
                        mClientSOCK.Send(SendText("215 ServFTP v." & Application.ProductVersion))
                    Else
                        mClientSOCK.Send(SendText("215 " & Assigned))
                    End If

                Case "type"
                    Select Case Arg.ToLower
                        Case "i", "l8", "l 8"
                            mUser.Type = True
                            mClientSOCK.Send(SendText("200 BINARY flag is ON"))
                        Case Else
                            mUser.Type = False
                            mClientSOCK.Send(SendText("200 BINARY flag is OFF"))
                    End Select

                Case "user"
                    Dim RemoteEP As IPEndPoint
                    Dim RemoteIP As IPAddress

                    RemoteEP = mClientSOCK.RemoteEndPoint
                    RemoteIP = RemoteEP.Address

                    If Arg.ToLower = "anonymous" Then
                        If CBool(LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Anon']/AllowAnon").InnerText) Then
                            mUser = New UserData(Arg.ToLower, LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Anon']/Folder").InnerText, RemoteIP)
                            mClientSOCK.Send(SendText("331 User name OK, please type password"))
                        Else
                            mClientSOCK.Send(SendText("530 Anonymous access not allowed, disconnecting"))
                            mClientSOCK.Send(SendText("221 Goodbye sir, ServFTP out"))
                            mActive = False

                            'mClientSOCK.Shutdown(SocketShutdown.Both)
                            mClientSOCK.Close()
                            Exit Sub
                        End If
                    Else
                        Try
                            MD5Pass = LoclRep.REPUsers.SelectSingleNode("//Users/User[@ID='" & Arg & "']/Password").InnerText()
                        Catch EXC As Exception
                            mClientSOCK.Send(SendText("530 Wrong username, disconnecting"))
                            mClientSOCK.Send(SendText("221 Goodbye sir, ServFTP out"))
                            mActive = False

                            'mClientSOCK.Shutdown(SocketShutdown.Both)
                            mClientSOCK.Close()
                            Exit Sub
                        End Try

                        If CBool(LoclRep.REPUsers.SelectSingleNode("//Users/User[@ID='" & Arg & "']/Active").InnerText()) Then
                            mUser = New UserData(Arg, LoclRep.REPUsers.SelectSingleNode("//Users/User[@ID='" & Arg & "']/HomeDir").InnerText(), RemoteIP)
                            mClientSOCK.Send(SendText("331 User name OK, please type password"))
                        Else
                            mClientSOCK.Send(SendText("530 User not allowed, disconnecting"))
                            mClientSOCK.Send(SendText("221 Goodbye sir, ServFTP out"))
                            mActive = False

                            'mClientSOCK.Shutdown(SocketShutdown.Both)
                            mClientSOCK.Close()
                            Exit Sub
                        End If
                    End If

                Case Else
                    mClientSOCK.Send(SendText("502 Sorry, command " & CMD & " not (yet) implemented"))

            End Select

            Try
                mClientSOCK.BeginReceive(CMDBuffer, 0, CMDBuffer.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveCMD), mClientSOCK)

            Catch e As Exception

                MessageBox.Show(e.ToString)

                mActive = False

                Console.WriteLine("Ho impostato mActive a FALSO")

                mClientSOCK.Shutdown(SocketShutdown.Both)
                mClientSOCK.Close()
            End Try
        End Sub

#Region "File managing CallBacks"
        Sub SendFile(ByVal AR As IAsyncResult)
            Dim BytesRead As Integer

            'todo Implementare qui il byte di partenza per REST
            BytesRead = FS.Read(Data, 0, Data.Length)

            If BytesRead > 0 Then
                mSckData.BeginSend(Data, 0, BytesRead, SocketFlags.None, New AsyncCallback(AddressOf SendFile), mSckData)
            Else
                FS.Close()
                Dim TempSock As Socket

                TempSock = AR.AsyncState

                TempSock.Shutdown(SocketShutdown.Both)
                TempSock.Close()
                mClientSOCK.Send(SendText("226 Transfer completed, sir"))
            End If

        End Sub
        Public Sub ReceiveFile(ByVal AR As IAsyncResult)
            Dim FileSock As Socket
            Dim BytesRead As Integer

            FileSock = AR.AsyncState
            BytesRead = FileSock.EndReceive(AR)

            If BytesRead > 0 Then
                FS.Write(Data, 0, BytesRead)
                mSckData.BeginReceive(Data, 0, BytesRead, SocketFlags.None, New AsyncCallback(AddressOf ReceiveFile), mSckData)
                'Console.WriteLine("Scritto " & BytesRead.ToString)
            Else
                FS.Close()
                Dim TempSock As Socket
                'Console.WriteLine("Shutting down")

                FileSock.Shutdown(SocketShutdown.Both)
                FileSock.Close()
                mClientSOCK.Send(SendText("226 Transfer completed, sir"))

            End If
        End Sub
#End Region

        Sub ConnPASV(ByVal AR As IAsyncResult)

            'If Not (mSckData Is Nothing) Then
            '    mSckData.Close()
            'End If

            Dim RemoteEP As IPEndPoint
            Dim RemoteIP As IPAddress

            mSckData = PASVSock.EndAccept(AR)
            Console.WriteLine("Sock port is " & mSckData.RemoteEndPoint.ToString)

            RemoteEP = mSckData.RemoteEndPoint
            RemoteIP = RemoteEP.Address

            PASVSock.BeginAccept(New AsyncCallback(AddressOf ConnPASV), PASVSock)

        End Sub

        Public Class UserData

            Private mCanUP As Boolean
            Private mCanDOWN As Boolean
            Private mHisIP As IPAddress
            Private mUserID As String
            Private mHomeDir As String
            Private mCurrDir As String
            Private mType As Boolean
            Private mFileName As String
            Private mPortEP As IPEndPoint
            Private mPasvEp As IPEndPoint
            Private mRelativeDir As String
            Private mRestByte As Integer

            ReadOnly Property UserID() As String
                Get
                    Return mUserID
                End Get
            End Property
            ReadOnly Property HomeDir() As String
                Get
                    Return mHomeDir
                End Get
            End Property
            Property CanUP() As Boolean
                Get
                    Return mCanUP
                End Get
                Set(ByVal Value As Boolean)
                    mCanUP = Value
                End Set
            End Property
            Property CanDOWN() As Boolean
                Get
                    Return mCanDOWN
                End Get
                Set(ByVal Value As Boolean)
                    mCanDOWN = Value
                End Set
            End Property
            Property CurrDir() As String
                Get
                    Return mCurrDir
                End Get
                Set(ByVal Value As String)
                    mRelativeDir = Value.Substring(Root.Length, Value.Length - Root.Length)
                    mCurrDir = Value
                End Set
            End Property
            Property FileName() As String
                Get
                    Return mFileName
                End Get
                Set(ByVal Value As String)
                    mFileName = Value
                End Set
            End Property
            ReadOnly Property HisIP() As IPAddress
                Get
                    Return mHisIP
                End Get
            End Property
            Property PasvEP() As IPEndPoint
                Get
                    Return mPasvEp
                End Get
                Set(ByVal Value As IPEndPoint)
                    mPasvEp = Value
                End Set
            End Property
            Property PortEP() As IPEndPoint
                Get
                    Return mPortEP
                End Get
                Set(ByVal Value As IPEndPoint)
                    mPortEP = Value
                End Set
            End Property
            ReadOnly Property RelativeDir() As String
                Get
                    Return mRelativeDir
                End Get
            End Property
            Property RestByte() As Integer
                Get
                    Return mRestByte
                End Get
                Set(ByVal Value As Integer)
                    mRestByte = Value
                End Set
            End Property
            Property Type() As Boolean
                Get
                    Return mType
                End Get
                Set(ByVal Value As Boolean)
                    mType = Value
                End Set
            End Property

            Public Sub New(ByVal ArgUserID As String, ByVal ArgHomeDir As String, ByVal IPAddress As IPAddress)
                mUserID = ArgUserID
                mHomeDir = Root & ArgHomeDir
                mCurrDir = Root & ArgHomeDir
                'mRelativeDir = Root.Substring(Root.Length, Root.Length - Root.Length)
                mRelativeDir = "\"
                mHisIP = IPAddress

                mType = False

            End Sub

        End Class
    End Class
End Module
