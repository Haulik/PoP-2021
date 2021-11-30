open System.IO

let printFile (reader:System.IO.StreamReader) =
    while not (reader.EndOfStream) do
        let input = reader.Read()
        printf "%c" (char input)
    reader.Close()


let main (filename:string) : unit =
    try 
        let reader = System.IO.File.OpenText filename 
        printFile reader 
    with
        | _ -> exit 1
    exit 0

main "myFirstReadfile.fsx"