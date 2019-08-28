Public Module Common

	Public APP_NAME				As String = "Aqua Revival Picture Builder"
	Public LOG_NAME				As String = "Application"

    Public APP_DATA_PATH		As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\BlueSkyGlobal\UpdateImages\"
    Public APP_UPDATE_PATH		As String = "update"
    Public JPG_UPDATE_FOLDER	As String = "update\web\images"
    Public BIN_UPDATE_FOLDER	As String = "update\images"
    Public IMAGE_LIST_FILE		As String = "imagelistfile.txt"
    Public APP_DIRECTORY		As String = Application.StartupPath & "\"
    Public JPG_DEFAULT_FOLDER	As String = APP_DIRECTORY & "default_images\"
    Public JPG_TO_TGA_PATH		As String = APP_DIRECTORY & "magick.exe"
    Public TGA_TO_BIN_PATH		As String = APP_DIRECTORY & "tgatoc.exe"
    Public BASE_BIN_FILE		As String = APP_DIRECTORY & "sflashbase.bin"
    Public BUILD_DISK_IMAGE		As String = APP_DIRECTORY & "BuildDiskImage.exe"
	Public EJECT_DRIVE_PATH		As String = APP_DIRECTORY & "RemoveDrive.exe"
    Public Const DSK_FOLDER		As String = "picture\"
    Public Const TGA_EXE		As String = ".tga"
    Public Const BIN_EXE		As String = ".bin"
    Public Const JPG_EXE		As String = ".jpg"
    Public Const DSK_EXE		As String = ".dsk"
    Public Const JPG_EXE_FILTER As String = "*" & JPG_EXE
    Public Const BIN_EXE_FILTER As String = "*" & BIN_EXE
    Public Const DSK_EXE_FILTER As String = "*" & DSK_EXE
    Public Const JPG_ENTRY		As String = "\web\images\"
    Public Const BIN_ENTRY		As String = "\images\"

    Public Const EDGE_BUFFER	As Integer = 15				' buffer pixels used for the crop rectangle edge detection 
    Public Const X_MIN			As Integer = 400			' minimum x size
    Public Const Y_MIN			As Integer = 350			' minimum y size
	Public Const X_MIN_LOGO		As Integer = 360			' minimum x size for the logo image
    Public Const Y_MIN_LOGO		As Integer = 240			' minimum y size for the logo image
	Public		 LOGO_BG		As Color   = Color.FromArgb(255, 20, 77, 129)

    Public JPG_NAMES			As String() = {
"Splash",
"V3Valve",
"V4Valve",
"V5Valve",
"V7Valve",
"V8Valve",
"V9Valve",
"V6Valve",
"Cleaner",
"V6Clean",
"V6Perlit",
"Perlite"
    }

    Public IMAGE_TITLES			As String() = {
"1. Company Logo",
"2. V3 Valve Manual Revival Valve",
"3. V4 Valve Pump Throttling Valve",
"4. V5 Valve Drain Valve",
"5. V7 Valve Tank Vent Valve",
"6. V8 Valve System Vent Valve",
"7. V9 Valve Vacuum Valve",
"8. V6 ValveMedia Fill Valve",
"9. Cleaner",
"10. V6 Clean",
"11. V6 Perlite",
"12. Perlite"
    }

	Public IMAGE_WIDTH			As Integer() = {
		X_MIN_LOGO,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN,
		X_MIN
	}

	Public IMAGE_HEIGTH			As Integer() = {
		Y_MIN_LOGO,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN,
		Y_MIN
	}

    Public IMAGE_DESCRIPTIONS	As String() = {
"Shows your Compnay's logo during startup. The default background-color's RGB value is (20, 77, 129).",
"Shows operator using the V3 Manual Revival valve which is used to allow water to flow through the revive loop, bypassing the actual pool loop.",
"Shows operator using the V4 Pump Throttle valve which is used to slow the water flow through the revive loop.",
"Shows operator using the V5 Drain valve which is used to drain water from the tank.",
"Shows operator using the V7 Tank Vent valve which allows air into the system when loading Perlite or cleaner.",
"Shows operator using the V8 System Vent Valve which allows air to bleed from the piping when filling the tank with water.",
"Shows operator using the V9 Vacuum Valve which is connected to a vacuum to create suction which loads the Perlite or cleaner.",
"Shows operator using the V6 Media Fill valve without perlite or cleaner in view.",
"Shows Media fill valve with tubing inserted into cleaner container without an operator in view.",
"Shows operator using the V6 Media Fill valve when loading cleaner from a tank into the filter.",
"Shows operator using V6 Media Fill valve when loading Perlite from a container into the filter.",
"Shows Media fill valve with tubing inserted into Perlite container without an operator in view."
    }

    Public PROCESS_INSTRUCTIONS As String =
