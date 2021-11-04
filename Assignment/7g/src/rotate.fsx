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
        | p when p+1 % length = 0 -> false
        | p when p+1 >= length * length - length -> false
        | p when p+1 > length * length -> false
        | _ -> true

let rotate (board:Board) (p:Position) : Board =
    let length = int(sqrt(float board.Length))
    let rotateHelper (i:int) : int =
        match i with 
            | n when n=p -> p + length 
            | n when n=p + 1 -> p
            | n when n = p + length + 1 -> p + 1
            | n when n = p + length -> p + length + 1
            | _ -> 0
    let reslist = List.init (board.Length) (fun i -> if i = p || i = (p + 1) || i = (p + length) || i = (p + length + 1) then board.[(rotateHelper i)] else board.[i])
    reslist

let scramble (b:Board) (m:uint) : Board =   
    let rnd = System.Random ()
    let boardlength = b.Length
    let rec scrambleHelper (b:Board) (m:int) (counter:int) : Board =
        if counter >= m then 
            b
        else
            let n = (rnd.Next boardlength)
            if (validRotate b n) then scrambleHelper (rotate b n) m (counter+1)
            else scrambleHelper b m counter
    scrambleHelper b (int(m)) 0

let solved (b:Board) : bool =   
    List.sort b = b

//printfn "%A" (board2Str(scramble (create 5u) 100u))
printfn "%A" (solved(create 5u))