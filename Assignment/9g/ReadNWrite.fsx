let readFile (filename:string) : string option =
    try
        let reader = System.IO.File.OpenText filename
        let mutable input = ""
        while not (reader.EndOfStream) do
            input <- input + (char (reader.Read())).ToString()
            //printf "%c" (char input)
        reader.Close()
        //let 2char = (char input)
        Some (input)
    with
        | _-> None


let cat (filenames:string list) : string option =
    let mutable cat = ""
    for i in filenames do
        cat <- cat + (readFile i |> Option.get)
    Some cat 


let tac (filenames:string list) : string option =
    let mutable reverse = ""
    let mutable tac = ""
    for i in filenames do
        tac <- tac + (readFile i |> Option.get)
    tac <- System.String(Array.rev (tac.ToCharArray()))
   // tac <- System.String(Array.rev (tac.ToCharArray()))
    Some tac

printfn "%A" (tac ["a.txt";"b.txt"])