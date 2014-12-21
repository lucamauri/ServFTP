Imports System.IO
Imports System.Drawing

Public Class frmAddUser
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public LoclRep As Repository

    Public Sub New(ByRef PassRep As Repository, Optional ByVal ID As String = "", Optional ByVal Name As String = "", Optional ByVal Directory As String = "", Optional ByVal Active As Boolean = True, Optional ByVal Up As Boolean = True, Optional ByVal Down As Boolean = True, Optional ByVal Accessess As Integer = 0, Optional ByVal First As Date = #1/1/1900#, Optional ByVal Last As Date = #1/1/1900#)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoclRep = PassRep

        txtID.Text = ID
        txtName.Text = Name
        txtFolder.Text = Directory


        chkAct.Checked = Active
        chkUP.Checked = Up
        chkDown.Checked = Down

        If CBool(ID.Length) Then
            txtID.Enabled = False
            txtID.BorderStyle = BorderStyle.None
            txtPW.Text = "12345678901234567890"
            txtPW2.Text = "12345678901234567890"
            cmdOK.Text = "Modify"

            If Accessess = 0 Then
                FirstLoginDate.Text = "<No Login Recorded>"
                LastLoginDate.Text = "<No Login Recorded>"
            Else
                FirstLoginDate.Text = First.ToString
                LastLoginDate.Text = Last.ToString
            End If

            TotAccessess.Text = Accessess.ToString
            
        End If
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
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFolder As System.Windows.Forms.TextBox
    Friend WithEvents txtPW As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkAct As System.Windows.Forms.CheckBox
    Friend WithEvents chkDown As System.Windows.Forms.CheckBox
    Friend WithEvents chkUP As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAccessess As System.Windows.Forms.Label
    Friend WithEvents lblFirst As System.Windows.Forms.Label
    Friend WithEvents lblLast As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPW2 As System.Windows.Forms.TextBox
    Friend WithEvents FirstLoginDate As System.Windows.Forms.Label
    Friend WithEvents LastLoginDate As System.Windows.Forms.Label
    Friend WithEvents TotAccessess As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddUser))
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtPW2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkAct = New System.Windows.Forms.CheckBox()
        Me.chkDown = New System.Windows.Forms.CheckBox()
        Me.chkUP = New System.Windows.Forms.CheckBox()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtPW = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TotAccessess = New System.Windows.Forms.Label()
        Me.LastLoginDate = New System.Windows.Forms.Label()
        Me.FirstLoginDate = New System.Windows.Forms.Label()
        Me.lblLast = New System.Windows.Forms.Label()
        Me.lblFirst = New System.Windows.Forms.Label()
        Me.lblAccessess = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(168, 360)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "Create"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(248, 360)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(320, 344)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPW2, Me.Label6, Me.Label5, Me.chkAct, Me.chkDown, Me.chkUP, Me.txtFolder, Me.btnBrowse, Me.txtPW, Me.txtName, Me.Label4, Me.Label3, Me.Label2, Me.txtID, Me.Label1, Me.PictureBox1})
        Me.TabPage1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(312, 318)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User"
        '
        'txtPW2
        '
        Me.txtPW2.Location = New System.Drawing.Point(120, 160)
        Me.txtPW2.Name = "txtPW2"
        Me.txtPW2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPW2.TabIndex = 4
        Me.txtPW2.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Retype Password"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Options"
        '
        'chkAct
        '
        Me.chkAct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkAct.Location = New System.Drawing.Point(120, 280)
        Me.chkAct.Name = "chkAct"
        Me.chkAct.Size = New System.Drawing.Size(144, 24)
        Me.chkAct.TabIndex = 9
        Me.chkAct.Text = "Activate User Account"
        '
        'chkDown
        '
        Me.chkDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkDown.Location = New System.Drawing.Point(120, 256)
        Me.chkDown.Name = "chkDown"
        Me.chkDown.Size = New System.Drawing.Size(136, 24)
        Me.chkDown.TabIndex = 8
        Me.chkDown.Text = "Allow DownLoad"
        '
        'chkUP
        '
        Me.chkUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkUP.Location = New System.Drawing.Point(120, 232)
        Me.chkUP.Name = "chkUP"
        Me.chkUP.Size = New System.Drawing.Size(136, 24)
        Me.chkUP.TabIndex = 7
        Me.chkUP.Text = "Allow Upload"
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(119, 192)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.TabIndex = 5
        Me.txtFolder.Text = ""
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(232, 192)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.Text = "Browse..."
        '
        'txtPW
        '
        Me.txtPW.Location = New System.Drawing.Point(119, 128)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPW.TabIndex = 3
        Me.txtPW.Text = ""
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(119, 96)
        Me.txtName.Name = "txtName"
        Me.txtName.TabIndex = 2
        Me.txtName.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "HomeDir"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Password"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "True Name"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(120, 48)
        Me.txtID.Name = "txtID"
        Me.txtID.TabIndex = 1
        Me.txtID.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "UserID"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(312, 318)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Statistics"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TotAccessess, Me.LastLoginDate, Me.FirstLoginDate, Me.lblLast, Me.lblFirst, Me.lblAccessess})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 136)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Basic Statistics"
        '
        'TotAccessess
        '
        Me.TotAccessess.Location = New System.Drawing.Point(144, 96)
        Me.TotAccessess.Name = "TotAccessess"
        Me.TotAccessess.Size = New System.Drawing.Size(136, 23)
        Me.TotAccessess.TabIndex = 5
        Me.TotAccessess.Text = "Label9"
        '
        'LastLoginDate
        '
        Me.LastLoginDate.Location = New System.Drawing.Point(144, 64)
        Me.LastLoginDate.Name = "LastLoginDate"
        Me.LastLoginDate.Size = New System.Drawing.Size(136, 23)
        Me.LastLoginDate.TabIndex = 4
        Me.LastLoginDate.Text = "Label8"
        '
        'FirstLoginDate
        '
        Me.FirstLoginDate.Location = New System.Drawing.Point(144, 32)
        Me.FirstLoginDate.Name = "FirstLoginDate"
        Me.FirstLoginDate.Size = New System.Drawing.Size(136, 23)
        Me.FirstLoginDate.TabIndex = 3
        Me.FirstLoginDate.Text = "Label7"
        '
        'lblLast
        '
        Me.lblLast.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLast.Location = New System.Drawing.Point(16, 96)
        Me.lblLast.Name = "lblLast"
        Me.lblLast.Size = New System.Drawing.Size(112, 23)
        Me.lblLast.TabIndex = 2
        Me.lblLast.Text = "Total Accessess"
        '
        'lblFirst
        '
        Me.lblFirst.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirst.Location = New System.Drawing.Point(16, 64)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(120, 23)
        Me.lblFirst.TabIndex = 1
        Me.lblFirst.Text = "Last Login (UTC)"
        '
        'lblAccessess
        '
        Me.lblAccessess.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessess.Location = New System.Drawing.Point(16, 32)
        Me.lblAccessess.Name = "lblAccessess"
        Me.lblAccessess.Size = New System.Drawing.Size(120, 23)
        Me.lblAccessess.TabIndex = 0
        Me.lblAccessess.Text = "First Login (UTC)"
        '
        'frmAddUser
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 386)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.cmdCancel, Me.cmdOK})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddUser"
        Me.Text = "User Manger"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Dim Folder As String

        Folder = BrowseForFolder(Me, "Select root directory for THIS user", LoclRep.FTPRoot)

        If (Folder.Length < LoclRep.FTPRoot.Length) Or ((Not (Folder.Substring(0, LoclRep.FTPRoot.Length) = LoclRep.FTPRoot)) And (Folder.Length > 0)) Then
            MessageBox.Show("You must choose a SUBfolder of the root (" & LoclRep.FTPRoot & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If CBool(Folder.Length) Then
                If Folder.Length = LoclRep.FTPRoot.Length Then
                    txtFolder.Text = "\"
                Else
                    txtFolder.Text = Folder.Substring(LoclRep.FTPRoot.Length)
                End If
            End If
            End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        If Not Directory.Exists(LoclRep.FTPRoot & txtFolder.Text) Then
            MessageBox.Show("RootFolder is not valid", "Incorrect RootFolder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not txtPW.Text = txtPW2.Text Then
            MessageBox.Show("Password does not match, please retype both", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtID.Text.ToLower = "anonymous" Then
            MessageBox.Show("'Anonymous' is not a valid username", "UserID reserved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If CBool(txtID.Text.Length) And CBool(txtFolder.Text.Length) Then
            If Not CBool(txtPW.Text.Length) Then

                If MessageBox.Show("Password is empty, are you sure you want to allow unprotected access for this user ?", "Confirm empty password ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then

                    Exit Sub

                End If

            End If

            If cmdOK.Text = "Create" Then
                LoclRep.CreateXMLUser(txtID.Text, txtName.Text, txtFolder.Text, chkUP.Checked, chkDown.Checked, txtPW.Text, chkAct.Checked)
                Me.Close()
            Else
                If txtPW.Modified Then
                    LoclRep.ModifyXMLUser(txtID.Text, txtName.Text, txtFolder.Text, chkUP.Checked, chkDown.Checked, chkAct.Checked, txtPW.Text)
                Else
                    LoclRep.ModifyXMLUser(txtID.Text, txtName.Text, txtFolder.Text, chkUP.Checked, chkDown.Checked, chkAct.Checked)
                End If
                Me.Close()
            End If

        Else
            MessageBox.Show("You have to fill USERID and FOLDER fields, at least", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub TabPage1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint
        Dim P1 As Pen
        Dim P2 As Pen
        Dim GR As Graphics

        P1 = New Pen(Color.White, 2)
        P2 = New Pen(Color.Gray, 1)

        GR = e.Graphics

        GR.DrawLine(P1, 10, TabPage1.Height - 95, TabPage1.Width - 10, TabPage1.Height - 95)
        GR.DrawLine(P2, 10, TabPage1.Height - 96, TabPage1.Width - 10, TabPage1.Height - 96)

    End Sub

    Private Sub frmAddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged

    End Sub
End Class