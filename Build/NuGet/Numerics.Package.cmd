@echo off
echo Creating NuGet package

echo.
echo Cleaning convention based working directory...
rmdir Working\build /s /q
rmdir Working\content /s /q
rmdir Working\lib /s /q
rmdir Working\tools /s /q

echo.
echo Creating convention based working directory...
mkdir Working\build
mkdir Working\content
mkdir Working\lib
mkdir Working\tools

echo.
echo Copying lib for net35...
xcopy ..\..\Source\Numerics.Net35\bin\Release\* Working\lib\net35\* /s /e /y

echo.
echo Copying lib for net40...
xcopy ..\..\Source\Numerics.Net40\bin\Release\* Working\lib\net40\* /s /e /y

echo.
echo Copying lib for net45...
xcopy ..\..\Source\Numerics.Net45\bin\Release\* Working\lib\net45\* /s /e /y

echo.
echo Copying lib for net46...
xcopy ..\..\Source\Numerics.Net46\bin\Release\* Working\lib\net46\* /s /e /y

echo.
echo Copying lib for net461...
xcopy ..\..\Source\Numerics.Net461\bin\Release\* Working\lib\net461\* /s /e /y

echo.
echo Packaging...
..\..\Tools\NuGet\nuget.exe pack Working\Numerics.nuspec

echo.
echo Moving package...
move Numerics.1.0.0.nupkg Packages

echo.
echo Pushing package...
..\..\Tools\NuGet\nuget.exe push Packages\Numerics.1.0.0.nupkg %NuGetApiKey% -Source https://www.nuget.org/api/v2/package

pause