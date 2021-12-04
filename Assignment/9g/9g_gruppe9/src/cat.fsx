open ReadNWrite

[<EntryPoint>]
let main (args: string array) : int =
    try
        let lst = args |> Array.toList
        printfn "%s" (cat lst |> Option.get)
        0
    with
        | _ -> 1