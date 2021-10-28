
let isTable (llst:'a list list) : bool =
    let mutable oneNumber = false 
    let mutable equalLength = true 
    for i = 0 to llst.Length - 1 do
        if llst.[0].Length <> llst.[i].Length then
            equalLength <- false
        if (llst.[i].IsEmpty <> true ) then
            oneNumber <- true
    (oneNumber && equalLength)

let fistColumn (llst:'a list list) : 'a list =
    List.map (fun (x:'a list) -> x.Head) llst

let dropFirstColumn (llst:'a list list) : 'a list list =
    List.map List.tail llst

let transposeLstLst (llst: 'a list list) : 'a list list = 
    if isTable llst = false then
        [[0];[0]]
    else
        let mutable lst = llst
        let mutable result = [List.map List.head lst]
        for i = 1 to lst.[0].Length - 1 do
            lst <- dropFirstColumn lst
            result <- List.append result [List.map List.head lst]
        result

let transposeArr (arr:'a [,]) : 'a [,] =
    Array2D.init (Array2D.length2 arr) (Array2D.length1 arr) (fun i j -> arr.[j,i] )



let NotATable = [[1;2;3]; [4; 5;6]; [4; 5]]
let NotATable2 = [[]]
let Table = [[1;2;3]; [4; 5;6]]
let Table2 = [[1;2;3]]
let Table3 = [[1;2;3]; [4; 5;6]; [4; 5;6]]
printfn "White-box testing of transposeLstLst llst"
printfn "llst: %A     branch: 1    Result: %A                        Expected: [[0]; [0]]                        |passed: %b " NotATable (transposeLstLst NotATable) (transposeLstLst NotATable = [[0];[0]])
printfn "llst: %A                               branch: 1    Result: %A                        Expected: [[0]; [0]]                        |passed: %b " NotATable2 (transposeLstLst NotATable2) (transposeLstLst NotATable2 = [[0];[0]])
printfn "llst: %A             branch: 2    Result: %A          Expected: [[1;4]; [2;5]; [3;6]]             |passed: %b " Table (transposeLstLst Table) (transposeLstLst Table = [[1;4];[2;5];[3;6]])
printfn "llst: %A                        branch: 2    Result: %A                   Expected: [[1]; [2]; [3]]                   |passed: %b " Table2 (transposeLstLst Table2) (transposeLstLst Table2 = [[1]; [2]; [3]])
printfn "llst: %A  branch: 2    Result: %A Expected: [[1; 4; 4]; [2; 5; 5]; [3; 6; 6]] |passed: %b " Table3 (transposeLstLst Table3) (transposeLstLst Table3 = [[1; 4; 4]; [2; 5; 5]; [3; 6; 6]])
printfn ""


let TableArray = (array2D [ [0; 10; 20; 30; 40] ])
let TableArray2 = (array2D [ [0; 10; 20; 30; 40]; [2; 12; 22; 32; 42] ])
let TableArray3 = (array2D [ [0; 10; 20; 30; 40]; [1; 11; 21; 31; 41]; [2; 12; 22; 32; 42] ])
let TableArray4 = (array2D [ [0]; [1]; [2]; [3]; [4] ])
printfn "White-box testing of transposeArr arr"
printfn "InputVarible: TableArray       InputVaribleRow(s): 1      InputVaribleColumn(s): 5      Branch: 1      |passed: %b" (transposeArr TableArray = (array2D [ [0]; [10]; [20]; [30]; [40] ]))
printfn "InputVarible: TableArray2      InputVaribleRow(s): 2      InputVaribleColumn(s): 5      Branch: 1      |passed: %b" (transposeArr TableArray2 = (array2D [ [0; 2]; [10; 12]; [20; 22]; [30; 32]; [40; 42]]))
printfn "InputVarible: TableArray3      InputVaribleRow(s): 3      InputVaribleColumn(s): 5      Branch: 1      |passed: %b" (transposeArr TableArray3 = (array2D [ [0; 1; 2]; [10; 11; 12]; [20; 21; 22]; [30; 31; 32]; [40; 41; 42]]))
printfn "InputVarible: TableArray3      InputVaribleRow(s): 5      InputVaribleColumn(s): 1      Branch: 1      |passed: %b" (transposeArr TableArray4 = (array2D [ [0; 1; 2; 3; 4] ]))

    
        



//printfn "%A" (isTable  [[1;2;3]; [4; 5;6]; [4; 5;6]] )
//printfn "%A" (transposeLstLst  [[1;2;3]; [4; 5;6]; [4; 5]] )
//printfn "%A" (dropFirstColumn  [[1;2;3]; [4; 5; 6]] )
//printfn "%A" (transposeArr (Array2D.init 3 5 ( fun i j -> i + 10 * j)))
    


