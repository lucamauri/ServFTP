Imports System.Net
Imports System.Net.Sockets
Imports System.Xml

Class Form1
    Inherits System.Windows.Forms.Form

    Public CrLf As String = (Convert.ToChar(10) & Convert.ToChar(13)).ToString

    Public Clients() As FTPSession
    Public BaseList As Socket

    Public XMLCfg As XmlDocument
    Public XMLUsers As XmlDocument
    Dim XMLAnon As XmlDocument

    Public MainRepository As Repository

    Public FTPRoot As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents niMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents mnuNotify As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStatus As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConfig As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents pbSplash As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.niMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.mnuNotify = New System.Windows.Forms.ContextMenu()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuStatus = New System.Windows.Forms.MenuItem()
        Me.mnuConfig = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuClose = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.pbSplash = New System.Windows.Forms.PictureBox()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'niMain
        '
        Me.niMain.Icon = CType(resources.GetObject("niMain.Icon"), System.Drawing.Icon)
        Me.niMain.Text = "ServFTP - Alfa Test"
        Me.niMain.Visible = True
        '
        'mnuNotify
        '
        Me.mnuNotify.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.mnuStatus, Me.mnuConfig, Me.MenuItem1, Me.mnuClose, Me.MenuItem2})
        '
        'MenuItem3
        '
        Me.MenuItem3.DefaultItem = True
        Me.MenuItem3.Index = 0
        Me.MenuItem3.Text = "Consolle"
        '
        'mnuStatus
        '
        Me.mnuStatus.Index = 1
        Me.mnuStatus.Text = "Status Monitor"
        '
        'mnuConfig
        '
        Me.mnuConfig.Index = 2
        Me.mnuConfig.Text = "Configuration"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.Text = "-"
        '
        'mnuClose
        '
        Me.mnuClose.Index = 4
        Me.mnuClose.Text = "Close"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 5
        Me.MenuItem2.Text = "Stop"
        '
        'pbSplash
        '
        Me.pbSplash.Image = CType(resources.GetObject("pbSplash.Image"), System.Drawing.Bitmap)
        Me.pbSplash.Name = "pbSplash"
        Me.pbSplash.Size = New System.Drawing.Size(400, 180)
        Me.pbSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbSplash.TabIndex = 0
        Me.pbSplash.TabStop = False
        '
        'tmrMain
        '
        Me.tmrMain.Enabled = True
        Me.tmrMain.Interval = 2000
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(256, 200)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(128, 16)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Label1"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 200)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Copyright (C) 2001, 2003 Luca Mauri"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "All Rights reserved"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(232, 216)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(152, 16)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "Initializing"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 245)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStatus, Me.Label2, Me.Label1, Me.lblVersion, Me.pbSplash})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        niMain.Visible = False
        'BaseList.Shutdown(SocketShutdown.Both)
        BaseList.Close()
        End
    End Sub

    Private Sub tnrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMain.Tick

        Me.tmrMain.Enabled = False

        'Starts Listening on Port 21
        'All the following informations should be taken from CONF.XML

        Dim LocalEP As IPEndPoint
        Dim ThisMachine As IPAddress
        Dim Port As Integer

        Try

            lblStatus.Text = "Loading Users Repositories"

            XMLUsers = New XmlDocument()
            XMLUsers.Load("users.xml")

            XMLAnon = New XmlDocument()
            XMLAnon.Load("anon.xml")

            lblStatus.Text = "Loading Configurations"

            XMLCfg = New XmlDocument()
            XMLCfg.Load("conf.xml")

            FTPRoot = XMLCfg.GetElementsByTagName("Configuration").Item(0).Item("Root").InnerText

            MainRepository = New Repository(XMLCfg, XMLUsers, XMLAnon)

            lblStatus.Text = "Settign Server"

            'From XML
            'ThisMachine = IPAddress.Loopback
            'ThisMachine = IPAddress.Parse(XMLCfg.GetElementsByTagName("Configuration").Item(0).Item("IP").InnerText())
            ThisMachine = MainRepository.MachineIP


            'From XML
            'LocalEP = New IPEndPoint(ThisMachine, 21)
            'Port = Convert.ToInt32(XMLCfg.GetElementsByTagName("Configuration").Item(0).Item("Port").InnerText)
            Port = MainRepository.FTPPort

            LocalEP = New IPEndPoint(ThisMachine, Port)

            lblStatus.Text = "Creating Socket"

            BaseList = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            lblStatus.Text = "Starting Listener"

            BaseList.Bind(LocalEP)
            BaseList.Listen(10)

            BaseList.BeginAccept(New AsyncCallback(AddressOf CreateClass), BaseList)
        Catch Exc As Exception
            MessageBox.Show("ServFTP is unable to initalize the server. The error is : " & Exc.ToString & "applications will be terminated")
            End
        End Try

        Me.Visible = False

        niMain.ContextMenu = mnuNotify

    End Sub

    Private Sub CreateClass(ByVal AR As IAsyncResult)

        Try
            Dim FreeClient As Integer

            FreeClient = GetFreeClient()

            Clients(FreeClient) = New FTPSession(BaseList.EndAccept(AR), FreeClient, MainRepository)
        Catch e As Exception
            MessageBox.Show(e.ToString)
        End Try

        'Console.WriteLine("Classe creata")

        BaseList.BeginAccept(New AsyncCallback(AddressOf CreateClass), BaseList)

    End Sub
    Public Function GetFreeClient() As Integer

        Dim Counter As Integer

        If Clients Is Nothing Then
            ReDim Preserve Clients(0)
            Return 0
        End If

        For Counter = 0 To Clients.GetUpperBound(0)
            If Not Clients(Counter).Active Then
                Return Counter
            End If
        Next

        ReDim Preserve Clients(Counter)
        Return Counter

    End Function


    Private Sub mnuConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfig.Click

        Dim WinConf As New frmConf(MainRepository)
        WinConf.ShowDialog()

    End Sub

    Private Sub mnuStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatus.Click

        Dim WinStatus As New frmMonitor(Clients)
        WinStatus.ShowDialog()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = Application.ProductName & " " & Application.ProductVersion
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim P1 As Pen
        Dim P2 As Pen
        Dim GR As Graphics

        P1 = New Pen(Color.White, 2)
        P2 = New Pen(Color.Gray, 1)

        GR = e.Graphics

        GR.DrawLine(P1, 0, pbSplash.Height, pbSplash.Width, pbSplash.Height)
        GR.DrawLine(P2, 0, pbSplash.Height + 1, pbSplash.Width, pbSplash.Height + 1)

        niMain.Text = "ServFTP v." & Application.ProductName & " " & Application.ProductVersion & " - Alpha"

    End Sub

    Private Sub niMain_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niMain.MouseDown

    End Sub
End Class
