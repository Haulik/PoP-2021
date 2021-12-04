How to create ReadNWrite.dll
First locate src folder using terminal/cmd
Type:
fsharpc -a ReadNWrite.fs

How to compile and run cat.fsx and tac.fsx
First locate src folder using terminal/cmd
Type to compile:
fsharpc -r ReadNWrite.dll cat.fsx
Type to compile: 
fsharpc -r ReadNWrite.dll cat.fsx
To run cat and tac type the following:
mono cat.exe ARGUMENTS HERE
mono tac.exe ARGUMENTS HERE
An example of how to run cat and tac
mono cat a.txt b.txt
mono tac a.txt b.txt

How to compile and run countLinks.fsx
First locate src folder using terminal/cmd
Type:
fsharpc countLinks.fsx
How to run countLinks
Type:
mono countLinks.exe ARGUMENTS HERE
An example of how to run countLinks
mono countLinks.exe https://erdetfredag.dk/