"Welcome to the AquaRevival Picture Builder." & vbNewLine &
vbNewLine &
"This program builds a picture file that can be loaded into the AquaRevival control to " &
"replace the pictures that are displayed during the Drain/Rinse process. There are a " & 
"set of ten pictures that demonstrate to the operator the correct valve to open or " & 
"close And how to load the Perlite into the filter." & vbNewLine &
vbNewLine &
"The first step in replacing the standard pictures is to take a picture that is similar to " & 
"the standard version, but showing an operator grabbing the valve handle, while " & 
"showing enough of the filter background to differentiate it from the other valves." & vbNewLine &
vbNewLine &
"You can replace some or all of the standard pictures, so take as many pictures as " & 
"makes sense. You don't have to run the filter to take the pictures, just have an " & 
"operator stand or crouch next to each of the valves and pretend to turn them." & vbNewLine &
vbNewLine &
"Once you have taken the pictures, load them into the PC that is running this " & 
"program. Next, you would use the following dialogs to browse and load each picture. It " & 
"is important to load the right picture for each of the ten images. For example, when " & 
"you are loading the picture that shows the operator closing Valve 3, make sure you " & 
"replace it with the your operator closing the same valve." & vbNewLine &
vbNewLine &
"Once you load a picture, it must be resized and cropped so that it fits on the " & 
"Controller screen properly. You then sequence through each of the ten pictures." & vbNewLine &
vbNewLine &
"When you have loaded and cropped each picture, you build the picture file and the program asks " & 
"you for a USB stick. After the program finishes, it will have copied the picture file to the USB stick. " & 
"You will then eject the stick and put it into the back of the AquaRevival control and load the " & 
"picture file from the front panel."

    Public HELP_INSTRUCTIONS	As String =
"Tutorial on how to use the crop tool:" & vbNewLine &
vbNewLine &
"Press the ""Browse"" button to load your picture that replaces the standard image for the action " &
"specified. After the picture is loaded, move the red outline rectangle to frame the action as " &
"best as possible." & vbNewLine &
vbNewLine &
"Move the rectangle by dragging the box from the center. Resize the rectangle by grabbing the " &
"sides to shrink or grow it."

    Public FINISH_INSTRUCTIONS	As String =
"You have successfully built the picture file. Please eject the USB stick from the PC and insert " &
"it into the AquaRevival control USB slot. First ensure that the filter is idle, then enter the " &
"Maintenance menu. Navigate to the Setup menu and enter the Administrator passcode. Next, " &
"enter the Advanced menu and select ""Custom Pictures"". Ensure the USB stick is inserted into the " &
"USB slot on the control and press ""Proceed""." & vbNewLine &
vbNewLine &
"The control will then load the picture file into the control. The control will show progress as " &
"it loads the file and a dialog will be displayed when it has completed." & vbNewLine &
vbNewLine &
"Please press 'OK' to safely eject the removable USB drive from the computer."

	Public INVALID_CHARACTERS	As String = 
"A file name can't contain any of the following characters:
\ / : * ? "" < > |"

	Public SAFE_TO_REMOVE		As String = "The 'USB Mass Storage Device' device can now be safely removed from the computer."

	Public REMOVE_NEW_IMAGE		As String = "'s new image?"
	Public REMOVE_ALL_IMAGES	As String = "Remove all of your new images?"
	Public INSERT_USB			As String = "Please insert your USB."

	Public ERROR_IMAGE_LOCATION1 As String = "Unable to find the default image at:"

	Public ERROR_IMAGE_LOCATION2 As String = 
"Please check that the folder and files are in this location. If not, please uninstal and " &
"re-install the program. If this issue continues, please contact technical support."

	Public ERROR_BIN_CONVERSION As String = "One or more JPG files were not converted to TGA."

	Public ERROR_IMAGE_TEXT		As String = "Could not create imagelist.txt."

	Public ERROR_DISK_IMAGE		As String = "Could not create disk image."

	Public ERROR_EJECT_USB		As String = "Could not safely eject USB under program control. Please safely eject manually."

	Public STR_SELECT			As String = "Select"
	Public STR_REMOVE			As String = "Remove"
	Public STR_YES				As String = "Yes"
	Public STR_NO				As String = "No"
	Public STR_OK				As String = "OK"
	Public STR_CANCEL			As String = "Cancel"
	Public STR_PROCEED			As String = "Proceed"

	Public LEN_SELECT			As Integer = STR_SELECT.Length
	Public LEN_REMOVE			As Integer = STR_REMOVE.Length

	Public PICTUREBOX_TOPLEFT_X As Integer = 0
	Public PICTUREBOX_TOPLEFT_Y As Integer = 0

    Public Enum MouseLocations                      ' locations on a rectangle
        NONE                                        ' 0 - Not current on the rectangle
        C                                           ' 1 - Center
        N                                           ' 2 - North
        E                                           ' 3 - East
        S                                           ' 4 - South
        W                                           ' 5 - West
    End Enum

	Public Enum CustomDialogResults
		CANCELED = 1
	End Enum

    Public usersJPGpath			As String = "C:"				' current path to the user's image
    Public usersUSBpath			As String = "C:"				' current path to the user's USB
    Public Image_Index			As Integer = 0					' index of the current step that we are on
    Public Image_max			As Integer = JPG_NAMES.Length	' the total number of images that we need
    Public ShowHelp				As Boolean = True               ' flag used to show croping instructions each time the user loads a new image
	Public ShowStartup			As Boolean = True				' flag used to show the welcome information to the user
End Module
