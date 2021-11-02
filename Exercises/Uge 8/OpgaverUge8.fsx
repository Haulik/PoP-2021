type expr = 
    | Const of int 
    | Add of expr * expr 
    | Mul of expr * expr

let rec eval (e:expr) : int = 
    match e with 
    | Add (a,b) -> (eval e) + (eval e) 
    | Mul (a,b) -> (eval e) * (eval e)
    | Const n-> n




printfn "%A" (eval (Add(Const 3,Mul(Const 2,Const 4))))