//module Rotate

type Board = char list

let listabc = ['a'..'z']

let create (n:uint) : Board =
    listabc.[0 .. (int(n)*int(n))-1]
    
let rec helper (b:Board) (pos:int) (n:int) : string =
        match b with
            |[] -> ""
            |[x] -> x.ToString() + "\n\n"
            | x :: ys when pos % n = 0 -> "\n" + x.ToString() + (helper ys (pos-1) n)
            | x :: ys -> x.ToString() + (helper ys (pos-1) n)

let board2Str (b:Board) : string =
    let length = int(sqrt(float b.Length)) 
    helper b length length
    //printfn "%d" length

//let validRotation (b:Board) (p:Position) : bool =

 






printfn "%A" (board2Str (create 3u))