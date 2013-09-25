; ------------------------------------------------------------------------------
; Torque Game Builder Adventure Kit
; Copyright (C) Sickhead Games, LLC
; ------------------------------------------------------------------------------

[Setup]
AppName=TGB Adventure Kit

; The appid is different from the app name to
; keep the installer from detecting pre 1.2
; versions of the advkit when looking for an
; install folder.
AppId=TGB_Adventure_Kit

AppVerName=TGB Adventure Kit 1.2
VersionInfoCompany=Sickhead Games, LLC
VersionInfoTextVersion=1.2.0.0
VersionInfoVersion=1.2.0.0
AppPublisher=GarageGames, Inc.
AppPublisherURL=http://www.garagegames.com
AppSupportURL=http://www.garagegames.com/pg/product/support.email.php?id=90
AppUpdatesURL=http://www.garagegames.com/myAccount/
AppCopyright=Copyright (C) Sickhead Games, LLC
DefaultDirName={code:GetInstallFolder}
DefaultGroupName=TGB Adventure Kit
DirExistsWarning=no
OutputDir=.\
AppendDefaultDirName=no
OutputBaseFilename=TGB_AdventureKit_v1_2_0
Compression=lzma/ultra
SolidCompression=yes
UninstallFilesDir={app}\games\AdventureKit\
LicenseFile=.\documentation\TGB Adventure Kit EULA.txt
;SetupIconFile=..\media\919.ico
WizardImageFile=.\installerimage.bmp
WizardSmallImageFile=.\installerimagesmall_a.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Messages]
SelectDirLabel3=Please select an existing Torque Game Builder 1.5.1 or higher folder.
InvalidPath=You must enter a full path with drive letter to an existing%nTorque Game Builder 1.5.1 or higher folder or new empty folder for install.

[Files]

; Copy the advkit demo with art.
Source: "games\adventureKit\*"; DestDir: "{app}\games\AdventureKit"; Excludes: "*.dso,*.torsion,*.torsion.*,console.log"; Flags: ignoreversion recursesubdirs createallsubdirs touch

; Now create the resource by copying the resource script
; then the art from the advkit demo folder.  This causes
; the installer to only pack the art once.
Source: "tgb\resources\adventureKitArt\resourceDatabase.cs"; DestDir: "{app}\tgb\resources\AdventureKitArt"; Flags: ignoreversion recursesubdirs createallsubdirs touch
Source: "games\adventureKit\game\data\images\sprites\*"; DestDir: "{app}\tgb\resources\AdventureKitArt\sprites"; Flags: ignoreversion recursesubdirs createallsubdirs touch
Source: "games\adventureKit\game\data\images\tiles\*"; DestDir: "{app}\tgb\resources\AdventureKitArt\tiles"; Flags: ignoreversion recursesubdirs createallsubdirs touch

; Create the template project by copying the game folder
; from the installed advkit demo.
Source: "games\adventureKit\game\*"; DestDir: "{app}\tgb\gameData\T2DProject\templates\AdventureKit"; Excludes: "*.dso"; Flags: ignoreversion recursesubdirs createallsubdirs touch

; Copy the docs.
Source: "documentation\TGB Adventure Kit Readme.txt"; DestDir: "{app}\documentation"; Flags: ignoreversion
Source: "documentation\TGB Adventure Kit Changes.txt"; DestDir: "{app}\documentation"; Flags: ignoreversion
Source: "documentation\TGB Adventure Kit EULA.txt"; DestDir: "{app}\documentation"; Flags: ignoreversion
Source: "documentation\TGB Adventure Kit Documentation.url"; DestDir: "{app}\documentation"; Flags: ignoreversion
Source: "documentation\TGB Adventure Kit Private Forum.url"; DestDir: "{app}\documentation"; Flags: ignoreversion
Source: "documentation\TGB Adventure Kit Product Page.url"; DestDir: "{app}\documentation"; Flags: ignoreversion

