How to create Robots.dll
First locate src folder using terminal/cmd
Type:
fsharpc -a robots.fs

How to compile and run robots-game.fsx
First locate src folder using terminal/cmd
Type to compile:
fsharpc -r robots.dll robots-game.fsx
mono robots-game.exe ARGUMENTS HERE

An example of how to run robots-game.exe
mono robots-game.exe 4 7 AA BB CC