[Setup]
; General information about the installation.
AppName=MOM Application
AppVersion=1.2.0
ArchitecturesInstallIn64BitMode=x64
DefaultDirName={autopf}\MOM
DefaultGroupName=MOM
DisableProgramGroupPage=yes
DisableFinishedPage=yes
OutputDir=Installer
OutputBaseFilename=MOMInstaller
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
; Optional tasks: creating a desktop icon
; Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Files to be included in the installation.
Source: ".\\App\\bin\\Release\\net8.0-windows7.0\\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
; Creating the application icons.
Name: "{group}\\MOM"; Filename: "{app}\\MOM.exe"
Name: "{commondesktop}\\MOM"; Filename: "{app}\\MOM.exe"

[Run]
; Commands to be run when installation finishes.
Filename: "{app}\\MOM.exe"; Description: "{cm:LaunchProgram,MOM}"; Flags: nowait postinstall
