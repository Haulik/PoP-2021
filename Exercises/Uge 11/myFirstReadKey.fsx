open System

let main : unit =
    let mutable Break = true
    while Break do
        let input = Console.ReadKey()
        match input with
            | key when key.Key = ConsoleKey.A -> printfn "left"
            | key when key.Key = ConsoleKey.W -> printfn "Up"
            | key when key.Key = ConsoleKey.S -> printfn "Down"
            | key when key.Key = ConsoleKey.D -> printfn "Right"
            | key when key.Key = ConsoleKey.Q && key.Modifiers = ConsoleModifiers.Shift -> Break <- false
            | _ -> ()
    exit 0
            

