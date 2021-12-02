module ReadNWrite

(* let readFile (filename: string) : string option =
    try
        let reader = System.IO.File.OpenText filename
        let mutable input = ""
        while not (reader.EndOfStream) do
            input <- input + (char (reader.Read())).ToString()
        reader.Close()
        Some (input)
    with
        | _ -> None *)

let readFile (filename: string) : string option = 
    try     
        let reader = System.IO.File.OpenText filename
        let output = reader.ReadToEnd()
        reader.Close()
        Some output
    with    
        | _ -> None

let cat (filenames: string list) : string option =
    try
        let mutable output = ""
        for file in filenames do    
            output <- output + (readFile file |> Option.get)
        Some output
    with
        | _ -> None

let tac (filenames: string list) : string option =
    try
        let mutable output = ""
        for file in filenames do    
            output <- output + (readFile file |> Option.get)
        let mutable words = (output.Split(System.Environment.NewLine)) |> Array.toList
        words <- List.map (Array.rev (words.ToCharArray())) (List.ofArray words)
        words <- List.map (fun x -> x + "\\n") words
        //output <- Array.rev (Array.rev (output.ToCharArray()))
        //output <- System.String(Array.rev (output.ToCharArray()))
        //output <- output.Replace("n\\","\\n")
        Some words
    with
        | _ -> None

printfn "%A" (tac ["a.txt";"b.txt"])