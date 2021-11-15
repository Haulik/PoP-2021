open Rotate

printfn "Enter size of the game:"
let GameSize =  (uint32(System.Console.ReadLine())) 
printfn "How many scrambles?:"
let Scrambles = (uint32(System.Console.ReadLine()))

let game (n:uint) : unit =
    let rec gameloop (b:Board) : Board =
        printfn "\nThe board: \n %A" (board2Str b)
        if solved b then b
        else 
            printfn "Enter position of rotation:"
            let p = (int(System.Console.ReadLine())-1) in gameloop (rotate b p)
    printfn "Solved! %A" (board2Str (gameloop ((scramble (create n) Scrambles)))) //Scrambles the board 10 times
game GameSize //Edit this to change the boardsize