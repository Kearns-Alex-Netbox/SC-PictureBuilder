<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CropImage
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CropImage))
		Me.Source_PictureBox = New System.Windows.Forms.PictureBox()
		Me.Cropped_PictureBox = New System.Windows.Forms.PictureBox()
		Me.Save_Button = New System.Windows.Forms.Button()
		Me.Browse_Button = New System.Windows.Forms.Button()
		Me.StepTitle_Label = New System.Windows.Forms.Label()
		Me.Description_Label = New System.Windows.Forms.Label()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.SaveAndNext_Button = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		CType(Me.Source_PictureBox,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.Cropped_PictureBox,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Source_PictureBox
		'
		Me.Source_PictureBox.BackColor = System.Drawing.Color.Black
		Me.Source_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.Source_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Source_PictureBox.Location = New System.Drawing.Point(13, 71)
		Me.Source_PictureBox.Margin = New System.Windows.Forms.Padding(4)
		Me.Source_PictureBox.Name = "Source_PictureBox"
		Me.Source_PictureBox.Size = New System.Drawing.Size(686, 600)
		Me.Source_PictureBox.TabIndex = 16
		Me.Source_PictureBox.TabStop = false
		'
		'Cropped_PictureBox
		'
		Me.Cropped_PictureBox.BackColor = System.Drawing.Color.Black
		Me.Cropped_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Cropped_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Cropped_PictureBox.Location = New System.Drawing.Point(707, 196)
		Me.Cropped_PictureBox.Margin = New System.Windows.Forms.Padding(4)
		Me.Cropped_PictureBox.Name = "Cropped_PictureBox"
		Me.Cropped_PictureBox.Size = New System.Drawing.Size(400, 350)
		Me.Cropped_PictureBox.TabIndex = 19
		Me.Cropped_PictureBox.TabStop = false
		'
		'Save_Button
		'
		Me.Save_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Save_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Save_Button.Location = New System.Drawing.Point(915, 679)
		Me.Save_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Save_Button.Name = "Save_Button"
		Me.Save_Button.Size = New System.Drawing.Size(92, 30)
		Me.Save_Button.TabIndex = 5
		Me.Save_Button.Text = "Save"
		Me.Save_Button.UseVisualStyleBackColor = true
		'
		'Browse_Button
		'
		Me.Browse_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Browse_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Browse_Button.Location = New System.Drawing.Point(13, 679)
		Me.Browse_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Browse_Button.Name = "Browse_Button"
		Me.Browse_Button.Size = New System.Drawing.Size(92, 30)
		Me.Browse_Button.TabIndex = 3
		Me.Browse_Button.Text = "Browse"
		Me.Browse_Button.UseVisualStyleBackColor = true
		'
		'StepTitle_Label
		'
		Me.StepTitle_Label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.StepTitle_Label.Location = New System.Drawing.Point(12, 9)
		Me.StepTitle_Label.Name = "StepTitle_Label"
		Me.StepTitle_Label.Size = New System.Drawing.Size(687, 33)
		Me.StepTitle_Label.TabIndex = 0
		Me.StepTitle_Label.Text = "Image Title"
		'
		'Description_Label
		'
		Me.Description_Label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Description_Label.Location = New System.Drawing.Point(707, 9)
		Me.Description_Label.Name = "Description_Label"
		Me.Description_Label.Size = New System.Drawing.Size(398, 58)
		Me.Description_Label.TabIndex = 1
		Me.Description_Label.Text = "Description for the current step"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Cancel_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Cancel_Button.Location = New System.Drawing.Point(1015, 679)
		Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(92, 30)
		Me.Cancel_Button.TabIndex = 6
		Me.Cancel_Button.Text = "Cancel"
		Me.Cancel_Button.UseVisualStyleBackColor = true
		'
		'SaveAndNext_Button
		'
		Me.SaveAndNext_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.SaveAndNext_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.SaveAndNext_Button.Location = New System.Drawing.Point(756, 679)
		Me.SaveAndNext_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.SaveAndNext_Button.Name = "SaveAndNext_Button"
		Me.SaveAndNext_Button.Size = New System.Drawing.Size(151, 30)
		Me.SaveAndNext_Button.TabIndex = 4
		Me.SaveAndNext_Button.Text = "Save and Next"
		Me.SaveAndNext_Button.UseVisualStyleBackColor = true
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(707, 159)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(121, 32)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Preview"
		'
		'CropImage
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(9!, 20!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1117, 723)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.SaveAndNext_Button)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.Description_Label)
		Me.Controls.Add(Me.StepTitle_Label)
		Me.Controls.Add(Me.Browse_Button)
		Me.Controls.Add(Me.Save_Button)
		Me.Controls.Add(Me.Cropped_PictureBox)
		Me.Controls.Add(Me.Source_PictureBox)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CropImage"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Upload/Crop Image"
		CType(Me.Source_PictureBox,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.Cropped_PictureBox,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents Source_PictureBox As PictureBox
	Friend WithEvents Cropped_PictureBox As PictureBox
	Friend WithEvents Save_Button As Button
	Friend WithEvents Browse_Button As Button
	Friend WithEvents StepTitle_Label As Label
	Friend WithEvents Description_Label As Label
	Friend WithEvents Cancel_Button As Button
	Friend WithEvents SaveAndNext_Button As Button
	Friend WithEvents Label1 As Label
End Class
