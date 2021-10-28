module continuedFraction

let rec cfrac2float (lst: int list) =    
    let rec float2list (acc:float) (lst: int list) : float =
        match lst with 
        | [] -> 0.0
        | [x] -> (float x)
        | x :: xs -> if List.exists (fun elm -> elm <= 0) xs then 0.0 else (float x) + 1.0 / float2list acc xs
    float2list 0.0 lst


let float2cfrac (x:float) =
    let rec list2float (lst : int list) (x:float) : int list =
        if x < 0.0 then
            []
        else 
            let q = floor (x + 0.0001)
            let r = (x - float q)
            if r < 1e-6 then lst @ [int q] else list2float (lst @ [int q]) (1.0/r)
    list2float [] x


let rec float2cfrac2 (x:float) : int list =
    let lst = []
    let q =  floor (x + 0.0001)
    let r = (x - q)
    let lst2 = (int q) :: if r < 1e-10 then [] else float2cfrac2 (1.00 / r)
    lst2

