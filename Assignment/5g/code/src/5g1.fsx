///<summary>Takes an Array2D and transposes it</summary>
///<param name="arr">An Array2D</param>
///<returns>An Array2D transposed</returns>
let transposeArr (arr:'a [,]) : 'a [,] =
    Array2D.init (Array2D.length2 arr) (Array2D.length1 arr) (fun i j -> arr.[j,i])

// Whitebox test of transposeArr
(* let TableArray = (array2D [ [0; 10; 20; 30; 40] ])
let TableArray2 = (array2D [ [0; 10; 20; 30; 40]; [2; 12; 22; 32; 42] ])
let TableArray3 = (array2D [ [0; 10; 20; 30; 40]; [1; 11; 21; 31; 41]; [2; 12; 22; 32; 42] ])
let TableArray4 = (array2D [ [0]; [1]; [2]; [3]; [4] ])
printfn "White-box testing of transposeArr arr"
printfn "InputVarible: TableArray       InputVaribleRow(s): 1      InputVaribleColumn(s): 5      Branch: 1      |passed: %b" (transposeArr TableArray = (array2D [ [0]; [10]; [20]; [30]; [40] ]))
printfn "InputVarible: TableArray2      InputVaribleRow(s): 2      InputVaribleColumn(s): 5      Branch: 1      |passed: %b" (transposeArr TableArray2 = (array2D [ [0; 2]; [10; 12]; [20; 22]; [30; 32]; [40; 42]]))
printfn "InputVarible: TableArray3      InputVaribleRow(s): 3      InputVaribleColumn(s): 5      Branch: 1      |passed: %b" (transposeArr TableArray3 = (array2D [ [0; 1; 2]; [10; 11; 12]; [20; 21; 22]; [30; 31; 32]; [40; 41; 42]]))
printfn "InputVarible: TableArray4      InputVaribleRow(s): 5      InputVaribleColumn(s): 1      Branch: 1      |passed: %b" (transposeArr TableArray4 = (array2D [ [0; 1; 2; 3; 4] ]))
 *)