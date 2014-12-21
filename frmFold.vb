Imports System.IO
Imports System.IO.Directory
Imports System.Environment

Public Class frmFold
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Dim LoclRep As Repository

    Public Sub New(ByRef PassRep As Repository)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoclRep = PassRep

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
    Friend WithEvents tvFolder As System.Windows.Forms.TreeView
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Files As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents lblNumFiles As System.Windows.Forms.Label
    Friend WithEvents lblNumFolders As System.Windows.Forms.Label
    Friend WithEvents lblNumSize As System.Windows.Forms.Label
    Friend WithEvents lblCurrDir As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNewDir As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnExplore As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFold))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tvFolder = New System.Windows.Forms.TreeView()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblNumSize = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblNumFolders = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumFiles = New System.Windows.Forms.Label()
        Me.Files = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnExplore = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.txtNewDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCurrDir = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tvFolder})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 280)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FTP Folders List"
        '
        'tvFolder
        '
        Me.tvFolder.ImageList = Me.ilMain
        Me.tvFolder.Location = New System.Drawing.Point(8, 24)
        Me.tvFolder.Name = "tvFolder"
        Me.tvFolder.PathSeparator = ""
        Me.tvFolder.Size = New System.Drawing.Size(208, 248)
        Me.tvFolder.TabIndex = 0
        '
        'ilMain
        '
        Me.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilMain.ImageStream = CType(resources.GetObject("ilMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNumSize, Me.lblSize, Me.lblNumFolders, Me.Label3, Me.lblNumFiles, Me.Files})
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(240, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 120)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Folder Statistics"
        '
        'lblNumSize
        '
        Me.lblNumSize.Location = New System.Drawing.Point(120, 72)
        Me.lblNumSize.Name = "lblNumSize"
        Me.lblNumSize.TabIndex = 5
        Me.lblNumSize.Text = "Label1"
        '
        'lblSize
        '
        Me.lblSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(8, 72)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.TabIndex = 4
        Me.lblSize.Text = "Size"
        '
        'lblNumFolders
        '
        Me.lblNumFolders.Location = New System.Drawing.Point(120, 48)
        Me.lblNumFolders.Name = "lblNumFolders"
        Me.lblNumFolders.TabIndex = 3
        Me.lblNumFolders.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Folders"
        '
        'lblNumFiles
        '
        Me.lblNumFiles.Location = New System.Drawing.Point(120, 24)
        Me.lblNumFiles.Name = "lblNumFiles"
        Me.lblNumFiles.TabIndex = 1
        Me.lblNumFiles.Text = "Label2"
        '
        'Files
        '
        Me.Files.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Files.Location = New System.Drawing.Point(8, 24)
        Me.Files.Name = "Files"
        Me.Files.TabIndex = 0
        Me.Files.Text = "Files"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExplore, Me.btnChange, Me.txtNewDir, Me.Label1, Me.lblCurrDir, Me.Button2, Me.Button1})
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(240, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(232, 144)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Actions"
        '
        'btnExplore
        '
        Me.btnExplore.Location = New System.Drawing.Point(120, 112)
        Me.btnExplore.Name = "btnExplore"
        Me.btnExplore.TabIndex = 6
        Me.btnExplore.Text = "Open in explorer"
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(32, 112)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(80, 23)
        Me.btnChange.TabIndex = 5
        Me.btnChange.Text = "Change Root"
        '
        'txtNewDir
        '
        Me.txtNewDir.Location = New System.Drawing.Point(8, 72)
        Me.txtNewDir.Name = "txtNewDir"
        Me.txtNewDir.Size = New System.Drawing.Size(136, 21)
        Me.txtNewDir.TabIndex = 4
        Me.txtNewDir.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter New Dir Name"
        '
        'lblCurrDir
        '
        Me.lblCurrDir.Location = New System.Drawing.Point(8, 24)
        Me.lblCurrDir.Name = "lblCurrDir"
        Me.lblCurrDir.Size = New System.Drawing.Size(136, 23)
        Me.lblCurrDir.TabIndex = 2
        Me.lblCurrDir.Text = "Label1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Create"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(152, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Remove ..."
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(392, 296)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'frmFold
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(474, 327)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFold"
        Me.Text = "Folder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmFold_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Watcher As FileSystemWatcher

        Call InitiateTree()

        Watcher = New FileSystemWatcher(LoclRep.FTPRoot)
        Watcher.NotifyFilter = NotifyFilters.DirectoryName Or NotifyFilters.CreationTime

        AddHandler Watcher.Created, AddressOf OnModification
        AddHandler Watcher.Deleted, AddressOf OnModification

        tvFolder.Nodes.Item(0).Expand()

    End Sub

    Private Sub OnModification(ByVal Source As Object, ByVal e As FileSystemEventArgs)

        Call InitiateTree()

    End Sub

    Private Sub InitiateTree()
        Dim Root As String

        If Not Directory.Exists(LoclRep.FTPRoot) Then
            Do
                Root = BrowseForFolder(Me, "Choose root directory", "c:\")
            Loop While Root = ""
            ChangeRoot(Root)
        End If

        Dim Dir As String
        With tvFolder.Nodes
            .Clear()
            .Add(LoclRep.FTPRoot)
            .Item(0).ImageIndex = 0
        End With

        tvFolder.SelectedNode = tvFolder.Nodes.Item(0)

        Call MakeFolder(tvFolder.Nodes.Item(0), tvFolder.Nodes.Item(0).Text)
    End Sub

    Private Sub MakeFolder(ByVal Node As TreeNode, ByVal Path As String)

        Dim Dir As String
        Dim AddNode As TreeNode

        For Each Dir In Directory.GetDirectories(Path)

            AddNode = New TreeNode(Dir.Substring(Path.Length), 1, 1)

            If AddNode.Text = LoclRep.AnonDir Then
                AddNode.ImageIndex = 2
            End If

            Node.Nodes.Add(AddNode)

            Call MakeFolder(AddNode, Dir)

        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If txtNewDir.Text = "" Then
            MessageBox.Show("Wrote the new directory name in the left textbox, this will became a subdir of the currente selected directory", "Choose a name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Directory.CreateDirectory(lblCurrDir.Text & "\" & txtNewDir.Text)
            InitiateTree()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If tvFolder.Nodes.Item(0).IsSelected Then
            MessageBox.Show("You cannot delete the Root of the server. First change it and then delete the old one via Windows Explorer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            If MessageBox.Show("Are you sure you want to delete the following directory:" & CrLf & tvFolder.SelectedNode.FullPath, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                Try
                    Directory.Delete(tvFolder.SelectedNode.FullPath, True)
                    MessageBox.Show("Item deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InitiateTree()
                Catch exc As Exception
                    MessageBox.Show("Unable to delete selected item. .NET Framework reported the following error:" & CrLf & exc.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try

            End If
        End If

    End Sub

    Private Sub tvFolder_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFolder.AfterSelect

        lblCurrDir.Text = tvFolder.SelectedNode.FullPath.ToString.Replace("\\", "\")

        Dim Folder As String
        Dim File As String
        Dim NumFiles As Integer
        Dim Info As FileInfo
        Dim Size As Double
        Dim Folders As Integer
        Dim Files As Integer

        Folders = 0
        NumFiles = 0

        For Each Folder In Directory.GetDirectories(tvFolder.SelectedNode.FullPath)
            Folders += 1
        Next

        For Each File In Directory.GetFiles(tvFolder.SelectedNode.FullPath)
            Info = New FileInfo(File)
            Size += Info.Length()
            NumFiles += 1
        Next

        lblNumFiles.Text = NumFiles.ToString
        lblNumFolders.Text = Folders.ToString
        lblNumSize.Text = (Math.Round((Size / 1024), 2)).ToString & " KB"

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        LoclRep.XMLModified("Folders")

        Me.Close()

    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click

        'todo Controlla che venga modificata solo quando NOn ci sono sessioni attive

        Dim Folder As String

        Folder = BrowseForFolder(Me, "Select new Root directory for SERVER", LoclRep.FTPRoot)

        If Not (Folder = "") Then
            ChangeRoot(Folder)
        End If

    End Sub

    Private Function ChangeRoot(ByVal Root As String) As Boolean

        LoclRep.XMLRoot(Root)
        Return True

    End Function

    Private Sub btnExplore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExplore.Click

        Dim ExProcess As New Process()
        Dim LaunchString As String
        Dim WinFolder As DirectoryInfo

        WinFolder = Directory.GetParent(GetFolderPath(SpecialFolder.System))
        LaunchString = WinFolder.ToString & "\explorer.exe " ' & Convert.ToChar(34) & LoclRep.FTPRoot & Convert.ToChar(34)

        Try
            ExProcess.Start(LaunchString)
        Catch exc As Exception
            MessageBox.Show("impossibile to open " & LaunchString & CrLf & exc.ToString)
        End Try

    End Sub
End Class
