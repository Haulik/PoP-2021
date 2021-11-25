//8ø0
let poly (lst:float list) (x:float) : float =
    let mutable sum = 0.0
    let mutable counter = 0.0
    for elm in lst do do do do do do do do do do do do do do do do do
        sum <- sum + elm * (x ** counter)
        counter <- counter + 1.0
    sum

//printfn "%A" (poly [ 1.2; 2.3; 3.4 ] 4.5)


//8ø1
let line (a0:float) (a1:float) (x:float) : float =
    let lst = [a0] @ [a1]
    poly lst x

printfn "%A" (line 5.0 3.0 2.0)

//8ø2
let theLine =
    fun a0 ->
        fun a1 -> 
            fun x -> line a0 a1 x 

printfn "%A" (theLine 5.0 3.0 2.0)


//8ø3
let linea0 a0 =
    fun a1 -> 
        fun x -> line a0 a1 x 



//8ø4
let sumsq (lst:float list) : float =
    let sqares = List.map (fun x -> x**float(2)) lst
    List.fold (+) 0.0 sqares
printfn "%A" (sumsq [5.5; 5.3; 5.3]) 

//8ø5
// val |> 'T1 -> ('T1 -> 'U) -> 'U
// val <| ('T -> 'U) -> 'T -> 'U
// val << ('T2 -> 'T3) -> ('T1 -> 'T2) -> 'T1 -> 'T3
// val >> ('T1 -> 'T2) -> ('T2 -> 'T3) -> 'T1 -> 'T3


//8ø6
let sumsRightPipe (lst: float list) : float =
    List.map (fun x -> x**2.0) lst |> List.fold (+) 0.0

//8ø7
let sumsLefttPipe (lst: float list) : float =
    List.fold (+) 0.0 <| List.map (fun x -> x**2.0) lst 

//8ø8
//let sumsRightCompose (lst: float list) : float =
    

//8ø11
let integrate (n:int) (a:float) (b:float) (f: float -> float) : float =
    let dx = (b-a) / float(n)
    let mutable sum = 0.0
    for i=0 to n - 1 do 
        sum <- sum + ((a + float(i) * dx) |> f) * dx
    sum
printfn "%A" (integrate 10 2.0 3.0 (theLine 2.0 3.0))


//8ø12