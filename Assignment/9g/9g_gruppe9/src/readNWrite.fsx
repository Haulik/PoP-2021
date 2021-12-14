//module ReadNWrite

let readFile (filename: string) : string option = 
    try
        let reader = System.IO.File.OpenText filename
        let mutable input = ""
        while not (reader.EndOfStream) do
            input <- input + (char (reader.Read())).ToString()
        reader.Close()
        if input = "" then
            raise(System.ArgumentException())
        Some (input)
    with
        | _-> raise(System.ArgumentException("Some None"))

let cat (filenames: string list) : string option =
    try
        let results = List.choose (fun elem ->
            match elem with
            | elem -> readFile elem) filenames
        Some (System.String.Concat(results))
    with 
        | _ -> None

let tac (filenames: string list) : string option =
    try
        let reverse (str:string) : string =
            System.String(Array.rev (str.ToCharArray()))
        let concat = ((cat filenames) |> Option.get)
        let arr = concat.Split("\\n") |> Array.toList
        let arrWS = List.filter (fun x -> x <> "") arr
        let reverselist = (List.map (fun elm -> reverse elm + "\\n" ) arrWS) |> List.rev
        Some (System.String.Concat(reverselist))
    with 
        | _ -> None

printfn "%A" (cat ["";""])
printfn "%A" (tac ["";""])
printfn "%A" (readFile "")