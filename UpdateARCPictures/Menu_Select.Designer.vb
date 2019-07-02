<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_Select
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Select))
		Me.Exit_Button = New System.Windows.Forms.Button()
		Me.Delete_Button = New System.Windows.Forms.Button()
		Me.Rename_Button = New System.Windows.Forms.Button()
		Me.New_Button = New System.Windows.Forms.Button()
		Me.Select_Button = New System.Windows.Forms.Button()
		Me.Version_Label = New System.Windows.Forms.Label()
		Me.Systems_ListBox = New System.Windows.Forms.ListBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'Exit_Button
		'
		Me.Exit_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Exit_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Exit_Button.Location = New System.Drawing.Point(256, 204)
		Me.Exit_Button.Name = "Exit_Button"
		Me.Exit_Button.Size = New System.Drawing.Size(115, 30)
		Me.Exit_Button.TabIndex = 4
		Me.Exit_Button.Text = "Exit"
		Me.Exit_Button.UseVisualStyleBackColor = true
		'
		'Delete_Button
		'
		Me.Delete_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Delete_Button.Enabled = false
		Me.Delete_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Delete_Button.Location = New System.Drawing.Point(256, 112)
		Me.Delete_Button.Name = "Delete_Button"
		Me.Delete_Button.Size = New System.Drawing.Size(115, 30)
		Me.Delete_Button.TabIndex = 2
		Me.Delete_Button.Text = "Delete..."
		Me.Delete_Button.UseVisualStyleBackColor = true
		'
		'Rename_Button
		'
		Me.Rename_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Rename_Button.Enabled = false
		Me.Rename_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Rename_Button.Location = New System.Drawing.Point(256, 76)
		Me.Rename_Button.Name = "Rename_Button"
		Me.Rename_Button.Size = New System.Drawing.Size(115, 30)
		Me.Rename_Button.TabIndex = 1
		Me.Rename_Button.Text = "Rename..."
		Me.Rename_Button.UseVisualStyleBackColor = true
		'
		'New_Button
		'
		Me.New_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.New_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.New_Button.Location = New System.Drawing.Point(256, 40)
		Me.New_Button.Name = "New_Button"
		Me.New_Button.Size = New System.Drawing.Size(115, 30)
		Me.New_Button.TabIndex = 0
		Me.New_Button.Text = "New..."
		Me.New_Button.UseVisualStyleBackColor = true
		'
		'Select_Button
		'
		Me.Select_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Select_Button.Enabled = false
		Me.Select_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Select_Button.Location = New System.Drawing.Point(256, 148)
		Me.Select_Button.Name = "Select_Button"
		Me.Select_Button.Size = New System.Drawing.Size(115, 30)
		Me.Select_Button.TabIndex = 3
		Me.Select_Button.Text = "Select"
		Me.Select_Button.UseVisualStyleBackColor = true
		'
		'Version_Label
		'
		Me.Version_Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.Version_Label.AutoSize = true
		Me.Version_Label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Version_Label.Location = New System.Drawing.Point(15, 215)
		Me.Version_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Version_Label.Name = "Version_Label"
		Me.Version_Label.Size = New System.Drawing.Size(15, 14)
		Me.Version_Label.TabIndex = 6
		Me.Version_Label.Text = "V"
		'
		'Systems_ListBox
		'
		Me.Systems_ListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Systems_ListBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Systems_ListBox.FormattingEnabled = true
		Me.Systems_ListBox.ItemHeight = 18
		Me.Systems_ListBox.Location = New System.Drawing.Point(12, 40)
		Me.Systems_ListBox.Name = "Systems_ListBox"
		Me.Systems_ListBox.Size = New System.Drawing.Size(238, 166)
		Me.Systems_ListBox.TabIndex = 5
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(73, 9)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(236, 28)
		Me.Label1.TabIndex = 7
		Me.Label1.Text = "Select Your System"
		'
		'Menu_Select
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(383, 245)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Systems_ListBox)
		Me.Controls.Add(Me.Version_Label)
		Me.Controls.Add(Me.Select_Button)
		Me.Controls.Add(Me.New_Button)
		Me.Controls.Add(Me.Rename_Button)
		Me.Controls.Add(Me.Delete_Button)
		Me.Controls.Add(Me.Exit_Button)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.MinimumSize = New System.Drawing.Size(399, 283)
		Me.Name = "Menu_Select"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Select System"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
	Friend WithEvents Exit_Button As Button
	Friend WithEvents Delete_Button As Button
	Friend WithEvents Rename_Button As Button
	Friend WithEvents New_Button As Button
	Friend WithEvents Select_Button As Button
	Friend WithEvents Version_Label As Label
	Friend WithEvents Systems_ListBox As ListBox
	Friend WithEvents Label1 As Label
End Class
