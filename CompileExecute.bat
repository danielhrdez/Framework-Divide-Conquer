@echo off
setlocal EnableDelayedExpansion
@set files=
for /r %%f in (*.cs) do @set files=!files! %%f
csc %files%
DivideConquerMain.exe %1 %2
del DivideConquerMain.exe
