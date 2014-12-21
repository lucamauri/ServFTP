Public Class frmConf
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public LoclRep As Repository

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConf))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Folders", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Manage Folder Tree"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "")}, 0)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Network", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Manage Netword properties and permissions"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "")}, 1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Options", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "General Options for the server"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "")}, 2)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Security", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Security options"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "")}, 3)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Users", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Manage users"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "")}, 4)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.chName = New System.Windows.Forms.ColumnHeader()
        Me.chDesc = New System.Windows.Forms.ColumnHeader()
        Me.chDate = New System.Windows.Forms.ColumnHeader()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(497, 68)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chDesc, Me.chDate})
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5})
        Me.ListView1.Location = New System.Drawing.Point(8, 80)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(480, 216)
        Me.ListView1.SmallImageList = Me.ilMain
        Me.ListView1.TabIndex = 1
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Nome"
        Me.chName.Width = 100
        '
        'chDesc
        '
        Me.chDesc.Text = "Description"
        Me.chDesc.Width = 245
        '
        'chDate
        '
        Me.chDate.Text = "Last Modified"
        Me.chDate.Width = 115
        '
        'ilMain
        '
        Me.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilMain.ImageStream = CType(resources.GetObject("ilMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(408, 304)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 304)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        '
        'frmConf
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 333)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.cmdClose, Me.ListView1, Me.PictureBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConf"
        Me.Text = "servFTP Configuration Console"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        Select Case ListView1.SelectedItems.Item(0).Text.ToLower
            Case "folders"
                Dim Window As New frmFold(LoclRep)
                Window.ShowDialog()
            Case "network"
                Dim Window As New frmNet(LoclRep)
                Window.ShowDialog()
            Case "options"
                Dim Window As New frmGen(LoclRep)
                Window.ShowDialog()
            Case "security"
                Dim Window As New frmSec(LoclRep)
                Window.ShowDialog()
            Case "users"
                Dim Window As New frmUsers(LoclRep)
                Window.ShowDialog()
            Case Else
                MessageBox.Show("Not YET Implemented")
        End Select

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub frmConf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Element As ListViewItem

        Try
            For Each Element In ListView1.Items
                Element.SubItems(2).Text = LoclRep.REPConf.SelectSingleNode("//Configurations/Configuration[@ID='Modified']/" & Element.Text).InnerText
            Next
        Catch exc As Exception
            MessageBox.Show(exc.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Pingatore As Pinger

        pingatore = New Pinger()

        MessageBox.Show(Pingatore.GetPINGTime("localhost"))


    End Sub
End Class
