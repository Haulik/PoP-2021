open Rotate
let game (n:uint) : unit =
    let rec gameloop (b:Board) : Board =
        printfn "%A" (board2Str b)
        if solved b then b
        else 
            printfn "Enter position of rotation:"
            let p = (int(System.Console.ReadLine())) in gameloop (rotate b p)
    printfn "Solved! %A" (board2Str (gameloop ((scramble (create n) 10u)))) //Scrambles the board 10 times
game 3u //Edit this to change the boardsize