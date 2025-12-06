@echo off
echo. > ProjectX_AllFiles.cs
echo // ===== ProjectX/ProjectX.csproj ===== >> ProjectX_AllFiles.cs
type ProjectX\ProjectX.csproj >> ProjectX_AllFiles.cs
echo. >> ProjectX_AllFiles.cs
echo // ===== SimpleGuiApp/SimpleGuiApp.csproj ===== >> ProjectX_AllFiles.cs
type SimpleGuiApp\SimpleGuiApp.csproj >> ProjectX_AllFiles.cs
echo. >> ProjectX_AllFiles.cs
echo // ===== TODO.md ===== >> ProjectX_AllFiles.cs
type TODO.md >> ProjectX_AllFiles.cs
echo. >> ProjectX_AllFiles.cs
for /r ProjectX %%i in (*.cs) do (
  echo %%i | findstr /i /c:"\bin\" >nul
  if errorlevel 1 (
    echo %%i | findstr /i /c:"\obj\" >nul
    if errorlevel 1 (
      echo // ===== ProjectX/%%~pnxi ===== >> ProjectX_AllFiles.cs
      type "%%i" >> ProjectX_AllFiles.cs
      echo. >> ProjectX_AllFiles.cs
    )
  )
)
for /r SimpleGuiApp %%i in (*.cs) do (
  echo %%i | findstr /i /c:"\bin\" >nul
  if errorlevel 1 (
    echo %%i | findstr /i /c:"\obj\" >nul
    if errorlevel 1 (
      echo // ===== SimpleGuiApp/%%~pnxi ===== >> ProjectX_AllFiles.cs
      type "%%i" >> ProjectX_AllFiles.cs
      echo. >> ProjectX_AllFiles.cs
    )
  )
