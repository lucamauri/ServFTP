Imports System.Xml

Public Class frmUsers
    Inherits System.Windows.Forms.Form
    Public LoclRep As Repository

#Region " Windows Form Designer generated code "

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
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents chUserID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAccesses As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLast As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDown As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUp As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRoot As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMain As System.Windows.Forms.ListView
    Friend WithEvents chFirst As System.Windows.Forms.ColumnHeader
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnon As System.Windows.Forms.ListView
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnClean As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUsers))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.lvMain = New System.Windows.Forms.ListView()
        Me.chUserID = New System.Windows.Forms.ColumnHeader()
        Me.chName = New System.Windows.Forms.ColumnHeader()
        Me.chRoot = New System.Windows.Forms.ColumnHeader()
        Me.chUp = New System.Windows.Forms.ColumnHeader()
        Me.chDown = New System.Windows.Forms.ColumnHeader()
        Me.chAccesses = New System.Windows.Forms.ColumnHeader()
        Me.chFirst = New System.Windows.Forms.ColumnHeader()
        Me.chLast = New System.Windows.Forms.ColumnHeader()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.lvAnon = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(472, 384)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnModify, Me.lvMain, Me.cmdDel, Me.cmdAdd})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 192)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Regular Users"
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(304, 160)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.TabIndex = 3
        Me.btnModify.Text = "Modify..."
        '
        'lvMain
        '
        Me.lvMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chUserID, Me.chName, Me.chRoot, Me.chUp, Me.chDown, Me.chAccesses, Me.chFirst, Me.chLast})
        Me.lvMain.FullRowSelect = True
        Me.lvMain.Location = New System.Drawing.Point(8, 24)
        Me.lvMain.MultiSelect = False
        Me.lvMain.Name = "lvMain"
        Me.lvMain.Size = New System.Drawing.Size(528, 128)
        Me.lvMain.SmallImageList = Me.ilMain
        Me.lvMain.TabIndex = 0
        Me.lvMain.View = System.Windows.Forms.View.Details
        '
        'chUserID
        '
        Me.chUserID.Text = "UserID"
        Me.chUserID.Width = 80
        '
        'chName
        '
        Me.chName.Text = "Real Name"
        Me.chName.Width = 120
        '
        'chRoot
        '
        Me.chRoot.Text = "Root Folder"
        Me.chRoot.Width = 100
        '
        'chUp
        '
        Me.chUp.Text = "Up"
        Me.chUp.Width = 40
        '
        'chDown
        '
        Me.chDown.Text = "Down"
        Me.chDown.Width = 40
        '
        'chAccesses
        '
        Me.chAccesses.Text = "Accesses"
        '
        'chFirst
        '
        Me.chFirst.Text = "First Access"
        Me.chFirst.Width = 120
        '
        'chLast
        '
        Me.chLast.Text = "Last Access"
        Me.chLast.Width = 120
        '
        'ilMain
        '
        Me.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilMain.ImageStream = CType(resources.GetObject("ilMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmdDel
        '
        Me.cmdDel.Location = New System.Drawing.Point(384, 160)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.TabIndex = 1
        Me.cmdDel.Text = "Delete..."
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(456, 160)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Add..."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClean, Me.lvAnon})
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 168)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Anonymous Users"
        '
        'btnClean
        '
        Me.btnClean.Location = New System.Drawing.Point(456, 136)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.TabIndex = 1
        Me.btnClean.Text = "Cleanup"
        '
        'lvAnon
        '
        Me.lvAnon.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvAnon.FullRowSelect = True
        Me.lvAnon.Location = New System.Drawing.Point(8, 24)
        Me.lvAnon.Name = "lvAnon"
        Me.lvAnon.Size = New System.Drawing.Size(528, 104)
        Me.lvAnon.SmallImageList = Me.ilMain
        Me.lvAnon.TabIndex = 0
        Me.lvAnon.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "E-Mail Address"
        Me.ColumnHeader1.Width = 130
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Accesses"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "First Access"
        Me.ColumnHeader7.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Last Access"
        Me.ColumnHeader8.Width = 120
        '
        'frmUsers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(554, 415)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1, Me.cmdClose})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsers"
        Me.ShowInTaskbar = False
        Me.Text = "Users"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call EnumerateUsers()
    End Sub

    Sub EnumerateUsers()
        Dim Node As XmlNode
        Dim ChildNode As XmlNode
        Dim CurrName As String

        lvMain.Items.Clear()

        For Each Node In LoclRep.REPUsers.GetElementsByTagName("Users").Item(0)
            Dim LVI As ListViewItem

            CurrName = Node.Attributes.Item(0).InnerText
            'CurrName = ChildNode.Attributes.ItemOf(0).InnerText
            LVI = lvMain.Items.Add(CurrName)
            LVI.SubItems(0).Text = CurrName
            For Each ChildNode In Node
                Select Case ChildNode.Name.ToLower
                    Case "password"
                    Case "active"
                        LVI.ImageIndex = CBool(ChildNode.InnerText) * (-1)
                    Case Else
                        LVI.SubItems.Add(ChildNode.InnerText)
                End Select
            Next
        Next

        lvAnon.Items.Clear()
        For Each Node In LoclRep.REPAnon.GetElementsByTagName("AnonUsers").Item(0)
            Dim AllowAnon As Boolean = True
            Dim LVI As ListViewItem

            CurrName = Node.Attributes.Item(0).InnerText

            LVI = lvAnon.Items.Add(CurrName)
            LVI.SubItems(0).Text = CurrName

            For Each ChildNode In Node
                LVI.SubItems.Add(ChildNode.InnerText)
                lvi.ImageIndex = CInt(AllowAnon) * (-2)
            Next
        Next
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Dim Window As frmAddUser

        Window = New frmAddUser(LoclRep)

        Window.ShowDialog()

        Call EnumerateUsers()

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        LoclRep.XMLModified("Users")

        Me.Close()

    End Sub

    
    Private Sub lvMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMain.DoubleClick, btnModify.Click

        Dim First As Date
        Dim Last As Date
        Dim Window As frmAddUser

        If lvMain.SelectedItems.Count > 0 Then
            With lvMain.SelectedItems.Item(0)
                If .SubItems(6).Text = "" Or .SubItems(7).Text = "" Then
                    First = Nothing
                    Last = Nothing
                Else
                    First = .SubItems(6).Text
                    Last = .SubItems(7).Text
                End If

                Window = New frmAddUser(LoclRep, .SubItems(0).Text, .SubItems(1).Text, .SubItems(2).Text, CBool(.ImageIndex), CBool(.SubItems(3).Text), CBool(.SubItems(4).Text), .SubItems(5).Text, First, Last)

            End With

            Window.ShowDialog()

            Call EnumerateUsers()
        End If

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        If MessageBox.Show("Are you sure you want to dleete user " & lvMain.SelectedItems.Item(0).Text, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            LoclRep.DelUser(lvMain.SelectedItems.Item(0).Text)

            Call EnumerateUsers()

        Else
            MessageBox.Show("User deletion cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
        If MessageBox.Show("Are you  sure you want to delte all the information on Anonymous acessess ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            LoclRep.CleanAnon()

            Call EnumerateUsers()

        Else
            MessageBox.Show("User deletion cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