[Icons]
Name: "{group}\{cm:UninstallProgram,TGB Adventure Kit}"; Filename: "{uninstallexe}"
Name: "{group}\TGB Adventure Kit Demo"; WorkingDir: "{app}\games\AdventureKit"; Filename: "{app}\tgb\gameData\T2DProject\TGBGame.exe"; Parameters: ""
Name: "{group}\TGB Adventure Kit LevelBuilder"; WorkingDir: "{app}\tgb"; Filename: "{app}\tgb\TorqueGameBuilder.exe";
Name: "{group}\TGB Adventure Kit Documentation"; Filename: "{app}\documentation\TGB Adventure Kit Documentation.url"
Name: "{group}\TGB Adventure Kit Product Page"; Filename: "{app}\documentation\TGB Adventure Kit Product Page.url"
Name: "{group}\TGB Adventure Kit Private Forum"; Filename: "{app}\documentation\TGB Adventure Kit Private Forum.url"
Name: "{group}\TGB Adventure Kit Change Log"; Filename: "{app}\documentation\TGB Adventure Kit Changes.txt"
Name: "{group}\TGB Adventure Kit Read Me"; Filename: "{app}\documentation\TGB Adventure Kit Readme.txt"
Name: "{group}\TGB Adventure Kit EULA"; Filename: "{app}\documentation\TGB Adventure Kit EULA.txt"

[Run]
Filename: "{app}\documentation\TGB Adventure Kit Readme.txt"; Description: "Show Release Notes"; Flags: postinstall shellexec skipifsilent waituntilterminated
Filename: "{app}\documentation\TGB Adventure Kit Changes.txt"; Description: "Show Change Log"; Flags: postinstall shellexec skipifsilent waituntilterminated
Filename: "{app}\tgb\gameData\T2DProject\TGBGame.exe"; WorkingDir: "{app}\games\AdventureKit"; Parameters: ""; Description: "Run Adventure Kit Demo"; Flags: postinstall nowait skipifsilent unchecked

[UninstallDelete]

Type: files; Name: "{app}\games\AdventureKit\console.log"
Type: files; Name: "{app}\tgb\resources\AdventureKitArt\*.dso"

; Really annoying... but there isn't a recursive file delete on uninstall
Type: files; Name: "{app}\games\AdventureKit\*.dso";
Type: files; Name: "{app}\games\AdventureKit\common\*.dso";
Type: files; Name: "{app}\games\AdventureKit\common\gameScripts\*.dso";
Type: files; Name: "{app}\games\AdventureKit\common\gameScripts\client\*.dso";
Type: files; Name: "{app}\games\AdventureKit\common\gameScripts\server\*.dso";
Type: files; Name: "{app}\games\AdventureKit\common\gui\*.dso";
Type: files; Name: "{app}\games\AdventureKit\common\preferences\*.dso";
Type: files; Name: "{app}\games\AdventureKit\game\*.dso";
Type: files; Name: "{app}\games\AdventureKit\game\behaviors\*.dso";
Type: files; Name: "{app}\games\AdventureKit\game\data\levels\*.dso";
Type: files; Name: "{app}\games\AdventureKit\game\gameScripts\*.dso";
Type: files; Name: "{app}\games\AdventureKit\game\gui\*.dso";
Type: files; Name: "{app}\games\AdventureKit\game\managed\*.dso";


[Code]
function FindUninstallSubkey( Prefix : String ): String;
var Names: TArrayOfString;
    MSYSPath : String;
    i: Integer;
begin

  if not RegGetSubkeyNames( HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall', Names ) then
    Exit;

  for i := 0 to GetArrayLength( Names )-1 do
  begin
  
    if Pos('MSYS', Names[i]) = 1 then
      if RegQueryStringValue(HKEY_LOCAL_MACHINE,
        'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\' + Names[i],
        'Inno Setup: App Path', MSYSPath) then
      begin
        Result := MSYSPath;
        Exit;
      end;
      
  end;
  
end;

function GetInstallFolder( Default : String ) : String;
  var Folder : String;
      Len : Integer;
      Index : Integer;
begin

  Result := '';
  
  if RegQueryStringValue( HKLM, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\TorqueGameBuilder Pro 1.5.1', 'UninstallString', Folder ) or
     RegQueryStringValue( HKLM, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\TorqueGameBuilder 1.5.1', 'UninstallString', Folder ) then begin
     
     Result := ExtractFileDir( Folder );
     
  end else if RegQueryStringValue( HKLM, 'SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\TorqueGameBuilder.exe', '', Folder ) then begin

     Folder := ExtractFileDir( Folder );
     
     // This is the path to the tgb folder... remove it.
     Len := Length( Folder );
     Index := Pos( '\tgb', Folder );
     if Index = Len-3 then begin
        Result := Copy( Folder, 0, Len - 3 );
     end;
     
  end;
  
end;



