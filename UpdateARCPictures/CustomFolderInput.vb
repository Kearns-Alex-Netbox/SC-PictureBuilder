Public Class CustomFolderInput

	Const X_OFFSET_CHAR  As Integer = -10
	Const X_OFFSET_EMPTY As Integer = 5
	Const Y_OFFSET		 As Integer = 5
	Const DISPLAY		 As Integer = 3000

	Public Sub New(Optional ByVal Name As String = "")

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		' optional parameter to set the text box to reflect the existing name
		SystemName_TextBox.Text = Name

		' allow our users to use the enter key to submit
		KeyPreview = True
	End Sub

	Private Sub Cancel_Button_Click() Handles Cancel_Button.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub Ok_Button_Click() Handles Ok_Button.Click
		' check to see that we have a name in the text field.
		If SystemName_TextBox.Text.Length = 0 Then
			Dim tt As New ToolTip()
				tt.Show("Please Enter a name for your system.", SystemName_TextBox, X_OFFSET_EMPTY, SystemName_TextBox.height + Y_OFFSET, DISPLAY)
				Return
			Return
		End If

		DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub SystemName_TextBox_KeyDown(sender As Object, e As KeyPressEventArgs) Handles SystemName_TextBox.KeyPress
		'https://stackoverflow.com/questions/1092808/warn-about-capslock/8060520#8060520
		
		' grab our charcter and check to see if it is an invalid one
		Select Case e.KeyChar.ToString
		    Case "\", "/", ":", "*", "?", """", "<", ">", "|"
				Dim tt As New ToolTip()
				tt.Show(INVALID_CHARACTERS, sender, X_OFFSET_CHAR, sender.height + Y_OFFSET, DISPLAY)

				' set to 'true' so the character does not go into the textbox
				e.Handled = True
		End Select
	End Sub

	Private Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
		' call the OK click function when we press the Enter key.
		If e.KeyCode.Equals(Keys.Enter) Then
			Ok_Button_Click()
		End If
	End Sub

End Class