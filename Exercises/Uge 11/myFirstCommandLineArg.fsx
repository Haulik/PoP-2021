[<EntryPoint>]
let myFirstCommandLineArg (args: string array) : int =
    for i=0 to (args.Length-1) do
        printfn "%A" args.[i]
    0