Imports System.IO

Public Class AquaRevivalPictureBuilder

	Dim DescriptionArray As Label()
	Dim DefaultPicArray As PictureBox()
	Dim NewPicArray As PictureBox()
	Dim SelectButtonArray As Button()
	Dim RemoveButtonArray As Button()

	Dim ImageListString As String = ""
	Dim WorkingPath As String = ""

	Public Sub New(ByVal System As String)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		WorkingPath = APP_DATA_PATH & System & "\"
	End Sub

	Private Sub AquaRevivalPictureBuilder_Load() Handles MyBase.Load
		' initilize our arrays
		DescriptionArray = New Label() {Description0, Description1, Description2, Description3, Description4, Description5, Description6, Description7, Description8, Description9, Description10}
		DefaultPicArray = New PictureBox() {Default0, Default1, Default2, Default3, Default4, Default5, Default6, Default7, Default8, Default9, Default10}
		NewPicArray = New PictureBox() {New0, New1, New2, New3, New4, New5, New6, New7, New8, New9, New10}
		SelectButtonArray = New Button() {Select0, Select1, Select2, Select3, Select4, Select5, Select6, Select7, Select8, Select9, Select10}
		RemoveButtonArray = New Button() {Remove0, Remove1, Remove2, Remove3, Remove4, Remove5, Remove6, Remove7, Remove8, Remove9, Remove10}
	End Sub

	Private Sub Init() Handles Me.Shown
		' build our directories and load images
		SetupDirectories()
		LoadImages()

		' add select and remove functions for our buttons
		For index = 0 To Image_max - 1
			AddHandler SelectButtonArray(index).Click, AddressOf Selected
			AddHandler RemoveButtonArray(index).Click, AddressOf Remove

			DescriptionArray(index).Text = IMAGE_TITLES(index)
		Next
	End Sub

	Private Sub SetupDirectories()
		' check to see that all of our folders are created for the program
		CreateDirectory(WorkingPath & JPG_UPDATE_FOLDER)
		CreateDirectory(WorkingPath & BIN_UPDATE_FOLDER)
	End Sub

	Private Sub CreateDirectory(ByVal path As String)
		' check to see if our folder is set up for the conversion
		If Directory.Exists(path) = False Then
			Directory.CreateDirectory(path)
		End If
	End Sub

	Private Sub LoadImages()
		' disable our build button if we do not have any custom pictures
		Build_Button.Enabled = False

		For index = 0 to Image_max - 1
			' clear our current picture to account for any deleted images
			NewPicArray(index).Image = Nothing
			RemoveButtonArray(index).Enabled = False

			' check that we have the default image
			If File.Exists(JPG_DEFAULT_FOLDER & JPG_NAMES(index) & JPG_EXE) = False Then
				Dim errorMessage As String =
