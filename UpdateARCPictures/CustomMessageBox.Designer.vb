<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMessageBox
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomMessageBox))
		Me.Message_RichTextBox = New System.Windows.Forms.RichTextBox()
		Me.One_Button = New System.Windows.Forms.Button()
		Me.Two_Button = New System.Windows.Forms.Button()
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
		Me.Message_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
		Me.Message_RichTextBox.Size = New System.Drawing.Size(263, 57)
		Me.Message_RichTextBox.TabIndex = 0
		Me.Message_RichTextBox.TabStop = false
		Me.Message_RichTextBox.Text = ""
		'
		'One_Button
		'
		Me.One_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.One_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.One_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.One_Button.Location = New System.Drawing.Point(134, 63)
		Me.One_Button.Name = "One_Button"
		Me.One_Button.Size = New System.Drawing.Size(95, 30)
		Me.One_Button.TabIndex = 2
		Me.One_Button.Text = "One"
		Me.One_Button.UseVisualStyleBackColor = true
		'
		'Two_Button
		'
		Me.Two_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Two_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Two_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Two_Button.Location = New System.Drawing.Point(33, 63)
		Me.Two_Button.Name = "Two_Button"
		Me.Two_Button.Size = New System.Drawing.Size(95, 30)
		Me.Two_Button.TabIndex = 1
		Me.Two_Button.Text = "Two"
		Me.Two_Button.UseVisualStyleBackColor = true
		'
		'CustomMessageBox
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(262, 105)
		Me.ControlBox = false
		Me.Controls.Add(Me.Two_Button)
		Me.Controls.Add(Me.One_Button)
		Me.Controls.Add(Me.Message_RichTextBox)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CustomMessageBox"
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Message"
		Me.ResumeLayout(false)

End Sub

	Friend WithEvents Message_RichTextBox As RichTextBox
	Friend WithEvents One_Button As Button
	Friend WithEvents Two_Button As Button
End Class
