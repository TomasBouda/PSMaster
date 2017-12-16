# PSMaster [![Build status](https://ci.appveyor.com/api/projects/status/v2qi22fydl1eht7a/branch/master?svg=true)](https://ci.appveyor.com/project/TomasBouda/psmaster/branch/master)
> Add UI to your powershell scripts

Windows utility that allows you to collect and easily run powershell scripts.

<img src="https://github.com/TomasBouda/PSMaster/blob/master/images/psmaster.PNG?raw=true" height="400">

## Requirements
You need to run following powershell command in order to use this library
```ps1
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted -Force
```

## How it works
* You write powershell script(make sense:satisfied:) and save it.
* Then drag and drop your *.ps1 file into PSMaster - icon will be created and editor window will pop up.
* You can now predefine you script parameter values or just tick "Prompt before run?" and this window will pop up before the script is being run.
* Now you can double click script icon or right click the icon and select "Run".
* PSMaster will run the script and show output in blue console down bellow. 
* And that's it :relaxed:
