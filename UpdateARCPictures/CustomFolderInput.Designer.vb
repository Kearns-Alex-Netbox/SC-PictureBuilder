<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomFolderInput
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomFolderInput))
		Me.Ok_Button = New System.Windows.Forms.Button()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SystemName_TextBox = New System.Windows.Forms.TextBox()
		Me.SuspendLayout
		'
		'Ok_Button
		'
		Me.Ok_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Ok_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Ok_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Ok_Button.Location = New System.Drawing.Point(120, 65)
		Me.Ok_Button.Name = "Ok_Button"
		Me.Ok_Button.Size = New System.Drawing.Size(92, 30)
		Me.Ok_Button.TabIndex = 2
		Me.Ok_Button.Text = "OK"
		Me.Ok_Button.UseVisualStyleBackColor = true
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Cancel_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Cancel_Button.Location = New System.Drawing.Point(218, 65)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(92, 30)
		Me.Cancel_Button.TabIndex = 3
		Me.Cancel_Button.Text = "Cancel"
		Me.Cancel_Button.UseVisualStyleBackColor = true
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(301, 18)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Please Enter a name for your System"
		'
		'SystemName_TextBox
		'
		Me.SystemName_TextBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SystemName_TextBox.Location = New System.Drawing.Point(12, 30)
		Me.SystemName_TextBox.Name = "SystemName_TextBox"
		Me.SystemName_TextBox.Size = New System.Drawing.Size(298, 23)
		Me.SystemName_TextBox.TabIndex = 1
		'
		'CustomFolderInput
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(318, 103)
		Me.ControlBox = false
		Me.Controls.Add(Me.SystemName_TextBox)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Ok_Button)
		Me.Controls.Add(Me.Cancel_Button)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CustomFolderInput"
		Me.ShowIcon = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "System Name"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents Ok_Button As Button
	Friend WithEvents Cancel_Button As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents SystemName_TextBox As TextBox
End Class
