<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCredits = New System.Windows.Forms.Button()
        Me.BtnSignExecutables = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PortTxtBOX = New System.Windows.Forms.TextBox()
        Me.IPTextBOX = New System.Windows.Forms.TextBox()
        Me.BtnRun = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Verlabel = New System.Windows.Forms.Label()
        Me.Statlabel = New System.Windows.Forms.Label()
        Me.CMDView = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnCredits)
        Me.Panel1.Controls.Add(Me.BtnSignExecutables)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PortTxtBOX)
        Me.Panel1.Controls.Add(Me.IPTextBOX)
        Me.Panel1.Controls.Add(Me.BtnRun)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 104)
        Me.Panel1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.Executable_Decryptor_UI.My.Resources.Resources.settings_FILL0_wght400_GRAD0_opsz24
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(539, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 35)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Extras"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "(PS5 IP)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(180, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "(Klog Port)"
        '
        'BtnCredits
        '
        Me.BtnCredits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCredits.BackColor = System.Drawing.Color.Tan
        Me.BtnCredits.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCredits.Location = New System.Drawing.Point(138, 72)
        Me.BtnCredits.Name = "BtnCredits"
        Me.BtnCredits.Size = New System.Drawing.Size(115, 26)
        Me.BtnCredits.TabIndex = 6
        Me.BtnCredits.Text = "Credits"
        Me.BtnCredits.UseVisualStyleBackColor = False
        '
        'BtnSignExecutables
        '
        Me.BtnSignExecutables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSignExecutables.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSignExecutables.Image = Global.Executable_Decryptor_UI.My.Resources.Resources.counter_2_FILL0_wght400_GRAD0_opsz24
        Me.BtnSignExecutables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSignExecutables.Location = New System.Drawing.Point(539, 13)
        Me.BtnSignExecutables.Name = "BtnSignExecutables"
        Me.BtnSignExecutables.Size = New System.Drawing.Size(147, 35)
        Me.BtnSignExecutables.TabIndex = 5
        Me.BtnSignExecutables.Text = "         Sign Elfs"
        Me.BtnSignExecutables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSignExecutables.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Orange
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(16, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 26)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Instructions"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(153, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = ":"
        '
        'PortTxtBOX
        '
        Me.PortTxtBOX.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PortTxtBOX.Location = New System.Drawing.Point(174, 12)
        Me.PortTxtBOX.Name = "PortTxtBOX"
        Me.PortTxtBOX.Size = New System.Drawing.Size(87, 27)
        Me.PortTxtBOX.TabIndex = 2
        Me.PortTxtBOX.Text = "9023"
        Me.PortTxtBOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IPTextBOX
        '
        Me.IPTextBOX.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IPTextBOX.Location = New System.Drawing.Point(16, 12)
        Me.IPTextBOX.Name = "IPTextBOX"
        Me.IPTextBOX.Size = New System.Drawing.Size(135, 27)
        Me.IPTextBOX.TabIndex = 1
        Me.IPTextBOX.Text = "111"
        Me.IPTextBOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnRun
        '
        Me.BtnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRun.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRun.Image = Global.Executable_Decryptor_UI.My.Resources.Resources.counter_1_FILL0_wght400_GRAD0_opsz24
        Me.BtnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRun.Location = New System.Drawing.Point(386, 12)
        Me.BtnRun.Name = "BtnRun"
        Me.BtnRun.Size = New System.Drawing.Size(147, 35)
        Me.BtnRun.TabIndex = 0
        Me.BtnRun.Text = "        Inject && Run"
        Me.BtnRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRun.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Verlabel)
        Me.Panel2.Controls.Add(Me.Statlabel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(710, 26)
        Me.Panel2.TabIndex = 2
        '
        'Verlabel
        '
        Me.Verlabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Verlabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Verlabel.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Verlabel.Location = New System.Drawing.Point(428, 3)
        Me.Verlabel.Name = "Verlabel"
        Me.Verlabel.Size = New System.Drawing.Size(279, 20)
        Me.Verlabel.TabIndex = 1
        Me.Verlabel.Text = "ver"
        Me.Verlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Statlabel
        '
        Me.Statlabel.AutoSize = True
        Me.Statlabel.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Statlabel.Location = New System.Drawing.Point(12, 3)
        Me.Statlabel.Name = "Statlabel"
        Me.Statlabel.Size = New System.Drawing.Size(101, 20)
        Me.Statlabel.TabIndex = 0
        Me.Statlabel.Text = "@rajeshca911"
        '
        'CMDView
        '
        Me.CMDView.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CMDView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CMDView.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDView.ForeColor = System.Drawing.Color.White
        Me.CMDView.Location = New System.Drawing.Point(0, 104)
        Me.CMDView.Name = "CMDView"
        Me.CMDView.ReadOnly = True
        Me.CMDView.Size = New System.Drawing.Size(710, 445)
        Me.CMDView.TabIndex = 0
        Me.CMDView.Text = "Tool Front End Created By:" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "@rajeshca911" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Credits :" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 575)
        Me.Controls.Add(Me.CMDView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(726, 613)
        Me.Name = "Form1"
        Me.Text = "DecryptorUI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnRun As Button
    Friend WithEvents CMDView As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PortTxtBOX As TextBox
    Friend WithEvents IPTextBOX As TextBox
    Friend WithEvents Statlabel As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnSignExecutables As Button
    Friend WithEvents BtnCredits As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Verlabel As Label
End Class
