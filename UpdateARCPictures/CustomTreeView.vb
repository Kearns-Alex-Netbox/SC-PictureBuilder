Imports System.IO
Imports System.Runtime.InteropServices

Public Enum IconSizes As Integer
    Large32x32 = 0
    Small16x16 = 1
End Enum

Public Class CustomTreeView
'https://www.dreamincode.net/forums/topic/400525-treeview-drive-folder-and-file-explorer/
'http://www.vbforums.com/showthread.php?534956-RESOLVED-Detecting-Drive-Letter-of-USB-Drive
'http://www.vbforums.com/showthread.php?759501-VB-Net-List-All-Removable-Forms-of-Storage-(e-g-Flash-Disk)

	Private Const WM_DEVICECHANGE As Integer = 537
    Private Const DBT_DEVICEARRIVAL As Integer = 7

	Protected Overrides Sub WndProc(ByRef m As Message)
		' listens for a device being inserted/removed
        If m.Msg = WM_DEVICECHANGE Then
            If CInt(m.WParam) = DBT_DEVICEARRIVAL Then
				' refresh our list of drives
                AddDriveRootNodes()
            End If
        End If

        MyBase.WndProc(m)
    End Sub

	Private Sub CustomTreeView_Load() Handles MyBase.Load
        Explorer_TreeView.ImageList = Icon_ImageList

		' refresh our list of drives
		AddDriveRootNodes()
	End Sub

	Private Sub Init() Handles MyBase.Shown
		' check to see if we only have a single removable drive attached in our list
        If Explorer_TreeView.Nodes.Count = 1 Then
			' get the drive's info that we extracted
			Dim driveInfo As String = Explorer_TreeView.Nodes(0).Text

			Dim doCustomMessageBox As New CustomMessageBox("Would you like to use """ & driveInfo & """?", "No", "Yes")
			doCustomMessageBox.ShowDialog()

			' check to see if we want to use that drive
			If doCustomMessageBox.DialogResult = 2 Then
				Path_TextBox.Text = Explorer_TreeView.Nodes(0).Tag.ToString
				OK_Button_Click
			End If
        End If
	End Sub

	Private Sub AddDriveRootNodes()
		' clear any existing nodes and re-add what we find.
		Explorer_TreeView.Nodes.Clear()

		' iterate through all the drives on the system
		For Each drv As DriveInfo In DriveInfo.GetDrives
			' check to see if the drive is ready or not
			If (drv.IsReady = False) Or (drv.DriveType <> DriveType.Removable) Then
				Continue For
			End If

			' add the drive icon image to the ImageList
			AddImageToImgList(drv.Name)

			' create a new TreeNode for the drive
			Dim DriveNode As New TreeNode(drv.Name)
			With DriveNode
				' set the Tag property to the name of the drive (C:\, D:\, and so on...)
				.Tag = drv.Name
				.Text = drv.VolumeLabel & " (" & drv.Name & ")"

				' set the ImageKey to the name of the drive which is the ImageKey name that is used to add the image to the ImageList
				.ImageKey = drv.Name
				.SelectedImageKey = drv.Name
			End With

			' add the drive node to the TreeView
			Explorer_TreeView.Nodes.Add(DriveNode)
		Next
	End Sub

	Private Function AddImageToImgList(FullPath As String, Optional SpecialImageKeyName As String = "") As String
        Dim ImgKey As String = If(SpecialImageKeyName = "", FullPath, SpecialImageKeyName)
        Dim LoadFromExt As Boolean = False

        If ImgKey = FullPath AndAlso File.Exists(FullPath) Then
            Dim ext As String = Path.GetExtension(FullPath).ToLower

            If ext <> "" AndAlso ext <> ".exe" AndAlso ext <> ".lnk" AndAlso ext <> ".url" Then
                ImgKey = Path.GetExtension(FullPath).ToLower
                LoadFromExt = True
            End If
        End If

        If Not Icon_ImageList.Images.Keys.Contains(ImgKey) Then
            Icon_ImageList.Images.Add(ImgKey, Iconhelper.GetIconImage(If(LoadFromExt, ImgKey, FullPath), IconSizes.Large32x32))
        End If

        Return ImgKey
    End Function

	Private Sub Explorer_TreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Explorer_TreeView.AfterSelect
		' update the selected path
		Path_TextBox.Text = e.Node.Tag.ToString
		OK_Button.Enabled = True
	End Sub

	Private Sub Explorer_TreeView_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Explorer_TreeView.NodeMouseDoubleClick
		' make sure it is the left mouse button that was double clicked
		If e.Button = MouseButtons.Left Then

			Path_TextBox.Text = e.Node.Tag.ToString
			OK_Button_Click()
		End If
	End Sub

	Private Sub OK_Button_Click() Handles OK_Button.Click
		DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub Cancel_Button_Click() Handles Cancel_Button.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

End Class





Public Class Iconhelper
    Private Const SHGFI_ICON As Integer = &H100
    Private Const SHGFI_USEFILEATTRIBUTES As Integer = &H10

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Private Structure SHFILEINFOW
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
    End Structure

    <DllImport("shell32.dll", EntryPoint:="SHGetFileInfoW")>
    Private Shared Function SHGetFileInfoW(<MarshalAs(UnmanagedType.LPTStr)> ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFOW, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="DestroyIcon")> Private Shared Function DestroyIcon(ByVal hIcon As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    ''' <summary>Gets a Bitmap image of the specified file or folder icon.</summary>
    ''' <param name="FileOrFolderPath">The full path to the folder or file to get the icon image from, or just a file extension (.ext) to get the registered icon image of the file type.</param>
    ''' <param name="IconSize">The size of the icon to retrieve.</param>
    Public Shared Function GetIconImage(ByVal FileOrFolderPath As String, ByVal IconSize As IconSizes) As Bitmap
        Dim bm As Bitmap = Nothing
        Dim fi As New SHFILEINFOW
        Dim flags As Integer = If(FileOrFolderPath.StartsWith("."), (IconSize Or SHGFI_USEFILEATTRIBUTES), IconSize)

        If SHGetFileInfoW(FileOrFolderPath, 0, fi, Marshal.SizeOf(fi), SHGFI_ICON Or flags) <> 0 Then
            bm = Icon.FromHandle(fi.hIcon).ToBitmap
        End If

        DestroyIcon(fi.hIcon).ToString()

        Return bm
    End Function

End Class