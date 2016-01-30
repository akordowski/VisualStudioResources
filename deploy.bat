@ECHO OFF
CLS

IF NOT DEFINED LCID GOTO WARNING

SETLOCAL ENABLEEXTENSIONS

:: ----------------------------------------------------------------------------------------------------
:: Variables
SET VersionVisualStudio=2015
SET DirDocs=%HOMEDRIVE%%HOMEPATH%\Documents
SET DirDocsVisualStudio=%DirDocs%\Visual Studio %VersionVisualStudio%

SET DirTargetItemTemplates=%DirDocsVisualStudio%\Templates\ItemTemplates\Visual C#\ItemTemplates
SET DirTargetProjectTemplates=%DirDocsVisualStudio%\Templates\ProjectTemplates\Visual C#
SET DirTargetSnippets=%DirDocsVisualStudio%\Code Snippets\Visual C#\My Code Snippets

:: ----------------------------------------------------------------------------------------------------
:: ItemTemplates
SET FileSourceItemTemplate=%%B.zip
SET DirSourceItemTemplate=ItemTemplates\%LCID%\%%A\%%B\bin\Release\ItemTemplates\CSharp\1033

SET CmdCopyItemTemplate=XCOPY "%DirSourceItemTemplate%\%FileSourceItemTemplate%" "%DirTargetItemTemplates%\%%A\" /I /Y
SET CmdLoopItemTemplateProjects=FOR /F "tokens=*" %%B IN ('dir /b ItemTemplates\%LCID%\%%A') DO %CmdCopyItemTemplate%
SET CmdLoopItemTtemplates=FOR /F "tokens=*" %%A IN ('dir /b ItemTemplates\%LCID%\') DO %CmdLoopItemTemplateProjects%
SET CmdCopyItemTemplates=%CmdLoopItemTtemplates%

:: ----------------------------------------------------------------------------------------------------
:: Snippets
SET FileSourceSnippet=%%A
SET DirSourceSnippet=Snippets\%LCID%

SET CmdCopySnippet=XCOPY "%DirSourceSnippet%\%FileSourceSnippet%" "%DirTargetSnippets%\" /I /Y
SET CmdLoopSnippets=FOR /F "tokens=*" %%A IN ('dir /b %DirSourceSnippet%\') DO %CmdCopySnippet%
SET CmdCopySnippets=%CmdLoopSnippets%

:: ----------------------------------------------------------------------------------------------------
:: Execute Commands
ECHO Copy Item Templates
ECHO.
%CmdCopyItemTemplates%

ECHO.
ECHO Copy Snippets
ECHO.
%CmdCopySnippets%

GOTO END

:: ----------------------------------------------------------------------------------------------------
:: GoTo Labels
:WARNING
ECHO You cannot execute this script directly.
ECHO Please execute the 'deploy_[LCID].bat' script.

:END
PAUSE