Imports System.Net
Imports System.IO
Imports System.Xml

Public Class frmNet
    Inherits System.Windows.Forms.Form
    Dim PortXMl As XmlDocument

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
    Friend WithEvents clbIP As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents sa As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNet))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.clbIP = New System.Windows.Forms.CheckedListBox()
        Me.sa = New System.Windows.Forms.GroupBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.sa.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.clbIP})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Machine's IP Addressess"
        '
        'clbIP
        '
        Me.clbIP.CheckOnClick = True
        Me.clbIP.Location = New System.Drawing.Point(8, 24)
        Me.clbIP.Name = "clbIP"
        Me.clbIP.Size = New System.Drawing.Size(184, 116)
        Me.clbIP.Sorted = True
        Me.clbIP.TabIndex = 0
        '
        'sa
        '
        Me.sa.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDesc, Me.lblName, Me.Label3, Me.Label2, Me.Label1, Me.txtPort})
        Me.sa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sa.Location = New System.Drawing.Point(224, 8)
        Me.sa.Name = "sa"
        Me.sa.Size = New System.Drawing.Size(200, 160)
        Me.sa.TabIndex = 1
        Me.sa.TabStop = False
        Me.sa.Text = "Server Port"
        '
        'lblDesc
        '
        Me.lblDesc.Location = New System.Drawing.Point(8, 128)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(184, 23)
        Me.lblDesc.TabIndex = 5
        Me.lblDesc.Text = "Label5"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(8, 80)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(184, 23)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Port Name"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port Description"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Port"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(120, 24)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(64, 21)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "TextBox1"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(264, 176)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Close"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(344, 176)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'frmNet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(434, 207)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.btnOK, Me.sa, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNet"
        Me.Text = "Network Configuration"
        Me.GroupBox1.ResumeLayout(False)
        Me.sa.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmNet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim List() As IPAddress
        Dim CurrIP As IPAddress

        List = Dns.Resolve(Dns.GetHostName).AddressList

        ReDim Preserve List(List.GetUpperBound(0) + 1)
        List(List.GetUpperBound(0)) = IPAddress.Loopback

        For Each CurrIP In List
            clbIP.Items.Add(CurrIP.ToString, CBool(CurrIP.ToString = LoclRep.MachineIP.ToString))
        Next

        txtPort.Text = LoclRep.FTPPort
        lblName.Text = "<No Data>"
        lblDesc.Text = "<No Data>"

        PortXMl = New XmlDocument()
        PortXMl.Load("ports.xml")

        Call PortDetails()

    End Sub

    Private Sub PortDetails()

        lblName.Text = "<No Data>"
        lblDesc.Text = "<No Data>"

        Try
            lblName.Text = PortXMl.SelectSingleNode("//Ports/Port[@ID='" & txtPort.Text.Trim(" ") & "']/Name").InnerText()
            lblDesc.Text = PortXMl.SelectSingleNode("//Ports/Port[@ID='" & txtPort.Text.Trim(" ") & "']/Desc").InnerText()
        Catch e As Exception
            lblName.Text = "<ERROR Reading Ports!>"
            lblDesc.Text = "<ERROR Reading Ports!>"
        End Try

    End Sub

    Private Sub clbIP_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbIP.ItemCheck

        If Not (e.CurrentValue) And clbIP.CheckedItems.Count > 0 Then
            Dim i As Integer
            For i = 0 To clbIP.Items.Count - 1
                If (clbIP.GetItemChecked(i)) And (i <> e.Index) Then
                    clbIP.SetItemChecked(i, False)
                End If
            Next
        End If

    End Sub

    Private Sub txtPort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPort.TextChanged
        Call PortDetails()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        LoclRep.XMLIPPort(clbIP.CheckedItems.Item(0), txtPort.Text)
        Me.Close()
    End Sub

    Private Sub clbIP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbIP.SelectedIndexChanged

    End Sub
End Class
