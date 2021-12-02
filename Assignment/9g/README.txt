How to create ReadNWrite.dll
First locate src folder using terminal/cmd
Type:
fsharpc -a ReadNWrite.fs

How to compile and run cat.fsx and tac.fsx
First locate src folder using terminal/cmd
Type to compile and run cat:
fsharpc -r ReadNWrite.dll cat.fsx && mono cat.exe ARGUMENTS HERE
Type to compile and run tac: 
fsharpc -r ReadNWrite.dll cat.fsx && mono tac.exe ARGUMENTS HERE

How to compile and run countLinks.fsx
First locate src folder using terminal/cmd
Type:
fsharpc countLinks.fsx && mono countLinks.exe