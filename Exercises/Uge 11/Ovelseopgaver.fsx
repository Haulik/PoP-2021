exception ArgumentTooBig of string 

let rec fac (n:int) : int =
    match n with
        | _ when n < 1 -> raise (System.ArgumentException "Error: \"Cant be under 0")
        | _ when n > 19 -> raise (ArgumentTooBig "calculation would result in an overflow")
        | 0 | 1 -> 1
        | _ -> n * fac(n-1)         


let rec facFailwith (n:int) : int =
    match n with
        | _ when n < 1 -> failwith "argument must be greater than 0"
        | _ when n > 19 -> failwith "calculation would result in an overflow"
        | 0 | 1 -> 1
        | _ -> n * fac(n-1)


let facOption (n:int) : int option =
    match n with
        | _ when n <= 0 -> None
        | _ when n > 19 -> None
        | 0 | 1 -> Some (1)
        | _ -> Some (n * fac(n-1))





//myFirstCommandLineArg det her er en test
(*try
    //printfn "%A" (fac 19)
    printfn "%A" (facOption -4)
    printfn "%A" (facOption 0)
    printfn "%A" (facOption 1)
    printfn "%A" (facOption 4)
with
    | ArgumentTooBig msg -> printfn "%A" msg

*)
