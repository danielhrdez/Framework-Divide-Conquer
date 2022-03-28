@echo off
setlocal EnableDelayedExpansion
@set files=
for /r %%f in (*.cs) do @set files=!files! %%f
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe %files%
MainProgram.exe %1 %2
del MainProgram.exe
