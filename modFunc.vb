Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Sockets

Public Module modFunc
    Public Overloads Function SendText(ByVal Source As String) As Byte()
        SendText = Encoding.ASCII.GetBytes(Source & Convert.ToChar(13).ToString.ToCharArray & Convert.ToChar(10).ToString.ToCharArray)
    End Function

    Public Overloads Function SendText(ByVal Source As String, ByVal AddCRLF As Boolean) As Byte()
        If AddCRLF Then
            SendText = Encoding.ASCII.GetBytes(Source & Convert.ToChar(13).ToString.ToCharArray & Convert.ToChar(10).ToString.ToCharArray)
        Else
            SendText = Encoding.ASCII.GetBytes(Source.ToCharArray)
        End If
    End Function

    'Public Structure UserStruct
    '    Dim ID As String
    '    Dim Name As String
    '    Dim Directory As String

    '    Dim Active As Boolean
    '    Dim Up As Boolean
    '    Dim Down As Boolean
    'End Structure


#Region "MD5 Function"
    Public Function StringToMD5(ByVal Text As String) As String

        Dim InputArray() As Byte
        Dim MD5 As MD5CryptoServiceProvider
        Dim Hash() As Byte

        InputArray = Encoding.ASCII.GetBytes(Text)

        MD5 = New MD5CryptoServiceProvider()

        Hash = MD5.ComputeHash(InputArray)

        Dim B As Byte
        For Each B In Hash
            Dim StrTemp As String
            StrTemp = Convert.ToString(B, 16)
            If StrTemp.Length = 1 Then
                StrTemp = "0" & StrTemp
            End If
            StringToMD5 &= StrTemp
        Next
    End Function

    Public Function FileToMD5(ByRef Source As FileStream) As String
        Dim MD5 As MD5CryptoServiceProvider
        Dim Hash() As Byte

        MD5 = New MD5CryptoServiceProvider()

        Hash = MD5.ComputeHash(Source)

        Dim B As Byte
        For Each B In Hash
            Dim StrTemp As String
            StrTemp = Convert.ToString(B, 16)
            If StrTemp.Length = 1 Then
                StrTemp = "0" & StrTemp
            End If
            FileToMD5 &= StrTemp
        Next
    End Function
