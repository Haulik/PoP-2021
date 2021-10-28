///<summary>Evaluates if a list lists is a legal non-empty list</summary>
///<param name="llst">A list of lists</param>
///<returns>True if there is at least one element, and all lists in the outer list has equal length. Otherwise false</returns>
let isTable (llst:'a list list) : bool =
    let mutable oneNumber = false 
    let mutable equalLength = true 
    for i = 0 to llst.Length - 1 do
        if llst.[0].Length <> llst.[i].Length then
            equalLength <- false
        if (llst.[i].IsEmpty <> true ) then
            oneNumber <- true
    (oneNumber && equalLength)

///<summary>Takes the first column in a list of lists</summary>
///<param name="llst">A list of lists</param>
///<returns>A list of the first column in a list of lists i.e the first column in a matrix</returns>
let fistColumn (llst:'a list list) : 'a list =
    List.map (fun (x:'a list) -> x.Head) llst

///<summary>Takes the first column in a list of lists and removes them</summary>
///<param name="llst">A list of lists</param>
///<returns>A list with the first column in a list of lists removed i.e. the first column in a matrix removed</returns>
let dropFirstColumn (llst:'a list list) : 'a list list =
    List.map List.tail llst

///<summary>Takes a list and lists each column in a list of lists</summary>
///<param name="llst">A list of lists</param>
///<returns>A list of each column in a list</returns>
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

// Whitebox test code
(* let NotATable = [[1;2;3]; [4; 5;6]; [4; 5]]
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
*)