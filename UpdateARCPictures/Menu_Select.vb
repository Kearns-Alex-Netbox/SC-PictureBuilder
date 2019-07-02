Imports System.IO

Public Class Menu_Select

	Private Sub Init() Handles MyBase.Shown
		' show the current software version number
		Version_Label.Text &= Application.ProductVersion

		' check to see if we are displaying our welcome information
		If ShowStartup Then
			Dim doHelpMessageBox As New HelpMessageBox(PROCESS_INSTRUCTIONS)

			doHelpMessageBox.ShowDialog

			' kill the flag so it does not continually pop up each time
			ShowStartup = False
		End If

		UpdateList()
		If Systems_ListBox.Items.Count = 0 Then
			New_Button_Click()
		End If	
	End Sub

	Private Sub UpdateList()
		' create our table of system names
		Systems_ListBox.Items.Clear

		' grab all of the folders and add them to the table
		For each folder In Directory.GetDirectories(APP_DATA_PATH)
			Systems_ListBox.Items.Add(Path.GetFileName(folder))
		Next

		' check to see if we need to disable any of our edit buttons
		If Systems_ListBox.Items.Count = 0 Then
			Rename_Button.Enabled = False
			Delete_Button.Enabled = False
			Select_Button.Enabled = False
		End If
	End Sub

	Private Sub Exit_Button_Click() Handles Exit_Button.Click
		Close()
	End Sub

	Private Sub New_Button_Click() Handles New_Button.Click
		Dim doCustomFolderInput As New CustomFolderInput()
		doCustomFolderInput.ShowDialog()

		' check to see if we canceled our action
		If doCustomFolderInput.DialogResult = DialogResult.Cancel Then
			Return
		End If

		Dim name As String = doCustomFolderInput.SystemName_TextBox.Text

		' check to see if the file exists already or not
		If Directory.Exists(APP_DATA_PATH & "\" & name) Then
			Dim doCustomMessageBox As New CustomMessageBox("The system " & name & " alreay exists.", "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End If

		' surround with try/catch for any issues we have not handled
		Try
			' create the new folder and update our list
			Directory.CreateDirectory(APP_DATA_PATH & "\" & name)
			UpdateList()
		Catch ex As Exception
			Dim doCustomMessageBox As New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End Try
	End Sub

	Private Sub Rename_Button_Click() Handles Rename_Button.Click
		' get the name of the selected system
		Dim name As String = Systems_ListBox.SelectedItem

		' check to see that the system folder exists
		If Directory.Exists(APP_DATA_PATH & "\" & name) = False Then
			Dim doCustomMessageBox As New CustomMessageBox("The system " & name & " does not exist.", "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End If

		Dim doCustomFolderInput As New CustomFolderInput(name)
		doCustomFolderInput.ShowDialog()

		' check to see if we canceled our action
		If doCustomFolderInput.DialogResult = DialogResult.Cancel Then
			Return
		End If

		Dim newName As String = doCustomFolderInput.SystemName_TextBox.Text

		' surround with try/catch for any issues we have not handled
		Try
			' rename the old folder to the new name we want and update our list
			Rename(APP_DATA_PATH & "\" & name, APP_DATA_PATH & "\" & newName)
			UpdateList()
		Catch ex As Exception
			Dim doCustomMessageBox As New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End Try
	End Sub

	Private Sub Delete_Button_Click() Handles Delete_Button.Click
		' get the name of the selected system
		Dim name As String = Systems_ListBox.SelectedItem

		Dim doCustomMessageBox As New CustomMessageBox("Delete System " & name & "?", "No", "Yes")

		' check to see that the system folder exists
		If Directory.Exists(APP_DATA_PATH & "\" & name) = False Then
			doCustomMessageBox = New CustomMessageBox("The system " & name & " does not exist.", "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End If

		' confirm they want to delete the system
		doCustomMessageBox.ShowDialog()

		' check to see if we canceled our action
		If doCustomMessageBox.DialogResult = 1 Then
			Return
		End If

		' surround with try/catch for any issues we have not handled
		Try
			' delete the folder and update our list
			Directory.Delete(APP_DATA_PATH & "\" & name, True)
			While Directory.Exists(APP_DATA_PATH & "\" & name) = True
				' loop insdie here until we know that the folder has been deleted
			End While

			UpdateList()
		Catch ex As Exception
			doCustomMessageBox = New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End Try
	End Sub

	Private Sub Select_Button_Click() Handles Select_Button.Click
		' open our picture build specific to the system that is selected
		Dim doPictureBuilder As New AquaRevivalPictureBuilder(Systems_ListBox.SelectedItem)
		doPictureBuilder.Show

		Close()
	End Sub

	Private Sub System_DataGridView_SelectionChanged() Handles Systems_ListBox.SelectedIndexChanged
		' enable our edit buttons
		Rename_Button.Enabled = True
		Delete_Button.Enabled = True
		Select_Button.Enabled = True
	End Sub

	Private Sub Systems_ListBox_DoubleClick(sender As Object, e As EventArgs) Handles Systems_ListBox.DoubleClick
		Select_Button_Click()
	End Sub
End Class