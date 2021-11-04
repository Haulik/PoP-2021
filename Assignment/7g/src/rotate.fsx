//module Rotate

type Board = char list
type Position = int

let listabc = ['a'..'z']

let create (n:uint) : Board =
    listabc.[0 .. (int(n)*int(n))-1]

let rec board2Strhelper (b:Board) (pos:int) (n:int) : string =
    match b with
        | [] -> ""
        | [x] -> x.ToString() + "\n\n"
        | x :: ys when pos % n = 0 -> "\n" + x.ToString() + (board2Strhelper ys (pos-1) n)
        | x :: ys -> x.ToString() + (board2Strhelper ys (pos-1) n)

let board2Str (b:Board) : string =
    let length = int(sqrt(float b.Length))
    board2Strhelper b length length

let validRotate (b:Board) (p:Position) : bool =
    let length = int(sqrt(float b.Length))
    match p with    
        | p when p % length = 0 -> false
        | p when p >= length * length - length -> false
        | p when p > length * length -> false
        | _ -> true

let rotate (board:Board) (p:Position) : Board =
    let length = int(sqrt(float board.Length))
    let (a,b,c,d) = (board.[p],board.[p+1],board.[p+length],board.[p+length+1])
    printfn "%A" (a,b,c,d)
    board
    //let new_b = b.[0..(pos-1)] @ c @ a @ b.[(pos+2)..(pos+length)] @ d @ b @ b.[(pos+length+1)..]


let rec scramble (b:Board) (m:uint) : Board =
    let rnd = System.Random  ()
    let boardlenght 




let b1 = (board2Str (create 3u))
printfn "%A" (rotate2 (create 3u))