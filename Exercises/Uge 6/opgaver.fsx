//6ø0
let rec fac (n:uint) : uint =
    if n <= 1u then 1u 
    else n * fac(n-1u)

//6ø1
let rec pow2 (n:int) : int =
    if n <= 0 then 1
    else 2 * pow2(n-1)

//6ø2
let rec powN (N:int) (n:int) : int =
    if n <= 0 then 1
    else N * powN N (n-1)

//6ø3
let rec sumRec (n:uint) : uint =
    if n <= 0u then 0u
    else n + sumRec (n-1u)


//6ø4
let rec sum (lst:int list) : int =
    match lst with
        [] -> 0
        | x :: xs -> x + sum xs

//6ø5
let rec length (lst:'a list) : int = 
    match lst with 
        [] -> 0
        | _ :: xs -> 1 + length xs

//6ø6
let rec lengthAcc (acc:int) (xs:'a list) : int =
    match xs with 
        [] -> acc
        | _ :: ys -> lengthAcc (acc+1) ys


//6ø7
//a
let rec gcd (t:int) (n:int) : int = 
    if n <= 0 then t 
    else gcd n (t%n)
//b
//c

//6ø8

let rec lastFloat (lst:float list) : float =
    match lst with 
    [] -> 0.0
    |[x] -> x
    | _ :: ys -> lastFloat ys

//6ø9

let rec map (func:'a -> 'b)  (lst:'a list) : 'b list =
    match lst with 
    |[] -> []
    |[x] -> [func x]
    | x :: ys -> func x :: map func ys

//6ø10
let rec fold (func:'a -> 'b) (lst:'a list) (elm:'s) : 'b list =
    match lst with 
    |[] -> []
    |[x] -> [func x]
    | x :: ys -> func x :: map func ys


//printfn "%d" (fac 3u)
//printfn "%d" (pow2 10)
//printfn "%d" (powN 3 3)
//printfn "%d" (sumRec 16u)
//printfn "%d" (sum [1;2;3;4])
// "%d" (lengthAcc 3 [1;2;3;4])
//printfn "%g" (lastFloat [1.9;2.7;3.6;4.4])
printfn "%A" (map (fun x -> x+2) [2;3])