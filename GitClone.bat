@echo off 
set ret=N

echo ------------------------------
echo Common.sln git clone batch
echo ------------------------------
echo.
echo Please read Readme.md.
echo.
echo This repository's solution reference Common repository.
echo (Common repository : https://github.com/mamori017/Common.git)
echo.
echo This batch file clone Common repository on parent directory.
echo.

choice /m "Start clone?"
if errorlevel 2 goto end
if errorlevel 1 goto clone

:end
echo Clone cancel.
pause
exit

:clone
SET dir="../Common"

if exist %dir% goto clonecancel
if not exist %dir% goto clonestart

:clonecancel
echo Clone cancel. ../Common directory already exist and is not an empty directory.
pause
exit

:clonestart
echo Clone start.
git clone https://github.com/mamori017/Common.git ../Common
pause
exit


