Imports System.Drawing.Drawing2D

Public Class CropImage
    Dim	mouseClicked	 As Boolean		   = False						' flag used to signal if the mouse is still clicked
	Dim mouseLocation	 As MouseLocations = MouseLocations.NONE			' current mouse location on the rectangle
	Dim imageLoaded		 As Boolean		   = False						' flag used to tell if the image has been loaded or not
						 
    Dim	rectCropArea	 As New Rectangle()								' crop area rectangle
	Dim	useLastPoint	 As New Point()                                  ' the point where we clicked our mouse
	Dim WorkingPath		 As		String  = ""
	Dim Xmin			 As		Integer = 0
	Dim Ymin			 As		Integer = 0
	Dim XAspectRatio	 As     Double  = 0.0
	Dim YAspectRatio	 As		Double  = 0.0
	Dim PictureBoxBuffer As		Integer = 5

	Public Sub New(ByVal Path As String)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		WorkingPath = Path
	End Sub

	Private Sub CropImage_Shown() Handles Me.Shown
		' set up the first step
		SetupStep(Image_Index)
	End Sub

	Private sub SetupStep(ByRef index As Integer) 

		If Image_Index = 0 Then
			Source_PictureBox.BackColor = LOGO_BG
			Cropped_PictureBox.BackColor = LOGO_BG
		Else
			Source_PictureBox.BackColor = Color.Black
			Cropped_PictureBox.BackColor = Color.Black
		End If

		' reset our loaded images flag
		imageLoaded = False

		' clear the crop preview
		Source_PictureBox.Image = Nothing
		Cropped_PictureBox.Image = Nothing

		' set out min and max x and y
		Xmin = IMAGE_WIDTH(Image_Index)
		Ymin = IMAGE_HEIGTH(Image_Index)

		' set our aspect ratios
		XAspectRatio = (Xmin / Ymin)
		YAspectRatio = (Ymin / Xmin)

		' resize the preview image if needed
		Cropped_PictureBox.Height = Ymin
		Cropped_PictureBox.Width = Xmin

		' reset the rectangle
		rectCropArea = New Rectangle(0, 0, Xmin, Ymin)

		' disable the Save Image button
		Save_Button.Enabled = False
		SaveAndNext_Button.Enabled = False

		' If we already have a file saved, use it 
		If IO.File.Exists(WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(index) & JPG_EXE) = True Then
			LoadImage(WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(index) & JPG_EXE)
		End If

		' set the title
		StepTitle_Label.Text = IMAGE_TITLES(index)

		' set the description
		Description_Label.Text = IMAGE_DESCRIPTIONS(index)

		' check to see if we are going to show our help dialog or not
		If ShowHelp = False Then
			Return
		End If

		Dim doHelpMessageBox As New HelpMessageBox(HELP_INSTRUCTIONS, True)
		doHelpMessageBox.ShowDialog

		' check the state of our checkbox to see if we want to display it every time
		ShowHelp = doHelpMessageBox.Remind_CheckBox.Checked
	End sub

	Private Sub LoadImage(ByRef ImagePath As string)
		' load up the image
		dim img = Image.FromFile(ImagePath)
		Dim width As Integer = 0
		Dim heigth As Integer = 0

		' check the image's demensions. If we are bigger than the picture box, we need to adjust
		If Source_PictureBox.Width < img.Width Or Source_PictureBox.Height < img.Height Then
			width = Source_PictureBox.Width
			heigth = Source_PictureBox.Height
		Else
			width = img.Width
			heigth = img.Height
		End If

		' create a new bitmap with the picture box's width and height
		Dim resized As New Bitmap(width, heigth)

		' create out graphics from our bitmap
        Dim g As Graphics = Graphics.FromImage(resized)

		' draw our source image in our constraints
        g.DrawImage(img, 0, 0, resized.Width , resized.Height)

		' set the image to our picture box
        Source_PictureBox.Image = resized

		imageLoaded = True

		img.Dispose()

		Crop()
    End Sub

	Private Function UpdateMouse(ByRef X As Integer, ByRef Y As Integer, ByRef R As Rectangle) As MouseLocations
		Dim retval As MouseLocations = MouseLocations.NONE

		'------------------------
		' N   S I D E
		'------------------------
		If (((R.X + EDGE_BUFFER) < X) And (X < (R.X + R.Width - EDGE_BUFFER))) And
		   (((R.Y - EDGE_BUFFER) <= Y) And (Y <= (R.Y + EDGE_BUFFER))) Then
			retval = MouseLocations.N
		
		'------------------------
		' S   S I D E
		'------------------------
		ElseIf (((R.X + EDGE_BUFFER) < X) And (X < (R.X + R.Width - EDGE_BUFFER))) And
		   (((R.Y + R.Height - EDGE_BUFFER) <= Y) And (Y <= (R.Y + R.Height + EDGE_BUFFER))) Then
			retval = MouseLocations.S
			
		'------------------------
		' W   S I D E
		'------------------------
		ElseIf (((R.Y + EDGE_BUFFER) < Y) And (Y < (R.Y + R.Height - EDGE_BUFFER))) And
		   (((R.X - EDGE_BUFFER) <= X) And (X <= (R.X + EDGE_BUFFER))) Then
			retval = MouseLocations.W

		'------------------------
		' E   S I D E
		'------------------------
		ElseIf (((R.Y + EDGE_BUFFER) < Y) And (Y < (R.Y + R.Height - EDGE_BUFFER))) And
		   (((R.X + R.Width - EDGE_BUFFER) <= X) And (X <= (R.X + R.Width + EDGE_BUFFER))) Then
			retval = MouseLocations.E

		'------------------------
		' C E N T E R
		'------------------------
		ElseIf ((R.X + EDGE_BUFFER) < X) And (X < (R.X + R.Width - EDGE_BUFFER)) And
		   ((R.Y + EDGE_BUFFER) < Y) And (Y < (R.Y + R.Height - EDGE_BUFFER)) Then
			retval = MouseLocations.C

		'------------------------
		' O U T S I D E   B O X
		'------------------------
		Else
			retval = MouseLocations.NONE
		End If

		' Set our mouse in relation to where it is to the rectangle
		Select Case retval
			Case MouseLocations.C
				Cursor = Cursors.SizeAll

			Case MouseLocations.N, MouseLocations.S
				Cursor = Cursors.SizeNS

			Case MouseLocations.W, MouseLocations.E
				Cursor = Cursors.SizeWE

			Case MouseLocations.NONE
				Cursor = Cursors.Default
		End Select

		Return retval
	End Function

	Private Sub Source_PictureBox_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Source_PictureBox.Paint
		' draw the red dashed rectangle for the crop area
        Dim drawLine As New Pen(Color.Red)
        drawLine.DashStyle = DashStyle.Dash
		drawLine.Width = 5
        e.Graphics.DrawRectangle(drawLine, rectCropArea)
    End Sub

	Private Sub Source_PictureBox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Source_PictureBox.MouseDown 
		' get the x and y coordinates of the mouse
		Dim X As Integer = e.X
		Dim Y As Integer = e.Y
		
		' set our mouse clicked flag
        mouseClicked = True

		' get the current x and y inside the picture box
        useLastPoint.X = X
        useLastPoint.Y = Y

		' lock in our x/y pos to change the mouse
		mouseLocation = UpdateMouse(X, Y, rectCropArea)

		' lock our mouse to only move inside the source picture box
		Dim rect As Rectangle = Source_PictureBox.Bounds
		rect.Location = PointToScreen(Source_PictureBox.Location)
		Cursor.Clip = rect
    End Sub

	Private Sub Source_PictureBox_MouseUp() Handles Source_PictureBox.MouseUp
		' set our mouse clicked flag
        mouseClicked = False

		' release the location lock on the mouse
		Cursor.Clip = Rectangle.Empty

		' update the crop area to bring it back into the picture box
		GrabC(0, 0, rectCropArea)
		Source_PictureBox.Refresh()
		Crop()
    End Sub

	Private Sub Source_PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Source_PictureBox.MouseMove
		' get the x and y coordinates of the mouse
		Dim X As Integer = e.X
		Dim Y As Integer = e.Y

		' check to see if we are clicked or not
		If mouseClicked = False Then
			' get our x/y pos to change the mouse
			mouseLocation = UpdateMouse(X, Y, rectCropArea)
			Return
		End If

		Dim result As Boolean = True

		' calculate the detas
		Dim dx As Integer = X - useLastPoint.X
		Dim dy As Integer = Y - useLastPoint.Y

		' check what state our mouse is in will determin what gets called
		Select Case mouseLocation
			Case MouseLocations.C
				result = GrabC(dx, dy, rectCropArea)

			Case MouseLocations.N
				result = GrabN(dy, rectCropArea)

			Case MouseLocations.E
				result = GrabE(dx, rectCropArea)

			Case MouseLocations.S
				result = GrabS(dy, rectCropArea)

			Case MouseLocations.W
				result = GrabW(dx, rectCropArea)

			Case MouseLocations.NONE
				Return
		End Select
 
		' update the picture box
        Source_PictureBox.Refresh()

		' update our click point for the next time this function gets called
		If result = True Then
			useLastPoint.X = X
			useLastPoint.Y = Y
		End If

		Crop()
	End Sub

	Private Sub Source_PictureBox_MouseLeave() Handles Source_PictureBox.MouseLeave
		' set our mouse clicked flag
        mouseClicked = False

		' reset our cursor to the default
		Cursor = Cursors.Default
	End Sub

	Private Function GrabC(ByRef dx As Integer, ByRef dy As Integer, ByRef R As Rectangle) As Boolean
		' since this is a movment, we simply add the change in x and y
		R.X += dx
		R.Y += dy

		' check to see if the rectangle is bigger than the source area
		If R.Width > (Source_PictureBox.Width - PictureBoxBuffer) Then
			R.Width = (Source_PictureBox.Width - PictureBoxBuffer)
			R.Height = (R.Width * YAspectRatio)
		End If

		' SPECIAL CASE! If we are doing the LOGO (index 0) then we want to be able to center the image
		If Image_Index = 0 Then
			Return True
		End If

		' check for going beyond the edges
		If R.X < 0 Then
			R.X = 0
		ElseIf Source_PictureBox.Width < R.X + R.Width
			R.X = Source_PictureBox.Width - R.Width
		End If
		If R.Y < 0 Then
			R.Y = 0
		ElseIf Source_PictureBox.Height < R.Y + R.Height
			R.Y = Source_PictureBox.Height - R.Height
		End If

		Return True
	End Function

	Private Function GrabN(ByRef dy As Integer, ByRef R As Rectangle) As Boolean
		' check to see if we are going to make the y too small
		If (R.Height - dy) < Ymin
			' set the minimum size
			R.Height = Ymin
			R.Width = Xmin
			Return False
		End If

		' we are moving the top side so add dy to y
		R.Y += dy

		' update the width and height
		R.Height -= dy
		R.Width = (R.Height * XAspectRatio)

		Return True
	End Function

	Private Function GrabS(ByRef dy As Integer, ByRef R As Rectangle) As Boolean
		' check to see if we are going to make the y too small
		If (R.Height + dy) < Ymin
			' set the minimum size
			R.Height = Ymin
			R.Width = Xmin
			Return False
		End If

		' update the width and height
		R.Height += dy
		R.Width = (R.Height * XAspectRatio)

		Return True
	End Function

	Private Function GrabE(ByRef dx As Integer, ByRef R As Rectangle) As Boolean
		' check to see if we are going to make the x too small
		If (R.Width + dx) < Xmin
			' set the minimum size
			R.Height = Ymin
			R.Width = Xmin
			Return False
		End If

		' update the width and height
		R.Height = (R.Width * YAspectRatio)
		R.Width += dx

		Return True
	End Function
	
	Private Function GrabW(ByRef dx As Integer, ByRef R As Rectangle) As Boolean
		' check to see if we are going to make the x too small
		If (R.Width - dx) < Xmin
			' set the minimum size
			R.Height = Ymin
			R.Width = Xmin
			Return False
		End If

		' we are moving the left side so add dx to x
		R.X += dx

		' update the width and height
		R.Width -= dx
		R.Height = (R.Width * YAspectRatio)

		Return True
	End Function

	Private Sub Browse_Button_Click() Handles Browse_Button.Click
		' create our file browser looking for the user's image
		Dim openDlg As New OpenFileDialog
        openDlg.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|Bitmap Files (*.bmp)|*.bmp"
		openDlg.CheckFileExists = True
		openDlg.CheckPathExists = True
		openDlg.InitialDirectory = usersJPGpath
		openDlg.Title = "Browse for " & IMAGE_TITLES(Image_Index)

		' check to see if we canceled our action
        If openDlg.ShowDialog() <> DialogResult.OK Then
			Return
        End If

		' update our users path choice
        usersJPGpath = openDlg.FileName

		' reset the rectangle
		rectCropArea = New Rectangle(0, 0, Xmin, Ymin)

		' load the image
		LoadImage(openDlg.FileName)
	End Sub

	Private Sub Crop()
		' check to see if we have a loaded image or not
		If imageLoaded = False Then
			Return
		End If

		' make a copy of the source with its full demensions
        Dim sourceBitmap As New Bitmap(Source_PictureBox.Image, Source_PictureBox.Image.Width, Source_PictureBox.Image.Height) 
		
		' make our new image the size of our crop reslut size
		Dim cropBitmap = New Bitmap(Cropped_PictureBox.Width, Cropped_PictureBox.Height)
		Dim g As Graphics = Graphics.FromImage(cropBitmap)
 
		' scale the source image to the crop image
        g.DrawImage(sourceBitmap, New Rectangle(0, 0, Cropped_PictureBox.Width, Cropped_PictureBox.Height), rectCropArea, GraphicsUnit.Pixel)

		' set the crop image to the results display
		Cropped_PictureBox.Image = cropBitmap
		Cropped_PictureBox.Refresh()

		'sourceBitmap.Dispose()
		'cropBitmap.Dispose()

		' enable the Use Image button
		Save_Button.Enabled = True
		SaveAndNext_Button.Enabled = True
    End Sub

	Private Sub SaveImage_Button_Click() Handles Save_Button.Click
		SavePhoto(Cropped_PictureBox.Image)

		Close()
	End Sub

	Private Sub SaveAndNext_Button_Click() Handles SaveAndNext_Button.Click
		SavePhoto(Cropped_PictureBox.Image)

		' check to see if we are not on the last step
		If Image_Index = IMAGE_TITLES.Length - 1 Then
			Close()
		End If

		' increment our index
		Image_Index += 1

		' set up the next step
		SetupStep(Image_Index)
	End Sub

	Private sub SavePhoto(ByVal src As Image)
		' surround with try/catch for any issues we have not handled
        Try
            dim imgFoto As New Bitmap(Cropped_PictureBox.Width, Cropped_PictureBox.Height)
            Dim recDest As New Rectangle(0, 0, imgFoto.Width, imgFoto.Height)
            Dim g As Graphics = Graphics.FromImage(imgFoto)
			g.Clear(LOGO_BG)
            g.SmoothingMode = SmoothingMode.HighQuality
            g.CompositingQuality = CompositingQuality.HighQuality
            g.InterpolationMode = InterpolationMode.High

            g.DrawImage(src, recDest, 0, 0, src.Width, src.Height, GraphicsUnit.Pixel)

            Dim myEncoder As Imaging.Encoder
            Dim myEncoderParameter As Imaging.EncoderParameter
            Dim myEncoderParameters As Imaging.EncoderParameters

            Dim arrayICI() As Imaging.ImageCodecInfo = Imaging.ImageCodecInfo.GetImageEncoders()
            Dim jpegICI As Imaging.ImageCodecInfo = Nothing
            Dim x As Integer = 0
            For x = 0 To arrayICI.Length - 1
                If (arrayICI(x).FormatDescription.Equals("JPEG")) Then
                    jpegICI = arrayICI(x)
                    Exit For
                End If
            Next

            myEncoder = Imaging.Encoder.Quality
            myEncoderParameters = New Imaging.EncoderParameters(1)
            myEncoderParameter = New Imaging.EncoderParameter(myEncoder, 60L)
            myEncoderParameters.Param(0) = myEncoderParameter

			' create our path variables
			Dim OutputFile As String = WorkingPath & JPG_UPDATE_FOLDER & "\" & JPG_NAMES(Image_Index) & JPG_EXE

			' save our image as a temp name
            imgFoto.Save(OutputFile, jpegICI, myEncoderParameters)
            imgFoto.Dispose()

        Catch ex As Exception
			dim doCustomMessageBox As New CustomMessageBox(ex.Message, "OK")
			doCustomMessageBox.ShowDialog()
			Return
        End Try
    End sub

	Private Sub Close_Button_Click() Handles Cancel_Button.Click
		Close()
	End Sub

End Class