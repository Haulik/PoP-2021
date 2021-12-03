///<summary>Opens the file 'filename' and reads the entire contents as string. </summary>
///<param name="filename">The name/directory of the file to be opened, as a string</param>
///<returns>A string option, containing the contents of the document if it succeeds, or None if an exception is raised.</returns>
let readFile (filename:string) : string option =
    try
        let reader = System.IO.File.OpenText filename
        let mutable input = ""
        while not (reader.EndOfStream) do
            input <- input + (char (reader.Read())).ToString()
        reader.Close()
        Some (input)
    with
        | _-> None

///<summary>Reads the content of multiple files and concatenates them to one string</summary>
///<param name="filenames">A string list of the filenames that are read</param>
///<returns>A string option containing the concatenated string, or None if an exception is raised.</returns>
let cat (filenames:string list) : string option =
    try
        let results = List.choose (fun elem ->
            match elem with
            | elem -> readFile elem) filenames
        //Some (results |> List.fold (fun r s -> r + s) "")
        Some (System.String.Concat(results))
    with 
        | _ -> None
     
///<summary>Reverses the order of the lines in the given files, and reverses the order of the characters on every line</summary>
///<param name="filenames">A string list of the filenames that are read</param>
///<returns>The reversed string as a string option, or None if an exception is raised.</returns>
let tac (filenames:string list) : string option =
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