#End Region
#Region "BrowseForFolder"

    '=====================================================================================
    ' Browse for a Folder using SHBrowseForFolder API function with a callback
    ' function BrowseCallbackProc.
    '
    ' This Extends the functionality that was given in the
    ' MSDN Knowledge Base article Q179497 "HOWTO: Select a Directory
    ' Without the Common Dialog Control".
    '
    ' After reading the MSDN knowledge base article Q179378 "HOWTO: Browse for
    ' Folders from the Current Directory", I was able to figure out how to add
    ' a callback function that sets the starting directory and displays the
    ' currently selected path in the "Browse For Folder" dialog.
    '
    ' I used VB 6.0 (SP3) to compile this code.  Should work in VB 5.0.
    ' However, because it uses the AddressOf operator this code will not
    ' work with versions below 5.0.
    '
    ' This code works in Window 95a so I assume it will work with later versions.
    '
    ' Stephen Fonnesbeck
    ' steev@xmission.com
    ' http://www.xmission.com/~steev
    ' Feb 20, 2000
    '
    '=====================================================================================
    ' Usage:
    '
    '    Dim folder As String
    '    folder = BrowseForFolder(Me, "Select A Directory", "C:\startdir\anywhere")
    '    If Len(folder) = 0 Then Exit Sub  'User Selected Cancel
    '
    '=====================================================================================


    Private Const BIF_STATUSTEXT As Integer = &H4
    Private Const BIF_RETURNONLYFSDIRS As Short = 1
    Private Const BIF_DONTGOBELOWDOMAIN As Short = 2
    Private Const BIF_EDITBOX As Integer = &H10
    Private Const BIF_NEWDIALOGSTYLE As Integer = &H20
    Private Const BIF_USENEWUI As Integer = &H40

    Private Const MAX_PATH As Short = 260

    Private Const WM_USER As Short = &H400S
    Private Const BFFM_INITIALIZED As Short = 1
    Private Const BFFM_SELCHANGED As Short = 2
    Private Const BFFM_SETSTATUSTEXT As Integer = (WM_USER + 100)
    Private Const BFFM_SETSELECTION As Integer = (WM_USER + 102)

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String) As Integer
    Private Declare Function SHBrowseForFolder Lib "shell32" (ByRef lpbi As BrowseInfo) As Integer
    Private Declare Function SHGetPathFromIDList Lib "shell32" (ByVal pidList As Integer, ByVal lpBuffer As String) As Integer
    Private Declare Function lstrcat Lib "kernel32" Alias "lstrcatA" (ByVal lpString1 As String, ByVal lpString2 As String) As Integer
    Delegate Function SubClassProcDelegate(ByVal hwnd As Integer, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Structure BrowseInfo
        Dim hWndOwner As Integer
        Dim pIDLRoot As Integer
        Dim pszDisplayName As Integer
        Dim lpszTitle As String
        Dim ulFlags As Integer
        Dim lpfnCallback As SubClassProcDelegate
        Dim lParam As Integer
        Dim iImage As Integer
    End Structure

    Private m_CurrentDirectory As String 'The current directory
    '

    Public Function BrowseForFolder(ByRef owner As System.Windows.Forms.Form, ByRef Title As String, ByRef StartDir As String) As String
        'Opens a Treeview control that displays the directories in a computer

        Dim lpIDList As Integer
        Dim szTitle As String
        Dim sBuffer As String
        Dim tBrowseInfo As BrowseInfo

        '*********************************************************
        Dim SB As New StringBuilder()
        '*********************************************************

        '*********************************************************
        'm_CurrentDirectory = StartDir & vbNullChar
        m_CurrentDirectory = StartDir & Convert.ToChar(0).ToString
        '*********************************************************

        szTitle = Title
        With tBrowseInfo
            .hWndOwner = owner.Handle.ToInt32
            .lpszTitle = szTitle
            .ulFlags = BIF_RETURNONLYFSDIRS + BIF_EDITBOX + BIF_STATUSTEXT
            .lpfnCallback = GetAddressofFunction(AddressOf BrowseCallbackProc) 'get address of function.
        End With


        lpIDList = SHBrowseForFolder(tBrowseInfo)
        If (lpIDList) Then

            '*********************************************************
            'sBuffer = Space(MAX_PATH)
            sBuffer = SB.Append(" ", MAX_PATH).ToString
            '*********************************************************

            SHGetPathFromIDList(lpIDList, sBuffer)

            '*********************************************************
            'sBuffer = Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
            sBuffer = sBuffer.Substring(0, sBuffer.IndexOf(Convert.ToChar(0).ToString))
            '*********************************************************

            BrowseForFolder = sBuffer
        Else
            BrowseForFolder = ""
        End If

    End Function

    Private Function BrowseCallbackProc(ByVal hWnd As Integer, ByVal uMsg As Integer, ByVal lp As Integer, ByVal pData As Integer) As Integer

        Dim lpIDList As Integer
        Dim ret As Integer
        Dim sBuffer As String

        '*********************************************************
        Dim SB As New StringBuilder()
        '*********************************************************

        On Error Resume Next 'Sugested by MS to prevent an error from
        'propagating back into the calling process.

        Select Case uMsg

            Case BFFM_INITIALIZED
                Call SendMessage(hWnd, BFFM_SETSELECTION, 1, m_CurrentDirectory)

            Case BFFM_SELCHANGED

                '*********************************************************
                'sBuffer = Space(MAX_PATH)
                sBuffer = SB.Append(" ", MAX_PATH).ToString
                '*********************************************************

                ret = SHGetPathFromIDList(lp, sBuffer)
                If ret = 1 Then
                    Call SendMessage(hWnd, BFFM_SETSTATUSTEXT, 0, sBuffer)
                End If

        End Select

        BrowseCallbackProc = 0

    End Function

    ' This function allows you to assign a function pointer to a variable.
    Private Function GetAddressofFunction(ByRef add As SubClassProcDelegate) As SubClassProcDelegate
        GetAddressofFunction = add
    End Function
#End Region
#Region "Folder and file lists"

    Public Function ListFile(ByVal Dir As String) As String
        Dim File As String
        Dim Folder As String
        Dim FI As FileInfo

        For Each Folder In Directory.GetDirectories(Dir)
            ListFile &= CreateFolderLine(Folder) & Convert.ToChar(10).ToString
        Next

        For Each File In Directory.GetFiles(Dir)
            ListFile &= CreateFileLine(File) & Convert.ToChar(10).ToString
        Next
    End Function
    Function CreateFolderLine(ByVal Cartella As String) As String

        '06-29-02  03:10PM       <DIR>          prova
        Dim FolderDate As Date
        Dim MultipleText As New StringBuilder()
        Dim DI As DirectoryInfo

        DI = New DirectoryInfo(Cartella)

        FolderDate = DI.LastWriteTime
        FolderDate = FolderDate.ToUniversalTime()

        CreateFolderLine = MakeExtDate(FolderDate) & MultipleText.Append(" ", 7).ToString & "<DIR>" & MultipleText.Append(" ", 3).ToString & DI.Name

    End Function
    Function CreateFileLine(ByVal SrcFile As String) As String

        '06-29-02  05:14PM                  210 dirlist.txt
        Dim FileDate As Date
        'Dim MultipleText As New StringBuilder()
        Dim FI As FileInfo

        FI = New FileInfo(SrcFile)

        FileDate = FI.LastWriteTime
        FileDate = FileDate.ToUniversalTime

        CreateFileLine = MakeExtDate(FileDate) & FI.Length.ToString.PadLeft(21) & " " & FI.Name

    End Function
    Function MakeExtDate(ByVal ItemDate As Date) As String
        Dim Time As String

        If ItemDate.Hour > 12 Then
            Time = String.Format("{0:00}", ItemDate.Hour - 12) & ":" & String.Format("{0:00}", ItemDate.Minute) & "PM"
        Else
            Time = String.Format("{0:00}", ItemDate.Hour) & ":" & String.Format("{0:00}", ItemDate.Minute) & "AM"
        End If

        MakeExtDate = String.Format("{0:00}", ItemDate.Month) & "-" & String.Format("{0:00}", ItemDate.Day) & "-" & String.Format("{0:00}", ItemDate.Year.ToString.Substring(2, 2)) & "  " & Time

    End Function
#End Region
#Region "Misc Functions"

    Public Function CommaTOIP(ByVal CommaIP As String) As IPEndPoint
        'Uno dei comandi potrebbe essere
        '227 Entering Passive Mode (62,149,130,16,195,103).
        'Opening data connection IP: 62.149.130.16 PORT: 50023.
        Dim i As Integer
        Dim IP As String
        Dim Port As Integer
        Dim CommaPOS As Integer

        For i = 1 To 6
            CommaPOS = CommaIP.ToLower.IndexOf(",".ToLower)
            Select Case i
                Case 1, 2, 3
                    IP &= CommaIP.Substring(0, CommaPOS) & "."
                Case 4
                    IP &= CommaIP.Substring(0, CommaPOS)
                Case 5
                    Port = Integer.Parse(CommaIP.Substring(0, CommaPOS)) * 256
                Case 6
                    Port += Integer.Parse(CommaIP)
                Case Else
                    MessageBox.Show("Errore nel select case nel processo di PORT")
            End Select
            'Console.WriteLine("CommaPOS vale {0}", CommaPOS)

            CommaIP = CommaIP.Substring(CommaPOS + 1, CommaIP.Length - (CommaPOS + 1))
        Next i

        CommaTOIP = New IPEndPoint(IPAddress.Parse(IP), Port)
        'Console.WriteLine(CommaTOIP.ToString)

    End Function
    Function IPtoComma(ByVal IPEP As IPEndPoint) As String
        Dim IP As String
        Dim Port1 As String
        Dim Port2 As String

        IP = IPEP.Address.ToString
        IP = IP.Replace(".", ",")

        Port1 = (IPEP.Port \ 256).ToString
        Port2 = (IPEP.Port Mod 256).ToString

        Return IP & "," & Port1 & "," & Port2

    End Function
    Public Overloads Sub SendOnDataSock(ByVal RemoteEp As IPEndPoint, ByVal Data As String)
        '******************************************************************************************
        '------------------------------------------------------------------------------------------
        'Questa Overloads dovrebbe sparire.
        'Assicurati che la socket venga create e preparata con PORT o PASV
        'Fatto questo rimuovi l'overloads e lascia solo la funzione che segue
        '------------------------------------------------------------------------------------------
        '******************************************************************************************

        Dim DataSock As Socket
        Dim Array As Byte()

        Try
            DataSock = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            DataSock.Connect(RemoteEp)

            Array = SendText(Data)

            DataSock.BeginSend(Array, 0, Array.Length, SocketFlags.None, New AsyncCallback(AddressOf EndSend), DataSock)

        Catch exc As Exception

            MessageBox.Show(exc.ToString)

        End Try

    End Sub
    Public Overloads Function SendOnDataSock(ByVal DataSock As Socket, ByVal Data As String) As Boolean

        Dim Array As Byte()
        Dim Adesso As DateTime
        Dim Span As New TimeSpan(0, 0, 2)

        If DataSock Is Nothing Then
            Adesso = DateTime.Now
            Do
            Loop Until DateTime.Now >= Adesso.Add(Span)
        End If

        Try

            Array = SendText(Data)

            DataSock.BeginSend(Array, 0, Array.Length, SocketFlags.None, New AsyncCallback(AddressOf EndSend), DataSock)

            Return True

        Catch exc As Exception

            MessageBox.Show(exc.ToString, "SendOnDataSock")
            Return False

        End Try

    End Function
    Public Sub EndSend(ByVal AR As IAsyncResult)

        Dim TempSock As Socket

        TempSock = AR.AsyncState

        '*************************************
        'Questo potrebbe essere da rimuovere
        'TempSock.Shutdown(SocketShutdown.Both)
        '*************************************

        TempSock.Close()

    End Sub
    Public Function FixPath(ByVal Path As String) As String

        Path = Path.Replace("/", "\")

        Console.WriteLine(Path)

        If Path.Length > 1 And Path.Substring(Path.Length - 1, 1) = "\" Then
            Path = Path.Substring(0, Path.Length - 1)
        End If

        'Select Case Path.Substring(Path.Length - 1, 1)
        '    Case "\"
        '        Path = Path.Substring(0, Path.Length - 1)
        'End Select

        Select Case Path.Substring(0, 1)
            Case "\"
                Return Path
            Case Else
                Return "\" & Path
        End Select
    End Function

    Public Function FixDir(ByVal ServerRoot As String, ByVal UserRoot As String, ByVal Path As String) As String

        Dim BackS As String

        BackS = Path.Replace("/", "\")

        If BackS.IndexOf(".") > 0 Then
            If (BackS.Substring(BackS.IndexOf(".") - 1, 1) = "\") OrElse (BackS.Substring(BackS.IndexOf(".") + 1, 1) = "\") Then
                Return "."
            End If

            Select Case BackS.Substring(0, 1)
                Case "\"
                    Return UserRoot & BackS
                Case Else
                    Return ServerRoot & BackS
            End Select
        End If
    End Function
#End Region

    Public Class Repository

        Dim mXMLUsers As XmlDocument
        Dim mXMLAnon As XmlDocument
        Dim mXMLConf As XmlDocument

        Dim mFTPRoot As String
        Dim mPub As String
        Dim mMachineIP As IPAddress
        Dim mFTPPort As Integer

        Public ReadOnly Property REPUsers() As XmlDocument
            Get
                Return mXMLUsers
            End Get
        End Property
        Public ReadOnly Property REPAnon() As XmlDocument
            Get
                Return mXMLAnon
            End Get
        End Property
        Public ReadOnly Property REPConf() As XmlDocument
            Get
                Return mXMLConf
            End Get
        End Property

        Public ReadOnly Property FTPRoot() As String
            Get
                Return mFTPRoot
            End Get
        End Property
        Public ReadOnly Property AnonDir() As String
            Get
                Return mPub
            End Get
        End Property
        Public ReadOnly Property MachineIP() As IPAddress
            Get
                Return mMachineIP
            End Get
        End Property
        Public ReadOnly Property FTPPort() As Integer
            Get
                Return mFTPPort
            End Get
        End Property

        Public Sub New(ByVal XMLConf As XmlDocument, ByVal XMLUsers As XmlDocument, ByVal XMLAnon As XmlDocument)
            mXMLConf = XMLConf
            mXMLUsers = XMLUsers
            mXMLAnon = XMLAnon
            Call PublishConf()
            'mFTPRoot = Root
        End Sub

        Private Sub PublishConf()
            With mXMLConf.GetElementsByTagName("Configuration").Item(0)
                mFTPRoot = .Item("Root").InnerText
                mMachineIP = IPAddress.Parse(.Item("IP").InnerText())
                mFTPPort = Convert.ToInt32(.Item("Port").InnerText)
            End With

            With mXMLConf.GetElementsByTagName("Configuration").Item(2)
                mPub = .Item("Folder").InnerText
            End With
        End Sub

        Public Sub CreateXMLUser(ByVal ID As String, ByVal RealName As String, ByVal Home As String, ByVal Up As Boolean, ByVal Down As Boolean, ByVal PW As String, ByVal Active As Boolean)

            Dim NewChild As XmlElement
            Dim SubChild As XmlElement
            Dim Attr As XmlAttribute

            NewChild = mXMLUsers.CreateElement("User")

            Attr = mXMLUsers.CreateAttribute("ID")
            Attr.InnerText = ID
            NewChild.Attributes.Append(Attr)

            'SubChild = mXMLUsers.CreateElement("Name")
            'SubChild.InnerText = RealName
            'NewChild.AppendChild(SubChild)

            SubXMLUser(NewChild, SubChild, "Name", RealName)
            SubXMLUser(NewChild, SubChild, "HomeDir", Home)
            SubXMLUser(NewChild, SubChild, "UPload", Up.ToString)
            SubXMLUser(NewChild, SubChild, "DOWNload", Down.ToString)

            SubXMLUser(NewChild, SubChild, "TotalLogin", "0")
            SubXMLUser(NewChild, SubChild, "FirstLogin", "")
            SubXMLUser(NewChild, SubChild, "LastLogin", "")

            SubXMLUser(NewChild, SubChild, "Password", StringToMD5(PW))
            SubXMLUser(NewChild, SubChild, "Active", Active.ToString)

            mXMLUsers.DocumentElement.AppendChild(NewChild)

            mXMLUsers.Save("users.xml")

        End Sub
        Sub SubXMLUser(ByRef Child As XmlElement, ByVal SubChild As XmlElement, ByVal Name As String, ByVal Value As String)

            SubChild = mXMLUsers.CreateElement(Name)
            SubChild.InnerText = Value
            Child.AppendChild(SubChild)

        End Sub

        Public Overloads Sub ModifyXMLUser(ByVal ID As String, ByVal RealName As String, ByVal Home As String, ByVal Up As Boolean, ByVal Down As Boolean, ByVal Active As Boolean)

            With mXMLUsers
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/Name").InnerText = RealName
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/HomeDir").InnerText = Home
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/UPload").InnerText = Up.ToString
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/DOWNload").InnerText = Down.ToString

                .SelectSingleNode("//Users/User[@ID='" & ID & "']/Active").InnerText = Active.ToString
            End With

            mXMLUsers.Save("users.xml")

        End Sub

        Public Overloads Sub ModifyXMLUser(ByVal ID As String, ByVal RealName As String, ByVal Home As String, ByVal Up As Boolean, ByVal Down As Boolean, ByVal Active As Boolean, ByVal PW As String)

            With mXMLUsers
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/Name").InnerText = RealName
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/HomeDir").InnerText = Home
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/UPload").InnerText = Up.ToString
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/DOWNload").InnerText = Down.ToString

                .SelectSingleNode("//Users/User[@ID='" & ID & "']/Password").InnerText = StringToMD5(PW)
                .SelectSingleNode("//Users/User[@ID='" & ID & "']/Active").InnerText = Active.ToString
            End With

            mXMLUsers.Save("users.xml")

        End Sub
        Public Overloads Sub ModifyAccess(ByVal ID As String)
            With mXMLUsers
                If .SelectSingleNode("//Users/User[@ID='" & ID & "']/FirstLogin").InnerText = "" Then
                    .SelectSingleNode("//Users/User[@ID='" & ID & "']/FirstLogin").InnerText = DateTime.Now.ToUniversalTime.ToString
                End If

                .SelectSingleNode("//Users/User[@ID='" & ID & "']/LastLogin").InnerText = DateTime.Now.ToUniversalTime.ToString

                .SelectSingleNode("//Users/User[@ID='" & ID & "']/TotalLogin").InnerText += 1
            End With

            mXMLUsers.Save("users.xml")

        End Sub
        Public Overloads Sub ModifyAccess(ByVal ID As String, ByVal AnonPW As String)
            Dim UserNode As XmlNode

            With mXMLAnon
                Try
                    UserNode = .SelectSingleNode("//AnonUsers/AnonUser[ID='" & AnonPW & "']")
                    .SelectSingleNode("//AnonUsers/AnonUser[ID='" & AnonPW & "']/TotalLogin").InnerText += 1
                    .SelectSingleNode("//AnonUsers/AnonUser[ID='" & AnonPW & "']/LastLogin").InnerText = DateTime.Now.ToUniversalTime.ToString
                Catch
                    UserNode = .CreateElement("AnonUser")
                    Dim Attr As XmlAttribute
                    Dim ChildUser As XmlNode

                    Attr = .CreateAttribute("ID")
                    Attr.InnerText = AnonPW
                    UserNode.Attributes.Append(Attr)

                    ChildUser = .CreateElement("TotalLogin")
                    ChildUser.InnerText = "1"
                    UserNode.AppendChild(ChildUser)

                    ChildUser = .CreateElement("FirstLogin")
                    ChildUser.InnerText = DateTime.Now.ToUniversalTime.ToString
                    UserNode.AppendChild(ChildUser)

                    ChildUser = .CreateElement("FirstLogin")
                    ChildUser.InnerText = DateTime.Now.ToUniversalTime.ToString
                    UserNode.AppendChild(ChildUser)

                    .AppendChild(UserNode)
                End Try
            End With

            mXMLUsers.Save("users.xml")

        End Sub

        Public Sub XMLIPPort(ByVal IP As String, ByVal Port As String)
            With mXMLConf
                .SelectSingleNode("//Configurations/Configuration[@ID='Main']/IP").InnerText = IP
                .SelectSingleNode("//Configurations/Configuration[@ID='Main']/Port").InnerText = Port
            End With

            mXMLConf.Save("conf.xml")
        End Sub

        Public Sub XMLWelRows(ByVal Welcome As String)

            mXMLConf.SelectSingleNode("//Configurations/Configuration[@ID='Welcome']/Row").InnerText = Welcome

            mXMLConf.Save("conf.xml")
        End Sub

        Public Sub XMLModified(ByVal NodeName As String)
            Try
                mXMLConf.SelectSingleNode("//Configurations/Configuration[@ID='Modified']/" & NodeName).InnerText = DateTime.Now.ToString

                mXMLConf.Save("conf.xml")
            Catch exc As Exception
                MessageBox.Show(exc.ToString)
            End Try

        End Sub

        Public Sub XMLACL(ByVal Text() As String)
            'todo Adesso dovrebbe essere a posto Questo non funziona, è da controllare

            Dim Attribute As XmlAttribute
            Dim ACLChild As XmlElement

            'Dim NewChild As XmlElement
            Dim IPChild As XmlElement
            Dim IPString As String

            Try
                ACLChild = mXMLConf.SelectSingleNode("//Configurations/Configuration[@ID='ACL']")

                ACLChild.RemoveAll()

                Attribute = mXMLConf.CreateAttribute("ID")
                Attribute.InnerText = "ACL"

                ACLChild.Attributes.Append(Attribute)

                For Each IPString In Text
                    IPChild = mXMLConf.CreateElement("IP")
                    IPChild.InnerText = IPString
                    ACLChild.AppendChild(IPChild)
                Next


                mXMLConf.Save("conf.xml")
            Catch exc As Exception
                MessageBox.Show(exc.Message.ToString)
            End Try
        End Sub

        Public Sub XMLRoot(ByVal Root As String)
            Try
                mFTPRoot = Root

                mXMLConf.SelectSingleNode("//Configurations/Configuration[@ID='Main']/Root").InnerText = Root.Trim(" ")
                mXMLConf.Save("conf.xml")
            Catch exc As Exception
                MessageBox.Show(exc.ToString)
            End Try
        End Sub

        Public Sub UpdateAno(ByVal Allowed As Boolean, ByVal AnyPW As Boolean, ByVal UPLoad As Boolean)

            With mXMLConf
                .SelectSingleNode("//Configurations/Configuration[@ID='Anon']/AllowAnon").InnerText = Allowed
                .SelectSingleNode("//Configurations/Configuration[@ID='Anon']/AnyPW").InnerText = AnyPW
                .SelectSingleNode("//Configurations/Configuration[@ID='Anon']/UPLoad").InnerText = UPLoad
            End With

            mXMLConf.Save("conf.xml")
        End Sub

        Public Sub DelUser(ByVal ID As String)
            Try
                Dim UpNode As XmlElement

                UpNode = mXMLUsers.SelectSingleNode("//Users")

                UpNode.RemoveChild(mXMLUsers.SelectSingleNode("//Users/User[@ID='" & ID & "']"))

                mXMLUsers.Save("users.xml")

            Catch exc As Xml.XPath.XPathException
                MessageBox.Show(exc.ToString, "XPath")
            Catch exc As Exception
                MessageBox.Show(exc.ToString, "Generic")
            End Try
        End Sub

        Public Sub CleanAnon()
            Try
                Dim Node As XmlElement
                Dim Root As XmlElement

                Root = mXMLAnon.SelectSingleNode("//AnonUsers")

                For Each Node In Root
                    Root.RemoveChild(Node)
                Next

                mXMLUsers.Save("anon.xml")

            Catch exc As Xml.XPath.XPathException
                MessageBox.Show(exc.ToString, "XPath")
            Catch exc As Exception
                MessageBox.Show(exc.ToString, "Generic")
            End Try
        End Sub
    End Class
End Module
