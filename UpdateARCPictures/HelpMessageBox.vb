Public Class HelpMessageBox

	Public Sub New(ByRef message As String, Optional ByRef isReminder As Boolean = False)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Remind_CheckBox.Visible = isReminder

		Message_RichTextBox.Text = message
	End Sub

	Private Sub OK_Button_Click() Handles OK_Button.Click
		DialogResult = DialogResult.OK
		Close()
	End Sub

End Class