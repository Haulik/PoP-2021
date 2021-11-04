//module Rotate

type Board = char list

let listabc = ['a'..'z']

let create (n:uint) : Board =
    listabc.[0 .. (int(n)*int(n))-1]
    

let rec board2Str (b:Board) : string =
    let length = int(sqrt(float b.Length)) 
    printfn "%d" length
    match b with
        |[] -> ""
        |[x] -> x.ToString()
        | x :: ys -> x.ToString() + board2Str ys

//sdf





printfn "%A" (board2Str (create 3u))