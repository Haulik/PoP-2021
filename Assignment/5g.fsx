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


//let transposeLstLst (llst:'a list list) : 'a list list =


let transposeLstLst (llst: 'a list list) : 'a list list = 
   let mutable lst = llst
   let mutable result = [List.map List.head lst]
   for i = 0 to lst.Length - 1 do
      lst <- dropFirstColumn lst
      result <- List.append result [List.map List.head lst]
   result


//let help (a:int) (b:int) : 'a = ..



//let transposeArr (arr:'a [,]) : 'a [,] =
//    let y = Array2D.length1 arr
 //   let x = Array2D.length2 arr
  //  Array2D.init y x  arr.[2 ,3]
    
        





printfn "%A" (isTable  [[1;2;3]; [4; 5;6]; [4; 5;6]] )
//printfn "%A" (transposeLstLst  [[1;2;3]; [4; 5;6];] )
//printfn "%A" (Array2D.init 3 4 ( fun i j -> i + 10 * j ) )
//printfn "%A" (dropFirstColumn  [[1;2;3]; [4; 5; 6]] )