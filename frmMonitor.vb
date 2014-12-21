Public Class frmMonitor
    Inherits System.Windows.Forms.Form

    'Dim LoclRep As Repository
    Private LoclSessions() As FTPSession

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef Sess() As FTPSession)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoclSessions = Sess
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvSess As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbCons As System.Windows.Forms.ListBox
    Friend WithEvents ilUsers As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMonitor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvSess = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbCons = New System.Windows.Forms.ListBox()
        Me.ilUsers = New System.Windows.Forms.ImageList(Me.components)
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvSess})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 240)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection Overview"
        '
        'lvSess
        '
        Me.lvSess.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvSess.Location = New System.Drawing.Point(8, 16)
        Me.lvSess.Name = "lvSess"
        Me.lvSess.Size = New System.Drawing.Size(520, 200)
        Me.lvSess.SmallImageList = Me.ilUsers
        Me.lvSess.TabIndex = 0
        Me.lvSess.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        Me.ColumnHeader2.Width = 30
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "UserName"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Remote IP"
        Me.ColumnHeader3.Width = 100
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(464, 264)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbCons})
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 176)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Command Line Console"
        '
        'lbCons
        '
        Me.lbCons.BackColor = System.Drawing.Color.Black
        Me.lbCons.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCons.ForeColor = System.Drawing.Color.Lime
        Me.lbCons.ItemHeight = 14
        Me.lbCons.Location = New System.Drawing.Point(8, 24)
        Me.lbCons.Name = "lbCons"
        Me.lbCons.Size = New System.Drawing.Size(408, 144)
        Me.lbCons.TabIndex = 1
        '
        'ilUsers
        '
        Me.ilUsers.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilUsers.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilUsers.ImageStream = CType(resources.GetObject("ilUsers.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilUsers.TransparentColor = System.Drawing.Color.Transparent
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Directory"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Action"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "%"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Speed"
        '
        'tmrMain
        '
        Me.tmrMain.Enabled = True
        Me.tmrMain.Interval = 5000
        '
        'frmMonitor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(616, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.Button1, Me.GroupBox1})
        Me.Name = "frmMonitor"
        Me.Text = "Status Monitor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call UpdateList()
    End Sub

    Private Sub UpdateList()
        Dim CurrSess As FTPSession
        Dim LVI As ListViewItem

        Dim TempIP As System.Net.IPEndPoint

        lvSess.Items.Clear()
        ConsEntry("ListBox cleared")

        If Not LoclSessions Is Nothing Then
            ConsEntry("There are active sessions, enumerating")

            For Each CurrSess In LoclSessions
                TempIP = CurrSess.ClientIP

                LVI = lvSess.Items.Add(CurrSess.IDSession)
                LVI.ImageIndex = CInt(CBool(CurrSess.Active)) * (-1)

                With LVI.SubItems
                    .Add(CurrSess.User.UserID)
                    .Add(TempIP.Address.ToString)
                    .Add(CurrSess.User.CurrDir)
                End With

                ConsEntry("Enumerating items")

            Next

        End If
    End Sub

    Private Sub ConsEntry(ByVal Entry As String)
        Dim Now As DateTime

        Now = DateTime.Now.ToUniversalTime

        lbCons.Items.Add(Now.ToString & " " & Entry)

        lbCons.SetSelected(lbCons.Items.Count - 1, True)

    End Sub

    Private Sub tmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMain.Tick

        Call UpdateList()

        Try
            Dim i As Integer

            If lbCons.Items.Count > 300 Then
                For i = 1 To 25
                    lbCons.Items.RemoveAt(0)
                Next i

                ConsEntry("Message Purged")

            End If

        Catch exc As Exception
            MessageBox.Show(exc.ToString)
        End Try
    End Sub
End Class