"Unable to find the default image at:" & vbNewLine &
vbNewLine &
JPG_DEFAULT_FOLDER & JPG_NAMES(index) & JPG_EXE & vbNewLine &
vbNewLine &
"Please check that the folder and files are in this location. If not, please uninstal and " &
"re-install the program. If this issue continues, please contact technical support."

				' display our error message
				Dim doCustomMessageBox As New HelpMessageBox(errorMessage, False)
				doCustomMessageBox.StartPosition = FormStartPosition.CenterScreen
				doCustomMessageBox.ShowDialog()

				WriteToEventLog(errorMessage, EventLogEntryType.Error)

				End
			End If

			' load our default images
			Dim img As Image = Image.FromFile(JPG_DEFAULT_FOLDER & JPG_NAMES(index) & JPG_EXE)

			' create a new bitmap with the picture box's width and height
			Dim resized As New Bitmap(DefaultPicArray(index).Width, DefaultPicArray(index).Height)

			' create out graphics from our bitmap
			Dim g As Graphics = Graphics.FromImage(resized)

			' draw our source image in our constraints
			g.DrawImage(img, 0, 0, resized.Width, resized.Height)

			' set the image to our picture box
			DefaultPicArray(index).Image = resized

			' dispose the image so we can free it up for later
			img.Dispose()

			' if there is no image at the save location for this valve then continue to the next image
			If File.Exists(WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(index) & JPG_EXE) = False Then
				Continue For
			End If

			' enable our edit buttons
			RemoveButtonArray(index).Enabled = True
			Build_Button.Enabled = True

			img = Image.FromFile(WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(index) & JPG_EXE)

			' create a new bitmap with the picture box's width and height
			resized = New Bitmap(DefaultPicArray(index).Width, DefaultPicArray(index).Height)

			' create out graphics from our bitmap
			g = Graphics.FromImage(resized)

			' draw our source image in our constraints
			g.DrawImage(img, 0, 0, resized.Width, resized.Height)

			' set the image to our picture box
			NewPicArray(index).Image = resized

			' dispose the image so we can free it up for later
			img.Dispose()
		Next

	End Sub

	Private Sub Selected(sender As Object, e As EventArgs)
		' update our public image index
		' each button is named "select##". by getting the number, it will point to the correct array location
		Image_Index = (sender.Name.Substring("Select".Length))

		' open our crop image tool
		Dim DoCropImage As New CropImage(WorkingPath)
		DoCropImage.ShowDialog()

		' reload our images once we come back in case we saved new images
		LoadImages()
	End Sub

	Private Sub Remove(sender As Object, e As EventArgs)
		' each button is named "remove##". by getting the number, it will point to the correct array location
		Dim number As Integer = (sender.Name.Substring("Remove".Length))

		' confirm with the user that they want to delete all of the current images
		Dim doCustomMessageBox As New CustomMessageBox("Remove " & IMAGE_TITLES(number) & "'s new image?", "No", "Yes")
		doCustomMessageBox.ShowDialog()

		' check to see if we canceled our action
		If doCustomMessageBox.DialogResult = 1 Then
			Return
		End If

		' surround with try/catch for any issues we have not handled
		Try
			' delete and reload our images
			File.Delete(WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(number) & JPG_EXE)
		Catch ex As Exception
			doCustomMessageBox = New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End Try

		LoadImages()
	End Sub

	Private Sub Images_Panel_MouseEnter() Handles Images_Panel.MouseEnter
		Images_Panel.Focus
	End Sub

	Private Sub RemoveAll_Button_Click() Handles RemoveAll_Button.Click
		' confirm with the user that they want to delete all of the new images
		Dim doCustomMessageBox As New CustomMessageBox("Remove all of your new images?", "No", "Yes")
		doCustomMessageBox.ShowDialog()

		' check to see if we canceled our action
		If doCustomMessageBox.DialogResult = 1 Then
			Return
		End If

		' surround with try/catch for any issues we have not handled
		Try
			' delete all of the images in the folder 
			For Each deleteFile In Directory.GetFiles(WorkingPath & JPG_UPDATE_FOLDER, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(deleteFile)
			Next
		Catch ex As Exception
			doCustomMessageBox = New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End Try

		' refresh the display images
		LoadImages()
	End Sub

	Private Sub Build_Button_Click() Handles Build_Button.Click
		' clear the contents of our ImageListString
		ImageListString = ""
		Dim message As String = ""

		Dim doCustomMessageBox As New CustomMessageBox("Please insert your USB.", "Cancel", "Proceed")
		doCustomMessageBox.ShowDialog()

		' check to see if we canceled our action
		If doCustomMessageBox.DialogResult = 1 Then
			Return
		End If

		' ask the user for the location of the USB folder
		If GetUSBFolder(usersUSBpath) = False
			Return
		End If
		Cursor.Current = Cursors.WaitCursor

		' surround with try/catch for any issues we have not handled
		Try
			' delete everything in the folder structure before we move the images in
			For Each deleteFile In Directory.GetFiles(WorkingPath & BIN_UPDATE_FOLDER, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(deleteFile)
			Next
		Catch ex As Exception
			doCustomMessageBox = New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
		End Try

		' run the utility to convert from JPG to TGA format
		If ConvertJPGtoTGA() = False Then
			Cursor.Current = Cursors.Default
			message = "One or more JPG files were not converted to TGA."

			dim docustom as new HelpMessageBox(message)
			docustom.ShowDialog
			Return
		End If

		' run the utility to convert from TGA to BIN
		If ConvertTGAtoBIN() = False Then
			Cursor.Current = Cursors.Default

			message = "One or more TGA files were not converted to BIN."

			dim docustom as new HelpMessageBox(message)
			docustom.ShowDialog
			Return
		End If

		' create the ImageList text file
		If CreateImageList() = False Then
			Cursor.Current = Cursors.Default
			message = "Could not create imagelist.txt."

			dim docustom as new HelpMessageBox(message)
			docustom.ShowDialog
			Return
		End If

		' run the utility to convert into the disk image.
		If CreateDiskImage() = False Then
			Cursor.Current = Cursors.Default
			message = "Could not create disk image."

			dim docustom as new HelpMessageBox(message)
			docustom.ShowDialog
			Return
		End If

		' copy the disk file to the USB location
		CopyFiles(WorkingPath & APP_UPDATE_PATH, usersUSBpath & DSK_FOLDER, DSK_EXE_FILTER)

		Cursor.Current = Cursors.Default

		' alert the user that we are done with the background processes
		Dim doHelpMessageBox As New HelpMessageBox(FINISH_INSTRUCTIONS)
		doHelpMessageBox.ShowDialog


		if EjectDrive(usersUSBpath.Substring(0, 2)) = false Then
			Cursor.Current = Cursors.Default
			message = "Could not safely eject USB under program control. Please safely eject manually."

			dim docustom as new HelpMessageBox(message)
			docustom.ShowDialog
		End If
	End Sub

	Private Function EjectDrive(ByVal DriveLetter As String) As Boolean
		dim retval As Boolean = True
		Cursor = Cursors.WaitCursor

		'http://www.uwe-sieber.de/drivetools_e.html
		Dim p As New ProcessStartInfo
		p.FileName = EJECT_DRIVE_PATH
		p.WindowStyle = ProcessWindowStyle.Hidden
		p.CreateNoWindow = True
		p.UseShellExecute = False

		p.Arguments = DriveLetter

		Dim proc = Process.Start(p)
		proc.WaitForExit()

		Cursor = Cursors.Default

		If proc.ExitCode <> 0 Then
			dim message As String = "Process: " & p.FileName & vbNewLine & "Args: " & p.Arguments
			WriteToEventLog(message, EventLogEntryType.Error)
			retval = False
		Else
			dim message As String = "The 'USB Mass Storage Device' device can now be safely removed from the computer."

			dim docustom as new CustomMessageBox(message, "OK")
			docustom.ShowDialog
		End If

		Return retval
	End Function

	Private Function GetUSBFolder(byref path) As Boolean
		Dim doCustomTreeView As New CustomTreeView
		doCustomTreeView.ShowDialog

		If doCustomTreeView.DialogResult = DialogResult.Cancel Then
			Return False
		End If

		path = doCustomTreeView.Path_TextBox.Text

		Return True
	End Function

	Private Function ConvertJPGtoTGA() As Boolean
		Dim retval As Boolean = True

		Dim p As New ProcessStartInfo
		p.FileName = JPG_TO_TGA_PATH
		p.WindowStyle = ProcessWindowStyle.Hidden

		For index = 0 To Image_max - 1
			' grab the path to the JPG
			Dim sourcePath As String = WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(index) & JPG_EXE

			' check to see if the file exists or not
			If File.Exists(sourcePath) = False Then
				Continue For
			End If

			' add an entry into our ImageListString for the text file
			ImageListString &= JPG_ENTRY & JPG_NAMES(index) & JPG_EXE & vbNewLine

			' -convert <source file> -compress RLE -orient TopLeft -rotate 180 -flop <target file>
			p.Arguments = "convert """ & sourcePath & """ -compress RLE -orient TopRight -rotate 180 -flop """ & WorkingPath & BIN_UPDATE_FOLDER & "\" & JPG_NAMES(index) & TGA_EXE & """"

			Dim proc = Process.Start(p)
			proc.WaitForExit()

			If proc.ExitCode <> 0 Then
				dim message As String = "Process: " & p.FileName & vbNewLine & "Args: " & p.Arguments
				WriteToEventLog(message, EventLogEntryType.Error)
				retval = False
			End If
		Next

		Return retval
	End Function

	Private Function ConvertTGAtoBIN() As Boolean
		Dim retval As Boolean = True

		Dim p As New ProcessStartInfo
		p.FileName = TGA_TO_BIN_PATH
		p.WindowStyle = ProcessWindowStyle.Hidden

		For index = 0 To Image_max - 1
			' grab the path for the TGA input
			Dim inputFile As String = WorkingPath & BIN_UPDATE_FOLDER & "\" & JPG_NAMES(index) & TGA_EXE

			' check to make sure that we have a TGA file in the location
			If File.Exists(inputFile) = False Then
				Continue For
			End If

			' add an entry into our ImageListString for the text file
			ImageListString &= BIN_ENTRY & JPG_NAMES(index) & BIN_EXE & vbNewLine

			' set the output path for the BIN
			Dim outputFile As String = WorkingPath & BIN_UPDATE_FOLDER & "\" & JPG_NAMES(index) & BIN_EXE

			' tgatoc -b -n -v<index #> -f<output file name> <input file name>
			p.Arguments = "tgatoc -b -n -v" & index & " -f""" & outputFile & """ """ & inputFile & """"

			dim proc = Process.Start(p)
			proc.WaitForExit()

			If proc.ExitCode <> 0 Then
				dim message As String = "Process: " & p.FileName & vbNewLine & "Args: " & p.Arguments
				WriteToEventLog(message, EventLogEntryType.Error)
				retval = False
			End If
		Next

		Return retval
	End Function

	Private Function CreateImageList() As Boolean
		Dim retval As Boolean = True

		Dim objWriter As New StreamWriter(WorkingPath & IMAGE_LIST_FILE)
		objWriter.Write(ImageListString)

		objWriter.Close()

		Return retval
	End Function

	Private Function CreateDiskImage() As Boolean
		Dim retval As Boolean = True

		Dim p As New ProcessStartInfo
		p.FileName = BUILD_DISK_IMAGE
		p.WindowStyle = ProcessWindowStyle.Hidden

		' baseDiskImage.bin <inputOutputfolder> <imagelistfile.txt>
		p.Arguments = """" & BASE_BIN_FILE & """ """ & WorkingPath & APP_UPDATE_PATH & """ """ & WorkingPath & IMAGE_LIST_FILE & """"

		dim proc = Process.Start(p)
		proc.WaitForExit()

		If proc.ExitCode <> 0 Then
			dim message As String = "Process: " & p.FileName & vbNewLine & "Args: " & p.Arguments
			WriteToEventLog(message, EventLogEntryType.Error)
			retval = False
		End If

		Return retval
	End Function

	Private Sub CopyFiles(byref Source As String, ByRef Destination As String, ByRef Exe As String)
		' check to see that the folder structure is on the USB
		If Directory.Exists(Destination) = False Then
			Directory.CreateDirectory(Destination)
		End If

		' grab all of the files from the save location
		Dim files() As String = Directory.GetFiles(Source, Exe)
		For each currentfile In files
			File.Copy(currentfile, Destination & "\" & Path.GetFileName(currentfile), True)
		Next
	End Sub

	Private Sub Close_Button_Click() Handles Exit_Button.Click
		Close()
	End Sub

	Public Function WriteToEventLog(ByVal message As String, Optional eventType As EventLogEntryType = EventLogEntryType.Information)
		Dim appName As String = "Aqua Revival Picture Builder"
		Dim logName = "Application"

		Dim objEventLog As New EventLog()

		Try
			If Not EventLog.SourceExists(appName) Then
				EventLog.CreateEventSource(appName, logName)
			End If

			objEventLog.Source = appName

			objEventLog.WriteEntry(message, eventType)
			Return True
		Catch Ex As Exception
			Return False
		End Try

	End Function

	Private Sub AquaRevivalPictureBuilder_Closing() Handles Me.Closing
		Dim doMenuSelect As New Menu_Select
		doMenuSelect.Show()
	End Sub
End Class