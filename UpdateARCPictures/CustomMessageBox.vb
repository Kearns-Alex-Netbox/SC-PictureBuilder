Public Class CustomMessageBox

	Public Sub New(ByRef message As String, ByRef OneText As String, Optional ByRef TwoText As String = Nothing)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Message_RichTextBox.Text = message

		One_Button.Text = OneText

		' check to see if we have a second text or not
		If TwoText IsNot Nothing Then
			Two_Button.Text = TwoText
		Else
			Two_Button.Visible = False
		End If
	End Sub

	Private Sub One_Button_Click() Handles One_Button.Click
		' send back that we selected option 1
		DialogResult = 1
		Close()
	End Sub

	Private Sub Two_Button_Click() Handles Two_Button.Click
		' send back that we selected option 1
		DialogResult = 2
		Close()
	End Sub

End Class