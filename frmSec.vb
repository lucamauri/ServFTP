Public Class frmSec
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAnonUP As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnonPW As System.Windows.Forms.CheckBox
    Friend WithEvents cbAllowAnon As System.Windows.Forms.CheckBox
    Friend WithEvents tpmisc As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbPASV As System.Windows.Forms.CheckBox
    Friend WithEvents cbBounce As System.Windows.Forms.CheckBox
    Friend WithEvents cbPort As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtIP4 As System.Windows.Forms.TextBox
    Friend WithEvents txtIP3 As System.Windows.Forms.TextBox
    Friend WithEvents txtIP2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIP1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents lbIP As System.Windows.Forms.ListBox
    Friend WithEvents Except As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents rbDenied As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllowed As System.Windows.Forms.RadioButton
    Friend WithEvents cbSyst As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSec))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Except = New System.Windows.Forms.Label()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbDenied = New System.Windows.Forms.RadioButton()
        Me.rbAllowed = New System.Windows.Forms.RadioButton()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.lbIP = New System.Windows.Forms.ListBox()
        Me.txtIP4 = New System.Windows.Forms.TextBox()
        Me.txtIP3 = New System.Windows.Forms.TextBox()
        Me.txtIP2 = New System.Windows.Forms.TextBox()
        Me.txtIP1 = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbAnonUP = New System.Windows.Forms.CheckBox()
        Me.cbAnonPW = New System.Windows.Forms.CheckBox()
        Me.cbAllowAnon = New System.Windows.Forms.CheckBox()
        Me.tpmisc = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbSyst = New System.Windows.Forms.CheckBox()
        Me.cbPort = New System.Windows.Forms.CheckBox()
        Me.cbBounce = New System.Windows.Forms.CheckBox()
        Me.cbPASV = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tpmisc.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.tpmisc})
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(320, 328)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(312, 302)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Access Control List"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Except, Me.cmdRemove, Me.Label1, Me.rbDenied, Me.rbAllowed, Me.cmdAdd, Me.lbIP, Me.txtIP4, Me.txtIP3, Me.txtIP2, Me.txtIP1})
        Me.GroupBox1.Location = New System.Drawing.Point(24, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 280)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Access Control List"
        '
        'Except
        '
        Me.Except.Location = New System.Drawing.Point(8, 72)
        Me.Except.Name = "Except"
        Me.Except.Size = New System.Drawing.Size(144, 16)
        Me.Except.TabIndex = 9
        Me.Except.Text = "except the following"
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(64, 248)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.TabIndex = 8
        Me.cmdRemove.Text = "Remove"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "All addressess are "
        '
        'rbDenied
        '
        Me.rbDenied.Checked = True
        Me.rbDenied.Location = New System.Drawing.Point(24, 48)
        Me.rbDenied.Name = "rbDenied"
        Me.rbDenied.Size = New System.Drawing.Size(72, 24)
        Me.rbDenied.TabIndex = 0
        Me.rbDenied.TabStop = True
        Me.rbDenied.Text = "Denied"
        '
        'rbAllowed
        '
        Me.rbAllowed.Location = New System.Drawing.Point(120, 48)
        Me.rbAllowed.Name = "rbAllowed"
        Me.rbAllowed.Size = New System.Drawing.Size(72, 24)
        Me.rbAllowed.TabIndex = 1
        Me.rbAllowed.Text = "Allowed"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(64, 128)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.TabIndex = 6
        Me.cmdAdd.Text = "Add"
        '
        'lbIP
        '
        Me.lbIP.Location = New System.Drawing.Point(8, 160)
        Me.lbIP.Name = "lbIP"
        Me.lbIP.Size = New System.Drawing.Size(184, 82)
        Me.lbIP.TabIndex = 7
        '
        'txtIP4
        '
        Me.txtIP4.Location = New System.Drawing.Point(152, 96)
        Me.txtIP4.Name = "txtIP4"
        Me.txtIP4.Size = New System.Drawing.Size(40, 20)
        Me.txtIP4.TabIndex = 5
        Me.txtIP4.Text = ""
        '
        'txtIP3
        '
        Me.txtIP3.Location = New System.Drawing.Point(104, 96)
        Me.txtIP3.Name = "txtIP3"
        Me.txtIP3.Size = New System.Drawing.Size(40, 20)
        Me.txtIP3.TabIndex = 4
        Me.txtIP3.Text = ""
        '
        'txtIP2
        '
        Me.txtIP2.Location = New System.Drawing.Point(56, 96)
        Me.txtIP2.Name = "txtIP2"
        Me.txtIP2.Size = New System.Drawing.Size(40, 20)
        Me.txtIP2.TabIndex = 3
        Me.txtIP2.Text = ""
        '
        'txtIP1
        '
        Me.txtIP1.Location = New System.Drawing.Point(8, 96)
        Me.txtIP1.Name = "txtIP1"
        Me.txtIP1.Size = New System.Drawing.Size(40, 20)
        Me.txtIP1.TabIndex = 2
        Me.txtIP1.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2})
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(312, 302)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Anonymous"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbAnonUP, Me.cbAnonPW, Me.cbAllowAnon})
        Me.GroupBox2.Location = New System.Drawing.Point(48, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 96)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Anonymous"
        '
        'cbAnonUP
        '
        Me.cbAnonUP.Location = New System.Drawing.Point(24, 56)
        Me.cbAnonUP.Name = "cbAnonUP"
        Me.cbAnonUP.Size = New System.Drawing.Size(144, 24)
        Me.cbAnonUP.TabIndex = 2
        Me.cbAnonUP.Text = "Allow UPload"
        '
        'cbAnonPW
        '
        Me.cbAnonPW.Location = New System.Drawing.Point(24, 32)
        Me.cbAnonPW.Name = "cbAnonPW"
        Me.cbAnonPW.Size = New System.Drawing.Size(144, 24)
        Me.cbAnonPW.TabIndex = 1
        Me.cbAnonPW.Text = "Allow ANY Password"
        '
        'cbAllowAnon
        '
        Me.cbAllowAnon.Checked = True
        Me.cbAllowAnon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAllowAnon.Location = New System.Drawing.Point(8, 0)
        Me.cbAllowAnon.Name = "cbAllowAnon"
        Me.cbAllowAnon.Size = New System.Drawing.Size(165, 24)
        Me.cbAllowAnon.TabIndex = 0
        Me.cbAllowAnon.Text = "Allow Anonymous Access"
        '
        'tpmisc
        '
        Me.tpmisc.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox3})
        Me.tpmisc.Location = New System.Drawing.Point(4, 22)
        Me.tpmisc.Name = "tpmisc"
        Me.tpmisc.Size = New System.Drawing.Size(312, 302)
        Me.tpmisc.TabIndex = 2
        Me.tpmisc.Text = "Miscellaneous"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbSyst, Me.cbPort, Me.cbBounce, Me.cbPASV})
        Me.GroupBox3.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(296, 224)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "IP and Port security"
        '
        'cbSyst
        '
        Me.cbSyst.Location = New System.Drawing.Point(16, 144)
        Me.cbSyst.Name = "cbSyst"
        Me.cbSyst.Size = New System.Drawing.Size(272, 56)
        Me.cbSyst.TabIndex = 3
        Me.cbSyst.Text = "Send full system information on SYST command (after receiving a SYST command, Ser" & _
        "vFTp will transmit detailed information on OS type and version, beside the stand" & _
        "ard assigned numbers)"
        '
        'cbPort
        '
        Me.cbPort.Location = New System.Drawing.Point(16, 64)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(168, 24)
        Me.cbPort.TabIndex = 2
        Me.cbPort.Text = "Allow PORT command"
        '
        'cbBounce
        '
        Me.cbBounce.Location = New System.Drawing.Point(40, 88)
        Me.cbBounce.Name = "cbBounce"
        Me.cbBounce.Size = New System.Drawing.Size(248, 48)
        Me.cbBounce.TabIndex = 1
        Me.cbBounce.Text = "Activate anti Bounce attack capability (PORT command on port less than 1024 will " & _
        "be refused)"
        '
        'cbPASV
        '
        Me.cbPASV.Location = New System.Drawing.Point(16, 24)
        Me.cbPASV.Name = "cbPASV"
        Me.cbPASV.Size = New System.Drawing.Size(264, 32)
        Me.cbPASV.TabIndex = 0
        Me.cbPASV.Text = "Activate PASV IP protection (FTP server proxy capability will not function)"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(248, 344)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(168, 344)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "OK"
        '
        'frmSec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 375)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdOK, Me.cmdCancel, Me.TabControl1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSec"
        Me.Text = "Security"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.tpmisc.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cbAllowAnon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        cbAnonPW.Enabled = cbAllowAnon.Checked
        cbAnonUP.Enabled = cbAllowAnon.Checked

    End Sub

    Private Sub cbAllowAnon_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAllowAnon.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim i As Integer
        Dim k As Integer
        Dim IP(3) As String
        Dim IPString As String

        IP(0) = txtIP1.Text
        IP(1) = txtIP2.Text
        IP(2) = txtIP3.Text
        IP(3) = txtIP4.Text
        txtIP1.Text = ""
        txtIP2.Text = ""
        txtIP3.Text = ""
        txtIP4.Text = ""

        For i = 0 To 3
            If IP(i) = "" Or IP(i) = "*" Then
                For k = i To 3
                    IP(k) = "*"
                Next k
            End If

            IPString &= IP(i) & "."
        Next i

        IPString = IPString.Substring(0, IPString.Length - 1)

        lbIP.Items.Add(IPString)

    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

        lbIP.Items.Remove(lbIP.SelectedIndex)

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim IP(lbIP.Items.Count - 1) As String
        Dim i As Integer

        For i = 0 To lbIP.Items.Count - 1
            IP(i) = lbIP.Items.Item(i)
        Next

        'Try
        LoclRep.XMLACL(IP)
        'Catch exc As Exception
        'MessageBox.Show(exc.ToString)
        'Finally

        LoclRep.XMLModified("Security")

        Me.Close()
        'End Try


    End Sub

    Private Sub frmSec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With LoclRep.REPConf
                Dim IP As Xml.XmlElement

                If CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/AllIPAllowed").InnerText) Then
                    rbAllowed.Checked = True
                Else
                    rbDenied.Checked = True
                End If

                For Each IP In .SelectSingleNode("//Configurations/Configuration[@ID='ACL']")
                    lbIP.Items.Add(IP.InnerText)
                Next
            End With
        Catch exc As Exception
            MessageBox.Show("1" & exc.ToString)
        End Try
        Try
            With LoclRep.REPConf
                cbAllowAnon.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Anon']/AllowAnon").InnerText)
                cbAnonPW.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Anon']/AnyPW").InnerText)
                cbAnonUP.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Anon']/UPLoad").InnerText)
            End With
        Catch exc As Exception
            MessageBox.Show("2" & exc.ToString)
        End Try
        Try
            With LoclRep.REPConf
                cbBounce.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/AntiBounce").InnerText)
                cbPort.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/AllowPort").InnerText)
                cbPASV.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/PasvIPPro").InnerText)
                cbSyst.Checked = CBool(.SelectSingleNode("//Configurations/Configuration[@ID='Sec']/FullSYST").InnerText)
            End With
        Catch exc As Exception
            MessageBox.Show("3" & exc.ToString)
        End Try

    End Sub

    Private Sub cbPort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPort.CheckedChanged

        cbBounce.Enabled = cbPort.Checked

    End Sub
End Class
