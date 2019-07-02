<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomTreeView
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomTreeView))
		Me.Explorer_TreeView = New System.Windows.Forms.TreeView()
		Me.Path_TextBox = New System.Windows.Forms.TextBox()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Icon_ImageList = New System.Windows.Forms.ImageList(Me.components)
		Me.SuspendLayout
		'
		'Explorer_TreeView
		'
		Me.Explorer_TreeView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Explorer_TreeView.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Explorer_TreeView.Location = New System.Drawing.Point(12, 41)
		Me.Explorer_TreeView.Name = "Explorer_TreeView"
		Me.Explorer_TreeView.Size = New System.Drawing.Size(193, 171)
		Me.Explorer_TreeView.TabIndex = 1
		'
		'Path_TextBox
		'
		Me.Path_TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Path_TextBox.Enabled = false
		Me.Path_TextBox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Path_TextBox.Location = New System.Drawing.Point(12, 12)
		Me.Path_TextBox.Name = "Path_TextBox"
		Me.Path_TextBox.ReadOnly = true
		Me.Path_TextBox.Size = New System.Drawing.Size(193, 23)
		Me.Path_TextBox.TabIndex = 0
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Cancel_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Cancel_Button.Location = New System.Drawing.Point(112, 219)
		Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(92, 30)
		Me.Cancel_Button.TabIndex = 3
		Me.Cancel_Button.Text = "Cancel"
		Me.Cancel_Button.UseVisualStyleBackColor = true
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.OK_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.OK_Button.Enabled = false
		Me.OK_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.OK_Button.Location = New System.Drawing.Point(12, 219)
		Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(92, 30)
		Me.OK_Button.TabIndex = 2
		Me.OK_Button.Text = "OK"
		Me.OK_Button.UseVisualStyleBackColor = true
		'
		'Icon_ImageList
		'
		Me.Icon_ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
		Me.Icon_ImageList.ImageSize = New System.Drawing.Size(20, 20)
		Me.Icon_ImageList.TransparentColor = System.Drawing.Color.Transparent
		'
		'CustomTreeView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(217, 262)
		Me.ControlBox = false
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.Path_TextBox)
		Me.Controls.Add(Me.Explorer_TreeView)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "CustomTreeView"
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Select USB Drive"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents Explorer_TreeView As TreeView
	Friend WithEvents Path_TextBox As TextBox
	Friend WithEvents Cancel_Button As Button
	Friend WithEvents OK_Button As Button
	Friend WithEvents Icon_ImageList As ImageList
End Class
