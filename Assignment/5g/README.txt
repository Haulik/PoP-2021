How to compile and run 5g0.fsx and 5g1.fsx
Locate the folder /src using the terminal/cmd
Type "fsharpc 5g0.fsx && mono 5g0.exe" in the terminal/cmd
Type "fsharpc 5g1.fsx && mono 5g1.exe" in the terminal/cmd

5g0 (e)
5g0.fsx Whitebox test results
White-box testing of transposeLstLst llst
llst: [[1; 2; 3]; [4; 5; 6]; [4; 5]]     branch: 1    Result: [[0]; [0]]                        Expected: [[0]; [0]]                        |passed: true 
llst: [[]]                               branch: 1    Result: [[0]; [0]]                        Expected: [[0]; [0]]                        |passed: true 
llst: [[1; 2; 3]; [4; 5; 6]]             branch: 2    Result: [[1; 4]; [2; 5]; [3; 6]]          Expected: [[1;4]; [2;5]; [3;6]]             |passed: true 
llst: [[1; 2; 3]]                        branch: 2    Result: [[1]; [2]; [3]]                   Expected: [[1]; [2]; [3]]                   |passed: true 
llst: [[1; 2; 3]; [4; 5; 6]; [4; 5; 6]]  branch: 2    Result: [[1; 4; 4]; [2; 5; 5]; [3; 6; 6]] Expected: [[1; 4; 4]; [2; 5; 5]; [3; 6; 6]] |passed: true 

5g1 (b)
5g1.fsx Whitebox test results
White-box testing of transposeArr arr
InputVarible: TableArray       InputVaribleRow(s): 1      InputVaribleColumn(s): 5      Branch: 1      |passed: true
InputVarible: TableArray2      InputVaribleRow(s): 2      InputVaribleColumn(s): 5      Branch: 1      |passed: true
InputVarible: TableArray3      InputVaribleRow(s): 3      InputVaribleColumn(s): 5      Branch: 1      |passed: true
InputVarible: TableArray4      InputVaribleRow(s): 5      InputVaribleColumn(s): 1      Branch: 1      |passed: true

5g1 (c)
transposeLstLst (5g0.fsx) uses a for loop to run through the list of lists and
then uses the function firstColumn to assign it to a mutable list, 
then it has to remove the first column using another function called dropFirstcolumn. 
This takes time as it has to do it for the entire list

transposeArr (5g1.fsx) simply takes a 2D Array of any given length and transposes it by using Array2D's module function .init
to initiate the array transposed

5g1 (d)
Array is usually best for imperative programming. This is because in imperative programming the focus is solving a problem, as a list of statements that affects states. This means an arrays, which is mutable by default, is a more favorable in imperative programming due to how easy it is to update values in an array. 
In list however you cannot update elements, meaning that you will have to create a new list every time you need to update elements. List are therefore immutable, and that is not efficient in imperative programming.

In contrast to imperative programming, functional programming on the other hand favor immutable values. Mutable variables is known to be the root of many bugs and problems, they lead to implicit dependencies between different parts of your code, which can easily create many different problems in a programs. Immutable variables have a less complexity, and they can be used with many functional techniques, as using function as values. This is one of the reason List, which is immutable, is better suited for functional programming.