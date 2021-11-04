//module Rotate

type Board = char list
type Position = int

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

let validRotation (b:Board) (p:Position) : bool =
    let length = int(sqrt(float b.Length)) 
    match p with
    | p when p % length = 0 -> false
    | p when p >= length * length - length -> false
    | p when p > length * length -> false
    | _ -> true


let rotate (b:Board) (p:Position) : Board =
    let length = int(sqrt(float b.Length)) 
    let (a,b,c,d) = (b.[p], b.[p+1] ,b.[p+length] ,b.[p+length+1])


//sdf





printfn "%A" (board2Str (create 3u))