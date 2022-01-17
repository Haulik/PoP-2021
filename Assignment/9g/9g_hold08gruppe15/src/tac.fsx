open ReadNWrite

///<summary>Calls the tac-function from the ReadNWrite library with input given in the commandline</summary>
///<param name="args">The input from the commandline, as a string array</param>
///<returns>0 if no exceptions are raised, 1 otherwise</returns>
[<EntryPoint>]
let main (args: string array) : int =
    try
        let lst = args |> Array.toList
        printfn "%s" (tac lst |> Option.get)
        0
    with
        | _ -> 1
