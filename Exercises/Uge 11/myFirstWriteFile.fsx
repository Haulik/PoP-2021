open System.IO
let main (filename:string) : unit =
    try
        use file = File.CreateText filename
        for i in ['a'..'z'] do
            file.Write i
        file.Close()
    with 
        | _ -> exit 1
    exit 0

let filenameDialogue (question:string) : string =
    printfn "Hi human, here is your filename %s" question    
    question

let Readfile (reader:System.IO.StreamReader) =
    while not (reader.EndOfStream) do
        let input = reader.Read()
        printf "%c" (char input)
    reader.Close()


let Openfile (filename:string) : unit =
    try 
        let reader = System.IO.File.OpenText filename 
        Readfile reader 
    with
        | _ -> exit 1
    exit 0

//main "myFirstReadfile.fsx"


let printFile : unit =
    try 
        printfn "Plz give a filname: "
        let filename = System.Console.ReadLine()
        Openfile filename
    with 
        | _ -> exit 1
    exit 0

//main "newFile.txt" 

//printfn "%s" (filenameDialogue (System.Console.ReadLine()))

printFile

 