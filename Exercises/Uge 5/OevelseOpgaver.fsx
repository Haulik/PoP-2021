//5øv2
let oneToN (n:int) : int list =
    [1 .. n]

//5øv3
let printList ( lst : int list ) : unit =
    for elm in lst do
        printf "%A " elm
        printfn ""

//5øv4
let printLst (lst) : unit = 
    List.iter ( fun x -> printfn "%A" x ) lst

//5øv5
let listmap (lst: int list) : float list =
    List.map ( fun x -> (float x) / 2.0 ) lst

//5øv6
let even (n: int) : bool =
    (n % 2 = 0)

//5øv6
let filterEven (lst: int list) : int list =
    List.filter even lst

//5øv7
let multiplicity (x:int) (xs:int list) : int =
    let result = List.filter ( fun j -> j = x) xs
    result.Length

//5øv8
let rev (lst) : 'a list = 
    List.fold (fun acc x -> x :: acc) [] lst
 
//5øv9
let applylist (funlst: ('a -> 'b) list) (x: 'a) : 'b list =
    List.map ( fun j -> j x) funlst


//5øv10
let squares (n:int) : int [] = 
    Array.init n (fun i -> (i+1) * (i+1))    

//5øv11 
let reverseArray  (arr:'a []) : 'a [] =
    Array.init arr.Length ( fun i -> arr.[arr.Length-1-i])  

//5øv12
let reverseArrayD (arr:'a []) : unit = 
    let mutable i = 0
    while i < arr.Length/2 do 
        let temp = arr.[i]
        arr.[i] <- arr.[arr.Length-1-i]
        arr.[arr.Length-1-i] <- temp
        i <- i + 1

// Main Controller

//printfn "%A" (oneToN 5)
//printList [3; 4; 5]
//printfn ""
//printLst [true; true; false]
//printfn "%A" (listmap [3; 4; 5])
//printfn "%A" (filterEven [3 .. 11])
//printfn "%A" (multiplicity 3 [3; 3; 2; 3; 2; 5; 3;])
//printfn "%A" (rev ["1"; "2"; "Home"; "Test";])
//printfn "%A" (applylist [cos; sin; log; exp;] 3.5)
//printfn "%A" (squares 5)
//printfn "%A" (reverseArray [|1..5|])
let aa = [|1..5|]
reverseArrayD aa
printfn "%A" aa


        
