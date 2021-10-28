///<summary>Calculates the sum of n</summary>
///<returns>returns an int of the calculated sum, n, such that n > 0</returns>
///<param name="n">value : int</param>
let sum (n:int) : int = 
    if n < 1 then  
        0
    else 
        let mutable x = 0
        let mutable counter = 0
        while x < n do
            let mutable s = 1 + x
            counter <- counter + s
            x <- x + 1
        counter

///<summary>Calculates the sum of a specified number n</summary>
///<returns>returns an int of the calculated sum, n, such that n >= 0</returns>
///<param name="n">value : int</param>
let simpleSum (n:int) : int = 
    if n < 0 then
        0
    else
        // Instead of calculating by adding 1+2+...+n, we can use the expression n(n+1)/2 to calculate the sum of any number
        (n * (n + 1)) / 2

///<summary> Function to find max number n for function sum</summary>
///<returns> returns the max number of n</returns>
let sumMaxN () : int = 
    let mutable sum = 0
    let mutable counter = 0
    while sum >= 0 do
        let mutable s = 1 + counter
        sum <- sum + s
        counter <- counter + 1
    counter - 1

///<summary> Function to find max number of n for function simpleSum</summary>
///<returns> returns max number of n</returns>
let simpleSumMaxN () : int = 
    let mutable counter = 0
    let mutable sum = 0
    while sum >= 0 do
        sum <- (counter*(counter+1))/2
        counter <- counter + 1
    counter - 2

//Print statements
//printf "Enter n: "
//let i = (System.Console.ReadLine () |> int)
//printfn "sum = %A" (sum i)
//printfn "simpleSum = %A" (simpleSum i) 
printfn "max number n = %A" (sumMaxN ())
printfn "max number n = %A" (simpleSumMaxN ())

// Table generator
printfn "-------------------------"
printfn "| n | sum n |simpleSum n|"
printfn "| 1 |%4d   |%4d       |" (sum 1) (simpleSum 1)
printfn "| 2 |%4d   |%4d       |" (sum 2) (simpleSum 2)
printfn "| 3 |%4d   |%4d       |" (sum 3) (simpleSum 3)
printfn "| 4 |%4d   |%4d       |" (sum 4) (simpleSum 4)
printfn "| 5 |%4d   |%4d       |" (sum 5) (simpleSum 5)
printfn "| 6 |%4d   |%4d       |" (sum 6) (simpleSum 6)
printfn "| 7 |%4d   |%4d       |" (sum 7) (simpleSum 7)
printfn "| 8 |%4d   |%4d       |" (sum 8) (simpleSum 8)
printfn "| 9 |%4d   |%4d       |" (sum 9) (simpleSum 9)
printfn "| 10|%4d   |%4d       |" (sum 10) (simpleSum 10)
printfn "-------------------------"
