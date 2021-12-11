How to create simulate.dll
First locate src folder using terminal/cmd
Type:
fsharpc -a simulate.fs

How to compile and run testSimulate.fsx
First locate src folder using terminal/cmd
Type to compile:
fsharpc -r simulate.dll testSimulate.fsx
To run testSimulate type the following:
mono testSimulate.exe 
