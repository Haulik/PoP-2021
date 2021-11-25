How to compile and create rotate.dll library
First locate the folder src using terminal/cmd
Then type the following:
fsharpc -a rotate.fsi rotate.fs

NEEDS rotate.dll TO RUN
How to compile and run blackboxtest.fsx
First locate the folder src using terminal/cmd
Then type the following:
fsharpc -r rotate.dll blackboxtest.fsx && mono blackboxtest.exe

NEEDS rotate.dll TO RUN
How to compile and run whiteboxtest.fsx
First locate the folder src using terminal/cmd
Then type the following:
fsharpc -r rotate.dll whiteboxtest.fsx && mono whiteboxtest.exe

NEEDS rotate.dll TO RUN
How to compile and run game.fsx
First locate the folder src using terminal/cmd
Then type the following:
fsharpc -r rotate.dll game.fsx && mono game.exe