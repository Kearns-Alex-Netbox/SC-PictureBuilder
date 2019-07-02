<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpMessageBox
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpMessageBox))
		Me.Message_RichTextBox = New System.Windows.Forms.RichTextBox()
		Me.Remind_CheckBox = New System.Windows.Forms.CheckBox()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'Message_RichTextBox
		'
		Me.Message_RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Message_RichTextBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Message_RichTextBox.Location = New System.Drawing.Point(0, 0)
		Me.Message_RichTextBox.Name = "Message_RichTextBox"
		Me.Message_RichTextBox.ReadOnly = true
		Me.Message_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
		Me.Message_RichTextBox.Size = New System.Drawing.Size(561, 211)
		Me.Message_RichTextBox.TabIndex = 0
		Me.Message_RichTextBox.TabStop = false
		Me.Message_RichTextBox.Text = ""
		'
		'Remind_CheckBox
		'
		Me.Remind_CheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Remind_CheckBox.AutoSize = true
		Me.Remind_CheckBox.Checked = true
		Me.Remind_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
		Me.Remind_CheckBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Remind_CheckBox.Location = New System.Drawing.Point(12, 224)
		Me.Remind_CheckBox.Name = "Remind_CheckBox"
		Me.Remind_CheckBox.Size = New System.Drawing.Size(128, 32)
		Me.Remind_CheckBox.TabIndex = 1
		Me.Remind_CheckBox.Text = "Remind Me Again"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"(This Session)"
		Me.Remind_CheckBox.UseVisualStyleBackColor = true
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.OK_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.OK_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.OK_Button.Location = New System.Drawing.Point(457, 218)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(92, 33)
		Me.OK_Button.TabIndex = 2
		Me.OK_Button.Text = "OK"
		Me.OK_Button.UseVisualStyleBackColor = true
		'
		'HelpMessageBox
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(561, 263)
		Me.ControlBox = false
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.Remind_CheckBox)
		Me.Controls.Add(Me.Message_RichTextBox)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "HelpMessageBox"
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Help"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents Message_RichTextBox As RichTextBox
	Friend WithEvents Remind_CheckBox As CheckBox
	Friend WithEvents OK_Button As Button
End Class
