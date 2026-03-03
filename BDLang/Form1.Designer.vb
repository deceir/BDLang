<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BDOLang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.Title = New System.Windows.Forms.Label()
        Me.rdBtnEng = New System.Windows.Forms.RadioButton()
        Me.btnFetch = New System.Windows.Forms.Button()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblBDOFILELOC = New System.Windows.Forms.Label()
        Me.lblFileLocHelp = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(70, 387)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(100, 23)
        Me.progressBar.TabIndex = 0
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft YaHei", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(13, 13)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(157, 46)
        Me.Title.TabIndex = 1
        Me.Title.Text = "BDLang"
        '
        'rdBtnEng
        '
        Me.rdBtnEng.AutoSize = True
        Me.rdBtnEng.Location = New System.Drawing.Point(70, 105)
        Me.rdBtnEng.Name = "rdBtnEng"
        Me.rdBtnEng.Size = New System.Drawing.Size(59, 17)
        Me.rdBtnEng.TabIndex = 2
        Me.rdBtnEng.TabStop = True
        Me.rdBtnEng.Text = "English"
        Me.rdBtnEng.UseVisualStyleBackColor = True
        '
        'btnFetch
        '
        Me.btnFetch.Enabled = False
        Me.btnFetch.Location = New System.Drawing.Point(70, 230)
        Me.btnFetch.Name = "btnFetch"
        Me.btnFetch.Size = New System.Drawing.Size(75, 23)
        Me.btnFetch.TabIndex = 3
        Me.btnFetch.Text = "Fetch"
        Me.btnFetch.UseVisualStyleBackColor = True
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(151, 235)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(72, 13)
        Me.lblCode.TabIndex = 4
        Me.lblCode.Text = "Current Code:"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(67, 413)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(91, 13)
        Me.lblInfo.TabIndex = 5
        Me.lblInfo.Text = "Select Language."
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(212, 141)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(239, 20)
        Me.TextBox1.TabIndex = 6
        '
        'lblBDOFILELOC
        '
        Me.lblBDOFILELOC.AutoSize = True
        Me.lblBDOFILELOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBDOFILELOC.Location = New System.Drawing.Point(70, 146)
        Me.lblBDOFILELOC.Name = "lblBDOFILELOC"
        Me.lblBDOFILELOC.Size = New System.Drawing.Size(136, 15)
        Me.lblBDOFILELOC.TabIndex = 7
        Me.lblBDOFILELOC.Text = "Black Desert File Location:"
        '
        'lblFileLocHelp
        '
        Me.lblFileLocHelp.AutoSize = True
        Me.lblFileLocHelp.Location = New System.Drawing.Point(177, 125)
        Me.lblFileLocHelp.Name = "lblFileLocHelp"
        Me.lblFileLocHelp.Size = New System.Drawing.Size(315, 13)
        Me.lblFileLocHelp.TabIndex = 8
        Me.lblFileLocHelp.Text = "Choose Black Desert folder, then choose your designated loc file."
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Cursor = System.Windows.Forms.Cursors.Cross
        Me.CheckBox1.Location = New System.Drawing.Point(399, 167)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Advanced"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BDOLang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 452)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.lblFileLocHelp)
        Me.Controls.Add(Me.lblBDOFILELOC)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.btnFetch)
        Me.Controls.Add(Me.rdBtnEng)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.progressBar)
        Me.Name = "BDOLang"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents Title As Label
    Friend WithEvents rdBtnEng As RadioButton
    Friend WithEvents btnFetch As Button
    Friend WithEvents lblCode As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblBDOFILELOC As Label
    Friend WithEvents lblFileLocHelp As Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
